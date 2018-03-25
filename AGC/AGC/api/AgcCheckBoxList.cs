using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcCheckBoxList:AgcBase, IAgcAttach
    {
        private AgcCenter<AgcCheckbox> mAgcCenter;
        private List<AgcCheckbox> agcCheckBoxList = new List<AgcCheckbox>();
        private Dictionary<String, AgcCheckbox> checkBoxDic = new Dictionary<String, AgcCheckbox>();
        protected List<AgcBase> mAttachList = new List<AgcBase>();
        private int mPanelLength = 0;
        private String[] mCheckList;
        private Char mSeparate = '=';
        private Char mValueSeparate = '|';

        public AgcCheckBoxList(int index, String title, int panelLength, bool newRow, params String[] checkList)
            : base(index)
        {
            this.Title = title;
            this.mCheckList = checkList;
            this.NewRow = newRow;
            this.mPanelLength = panelLength;
        }

        public override object getValue()
        {
            String value = String.Empty;
            foreach (AgcCheckbox acb in agcCheckBoxList)
            {
                value += String.IsNullOrEmpty(acb.getValue().ToString()) ? "" : acb.getValue() + "|";
            }
            return value.Length > 2? value.Substring(0, value.Length-1): value;
        }

        public override void setValue(object obj)
        {
            String[] values = obj.ToString().Split(mValueSeparate);
            foreach (String v in values)
            {
                AgcCheckbox acb = this.getCheckBoxByTag(v);
                if (acb != null)
                {
                    acb.setValue(true);
                }
            }
        }

        protected override void setControl()
        {
            AgcControl agcLabel = new AgcControl();
            agcLabel.Index = 1;
            this.MLabel = new Label();
            this.MLabel.AutoSize = true;
            this.MLabel.Name = this.generateName();
            this.MLabel.Text = Title;
            this.MLabel.Width = this.MLabel.PreferredWidth;
            agcLabel.MControl = this.MLabel;

            AgcControl agcPanel = new AgcControl();
            agcPanel.MarginTop = -11;
            agcPanel.MarginLeft = -8;
            agcPanel.Index = 2;
            this.MPanel = new Panel();
            this.MPanel.TabIndex = this.Index;
            this.MPanel.Name = this.generateName();
            this.MPanel.Size = new System.Drawing.Size(mPanelLength, 25);
            this.MPanel.TabIndex = this.Index;
            agcPanel.MControl = this.MPanel;

            this.MAgcCtlList.Add(agcLabel);
            this.MAgcCtlList.Add(agcPanel);
        }

        public override bool afterAdd()
        {
            List<AgcBase> list = new List<AgcBase>();
            for (int i = 0; i < mCheckList.Length; i++)
            {
                String[] kv = mCheckList[i].Split(mSeparate);
                if (kv.Length != 2)
                {
                    continue;
                }

                AgcCheckbox agcCb = new AgcCheckbox(i, kv[1], kv[0]);
                list.Add(agcCb);
                agcCheckBoxList.Add(agcCb);
                checkBoxDic.Add(agcCb.Tag.ToString(), agcCb);
            }
            list.AddRange(mAttachList);
            AgcSetting setting = new AgcSetting(true);
            setting.MarginButtom = 0;
            setting.SpacingY = 0;
            mAgcCenter = new AgcCenter<AgcCheckbox>(this.MPanel, setting, list);
            return true;
        }

        private AgcCheckbox getCheckBoxByTag(String tag)
        {
            try
            {
                return checkBoxDic[tag];
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Label _mLabel;

        public Label MLabel
        {
            get { return _mLabel; }
            set { _mLabel = value; }
        }

        private Panel _mPanel;

        public Panel MPanel
        {
            get { return _mPanel; }
            set { _mPanel = value; }
        }


        #region IAgcAttach ≥…‘±

        List<AgcBase> IAgcAttach.getAttachList()
        {
            return mAttachList;
        }

        void IAgcAttach.attach(AgcBase agcBase)
        {
            mAttachList.Add(agcBase);
        }

        #endregion
    }
}

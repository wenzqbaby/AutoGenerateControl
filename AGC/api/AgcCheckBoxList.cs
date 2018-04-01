using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    /// <summary>
    /// Agc控件：Label、Panel、CheckBox的组合控件, 允许被附加
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public class AgcCheckBoxList:AgcBase, IAgcAttach
    {
        private AgcCenter<AgcCheckbox> mAgcCenter;
        private List<AgcCheckbox> agcCheckBoxList = new List<AgcCheckbox>();
        private Dictionary<String, AgcCheckbox> checkBoxDic = new Dictionary<String, AgcCheckbox>();
        protected List<AgcBase> mAttachList = new List<AgcBase>();
        private int mPanelWidth = 0;
        private String[] mCheckList;
        private Char mSeparate = '=';
        private Char mValueSeparate = '|';
        private bool mFontBold = true;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="panelWidth">包裹CheckBox的Panel的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="checkList">Checkbox的值和显示内容，为键值对组合，用'='分开，如："key=value"</param>
        public AgcCheckBoxList(int index, String title, int panelWidth, bool newRow, params String[] checkList)
            : base(index, title, newRow)
        {
            this.mCheckList = checkList;
            this.mPanelWidth = panelWidth;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="panelWidth">包裹CheckBox的Panel的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="labelBold">Label字体是否加粗</param>
        /// <param name="checkList">Checkbox的值和显示内容，为键值对组合，用'='分开，如："key=value"</param>
        public AgcCheckBoxList(int index, String title, int panelWidth, bool newRow, bool labelBold, params String[] checkList)
            : this(index, title, panelWidth, newRow, checkList)
        {
            this.mFontBold = labelBold;
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

        protected override void setValue(object obj)
        {
            String[] values = obj.ToString().Split(mValueSeparate);
            foreach (String v in values)
            {
                AgcCheckbox acb = this.getCheckBoxByTag(v);
                if (acb != null)
                {
                    acb.set(true);
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
            if (mFontBold)
            {
                this.MLabel.Font = new System.Drawing.Font(this.MLabel.Font, System.Drawing.FontStyle.Bold);
            }
            agcLabel.MControl = this.MLabel;

            AgcControl agcPanel = new AgcControl();
            agcPanel.MarginTop = -11;
            agcPanel.MarginLeft = -8;
            agcPanel.Index = 2;
            this.MPanel = new Panel();
            this.MPanel.TabIndex = this.Index;
            this.MPanel.Name = this.generateName();
            this.MPanel.Size = new System.Drawing.Size(mPanelWidth, 25);
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

                AgcCheckbox agcCb = new AgcCheckbox(i, kv[1].Trim(), kv[0].Trim());
                list.Add(agcCb);
                agcCheckBoxList.Add(agcCb);
                checkBoxDic[agcCb.Tag.ToString()]=agcCb;
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


        #region IAgcAttach 成员

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

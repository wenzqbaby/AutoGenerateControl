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
    /// Agc控件：Label、Panel、RadioButton的组合控件, 允许被附加
    /// @author wenzq
    /// @date   2018.3.31
    /// </summary>
    public class AgcRadioList: AgcBase, IAgcAttach
    {
        private AgcCenter<AgcCheckbox> mAgcCenter;
        public List<AgcRadioButton> agcrbList = new List<AgcRadioButton>();
        private Dictionary<String, AgcRadioButton> agcrbDic = new Dictionary<String, AgcRadioButton>();
        protected List<AgcBase> mAttachList = new List<AgcBase>();
        private int mPanelWidth = 0;
        private String[] mRbList;
        private Char mSeparate = '=';
        private Char mValueSeparate = '|';
        private bool mFontBold = true;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="panelWidth">包裹RadioButton的Panel的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="rbList">RadioButton的值和显示内容，为键值对组合，用'='分开，如："key=value"</param>
        public AgcRadioList(int index, String title, int panelWidth, bool newRow, params String[] rbList)
            : base(index, title)
        {
            mPanelWidth = panelWidth;
            this.NewRow = newRow;
            mRbList = rbList;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="panelWidth">包裹RadioButton的Panel的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="rbList">RadioButton的值和显示内容，为键值对组合，用'='分开，如："key=value"</param>
        public AgcRadioList(int index, String title, int panelWidth, bool newRow, bool labelBold, params String[] rbList)
            : this(index, title, panelWidth, newRow, rbList)
        {
            this.mFontBold = labelBold;
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
            for (int i = 0; i < mRbList.Length; i++)
            {
                String[] kv = mRbList[i].Split(mSeparate);
                if (kv.Length != 2)
                {
                    continue;
                }

                AgcRadioButton agcCb = new AgcRadioButton(i, kv[1].Trim(), kv[0].Trim());
                list.Add(agcCb);
                agcrbList.Add(agcCb);
                agcrbDic[agcCb.Tag.ToString()] = agcCb;
            }
            list.AddRange(mAttachList);
            AgcSetting setting = new AgcSetting(true);
            setting.MarginButtom = 0;
            setting.SpacingY = 0;
            mAgcCenter = new AgcCenter<AgcCheckbox>(this.MPanel, setting, list);
            return true;
        }

        public override object getValue()
        {
            foreach (AgcRadioButton r in agcrbList)
            {
                if (r.isChecked())
                {
                    return r.Tag.ToString();
                }
            }

            return String.Empty;
        }

        protected override void setValue(object obj)
        {
            String[] values = obj.ToString().Split(mValueSeparate);
            foreach (String v in values)
            {
                AgcRadioButton rb = getRadioButton(v);
                if (rb != null)
                {
                    rb.set(true);
                }
            }
        }

        #region IAgcAttach 成员

        public List<AgcBase> getAttachList()
        {
            return mAttachList;
        }

        public void attach(AgcBase agcBase)
        {
            mAttachList.Add(agcBase);
        }

        #endregion

        public AgcRadioButton getRadioButton(String rbTag)
        {
            try
            {
                return agcrbDic[rbTag];
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
    }
}

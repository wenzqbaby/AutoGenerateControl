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
    /// Agc�ؼ���Label��Panel��RadioButton����Ͽؼ�, ��������
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
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="panelWidth">����RadioButton��Panel�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        /// <param name="rbList">RadioButton��ֵ����ʾ���ݣ�Ϊ��ֵ����ϣ���'='�ֿ����磺"key=value"</param>
        public AgcRadioList(int index, String title, int panelWidth, bool newRow, params String[] rbList)
            : base(index, title)
        {
            mPanelWidth = panelWidth;
            this.NewRow = newRow;
            mRbList = rbList;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="panelWidth">����RadioButton��Panel�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        /// <param name="rbList">RadioButton��ֵ����ʾ���ݣ�Ϊ��ֵ����ϣ���'='�ֿ����磺"key=value"</param>
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

        #region IAgcAttach ��Ա

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

using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    /// <summary>
    /// ѡ��RadioButton�������д�ı������븽�ӵ������ؼ���ʹ��
    /// @author wenzq
    /// @date   2018.3.31
    /// </summary>
    public class AgcRadioText: AgcBase
    {
        private int mTextWidth;
        private int mMaxLength = 32767;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="attachProp">Ҫ���ӵ����������������Զ�Ӧ�Ŀؼ�����ʵ��AGC.interfaces.IAgcAttach�ӿ�</param>
        /// <param name="index">����</param>
        /// <param name="title">��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcRadioText(String attachProp, int index, String title, int textWidth, bool newRow)
            : base(index, title, newRow)
        {
            mTextWidth = textWidth;
            this.isAttach = true;
            this.attachProp = attachProp;
            this.Tag = String.Empty;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="attachProp">Ҫ���ӵ����������������Զ�Ӧ�Ŀؼ�����ʵ��AGC.interfaces.IAgcAttach�ӿ�</param>
        /// <param name="index">����</param>
        /// <param name="title">��ʾ������</param>
        /// <param name="textWidth">TextBox�ĳ���</param>
        /// <param name="maxLength">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcRadioText(String attachProp, int index, String title, int textWidth, int maxLength, bool newRow)
            : this(attachProp, index, title, textWidth, newRow)
        {
            this.mMaxLength = maxLength;
        }

        protected override void setControl()
        {
            AgcControl agcrb = new AgcControl();
            this.MRadioButton = new RadioButton();
            this.MRadioButton.AutoSize = true;
            this.MRadioButton.Name = this.generateName();
            this.MRadioButton.TabIndex = this.Index;
            this.MRadioButton.Text = this.Title;
            this.MRadioButton.Width = this.MRadioButton.PreferredSize.Width;
            this.MRadioButton.CheckedChanged += new EventHandler(MRadioButton_CheckedChanged);
            agcrb.MControl = this.MRadioButton;

            AgcControl agcText = new AgcControl();
            agcText.MarginTop = -4;
            agcText.MarginLeft = 2;
            agcText.Index = 2;
            this.MTextBox = new TextBox();
            this.MTextBox.TabIndex = this.Index + 1;
            this.MTextBox.Name = this.generateName();
            this.MTextBox.Size = new System.Drawing.Size(mTextWidth, 21);
            this.MTextBox.TabIndex = this.Index;
            this.MTextBox.Enabled = false;
            this.MTextBox.MaxLength = mMaxLength;
            agcText.MControl = this.MTextBox;

            this.MAgcCtlList.Add(agcrb);
            this.MAgcCtlList.Add(agcText);
        }

        public override object getValue()
        {
            if (MRadioButton.Checked)
            {
                return MTextBox.Text;
            }
            return String.Empty;
        }

        protected override void setValue(object obj)
        {
            this.MRadioButton.Checked = true;
            this.MTextBox.Text = obj.ToString();
        }

        void MRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            this.MTextBox.Enabled = this.MRadioButton.Checked;
            if (!this.MRadioButton.Checked)
            {
                this.MTextBox.Clear();
            }
        }

        private RadioButton _mRadioButton;

        public RadioButton MRadioButton
        {
            get { return _mRadioButton; }
            set { _mRadioButton = value; }
        }

        private TextBox _mTextBox;

        public TextBox MTextBox
        {
            get { return _mTextBox; }
            set { _mTextBox = value; }
        }
    }
}

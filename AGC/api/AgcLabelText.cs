using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using AGC.entity;
using System.Windows.Forms;

namespace AGC.api
{
    /// <summary>
    /// Agc�ؼ���Label��TextBox����Ͽؼ�
    /// @author wenzq
    /// @date   2018.3.24
    /// </summary>
    public class AgcLabelText : AgcBase, IValidate
    {
        private bool mFontBold = true;
        private int textWidth;
        private int mMaxLength = 32767;

        private Label _mLabel;

        public Label MLabel
        {
            get { return _mLabel; }
            set { _mLabel = value; }
        }
        private TextBox _textBox;

        public TextBox MTextBox
        {
            get { return _textBox; }
            set { _textBox = value; }
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelText(int index, String title, int textWidth, bool newRow)
            : base(index, title, newRow)
        {
            this.textWidth = textWidth;
            this.AfterX = 20;
        }
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�ĳ���</param>
        /// <param name="maxLenth">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelText(int index, String title, int textWidth, int maxLenth, bool newRow)
            : this(index, title, textWidth, newRow)
        {
            if (maxLenth > 0)
            {
                this.mMaxLength = maxLenth;
            }
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�ĳ���</param>
        /// <param name="maxLenth">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        /// <param name="labelBold">Label�����Ƿ�Ӵ�</param>
        public AgcLabelText(int index, String title, int textWidth, int maxLenth, bool newRow, bool labelBold)
            : this(index, title, textWidth, maxLenth, newRow)
        {
            this.mFontBold = labelBold;
        }

        public override object getValue()
        {
            return MTextBox.Text;
        }

        protected override void setValue(object obj)
        {
            MTextBox.Text = obj.ToString();
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

            AgcControl agcText = new AgcControl();
            agcText.MarginTop = -4;
            agcText.MarginLeft = 2;
            agcText.Index = 2;
            this.MTextBox = new TextBox();
            this.MTextBox.TabIndex = this.Index;
            this.MTextBox.Name = this.generateName();
            this.MTextBox.Size = new System.Drawing.Size(textWidth, 21);
            this.MTextBox.TabIndex = this.Index;
            this.MTextBox.MaxLength = mMaxLength;
            agcText.MControl = this.MTextBox;

            this.MAgcCtlList.Add(agcLabel);
            this.MAgcCtlList.Add(agcText);
        }

        #region IValidate ��Ա

        public Control getValidateControl()
        {
            return this.MTextBox;
        }

        public void validateSuccess()
        {
            
        }

        public void validateFail(string failMsg)
        {
            
        }

        #endregion
    }
}

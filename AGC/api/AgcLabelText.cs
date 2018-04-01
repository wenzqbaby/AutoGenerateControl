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
    /// Agc控件：Label和TextBox的组合控件
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
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelText(int index, String title, int textWidth, bool newRow)
            : base(index, title, newRow)
        {
            this.textWidth = textWidth;
            this.AfterX = 20;
        }
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的长度</param>
        /// <param name="maxLenth">TextBox可输入的字符最大长度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelText(int index, String title, int textWidth, int maxLenth, bool newRow)
            : this(index, title, textWidth, newRow)
        {
            if (maxLenth > 0)
            {
                this.mMaxLength = maxLenth;
            }
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的长度</param>
        /// <param name="maxLenth">TextBox可输入的字符最大长度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="labelBold">Label字体是否加粗</param>
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

        #region IValidate 成员

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

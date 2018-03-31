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
    /// 选中后才能填写文本，必须附加到其他控件上使用
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public class AgcCheckText: AgcBase
    {
        private int mTextLength;

        public AgcCheckText(String attachProp, int index, String title, int textLength, bool newRow)
            : base(index)
        {
            this.Index = index;
            this.Title = title;
            mTextLength = textLength;
            this.NewRow = newRow;
            this.isAttach = true;
            this.attachProp = attachProp;
            this.Tag = String.Empty;
        }

        public override object getValue()
        {
            if (MCheckBox.Checked)
            {
                return MTextBox.Text;
            }
            return String.Empty;
        }

        protected override void setValue(object obj)
        {
            this.MCheckBox.Checked = true;
            this.MTextBox.Text = obj.ToString();
        }

        protected override void setControl()
        {
            AgcControl agcCheckBox = new AgcControl();
            this.MCheckBox = new CheckBox();
            this.MCheckBox.AutoSize = true;
            this.MCheckBox.Name = this.generateName();
            this.MCheckBox.TabIndex = this.Index;
            this.MCheckBox.Text = this.Title;
            this.MCheckBox.Width = this.MCheckBox.PreferredSize.Width;
            this.MCheckBox.CheckedChanged += new EventHandler(MCheckBox_CheckedChanged);
            agcCheckBox.MControl = this.MCheckBox;

            AgcControl agcText = new AgcControl();
            agcText.MarginTop = -4;
            agcText.MarginLeft = 2;
            agcText.Index = 2;
            this.MTextBox = new TextBox();
            this.MTextBox.TabIndex = this.Index + 1;
            this.MTextBox.Name = this.generateName();
            this.MTextBox.Size = new System.Drawing.Size(mTextLength, 21);
            this.MTextBox.TabIndex = this.Index;
            this.MTextBox.Enabled = false;
            agcText.MControl = this.MTextBox;

            this.MAgcCtlList.Add(agcCheckBox);
            this.MAgcCtlList.Add(agcText);
        }

        void MCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.MTextBox.Enabled = this.MCheckBox.Checked;
            if (!this.MCheckBox.Checked)
            {
                this.MTextBox.Clear();
            }
        }

        private CheckBox _mCheckBox;

        public CheckBox MCheckBox
        {
            get { return _mCheckBox; }
            set { _mCheckBox = value; }
        }

        private TextBox _mTextBox;

        public TextBox MTextBox
        {
            get { return _mTextBox; }
            set { _mTextBox = value; }
        }
    }
}

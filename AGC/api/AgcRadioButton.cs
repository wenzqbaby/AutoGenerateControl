using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcRadioButton:AgcBase
    {
        private RadioButton _mRadioButton;

        public RadioButton MRadioButton
        {
            get { return _mRadioButton; }
            set { _mRadioButton = value; }
        }

        public AgcRadioButton(int index, String title, String value)
            : base(index, title)
        {
            this.Tag = value;
        }

        protected override void setControl()
        {
            AgcControl agc = new AgcControl();
            this.MRadioButton = new RadioButton();
            this.MRadioButton.AutoSize = true;
            this.MRadioButton.Name = this.generateName();
            this.MRadioButton.TabIndex = this.Index;
            this.MRadioButton.Text = this.Title;
            this.MRadioButton.Width = this.MRadioButton.PreferredSize.Width;
            agc.MControl = this.MRadioButton;

            this.MAgcCtlList.Add(agc);
        }

        public override object getValue()
        {
            if (this.MRadioButton.Checked)
            {
                return this.Tag;
            }
            return String.Empty;
        }

        protected override void setValue(object obj)
        {
            this.MRadioButton.Checked = Convert.ToBoolean(obj);
        }

        public bool isChecked()
        {
            return this.MRadioButton.Checked;
        }
    }
}

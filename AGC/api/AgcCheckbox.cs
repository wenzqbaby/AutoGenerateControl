using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcCheckbox:AgcBase
    {
        private CheckBox _mCheckBox;

        public CheckBox MCheckBox
        {
            get { return _mCheckBox; }
            set { _mCheckBox = value; }
        }

        public AgcCheckbox(int index, String title, String value)
            : base(index, title)
        {
            this.Tag = value;
        }

        public override object getValue()
        {
            if (this.MCheckBox.Checked)
            {
                return this.Tag.ToString();
            }
            return String.Empty;
        }

        public bool isChecked()
        {
            return this.MCheckBox.Checked;
        }

        protected override void setValue(object obj)
        {
            this.MCheckBox.Checked = Convert.ToBoolean(obj);
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
            agcCheckBox.MControl = this.MCheckBox;

            this.MAgcCtlList.Add(agcCheckBox);
        }
    }
}

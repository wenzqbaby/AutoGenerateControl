using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcLabelCombo: AgcBase
    {
        private String[] mOptions;
        private int mCbLength;

        public AgcLabelCombo(int index, String title, int cbLength, params String[] options):base(index)
        {
            this.Index = index;
            this.Title = title;
            mCbLength = cbLength;
            mOptions = options;
        }

        protected override void setControl()
        {
            AgcControl agcLabel = new AgcControl();
            agcLabel.Index = 1;
            this.MLabel = new Label();
            this.MLabel.AutoSize = true;
            this.MLabel.Name = this.generateName();
            this.MLabel.Text = this.Title;
            this.MLabel.Width = this.MLabel.PreferredWidth;
            agcLabel.MControl = this.MLabel;

            AgcControl agcComboBox = new AgcControl();
            agcComboBox.Index = 2;
            agcComboBox.MarginTop = -4;
            agcComboBox.MarginLeft = 2;
            this.MComboBox = new ComboBox();
            this.MComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.MComboBox.FormattingEnabled = true;
            this.MComboBox.Name = this.generateName();
            this.MComboBox.Size = new System.Drawing.Size(mCbLength, 20);
            this.MComboBox.TabIndex = this.Index;
            List<AgcKeyValue> list = new List<AgcKeyValue>();
            foreach (String var in mOptions)
            {
                String[] o = var.Split('=');
                list.Add(new AgcKeyValue(o[0], o[1]));
            }
            this.MComboBox.DataSource = list;
            this.MComboBox.DisplayMember = "Value";
            this.MComboBox.ValueMember = "Key";
            //this.MComboBox.SelectedIndex = 0;
            agcComboBox.MControl = this.MComboBox;

            this.MAgcCtlList.Add(agcLabel);
            this.MAgcCtlList.Add(agcComboBox);
        }

        public override object getValue()
        {
            return this.MComboBox.SelectedValue.ToString();
        }

        protected override void setValue(object obj)
        {
            this.MComboBox.SelectedValue = obj.ToString();
        }

        private Label _mLabel;

        public Label MLabel
        {
            get { return _mLabel; }
            set { _mLabel = value; }
        }

        private ComboBox _mComboBox;

        public ComboBox MComboBox
        {
            get { return _mComboBox; }
            set { _mComboBox = value; }
        }

    }
}

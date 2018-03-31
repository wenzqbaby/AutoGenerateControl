using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    /// <summary>
    /// Agc控件：Label和ComboBox的组合控件
    /// @author wenzq
    /// @date   2018.3.26
    /// </summary>
    public class AgcLabelCombo: AgcBase
    {
        private String[] mOptions;
        private int mCbLength;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="cbLength">ComboBox的宽度</param>
        /// <param name="options">ComboBox的选项为键值对组合，用'='分开，如："key=value"</param>
        public AgcLabelCombo(int index, String title, int cbLength, params String[] options)
            : base(index, title)
        {
            mCbLength = cbLength;
            mOptions = options;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="cbLength">ComboBox的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="options">ComboBox的选项为键值对组合，用'='分开，如："key=value"</param>
        public AgcLabelCombo(int index, String title, int cbLength, bool newRow, params String[] options)
            : base(index, title, newRow)
        {
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
                if (o.Length != 2)
                {
                    continue;
                }
                list.Add(new AgcKeyValue(o[0].Trim(), o[1].Trim()));
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

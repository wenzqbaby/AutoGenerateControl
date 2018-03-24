using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using AGC.entity;
using System.Windows.Forms;
using System.Drawing;

namespace AGC.api
{
    public class AgcLabel: AgcBase, IAgc
    {
        public AgcLabel(int index, String label, int valueWidth, bool newRow):base(index)
        {
            this.Title = label;
            this.MarginRight = valueWidth;
            this.NewRow = newRow;
        }

        protected override void init()
        {
            mIAgc = this;
        }

        public override object getValue()
        {
            return this.MLabelValue.Text;
        }

        public override void setValue(object obj)
        {
            this.MLabelValue.Text = obj.ToString();
            this.MLabelValue.Width = this.MLabelValue.PreferredWidth;
        }

        #region IAgc ≥…‘±

        List<AgcControl> IAgc.generate()
        {
            List<AgcControl> list = new List<AgcControl>();
            AgcControl agcLabelTitle = new AgcControl();
            agcLabelTitle.Index = 1;
            this.MLabelTitle = new Label();
            this.MLabelTitle.AutoSize = true;
            this.MLabelTitle.Name = this.generateName();
            this.MLabelTitle.Text = this.Title;
            this.MLabelTitle.Width = this.MLabelTitle.PreferredWidth;
            agcLabelTitle.MControl = this.MLabelTitle;

            AgcControl agcLabelValue = new AgcControl();
            agcLabelValue.Index = 2;
            agcLabelValue.MarginLeft = 2;
            this.MLabelValue = new Label();
            this.MLabelValue.AutoSize = true;
            this.MLabelValue.Name = this.generateName();
            this.MLabelValue.Text = String.Empty;
            this.MLabelValue.Width = this.MLabelValue.PreferredWidth;
            agcLabelValue.MControl = this.MLabelValue;

            list.Add(agcLabelTitle);
            list.Add(agcLabelValue);
            return list;
        }

        #endregion

        private Label _mLabelTitle;

        public Label MLabelTitle
        {
            get { return _mLabelTitle; }
            set { _mLabelTitle = value; }
        }

        private Label _mLabelValue;

        public Label MLabelValue
        {
            get { return _mLabelValue; }
            set { _mLabelValue = value; }
        }

    }
}

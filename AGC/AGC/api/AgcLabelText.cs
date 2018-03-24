using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using AGC.entity;
using System.Windows.Forms;
using AGC.utils;

namespace AGC.api
{
    public class AgcLabelText : AgcBase, IAgc
    {
        private int textLength;

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

        public AgcLabelText(int index, String label, int textlength, bool newRow)
            : base(index)
        {
            this.Title = label;
            this.textLength = textlength;
            this.AfterX = 20;
            this.NewRow = newRow;
        }

        protected override void init()
        {
            mIAgc = this;
        }

        public override object getValue()
        {
            return _textBox.Text;
        }

        public override void setValue(object obj)
        {
            _textBox.Text = obj.ToString();
        }

        #region IAgc ≥…‘±

        List<AgcControl> IAgc.generate()
        {
            List<AgcControl> list = new List<AgcControl>();
            AgcControl agcLabel = new AgcControl();
            agcLabel.Index = 1;
            this.MLabel = new Label();
            this.MLabel.AutoSize = true;
            this.MLabel.Name = this.generateName();
            this.MLabel.Text = Title;
            this.MLabel.Width = this.MLabel.PreferredWidth;
            agcLabel.MControl = this.MLabel;

            AgcControl agcText = new AgcControl();
            agcText.MarginTop = -4;
            agcText.MarginLeft = 2;
            agcText.Index = 2;
            this.MTextBox = new TextBox();
            this.MTextBox.TabIndex = this.Index;
            this.MTextBox.Name = this.generateName();
            this.MTextBox.Size = new System.Drawing.Size(textLength, 21);
            this.MTextBox.TabIndex = this.Index;
            agcText.MControl = this.MTextBox;

            list.Add(agcLabel);
            list.Add(agcText);
            return list;
        }

        #endregion
    }
}

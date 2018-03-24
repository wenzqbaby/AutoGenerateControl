using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcLabelDate: AgcBase, IAgc
    {
        public AgcLabelDate(int index, String label):base(index)
        {
            this.Title = label;
        }

        private DateTimePicker _mDateTimePicker;

        public DateTimePicker MDateTimePicker
        {
            get { return _mDateTimePicker; }
            set { _mDateTimePicker = value; }
        }

        private Label _mLabel;

        public Label MLabel
        {
            get { return _mLabel; }
            set { _mLabel = value; }
        }

        protected override void init()
        {
            mIAgc = this;
        }

        public override object getValue()
        {
            return this.MDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 参数格式为yyyy-MM-dd HH:mm:ss的字符串
        /// </summary>
        /// <param name="obj"></param>
        public override void setValue(object obj)
        {
            try
            {
                DateTime dt = DateTime.Parse(obj.ToString());
                this.MDateTimePicker.Value = dt;
            }
            catch (Exception e)
            {
                throw new Exception(String.Format("{0} 设置值 {1} 的日期格式错误，应为yyyy-MM-dd HH:mm:ss的字符串 {2}", mTAG, obj.ToString(), e.Message));
            }
            
        }

        #region IAgc 成员

        List<AgcControl> IAgc.generate()
        {
            List<AgcControl> list = new List<AgcControl>();
            AgcControl agcLabel = new AgcControl();
            agcLabel.Index = 1;
            this.MLabel = new Label();
            this.MLabel.AutoSize = true;
            this.MLabel.Name = this.generateName();
            this.MLabel.Text = this.Title;
            this.MLabel.Width = this.MLabel.PreferredWidth;
            agcLabel.MControl = this.MLabel;

            AgcControl agcDtp = new AgcControl();
            agcDtp.Index = 2;
            agcDtp.MarginLeft = 2;
            agcDtp.MarginTop = -4;
            this.MDateTimePicker = new DateTimePicker();
            this.MDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.MDateTimePicker.Name = this.generateName();
            this.MDateTimePicker.TabIndex = this.Index;
            agcDtp.MControl = this.MDateTimePicker;

            list.Add(agcLabel);
            list.Add(agcDtp);
            return list;
        }

        #endregion
    }
}

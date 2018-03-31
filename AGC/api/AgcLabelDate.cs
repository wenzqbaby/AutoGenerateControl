using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcLabelDate: AgcBase, IAgcAttach
    {
        public AgcLabelDate(int index, String label, bool newRow):base(index)
        {
            this.Title = label;
            this.NewRow = NewRow;
        }

        public AgcLabelDate(int index, bool attach, String prop, String label, bool newRow)
            : base(index)
        {
            this.Index = index;
            this.isAttach = attach;
            this.attachProp = prop;
            this.Title = label;
            this.NewRow = newRow;

            this.addControl(2, 3);
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

        public override object getValue()
        {
            return this.MDateTimePicker.Value.ToString("yyyy-MM-dd HH:mm:ss");
        }

        /// <summary>
        /// 参数格式为yyyy-MM-dd HH:mm:ss的字符串
        /// </summary>
        /// <param name="obj"></param>
        protected override void setValue(object obj)
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

        protected override void setControl()
        {
            addControl(1, 2);
        }

        private void addControl(int labelIndex, int dtpIndex)
        {
            AgcControl agcLabel = new AgcControl();
            agcLabel.Index = labelIndex;
            this.MLabel = new Label();
            this.MLabel.AutoSize = true;
            this.MLabel.Name = this.generateName();
            this.MLabel.Text = this.Title;
            this.MLabel.Width = this.MLabel.PreferredWidth;
            agcLabel.MControl = this.MLabel;

            AgcControl agcDtp = new AgcControl();
            agcDtp.Index = dtpIndex;
            agcDtp.MarginLeft = 2;
            agcDtp.MarginTop = -4;
            agcDtp.MarginRight = 2;
            this.MDateTimePicker = new DateTimePicker();
            this.MDateTimePicker.Size = new System.Drawing.Size(200, 21);
            this.MDateTimePicker.Name = this.generateName();
            this.MDateTimePicker.TabIndex = this.Index;
            agcDtp.MControl = this.MDateTimePicker;

            this.MAgcCtlList.Add(agcLabel);
            this.MAgcCtlList.Add(agcDtp);
        }

        #region IAgcAttach 成员

        private List<AgcBase> attachList = new List<AgcBase>();

        public List<AgcBase> getAttachList()
        {
            return attachList;
        }

        public void attach(AgcBase agcBase)
        {
            attachList.Add(agcBase);
            foreach (AgcControl ac in agcBase.MAgcCtlList)
            {
                this.MAgcCtlList.Add(ac);
            }
        }

        #endregion
    }
}

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
    /// Agc控件：Label、DateTimePicker的组合控件, 取值和设置的日期格式为字符串"yyyy-MM-dd HH:mm:ss", 允许被附加
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public class AgcLabelDate: AgcBase, IAgcAttach
    {
        private int mDateWidth = 130;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelDate(int index, String title, bool newRow)
            : base(index, title, newRow) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="dateTimePickerWidth">DateTimePicker的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelDate(int index, String title, int dateTimePickerWidth, bool newRow)
            : this(index, title, newRow)
        {
            this.mDateWidth = dateTimePickerWidth;
        }

        /// <summary>
        /// 构造方法，用于附加到其他控件
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="prop">要附加到的属性名，该属性对应的控件必须实现AGC.interfaces.IAgcAttach接口</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelDate(int index, String prop, String title, bool newRow)
            : base(index, title, newRow)
        {
            this.isAttach = true;
            this.attachProp = prop;

            this.addControl(2, 3);
        }

        /// <summary>
        /// 构造方法，用于附加到其他控件
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="prop">要附加到的属性名，该属性对应的控件必须实现AGC.interfaces.IAgcAttach接口</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="dateTimePickerWidth">DateTimePicker的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelDate(int index, String prop, String title, int dateTimePickerWidth, bool newRow)
            : this(index, prop, title, newRow)
        {
            this.mDateWidth = dateTimePickerWidth;
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
            this.MDateTimePicker.Size = new System.Drawing.Size(mDateWidth, 21);
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

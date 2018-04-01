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
    /// <summary>
    /// Agc控件：Label和Label的组合控件
    /// @author wenzq
    /// @date   2018.3.24
    /// </summary>
    public class AgcLabel: AgcBase
    {
        private bool mFontBold = true;
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="valueWidth">显示值的Label的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabel(int index, String title, int valueWidth, bool newRow)
            : base(index, title, newRow)
        {
            this.MarginRight = valueWidth;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="valueWidth">显示值的Label的宽度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="labelBold">Label字体是否加粗</param>
        public AgcLabel(int index, String title, int valueWidth, bool newRow, bool labelBold)
            : this(index, title, valueWidth, newRow)
        {
            this.mFontBold = labelBold;
        }

        public override object getValue()
        {
            return this.MLabelValue.Text;
        }

        protected override void setValue(object obj)
        {
            if (obj == null)
            {
                return;
            }
            this.MLabelValue.Text = obj.ToString();
            this.MLabelValue.Width = this.MLabelValue.PreferredWidth;
        }

        protected override void setControl()
        {
            AgcControl agcLabelTitle = new AgcControl();
            agcLabelTitle.Index = 1;
            this.MLabelTitle = new Label();
            this.MLabelTitle.AutoSize = true;
            this.MLabelTitle.Name = this.generateName();
            this.MLabelTitle.Text = this.Title;
            this.MLabelTitle.Width = this.MLabelTitle.PreferredWidth;
            if (mFontBold)
            {
                this.MLabelTitle.Font = new Font(this.MLabelTitle.Font, FontStyle.Bold);
            }
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

            this.MAgcCtlList.Add(agcLabelTitle);
            this.MAgcCtlList.Add(agcLabelValue);
        }


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

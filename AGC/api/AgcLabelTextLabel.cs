using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    public class AgcLabelTextLabel:AgcLabelText
    {
        private String mBehineText;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的宽度</param>
        /// <param name="behindText">在TextBox后面显示的Label的内容</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelTextLabel(int index, String title, int textWidth, String behindText, bool newRow)
            : base(index, title, textWidth, newRow)
        {
            mBehineText = behindText;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的长度</param>
        /// <param name="maxLenth">TextBox可输入的字符最大长度</param>
        /// <param name="behindText">在TextBox后面显示的Label的内容</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelTextLabel(int index, String title, int textWidth, int maxLenth, String behindText, bool newRow)
            : base(index, title, textWidth, maxLenth, newRow)
        {
            mBehineText = behindText;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的长度</param>
        /// <param name="maxLenth">TextBox可输入的字符最大长度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="labelBold">Label字体是否加粗</param>
        public AgcLabelTextLabel(int index, String title, int textWidth, int maxLenth, String behindText, bool newRow, bool labelBold)
            : base(index, title, textWidth, maxLenth, newRow, labelBold)
        {
            mBehineText = behindText;
        }

        protected override void setControl()
        {
            base.setControl();

            AgcControl agcBehind = new AgcControl();
            agcBehind.Index = 3;
            this.MLabelBehine = new Label();
            this.MLabelBehine.AutoSize = true;
            this.MLabelBehine.Name = this.generateName();
            this.MLabelBehine.Text = mBehineText;
            this.MLabelBehine.Width = this.MLabelBehine.PreferredWidth;
            agcBehind.MControl = this.MLabelBehine;

            MAgcCtlList.Add(agcBehind);
        }

        private Label _mLabelBehine;
        /// <summary>
        /// TextBox后面的Label
        /// </summary>
        public Label MLabelBehine
        {
            get { return _mLabelBehine; }
            set { _mLabelBehine = value; }
        }
    }
}

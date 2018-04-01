using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.api
{
    /// <summary>
    /// Agc控件：Label和多行输入TextBox的组合控件
    /// @author wenzq
    /// @date   2018.3.31
    /// </summary>
    public class AgcLabelTextarea: AgcLabelText
    {
        private int mTextHeight = 21;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的宽度</param>
        /// <param name="textHeight">TextBox的高度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelTextarea(int index, String title, int textWidth, int textHeight, bool newRow)
            : base(index, title, textWidth, newRow)
        {
            this.mTextHeight = textHeight;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的宽度</param>
        /// <param name="textHeight">TextBox的高度</param>
        /// <param name="maxLength">TextBox可输入的字符最大长度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        public AgcLabelTextarea(int index, String title, int textWidth, int textHeight, int maxLength, bool newRow)
            : base(index, title, textWidth, maxLength, newRow)
        {
            this.mTextHeight = textHeight;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">Label显示的内容</param>
        /// <param name="textWidth">TextBox的宽度</param>
        /// <param name="textHeight">TextBox的高度</param>
        /// <param name="maxLength">TextBox可输入的字符最大长度</param>
        /// <param name="newRow">是否在新的一行创建</param>
        /// <param name="labelBold">Label字体是否加粗</param>
        public AgcLabelTextarea(int index, String title, int textWidth, int textHeight, int maxLength, bool newRow, bool labelBold)
            : base(index, title, textWidth, maxLength, newRow, labelBold)
        {
            this.mTextHeight = textHeight;
        }

        protected override void afterSetControl()
        {
            this.MTextBox.Multiline = true;
            this.MTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MTextBox.Size = new System.Drawing.Size(this.MTextBox.Size.Width, mTextHeight);
        }
    }
}

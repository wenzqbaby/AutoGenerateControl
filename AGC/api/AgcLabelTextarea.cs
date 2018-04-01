using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.api
{
    /// <summary>
    /// Agc�ؼ���Label�Ͷ�������TextBox����Ͽؼ�
    /// @author wenzq
    /// @date   2018.3.31
    /// </summary>
    public class AgcLabelTextarea: AgcLabelText
    {
        private int mTextHeight = 21;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="textHeight">TextBox�ĸ߶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelTextarea(int index, String title, int textWidth, int textHeight, bool newRow)
            : base(index, title, textWidth, newRow)
        {
            this.mTextHeight = textHeight;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="textHeight">TextBox�ĸ߶�</param>
        /// <param name="maxLength">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelTextarea(int index, String title, int textWidth, int textHeight, int maxLength, bool newRow)
            : base(index, title, textWidth, maxLength, newRow)
        {
            this.mTextHeight = textHeight;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="textHeight">TextBox�ĸ߶�</param>
        /// <param name="maxLength">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        /// <param name="labelBold">Label�����Ƿ�Ӵ�</param>
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

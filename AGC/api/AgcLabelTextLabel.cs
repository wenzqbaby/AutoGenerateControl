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
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�Ŀ��</param>
        /// <param name="behindText">��TextBox������ʾ��Label������</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelTextLabel(int index, String title, int textWidth, String behindText, bool newRow)
            : base(index, title, textWidth, newRow)
        {
            mBehineText = behindText;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�ĳ���</param>
        /// <param name="maxLenth">TextBox��������ַ���󳤶�</param>
        /// <param name="behindText">��TextBox������ʾ��Label������</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelTextLabel(int index, String title, int textWidth, int maxLenth, String behindText, bool newRow)
            : base(index, title, textWidth, maxLenth, newRow)
        {
            mBehineText = behindText;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="textWidth">TextBox�ĳ���</param>
        /// <param name="maxLenth">TextBox��������ַ���󳤶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        /// <param name="labelBold">Label�����Ƿ�Ӵ�</param>
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
        /// TextBox�����Label
        /// </summary>
        public Label MLabelBehine
        {
            get { return _mLabelBehine; }
            set { _mLabelBehine = value; }
        }
    }
}

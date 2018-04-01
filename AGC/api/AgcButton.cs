using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.api
{
    /// <summary>
    /// ��ť
    /// @author wenzq
    /// @date   2018.3.31
    /// </summary>
    public class AgcButton: AgcBase
    {
        private int mBtnWidth = 0;
        private int mBtnHeight = 0;
        private EventHandler mEventHandler;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Button��ʾ������</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcButton(int index, String title, bool newRow)
            : base(index, title, newRow) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="e">��ť����¼�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcButton(int index, String title, EventHandler e, bool newRow)
            : base(index, title, newRow) 
        {
            mEventHandler = e;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Button��ʾ������</param>
        /// <param name="width">Button�Ŀ��</param>
        /// <param name="height">Button�ĸ߶�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcButton(int index, String title, int width, int height,  bool newRow)
            : base(index, title, newRow)
        {
            mBtnWidth = width;
            mBtnHeight = height;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Button��ʾ������</param>
        /// <param name="width">Button�Ŀ��</param>
        /// <param name="height">Button�ĸ߶�</param>
        /// <param name="e">��ť����¼�</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcButton(int index, String title, int width, int height, EventHandler e, bool newRow)
            : this(index, title, width, height, newRow)
        {
            mEventHandler = e;
        }

        protected override void setControl()
        {
            AgcControl agcbutton = new AgcControl();
            agcbutton.Index = 1;
            this.MButton = new Button();
            if (mBtnWidth == 0 && mBtnHeight == 0)
            {
                this.MButton.AutoSize = true;
            }
            else
            {
                this.MButton.Size = new System.Drawing.Size(mBtnWidth, mBtnHeight);
            }
            this.MButton.Name = this.generateName();
            this.MButton.Text = this.Title;
            this.MButton.UseVisualStyleBackColor = true;
            this.MButton.Width = this.MButton.PreferredSize.Width;
            if (mEventHandler !=null)
            {
                this.MButton.Click += mEventHandler;
            }
            agcbutton.MControl = this.MButton;

            MAgcCtlList.Add(agcbutton);
        }

        public override object getValue()
        {
            return this.MButton.Text;
        }

        protected override void setValue(object obj)
        {
            return;
        }

        private Button _mButton;

        public Button MButton
        {
            get { return _mButton; }
            set { _mButton = value; }
        }
    }
}

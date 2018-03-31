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
    /// Agc�ؼ���Label��DateTimePicker����Ͽؼ�, ȡֵ�����õ����ڸ�ʽΪ�ַ���"yyyy-MM-dd HH:mm:ss", ��������
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public class AgcLabelDate: AgcBase, IAgcAttach
    {
        private int mDateWidth = 130;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelDate(int index, String title, bool newRow)
            : base(index, title, newRow) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="dateTimePickerWidth">DateTimePicker�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelDate(int index, String title, int dateTimePickerWidth, bool newRow)
            : this(index, title, newRow)
        {
            this.mDateWidth = dateTimePickerWidth;
        }

        /// <summary>
        /// ���췽�������ڸ��ӵ������ؼ�
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="prop">Ҫ���ӵ����������������Զ�Ӧ�Ŀؼ�����ʵ��AGC.interfaces.IAgcAttach�ӿ�</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
        public AgcLabelDate(int index, String prop, String title, bool newRow)
            : base(index, title, newRow)
        {
            this.isAttach = true;
            this.attachProp = prop;

            this.addControl(2, 3);
        }

        /// <summary>
        /// ���췽�������ڸ��ӵ������ؼ�
        /// </summary>
        /// <param name="index">����</param>
        /// <param name="prop">Ҫ���ӵ����������������Զ�Ӧ�Ŀؼ�����ʵ��AGC.interfaces.IAgcAttach�ӿ�</param>
        /// <param name="title">Label��ʾ������</param>
        /// <param name="dateTimePickerWidth">DateTimePicker�Ŀ��</param>
        /// <param name="newRow">�Ƿ����µ�һ�д���</param>
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
        /// ������ʽΪyyyy-MM-dd HH:mm:ss���ַ���
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
                throw new Exception(String.Format("{0} ����ֵ {1} �����ڸ�ʽ����ӦΪyyyy-MM-dd HH:mm:ss���ַ��� {2}", mTAG, obj.ToString(), e.Message));
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

        #region IAgcAttach ��Ա

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

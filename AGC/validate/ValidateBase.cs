using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AGC.interfaces;

namespace AGC.validate
{
    /// <summary>
    /// У�����
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class ValidateBase : Attribute
    {
        public ValidateBase() { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        public ValidateBase(String failMsg)
        {
            this.FailMsg = failMsg;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        /// <param name="addValidateEvent">�Ƿ����У���¼����ؼ���</param>
        public ValidateBase(String failMsg, bool addValidateEvent)
            : this(failMsg)
        {
            this.AddEvent = addValidateEvent;
        }

        public void init()
        {
            if (this.AddEvent && MIValidate != null && MIValidate.getValidateControl() != null)
            {
                this.addValidateEvent(MIValidate.getValidateControl());
            }
        }

        private bool _addEvent = false;
        /// <summary>
        /// ��AgcBase����һ������ã���������Ϊtrue������MIValidate��Ϊ�գ��������У���¼���MIValidate��ȡ���Ŀؼ���
        /// </summary>
        public bool AddEvent
        {
            get { return _addEvent; }
            set { _addEvent = value; }
        }

        private IValidate _mIValidate;

        public IValidate MIValidate
        {
            get { return _mIValidate; }
            set { _mIValidate = value; }
        }

        private String _failMsg;
        /// <summary>
        /// У��ʧ�ܵ���ʾ��Ϣ
        /// </summary>
        public String FailMsg
        {
            get { return _failMsg; }
            set { _failMsg = value; }
        }

        /// <summary>
        /// У��
        /// </summary>
        /// <returns></returns>
        public abstract bool validate(Object value);

        public virtual void addValidateEvent(Control control) { }
    }
}

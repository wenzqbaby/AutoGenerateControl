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

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        /// <param name="addValidateEvent">�Ƿ����У���¼����ؼ���</param>
        /// <param name="allowNull">�Ƿ������ֵ����ַ���</param>
        public ValidateBase(String failMsg, bool addValidateEvent, bool allowNull)
            : this(failMsg, addValidateEvent)
        {
            this.AllowNull = allowNull;
        }

        public void init()
        {
            if (this.AddEvent && MIValidate != null && MIValidate.getValidateControl() != null)
            {
                this.addValidateEvent(MIValidate.getValidateControl());
            }
        }

        private bool _allowNull = true;
        /// <summary>
        /// �ջ���ַ���У��Ϊ��ȷ
        /// </summary>
        public bool AllowNull
        {
            get { return _allowNull; }
            set { _allowNull = value; }
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
        /// <param name="value"></param>
        /// <returns></returns>
        public bool vaildated(Object value)
        {
            if (value == null || String.IsNullOrEmpty(value.ToString()))
            {
                if (AllowNull)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return this.validate(value);
        }
        /// <summary>
        /// У��, value����Ϊ�ջ���ַ���
        /// </summary>
        /// <returns></returns>
        protected abstract bool validate(Object value);

        public virtual void addValidateEvent(Control control) { }
    }
}

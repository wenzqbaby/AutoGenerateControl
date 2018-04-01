using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AGC.interfaces;

namespace AGC.validate
{
    /// <summary>
    /// 校验基类
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class ValidateBase : Attribute
    {
        public ValidateBase() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        public ValidateBase(String failMsg)
        {
            this.FailMsg = failMsg;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        /// <param name="addValidateEvent">是否添加校验事件到控件上</param>
        public ValidateBase(String failMsg, bool addValidateEvent)
            : this(failMsg)
        {
            this.AddEvent = addValidateEvent;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        /// <param name="addValidateEvent">是否添加校验事件到控件上</param>
        /// <param name="allowNull">是否允许空值或空字符串</param>
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
        /// 空或空字符串校验为正确
        /// </summary>
        public bool AllowNull
        {
            get { return _allowNull; }
            set { _allowNull = value; }
        }

        private bool _addEvent = false;
        /// <summary>
        /// 与AgcBase特征一起才有用，若该属性为true，并且MIValidate不为空，将会添加校验事件到MIValidate获取到的控件中
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
        /// 校验失败的提示信息
        /// </summary>
        public String FailMsg
        {
            get { return _failMsg; }
            set { _failMsg = value; }
        }

        /// <summary>
        /// 校验
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
        /// 校验, value不会为空或空字符串
        /// </summary>
        /// <returns></returns>
        protected abstract bool validate(Object value);

        public virtual void addValidateEvent(Control control) { }
    }
}

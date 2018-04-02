using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.validate
{
    /// <summary>
    /// 校验是否输入为数字
    /// </summary>
    public class ValidateNumber : ValidateBase
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        public ValidateNumber(String failMsg) : base(failMsg) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        /// <param name="addValidateEvent">是否添加校验事件到控件上</param>
        public ValidateNumber(String failMsg, bool addValidateEvent) : base(failMsg, addValidateEvent) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        /// <param name="addValidateEvent">是否添加校验事件到控件上</param>
        /// <param name="allowNull">是否允许空值或空字符串</param>
        public ValidateNumber(String failMsg, bool addValidateEvent, bool allowNull) : base(failMsg, addValidateEvent, allowNull) { }

        public override void addValidateEvent(Control control)
        {
            control.KeyPress += new KeyPressEventHandler(keyPressNumber);
        }

        /// <summary>
        /// KeyPress事件，只允许输入数字
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void keyPressNumber(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13)
            {
                e.Handled = true;
            }
        }

        protected override bool validate(object value)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(value.ToString(), @"^\d+$"))
            {
                return true;
            }
            return false;
        }
    }
}

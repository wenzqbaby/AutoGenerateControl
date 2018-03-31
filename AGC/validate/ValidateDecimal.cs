using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.validate
{
    /// <summary>
    /// 校验浮点型数字
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    public class ValidateDecimal: ValidateBase
    {
        private Decimal min;
        private Decimal max;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
        public ValidateDecimal(String failMsg) : base(failMsg) { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值(含)</param>
        /// <param name="max">最大值(不含)</param>
        /// <param name="failMsg">校验失败的信息</param>
        public ValidateDecimal(int min, int max, String failMsg)
            : base(failMsg)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="min">最小值(含)</param>
        /// <param name="max">最大值(不含)</param>
        /// <param name="failMsg">校验失败的信息</param>
        /// <param name="addEvent">是否添加校验事件到控件上</param>
        public ValidateDecimal(int min, int max, String failMsg, bool addEvent)
            : base(failMsg, addEvent)
        {
            this.min = min;
            this.max = max;
        }

        public override bool validate(object value)
        {
            if (value == null)
            {
                return false;
            }

            try
            {
                Decimal d = Convert.ToDecimal(value);
                if (min == 0 && max == 0)
                {
                    return true;
                }
                else if (d >= min && d < max)
                {
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            return false;
        }

        public override void addValidateEvent(Control control)
        {
            control.KeyPress += new KeyPressEventHandler(keyPressDecimal);
        }

        /// <summary>
        /// KeyPress事件，只允许输入数字和小数点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void keyPressDecimal(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 13 && e.KeyChar != 46)
            {
                e.Handled = true;
            }
            if (e.KeyChar == 46 && (((Control)sender).Text.IndexOf(".") >= 0 || ((Control)sender).Text == ""))
            {
                e.Handled = true;
            }
        }
    }
}

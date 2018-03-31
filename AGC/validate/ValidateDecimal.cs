using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.validate
{
    /// <summary>
    /// У�鸡��������
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    public class ValidateDecimal: ValidateBase
    {
        private Decimal min;
        private Decimal max;

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        public ValidateDecimal(String failMsg) : base(failMsg) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="min">��Сֵ(��)</param>
        /// <param name="max">���ֵ(����)</param>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        public ValidateDecimal(int min, int max, String failMsg)
            : base(failMsg)
        {
            this.min = min;
            this.max = max;
        }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="min">��Сֵ(��)</param>
        /// <param name="max">���ֵ(����)</param>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        /// <param name="addEvent">�Ƿ����У���¼����ؼ���</param>
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
        /// KeyPress�¼���ֻ�����������ֺ�С����
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.validate
{
    /// <summary>
    /// У���Ƿ�����Ϊ����
    /// </summary>
    public class ValidateNumber : ValidateBase
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        public ValidateNumber(String failMsg) : base(failMsg) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        /// <param name="addValidateEvent">�Ƿ����У���¼����ؼ���</param>
        public ValidateNumber(String failMsg, bool addValidateEvent) : base(failMsg, addValidateEvent) { }

        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        /// <param name="addValidateEvent">�Ƿ����У���¼����ؼ���</param>
        /// <param name="allowNull">�Ƿ������ֵ����ַ���</param>
        public ValidateNumber(String failMsg, bool addValidateEvent, bool allowNull) : base(failMsg, addValidateEvent, allowNull) { }

        public override void addValidateEvent(Control control)
        {
            control.KeyPress += new KeyPressEventHandler(keyPressNumber);
        }

        /// <summary>
        /// KeyPress�¼���ֻ������������
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

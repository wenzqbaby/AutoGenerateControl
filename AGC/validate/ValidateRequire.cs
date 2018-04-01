using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.validate
{
    /// <summary>
    /// �ǿ�У�飬��Ϊ�ջ���ַ����򷵻�false
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    public class ValidateRequire: ValidateBase
    {
        /// <summary>
        /// ���췽��
        /// </summary>
        /// <param name="failMsg">У��ʧ�ܵ���Ϣ</param>
        public ValidateRequire(String failMsg) : base(failMsg) 
        {
            this.AllowNull = false;
        }

        protected override bool validate(object value)
        {
            return true;
        }
    }
}

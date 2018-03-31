using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.validate
{
    /// <summary>
    /// ·Ç¿ÕÐ£Ñé
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    public class ValidateRequire: ValidateBase
    {
        public ValidateRequire(String failMsg) : base(failMsg) { }

        public override bool validate(object value)
        {
            if (value == null || String.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            return true;
        }
    }
}

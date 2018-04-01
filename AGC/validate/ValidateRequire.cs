using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.validate
{
    /// <summary>
    /// 非空校验，若为空或空字符串则返回false
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    public class ValidateRequire: ValidateBase
    {
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="failMsg">校验失败的信息</param>
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

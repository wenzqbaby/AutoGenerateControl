using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.entity
{
    /// <summary>
    /// 校验实体
    /// @author wenzq
    /// @date   2018.3.28
    /// </summary>
    public class Validatetion
    {
        private bool _isValide = true;
        /// <summary>
        /// 是否校验成功，true为成功
        /// </summary>
        public bool IsValide
        {
            get { return _isValide; }
            set { _isValide = value; }
        }

        private List<String> failMsgs = new List<string>();
        /// <summary>
        /// 校验失败后的失败提示信息
        /// </summary>
        public List<String> FailMsgs
        {
            get { return failMsgs; }
            set { failMsgs = value; }
        }

        public override string ToString()
        {
            String str = String.Empty;
            foreach (String msg in failMsgs)
            {
                str += msg + "\n";
            }
            return str;
        }
    }
}

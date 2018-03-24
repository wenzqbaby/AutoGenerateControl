using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.utils
{
    public class GUIDUtil
    {
        /// <summary>
        /// 获取32位随机ID
        /// </summary>
        /// <returns></returns>
        public static String getID()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.utils
{
    public class GUIDUtil
    {
        /// <summary>
        /// ��ȡ32λ���ID
        /// </summary>
        /// <returns></returns>
        public static String getID()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}

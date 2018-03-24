using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.interfaces
{
    public interface IAgc
    {
        /// <summary>
        /// 返回要添加的控件集合
        /// </summary>
        /// <returns></returns>
        List<AgcControl> generate();
    }
}

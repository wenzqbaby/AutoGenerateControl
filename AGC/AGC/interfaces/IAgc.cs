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
        /// ����Ҫ��ӵĿؼ�����
        /// </summary>
        /// <returns></returns>
        List<AgcControl> generate();
    }
}

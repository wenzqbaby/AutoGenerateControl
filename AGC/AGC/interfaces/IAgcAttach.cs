using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;

namespace AGC.interfaces
{
    /// <summary>
    /// AgcBaseʵ�ָýӿڲ��������ӿؼ�
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public interface IAgcAttach
    {
        /// <summary>
        /// ��ȡ���ӵĿؼ�����
        /// </summary>
        /// <returns></returns>
        List<AgcBase> getAttachList();

        /// <summary>
        /// ���ӿؼ�
        /// </summary>
        /// <param name="agcBase"></param>
        void attach(AgcBase agcBase);

    }
}

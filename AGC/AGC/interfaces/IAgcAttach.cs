using System;
using System.Collections.Generic;
using System.Text;
using AGC.attributes;

namespace AGC.interfaces
{
    /// <summary>
    /// AgcBase实现该接口才能允许附加控件
    /// @author wenzq
    /// @date   2018.3.25
    /// </summary>
    public interface IAgcAttach
    {
        /// <summary>
        /// 获取附加的控件集合
        /// </summary>
        /// <returns></returns>
        List<AgcBase> getAttachList();

        /// <summary>
        /// 附加控件
        /// </summary>
        /// <param name="agcBase"></param>
        void attach(AgcBase agcBase);

    }
}

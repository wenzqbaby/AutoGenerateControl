using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.interfaces
{
    /// <summary>
    /// 校验接口
    /// @author wenzq
    /// @date   2018.3.28
    /// </summary>
    public interface IValidate
    {
        /// <summary>
        /// 获取需要校验的控件，用于设置校验事件
        /// </summary>
        /// <returns></returns>
        Control getValidateControl();

        /// <summary>
        /// 校验成功触发事件
        /// </summary>
        void validateSuccess();

        /// <summary>
        /// 校验失败触发事件
        /// </summary>
        void validateFail(String failMsg);
    }
}

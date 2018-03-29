using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.interfaces
{
    /// <summary>
    /// У��ӿ�
    /// @author wenzq
    /// @date   2018.3.28
    /// </summary>
    public interface IValidate
    {
        /// <summary>
        /// ��ȡ��ҪУ��Ŀؼ�����������У���¼�
        /// </summary>
        /// <returns></returns>
        Control getValidateControl();

        /// <summary>
        /// У��ɹ������¼�
        /// </summary>
        void validateSuccess();

        /// <summary>
        /// У��ʧ�ܴ����¼�
        /// </summary>
        void validateFail(String failMsg);
    }
}

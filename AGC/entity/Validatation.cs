using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.entity
{
    /// <summary>
    /// У��ʵ��
    /// @author wenzq
    /// @date   2018.3.28
    /// </summary>
    public class Validatation
    {
        private bool _isValide = true;
        /// <summary>
        /// �Ƿ�У��ɹ���trueΪ�ɹ�
        /// </summary>
        public bool IsValide
        {
            get { return _isValide; }
            set { _isValide = value; }
        }

        private List<String> failMsgs = new List<string>();
        /// <summary>
        /// У��ʧ�ܺ��ʧ����ʾ��Ϣ
        /// </summary>
        public List<String> FailMsgs
        {
            get { return failMsgs; }
            set { failMsgs = value; }
        }
    }
}

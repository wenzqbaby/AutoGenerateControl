using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.entity
{
    /// <summary>
    /// Agc�Ŀؼ�ʵ��
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcControl
    {
        private bool _autoWidth;
        /// <summary>
        /// �Զ���ȣ���������ÿ�еĿؼ������¸��ؼ�����ʱ����Ч
        /// </summary>
        public bool AutoWidth
        {
            get { return _autoWidth; }
            set { _autoWidth = value; }
        }

        private Control _mControl;
        /// <summary>
        /// Ҫ�����Ŀؼ�
        /// </summary>
        public Control MControl
        {
            get { return _mControl; }
            set { _mControl = value; }
        }

        private int _index;
        /// <summary>
        /// �����ؼ���˳��
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        private int _marginTop;
        /// <summary>
        /// �ϱ߾�
        /// </summary>
        public int MarginTop
        {
            get { return _marginTop; }
            set { _marginTop = value; }
        }
        private int _marginButtom;
        /// <summary>
        /// �±߾�
        /// </summary>
        public int MarginButtom
        {
            get { return _marginButtom; }
            set { _marginButtom = value; }
        }
        private int _marginLeft;
        /// <summary>
        /// ��߾�
        /// </summary>
        public int MarginLeft
        {
            get { return _marginLeft; }
            set { _marginLeft = value; }
        }
        private int _marginRight;
        /// <summary>
        /// �ұ߾�
        /// </summary>
        public int MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }

    }
}

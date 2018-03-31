using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace AGC.entity
{
    /// <summary>
    /// Agc的控件实体
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcControl
    {
        private bool _autoWidth;
        /// <summary>
        /// 自动宽度，若设置了每行的控件数或下个控件换行时才有效
        /// </summary>
        public bool AutoWidth
        {
            get { return _autoWidth; }
            set { _autoWidth = value; }
        }

        private Control _mControl;
        /// <summary>
        /// 要创建的控件
        /// </summary>
        public Control MControl
        {
            get { return _mControl; }
            set { _mControl = value; }
        }

        private int _index;
        /// <summary>
        /// 创建控件的顺序
        /// </summary>
        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        private int _marginTop;
        /// <summary>
        /// 上边距
        /// </summary>
        public int MarginTop
        {
            get { return _marginTop; }
            set { _marginTop = value; }
        }
        private int _marginButtom;
        /// <summary>
        /// 下边距
        /// </summary>
        public int MarginButtom
        {
            get { return _marginButtom; }
            set { _marginButtom = value; }
        }
        private int _marginLeft;
        /// <summary>
        /// 左边距
        /// </summary>
        public int MarginLeft
        {
            get { return _marginLeft; }
            set { _marginLeft = value; }
        }
        private int _marginRight;
        /// <summary>
        /// 右边距
        /// </summary>
        public int MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }

    }
}

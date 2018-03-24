using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.attributes
{
    /// <summary>
    /// �������ã�ֻ�ܼ�������
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcSetting: Attribute
    {
        public AgcSetting() { }
        public AgcSetting(bool resetHeight)
        {
            this.ResetHeight = resetHeight;
        }

        public AgcSetting(int columns)
        {
            this.Column = columns;
        }

        public AgcSetting(int columns, bool resetHeight)
        {
            this.Column = columns;
            this.ResetHeight = resetHeight;
        }

        public AgcSetting(int top, int buttom, int left, int right)
        {
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
        }

        public AgcSetting(int columns, bool resetHeight, int top, int buttom, int left, int right)
        {
            this.Column = columns;
            this.ResetHeight = resetHeight;
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
        }

        private int _marginTop = 10;
        /// <summary>
        /// �ϱ߾�
        /// </summary>
        public int MarginTop
        {
            get { return _marginTop; }
            set { _marginTop = value; }
        }
        private int _marginButtom = 10;
        /// <summary>
        /// �±߾�
        /// </summary>
        public int MarginButtom
        {
            get { return _marginButtom; }
            set { _marginButtom = value; }
        }
        private int _marginLeft = 10;
        /// <summary>
        /// ��߾�
        /// </summary>
        public int MarginLeft
        {
            get { return _marginLeft; }
            set { _marginLeft = value; }
        }
        private int _marginRight = 10;
        /// <summary>
        /// �ұ߾�
        /// </summary>
        public int MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }
        private int _column = 0;
        /// <summary>
        /// ÿ�пؼ������
        /// </summary>
        public int Column
        {
            get { return _column; }
            set { _column = value; }
        }

        private int _spacingX = 8;
        /// <summary>
        /// �м��
        /// </summary>
        public int SpacingX
        {
            get { return _spacingX; }
            set { _spacingX = value; }
        }

        private int _spacingY = 8;
        /// <summary>
        /// �м��
        /// </summary>
        public int SpacingY
        {
            get { return _spacingY; }
            set { _spacingY = value; }
        }

        private bool _resetHeight = false;
        /// <summary>
        /// �Ƿ����������߶�
        /// </summary>
        public bool ResetHeight
        {
            get { return _resetHeight; }
            set { _resetHeight = value; }
        }
    }
}

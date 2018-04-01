using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.attributes
{
    /// <summary>
    /// 生成配置，只能加在类上
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = true)]
    public class AgcSetting: Attribute
    {
        public AgcSetting() { }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="resetHeight">生成控件后，是否重设容器高度</param>
        public AgcSetting(bool resetHeight)
        {
            this.ResetHeight = resetHeight;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="spaceX">列间距</param>
        /// <param name="spaceY">行间距</param>
        public AgcSetting(int spaceX, int spaceY)
        {
            this.SpacingX = spaceX;
            this.SpacingY = spaceY;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="top">上边距</param>
        /// <param name="buttom">下边距</param>
        /// <param name="left">左边距</param>
        /// <param name="right">右边距</param>
        public AgcSetting(int top, int buttom, int left, int right)
        {
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="top">上边距</param>
        /// <param name="buttom">下边距</param>
        /// <param name="left">左边距</param>
        /// <param name="right">右边距</param>
        /// <param name="spaceX">列间距</param>
        /// <param name="spaceY">行间距</param>
        public AgcSetting(int top, int buttom, int left, int right, int spaceX, int spaceY)
        {
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
            this.SpacingX = spaceX;
            this.SpacingY = spaceY;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="resetHeight">生成控件后，是否重设容器高度</param>
        /// <param name="top">上边距</param>
        /// <param name="buttom">下边距</param>
        /// <param name="left">左边距</param>
        /// <param name="right">右边距</param>
        public AgcSetting(bool resetHeight, int top, int buttom, int left, int right)
        {
            this.ResetHeight = resetHeight;
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="resetHeight">生成控件后，是否重设容器高度</param>
        /// <param name="top">上边距</param>
        /// <param name="buttom">下边距</param>
        /// <param name="left">左边距</param>
        /// <param name="right">右边距</param>
        /// <param name="spaceX">列间距</param>
        /// <param name="spaceY">行间距</param>
        public AgcSetting(bool resetHeight, int top, int buttom, int left, int right, int spaceX, int spaceY)
        {
            this.ResetHeight = resetHeight;
            this.MarginTop = top;
            this.MarginButtom = buttom;
            this.MarginLeft = left;
            this.MarginRight = right;
            this.SpacingX = spaceX;
            this.SpacingY = spaceY;
        }

        private int _marginTop = 10;
        /// <summary>
        /// 上边距
        /// </summary>
        public int MarginTop
        {
            get { return _marginTop; }
            set { _marginTop = value; }
        }
        private int _marginButtom = 10;
        /// <summary>
        /// 下边距
        /// </summary>
        public int MarginButtom
        {
            get { return _marginButtom; }
            set { _marginButtom = value; }
        }
        private int _marginLeft = 10;
        /// <summary>
        /// 左边距
        /// </summary>
        public int MarginLeft
        {
            get { return _marginLeft; }
            set { _marginLeft = value; }
        }
        private int _marginRight = 10;
        /// <summary>
        /// 右边距
        /// </summary>
        public int MarginRight
        {
            get { return _marginRight; }
            set { _marginRight = value; }
        }

        private int _spacingX = 8;
        /// <summary>
        /// 列间距
        /// </summary>
        public int SpacingX
        {
            get { return _spacingX; }
            set { _spacingX = value; }
        }

        private int _spacingY = 8;
        /// <summary>
        /// 行间距
        /// </summary>
        public int SpacingY
        {
            get { return _spacingY; }
            set { _spacingY = value; }
        }

        private bool _resetHeight = false;
        /// <summary>
        /// 是否重设容器高度
        /// </summary>
        public bool ResetHeight
        {
            get { return _resetHeight; }
            set { _resetHeight = value; }
        }
    }
}

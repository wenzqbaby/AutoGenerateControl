using System;
using System.Collections.Generic;
using System.Text;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.attributes
{
    /// <summary>
    /// Agc的基类
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, Inherited = true)]
    public abstract class AgcBase : Attribute
    {
        /// <summary>
        /// 当前类名
        /// </summary>
        protected String mTAG;
        /// <summary>
        /// 若该属性为true，则生成的控件会添加到其他容器上
        /// </summary>
        public bool isAttach = false;

        /// <summary>
        /// isAttach为true才生效，要附加的属性名，该属性对应的控件必须为AGC.interfaces.IAgcAttach
        /// </summary>
        public String attachProp;

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        public AgcBase(int index)
        {
            this.Index = index;
            mTAG = this.GetType().Name;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="title">显示标题</param>
        public AgcBase(int index, String title)
            : this(index)
        {
            this.Title = title;
        }

        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="index">排序</param>
        /// <param name="titel">显示标题</param>
        /// <param name="newRow">是否在新的一行生成</param>
        public AgcBase(int index, String titel, bool newRow)
            : this(index, titel)
        {
            this.NewRow = newRow;
        }

        #region 生命周期
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void init() { }
        /// <summary>
        /// 设置控件前执行
        /// </summary>
        protected virtual void beforeSetControl() { }
        /// <summary>
        /// 设置控件
        /// </summary>
        protected abstract void setControl();
        /// <summary>
        /// 设置控件后执行
        /// </summary>
        protected virtual void afterSetControl() { }

        /// <summary>
        /// 在容器中添加生成控件
        /// </summary>
        /// <returns></returns>
        public List<AgcControl> generate()
        {
            this.beforeSetControl();
            this.setControl();
            this.afterSetControl();
            MAgcCtlList.Sort(delegate(AgcControl ac1, AgcControl ac2) { return ac1.Index.CompareTo(ac2.Index); });
            calcWidthAndHeight();
            this.afterGenerate();
            return MAgcCtlList;
        }

        /// <summary>
        /// 生成控件后执行
        /// </summary>
        protected virtual void afterGenerate() { }

        /// <summary>
        /// 添加控件到容器后执行，返回true则重新计算该控件的长和宽
        /// </summary>
        /// <returns></returns>
        public virtual bool afterAdd() { return false; }

        /// <summary>
        /// 控件生成结束
        /// </summary>
        public void theEnd() 
        {
            if (this.afterAdd())
            {
                calcWidthAndHeight();
            }
        }

        #endregion

        private void calcWidthAndHeight()
        {
            this.TotalWidth = 0;
            this.TotalHeight = 0;

            foreach (AgcControl aCtl in MAgcCtlList)
            {
                this.TotalWidth += (aCtl.MarginLeft + aCtl.MControl.Width + aCtl.MarginRight);
                int h = aCtl.MarginTop + aCtl.MControl.Height + aCtl.MarginButtom;
                this.TotalHeight = this.TotalHeight > h ? this.TotalHeight : h;
            }
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <returns></returns>
        public abstract Object getValue();

        /// <summary>
        /// 设置值到控件中
        /// </summary>
        /// <param name="obj"></param>
        public void set(Object obj)
        {
            if (obj == null)
            {
                return;
            }
            this.setValue(obj);
        }

        /// <summary>
        /// 设置值
        /// </summary>
        /// <param name="obj"></param>
        protected abstract void setValue(Object obj);

        /// <summary>
        /// 控件是否可用，需重写实现
        /// </summary>
        /// <param name="enable">是则可用</param>
        public virtual void Enable(bool enable) {}

        private List<AgcControl> _mAgcCtlList = new List<AgcControl>();
        /// <summary>
        /// 控件集合
        /// </summary>
        public List<AgcControl> MAgcCtlList
        {
            get { return _mAgcCtlList; }
            set { _mAgcCtlList = value; }
        }

        private int _totalWidth;
        /// <summary>
        /// 总宽度
        /// </summary>
        public int TotalWidth
        {
            get { return _totalWidth; }
            set { _totalWidth = value; }
        }

        private int _totalHeight;
        /// <summary>
        /// 总高度
        /// </summary>
        public int TotalHeight
        {
            get { return _totalHeight; }
            set { _totalHeight = value; }
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

        private bool _newRow;
        /// <summary>
        /// 是否在新的一行创建
        /// </summary>
        public bool NewRow
        {
            get { return _newRow; }
            set { _newRow = value; }
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

        private int _afterX = 8;
        /// <summary>
        /// 距离上一个AGC控件的X轴距离
        /// </summary>
        public int AfterX
        {
            get { return _afterX; }
            set { _afterX = value; }
        }

        private int _afterY;
        /// <summary>
        /// 距离上一个AGC控件的Y轴距离
        /// </summary>
        public int AfterY
        {
            get { return _afterY; }
            set { _afterY = value; }
        }

        private String _title;
        /// <summary>
        /// 对应对象的属性名称
        /// </summary>
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _objProp;
        /// <summary>
        /// 对应对象的属性
        /// </summary>
        public String ObjProp
        {
            get { return _objProp; }
            set { _objProp = value; }
        }

        private Object _tag;
        /// <summary>
        /// 标记属性
        /// </summary>
        public Object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        /// <summary>
        /// 自动生成控件名称
        /// </summary>
        /// <returns></returns>
        protected String generateName()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}

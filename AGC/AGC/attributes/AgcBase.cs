using System;
using System.Collections.Generic;
using System.Text;
using AGC.interfaces;
using System.Windows.Forms;
using AGC.entity;

namespace AGC.attributes
{
    /// <summary>
    /// �����Ļ��ࣺ������init�����г�ʼ��mIAgc�ӿ�
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public abstract class AgcBase : Attribute
    {
        protected String mTAG;
        /// <summary>
        /// ��������Ϊtrue�������ɵĿؼ�����ӵ�����������
        /// </summary>
        public bool isAttach = false;

        /// <summary>
        /// isAttachΪtrue����Ч��Ҫ���ӵ��������������Զ�Ӧ�Ŀؼ�����ΪAGC.interfaces.IAgcAttach
        /// </summary>
        public String attachProp;

        public AgcBase(int index)
        {
            this.Index = index;
            mTAG = this.GetType().Name;
        }

        #region ��������
        /// <summary>
        /// ��ʼ��
        /// </summary>
        public virtual void init() { }
        protected virtual void beforeSetControl() { }
        protected abstract void setControl();
        protected virtual void afterSetControl() { }

        public virtual void beforeGenerate() { }

        public List<AgcControl> generate()
        {
            this.beforeSetControl();
            this.setControl();
            this.afterSetControl();
            MAgcCtlList.Sort(delegate(AgcControl ac1, AgcControl ac2) { return ac1.Index.CompareTo(ac2.Index); });
            calcWidthAndHeight();
            return MAgcCtlList;
        }

        public virtual void afterGenerate() { }
        public virtual bool afterAdd() { return false; }

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
        /// ��ȡֵ
        /// </summary>
        /// <returns></returns>
        public abstract Object getValue();

        /// <summary>
        /// ����ֵ
        /// </summary>
        /// <param name="obj"></param>
        public abstract void setValue(Object obj);

        public virtual void Enable(bool enable) {}

        private List<AgcControl> _mAgcCtlList = new List<AgcControl>();
        /// <summary>
        /// �ؼ�����
        /// </summary>
        public List<AgcControl> MAgcCtlList
        {
            get { return _mAgcCtlList; }
            set { _mAgcCtlList = value; }
        }

        private int _totalWidth;
        /// <summary>
        /// �ܿ��
        /// </summary>
        public int TotalWidth
        {
            get { return _totalWidth; }
            set { _totalWidth = value; }
        }

        private int _totalHeight;
        /// <summary>
        /// �ܸ߶�
        /// </summary>
        public int TotalHeight
        {
            get { return _totalHeight; }
            set { _totalHeight = value; }
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

        private bool _newRow;
        /// <summary>
        /// �Ƿ����µ�һ�д���
        /// </summary>
        public bool NewRow
        {
            get { return _newRow; }
            set { _newRow = value; }
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

        private int _afterX = 8;
        /// <summary>
        /// ������һ��AGC�ؼ���X�����
        /// </summary>
        public int AfterX
        {
            get { return _afterX; }
            set { _afterX = value; }
        }

        private int _afterY;
        /// <summary>
        /// ������һ��AGC�ؼ���Y�����
        /// </summary>
        public int AfterY
        {
            get { return _afterY; }
            set { _afterY = value; }
        }

        private String _title;
        /// <summary>
        /// ��Ӧ�������������
        /// </summary>
        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private String _objProp;
        /// <summary>
        /// ��Ӧ���������
        /// </summary>
        public String ObjProp
        {
            get { return _objProp; }
            set { _objProp = value; }
        }

        private Object _tag;
        /// <summary>
        /// �������
        /// </summary>
        public Object Tag
        {
            get { return _tag; }
            set { _tag = value; }
        }

        protected String generateName()
        {
            return Guid.NewGuid().ToString("N").ToUpper();
        }
    }
}

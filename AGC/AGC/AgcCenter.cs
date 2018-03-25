using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using AGC.attributes;
using System.Windows.Forms;
using AGC.interfaces;

namespace AGC
{
    /// <summary>
    /// AGC����
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcCenter<T>
    {
        private String TAG = String.Empty;
        /// <summary>
        /// ��������Ӧ�ؼ��ֵ伯��
        /// </summary>
        private Dictionary<String, AgcBase> propDic = new Dictionary<String, AgcBase>();
        /// <summary>
        /// AGC�ؼ�����
        /// </summary>
        private List<AgcBase> baseList = new List<AgcBase>();
        /// <summary>
        /// ���ɿؼ�������
        /// </summary>
        private Control mContainer;
        private AgcGanerator mGanerator;
        private Type mType;

        public AgcCenter(Control container)
        {
            mType = typeof(T);
            TAG = mType.Name;
            PropertyInfo[] mPropertyInfo = typeof(T).GetProperties();
            List<AgcBase> attachList = new List<AgcBase>();
            foreach (PropertyInfo pi in mPropertyInfo)
            {
                try
                {
                    Attribute attr = Attribute.GetCustomAttribute(pi, typeof(AgcBase));
                    if (attr != null)
                    {
                        AgcBase ab = (attr as AgcBase);
                        if (ab.isAttach)
                        {
                            attachList.Add(ab);
                        }
                        else 
                        {
                            baseList.Add(ab);
                        }
                        propDic.Add(pi.Name, ab);
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception("AGC��ȡ�ؼ����ó���" + ex.Message);
                }
            }

            if (attachList.Count > 0)
            {
                foreach (AgcBase var in attachList)
                {
                    try
                    {
                        (getControl(var.attachProp) as IAgcAttach).attach(var);
                    }
                    catch (Exception e)
                    {
                        throw new Exception( String.Format("{0}: {1} ���ӵ���������Ӧ�Ŀؼ�δʵ�ֽӿ�AGC.interfaces.IAgcAttach" + e.Message,TAG, var.Title));
                    }
                }
            }

            mContainer = container;
            mGanerator = new AgcGanerator(mContainer);
        }

        public AgcCenter(Control container, AgcSetting agcSetting, List<AgcBase> slots)
        {
            mContainer = container;
            foreach (AgcBase ab in slots)
            {
                propDic.Add(ab.Tag.ToString(), ab);
            }
            baseList.AddRange(slots);
            mGanerator = new AgcGanerator(mContainer, agcSetting);
            this.generate();
        }

        public T getValue()
        {
            T t = Activator.CreateInstance<T>();
            foreach (KeyValuePair<String, AgcBase> kv in propDic)
            {
                this.setObj(t, kv.Key, kv.Value.getValue());
            }
            return t;
        }

        public void setValue(T t)
        {
            foreach (KeyValuePair<String, AgcBase> kv in propDic)
            {
                Object v = this.getObj(t, kv.Key);
                kv.Value.setValue(v);
            }
        }

        /// <summary>
        /// ���ɿؼ�
        /// </summary>
        public void generate()
        {
            mGanerator.generate(baseList);
        }

        /// <summary>
        /// ������������ȡ�ؼ�
        /// </summary>
        /// <param name="objProp">������</param>
        /// <returns></returns>
        public AgcBase getControl(String objProp)
        {
            try
            {
                return propDic[objProp];
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// ���ɿؼ���������Զ���ؼ�
        /// </summary>
        /// <param name="slots">�Զ���ؼ�</param>
        public void generate(List<AgcBase> slots)
        {
            baseList.AddRange(slots);
            this.generate();
        }

        private void setObj(T t, String propertyName, Object value)
        {
            try
            {
                mType.GetProperty(propertyName).SetValue(t, value, null);
            }
            catch (Exception e)
            {
                throw new Exception(TAG + " ��������ʧ�ܣ�" + propertyName + " " + e.Message);
            }
        }

        private Object getObj(T t, String propertyName)
        {
            try
            {
                return mType.GetProperty(propertyName).GetValue(t, null);
            }
            catch (Exception e)
            {
                throw new Exception(TAG + " ��ȡ����ʧ�ܣ�" + propertyName + " " + e.Message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using AGC.attributes;
using System.Windows.Forms;
using AGC.interfaces;
using AGC.entity;

namespace AGC
{
    /// <summary>
    /// AGC核心, T的属性须为字符串
    /// @author wenzq
    /// @date   2018.3.23
    /// </summary>
    public class AgcCenter<T>
    {
        private String TAG = String.Empty;
        /// <summary>
        /// 属性名对应控件字典集合
        /// </summary>
        private Dictionary<String, AgcBase> propDic = new Dictionary<String, AgcBase>();
        /// <summary>
        /// AGC控件集合
        /// </summary>
        private List<AgcBase> baseList = new List<AgcBase>();
        /// <summary>
        /// 生成控件的容器
        /// </summary>
        private Control mContainer;
        private AgcGanerator mGanerator;
        private Type mType;

        private Validator<T> mValidator;

        public AgcCenter(Control container)
        {
            this.init(container);
        }

        public AgcCenter(Control container, bool allowValidate)
        {
            this.init(container);
            if (allowValidate)
            {
                mValidator = new Validator<T>();
                mValidator.init(this.propDic);
            }
        }

        private void init(Control container)
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
                    throw new Exception(String.Format("{0} 获取控件配置出错：", mType) + ex.Message);
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
                        throw new Exception(String.Format("{0}: {1} 附加的属性名对应的控件未实现接口AGC.interfaces.IAgcAttach" + e.Message, TAG, var.Title));
                    }
                }
            }

            mContainer = container;
            mGanerator = new AgcGanerator(mContainer);
            this.generate();
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

        public T getValueBySetNull()
        {
            T t = Activator.CreateInstance<T>();
            foreach (KeyValuePair<String, AgcBase> kv in propDic)
            {
                Object value = kv.Value.getValue();
                if (value == null || String.IsNullOrEmpty(value.ToString()))
                {
                    value = "NULL";
                }
                this.setObj(t, kv.Key, value);
            }
            return t;
        }

        public void setValue(T t)
        {
            foreach (KeyValuePair<String, AgcBase> kv in propDic)
            {
                Object v = this.getObj(t, kv.Key);
                kv.Value.set(v);
            }
        }

        public Validatation validate()
        {
            if (mValidator == null)
            {
                throw new Exception(String.Format("{} 未开启校验", TAG));
            }

            return mValidator.validate(this.getValue());
        }

        /// <summary>
        /// 生成控件
        /// </summary>
        public void generate()
        {
            mGanerator.generate(baseList);
        }

        /// <summary>
        /// 根据属性名获取控件
        /// </summary>
        /// <param name="objProp">属性名</param>
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
        /// 生成控件，可添加自定义控件
        /// </summary>
        /// <param name="slots">自定义控件</param>
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
                throw new Exception(TAG + " 设置属性失败：" + propertyName + " " + e.Message);
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
                throw new Exception(TAG + " 获取属性失败：" + propertyName + " " + e.Message);
            }
        }
    }
}

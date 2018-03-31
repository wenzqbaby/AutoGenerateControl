using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using AGC.validate;
using AGC.entity;
using AGC.interfaces;
using AGC.attributes;

namespace AGC
{
    /// <summary>
    /// 校验器，T的属性须为字符串
    /// @author wenzq
    /// @date   2018.3.27
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Validator<T>
    {
        private String TAG;
        private Type mType;
        private Dictionary<String, ValidateBase> mPropDic = new Dictionary<String, ValidateBase>();
        private List<String> addEventList = new List<string>();
        private bool isInit;

        public Validator()
        {
            mType = typeof(T);
            TAG = mType.Name;
            PropertyInfo[] mPropertyInfo = typeof(T).GetProperties();
            foreach (PropertyInfo pi in mPropertyInfo)
            {
                try
                {
                    Attribute attr = Attribute.GetCustomAttribute(pi, typeof(ValidateBase));
                    if (attr != null)
                    {
                        ValidateBase vb = (attr as ValidateBase);
                        mPropDic.Add(pi.Name, vb);
                        if (vb.AddEvent)
                        {
                            addEventList.Add(pi.Name);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    throw new Exception(String.Format("{0} 获取控件配置出错：", mType) + ex.Message);
                }
            }
        }

        public void init(Dictionary<String, AgcBase> dic)
        {
            if (isInit)
            {
                return;
            }
            isInit = true;

            if (addEventList.Count < 1 || dic == null || dic.Count < 1)
            {
                return;
            }

            foreach (String prop in addEventList)
            {
                try
                {
                    mPropDic[prop].addValidateEvent((dic[prop] as IValidate).getValidateControl());
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("{0} 的 {1} 属性添加事件失败", TAG, prop) + ex.Message);
                }
            }
        }

        public Validatation validate(T t)
        {
            Validatation v = new Validatation();
            foreach (KeyValuePair<String,ValidateBase> item in mPropDic)
            {
                if (!item.Value.validate(getObj(t,item.Key)))
                {
                    if (v.IsValide)
                    {
                        v.IsValide = false;
                    }
                    v.FailMsgs.Add(item.Value.FailMsg);
                }
            }
            return v;
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

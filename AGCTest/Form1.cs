using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AGC;
using AGC.attributes;
using AGC.api;
using AGC.entity;

namespace AGCTest
{
    public partial class Form1 : Form
    {
        private AgcCenter<User> mAgcCenter;

        public Form1()
        {
            InitializeComponent();
            List<AgcBase> list = new List<AgcBase>();
            list.Add(new AgcLabel(85, "工作时间：", 0, true));
            list.Add(new AgcButton(100, "取值", new EventHandler(getValue), true));
            list.Add(new AgcButton(110, "取值空值设为NULL", new EventHandler(getValueByNull), false));
            list.Add(new AgcButton(120, "赋值", new EventHandler(setValue), false));
            list.Add(new AgcButton(130, "校验", new EventHandler(validate), false));
            //mAgcCenter = new AgcCenter<User>(this.panel1);
            mAgcCenter = new AgcCenter<User>(this.panel1, list, true);
            mAgcCenter.getControl("Start").set(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            mAgcCenter.getControl("End").set(DateTime.Now.AddDays(7).ToString("yyyy-MM-dd") + " 23:59:59");
        }

        void getValue(object sender, EventArgs e)
        {
            MessageBox.Show(mAgcCenter.getValue().ToString());
        }

        void getValueByNull(object sender, EventArgs e)
        {
            MessageBox.Show(mAgcCenter.getValueBySetNull().ToString());
        }

        void validate(object sender, EventArgs e)
        {
            Validatetion v = mAgcCenter.validate();
            if (v.IsValide)
            {
                MessageBox.Show("校验成功");
            }
            else
            {
                MessageBox.Show(mAgcCenter.validate().ToString());
            }
        }

        void setValue(object sender, EventArgs e)
        {
            User u = new User();
            u.Name = "李嘉诚";
            u.Gender = "M";
            u.Phone = "12345678";
            u.Birth = "2000-01-01 00:00:00";
            u.Height = "170.00";
            u.Hobby = "LQ|ZQ";
            u.HobbyOther = "写代码";
            u.Position = "XS";
            //u.PositonOther = "程序猿";
            u.Remark = "这是我的简介";
            u.Start = "2000-01-01 00:00:01";
            u.End = "2050-01-01 23:59:59";

            mAgcCenter.setValue(u);
        }
    }
}
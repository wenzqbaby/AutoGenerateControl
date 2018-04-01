using System;
using System.Collections.Generic;
using System.Text;
using AGC.api;
using AGC.validate;
using AGC.attributes;

namespace AGCTest
{
    [AgcSetting(true,20,0,20,0,10,20)]
    public class User
    {
        private String _name;
        [AgcLabel(10, "姓名：", 50, false)]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _gender;
        [AgcLabelCombo(20, "性别：", 50, "F=女", "M=男")]
        public String Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private String _phone;
        [ValidateInteger(0,0,"电话输入有误",true)]
        [AgcLabelText(30, "电话：", 150, 11, false)]
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private String _height;
        [ValidateDecimal(0,500,"身高输入有误", true)]
        [AgcLabelTextLabel(40,"身高：",80, 6,"CM",true)]
        public String Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private String _birth;
        [AgcLabelDate(50,"生日：", false)]
        public String Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        private String _position;
        [AgcRadioList(60, "职业：", 500, true, "XS=学生", "YS=医生", "JS=教师")]
        public String Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private String _positonOther;
        [AgcRadioText("Position", 100, "其他", 100, false)]
        public String PositonOther
        {
            get { return _positonOther; }
            set { _positonOther = value; }
        }

        private String _hobby;
        [AgcCheckBoxList(70, "爱好：", 500, true, "LQ=篮球", "ZQ=足球", "PQ=排球", "QQ=气球")]
        public String Hobby
        {
            get { return _hobby; }
            set { _hobby = value; }
        }

        private String _hobbyOther;
        [AgcCheckText("Hobby", 100, "其他", 100, 20, false)]
        public String HobbyOther
        {
            get { return _hobbyOther; }
            set { _hobbyOther = value; }
        }

        private String _remark;
        [AgcLabelTextarea(80, "简介：", 500, 60, 200, true)]
        public String Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private String _start;
        [AgcLabelDate(90,"从",120,false,false)]
        public String Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private String _end;
        [AgcLabelDate(95, "Start", "到", 120, false, false)]
        public String End
        {
            get { return _end; }
            set { _end = value; }
        }

        public override string ToString()
        {
            return String.Format("姓名={0}\n性别={1}\n电话={2}\n身高={3}\n生日={4}\n职业={5}\n其他职业={6}\n爱好={7}\n其他爱好={8}\n简介={9}\n开始={10}\n结束={11}", Name, Gender, Phone, Height, Birth, Position, PositonOther, Hobby, HobbyOther, Remark, Start, End);
        }
    }
}

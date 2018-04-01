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
        [AgcLabel(10, "������", 50, false)]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private String _gender;
        [AgcLabelCombo(20, "�Ա�", 50, "F=Ů", "M=��")]
        public String Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private String _phone;
        [ValidateInteger(0,0,"�绰��������",true)]
        [AgcLabelText(30, "�绰��", 150, 11, false)]
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private String _height;
        [ValidateDecimal(0,500,"�����������", true)]
        [AgcLabelTextLabel(40,"��ߣ�",80, 6,"CM",true)]
        public String Height
        {
            get { return _height; }
            set { _height = value; }
        }

        private String _birth;
        [AgcLabelDate(50,"���գ�", false)]
        public String Birth
        {
            get { return _birth; }
            set { _birth = value; }
        }

        private String _position;
        [AgcRadioList(60, "ְҵ��", 500, true, "XS=ѧ��", "YS=ҽ��", "JS=��ʦ")]
        public String Position
        {
            get { return _position; }
            set { _position = value; }
        }

        private String _positonOther;
        [AgcRadioText("Position", 100, "����", 100, false)]
        public String PositonOther
        {
            get { return _positonOther; }
            set { _positonOther = value; }
        }

        private String _hobby;
        [AgcCheckBoxList(70, "���ã�", 500, true, "LQ=����", "ZQ=����", "PQ=����", "QQ=����")]
        public String Hobby
        {
            get { return _hobby; }
            set { _hobby = value; }
        }

        private String _hobbyOther;
        [AgcCheckText("Hobby", 100, "����", 100, 20, false)]
        public String HobbyOther
        {
            get { return _hobbyOther; }
            set { _hobbyOther = value; }
        }

        private String _remark;
        [AgcLabelTextarea(80, "��飺", 500, 60, 200, true)]
        public String Remark
        {
            get { return _remark; }
            set { _remark = value; }
        }

        private String _start;
        [AgcLabelDate(90,"��",120,false,false)]
        public String Start
        {
            get { return _start; }
            set { _start = value; }
        }

        private String _end;
        [AgcLabelDate(95, "Start", "��", 120, false, false)]
        public String End
        {
            get { return _end; }
            set { _end = value; }
        }

        public override string ToString()
        {
            return String.Format("����={0}\n�Ա�={1}\n�绰={2}\n���={3}\n����={4}\nְҵ={5}\n����ְҵ={6}\n����={7}\n��������={8}\n���={9}\n��ʼ={10}\n����={11}", Name, Gender, Phone, Height, Birth, Position, PositonOther, Hobby, HobbyOther, Remark, Start, End);
        }
    }
}

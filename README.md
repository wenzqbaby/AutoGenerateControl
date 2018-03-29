# AutoGenerateControl
C# Winform自动生成控件工具

# 自动生成控件：
1、首先对需要自动创建控件的对象的属性配置，添加`AGC.attributes.AgcBase`特征(已封装部分在AGC.api包下，若不满足可以自己写AgcBase的子类)，例如：
```csharp
class User
    {
        private String _name;
        [AgcLabelText(70, "体重", 100, false)]
        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private String _phone;
        [AgcLabel(20,"电话",100,false)]
        public String Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        private String _hobby;
        [AgcCheckBoxList(30, "爱好", 230, true, "ZQ=足球", "LQ=篮球", "PQ=排球")]
        public String Hobby
        {
            get { return _hobby; }
            set { _hobby = value; }
        }
        private String _anotherHoby;
        [AgcCheckText("Hobby", 100, "其他", 150, true)]
        public String AnotherHoby
        {
            get { return _anotherHoby; }
            set { _anotherHoby = value; }
        }

        private String _gender;
        [AgcLabelCombo(25, "性别", 75, "F=女","M=男","O=不详")]
        public String Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        private String _start;
        [AgcLabelDate(40, "开始时间", true)]
        public String Start
        {
            get { return _start; }
            set { _start = value; }
        }
        private String _end;
        [AgcLabelDate(50, true, "Start", "结束时间", false)]
        public String End
        {
            get { return _end; }
            set { _end = value; }
        }
}
```
2、实例化AGC.AgcCenter<T>, 构造方法需要传入生成控件的容器，即可自动生成控件
```csharp
AGC.AgcCenter<User> mCenter = new AGC.AgcCenter<User>(this.panel);
```
如果还需要往里面添加其他非对象属性的控件，可以在构造方法中添加控件`List<AgcBase>`插槽：
```csharp
AGC.AgcCenter<User> mCenter = new AGC.AgcCenter<User>(this.panel, slot);
```

### AGC.AgcCenter<T>方法：
    
getValue()：可以获取自动生成控件对应值的对象
    
setValue(T t) : 可以把对象的值显示到自动生成的控件上

# 校验器
1、首先对需要校验的对象的属性配置，添加`AGC.validate.ValidateBase`特征(已封装部分在AGC.validate包下，若不满足可以自己写ValidateBase的子类)

2、实例化校验器：
`AGC.Validator<User> mValidator = new AGC.Validator<User>();`

3、调用校验器的`validate(T t)`方法可校验传入对象是否满足校验，返回`AGC.entity.Validatation`对象

# AgcCenter添加校验：
AgcCenter构造方法中参数allowValidate为true的话，将开启校验功能，`AgcCenter.validate()`可直接校验控件，并且对ValidateBase中AddEvent为true的属性，对AgcBase控件添加校验事件，但是AgcBase控件必须实现 `AGC.interfaces.IValidate`接口，即通过配置，可直接为控件添加校验事件

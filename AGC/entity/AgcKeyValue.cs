using System;
using System.Collections.Generic;
using System.Text;

namespace AGC.entity
{
    public class AgcKeyValue
    {
        public AgcKeyValue() { }

        public AgcKeyValue(String key, String value)
        {
            this._key = key;
            this._value = value;
        }

        private String _key;

        public String Key
        {
            get { return _key; }
            set { _key = value; }
        }

        private String _value;

        public String Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public override string ToString()
        {
            return this.Value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.CarTransport.Out.Core
{
    /// <summary>
    /// 绑定数据项
    /// </summary>
    public class DataItem
    {
        public DataItem(string text)
        {
            this._Text = text;
            this._Value = text;
        }

        public DataItem(string text, string value)
        {
            this._Text = text;
            this._Value = value;
        }

        public DataItem(string text, string value, object data)
        {
            this._Text = text;
            this._Value = value;
            this._Data = data;
        }

        private string _Text;
        public string Text { get { return _Text; } set { _Text = value; } }

        private string _Value;
        public string Value { get { return _Value; } set { _Value = value; } }

        private object _Data;

        public object Data { get { return _Data; } set { _Data = value; } }

        public override string ToString()
        {
            return _Text;
        }
    }
}

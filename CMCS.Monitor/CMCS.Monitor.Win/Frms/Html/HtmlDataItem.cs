using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CMCS.Monitor.Win.Html
{
    /// <summary>
    /// 页面传输 - 数据
    /// </summary>
    public class HtmlDataItem
    {
        public HtmlDataItem(string key, string value, eHtmlDataItemType type = eHtmlDataItemType.key_value)
        {
            this.key = key;
            this.value = value;
            this.type = type;
        }

        public HtmlDataItem(string key, string value, string tag, eHtmlDataItemType type = eHtmlDataItemType.key_value)
        {
            this.key = key;
            this.value = value;
            this.tag = tag;
            this.type = type;
        }

        public HtmlDataItem(string key, string value, string value2, string tag, eHtmlDataItemType type = eHtmlDataItemType.key_value)
        {
            this.key = key;
            this.value = value;
            this.value2 = value2;
            this.tag = tag;
            this.type = type;
        }

        private string key;
        /// <summary>
        /// 键
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private string value;
        /// <summary>
        /// 值
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private string value2;
        /// <summary>
        /// 值2
        /// </summary>
        public string Value2
        {
            get { return this.value2; }
            set { this.value2 = value; }
        }

        private eHtmlDataItemType type;
        /// <summary>
        /// 类型
        /// </summary>
        public eHtmlDataItemType Type
        {
            get { return type; }
            set { type = value; }
        }

        private string tag;
        /// <summary>
        /// 额外标识
        /// </summary>
        public string Tag
        {
            get { return this.tag; }
            set { this.tag = value; }
        }
    }
}

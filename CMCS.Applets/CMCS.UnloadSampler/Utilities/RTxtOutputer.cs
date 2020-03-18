using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.UnloadSampler.Enums;
using DevComponents.DotNetBar.Controls;

namespace CMCS.UnloadSampler.Utilities
{
    /// <summary>
    /// 文本框输出信息类
    /// </summary>
    public class RTxtOutputer
    {
        public RTxtOutputer(RichTextBoxEx rtxt)
        {
            this.rTxtOutputer = rtxt;
        }

        private object lockObject = new object();

        RichTextBoxEx rTxtOutputer;

        /// <summary>
        /// 输出运行信息
        /// </summary> 
        /// <param name="text"></param>
        /// <param name="type"></param>
        public void Output(string text, eOutputType outputType = eOutputType.Normal)
        {
            lock (lockObject)
            {
                try
                {
                    rTxtOutputer.Invoke((Action)(() =>
                    {
                        if (rTxtOutputer.TextLength > 5000)
                            rTxtOutputer.Clear();

                        text = string.Format("{0} - {1}", DateTime.Now.ToString("HH:mm:ss"), text);

                        rTxtOutputer.SelectionStart = rTxtOutputer.TextLength;

                        if (outputType == eOutputType.Normal)
                            rTxtOutputer.SelectionColor = ColorTranslator.FromHtml("#53A654");
                        else if (outputType == eOutputType.Important)
                            rTxtOutputer.SelectionColor = ColorTranslator.FromHtml("#ff91c5");
                        else if (outputType == eOutputType.Warn)
                            rTxtOutputer.SelectionColor = ColorTranslator.FromHtml("#ec7967");
                        else if (outputType == eOutputType.Error)
                            rTxtOutputer.SelectionColor = ColorTranslator.FromHtml("#f11030");

                        rTxtOutputer.AppendText(string.Format("{0}\r", text));

                        rTxtOutputer.ScrollToCaret();
                    }));
                }
                catch { }
            }
        }
    }
}
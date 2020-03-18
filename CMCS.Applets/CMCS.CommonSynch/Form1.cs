using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BasisPlatform.Util;
using CMCS.CommonSynch.Utilities;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CommonSynch
{
    public partial class Form1 : MetroForm
    {
        TableSynchDAO tableSynchDAO = new TableSynchDAO();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            tableSynchDAO.OutputInfo += new TableSynchDAO.OutputInfoEventHandler(tableSynchDAO_OutputInfo);
            tableSynchDAO.OutputError += new TableSynchDAO.OutputErrorEventHandler(tableSynchDAO_OutputError);
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
                // 添加、取消开机启动
                if (CommonAppConfig.GetInstance().Startup)
                    StartUpUtil.InsertStartUp(Application.ProductName, Application.ExecutablePath);
                else
                    StartUpUtil.DeleteStartUp(Application.ProductName);
            }
            catch { }

            tableSynchDAO.StartSynch();
        }

        private void btnOpenFrmConfigSet_Click(object sender, EventArgs e)
        {
            new FrmConfigSet().ShowDialog();
        }

        void tableSynchDAO_OutputError(string describe, Exception ex)
        {
            OutputErrorInfo(describe, ex);

            Log4netUtil.Error(describe, ex);
        }

        void tableSynchDAO_OutputInfo(string info, eOutputType outputType)
        {
            OutputRunInfo(rtxtOutput, info, outputType);

            Log4netUtil.Info(info);
        }

        #region Util

        /// <summary>
        /// 输出运行信息
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="text"></param>
        /// <param name="outputType"></param>
        private void OutputRunInfo(RichTextBoxEx richTextBox, string text, eOutputType outputType = eOutputType.Normal)
        {
            this.InvokeEx(() =>
            {
                if (richTextBox.TextLength > 100000) richTextBox.Clear();

                text = string.Format(" # {0} - {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), text);

                richTextBox.SelectionStart = richTextBox.TextLength;

                switch (outputType)
                {
                    case eOutputType.Normal:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#BD86FA");
                        break;
                    case eOutputType.Important:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#A50081");
                        break;
                    case eOutputType.Warn:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#F9C916");
                        break;
                    case eOutputType.Error:
                        richTextBox.SelectionColor = ColorTranslator.FromHtml("#DB2606");
                        break;
                    default:
                        richTextBox.SelectionColor = Color.White;
                        break;
                }

                richTextBox.AppendText(string.Format("{0}\r", text));

                richTextBox.ScrollToCaret();
            });
        }

        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        private void OutputErrorInfo(string text, Exception ex)
        {
            this.InvokeEx(() =>
            {
                text = string.Format("# {0} - {1}\r\n{2}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), text, ex.Message);

                OutputRunInfo(rtxtOutput, text + "", eOutputType.Error);
            });
        }

        /// <summary>
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }

        #endregion
    }
}

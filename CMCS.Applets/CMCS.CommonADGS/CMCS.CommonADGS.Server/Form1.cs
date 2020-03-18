using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using System.Linq;
//
using BasisPlatform.Util;
using CMCS.Common.Utilities;
using CMCS.CommonADGS.Configurations;
using CMCS.CommonADGS.Core;
using CMCS.CommonADGS.UDPDAO;
using DevComponents.DotNetBar.Controls;
namespace CMCS.CommonADGS.Server
{
    public partial class Form1 : BasisPlatform.Forms.FrmBasis
    {
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "版本：" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            this.IsSecretRunning = ServerConfiguration.Instance.IsSecretRunning;
            this.VerifyBeforeClose = ServerConfiguration.Instance.VerifyBeforeClose;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            try
            {
#if DEBUG

#else
               // 添加、取消开机启动
                if (ServerConfiguration.Instance.Startup)
                    StartUpUtil.InsertStartUp(Application.ProductName, Application.ExecutablePath);
                else
                    StartUpUtil.DeleteStartUp(Application.ProductName);
#endif
            }
            catch { }
            ExecuteAllTask();
        }

        /// <summary>
        /// 执行所有任务
        /// </summary>
        void ExecuteAllTask()
        {
            foreach (ServerConfigurationDetail item in ServerConfiguration.Instance.ServerPortSets.Where(a => a.Enabled))
            {
                UDPReceiveDAO DAO = new UDPReceiveDAO(item.MachineCode, item.Port, item.SavePath);
                DAO.OutputInfo += new UDPReceiveDAO.OutputInfoEventHandler(grabPerformer_OutputInfo);
                DAO.OutputError += new UDPReceiveDAO.OutputErrorEventHandler(grabPerformer_OutputError);
                taskSimpleScheduler.StartNewTask(item.MachineCode + "接收数据", () =>
                  {
                      DAO.StartReceive();
                  }, 0, grabPerformer_OutputError);
            }
        }

        #region Util

        void grabPerformer_OutputError(string describe, Exception ex)
        {
            OutputErrorInfo(describe, ex);

            Log4netUtil.Error(describe, ex);
        }

        void grabPerformer_OutputInfo(string info)
        {
            OutputRunInfo(rtxtOutput, info);

            Log4netUtil.Info(info);
        }

        /// <summary>
        /// 输出信息类型
        /// </summary>
        public enum eOutputType
        {
            /// <summary>
            /// 普通
            /// </summary>
            [Description("#BD86FA")]
            Normal,
            /// <summary>
            /// 重要
            /// </summary>
            [Description("#A50081")]
            Important,
            /// <summary>
            /// 警告
            /// </summary>
            [Description("#F9C916")]
            Warn,
            /// <summary>
            /// 错误
            /// </summary>
            [Description("#DB2606")]
            Error
        }

        /// <summary>
        /// 输出运行信息
        /// </summary>
        /// <param name="richTextBox"></param>
        /// <param name="text"></param>
        /// <param name="outputType"></param>
        private void OutputRunInfo(RichTextBox richTextBox, string text, eOutputType outputType = eOutputType.Normal)
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

        private void labSetting_Click(object sender, EventArgs e)
        {
            ConfigSetting frm = new ConfigSetting();
            frm.ShowDialog();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            taskSimpleScheduler.Cancal();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.CarSynchronous;
using CMCS.DumblyConcealer.Win.Core;
using CMCS.DapperDber.Dbs.AccessDb;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmDataHandler : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        RTxtOutputer rTxtOutResultputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();

        public FrmDataHandler()
        {
            InitializeComponent();
        }

        private void FrmCarSynchronous_Load(object sender, EventArgs e)
        {
            this.Text = "综合事件处理";

            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);

            ExecuteAllTask();

        }

        /// <summary>
        /// 执行所有任务
        /// </summary>
        void ExecuteAllTask()
        {
            DataHandlerDAO dataHandlerDAO = DataHandlerDAO.GetInstance();

            taskSimpleScheduler.StartNewTask("同步批次明细", () =>
            {
                dataHandlerDAO.SyncToBatch(this.rTxtOutputer.Output);

            }, 60000, OutputError);

            AccessDapperDber doorDapperDber = new AccessDapperDber("Provider=Microsoft.Jet.OLEDB.4.0;Persist Security Info =true;Data Source=\\\\10.36.0.71\\ZKAccess3.5\\ZKAccess.mdb;");
            taskSimpleScheduler.StartNewTask("同步门禁数据", () =>
            {
                dataHandlerDAO.SyncDoorData(this.rTxtOutputer.Output, doorDapperDber);

            }, 60000, OutputError);
        }

        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        void OutputError(string text, Exception ex)
        {
            this.rTxtOutputer.Output(text + Environment.NewLine + ex.Message, eOutputType.Error);

            Log4Neter.Error(text, ex);
        }

        /// <summary>
        /// 输出异常信息（结果）
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        void OutputResultError(string text, Exception ex)
        {
            this.rTxtOutResultputer.Output(text + Environment.NewLine + ex.Message, eOutputType.Error);

            Log4Neter.Error(text, ex);
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCarSynchronous_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }
    }
}

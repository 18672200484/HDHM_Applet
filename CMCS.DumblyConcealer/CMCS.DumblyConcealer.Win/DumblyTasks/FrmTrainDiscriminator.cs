using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.DumblyConcealer.Win.Core;
 
using CMCS.DumblyConcealer.Tasks.BeltSampler;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.WeightBridger;
using CMCS.DumblyConcealer.Tasks.TrainDiscriminator;
using System.Net.Sockets;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmTrainDiscriminator : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();


        public FrmTrainDiscriminator()
        {
            InitializeComponent();
        }

        private void FrmWeightBridger_Load(object sender, EventArgs e)
        {
            this.Text = "车号识别报文TCP/IP同步业务";

            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);

            ExecuteAllTask();
        }
        Socket socket;
        /// <summary>
        /// 执行所有任务
        /// </summary>
        void ExecuteAllTask()
        {
            TrainDiscriminatorDAO trainWeight_DAO = TrainDiscriminatorDAO.GetInstance();
            TrainDiscriminatorDBW trainWeight_DBW = TrainDiscriminatorDBW.GetInstance();
            TrainDiscriminatorTCPIP trainWeight_TCPIP = TrainDiscriminatorTCPIP.GetInstance();
            taskSimpleScheduler.StartNewTask("同步车号识别D报文数据", () =>
            {

                trainWeight_DAO.Save(trainWeight_DBW.GetDBWInfo(this.rTxtOutputer.Output), this.rTxtOutputer.Output);

            }, 30000, OutputError);

            taskSimpleScheduler.StartNewTask("同步车号识别TCP/IP数据", () =>
            {
                socket = trainWeight_TCPIP.CreateListening(this.rTxtOutputer.Output);
                trainWeight_TCPIP.StartListening(socket, this.rTxtOutputer.Output);
                socket.Dispose();

            }, 0, OutputError);

            //taskSimpleScheduler.StartNewTask("测试车号识别TCP/IP数据", () =>
            //{
            //    trainWeight_TCPIP.sentTime();

            //}, 0, OutputError);
        }

        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        void OutputError(string text, Exception ex)
        {
            this.rTxtOutputer.Output(text + Environment.NewLine + ex.Message, eOutputType.Error);
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmTrainWeight_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                socket.Close();
            }
            catch (Exception)
            {
            }
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }

        private void FrmTrainWeight_FormClosing(object sender, FormClosingEventArgs e)
        {
            //socket.Dispose();
        }
    }
}

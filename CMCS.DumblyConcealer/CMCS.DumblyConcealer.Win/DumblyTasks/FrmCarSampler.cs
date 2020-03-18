using System;
using System.Windows.Forms;
//
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Utilities;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.CarJXSampler;
using CMCS.DumblyConcealer.Win.Core;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
	public partial class FrmCarSampler : TaskForm
	{
		RTxtOutputer rTxtOutputer;
		RTxtOutputer rTxtOutResultputer;
		TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();

		public FrmCarSampler()
		{
			InitializeComponent();
		}

		private void FrmCarSampler_CSKY_Load(object sender, EventArgs e)
		{
			this.Text = "汽车机械采样机接口业务";

			this.rTxtOutputer = new RTxtOutputer(rtxtOutput);

			ExecuteAllTask();

		}

		/// <summary>
		/// 执行所有任务
		/// </summary>
		void ExecuteAllTask()
		{
			#region #1汽车机械采样机

			EquCarJXSamplerDAO carJXSamplerDAO1 = new EquCarJXSamplerDAO(GlobalVars.MachineCode_QCJXCYJ_1, new DapperDber.Dbs.SqlServerDb.SqlServerDapperDber(CommonDAO.GetInstance().GetCommonAppletConfigString("#1汽车机械采样机接口连接字符串")));

			taskSimpleScheduler.StartNewTask("#1汽车机械采样机-快速同步", () =>
			{
				carJXSamplerDAO1.SyncBarrel(this.rTxtOutputer.Output);
				carJXSamplerDAO1.SyncSampleCmd(this.rTxtOutputer.Output);
				carJXSamplerDAO1.SyncJXCYControlUnloadCMD(this.rTxtOutputer.Output);
				//carJXSamplerDAO1.SyncQCJXCYJError(this.rTxtOutputer.Output);
				carJXSamplerDAO1.SyncSignal(this.rTxtOutputer.Output);

			}, 2000, OutputError);

			this.taskSimpleScheduler.StartNewTask("#1汽车机械采样机-上位机心跳", () =>
			{
				carJXSamplerDAO1.SyncHeartbeatSignal();
			}, 30000, OutputError);

			#endregion

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
		private void FrmCarSampler_CSKY_FormClosed(object sender, FormClosedEventArgs e)
		{
			// 注意：必须取消任务
			this.taskSimpleScheduler.Cancal();
		}
	}
}

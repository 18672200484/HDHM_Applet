using System;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Utilities;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Enums;
//
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CarTransport.Queue.Frms.Sys
{
	public partial class FrmMainFrame : MetroForm
	{
		CommonDAO commonDAO = CommonDAO.GetInstance();

		public static SuperTabControlManager superTabControlManager;

		public FrmMainFrame()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			lblVersion.Text = new AU.Updater().Version;
			this.Text = CommonAppConfig.GetInstance().AppIdentifier;

			#region 初始化菜单查看权限
			if (GlobalVars.LoginUser.IsSupper == 0)
			{
				foreach (var item in this.panelEx2.Controls)
				{
					if (item.GetType() == typeof(ButtonX))
					{
						ButtonX btnFirst = item as ButtonX;
						if (btnFirst.SubItems.Count == 0)
						{
							if (btnFirst.Tag != null && !string.IsNullOrEmpty(btnFirst.Tag.ToString()))
							{
								//01 查看权限
								if (!QueuerDAO.GetInstance().CheckPower(btnFirst.Tag.ToString(), "01", GlobalVars.LoginUser))
									btnFirst.Enabled = false;
								else
									btnFirst.Enabled = true;
							}
						}
						else
							InitMenuPower(btnFirst.SubItems);
					}
				}
			}
			#endregion

			this.superTabControl1.Tabs.Clear();
			FrmMainFrame.superTabControlManager = new SuperTabControlManager(this.superTabControl1);

			OpenQueuer();
		}

		private void Form1_Shown(object sender, EventArgs e)
		{
			if (GlobalVars.LoginUser != null) lblLoginUserName.Text = GlobalVars.LoginUser.Name;

			commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.系统.ToString(), "1");
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (e.CloseReason == CloseReason.UserClosing)
			{
				if (MessageBoxEx.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					commonDAO.SetSignalDataValue(CommonAppConfig.GetInstance().AppIdentifier, eSignalDataName.系统.ToString(), "0");

					Application.Exit();
				}
				else
				{
					e.Cancel = true;
				}
			}
		}

		/// <summary>
		/// 退出系统
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnApplicationExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void timer_CurrentTime_Tick(object sender, EventArgs e)
		{
			lblCurrentTime.Text = DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss");
		}

		#region 打开/切换可视主界面

		#region 弹出窗体

		/// <summary>
		/// 打开入厂排队界面
		/// </summary>
		public void OpenQueuer()
		{
			string uniqueKey = FrmQueuer.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				FrmQueuer frm = new FrmQueuer();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, false);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 打开标签卡列表界面
		/// </summary>
		public void OpenEPCCard_List()
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard.FrmEPCCard_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard.FrmEPCCard_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard.FrmEPCCard_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 打开参数设置界面
		/// </summary>
		public void OpenSetting()
		{
			FrmSetting frm = new FrmSetting();
			frm.ShowDialog();
		}

		#endregion

		/// <summary>
		/// 打开参数设置界面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenSetting_Click(object sender, EventArgs e)
		{
			OpenSetting();
		}

		#endregion

		/// <summary>
		/// EPC标签卡管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenEPCCard_Click(object sender, EventArgs e)
		{
			OpenEPCCard_List();
		}

		/// <summary>
		/// 标签卡回收
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenEPCCardRecovery_Click(object sender, EventArgs e)
		{
			CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard.FrmEPCCard_Recovery frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.EPCCard.FrmEPCCard_Recovery();
			frm.ShowDialog();
		}

		/// <summary>
		/// 运输单位管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenTransportCompanyLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.TransportCompany.FrmTransportCompany_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.TransportCompany.FrmTransportCompany_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.TransportCompany.FrmTransportCompany_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 车辆信息管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenAutotruckLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck.FrmAutotruck_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck.FrmAutotruck_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.Autotruck.FrmAutotruck_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 汽车车型管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenCarModelLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.CarModel.FrmCarModel_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.CarModel.FrmCarModel_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.CarModel.FrmCarModel_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 煤种信息管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenFuelKindlLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.FuelKind.FrmFuelKind_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.FuelKind.FrmFuelKind_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.FuelKind.FrmFuelKind_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 供应商信息管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenSupplierLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier.FrmSupplier_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier.FrmSupplier_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.Supplier.FrmSupplier_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 矿点信息管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenMineLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.Mine.FrmMine_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.Mine.FrmMine_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.Mine.FrmMine_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 入厂煤运输记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenBuyFuelTransportLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.Transport.BuyFuelTransport.FrmBuyFuelTransport_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.Transport.BuyFuelTransport.FrmBuyFuelTransport_List frm = new CMCS.CarTransport.Queue.Frms.Transport.BuyFuelTransport.FrmBuyFuelTransport_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 其他物资运输记录
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenGoodsTransportLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.Transport.GoodsTransport.FrmGoodsTransport_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.Transport.GoodsTransport.FrmGoodsTransport_List frm = new CMCS.CarTransport.Queue.Frms.Transport.GoodsTransport.FrmGoodsTransport_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 修改密码
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenChangePassword_Click(object sender, EventArgs e)
		{
			FrmPassword frmpassword = new FrmPassword();
			frmpassword.ShowDialog();
			if (frmpassword.DialogResult == DialogResult.OK)
			{
				MessageBoxEx.Show("修改密码成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			}
		}

		/// <summary>
		/// 小程序配置界面
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenAppletConfigLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.AppletConfig.FrmAppletConfig_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.AppletConfig.FrmAppletConfig_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.AppletConfig.FrmAppletConfig_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 摄像头管理
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenCamareLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.CamareInfo.FrmCamare_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.CamareInfo.FrmCamare_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.CamareInfo.FrmCamare_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 物资类型
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenGoodsTypeLoad_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.GoodsType.FrmGoodsType_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.GoodsType.FrmGoodsType_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.GoodsType.FrmGoodsType_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		/// <summary>
		/// 省份简称
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnOpenProvince_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.Province.FrmProvince_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.Province.FrmProvince_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.Province.FrmProvince_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}
		#region 系统管理

		private void btnOpenUserInfo_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.BaseInfo.UserInfo.FrmUserInfo_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.BaseInfo.UserInfo.FrmUserInfo_List frm = new CMCS.CarTransport.Queue.Frms.BaseInfo.UserInfo.FrmUserInfo_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		private void btnModuleManage_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.SysManage.Frm_Module_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.SysManage.Frm_Module_List frm = new CMCS.CarTransport.Queue.Frms.SysManage.Frm_Module_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);

		}

		private void btnUser_Resource_Click(object sender, EventArgs e)
		{
			string uniqueKey = CMCS.CarTransport.Queue.Frms.SysManage.Frm_ResourceUser_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				CMCS.CarTransport.Queue.Frms.SysManage.Frm_ResourceUser_List frm = new CMCS.CarTransport.Queue.Frms.SysManage.Frm_ResourceUser_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		private void InitMenuPower(SubItemsCollection btnItems)
		{
			foreach (ButtonItem btnItem in btnItems)
			{
				if (btnItem.Tag != null && !string.IsNullOrEmpty(btnItem.Tag.ToString()))
				{
					//01 查看权限
					if (!QueuerDAO.GetInstance().CheckPower(btnItem.Tag.ToString(), "01", GlobalVars.LoginUser))
						btnItem.Enabled = false;
					else
						btnItem.Enabled = true;
				}

				InitMenuPower(btnItem.SubItems);
			}
		}

		private void btnOpenModifyLog_Click(object sender, EventArgs e)
		{
			string uniqueKey = FrmModifyLog_List.UniqueKey;

			if (FrmMainFrame.superTabControlManager.GetTab(uniqueKey) == null)
			{
				FrmModifyLog_List frm = new FrmModifyLog_List();
				FrmMainFrame.superTabControlManager.CreateTab(frm.Text, uniqueKey, frm, true, true);
			}
			else
				FrmMainFrame.superTabControlManager.ChangeToTab(uniqueKey);
		}

		#endregion

		/// <summary>
		/// 打开调试窗口
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnDebugConsole_Click(object sender, EventArgs e)
		{
			foreach (Form frm in Application.OpenForms)
			{
				if (frm is FrmDebugConsole)
				{
					FrmDebugConsole.GetInstance().Activate();
					return;
				}
			}

			FrmDebugConsole.GetInstance().Show();
		}

	}
}

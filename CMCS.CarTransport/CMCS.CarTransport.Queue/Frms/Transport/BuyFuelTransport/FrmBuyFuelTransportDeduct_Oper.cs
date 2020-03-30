using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.Transport.BuyFuelTransport
{
	public partial class FrmBuyFuelTransportDeduct_Oper : DevComponents.DotNetBar.Metro.MetroForm
	{
		#region Var

		//业务id
		string PId = String.Empty;

		//编辑模式
		eEditMode EditMode = eEditMode.默认;

		CmcsBuyFuelTransportDeduct CmcsBuyFuelTransportDeduct;

		//List<CmcsBuyFuelTransportDeduct> cmcsbuyfueltransportdeducts;

		#endregion

		public FrmBuyFuelTransportDeduct_Oper(string pId, eEditMode editMode)
		{
			InitializeComponent();

			PId = pId;
			EditMode = editMode;
		}

		/// <summary>
		/// 窗体加载绑定数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmBuyFuelTransportDeduct_Oper_Load(object sender, EventArgs e)
		{
			cmb_DeductType.Items.Add("扣矸");
			cmb_DeductType.Items.Add("扣水");
			cmb_DeductType.Items.Add("其他");
			cmb_DeductType.SelectedIndex = 0;

			if (this.EditMode == eEditMode.修改)
			{
				this.CmcsBuyFuelTransportDeduct = Dbers.GetInstance().SelfDber.Get<CmcsBuyFuelTransportDeduct>(this.PId);

				if (CmcsBuyFuelTransportDeduct != null)
				{
					cmb_DeductType.SelectedItem = CmcsBuyFuelTransportDeduct.DeductType;
					dbi_DeductWeight.Value = (double)CmcsBuyFuelTransportDeduct.DeductWeight;
					txt_OperUser.Text = CmcsBuyFuelTransportDeduct.DeductUser;
					txt_OperDate.Text = CmcsBuyFuelTransportDeduct.LastModificAtionTime.ToString();
				}
			}

			if (this.EditMode == eEditMode.查看)
			{
				btnSubmit.Enabled = false;
				HelperUtil.ControlReadOnly(panelEx2, true);
			}
		}

		/// <summary>
		/// 保存数据
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (dbi_DeductWeight.Value == 0)
			{
				MessageBoxEx.Show("扣量不能为0！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			if (this.EditMode == eEditMode.修改)
			{
				CmcsBuyFuelTransportDeduct.DeductWeight = (decimal)dbi_DeductWeight.Value;
				CmcsBuyFuelTransportDeduct.DeductType = (string)cmb_DeductType.SelectedItem;
				CmcsBuyFuelTransportDeduct.DeductUser = GlobalVars.LoginUser.Name;
				CmcsBuyFuelTransportDeduct.LastModificAtionTime = DateTime.Now;
				Dbers.GetInstance().SelfDber.Update(CmcsBuyFuelTransportDeduct);
			}
			else if (this.EditMode == eEditMode.新增)
			{
				CmcsBuyFuelTransportDeduct = new CmcsBuyFuelTransportDeduct();
				CmcsBuyFuelTransportDeduct.TransportId = this.PId;
				CmcsBuyFuelTransportDeduct.DeductWeight = (decimal)dbi_DeductWeight.Value;
				CmcsBuyFuelTransportDeduct.DeductType = (string)cmb_DeductType.SelectedItem;
				CmcsBuyFuelTransportDeduct.DeductUser = GlobalVars.LoginUser.Name;
				Dbers.GetInstance().SelfDber.Insert(CmcsBuyFuelTransportDeduct);
			}
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// 取消
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
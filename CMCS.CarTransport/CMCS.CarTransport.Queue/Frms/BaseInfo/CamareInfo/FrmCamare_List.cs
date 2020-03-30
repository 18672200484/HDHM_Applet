using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Metro;
using DevComponents.Editors;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.CamareInfo
{
	public partial class FrmCamare_List : MetroForm
	{
		#region Var

		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmCamare_List";

		/// <summary>
		/// 选中的实体
		/// </summary>
		public CmcsCamare SelCamera;

		/// <summary>
		/// 当前界面操作模式
		/// </summary>
		private eEditMode CurrEditMode = eEditMode.默认;

		CommonDAO commonDAO = CommonDAO.GetInstance();

		#endregion

		public FrmCamare_List()
		{
			InitializeComponent();
		}

		private void FrmCamare_List_Shown(object sender, EventArgs e)
		{
			InitTree();

			//01查看 02增加 03修改 04删除
			btnAdd.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
			btnUpdate.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "03", GlobalVars.LoginUser);
			btnDelete.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);
		}

		private void InitTree()
		{
			IList<CmcsCamare> rootList = Dbers.GetInstance().SelfDber.Entities<CmcsCamare>();

			if (rootList.Count == 0)
			{
				//初始化根节点
				CmcsCamare rootcamera = new CmcsCamare();
				rootcamera.Id = "-1";
				rootcamera.Name = "摄像头管理";
				rootcamera.NodeCode = "00";
				rootcamera.Channel = 0;
				rootcamera.Sort = 0;
				Dbers.GetInstance().SelfDber.Insert<CmcsCamare>(rootcamera);
			}

			advTree1.Nodes.Clear();

			CmcsCamare rootEntity = Dbers.GetInstance().SelfDber.Get<CmcsCamare>("-1");
			DevComponents.AdvTree.Node rootNode = CreateNode(rootEntity);

			LoadData(rootEntity, rootNode);

			advTree1.Nodes.Add(rootNode);

			ProcessFromRequest(eEditMode.查看);
		}

		void LoadData(CmcsCamare entity, DevComponents.AdvTree.Node node)
		{
			if (entity == null || node == null) return;

			foreach (CmcsCamare item in Dbers.GetInstance().SelfDber.Entities<CmcsCamare>("where ParentId=:ParentId order by Sort asc", new { ParentId = entity.Id }))
			{
				DevComponents.AdvTree.Node newNode = CreateNode(item);
				node.Nodes.Add(newNode);
				LoadData(item, newNode);
			}
		}

		DevComponents.AdvTree.Node CreateNode(CmcsCamare entity)
		{
			DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(entity.Name);
			node.Tag = entity;
			node.Expanded = true;
			return node;
		}

		private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
		{
			SelCameraNode();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (this.SelCamera == null)
			{
				MessageBoxEx.Show("请先选择一个摄像头!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.新增);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (this.SelCamera == null)
			{
				MessageBoxEx.Show("请先选择一个摄像头!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.修改);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{

			if (this.SelCamera == null)
			{
				MessageBoxEx.Show("请先选择一个摄像头!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.删除);
		}

		void SelCameraNode()
		{
			this.SelCamera = (advTree1.SelectedNode.Tag as CmcsCamare);
			ProcessFromRequest(eEditMode.查看);
		}

		void ProcessFromRequest(eEditMode editMode)
		{
			switch (editMode)
			{
				case eEditMode.新增:
					CurrEditMode = editMode;
					ClearFromControls();
					HelperUtil.ControlReadOnly(pnlMain, false);
					break;
				case eEditMode.修改:
					CurrEditMode = editMode;
					InitObjectInfo();
					HelperUtil.ControlReadOnly(pnlMain, false);
					break;
				case eEditMode.查看:
					CurrEditMode = editMode;
					InitObjectInfo();
					HelperUtil.ControlReadOnly(pnlMain, true);
					break;
				case eEditMode.删除:
					CurrEditMode = editMode;
					DelTreeNode();
					ClearFromControls();
					HelperUtil.ControlReadOnly(pnlMain, true);
					break;
			}
		}

		/// <summary>
		/// 删除子节点
		/// </summary>
		void DelTreeNode()
		{
			if (this.SelCamera.Id == "-1") { MessageBoxEx.Show("根节点不允许删除!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
			if (MessageBoxEx.Show("确认删除该节点及子节点吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Dbers.GetInstance().SelfDber.DeleteBySQL<CmcsCamare>("where Id=:Id or parentId=:Id", new { Id = SelCamera.Id });
			}
			InitTree();
		}

		void InitObjectInfo()
		{
			if (this.SelCamera == null) return;
			txt_CameraName.Text = this.SelCamera.Name;
			txt_IP.Text = this.SelCamera.Ip;
			txt_UserName.Text = this.SelCamera.UserName;
			txt_Password.Text = this.SelCamera.Password;
			txt_Port.Text = this.SelCamera.Port.ToString();
			cmbCameraType.SelectedText = this.SelCamera.Type;
			txt_Channel.Text = this.SelCamera.Channel.ToString();
			dbi_Sequence.Text = this.SelCamera.Sort.ToString();
			txt_EquipmentCode.Text = this.SelCamera.EquipmentCode;
			txt_Remark.Text = this.SelCamera.Remark;
			cmbCameraType.SelectedIndex = Convert.ToInt32(this.SelCamera.Type);
		}

		void ClearFromControls()
		{
			txt_CameraName.ResetText();
			txt_UserName.ResetText();
			txt_Password.ResetText();
			dbi_Sequence.Value = 0;
			txt_IP.ResetText();
			txt_Port.Value = 0;
			cmbCameraType.SelectedIndex = 0;
			txt_Code.ResetText();
			txt_Channel.Value = 0;
			txt_EquipmentCode.Text = "";
			txt_Remark.ResetText();
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidatePage()) return;

			if (CurrEditMode == eEditMode.新增)
			{
				if (this.SelCamera == null) return;
				CmcsCamare entity = new CmcsCamare();
				entity.NodeCode = commonDAO.GetCameraNewChildCode(this.txt_Code.Text);
				entity.Name = txt_CameraName.Text;
				entity.Ip = txt_IP.Text;
				entity.UserName = txt_UserName.Text;
				entity.Password = txt_Password.Text;
				entity.Port = Convert.ToInt32(txt_Port.Text);
				entity.Sort = Convert.ToInt32(dbi_Sequence.Text);
				entity.EquipmentCode = txt_EquipmentCode.Text;
				entity.Remark = txt_Remark.Text;
				entity.Channel = Convert.ToInt32(txt_Channel.Text);
				entity.Type = cmbCameraType.SelectedIndex.ToString();
				entity.ParentId = this.SelCamera.Id;
				Dbers.GetInstance().SelfDber.Insert<CmcsCamare>(entity);
			}
			else if (CurrEditMode == eEditMode.修改)
			{
				if (this.SelCamera == null) return;
				this.SelCamera.Name = txt_CameraName.Text;
				this.SelCamera.Ip = txt_IP.Text;
				this.SelCamera.UserName = txt_UserName.Text;
				this.SelCamera.Password = txt_Password.Text;
				this.SelCamera.Port = Convert.ToInt32(txt_Port.Text);
				this.SelCamera.Type = cmbCameraType.SelectedIndex.ToString();
				this.SelCamera.Channel = Convert.ToInt32(txt_Channel.Text);
				this.SelCamera.Sort = Convert.ToInt32(dbi_Sequence.Text);
				this.SelCamera.EquipmentCode = txt_EquipmentCode.Text;
				this.SelCamera.Remark = txt_Remark.Text;
				Dbers.GetInstance().SelfDber.Update<CmcsCamare>(this.SelCamera);
			}

			InitTree();
		}

		private void btnCancel_Click(object sender, EventArgs e)
		{
			InitTree();
		}

		/// <summary>
		/// 验证页面控件值的有效合法性
		/// </summary>
		/// <returns></returns>
		private bool ValidatePage()
		{
			if (string.IsNullOrEmpty(txt_CameraName.Text))
			{
				MessageBoxEx.Show("摄像头名称不能为空!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (commonDAO.IsExistCameraName(txt_CameraName.Text, SelCamera.Id))
			{
				MessageBoxEx.Show("已有相同摄像头名称!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
	}
}

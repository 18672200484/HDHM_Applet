using System;
using System.Collections.Generic;
using System.Windows.Forms;
using CMCS.CarTransport.DAO;
//
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.FuelKind
{
	public partial class FrmFuelKind_List : DevComponents.DotNetBar.Metro.MetroForm
	{
		#region Var

		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmFuelKind_List";

		/// <summary>
		/// 选中的实体
		/// </summary>
		public CmcsFuelKind SelFuelKind;

		/// <summary>
		/// 当前界面操作模式
		/// </summary>
		private eEditMode CurrEditMode = eEditMode.默认;

		CommonDAO commonDAO = CommonDAO.GetInstance();

		#endregion

		public FrmFuelKind_List()
		{
			InitializeComponent();
		}

		private void FrmFuelKind_List_Shown(object sender, EventArgs e)
		{
			InitTree();
			//权限控制
			btnAdd.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
			btnEdit.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "03", GlobalVars.LoginUser);
			btnDelete.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);
		}

		private void InitTree()
		{
			IList<CmcsFuelKind> rootList = Dbers.GetInstance().SelfDber.Entities<CmcsFuelKind>();

			if (rootList.Count == 0)
			{
				//初始化根节点
				CmcsFuelKind rootFuelKind = new CmcsFuelKind();
				rootFuelKind.Id = "-1";
				rootFuelKind.Name = "煤种管理";
				rootFuelKind.Code = "00";
				rootFuelKind.IsStop = 0;
				rootFuelKind.Sort = 0;
				Dbers.GetInstance().SelfDber.Insert<CmcsFuelKind>(rootFuelKind);
			}

			advTree1.Nodes.Clear();

			CmcsFuelKind rootEntity = Dbers.GetInstance().SelfDber.Get<CmcsFuelKind>("-1");
			DevComponents.AdvTree.Node rootNode = CreateNode(rootEntity);

			LoadData(rootEntity, rootNode);

			advTree1.Nodes.Add(rootNode);

			ProcessFromRequest(eEditMode.查看);
		}

		void LoadData(CmcsFuelKind entity, DevComponents.AdvTree.Node node)
		{
			if (entity == null || node == null) return;

			foreach (CmcsFuelKind item in Dbers.GetInstance().SelfDber.Entities<CmcsFuelKind>("where ParentId=:ParentId order by Sort asc", new { ParentId = entity.Id }))
			{
				DevComponents.AdvTree.Node newNode = CreateNode(item);
				node.Nodes.Add(newNode);
				LoadData(item, newNode);
			}
		}

		DevComponents.AdvTree.Node CreateNode(CmcsFuelKind entity)
		{
			DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(entity.Name + ((entity.IsStop == 0) ? "" : "(无效)"));
			node.Tag = entity;
			node.Expanded = true;
			return node;
		}

		private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
		{
			SelFuelNode();
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (this.SelFuelKind == null)
			{
				MessageBoxEx.Show("请先选择一个煤种!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.新增);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (this.SelFuelKind == null)
			{
				MessageBoxEx.Show("请先选择一个煤种!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			ProcessFromRequest(eEditMode.修改);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (this.SelFuelKind == null)
			{
				MessageBoxEx.Show("请先选择一个煤种!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}
			ProcessFromRequest(eEditMode.删除);
		}

		private void SelFuelNode()
		{
			this.SelFuelKind = (advTree1.SelectedNode.Tag as CmcsFuelKind);
			ProcessFromRequest(eEditMode.查看);
		}

		private void ProcessFromRequest(eEditMode editMode)
		{
			switch (editMode)
			{
				case eEditMode.新增:
					CurrEditMode = editMode;
					ClearFromControls();
					HelperUtil.ControlReadOnly(pnlMain, false);
					txtFuelCode.ReadOnly = true;
					break;
				case eEditMode.修改:
					CurrEditMode = editMode;
					InitObjectInfo();
					HelperUtil.ControlReadOnly(pnlMain, false);
					txtFuelCode.ReadOnly = true;
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

		private void DelTreeNode()
		{
			if (this.SelFuelKind.Id == "-1") { MessageBoxEx.Show("根节点不允许删除!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
			if (MessageBoxEx.Show("确认删除该节点及子节点吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Dbers.GetInstance().SelfDber.DeleteBySQL<CmcsFuelKind>("where Id=:Id or parentId=:Id", new { Id = SelFuelKind.Id });
			}
			InitTree();
		}

		private void InitObjectInfo()
		{
			if (this.SelFuelKind == null) return;
			txt_FuelName.Text = this.SelFuelKind.Name;
			txtFuelCode.Text = this.SelFuelKind.Code;
			txt_ReMark.Text = this.SelFuelKind.ReMark;
			dbi_Sequence.Text = this.SelFuelKind.Sort.ToString();
			chb_IsUse.Checked = (this.SelFuelKind.IsStop == 0);
		}

		private void ClearFromControls()
		{
			txt_FuelName.Text = string.Empty;
			txtFuelCode.Text = "自动生成";
			txt_ReMark.Text = string.Empty;
			dbi_Sequence.Value = 0;
			chb_IsUse.Checked = false;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidatePage()) return;

			if (CurrEditMode == eEditMode.新增)
			{
				if (this.SelFuelKind == null) return;
				CmcsFuelKind entity = new CmcsFuelKind();
				entity.Code = commonDAO.GetFuelKindNewChildCode(this.SelFuelKind.Code);
				entity.Name = txt_FuelName.Text;
				entity.Sort = dbi_Sequence.Value;
				entity.ParentId = this.SelFuelKind.Id;
				entity.IsStop = chb_IsUse.Checked ? 0 : 1;
				Dbers.GetInstance().SelfDber.Insert<CmcsFuelKind>(entity);
			}
			else if (CurrEditMode == eEditMode.修改)
			{
				if (this.SelFuelKind == null) return;
				this.SelFuelKind.Name = txt_FuelName.Text;
				this.SelFuelKind.Code = txtFuelCode.Text;
				this.SelFuelKind.Sort = dbi_Sequence.Value;
				this.SelFuelKind.IsStop = chb_IsUse.Checked ? 0 : 1;
				this.SelFuelKind.ReMark = txt_ReMark.Text;
				Dbers.GetInstance().SelfDber.Update<CmcsFuelKind>(this.SelFuelKind);
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
			if (string.IsNullOrEmpty(txt_FuelName.Text))
			{
				MessageBoxEx.Show("煤种名称不能为空!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (commonDAO.IsExistFuelKindName(txt_FuelName.Text, SelFuelKind.Id))
			{
				MessageBoxEx.Show("已有相同煤种名称!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
	}
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.Mine
{
	public partial class FrmMine_List : DevComponents.DotNetBar.Metro.MetroForm
	{
		/// <summary>
		/// 窗体唯一标识符
		/// </summary>
		public static string UniqueKey = "FrmMine_List";
		/// <summary>
		/// 选中的实体
		/// </summary>
		public CmcsMine SelCmcsMine;
		/// <summary>
		/// 当前界面操作模式
		/// </summary>
		private eEditMode EditMode = eEditMode.默认;

		CommonDAO commonDAO = CommonDAO.GetInstance();

		public FrmMine_List()
		{
			InitializeComponent();
		}

		private void FrmMine_List_Shown(object sender, EventArgs e)
		{
			InitTree();
			//权限控制
			BtnAdd.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
			btnEdit.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "03", GlobalVars.LoginUser);
			btnDelete.Enabled = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);
		}

		private void InitTree()
		{
			IList<CmcsMine> rootList = Dbers.GetInstance().SelfDber.Entities<CmcsMine>();

			if (rootList.Count == 0)
			{
				//初始化根节点
				CmcsMine rootFuelKind = new CmcsMine();
				rootFuelKind.Id = "-1";
				rootFuelKind.Name = "矿点管理";
				rootFuelKind.Code = "00";
				rootFuelKind.IsStop = 0;
				rootFuelKind.Sort = 0;
				Dbers.GetInstance().SelfDber.Insert<CmcsMine>(rootFuelKind);
			}

			advTree1.Nodes.Clear();

			CmcsMine rootEntity = Dbers.GetInstance().SelfDber.Get<CmcsMine>("-1");
			DevComponents.AdvTree.Node rootNode = CreateNode(rootEntity);

			LoadData(rootEntity, rootNode);

			advTree1.Nodes.Add(rootNode);

			ProcessFromRequest(eEditMode.查看);
		}

		void LoadData(CmcsMine entity, DevComponents.AdvTree.Node node)
		{
			if (entity == null || node == null) return;

			foreach (CmcsMine item in Dbers.GetInstance().SelfDber.Entities<CmcsMine>("where ParentId=:ParentId order by Sort asc", new { ParentId = entity.Id }))
			{
				DevComponents.AdvTree.Node newNode = CreateNode(item);
				node.Nodes.Add(newNode);
				LoadData(item, newNode);
			}
		}

		DevComponents.AdvTree.Node CreateNode(CmcsMine entity)
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
			if (this.SelCmcsMine == null)
			{
				MessageBoxEx.Show("请先选择一个矿点!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.新增);
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			if (this.SelCmcsMine == null)
			{
				MessageBoxEx.Show("请先选择一个矿点!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.修改);
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			if (this.SelCmcsMine == null)
			{
				MessageBoxEx.Show("请先选择一个矿点!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}
			ProcessFromRequest(eEditMode.删除);
		}

		private void SelFuelNode()
		{
			this.SelCmcsMine = (advTree1.SelectedNode.Tag as CmcsMine);
			ProcessFromRequest(eEditMode.查看);
		}

		private void ProcessFromRequest(eEditMode editMode)
		{
			switch (editMode)
			{
				case eEditMode.新增:
					EditMode = editMode;
					ClearFromControls();
					HelperUtil.ControlReadOnly(pnlMain, false);
					txt_Code.ReadOnly = true;
					break;
				case eEditMode.修改:
					EditMode = editMode;
					InitObjectInfo();
					HelperUtil.ControlReadOnly(pnlMain, false);
					txt_Code.ReadOnly = true;
					break;
				case eEditMode.查看:
					EditMode = editMode;
					InitObjectInfo();
					HelperUtil.ControlReadOnly(pnlMain, true);
					break;
				case eEditMode.删除:
					EditMode = editMode;
					DelTreeNode();
					ClearFromControls();
					HelperUtil.ControlReadOnly(pnlMain, true);
					break;
			}
		}

		private void DelTreeNode()
		{
			if (this.SelCmcsMine.Id == "-1") { MessageBoxEx.Show("根节点不允许删除!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
			if (MessageBoxEx.Show("确认删除该节点及子节点吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Dbers.GetInstance().SelfDber.DeleteBySQL<CmcsMine>("where Id=:Id or parentId=:Id", new { Id = SelCmcsMine.Id });
			}
			InitTree();
		}

		private void InitObjectInfo()
		{
			if (this.SelCmcsMine == null) return;
			txt_Name.Text = this.SelCmcsMine.Name;
			txt_Code.Text = this.SelCmcsMine.Code;
			txt_ReMark.Text = this.SelCmcsMine.ReMark;
			dbi_Sequence.Text = this.SelCmcsMine.Sort.ToString();
			chb_IsUse.Checked = (this.SelCmcsMine.IsStop == 0);
		}

		private void ClearFromControls()
		{
			txt_Name.Text = string.Empty;
			txt_Code.Text = "自动生成";
			txt_ReMark.Text = string.Empty;
			dbi_Sequence.Value = 0;
			chb_IsUse.Checked = false;
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			if (!ValidatePage()) return;

			if (EditMode == eEditMode.新增)
			{
				if (this.SelCmcsMine == null) return;
				CmcsMine entity = new CmcsMine();
				entity.Code = commonDAO.GetFuelKindNewChildCode(this.SelCmcsMine.Code);
				entity.Name = txt_Name.Text;
				entity.Sort = dbi_Sequence.Value;
				entity.ParentId = this.SelCmcsMine.Id;
				entity.IsStop = chb_IsUse.Checked ? 0 : 1;
				Dbers.GetInstance().SelfDber.Insert<CmcsMine>(entity);
			}
			else if (EditMode == eEditMode.修改)
			{
				if (this.SelCmcsMine == null) return;
				this.SelCmcsMine.Name = txt_Name.Text;
				this.SelCmcsMine.Code = txt_Code.Text;
				this.SelCmcsMine.Sort = dbi_Sequence.Value;
				this.SelCmcsMine.IsStop = chb_IsUse.Checked ? 0 : 1;
				this.SelCmcsMine.ReMark = txt_ReMark.Text;
				Dbers.GetInstance().SelfDber.Update<CmcsMine>(this.SelCmcsMine);
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
			if (string.IsNullOrEmpty(txt_Name.Text))
			{
				MessageBoxEx.Show("矿点名称不能为空!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			if (commonDAO.IsExistMineName(txt_Name.Text, SelCmcsMine.Id))
			{
				MessageBoxEx.Show("已有相同矿点名称!", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
			return true;
		}
	}
}
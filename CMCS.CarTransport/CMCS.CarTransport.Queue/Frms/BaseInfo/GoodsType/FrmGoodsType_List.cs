using System;
using System.Collections.Generic;
using System.Windows.Forms;
//
using CMCS.CarTransport.DAO;
using CMCS.CarTransport.Queue.Core;
using CMCS.CarTransport.Queue.Enums;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Frms.BaseInfo.GoodsType
{
	public partial class FrmGoodsType_List : DevComponents.DotNetBar.Metro.MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmGoodsType_List";

        /// <summary>
        /// 选中的实体
        /// </summary>
        public CmcsGoodsType Output;

        /// <summary>
        /// 当前界面操作模式
        /// </summary>
        private eEditMode CurrEditMode = eEditMode.默认;

        CommonDAO commonDAO = CommonDAO.GetInstance();

        public FrmGoodsType_List()
        {
            InitializeComponent();
        }

        private void FrmGoodsType_List_Shown(object sender, EventArgs e)
        {
            InitTree();

            //01查看 02增加 03修改 04删除
            btnAdd.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "02", GlobalVars.LoginUser);
            btnUpdate.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "03", GlobalVars.LoginUser);
            btnDelete.Visible = QueuerDAO.GetInstance().CheckPower(this.GetType().ToString(), "04", GlobalVars.LoginUser);
        }

        private void InitTree()
        {
            IList<CmcsGoodsType> rootList = Dbers.GetInstance().SelfDber.Entities<CmcsGoodsType>();

            if (rootList.Count == 0)
            {
                //初始化根节点
                CmcsGoodsType rootGoods = new CmcsGoodsType();
                rootGoods.Id = "-1";
                rootGoods.GoodsName = "物资名称";
                rootGoods.TreeCode = "00";
                rootGoods.IsValid = 1;
                rootGoods.OrderNumber = 0;
                Dbers.GetInstance().SelfDber.Insert<CmcsGoodsType>(rootGoods);
            }

            advTree1.Nodes.Clear();

            CmcsGoodsType rootEntity = Dbers.GetInstance().SelfDber.Get<CmcsGoodsType>("-1");
            DevComponents.AdvTree.Node rootNode = CreateNode(rootEntity);

            LoadData(rootEntity, rootNode);

            advTree1.Nodes.Add(rootNode);

            ProcessFromRequest(eEditMode.查看);
        }

        void LoadData(CmcsGoodsType entity, DevComponents.AdvTree.Node node)
        {
            if (entity == null || node == null) return;

            foreach (CmcsGoodsType item in Dbers.GetInstance().SelfDber.Entities<CmcsGoodsType>("where ParentId=:ParentId order by OrderNumber asc", new { ParentId = entity.Id }))
            {
                DevComponents.AdvTree.Node newNode = CreateNode(item);
                node.Nodes.Add(newNode);
                LoadData(item, newNode);
            }
        }

        DevComponents.AdvTree.Node CreateNode(CmcsGoodsType entity)
        {
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(entity.GoodsName + (entity.IsValid == 1 ? "" : "(无效)"));
            node.Tag = entity;
            node.Expanded = true;
            return node;
        }

        private void advTree1_NodeClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            SelGoodsTypeNode();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ProcessFromRequest(eEditMode.新增);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (this.Output == null)
            {
                MessageBoxEx.Show("操作提示", "请先选择一个物资!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProcessFromRequest(eEditMode.修改);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.Output == null)
            {
                MessageBoxEx.Show("操作提示", "请先选择一个物资!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            ProcessFromRequest(eEditMode.删除);
        }

        void SelGoodsTypeNode()
        {
            this.Output = (advTree1.SelectedNode.Tag as CmcsGoodsType);
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
					txt_TreeCode.ReadOnly = true;
                    break;
                case eEditMode.修改:
                    CurrEditMode = editMode;
                    InitObjectInfo();
                    HelperUtil.ControlReadOnly(pnlMain, false);
					txt_TreeCode.ReadOnly = true;
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
            if (this.Output.Id == "-1") { MessageBoxEx.Show("操作提示", "根节点不允许删除!", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }
            if (MessageBoxEx.Show("确认删除该节点及子节点吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dbers.GetInstance().SelfDber.DeleteBySQL<CmcsGoodsType>("where Id=:Id or parentId=:Id", new { Id = Output.Id });
            }
            InitTree();
        }

        void InitObjectInfo()
        {
            if (this.Output == null) return;
            txt_GoodsName.Text = this.Output.GoodsName;
            txt_TreeCode.Text = this.Output.TreeCode;
            txt_ReMark.Text = this.Output.Remark;
            dbi_OrderNumber.Text = this.Output.OrderNumber.ToString();
            chb_IsUse.Checked = (this.Output.IsValid == 1);
        }

        void ClearFromControls()
        {
            txt_GoodsName.Text = string.Empty;
            txt_TreeCode.Text = "自动生成";
            txt_ReMark.Text = string.Empty;
            dbi_OrderNumber.Value = 0;
            chb_IsUse.Checked = false;
        }

        void addCmcsGoodsType(CmcsGoodsType item)
        {
            txt_GoodsName.Text = item.GoodsName;
            txt_ReMark.Text = item.Remark;
            dbi_OrderNumber.Text = item.OrderNumber.ToString();
            txt_TreeCode.Text = item.TreeCode;
            chb_IsUse.Checked = (item.IsValid == 1);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!ValidatePage()) return;

            if (CurrEditMode == eEditMode.新增)
            {
                if (this.Output == null) return;
                CmcsGoodsType entity = new CmcsGoodsType();
                entity.TreeCode = commonDAO.GetGoodsNewChildCode(this.Output.TreeCode);
                entity.GoodsName = txt_GoodsName.Text;
                entity.OrderNumber = Convert.ToInt32(dbi_OrderNumber.Text);
                entity.ParentId = this.Output.Id;
                entity.IsValid = chb_IsUse.Checked ? 1 : 0;
                entity.Remark = txt_ReMark.Text;
                Dbers.GetInstance().SelfDber.Insert<CmcsGoodsType>(entity);
            }
            else if (CurrEditMode == eEditMode.修改)
            {
                if (this.Output == null) return;
                this.Output.GoodsName = txt_GoodsName.Text;
                this.Output.OrderNumber = Convert.ToInt32(dbi_OrderNumber.Text);
                this.Output.IsValid = chb_IsUse.Checked ? 1 : 0;
                this.Output.Remark = txt_ReMark.Text;
                Dbers.GetInstance().SelfDber.Update<CmcsGoodsType>(this.Output);
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
            if (string.IsNullOrEmpty(txt_GoodsName.Text))
            {
                MessageBoxEx.Show("操作提示", "物资名称不能为空!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (commonDAO.IsExistGoodsName(txt_GoodsName.Text, Output.Id))
            {
                MessageBoxEx.Show("操作提示", "已有相同物资名称!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CMCS.Common;
using DevComponents.DotNetBar.SuperGrid;
using CMCS.CarTransport.DAO;
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;

namespace CMCS.CarTransport.Queue.Frms
{
    public partial class FrmGoodsType_Select : DevComponents.DotNetBar.Metro.MetroForm
    {
        /// <summary>
        /// 选中的实体
        /// </summary>
        public CmcsGoodsType Output;

        public FrmGoodsType_Select()
        {
            InitializeComponent();
        }

        private void FrmGoodsType_Select_Shown(object sender, EventArgs e)
        {
            advTree1.Nodes.Clear();

            CmcsGoodsType rootEntity = Dbers.GetInstance().SelfDber.Entity<CmcsGoodsType>("where ParentId is null");
            DevComponents.AdvTree.Node rootNode = CreateNode(rootEntity);

            LoadData(rootEntity, rootNode);

            advTree1.Nodes.Add(rootNode);
        }

        private void FrmGoodsType_Select_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Output = null;
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
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
            DevComponents.AdvTree.Node node = new DevComponents.AdvTree.Node(entity.GoodsName);
            node.Tag = entity;
            node.Expanded = true;
            return node;
        }

        void Return()
        {
            if (advTree1.SelectedNode.Parent == null) return;

            this.Output = (advTree1.SelectedNode.Tag as CmcsGoodsType);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void advTree1_NodeDoubleClick(object sender, DevComponents.AdvTree.TreeNodeMouseEventArgs e)
        {
            Return();
        }
    }
}
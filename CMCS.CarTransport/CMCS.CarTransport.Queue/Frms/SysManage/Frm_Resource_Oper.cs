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
using CMCS.Common;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.iEAA;
using CMCS.Common.Entities.Sys;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Metro;

namespace CMCS.CarTransport.Queue.Frms.SysManage
{
    public partial class Frm_Resource_Oper : MetroForm
    {
        SysResource CurrSysResource = null;
        SysModule CurrSysModule = null;
        QueuerDAO queuerDAO = QueuerDAO.GetInstance();
        int orderno = 0;

        public Frm_Resource_Oper(SysResource sysresource)
        {
            InitializeComponent();

            this.CurrSysResource = sysresource;
        }

        public Frm_Resource_Oper(SysModule sysmodule)
        {
            InitializeComponent();

            this.CurrSysModule = sysmodule;
        }

        private void Frm_Resource_Oper_Load(object sender, EventArgs e)
        {
            if (this.CurrSysResource != null)
            {
                this.Text = "模块管理 - 详情";
                btnSubmit.Text = "修改";

                txtResName.Text = this.CurrSysResource.ResName;
                txtResNo.Text = this.CurrSysResource.Resno;
                txtCreateDate.Text = this.CurrSysResource.CreationTime.ToString("yyyy-MM-dd HH:mm");
            }
            else
            {
                this.Text = "模块管理 - 新增";
                btnSubmit.Text = "新增";

                txtCreateDate.Text = DateTime.Now.ToString("yyyy-MM-dd HH:mm");
                txtResNo.Text = queuerDAO.CreateResourceno(CurrSysModule, out orderno);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtResName.Text))
            {
                MessageBoxEx.Show("请输入功能名称！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (this.CurrSysResource == null)
            {
                // 新增
                SysResource entity = new SysResource();
                entity.ResName = txtResName.Text.Trim();
                entity.Resno = txtResNo.Text.Trim();
                entity.ModuleId = CurrSysModule.Id;
                entity.OrderNO = orderno;

                Dbers.GetInstance().SelfDber.Insert<SysResource>(entity);

                MessageBoxEx.Show("新增成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                txtResName.Text = string.Empty;
                txtResNo.Text = string.Empty;
            }
            else
            {
                // 修改
                this.CurrSysResource.ResName = txtResName.Text.Trim();

                Dbers.GetInstance().SelfDber.Update<SysResource>(this.CurrSysResource);

                MessageBoxEx.Show("修改成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnCancel_Click(null, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.DataTester.DAO; 

namespace CMCS.DataTester.Frms
{
    public partial class FrmBuildTrainCarriagePass : Form
    {
        DataTesterDAO dataTesterDAO = DataTesterDAO.GetInstance();

        public FrmBuildTrainCarriagePass()
        {
            InitializeComponent();
        }

        private void FrmBuildTrainCarriagePass_Load(object sender, EventArgs e)
        {
            cmbDirection.SelectedIndex = 0;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (dataTesterDAO.CreateTrainCarriagePass(txtMachineCode.Text.Trim(), txtCarNumber.Text.Trim(), cmbDirection.Text))
            {
                MessageBox.Show("生成成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

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
    public partial class FrmBuildTrainWeightRecord : Form
    {
        DataTesterDAO dataTesterDAO = DataTesterDAO.GetInstance();

        public FrmBuildTrainWeightRecord()
        {
            InitializeComponent();
        }

        private void FrmBuildTrainWeightRecord_Load(object sender, EventArgs e)
        {
            txtInFactoryTime.Value = DateTime.Now;
        }

        private void btnBuild_Click(object sender, EventArgs e)
        {
            if (dataTesterDAO.CreateTrainWeightRecords((int)txtRecordCount.Value, txtMachineCode.Text.Trim(), txtInFactoryTime.Value, txtSupplierName.Text.Trim(), txtMineName.Text.Trim(), txtStationName.Text.Trim(), txtFuelKindName.Text.Trim()))
            {
                MessageBox.Show("生成成功", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

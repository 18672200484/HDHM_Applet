using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;

namespace CMCS.CarTransport.Queue.UserControls
{
    /// <summary>
    /// 入厂煤来煤预报选择控件
    /// </summary>
    public partial class UCtrlBuyFuelForecast : UserControl
    {
        CmcsLMYB lMYB;

        public delegate void Selected(CmcsLMYB lMYB);
        public event Selected OnSelected;

        public UCtrlBuyFuelForecast(CmcsLMYB lMYB)
        {
            InitializeComponent();

            this.lMYB = lMYB;
        }

        private void UCtrlBuyFuelForecast_Load(object sender, EventArgs e)
        {
            LoadLMYB();
        }

        void LoadLMYB()
        {
            if (this.lMYB != null)
            {
                txtCoalNumber.Text = this.lMYB.CoalNumber.ToString("F2");
                txtFuelKindName.Text = this.lMYB.FuelKindName;
                txtInFactoryTime.Text = this.lMYB.InFactoryTime.ToString("yyyy-MM-dd");
                txtMineName.Text = this.lMYB.MineName;
                txtSupplierName.Text = this.lMYB.SupplierName;
                txtTransportCompanyName.Text = this.lMYB.TransportCompanyName;
                txtTransportNumber.Text = this.lMYB.TransportNumber.ToString("F0");
                txtYbNum.Text = this.lMYB.YbNum;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (this.OnSelected != null) this.OnSelected(this.lMYB);
        }
    }
}

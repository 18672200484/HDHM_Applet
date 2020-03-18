using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CMCS.Common.Entities.CarTransport;
using CMCS.CarTransport.Queue.UserControls;
using CMCS.Common.Entities.Fuel;

namespace CMCS.CarTransport.Queue.Frms
{
    public partial class FrmBuyFuelForecast_Confirm : DevComponents.DotNetBar.Metro.MetroForm
    {
        public CmcsLMYB Output;

        List<CmcsLMYB> list = new List<CmcsLMYB>();

        public FrmBuyFuelForecast_Confirm(List<CmcsLMYB> list)
        {
            InitializeComponent();

            this.list = list;
        }

        private void FrmBuyFuelForecast_Confirm_Load(object sender, EventArgs e)
        {
            if (this.list.Count == 1) this.Width = 325;
            if (this.list.Count == 2) this.Width = 635;
        }

        private void FrmBuyFuelForecast_Confirm_Shown(object sender, EventArgs e)
        {
            CreateUCtrlBuyFuelForecast();
        }

        void CreateUCtrlBuyFuelForecast()
        {
            foreach (CmcsLMYB lMYB in this.list)
            {
                UCtrlBuyFuelForecast uCtrlBuyFuelForecast = new UCtrlBuyFuelForecast(lMYB);
                uCtrlBuyFuelForecast.OnSelected += new UCtrlBuyFuelForecast.Selected(uCtrlBuyFuelForecast_OnSelected);
                flowLayoutPanel1.Controls.Add(uCtrlBuyFuelForecast);
            }
        }

        void uCtrlBuyFuelForecast_OnSelected(CmcsLMYB lMYB)
        {
            this.Output = lMYB;
            this.DialogResult = DialogResult.OK;
        }
    }
}
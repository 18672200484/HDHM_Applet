using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar; 
using CMCS.Common.DAO;
using CMCS.Common.Entities.CarTransport;
using CMCS.CarTransport.DAO;
using CMCS.Common.Enums;

namespace CMCS.CarTransport.Queue.Frms
{
    public partial class FrmTransport_Confirm : DevComponents.DotNetBar.Metro.MetroForm
    {
        string autotruckId;

        string transportId;
        string carType;

        CommonDAO commonDAO = CommonDAO.GetInstance();

        public FrmTransport_Confirm(string transportId, string carType)
        {
            this.transportId = transportId;
            this.carType = carType;

            InitializeComponent();
        }

        private void FrmTransport_Confirm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.transportId)) return;

            if (this.carType == eCarType.入厂煤.ToString())
            {
                CmcsBuyFuelTransport transport = commonDAO.SelfDber.Get<CmcsBuyFuelTransport>(this.transportId);
                if (transport != null)
                {
                    this.autotruckId = transport.AutotruckId;

                    txtSerialNumber.Text = transport.SerialNumber;
                    txtCarNumber.Text = transport.CarNumber;
                    txtInFactoryTime.Text = transport.InFactoryTime.ToString("yyyy-MM-dd HH:mm");
                }
            }
            else if (this.carType == eCarType.其他物资.ToString())
            {
                CmcsGoodsTransport transport = commonDAO.SelfDber.Get<CmcsGoodsTransport>(this.transportId);
                if (transport != null)
                {
                    this.autotruckId = transport.AutotruckId;

                    txtSerialNumber.Text = transport.SerialNumber;
                    txtCarNumber.Text = transport.CarNumber;
                    txtInFactoryTime.Text = transport.InFactoryTime.ToString("yyyy-MM-dd HH:mm");
                }
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            CarTransportDAO.GetInstance().ChangeUnFinishTransportToInvalid(this.autotruckId);
            this.DialogResult = DialogResult.Yes;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
}
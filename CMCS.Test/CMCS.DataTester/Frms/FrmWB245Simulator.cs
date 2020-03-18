using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.DataTester.DAO;
using System.IO.Ports;

namespace CMCS.DataTester.Frms
{
    public partial class FrmWB245Simulator : Form
    {
        private SerialPort serialPort = new SerialPort();

        DataTesterDAO dataTesterDAO = DataTesterDAO.GetInstance();

        public FrmWB245Simulator()
        {
            InitializeComponent();
        }

        private void FrmWBSimulator_Load(object sender, EventArgs e)
        {
            cmbCom.SelectedIndex = 0;
        }

        private void FrmWBSimulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) btnColseCom_Click(null, null);
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = cmbCom.Text;
                serialPort.BaudRate = 9600;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;
                serialPort.Parity = Parity.None;
                serialPort.ReceivedBytesThreshold = 1;
                serialPort.RtsEnable = true;
                serialPort.Open();

                timer1.Start();

                btnOpenCom.Enabled = false;
                btnCloseCom.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnColseCom_Click(object sender, EventArgs e)
        {
            try
            {
                timer1.Stop();

                serialPort.Close();

                btnOpenCom.Enabled = true;
                btnCloseCom.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败：" + ex.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        /// <summary>
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) return;

            List<byte> datas = new List<byte>();
            datas.Add(0x02);
            datas.Add(0x31);
            datas.Add(0x30);

            decimal weight = 0;
            if (!decimal.TryParse(txtWeight.Text, out weight)) return;
            if (weight < 0 || weight > 150) return;

            string a = weight.ToString("F3").Replace(".", "").PadLeft(7, ' ');
            for (int i = 0; i < a.Length; i++)
            {
                char t = a[i];
                datas.Add((byte)Convert.ToInt16(t));
            }

            datas.Add(0x20);
            datas.Add(0x20);
            datas.Add(0x20);
            datas.Add(0x20);
            datas.Add(0x30);
            datas.Add(0x30);
            datas.Add(0x0D);
            datas.Add(0x1E);

            serialPort.Write(datas.ToArray(), 0, datas.Count);
        }
    }
}

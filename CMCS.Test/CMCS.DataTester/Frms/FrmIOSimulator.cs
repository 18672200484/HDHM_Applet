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
    public partial class FrmIOSimulator : Form
    {
        private SerialPort serialPort = new SerialPort();

        DataTesterDAO dataTesterDAO = DataTesterDAO.GetInstance();

        public FrmIOSimulator()
        {
            InitializeComponent();
        }

        private void FrmIOSimulator_Load(object sender, EventArgs e)
        {
            cmbCom.SelectedIndex = 0;
            serialPort.DataReceived += new SerialDataReceivedEventHandler(serialPort_DataReceived);
        }

        private void FrmIOSimulator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serialPort.IsOpen) btnColseCom_Click(null, null);
        }

        private void btnOpenCom_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName =  cmbCom .Text;
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

        /// <summary>
        /// 临时数据
        /// </summary>
        private List<byte> ReceiveList = new List<byte>();

        void serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (serialPort.IsOpen)
            {
                int bytesToRead = serialPort.BytesToRead;
                byte[] buffer = new byte[bytesToRead];
                serialPort.Read(buffer, 0, bytesToRead);

                try
                {
                    for (int i = 0; i < bytesToRead; i++)
                    {
                        if (buffer[i] == 0x4f) this.ReceiveList.Clear();

                        this.ReceiveList.Add(buffer[i]);

                        if (buffer[i] == 0x29 && this.ReceiveList.Count == 8)
                        {
                            string port = Convert.ToChar(this.ReceiveList[4]).ToString();
                            this.InvokeEx(() =>
                            {
                                Button btn = flpanOutput.Controls.OfType<Button>().FirstOrDefault(a => a.Tag.ToString() == port);
                                if (btn != null) btn.BackColor = (this.ReceiveList[6] == 0x31) ? Color.Green : Color.Red;
                            });
                        }
                    }
                }
                catch { }
                finally { this.ReceiveList.Clear(); }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialPort.IsOpen) return;

            List<byte> datas = new List<byte>();
            datas.Add(0x49);
            datas.Add(0x28);
            datas.Add(0x49);
            datas.Add(0x30);
            datas.Add(0x2c);
            foreach (Button btn in flpanInput.Controls.OfType<Button>())
            {
                datas.Add((btn.Tag != null && btn.Tag.ToString() == "1") ? (byte)0x31 : (byte)0x30);
            }
            datas.Add(0x29);

            serialPort.Write(datas.ToArray(), 0, datas.Count);
        }

        private void btnInput_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Tag == null || btn.Tag.ToString() == "1")
            {
                btn.Tag = "0";
                btn.BackColor = Color.Red;
            }
            else
            {
                btn.Tag = "1";
                btn.BackColor = Color.Green;
            }
        }
    }
}

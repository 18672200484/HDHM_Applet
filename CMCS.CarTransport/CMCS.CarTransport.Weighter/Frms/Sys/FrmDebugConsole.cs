using System;
using System.Windows.Forms;
//
using CMCS.CarTransport.Weighter.Core;
using CMCS.CarTransport.Weighter.Enums;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Weighter.Frms.Sys
{
	/// <summary>
	/// �����������̨
	/// </summary>
	public partial class FrmDebugConsole : DevComponents.DotNetBar.Metro.MetroForm
	{
		private static FrmDebugConsole instance;

		public static FrmDebugConsole GetInstance()
		{
			if (instance == null || instance.IsDisposed)
			{
				instance = new FrmDebugConsole();
			}

			return instance;
		}

		private FrmDebugConsole()
		{
			InitializeComponent();
		}

		private void FrmDebugConsole_Load(object sender, EventArgs e)
		{
			cmbPassWay.Items.Add(new DataItem("���ϰ�", "���ϰ�", eDirection.Way1));
			cmbPassWay.Items.Add(new DataItem("���ϰ�", "���ϰ�", eDirection.Way2));
			cmbPassWay.SelectedIndex = 0;
		}

		public void Output(string message)
		{
			try
			{
				rtxtOutput.AppendText(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + " - " + message + Environment.NewLine);
				rtxtOutput.ScrollToCaret();
			}
			catch { }
		}

		/// <summary>
		/// ģ��ˢ��
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btnSubmit_Click(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(txtVoucher.Text.Trim()))
			{
				MessageBoxEx.Show("�����복�ƺ�\\��ǩ�ţ�", "��ʾ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			FrmWeighter.passCarQueuer.Enqueue((eDirection)(cmbPassWay.SelectedItem as DataItem).Data, txtVoucher.Text.Trim());
			Output("ģ��������" + txtVoucher.Text.Trim() + "  " + cmbPassWay.Text);
		}
	}
}
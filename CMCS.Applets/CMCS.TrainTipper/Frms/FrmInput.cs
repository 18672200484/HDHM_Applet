using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;

namespace CMCS.TrainTipper.Frms
{
    public partial class FrmInput : DevComponents.DotNetBar.Metro.MetroForm
    {
        public string Input
        {
            get { return txtInput.Text; }
            set { txtInput.Text = value; }
        }

        Func<string, bool> verifyFunc;

        public FrmInput(string waterMarkeText, Func<string, bool> verifyFunc)
        {
            InitializeComponent();

            this.Input = null;
            this.txtInput.WatermarkText = waterMarkeText;
            this.verifyFunc = verifyFunc;
        }

        /// <summary>
        /// Ã·Ωª
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (!verifyFunc(txtInput.Text)) return;

            this.DialogResult = DialogResult.OK;
        }
    }
}
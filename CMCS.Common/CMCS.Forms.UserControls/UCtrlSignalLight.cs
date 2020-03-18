using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CMCS.Forms.UserControls
{
    /// <summary>
    /// CMCS 状态信号灯控件
    /// </summary>
    public partial class UCtrlSignalLight : UserControl
    {
        private Color lightColor = Color.Gray;
        /// <summary>
        /// 显示颜色
        /// </summary>
        [Browsable(true)]
        [Category("外观")]
        [Description("显示颜色")]
        public Color LightColor
        {
            get { return lightColor; }
            set { lightColor = value; this.Refresh(); }
        }

        public UCtrlSignalLight()
        {
            InitializeComponent();
        }

        private void UCtrlSignalLight_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                e.Graphics.FillEllipse(new SolidBrush(this.lightColor), this.ClientRectangle);
            }
            catch { }
        }
    }
}

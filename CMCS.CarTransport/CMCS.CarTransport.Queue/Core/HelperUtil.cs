using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;
using DevComponents.Editors;
using DevComponents.DotNetBar;

namespace CMCS.CarTransport.Queue.Core
{
    public static class HelperUtil
    {
        public static void ControlReadOnly(Control ctl, bool isReadOnly)
        {
            foreach (Control item in ctl.Controls)
            {
                if (item.Controls.Count > 0)
                {
                    ControlReadOnly(item, isReadOnly);
                }
                else if (item is TextBoxX)
                {
                    ((TextBoxX)item).ReadOnly = isReadOnly;
                }
                else if (item is IntegerInput)
                {
                    ((IntegerInput)item).IsInputReadOnly = isReadOnly;
                }
                else if (item is DoubleInput)
                {
                    ((DoubleInput)item).IsInputReadOnly = isReadOnly;
                }
                else if (item is CheckBoxX)
                {
                    ((CheckBoxX)item).Enabled = !isReadOnly;
                }
                else if (item is ComboBoxEx)
                {
                    ((ComboBoxEx)item).DisabledBackColor = ((ComboBoxEx)item).BackColor;
                    ((ComboBoxEx)item).DisabledForeColor = ((ComboBoxEx)item).ForeColor;
                    ((ComboBoxEx)item).Enabled = !isReadOnly;
                }
                else if (item is ButtonX)
                {
                    ((ButtonX)item).Enabled = !isReadOnly;
                }
            }
        }
    }
}

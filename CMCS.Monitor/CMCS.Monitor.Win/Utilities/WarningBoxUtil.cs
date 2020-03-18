using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using DevComponents.DotNetBar.Controls;

namespace CMCS.Monitor.Win.Utilities
{
    /// <summary>
    /// 提示框帮助类
    /// </summary>
    public class WarningBoxUtil
    {
        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="box"></param>
        /// <param name="second">存在时长 等于0时，则永不消失。 单位（秒）</param>
        public static void ShowWarningBox(string info, WarningBox box, string color)
        {
            box.Text = "  <font color='" + color + "'>" + info + "</font>";
            box.Visible = true;
        }

        /// <summary>
        /// 显示错误信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="box"></param> 
        public static void ShowError(string info, WarningBox box)
        {
            ShowWarningBox(info, box, "red");
        }

        /// <summary>
        /// 显示提示信息
        /// </summary>
        /// <param name="info"></param>
        /// <param name="box"></param> 
        public static void ShowInfo(string info, WarningBox box)
        {
            ShowWarningBox(info, box, "green");
        }
    }
}

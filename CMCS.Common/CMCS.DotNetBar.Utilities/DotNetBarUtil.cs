using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevComponents.DotNetBar;

namespace CMCS.DotNetBar.Utilities
{
    public class DotNetBarUtil
    {
        #region 国际化

        /// <summary>
        /// 初始化国际化
        /// </summary>
        public static void InitLocalization()
        {
            LocalizationKeys.LocalizeString += new DotNetBarManager.LocalizeStringEventHandler(LocalizationKeys_LocalizeString);
        }
        static void LocalizationKeys_LocalizeString(object sender, LocalizeEventArgs e)
        {
            if (e.Key == LocalizationKeys.MessageBoxCancelButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&取消";
            }
            else if (e.Key == LocalizationKeys.MessageBoxOkButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&确定";
            }
            else if (e.Key == LocalizationKeys.MessageBoxCloseButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&关闭";
            }
            else if (e.Key == LocalizationKeys.MessageBoxYesButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&是";
            }
            else if (e.Key == LocalizationKeys.MessageBoxNoButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&否";
            }
            else if (e.Key == LocalizationKeys.MessageBoxTryAgainButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&重试";
            }
            else if (e.Key == LocalizationKeys.MessageBoxIgnoreButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&忽略";
            }
            else if (e.Key == LocalizationKeys.MessageBoxHelpButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&帮助";
            }
            else if (e.Key == LocalizationKeys.MessageBoxContinueButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&继续";
            }
            else if (e.Key == LocalizationKeys.MessageBoxAbortButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&中止";
            }
            else if (e.Key == LocalizationKeys.MessageBoxRetryButton)
            {
                e.Handled = true;
                e.LocalizedValue = "&重试";
            }
        } 

        #endregion
    }
}

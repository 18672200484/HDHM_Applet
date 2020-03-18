using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue;

namespace CMCS.Monitor.Win.CefGlue
{
    /// <summary>
    /// 右键菜单
    /// </summary>
    public class CefMenuHandler : CefContextMenuHandler
    {
        protected override void OnBeforeContextMenu(CefBrowser browser, CefFrame frame, CefContextMenuParams state, CefMenuModel model)
        {
            //base.OnBeforeContextMenu(browser, frame, state, model);
            model.Clear();
        }

        protected override bool OnContextMenuCommand(CefBrowser browser, CefFrame frame, CefContextMenuParams state, int commandId, CefEventFlags eventFlags)
        {
            //return base.OnContextMenuCommand(browser, frame, state, commandId, eventFlags);
            return false;
        }

        protected override void OnContextMenuDismissed(CefBrowser browser, CefFrame frame)
        {
            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xilium.CefGlue.WindowsForms;
using System.ComponentModel;

namespace CMCS.Monitor.Win.UserControls
{
    public class CefWebBrowserEx : CefWebBrowser
    {
        [Browsable(false)]
        public CefWebClient WebClient { get; set; }

        protected override CefWebClient CreateWebClient()
        {
            return this.WebClient ?? base.CreateWebClient();
        }
    }
}

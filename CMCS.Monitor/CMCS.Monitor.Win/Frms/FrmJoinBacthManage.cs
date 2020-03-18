using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common.Entities.Inf;
using CMCS.Monitor.DAO;
using CMCS.Monitor.Win.Core;
using CMCS.Monitor.Win.Html;
using DevComponents.DotNetBar.Metro;
using Xilium.CefGlue.WindowsForms;
using CMCS.Common.Entities.BaseInfo;

namespace CMCS.Monitor.Win.Frms
{
    public partial class FrmJoinBacthManage : MetroForm
    {
        /// <summary>
        /// 窗体唯一标识符
        /// </summary>
        public static string UniqueKey = "FrmJoinBacthManage";

        CefWebBrowser cefWebBrowser = new CefWebBrowser();

        public FrmJoinBacthManage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void FormInit()
        {
#if DEBUG
            gboxTest.Visible = true;
#else
            gboxTest.Visible = false;
#endif
            cefWebBrowser.StartUrl = SelfVars.Url_JoinBacthManage;
            cefWebBrowser.Dock = DockStyle.Fill;
            cefWebBrowser.LoadEnd += new EventHandler<LoadEndEventArgs>(cefWebBrowser_LoadEnd);
            panWebBrower.Controls.Add(cefWebBrowser);
           
        }

        void cefWebBrowser_LoadEnd(object sender, LoadEndEventArgs e)
        {
            timer1.Enabled = true;
        }

        private void FrmAssayManage_Load(object sender, EventArgs e)
        {
            FormInit();
        }
        /// <summary>
        /// 请求数据
        /// </summary>
        void RequestData()
        {
            CommonDAO commonDAO = CommonDAO.GetInstance();

            string value = string.Empty, machineCode = string.Empty;
            List<HtmlDataItem> datas = new List<HtmlDataItem>();
            List<InfEquInfHitch> equInfHitchs = new List<InfEquInfHitch>();

            #region 化验室网络管理
            datas.Clear();
            machineCode = GlobalVars.MachineCode_JoinBacth;

            List<CmcsSignalData> list =  commonDAO.GetInfTbqcjxcyPackingBatchCoord();
            string str = "";
            foreach (CmcsSignalData item in list)
	        {
                if (item.Remark == "已使用")
                {
                    str += item.SignalName + "," + item.Remark + "," + item.SignalValue + "," + dataFormat(item.UpdateTime) + "|";
                }
                else
                {
                    str += item.SignalName + "," + item.Remark + "," + item.SignalValue + ", |";
                }
	        }
            datas.Add(new HtmlDataItem("样品状态", str.TrimEnd('|'), eHtmlDataItemType.svg_text));

            DataTable dt = commonDAO.GetSqlDatas(string.Format("select t.machinecode,t.hitchtime,t.hitchdescribe from InfTbEquinFhitch t where t.machinecode = '{0}' and to_char(t.hitchtime,'yyyy-mm-dd') =  to_char(sysdate,'yyyy-mm-dd') ", machineCode));
            str = "";
            foreach (DataRow dr in dt.Rows)
            {
                str += dr["machinecode"] + ",";
                str += dataFormat(Convert.ToDateTime(dr["hitchtime"])) + ",";
                str += dr["hitchdescribe"] + "|";
            }

            datas.Add(new HtmlDataItem("异常信息", str.TrimEnd('|'), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("系统", commonDAO.GetSignalDataValue("矩阵合样归批机", "程序状态"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("X轴坐标", commonDAO.GetSignalDataValue("矩阵合样归批机", "X轴实时位置"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("Y轴坐标", commonDAO.GetSignalDataValue("矩阵合样归批机", "Y轴实时位置"), eHtmlDataItemType.svg_text));
            datas.Add(new HtmlDataItem("Z轴坐标", commonDAO.GetSignalDataValue("矩阵合样归批机", "Z轴实时位置"), eHtmlDataItemType.svg_text));

            #endregion

            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("requestData(" + Newtonsoft.Json.JsonConvert.SerializeObject(datas) + ");", "", 0);
        }

        private string dataFormat(DateTime dt)
        {
            string day = string.Empty;
            switch (dt.DayOfWeek.ToString())
            {
                case "Monday":
                    day = "星期一";
                    break;
                case "Tuesday":
                    day = "星期二";
                    break;
                case "Wednesday":
                    day = "星期三";
                    break;
                case "Thursday":
                    day = "星期四";
                    break;
                case "Friday": 
                     day = "星期五";
                    break;
                case "Saturday":
                    day = "星期六";
                    break;
                case "Sunday":
                    day = "星期日";
                    break;
            }
            string am = "上午";
            if (dt.Date.Hour > 12)
            {
                am = "下午";
            }
            return dt.ToString("yyyy/MM/dd " + day + am + " hh:mm:ss");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // 界面不可见时，停止发送数据
            if (!this.Visible) return;

            RequestData();
        }

        /// <summary>
        /// 刷新页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            cefWebBrowser.Browser.Reload();
        }

        private void btnRequestData_Click(object sender, EventArgs e)
        {
            RequestData();
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            // 发送到页面
            cefWebBrowser.Browser.GetMainFrame().ExecuteJavaScript("testColor();", "", 0);
        }
    }
}

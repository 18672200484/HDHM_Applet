using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CMCS.DapperDber.Dbs.AccessDb;

namespace CMCS.ADGS.Core.CustomGraber.KaiYuan
{
    /// <summary>
    /// 长沙开元.水分仪 型号：5E-MW6510 数据提取类
    /// </summary>
    public class Sfy_5EMW6510_Graber : AssayGraber
    {
        /// <summary>
        /// 提取范围 单位：天
        /// </summary>
        public int DayRange
        {
            get { return Convert.ToInt32(Parameters["DayRange"]); }
        } 

        public override System.Data.DataTable ExecuteGrab()
        {
            return new AccessDapperDber(this.ConnStr).ExecuteDataTable("select * from TestResult where BeginDate > #" + DateTime.Now.AddDays(-DayRange).ToString("yyyy-MM-dd") + "#");
        }
    }
}

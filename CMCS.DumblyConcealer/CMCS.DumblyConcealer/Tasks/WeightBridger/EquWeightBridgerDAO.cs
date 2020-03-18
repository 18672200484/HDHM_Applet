using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Enums;
using CMCS.DapperDber.Dbs.AccessDb;
using CMCS.DumblyConcealer.Enums;
using CMCS.Common.Entities.TrainInFactory;

namespace CMCS.DumblyConcealer.Tasks.WeightBridger
{
    public class EquWeightBridgerDAO
    {
        private static EquWeightBridgerDAO instance;

        public static EquWeightBridgerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new EquWeightBridgerDAO();
            }
            return instance;
        }

        private EquWeightBridgerDAO()
        {

        }

        /// <summary>
        /// 同步轨道衡过衡数据，并在火车出厂后将皮重回写
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SyncLwCarsInfo(Action<string, eOutputType> output)
        {
            int res = 0;
            DataTable result = getData(DcDbers.GetInstance().WeightBridger_Dber1);
            foreach (DataRow row in result.Rows)
            {
                string pKId = getDateTime(row["时间"].ToString()) + "-" + row["车号"].ToString(); //时间+车号组装成唯一标识
                CmcsTrainWeightRecord trainWeightRecord = Dbers.GetInstance().SelfDber.Entity<CmcsTrainWeightRecord>("where PKID=:PKID", new { PKID = pKId });
                if (trainWeightRecord == null)
                {
                    res += Dbers.GetInstance().SelfDber.Insert<CmcsTrainWeightRecord>(
                        new CmcsTrainWeightRecord
                        {
                            PKID = pKId,
                            OrderNumber = Convert.ToInt32(row["序号"].ToString()),
                            SupplierName = row["供煤单位"].ToString(),
                            MineName = row["矿点"].ToString(),
                            FuelKind = row["煤种"].ToString(),
                            StationName = row["发站"].ToString(),
                            MachineCode = row["设备编号"].ToString(),
                            TrainNumber = row["车号"].ToString(),
                            TrainType = row["车型"].ToString(),
                            TicketWeight = Convert.ToDecimal(row["票重"]),
                            GrossWeight = Convert.ToDecimal(row["毛重"]),
                            SkinWeight = Convert.ToDecimal(row["皮重"]),
                            StandardWeight = Convert.ToDecimal(row["净重"]),
                            Speed = Convert.ToDecimal(row["车速"]),
                            MesureMan = row["过衡人"].ToString(),
                            ArriveTime = Convert.ToDateTime(getDateTime(row["入厂时间"].ToString())),
                            GrossTime = Convert.ToDateTime(getDateTime(row["毛重时间"].ToString())),
                            SkinTime = Convert.ToDateTime(getDateTime(row["皮重时间"].ToString())),
                            LeaveTime = Convert.ToDateTime(getDateTime(row["出厂时间"].ToString())),
                            UnloadTime = Convert.ToDateTime(getDateTime(row["卸车时间"].ToString())),
                            TrainTipperMachineCode = row["翻车机编号"].ToString(),
                            IsTurnover = row["翻车标识"].ToString(),
                            DataFlag=0
                        }
                  );
                }
                else
                {
                    trainWeightRecord.OrderNumber = Convert.ToInt32(row["序号"].ToString());
                    if (!String.IsNullOrEmpty(row["车号"].ToString())) trainWeightRecord.TrainNumber = row["车号"].ToString();

                    trainWeightRecord.SupplierName = row["供煤单位"].ToString();
                    trainWeightRecord.MineName = row["矿点"].ToString();
                    trainWeightRecord.FuelKind = row["煤种"].ToString();
                    trainWeightRecord.StationName = row["发站"].ToString();
                    trainWeightRecord.MachineCode = row["设备编号"].ToString();
                    trainWeightRecord.TrainType = row["车型"].ToString();
                    trainWeightRecord.TicketWeight = Convert.ToDecimal(row["票重"]);
                    trainWeightRecord.GrossWeight = Convert.ToDecimal(row["毛重"]);
                    trainWeightRecord.SkinWeight = Convert.ToDecimal(row["皮重"]);
                    trainWeightRecord.StandardWeight = Convert.ToDecimal(row["净重"]);
                    trainWeightRecord.Speed = Convert.ToDecimal(row["车速"]);
                    trainWeightRecord.MesureMan = row["过衡人"].ToString();
                    trainWeightRecord.ArriveTime = Convert.ToDateTime(getDateTime(row["入厂时间"].ToString()));
                    trainWeightRecord.GrossTime = Convert.ToDateTime(getDateTime(row["毛重时间"].ToString()));
                    trainWeightRecord.SkinTime = Convert.ToDateTime(getDateTime(row["皮重时间"].ToString()));
                    trainWeightRecord.LeaveTime = Convert.ToDateTime(getDateTime(row["出厂时间"].ToString()));
                    trainWeightRecord.UnloadTime = Convert.ToDateTime(getDateTime(row["卸车时间"].ToString()));
                    trainWeightRecord.TrainTipperMachineCode = row["翻车机编号"].ToString();
                    trainWeightRecord.IsTurnover = row["翻车标识"].ToString();
                    trainWeightRecord.DataFlag = 0;
                    res += Dbers.GetInstance().SelfDber.Update<CmcsTrainWeightRecord>(trainWeightRecord);
                }
                if (res > 0 && String.IsNullOrEmpty(row["车号"].ToString()))
                {
                    CommonDAO.GetInstance().SaveSysMessage(eMessageType.轨道衡.ToString(), "车号为空请补录!", eMessageType.轨道衡.ToString());
                }
            }
            output(string.Format("同步轨道衡数据 {0} 条（第三方 > 集中管控）", res), eOutputType.Normal);
            return res;
        }

        /// <summary>
        /// 默认取当前月份轨道衡的数据
        /// </summary>
        /// <param name="argConn">Access数据库连接串</param>
        /// <returns></returns>
        private DataTable getData(AccessDapperDber argConn)
        {
            DataTable dt = new DataTable();
            int tempMonth = DateTime.Now.Month;//取当前日期的月份
            int tempDay = -CommonDAO.GetInstance().GetAppletConfigInt32("轨道衡数据读取天数");
            string sql = string.Format(@"select * from {0} where 发货单位 <> '' and 收货单位 <> '' and 时间 > '{1}'", tempMonth,
                getCurrentTime(DateTime.Now.AddDays(tempDay)));
            dt = argConn.ExecuteDataTable(sql);
            return dt;
        }

        /// <summary>
        /// 根据程序读取到的时间，返回一个标准的日期格式数据
        /// </summary>
        /// <param name="argTime">读取日期的格式必须是"********_******"</param>
        /// <returns></returns>
        private string getDateTime(string argTime)
        {
            StringBuilder sb = new StringBuilder();
            string result = string.Empty;
            Exception tempE = null;
            try
            {
                string[] ss = argTime.Split(new char[] { '_' });
                if (ss.Length == 2)
                {
                    //1.转换出年月日，按照"{年}-{月}-{日}格式划分"
                    string tempYear = ss[0].Substring(0, 4);
                    string tempMonth = ss[0].Substring(ss[0].Length - 4).Substring(0, 2);
                    string tempDay = ss[0].Substring(ss[0].Length - 2);
                    sb.Append(string.Format(@"{0}-{1}-{2} ", tempYear, tempMonth, tempDay));
                    //2.转换时分秒，按照"{时}：{分}：{秒}格式划分"
                    string tempHour = ss[1].Substring(0, 2);
                    string tempSecond = ss[1].Substring(0, 4).Substring(2);
                    string tempMinutes = ss[1].Substring(ss[1].Length - 2);
                    sb.Append(string.Format(@"{0}:{1}:{2}", tempHour, tempSecond, tempMonth));
                    result = sb.ToString();
                }
            }
            catch (Exception e)
            {
                tempE = e;
            }
            finally
            {
                if (tempE != null)
                {
                    result = "";
                }
            }
            return result;
        }

        /// <summary>
        /// 转换当前日期格式，按照小程序中读取的格式转换“********_******”
        /// </summary>
        /// <returns></returns>
        private string getCurrentTime(DateTime argTime)
        {
            string str = string.Empty;
            string tempYear = argTime.Year.ToString();
            string tempMonth = argTime.Month < 10 ? "0" + argTime.Month : argTime.Month.ToString();
            string tempDay = argTime.Day < 10 ? "0" + argTime.Day : argTime.Day.ToString();
            string tempHour = argTime.Hour < 10 ? "0" + argTime.Hour : argTime.Hour.ToString();
            str = string.Format(@"{0}{1}{2}_{3}{4}{5}", tempYear, tempMonth, tempDay, tempHour, argTime.Minute, argTime.Second);
            return str;
        }
    }
}

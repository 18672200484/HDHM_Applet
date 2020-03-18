using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common;
using CMCS.Common.Entities.Sys;
using CMCS.DumblyConcealer.Tasks.CarSynchronous.Enums;
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Fuel;
using CMCS.DumblyConcealer.Enums;
using CMCS.Common.DAO;
using CMCS.DapperDber.Dbs.AccessDb;
using System.Data;
using CMCS.DumblyConcealer.Tasks.DataHandler.Entities;

namespace CMCS.DumblyConcealer.Tasks.CarSynchronous
{
    /// <summary>
    /// 综合事件处理
    /// </summary>
    public class DataHandlerDAO
    {
        private static DataHandlerDAO instance;

        public static DataHandlerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new DataHandlerDAO();
            }
            return instance;
        }

        CommonDAO commonDAO = CommonDAO.GetInstance();

        private DataHandlerDAO()
        { }

        /// <summary>
        /// 将汽车入厂煤运输记录同步到批次明细中
        /// </summary>
        /// <param name="transportId">汽车入厂煤运输记录Id</param>
        /// <returns></returns>
        public void SyncToBatch(Action<string, eOutputType> output)
        {
            int res = 0;
            bool succes = false;

            //已完结的有效数据
            foreach (CmcsBuyFuelTransport transport in commonDAO.SelfDber.Entities<CmcsBuyFuelTransport>("where IsUse=1 and IsFinish=1 and IsSyncBatch=0 "))
            {
                if (transport.TareTime == null) continue;

                CmcsInFactoryBatch batch = commonDAO.SelfDber.Entity<CmcsInFactoryBatch>("where CreationTime like '%" + transport.InFactoryTime.ToString("yyyy-MM-dd") + "%' and SupplierId=:SupplierId and MineId=:MineId and FuelKindId=:FuelKindId and IsDeleted=0",
                    new { SupplierId = transport.SupplierId, MineId = transport.MineId, FuelKindId = transport.FuelKindId });
                if (batch == null) continue;

                CmcsTransport truck = commonDAO.SelfDber.Entity<CmcsTransport>("where PKID=:PKID and IsDeleted=0", new { PKID = transport.Id });
                if (truck != null)
                {
                    truck.TransportNo = transport.CarNumber;
                    truck.LastModificAtionTime = transport.LastModificAtionTime;
                    truck.InfactoryTime = transport.InFactoryTime;
                    truck.ArriveDate = transport.GrossTime;
                    truck.TareDate = transport.TareTime;
                    truck.OutfactoryTime = transport.OutFactoryTime;
                    truck.TicketQty = transport.TicketWeight;
                    truck.GrossQty = transport.GrossWeight;
                    truck.SkinQty = transport.TareWeight;
                    truck.SuttleQty = transport.SuttleWeight;
                    truck.KgQty = transport.DeductWeight;
                    truck.CheckQty = transport.SuttleWeight - transport.DeductWeight;
                    truck.MarginQty = transport.SuttleWeight - transport.DeductWeight - transport.TicketWeight;
                    truck.InFactoryBatchId = batch.Id;
                    truck.PKID = transport.Id;
                    truck.DataFrom = "汽车智能化";
                    succes = commonDAO.SelfDber.Update(truck) > 0;
                }
                else
                {
                    truck = new CmcsTransport()
                    {
                        TransportNo = transport.CarNumber,
                        LastModificAtionTime = transport.LastModificAtionTime,
                        InfactoryTime = transport.CreationTime,
                        ArriveDate = transport.GrossTime,
                        TareDate = transport.TareTime,
                        OutfactoryTime = transport.OutFactoryTime,
                        TicketQty = transport.TicketWeight,
                        GrossQty = transport.GrossWeight,
                        SkinQty = transport.TareWeight,
                        SuttleQty = transport.SuttleWeight,
                        KgQty = transport.DeductWeight,
                        CheckQty = transport.SuttleWeight - transport.DeductWeight,
                        MarginQty = transport.SuttleWeight - transport.DeductWeight - transport.TicketWeight,
                        InFactoryBatchId = batch.Id,
                        PKID = transport.Id,
                        DataFrom = "汽车智能化"
                    };

                    succes = commonDAO.SelfDber.Insert(truck) > 0;
                }

                if (succes)
                {
                    //更新智能化运输记录
                    transport.IsSyncBatch = 1;
                    transport.InFactoryBatchId = batch.Id;
                    Dbers.GetInstance().SelfDber.Update<CmcsBuyFuelTransport>(transport);

                    // 更新批次的量 
                    List<CmcsTransport> listTransport = commonDAO.SelfDber.Entities<CmcsTransport>("where InFactoryBatchId=:InFactoryBatchId and IsDeleted=0", new { InFactoryBatchId = batch.Id });

                    batch.SuttleQty = listTransport.Sum(a => a.SuttleQty);
                    batch.TicketQty = listTransport.Sum(a => a.TicketQty);
                    batch.CheckQty = listTransport.Sum(a => a.CheckQty);
                    batch.MarginQty = listTransport.Sum(a => a.MarginQty);
                    batch.TransportNumber = listTransport.Count;

                    Dbers.GetInstance().SelfDber.Update<CmcsInFactoryBatch>(batch);

                    res++;
                }

            }

            output(string.Format("同步批次明细数据 {0} 条", res), eOutputType.Normal);
        }

        #region 同步门禁数据

        /// <summary>
        /// 同步门禁数据
        /// </summary>
        /// <param name="output"></param>
        public void SyncDoorData(Action<string, eOutputType> output, AccessDapperDber doorDapperDber)
        {
            int res = 0;

            string sql = " select * from acc_monitor_log where time>#2018-08-08#";
            sql += " order by time";
            DataTable dtNum = doorDapperDber.ExecuteDataTable(sql);

            if (dtNum.Rows.Count > 0)
            {
                for (int i = 0; i < dtNum.Rows.Count; i++)
                {
                    string id = dtNum.Rows[i]["id"].ToString();
                    string userId = dtNum.Rows[i]["pin"].ToString();
                    string deviceId = dtNum.Rows[i]["device_id"].ToString();

                    string consumerName = GetConsumer(userId, doorDapperDber);
                    string doorName = GetMachine(deviceId, doorDapperDber);

                    if (string.IsNullOrEmpty(consumerName)) continue;
                    if (string.IsNullOrEmpty(doorName)) continue;

                    CmcsGuardInfo entity = Dbers.GetInstance().SelfDber.Entity<CmcsGuardInfo>("where NId=:NId", new { NId = id });
                    if (entity == null)
                    {
                        entity = new CmcsGuardInfo()
                        {
                            DataFrom = "智能化",
                            F_ConsumerId = userId,
                            F_ConsumerName = consumerName,
                            F_InOut = "1",
                            F_ReaderId = deviceId,
                            F_ReaderName = doorName,
                            NId = id,
                            F_ReadDate = DateTime.Parse(dtNum.Rows[i]["time"].ToString())
                        };

                        res += Dbers.GetInstance().SelfDber.Insert(entity);
                    }
                }
            }
            output(string.Format("同步门禁数据{0}条", res), eOutputType.Normal);
        }

        //根据用户id得到用户名
        private string GetConsumer(string UserId, AccessDapperDber doorDapperDber)
        {
            string sql = " select name from userinfo where Badgenumber='" + UserId + "'";
            DataTable dt = doorDapperDber.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }

        private string GetMachine(string MachineId, AccessDapperDber doorDapperDber)
        {
            string sql = " select MachineAlias from Machines where id=" + MachineId + "";
            DataTable dt = doorDapperDber.ExecuteDataTable(sql);
            if (dt != null && dt.Rows.Count > 0)
            {
                return dt.Rows[0][0].ToString();
            }
            return "";
        }

        #endregion
    }
}

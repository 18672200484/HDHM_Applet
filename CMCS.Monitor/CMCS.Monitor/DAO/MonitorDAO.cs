using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using CMCS.Common;
//
using CMCS.Common.Entities;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.DapperDber.Util;

namespace CMCS.Monitor.DAO
{
    public class MonitorDAO
    {
        private static MonitorDAO instance;

        public static MonitorDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new MonitorDAO();
            }

            return instance;
        }

        private MonitorDAO()
        { }

        #region 公共采样机

        /// <summary>
        /// 获取采样机的集样罐清单
        /// </summary>
        /// <param name="machineCode">设备编号</param>
        /// <returns></returns>
        public List<InfEquInfSampleBarrel> GetEquInfSampleBarrels(string machineCode)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode order by BarrelType,BarrelNumber asc", new { MachineCode = machineCode });
        }

        /// <summary>
        /// 获取采样机的集样罐清单
        /// </summary>
        /// <param name="machineCode">设备编号</param>
        /// <param name="barreltype">样罐类型 底卸式 密码罐</param>
        /// <returns></returns>
        public List<InfEquInfSampleBarrel> GetEquInfSampleBarrels(string machineCode, string barreltype)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfEquInfSampleBarrel>("where MachineCode=:MachineCode and BarrelType=:BarrelType order by BarrelNumber asc", new { MachineCode = machineCode, BarrelType = barreltype });
        }

        /// <summary>
        /// 获取第三方设备故障信息
        /// </summary>
        /// <param name="machineCode">设备编号</param>
        /// <param name="dtStart">故障起始时间</param>
        /// <returns></returns>
        public List<InfEquInfHitch> GetEquInfHitchs(string machineCode, DateTime dtStart)
        {
            return Dbers.GetInstance().SelfDber.Entities<InfEquInfHitch>("where MachineCode=:MachineCode and HitchTime=:HitchTime order by BarrelNumber asc", new { MachineCode = machineCode, HitchTime = dtStart });
        }

        /// <summary>
        /// 根据批次id获取采样单明细
        /// </summary>
        /// <param name="batchId"></param>
        /// <returns></returns>
        public List<CmcsRCSampling> GetSamplings(string batchId)
        {
            return Dbers.GetInstance().SelfDber.Entities<CmcsRCSampling>("where InfactoryBatchId=:InfactoryBatchId order by SamplingDate asc", new { InfactoryBatchId = batchId });
        }
        #endregion

        #region 皮带采样机



        #endregion

        #region 翻车机

        /// <summary>
        /// 根据火车入厂记录Id获取煤种、供煤单位、发站、矿点等信息
        /// </summary>
        /// <param name="trainWeightRecord">CmcsTrainWeightRecord ID</param>
        /// <returns></returns>
        public DataTable GetInFactoryBatchInfoByTrainWeightRecordId(string trainWeightRecord)
        {
            return Dbers.GetInstance().SelfDber.ExecuteDataTable(string.Format(@"select s.name as SupplierName,m.name as MineName,fk.FuelName,si.name as StationName from cmcstbtrainweightrecord twr left join cmcstbtransport t on t.Pkid=twr.Id left join cmcstbinfactorybatch ifb on ifb.Id=t.Infactorybatchid left join fultbsupplier s on s.Id=ifb.supplierid left join fultbstationinfo si
on si.Id=ifb.stationid left join fultbmine m on m.Id=ifb.mineid left join fultbfuelkind fk on fk.Id=ifb.fuelkindid where t.id='{0}'", trainWeightRecord));
        }

        #endregion


    }
}

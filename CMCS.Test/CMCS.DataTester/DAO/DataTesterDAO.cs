using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using CMCS.Common.Entities;
using CMCS.Common.Enums;
using System.Data;
using CMCS.Common.Utilities;
using CMCS.DapperDber.Dbs.OracleDb;
using CMCS.Common;
using CMCS.Common.Entities.TrainInFactory;

namespace CMCS.DataTester.DAO
{
    /// <summary>
    /// 模拟测试数据生成
    /// </summary>
    public class DataTesterDAO
    {
        private static DataTesterDAO instance;

        public static DataTesterDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new DataTesterDAO();
            }

            return instance;
        }

        private DataTesterDAO()
        { }

        public OracleDapperDber GetDber()
        {
            return Dbers.GetInstance().SelfDber;
        }

        #region 火车进厂记录数据生成

        /// <summary>
        /// 火车进厂记录数据生成
        /// </summary>
        /// <param name="recordCount"></param>
        /// <param name="machineCode"></param>
        /// <param name="dtInFactoryTime"></param>
        /// <param name="supplierName"></param>
        /// <param name="mineName"></param>
        /// <param name="stationName"></param>
        /// <param name="fuelKindName"></param>
        /// <returns></returns>
        public bool CreateTrainWeightRecords(int recordCount, string machineCode, DateTime dtInFactoryTime, string supplierName, string mineName, string stationName, string fuelKindName)
        {
            for (int i = 0; i < recordCount; i++)
            {
                string id = Guid.NewGuid().ToString();

                CmcsTrainWeightRecord entity = new CmcsTrainWeightRecord
                {
                    Id = id,
                    PKID = id,
                    ArriveTime = dtInFactoryTime,
                    DataFlag = 0,
                    FuelKind = fuelKindName,
                    MachineCode = machineCode,
                    MesureMan = "无人值守",
                    MineName = mineName,
                    StationName = stationName,
                    SupplierName = supplierName,
                    TrainType = "C64",
                    TrainNumber = id.Substring(0, 8),
                    OrderNumber = i,
                    Speed = 0.6m,
                    GrossTime = dtInFactoryTime,
                    SkinTime = dtInFactoryTime.AddMinutes(5),
                    TicketWeight = 51,
                    GrossWeight = 70 + i / 10m,
                    SkinWeight = 20 + i / 10m,
                    StandardWeight = 50,
                    UnloadTime = dtInFactoryTime.AddMinutes(20),
                    LeaveTime = dtInFactoryTime.AddMinutes(25),
                    IsTurnover = eTrainTipperTurnoverStatus.待翻.ToString()
                };

                Dbers.GetInstance().SelfDber.Insert(entity);
            }

            return true;
        }

        /// <summary>
        /// 生成火车进厂记录的抓拍记录
        /// </summary>
        /// <param name="trainWeightRecord"></param>
        /// <returns></returns>
        public void CreateTrainWatch(CmcsTrainWeightRecord trainWeightRecord)
        {
            Dbers.GetInstance().SelfDber.Insert(new CmcsTrainWatch
            {
                OrderNumber = 0,
                CatchDest = "http://10.36.2.137/Pictures/1.jpg",
                CatchTime = trainWeightRecord.ArriveTime,
                CatchType = "车顶抓拍",
                TrainWeightRecordId = trainWeightRecord.Id
            });

            Dbers.GetInstance().SelfDber.Insert(new CmcsTrainWatch
            {
                OrderNumber = 1,
                CatchDest = "http://10.36.2.137/Pictures/2.jpg",
                CatchTime = trainWeightRecord.ArriveTime,
                CatchType = "侧面抓拍",
                TrainWeightRecordId = trainWeightRecord.Id
            });
        }

        /// <summary>
        /// 生成火车进厂记录的装车线记录
        /// </summary>
        /// <param name="trainWeightRecord"></param>
        /// <returns></returns>
        public void CreateTrainLine(CmcsTrainWeightRecord trainWeightRecord)
        {
            Dbers.GetInstance().SelfDber.Insert(new CmcsTrainLine
            {
                OrderNumber = 0,
                StartTime = trainWeightRecord.ArriveTime,
                EndTime = trainWeightRecord.ArriveTime.AddSeconds(10),
                Height = "5.1|5.7|5.5|5.8|5.5|5.5|5.8|5.8|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|5.5|",
                TrainWeightRecordId = trainWeightRecord.Id
            });
        }

        #endregion

        #region 车号识别数据生成

        /// <summary>
        /// 车号识别数据生成
        /// </summary>
        /// <param name="machineCode"></param>
        /// <param name="carNumber"></param>
        /// <param name="direction"></param>
        /// <returns></returns>
        public bool CreateTrainCarriagePass(string machineCode, string carNumber, string direction)
        {
            return Dbers.GetInstance().SelfDber.Insert(new CmcsTrainCarriagePass
            {
                DataFlag = 0,
                Direction = direction,
                MachineCode = machineCode,
                PassTime = DateTime.Now,
                TrainNumber = carNumber
            }) > 0;
        }

        #endregion
    }
}

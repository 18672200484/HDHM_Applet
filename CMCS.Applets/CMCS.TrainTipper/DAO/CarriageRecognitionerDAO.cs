using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Enums;
using CMCS.Common.Entities;
using CMCS.DapperDber.Util;
using CMCS.Common;
using CMCS.Common.Entities.TrainInFactory;

namespace CMCS.TrainTipper.DAO
{
    /// <summary>
    /// 火车车号识别业务
    /// </summary>
    public class CarriageRecognitionerDAO
    {
        private static CarriageRecognitionerDAO instance;

        public static CarriageRecognitionerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new CarriageRecognitionerDAO();
            }

            return instance;
        }

        private CarriageRecognitionerDAO()
        { }

        /// <summary>
        /// 保存新的车号识别记录
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <param name="trainNumber">车号</param>
        /// <param name="passTime">经过时间</param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
        public bool SaveTrainCarriagePass(string machineCode, string trainNumber, DateTime passTime, eTrainPassDirection direction)
        {
            return Dbers.GetInstance().SelfDber.Insert(new CmcsTrainCarriagePass
               {
                   DataFlag = 0,
                   Direction = direction.ToString(),
                   MachineCode = machineCode,
                   PassTime = passTime,
                   TrainNumber = trainNumber
               }) > 0;
        }

        /// <summary>
        /// 获取未处理的车号识别记录
        /// </summary>
        /// <param name="machineCode">设备编码</param>
        /// <param name="direction">方向</param>
        /// <returns></returns>
        public CmcsTrainCarriagePass GetUnHandleTrainCarriagePass(string machineCode, eTrainPassDirection direction)
        {
            return Dbers.GetInstance().SelfDber.Entity<CmcsTrainCarriagePass>("where MachineCode=:MachineCode and Direction=:Direction and DataFlag=0 order by CreationTime asc", new { MachineCode = machineCode, Direction = direction.ToString() });
        }

        /// <summary>
        /// 标记车号识别记录为已处理
        /// </summary>
        /// <param name="trainCarriagePassId">车号识别记录Id</param>
        public bool ChangeTrainCarriagePassToHandled(string trainCarriagePassId)
        {
            return Dbers.GetInstance().SelfDber.Execute("update " + EntityReflectionUtil.GetTableName<CmcsTrainCarriagePass>() + " set DataFlag=1 where Id=:Id", new { Id = trainCarriagePassId }) > 0;
        }

        /// <summary>
        /// 设置车号识别记录为已处理
        /// </summary>
        /// <param name="machineCode">车号识别设备编码</param>
        public void ChangeTrainCarriagePassToHandledByMachineCode(string machineCode)
        {
            Dbers.GetInstance().SelfDber.Execute("update " + EntityReflectionUtil.GetTableName<CmcsTrainCarriagePass>() + " set DataFlag=1 where MachineCode=:MachineCode", new { MachineCode = machineCode });
        }
    }
}

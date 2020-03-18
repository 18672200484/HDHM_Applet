using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.Common;
using CMCS.DapperDber.Util;
using CMCS.Common.DAO;
using CMCS.Common.Enums;
using CMCS.Common.Views;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.Common.Entities.Fuel;

namespace CMCS.TrainTipper.DAO
{
    /// <summary>
    /// 翻车机业务
    /// </summary>
    public class TrainTipperDAO
    {
        private static TrainTipperDAO instance;

        public static TrainTipperDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new TrainTipperDAO();
            }

            return instance;
        }

        private TrainTipperDAO()
        { }

        CommonDAO commonDAO = CommonDAO.GetInstance();

        /// <summary>
        /// 获取设置的翻车机
        /// </summary>
        /// <returns></returns>
        public List<CmcsCMEquipment> GetTrainTippers()
        {
            List<CmcsCMEquipment> res = new List<CmcsCMEquipment>();

            string machineCodes = commonDAO.GetAppletConfigString("翻车机编码");
            if (!string.IsNullOrEmpty(machineCodes))
            {
                foreach (string machineCode in machineCodes.Split('|'))
                {
                    CmcsCMEquipment eMEquipment = Dbers.GetInstance().SelfDber.Entity<CmcsCMEquipment>("where EquipmentCode=:EquipmentCode", new { EquipmentCode = machineCode });
                    if (eMEquipment != null) res.Add(eMEquipment);
                }
            }

            return res;
        }

        /// <summary>
        /// 获取指定入厂时间段的火车进厂队列详情视图
        /// </summary>
        /// <param name="trainTipperMachineCode">翻车机编码</param>
        /// <param name="startInfactoryTime">起始入厂时间</param>
        /// <param name="endInfactoryTime">结束入厂时间</param>
        /// <returns></returns>
        public List<View_TrainTipperQueue> GetView_TrainTipperQueue(string trainTipperMachineCode, DateTime startInfactoryTime, DateTime endInfactoryTime)
        {
            return Dbers.GetInstance().SelfDber.Entities<View_TrainTipperQueue>("where TSSIsdeleted=0 and TIsdeleted=0 and TSSDIsdeleted=0 and TrainTipperMachineCode=:TrainTipperMachineCode and InfactoryTime>=:StartInfactoryTime and InfactoryTime<:EndInfactoryTime order by OrderNumber asc", new { TrainTipperMachineCode = trainTipperMachineCode, StartInfactoryTime = startInfactoryTime, EndInfactoryTime = endInfactoryTime });
        }

        /// <summary>
        /// 根据采样方案Id获取火车进厂队列详情视图
        /// </summary>
        /// <param name="trainSampleSchemeId"></param>
        /// <returns></returns>
        public List<View_TrainTipperQueue> GetView_TrainTipperQueueBy(string trainSampleSchemeId)
        {
            return Dbers.GetInstance().SelfDber.Entities<View_TrainTipperQueue>("where TSSIsdeleted=0 and TIsdeleted=0 and TSSDIsdeleted=0 and TrainSampleSchemeId=:TrainSampleSchemeId order by OrderNumber asc", new { TrainSampleSchemeId = trainSampleSchemeId });
        }

        /// <summary>
        /// 改变火车入厂记录记录的翻车状态
        /// </summary>
        /// <param name="trainWeightRecordId">火车入厂记录Id</param>
        /// <param name="trainTipperTurnoverStatus">翻车状态</param>
        /// <returns></returns>
        public bool ChangeTrainWeightRecordIsTurnover(string trainWeightRecordId, eTrainTipperTurnoverStatus trainTipperTurnoverStatus)
        {
            CmcsTrainWeightRecord trainWeightRecord = Dbers.GetInstance().SelfDber.Get<CmcsTrainWeightRecord>(trainWeightRecordId);
            if (trainWeightRecord != null)
            {
                if (trainTipperTurnoverStatus == eTrainTipperTurnoverStatus.已翻)
                {
                    trainWeightRecord.UnloadTime = DateTime.Now;

                    // 修改批次明细的卸车时间
                    Dbers.GetInstance().SelfDber.Execute("update " + EntityReflectionUtil.GetTableName<CmcsTransport>() + " set UnloadTime=sysdate where PKID=:PKID", new { PKID = trainWeightRecord.Id });
                }

                trainWeightRecord.IsTurnover = trainTipperTurnoverStatus.ToString();
                return Dbers.GetInstance().SelfDber.Update(trainWeightRecord) > 0;
            }

            return false;
        }
    }
}

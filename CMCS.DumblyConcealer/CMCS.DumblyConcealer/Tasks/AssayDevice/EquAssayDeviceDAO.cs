using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.AssayDevice.Entities;
using CMCS.Common;
using CMCS.Common.Entities.AssayDevices;
using CMCS.Common.DAO;

namespace CMCS.DumblyConcealer.Tasks.AssayDevice
{
    public class EquAssayDeviceDAO
    {
        private static EquAssayDeviceDAO instance;

        public static EquAssayDeviceDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new EquAssayDeviceDAO();
            }
            return instance;
        }

        private EquAssayDeviceDAO()
        {

        }

        CommonDAO commonDAO = CommonDAO.GetInstance();

        #region 生成标准测硫仪数据
        /// <summary>
        /// 生成标准测硫仪数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SaveToSulfurAssay(Action<string, eOutputType> output, Int32 days)
        {
            int res = 0;
            // .测硫仪 型号：5E-8SAII
            foreach (CLY_5E8SAII entity in Dbers.GetInstance().SelfDber.Entities<CLY_5E8SAII>("where TESTTIME>= :TestTime and SYBH is not null", new { TestTime = DateTime.Now.AddDays(-days).Date }))
            {
                CmcsSulfurAssay item = Dbers.GetInstance().SelfDber.Entity<CmcsSulfurAssay>("where PKID=:PKID", new { PKID = entity.PKID });
                if (item == null)
                {
                    item = new CmcsSulfurAssay();
                    item.SampleNumber = entity.SYBH;
                    item.FacilityNumber = entity.MachineCode;
                    item.ContainerWeight = 0;
                    item.SampleWeight = entity.SYZL;
                    item.Stad = entity.KGJLHL;
                    item.AssayUser = "";
                    item.AssayTime = entity.TESTTIME;
                    item.OrderNumber = 0;
                    item.IsEffective = 0;
                    item.PKID = entity.PKID;

                    res += Dbers.GetInstance().SelfDber.Insert<CmcsSulfurAssay>(item);
                }
                else
                {
                    item.SampleNumber = entity.SYBH;
                    item.FacilityNumber = entity.MachineCode;
                    item.ContainerWeight = 0;
                    item.SampleWeight = entity.SYZL;
                    item.Stad = entity.KGJLHL;
                    item.AssayUser = "";
                    item.AssayTime = entity.TESTTIME;
                    item.OrderNumber = 0;

                    res += Dbers.GetInstance().SelfDber.Update<CmcsSulfurAssay>(item);
                }
            }

            output(string.Format("生成标准测硫仪数据 {0} 条", res), eOutputType.Normal);

            return res;
        }
        #endregion

        #region 生成标准量热仪数据
        /// <summary>
        /// 生成标准量热仪数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SaveToHeatAssay(Action<string, eOutputType> output, Int32 days)
        {
            int res = 0;

            // .量热仪 型号：5E-C5500A双控
            foreach (LRY_5EC5500A entity in Dbers.GetInstance().SelfDber.Entities<LRY_5EC5500A>("where TestTime>= :TestTime and SYBH is not null", new { TestTime = DateTime.Now.AddDays(-days).Date }))
            {
                CmcsHeatAssay item = Dbers.GetInstance().SelfDber.Entity<CmcsHeatAssay>("where PKID=:PKID", new { PKID = entity.PKID });
                if (item == null)
                {
                    item = new CmcsHeatAssay();
                    item.SampleNumber = entity.SYBH;
                    item.FacilityNumber = entity.MachineCode;
                    item.ContainerWeight = 0;
                    item.SampleWeight = Convert.ToDecimal(entity.SYZL);
                    item.Qbad =entity.DTFRL;
                    item.AssayUser = entity.HYY;
                    item.AssayTime = entity.TestTime;
                    item.IsEffective = 0;
                    item.PKID = entity.PKID;

                    res += Dbers.GetInstance().SelfDber.Insert<CmcsHeatAssay>(item);
                }
                else
                {
                    item.SampleNumber = entity.SYBH;
                    item.FacilityNumber = entity.MachineCode;
                    item.ContainerWeight = 0;
                    item.SampleWeight = Convert.ToDecimal(entity.SYZL);
                    item.Qbad = entity.DTFRL;
                    item.AssayUser = entity.HYY;
                    item.AssayTime = entity.TestTime;

                    res += Dbers.GetInstance().SelfDber.Update<CmcsHeatAssay>(item);
                }

            }

            output(string.Format("生成标准量热仪数据 {0} 条", res), eOutputType.Normal);

            return res;
        }
        #endregion 

        #region 保存标准水分仪数据
        /// <summary>
        /// 保存标准水分仪数据
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int SaveToMoistureAssay(Action<string, eOutputType> output, Int32 days)
        {
            int res = 0;

            // .水分仪 型号：5E-MW6510
            foreach (SFY_5EMW6510 entity in Dbers.GetInstance().SelfDber.Entities<SFY_5EMW6510>("where TestDate>= :TestTime and SampleNo is not null", new { TestTime = DateTime.Now.AddDays(-days).Date }))
            {
                string pkid = entity.PKID;

                CmcsMoistureAssay item = Dbers.GetInstance().SelfDber.Entity<CmcsMoistureAssay>("where PKID=:PKID", new { PKID = pkid });
                if (item == null)
                {
                    item = new CmcsMoistureAssay();
                    item.SampleNumber = entity.SampleNo;
                    item.FacilityNumber = entity.DeviceNo;
                    item.ContainerWeight = 0;
                    item.SampleWeight = entity.MtMass;
                    item.Mar = entity.Mt;
                    item.AssayUser = entity.TestMan;
                    item.IsEffective = 0;
                    item.PKID = pkid;
                    item.AssayTime = entity.TestDate;
                    item.WaterType = entity.MType.Contains("全水") ? "全水分" : "分析水";
                    res += Dbers.GetInstance().SelfDber.Insert<CmcsMoistureAssay>(item);
                }
                else
                {
                    item.SampleNumber = entity.SampleNo;
                    item.FacilityNumber = entity.DeviceNo;
                    item.ContainerWeight = 0;
                    item.SampleWeight = entity.MtMass;
                    item.Mar = entity.Mt;
                    item.AssayUser = entity.TestMan;
                    item.AssayTime = entity.TestDate;
                    item.WaterType = entity.MType.Contains("全水") ? "全水分" : "分析水";
                    res += Dbers.GetInstance().SelfDber.Update<CmcsMoistureAssay>(item);
                }
            }
            output(string.Format("生成标准水分仪数据 {0} 条", res), eOutputType.Normal);
            return res;
        }
        #endregion 
    }
}

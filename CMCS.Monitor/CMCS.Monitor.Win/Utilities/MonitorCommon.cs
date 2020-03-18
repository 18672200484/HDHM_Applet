using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using CMCS.Common;

namespace CMCS.Monitor.Win.Utilities
{
    public class MonitorCommon
    {
        private static MonitorCommon instance;

        public static MonitorCommon GetInstance()
        {
            if (instance == null)
            {
                instance = new MonitorCommon();
            }

            return instance;
        }

        /// <summary>
        /// 根据选中的采样点击域获取设备编码
        /// </summary>
        /// <param name="selectedMachine"></param>
        /// <returns></returns>
        public string GetCarSamplerMachineCodeBySelected(string selectedMachine)
        {
            switch (selectedMachine)
            {
                case "1号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_1;
                case "2号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_2;
                case "3号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_3;
                case "4号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_4;
                case "5号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_5;
                case "6号机械采样机点击域":
                    return GlobalVars.MachineCode_QCJXCYJ_6;
                default:
                    return GlobalVars.MachineCode_QCJXCYJ_1;
            }
        }

        /// <summary>
        /// 根据选中的衡器点击域获取设备编码
        /// </summary>
        /// <param name="selectedMachine"></param>
        /// <returns></returns>
        public string GetTruckWeighterMachineCodeBySelected(string selectedMachine)
        {
            switch (selectedMachine)
            {
                case "汽车衡_1号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_1;
                case "汽车衡_2号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_2;
                case "汽车衡_3号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_3;
                case "汽车衡_4号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_4;
                case "汽车衡_5号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_5;
                case "汽车衡_6号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_6;
                case "汽车衡_7号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_7;
                case "汽车衡_8号衡点击域":
                    return GlobalVars.MachineCode_QC_Weighter_8;
                default:
                    return GlobalVars.MachineCode_QC_Weighter_1;
            }
        }

        /// <summary>
        /// 转换设备系统状态为颜色值
        /// </summary>
        /// <param name="systemStatus">系统状态</param>
        /// <returns></returns>
        public string ConvertMachineStatusToColor(string systemStatus)
        {
            if ("|就绪待机|".Contains("|" + systemStatus + "|"))
                return ColorTranslator.ToHtml(EquipmentStatusColors.BeReady);
            else if ("|正在运行|正在卸样|".Contains("|" + systemStatus + "|"))
                return ColorTranslator.ToHtml(EquipmentStatusColors.Working);
            else if ("|发生故障|".Contains("|" + systemStatus + "|"))
                return ColorTranslator.ToHtml(EquipmentStatusColors.Breakdown);
            else
                return ColorTranslator.ToHtml(EquipmentStatusColors.Forbidden);
        }

        /// <summary>
        /// 转换布尔类型状态为颜色值
        /// </summary>
        /// <param name="status">状态</param>
        /// <returns></returns>
        public string ConvertBooleanToColor(string status)
        {
            return (string.IsNullOrEmpty(status) ? "0" : status) == "1" ? ColorTranslator.ToHtml(EquipmentStatusColors.Working) : ColorTranslator.ToHtml(EquipmentStatusColors.Forbidden);
        }
    }
}

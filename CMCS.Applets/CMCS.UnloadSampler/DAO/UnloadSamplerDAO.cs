using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common;
using CMCS.Common.Entities;
using CMCS.Common.Entities.CarTransport;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Enums;
using CMCS.UnloadSampler.Enums;

namespace CMCS.UnloadSampler.DAO
{
    public class UnloadSamplerDAO
    {
        private static UnloadSamplerDAO instance;

        public static UnloadSamplerDAO GetInstance()
        {
            if (instance == null)
            {
                instance = new UnloadSamplerDAO();
            }

            return instance;
        }

        private UnloadSamplerDAO()
        { }

        /// <summary>
        /// 获取卸样状态
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public eEquInfCmdResultCode GetBeltUnloadSamplerState(string UnloadSamplerId)
        {
            eEquInfCmdResultCode eResult;
            InfBeltSampleUnloadCmd SampleUnloadCmd = Dbers.GetInstance().SelfDber.Get<InfBeltSampleUnloadCmd>(UnloadSamplerId);
            if (SampleUnloadCmd != null)
            {
                if (Enum.TryParse(SampleUnloadCmd.ResultCode, out eResult))
                    return eResult;
                else
                    return eEquInfCmdResultCode.默认;
            }
            else
                return eEquInfCmdResultCode.默认;
        }
        /// <summary>
        /// 获取卸样状态
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public eEquInfCmdResultCode GetQCJXCYUnloadSamplerState(string UnloadSamplerId)
        {
            eEquInfCmdResultCode eResult;
            InfQCJXCYUnLoadCMD SampleUnloadCmd = Dbers.GetInstance().SelfDber.Get<InfQCJXCYUnLoadCMD>(UnloadSamplerId);
            if (SampleUnloadCmd != null)
            {
                if (Enum.TryParse(SampleUnloadCmd.ResultCode, out eResult))
                    return eResult;
                else
                    return eEquInfCmdResultCode.默认;
            }
            else
                return eEquInfCmdResultCode.默认;
        }
    }
}

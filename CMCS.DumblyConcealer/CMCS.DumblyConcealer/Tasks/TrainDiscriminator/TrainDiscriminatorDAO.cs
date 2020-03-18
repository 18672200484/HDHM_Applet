using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using CMCS.Common;
using CMCS.Common.Entities;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.DumblyConcealer.Enums;

namespace CMCS.DumblyConcealer.Tasks.TrainDiscriminator
{
    /// <summary>
    /// 火车车号识别业务
    /// </summary>
    public class TrainDiscriminatorDAO
    {
        private static TrainDiscriminatorDAO instance;

        private static String MachineCode_CHSB = GlobalVars.MachineCode_HCRCCHSB;

        public static TrainDiscriminatorDAO GetInstance()
        {
            if (instance == null)
            {

                instance = new TrainDiscriminatorDAO();
            }
            return instance;
        }

        private TrainDiscriminatorDAO()
        {

        }

        /// <summary>
        /// 同步报文
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public int Save(List<CmcsTrainCarriagePass> cmcstbtrainrecognition, Action<string, eOutputType> output)
        {
            int res = 0;
            try
            {
                foreach (var item in cmcstbtrainrecognition)
                {
                    CmcsTrainCarriagePass item1 = Dbers.GetInstance().SelfDber.Entity<CmcsTrainCarriagePass>("where TrainNumber=:TrainNumber and PassTime=:PassTime", new { TrainNumber = item.TrainNumber, PassTime = item.PassTime });
                    if (item1 == null)
                    {
                        res += Dbers.GetInstance().SelfDber.Insert(item);
                    }
                    else
                    {
                        item1.OrderNum = item.OrderNum;
                        item1.CarModel = item.CarModel;
                        item1.TrainNumber = item.TrainNumber;
                        item1.PassTime = item.PassTime;
                        item1.Speed = item.Speed;
                        item1.MachineCode = item.MachineCode;
                        res += Dbers.GetInstance().SelfDber.Update<CmcsTrainCarriagePass>(item1);
                    }
                }
            }
            catch (Exception ex)
            {
                output(string.Format("保存数据失败,原因:{0}", ex.Message), eOutputType.Error);
            }
            output(string.Format("同步车号识别数据 {0} 条（集中管控 ）", res), eOutputType.Normal);
            return res;
        }




    }
}

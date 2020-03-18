using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.DumblyConcealer.Enums;

namespace CMCS.DumblyConcealer.Tasks.TrainDiscriminator
{
    /// <summary>
    /// 火车车号识别-D报文
    /// </summary>
    public class TrainDiscriminatorDBW
    {
        private static TrainDiscriminatorDBW instance;

        private static String MachineCode_CHSB = GlobalVars.MachineCode_HCRCCHSB;

        public static TrainDiscriminatorDBW GetInstance()
        {
            if (instance == null)
            {
                instance = new TrainDiscriminatorDBW();
            }
            return instance;
        }

        private TrainDiscriminatorDBW()
        {
        }

        /// <summary>
        /// 同步报文
        /// </summary>
        /// <param name="output"></param>
        /// <returns></returns>
        public List<CmcsTrainCarriagePass> GetDBWInfo(Action<string, eOutputType> output)
        {
            List<CmcsTrainCarriagePass> cmcstbtrainrecognition = new List<CmcsTrainCarriagePass>();
            String interface_dbwdest = CommonDAO.GetInstance().GetAppletConfigString("车号识别文件储存位置");
            int interface_dbwtime = CommonDAO.GetInstance().GetAppletConfigInt32("车号识别文件读取天数");
            int res = 0;
            if (Directory.Exists(interface_dbwdest))
            {
                String[] dir = Directory.GetFiles(interface_dbwdest);
                foreach (var diritem in dir)
                {
                    ///解析数据
                    if (File.Exists(diritem) && CheckUseFull(diritem).AddDays(interface_dbwtime) >= DateTime.Now.Date)
                    {
                        String Info = File.ReadAllText(diritem);
                        if (Info.StartsWith("D"))
                        {
                            try
                            {
                                //火车方向
                                String fx = Info.Substring(18, 1) == "0" ? "入厂" : "出厂";
                                //到达时间

                                DateTime ddsj = new DateTime(Convert.ToInt32(Info.Substring(34, 4)), Convert.ToInt32(Info.Substring(38, 2)), Convert.ToInt32(Info.Substring(40, 2)), Convert.ToInt32(Info.Substring(42, 2)), Convert.ToInt32(Info.Substring(44, 2)), Convert.ToInt32(Info.Substring(46, 2)));

                                //通过时间
                                DateTime tgsj = new DateTime(Convert.ToInt32(Info.Substring(50, 4)), Convert.ToInt32(Info.Substring(54, 2)), Convert.ToInt32(Info.Substring(56, 2)), Convert.ToInt32(Info.Substring(58, 2)), Convert.ToInt32(Info.Substring(60, 2)), Convert.ToInt32(Info.Substring(62, 2)));

                                //报告时间
                                DateTime bgsj = new DateTime(Convert.ToInt32(Info.Substring(66, 4)), Convert.ToInt32(Info.Substring(70, 2)), Convert.ToInt32(Info.Substring(72, 2)), Convert.ToInt32(Info.Substring(74, 2)), Convert.ToInt32(Info.Substring(76, 2)), Convert.ToInt32(Info.Substring(78, 2)));

                                //车数
                                int countnum = Convert.ToInt32(Info.Substring(82, 3));
                                //车头
                                int ctnum = Convert.ToInt32(Info.Substring(85, 1));
                                //车中
                                int cznum = Convert.ToInt32(Info.Substring(86, 1));
                                //车尾
                                int cwnum = Convert.ToInt32(Info.Substring(87, 1));
                                if ((int)Info.Substring(88 + 24 * countnum, 1).ToCharArray()[0] == 0x04)
                                {
                                    for (int i = 0; i < countnum; i++)
                                    {
                                        String trainnum = Info.Substring(88 + 24 * i, 24);
                                        //车型
                                        String cx = "";
                                        //车号
                                        String ch = "";
                                        //车类型
                                        String clx = "";
                                        if (trainnum.StartsWith("T"))
                                        {
                                            //车型
                                            cx = trainnum.Substring(1, 6).Trim();
                                            //车号
                                            ch = trainnum.Substring(7, 7);
                                            clx = "车厢";
                                        }
                                        else if (trainnum.StartsWith("J"))
                                        {
                                            //车型
                                            cx = trainnum.Substring(1, 3);
                                            //车号
                                            ch = trainnum.Substring(4, 4);
                                            clx = "车头";
                                        }
                                        string pkid = ch + "-" + tgsj.ToString("yyyyMMddHHmmss");
                                        if (clx == "车厢")
                                        {
                                            CmcsTrainCarriagePass item = new CmcsTrainCarriagePass
                                                    {
                                                        OrderNum = 0,
                                                        CarModel=cx,
                                                        TrainNumber=ch,
                                                        PassTime=tgsj,
                                                        Speed=0,
                                                        MachineCode=MachineCode_CHSB
                                                    };
                                            cmcstbtrainrecognition.Add(item);
                                        }
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                output(string.Format("解析 {0} 报文失败,原因:{1}", diritem, ex.Message), eOutputType.Error);
                            }
                        }
                    }
                }
            }
            return cmcstbtrainrecognition;
        }

        /// <summary>
        /// 解析报文名字是否有效
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private DateTime CheckUseFull(String path)
        {
            try
            {
                String Name = Path.GetFileName(path);
                if (Name.Length == 12 && Name.StartsWith("D") && Name.IndexOf('.') == 8)
                {
                    int month = 0;
                    String monthString = Name.Substring(9, 1);
                    if (!int.TryParse(monthString, out month))
                    {
                        switch (monthString)
                        {
                            case "A":
                                month = 10;
                                break;
                            case "B":
                                month = 11;
                                break;
                            case "C":
                                month = 12;
                                break;
                        }
                    }
                    DateTime dt = new DateTime(DateTime.Now.Year, month, Convert.ToInt32(Name.Substring(10, 2)));
                    if (dt > DateTime.Now.Date)
                    {
                        dt = dt.AddYears(-1);
                    }
                    return dt;
                }
            }
            catch (Exception)
            {
            }

            return DateTime.MinValue;
        }
    }
}

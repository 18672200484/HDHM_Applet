using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar;
using CMCS.DumblyConcealer.Win.Core;
using CMCS.Common.Utilities;
using CMCS.Common.DAO;
using CMCS.DumblyConcealer.Tasks.BeltBalancer;
using BeltBalancer.SM6000;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.BeltBalancer.Entities;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    /// <summary>
    /// 皮带秤称重数据同步程序
    /// </summary>
    public partial class FrmBeltBalancer : TaskForm
    {
        RTxtOutputer rTxtOutputer;

        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();

        CommonDAO commonDAO = CommonDAO.GetInstance();

        EquBeltBalancerDAO balancerDAO = EquBeltBalancerDAO.GetInstance();

        /// <summary>
        /// 命令报文1
        /// </summary>
        public static byte[] Cmd1 = new byte[] { 0x01, 0x03, 0x90, 0x00, 0x00, 0x03, 0x28, 0xCB };

        /// <summary>
        /// 命令报文2
        /// </summary>
        public static byte[] Cmd2 = new byte[] { 0x02, 0x03, 0x90, 0x00, 0x00, 0x06, 0xE8, 0xFB };

        SM6000ABber bber1 = new SM6000ABber(Cmd1, 1000);

        SM6000ABber bber2 = new SM6000ABber(Cmd2, 1000);

        float total1 = 0; float instant1 = 0; float speed1 = 0;

        float total2 = 0; float instant2 = 0; float speed2 = 0;

        DateTime prevHistoryTime1 = DateTime.Now.AddMinutes(-10);

        DateTime prevHistoryTime2 = DateTime.Now.AddMinutes(-10);

        public FrmBeltBalancer()
        {
            InitializeComponent();
        }

        private void FrmBeltBalancer_Load(object sender, EventArgs e)
        {
            this.Text = "皮带秤计量程序";

            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);

            ExecuteAllTask();
        }

        /// <summary>
        /// 执行所有任务
        /// </summary>
        void ExecuteAllTask()
        {
            taskSimpleScheduler.StartNewTask("初始化甲路皮带秤", () =>
            {
                bber1.OnDataReceived += Bber1_OnDataReceived;
                bber1.OnReceiveError += Bber1_OnReceiveError;
                if (bber1.OpenCom(commonDAO.GetAppletConfigInt32("甲路皮带秤串口号"), commonDAO.GetAppletConfigInt32("甲路皮带秤波特率"), 8, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None))
                    this.rTxtOutputer.Output("甲路皮带秤串口打开成功", eOutputType.Important);
                else
                    this.rTxtOutputer.Output("甲路皮带秤串口打开失败", eOutputType.Error);
            });

            taskSimpleScheduler.StartNewTask("初始化乙路皮带秤", () =>
            {
                bber2.OnDataReceived += Bber2_OnDataReceived;
                bber2.OnReceiveError += Bber2_OnReceiveError;
                if (bber2.OpenCom(commonDAO.GetAppletConfigInt32("乙路皮带秤串口号"), commonDAO.GetAppletConfigInt32("乙路皮带秤波特率"), 8, System.IO.Ports.StopBits.One, System.IO.Ports.Parity.None))
                    this.rTxtOutputer.Output("乙路皮带秤串口打开成功", eOutputType.Important);
                else
                    this.rTxtOutputer.Output("乙路皮带秤串口打开失败", eOutputType.Error);
            });
        }

        #region 甲路皮带秤
        private void Bber1_OnReceiveError(Exception ex)
        {
            this.rTxtOutputer.Output("读取甲皮带秤数据" + ex.Message, eOutputType.Error);
        }

        private void Bber1_OnDataReceived(float total, float instant, float speed)
        {
            this.InvokeEx(() =>
            {
                lblTotal1.Text = total.ToString() + " t";
                lblInstant1.Text = instant.ToString() + " t/h";
                lblSpeed1.Text = speed.ToString() + " m/s";

                this.total1 = total;
                this.instant1 = instant;
                this.speed1 = speed;

                try
                {
                    CmcsBeltBalancerValue sisTagValue = balancerDAO.IUTagValue("甲皮带秤累计量", total1.ToString(), "甲皮带秤");
                    balancerDAO.IUTagValue("甲皮带秤瞬时流量", instant1.ToString(), "甲皮带秤");
                    // 每一分钟插入累计量历史
                    if (prevHistoryTime1.ToString("yyyyMMddHHmm") != DateTime.Now.ToString("yyyyMMddHHmm"))
                    {
                        prevHistoryTime1 = DateTime.Now;
                        balancerDAO.InsertTagValueHistory(sisTagValue);
                    }
                }
                catch (Exception ex)
                {
                    this.rTxtOutputer.Output("保存甲皮带秤数据失败" + ex.Message, eOutputType.Error);
                }
            });
        }
        #endregion

        #region 乙路皮带秤
        private void Bber2_OnReceiveError(Exception ex)
        {
            this.rTxtOutputer.Output("读取乙皮带秤数据" + ex.Message, eOutputType.Error);
        }

        private void Bber2_OnDataReceived(float total, float instant, float speed)
        {
            this.InvokeEx(() =>
            {
                lblTotal2.Text = total.ToString() + " t";
                lblInstant2.Text = instant.ToString() + " t/h";
                lblSpeed2.Text = speed.ToString() + " m/s";

                this.total2 = total;
                this.instant2 = instant;
                this.speed2 = speed;

                try
                {
                    CmcsBeltBalancerValue sisTagValue = balancerDAO.IUTagValue("乙皮带秤累计量", total2.ToString(), "乙皮带秤");
                    balancerDAO.IUTagValue("乙皮带秤瞬时流量", instant2.ToString(), "乙皮带秤");

                    // 每一分钟插入累计量历史
                    if (prevHistoryTime2.ToString("yyyyMMddHHmm") != DateTime.Now.ToString("yyyyMMddHHmm"))
                    {
                        prevHistoryTime2 = DateTime.Now;
                        balancerDAO.InsertTagValueHistory(sisTagValue);
                    }
                }
                catch (Exception ex)
                {
                    this.rTxtOutputer.Output("保存乙皮带秤数据失败" + ex.Message, eOutputType.Error);
                }
            });
        }
        #endregion

        /// <summary>
        /// 输出异常信息
        /// </summary>
        /// <param name="text"></param>
        /// <param name="ex"></param>
        void OutputError(string text, Exception ex)
        {
            this.rTxtOutputer.Output(text + Environment.NewLine + ex.Message, eOutputType.Error);

            Log4Neter.Error(text, ex);
        }

        /// <summary>
        /// Invoke封装
        /// </summary>
        /// <param name="action"></param>
        public void InvokeEx(Action action)
        {
            if (this.IsDisposed || !this.IsHandleCreated) return;

            this.Invoke(action);
        }

        /// <summary>
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBeltBalancer_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                bber1.CloseCom();
                bber2.CloseCom();
            }
            catch { }

            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }

    }
}
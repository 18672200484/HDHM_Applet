using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CMCS.Common;
using CMCS.Common.DAO;
using CMCS.Common.Entities.BaseInfo;
using CMCS.Common.Entities.Fuel;
using CMCS.Common.Entities.Inf;
using CMCS.Common.Entities.TrainInFactory;
using CMCS.Common.Enums;
using CMCS.Common.Utilities;
using CMCS.Common.Views;
using CMCS.TrainTipper.DAO;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.SuperGrid;

namespace CMCS.TrainTipper.Frms
{
    public partial class FrmTrainTipper : DevComponents.DotNetBar.Metro.MetroForm
    {
        CommonDAO commonDAO = CommonDAO.GetInstance();
        TrainTipperDAO trainTipperDAO = TrainTipperDAO.GetInstance();
        BeltSamplerDAO beltSamplerDAO = BeltSamplerDAO.GetInstance();
        CarriageRecognitionerDAO carriageRecognitionerDAO = CarriageRecognitionerDAO.GetInstance();

        /// <summary>
        /// 翻车机
        /// </summary>
        CmcsCMEquipment trainTipper;
        /// <summary>
        /// 车号识别设备编码
        /// </summary>
        string carriageRecognitionerMachineCode;
        /// <summary>
        /// 皮带采样机
        /// </summary>
        CmcsCMEquipment trainBeltSampler;
        /// <summary>
        /// 最后一次记录
        /// </summary>
        View_TrainTipperQueue lastView_TrainTipperQueue;

        CmcsTrainCarriagePass currentTrainCarriagePass;
        /// <summary>
        /// 当前车号识别记录
        /// </summary>
        public CmcsTrainCarriagePass CurrentTrainCarriagePass
        {
            get { return currentTrainCarriagePass; }
            set
            {
                currentTrainCarriagePass = value;

                this.InvokeEx(() =>
                {
                    lblCurrentTrainNumber.Text = currentTrainCarriagePass.TrainNumber;
                });
            }
        }

        Color[] CellColors = new Color[] { ColorTranslator.FromHtml("#7D00FFFF"), ColorTranslator.FromHtml("#7DFFFF00"), ColorTranslator.FromHtml("#7D7CFC00"), ColorTranslator.FromHtml("#7DFF69B4"), ColorTranslator.FromHtml("#7DFF00FF"), ColorTranslator.FromHtml("#7DADD8E6"), ColorTranslator.FromHtml("#7D00FF00"), ColorTranslator.FromHtml("#7DFFC0CB") };
        /// <summary>
        /// 分配的颜色
        /// </summary>
        Dictionary<string, Color> dicCellColors = new Dictionary<string, Color>();

        List<View_TrainTipperQueue> view_TrainTipperQueue_All;
        List<View_TrainTipperQueue> view_TrainTipperQueue_YF;
        List<View_TrainTipperQueue> view_TrainTipperQueue_DF;

        /// <summary>
        /// FrmTrainTipper
        /// </summary>
        /// <param name="trainTipper">翻车机设备编码</param>
        /// <param name="carriageRecognitionerMachineCode">车号识别设备编码</param> 
        public FrmTrainTipper(CmcsCMEquipment trainTipper, string carriageRecognitionerMachineCode)
        {
            InitializeComponent();

            this.trainTipper = trainTipper;
            this.carriageRecognitionerMachineCode = carriageRecognitionerMachineCode;
        }

        private void FrmTrainTipper_Load(object sender, EventArgs e)
        {
            InitForm();
        }

        /// <summary>
        /// 窗体初始化
        /// </summary>
        private void InitForm()
        {
            // 默认当天
            dtiptStartArriveTime.Value = DateTime.Now.Date;
            dtiptEndArriveTime.Value = DateTime.Now.Date.AddDays(1);

            // 将未处理的车号识别通过记录标记为已处理
            carriageRecognitionerDAO.ChangeTrainCarriagePassToHandledByMachineCode(this.carriageRecognitionerMachineCode);

            timer2_Tick(null, null);
        }

        #region 定时器

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            try
            {

            }
            catch (Exception ex) { Log4Neter.Error("定时处理timer_Tick", ex); }

            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            timer2.Stop();

            UpdateLinkBeltSamplerStatus();

            timer2.Start();
        }

        #endregion

        #region 逻辑控制

        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();

        System.Threading.AutoResetEvent autoResetEvent = new AutoResetEvent(false);

        /// <summary>
        /// 翻车业务逻辑入口
        /// </summary>
        private void CreateMainTask()
        {
            taskSimpleScheduler = new TaskSimpleScheduler();

            autoResetEvent.Reset();

            taskSimpleScheduler.StartNewTask("翻车业务逻辑", () =>
            {
                // 获取待处理的车号识别记录 - 入厂方向
                CmcsTrainCarriagePass inTrainCarriagePass = carriageRecognitionerDAO.GetUnHandleTrainCarriagePass(this.carriageRecognitionerMachineCode, eTrainPassDirection.进厂);
                if (inTrainCarriagePass != null)
                {
                    this.CurrentTrainCarriagePass = inTrainCarriagePass;

                    // 检测采样机系统的状态
                    string samplerSystemStatue = commonDAO.GetSignalDataValue(this.trainBeltSampler.EquipmentCode, eSignalDataName.系统.ToString());
                    if (samplerSystemStatue == eEquInfSamplerSystemStatus.发生故障.ToString() || samplerSystemStatue == eEquInfSamplerSystemStatus.正在卸样.ToString())
                    {
                        MessageBoxEx2Show("禁止翻车， " + this.trainBeltSampler.EquipmentName + "发生故障或正在卸样，已暂停运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                        btnStartTurnover.Enabled = true;

                        // 取消任务
                        this.taskSimpleScheduler.Cancal();

                        return;
                    }

                    StartTippingTask(this.CurrentTrainCarriagePass);

                    autoResetEvent.WaitOne();
                }
            }, 4000);
        }

        /// <summary>
        /// 接收车号识别数据，开始翻车逻辑控制
        /// </summary>
        /// <param name="inTrainCarriagePass"></param>
        private void StartTippingTask(CmcsTrainCarriagePass trainCarriagePass)
        {
            Task task = new Task((state) =>
            {
                CmcsTrainCarriagePass inTrainCarriagePass = state as CmcsTrainCarriagePass;
                if (inTrainCarriagePass != null)
                {
                    #region 车号为空时，执行车号补录

                    if (string.IsNullOrEmpty(inTrainCarriagePass.TrainNumber))
                    {
                        Log4Neter.Info(this.trainTipper.EquipmentName + " - 车号识别失败，要求输入车号");

                        this.InvokeEx(() => { Form1.superTabControlManager.ChangeToTab(this.trainTipper.EquipmentCode); });

                        // 弹出输入框，要求输入车厢号
                        FrmInput frmInput = new FrmInput("请输入所翻车厢号", (input) =>
                        {
                            if (string.IsNullOrEmpty(input))
                            {
                                MessageBoxEx.Show("请输入车厢号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            if (!this.view_TrainTipperQueue_DF.Any(a => a.TrainNumber == input))
                            {
                                MessageBoxEx.Show("在队列中未找到此车，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }

                            return true;
                        });

                        if (frmInput.ShowDialog() == DialogResult.OK)
                        {
                            Log4Neter.Info(this.trainTipper.EquipmentName + " - 用户输入：" + frmInput.Input);
                            inTrainCarriagePass.TrainNumber = frmInput.Input;
                        }
                        else
                        {
                            Log4Neter.Info(this.trainTipper.EquipmentName + " - 用户关闭输入窗口");

                            inTrainCarriagePass.DataFlag = 1;
                            Dbers.GetInstance().SelfDber.Update(inTrainCarriagePass);

                            autoResetEvent.Set();
                        };
                    }

                    #endregion

                    Log4Neter.Info(this.trainTipper.EquipmentName + " - 当前车号：" + inTrainCarriagePass.TrainNumber);
                    commonDAO.SetSignalDataValue(this.trainTipper.EquipmentCode, eSignalDataName.当前车号.ToString(), inTrainCarriagePass.TrainNumber);

                    View_TrainTipperQueue selfView_TrainTipperQueue = this.view_TrainTipperQueue_All.FirstOrDefault(a => a.TrainNumber == inTrainCarriagePass.TrainNumber);
                    if (selfView_TrainTipperQueue != null)
                    {
                        commonDAO.SetSignalDataValue(this.trainTipper.EquipmentCode, eSignalDataName.当前车Id.ToString(), selfView_TrainTipperQueue.TransportId);

                        if (selfView_TrainTipperQueue.SampleType != eSamplingType.皮带采样.ToString())
                        {
                            // 采样方案中设置为非火车皮采

                            Log4Neter.Info(this.trainTipper.EquipmentName + " - 采样方案中设置为非皮带采样,SampleType=" + selfView_TrainTipperQueue.SampleType);

                            DialogResult dialogResult = MessageBoxEx2Show("<font size='+2'>车号: <font color='red'>" + selfView_TrainTipperQueue.TrainNumber + "</font><br/><br/>该车为" + selfView_TrainTipperQueue.SampleType + "<br/><br/>点击<font color='red'>[是]</font>立即通知皮带采样机停止采样<br/>然后在采样机成功停止后开始翻车<br/><br/>点击<font color='red'>[否]</font>直接开始翻车<br/><br/>点击<font color='red'>[取消]</font>不做任何处理</font>", "提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                            if (dialogResult == DialogResult.Yes)
                            {
                                if (SendSamplerStopCmd(selfView_TrainTipperQueue))
                                    // 标记为已处理 
                                    ToHandled(inTrainCarriagePass.Id, selfView_TrainTipperQueue.Id);
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                // 标记为已处理 
                                ToHandled(inTrainCarriagePass.Id, selfView_TrainTipperQueue.Id);
                            }
                        }
                        else
                        {
                            if (MessageBoxEx2Show("<font size='+2'>车号: <font color='red'>" + selfView_TrainTipperQueue.TrainNumber + "</font><br/><br/>点击<font color='red'>[确定]</font>立即通知皮带采样机开始采样<br/>确认采样机启动成功后再开始翻车<br/><br/>点击<font color='red'>[取消]</font>不做任何处理</font>", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                            {
                                if (SendSamplerStartCmd(selfView_TrainTipperQueue))
                                    // 标记为已处理 
                                    ToHandled(inTrainCarriagePass.Id, selfView_TrainTipperQueue.Id);
                            }
                        }
                    }
                    else
                    {
                        // 未找到此车

                        commonDAO.SetSignalDataValue(this.trainTipper.EquipmentCode, eSignalDataName.当前车Id.ToString(), string.Empty);

                        if (MessageBoxEx2Show("未找到车厢[" + inTrainCarriagePass.TrainNumber + "]，是否忽略？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            // 标记车号识别记录为已处理
                            carriageRecognitionerDAO.ChangeTrainCarriagePassToHandled(inTrainCarriagePass.Id);
                    }
                }

                autoResetEvent.Set();

            }, trainCarriagePass);
            task.Start();
        }

        #endregion

        #region 其他函数

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
        /// MessageBoxEx封装，弹出对话框之前切换到选项卡
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="buttons"></param>
        /// <param name="icon"></param>
        /// <returns></returns>
        private DialogResult MessageBoxEx2Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
        {
            Form1.superTabControlManager.ChangeToTab(this.trainTipper.EquipmentCode);
            return MessageBoxEx.Show(text, caption, buttons, icon);
        }

        /// <summary>
        /// 设置ToolTip提示
        /// </summary>
        private void SetSystemStatusToolTip(Control control)
        {
            this.toolTip1.SetToolTip(control, "<绿色> 就绪待机\r\n<红色> 正在运行\r\n<黄色> 发生故障");
        }

        /// <summary>
        /// 更新对应的皮带采样机系统状态
        /// </summary>
        private void UpdateLinkBeltSamplerStatus()
        {
            this.trainBeltSampler = TrainInFactoryDAO.GetInstance().GetTrainTipperLinkBeltSampler(this.trainTipper.EquipmentCode);
            if (trainBeltSampler != null)
            {
                lblTrainBeltSampler.Text = this.trainBeltSampler.EquipmentName;

                string systemStatus = commonDAO.GetSignalDataValue(this.trainBeltSampler.EquipmentCode, eSignalDataName.系统.ToString());
                if (systemStatus == eEquInfSamplerSystemStatus.就绪待机.ToString())
                    uCtrlSignalLight_TrainBeltSampler.LightColor = EquipmentStatusColors.BeReady;
                else if (systemStatus == eEquInfSamplerSystemStatus.正在运行.ToString() || systemStatus == eEquInfSamplerSystemStatus.正在卸样.ToString())
                    uCtrlSignalLight_TrainBeltSampler.LightColor = EquipmentStatusColors.Working;
                else if (systemStatus == eEquInfSamplerSystemStatus.发生故障.ToString())
                    uCtrlSignalLight_TrainBeltSampler.LightColor = EquipmentStatusColors.Breakdown;

                // 检测集样罐是否充足
                int barrelCount = commonDAO.SelfDber.Count<InfEquInfSampleBarrel>("where MachineCode=:MachineCode and BarrelStatus!=:BarrelStatus and BarrelType=:BarrelType", new { MachineCode = this.trainBeltSampler.EquipmentCode, BarrelStatus = eSampleBarrelStatus.已满.ToString(), BarrelType = "底卸式" });
                lblBarrelStatus.Text = barrelCount >= 1 ? "(样桶充足)" : "(样桶不足)";
                lblBarrelStatus.Location = new Point(lblTrainBeltSampler.Location.X + lblTrainBeltSampler.Size.Width, lblBarrelStatus.Location.Y);
            }
            else
            {
                lblTrainBeltSampler.Text = "未设置";

                uCtrlSignalLight_TrainBeltSampler.LightColor = EquipmentStatusColors.Forbidden;
            }
        }

        /// <summary>
        /// 输出当前运行信息
        /// </summary>
        /// <param name="output"></param>
        private void OutputRunInfo(string output)
        {
            this.InvokeEx(() =>
            {
                lblRunInfo.Text = "> " + output;

                Log4Neter.Info(this.trainTipper.EquipmentName + " - 运行输出：" + output);
            });
        }

        /// <summary>
        /// 更改界面控件的可用属性
        /// </summary>
        /// <param name="enabled"></param>
        private void ChangeUIEnabled(bool enabled)
        {
            this.InvokeEx(() =>
            {
                btnAddTrainCarriagePass.Enabled = enabled;
                btnStopTurnover.Enabled = enabled;
            });
        }

        /// <summary>
        /// 发送开始采样命令
        /// </summary>
        /// <param name="view_TrainTipperQueue"></param>
        /// <returns></returns>
        private bool SendSamplerStartCmd(View_TrainTipperQueue view_TrainTipperQueue)
        {
            this.lastView_TrainTipperQueue = view_TrainTipperQueue;

            bool res = false;

            // 检测采样机系统的状态
            string samplerSystemStatue = commonDAO.GetSignalDataValue(this.trainBeltSampler.EquipmentCode, eSignalDataName.系统.ToString());
            if (samplerSystemStatue == eEquInfSamplerSystemStatus.就绪待机.ToString() || samplerSystemStatue == eEquInfSamplerSystemStatus.正在运行.ToString())
            {
                Log4Neter.Info(this.trainTipper.EquipmentName + " - 向[" + this.trainBeltSampler.EquipmentCode + "]发送[开始采样]命令，采样码：" + view_TrainTipperQueue.YuSampleCode);

                // 发送采样计划
                if (SendSamplePlan(view_TrainTipperQueue))
                {
                    string cmdId;
                    bool sendSuccess = beltSamplerDAO.SendSampleCmd(this.trainBeltSampler.EquipmentCode, eEquInfSamplerCmd.开始采样, view_TrainTipperQueue.YuSampleCode, out cmdId);

                    ChangeUIEnabled(false);
                    OutputRunInfo("等待皮带采样机返回命令(开始采样)执行结果");

                    eEquInfCmdResultCode equInfCmdResultCode;
                    do
                    {
                        Thread.Sleep(10000);

                        equInfCmdResultCode = beltSamplerDAO.GetSampleCmdResult(cmdId);
                    }
                    while (sendSuccess && equInfCmdResultCode == eEquInfCmdResultCode.默认);

                    res = equInfCmdResultCode == eEquInfCmdResultCode.成功;

                    ChangeUIEnabled(true);
                    OutputRunInfo("皮带采样机执行命令(开始采样)" + (res ? "成功" : "失败"));
                }
            }
            else
            {
                Log4Neter.Info(this.trainTipper.EquipmentName + " - " + this.trainBeltSampler.EquipmentCode + "未处于" + samplerSystemStatue + "状态，禁止发送开始采样命令");
            }

            return res;
        }

        /// <summary>
        /// 发送结束采样命令
        /// </summary>
        /// <param name="view_TrainTipperQueue"></param> 
        private bool SendSamplerStopCmd(View_TrainTipperQueue view_TrainTipperQueue)
        {
            this.lastView_TrainTipperQueue = null;

            bool res = false;

            // 检测采样机系统的状态
            string samplerSystemStatue = commonDAO.GetSignalDataValue(this.trainBeltSampler.EquipmentCode, eSignalDataName.系统.ToString());
            if (samplerSystemStatue == eEquInfSamplerSystemStatus.正在运行.ToString())
            {
                string sampleCode = view_TrainTipperQueue != null ? view_TrainTipperQueue.YuSampleCode : string.Empty;

                Log4Neter.Info(this.trainTipper.EquipmentName + " - 向[" + this.trainBeltSampler.EquipmentCode + "]发送[结束采样]命令，采样码：" + sampleCode);

                string cmdId;
                bool sendSuccess = beltSamplerDAO.SendSampleCmd(this.trainBeltSampler.EquipmentCode, eEquInfSamplerCmd.结束采样, sampleCode, out cmdId);

                ChangeUIEnabled(false);
                OutputRunInfo("等待皮带采样机返回命令(结束采样)执行结果");

                eEquInfCmdResultCode equInfCmdResultCode;
                do
                {
                    Thread.Sleep(10000);

                    equInfCmdResultCode = beltSamplerDAO.GetSampleCmdResult(cmdId);
                }
                while (sendSuccess && equInfCmdResultCode == eEquInfCmdResultCode.默认);

                res = equInfCmdResultCode == eEquInfCmdResultCode.成功;

                ChangeUIEnabled(true);
                OutputRunInfo("皮带采样机执行命令(结束采样)" + (res ? "成功" : "失败"));

                return res;
            }
            else
            {
                OutputRunInfo(this.trainBeltSampler.EquipmentCode + "未处于正在运行状态，无须发送结束采样命令");
                Log4Neter.Info(this.trainTipper.EquipmentName + " - " + this.trainBeltSampler.EquipmentCode + "未处于正在运行状态，无须发送结束采样命令");

                return true;
            }
        }

        /// <summary>
        /// 发送采样计划，若存在则更新
        /// </summary>
        /// <param name="view_TrainTipperQueue"></param>  
        /// <returns></returns>
        public bool SendSamplePlan(View_TrainTipperQueue view_TrainTipperQueue)
        {
            CmcsInFactoryBatch inFactoryBatch = Dbers.GetInstance().SelfDber.Get<CmcsInFactoryBatch>(view_TrainTipperQueue.InFactoryBatchId);
            if (inFactoryBatch == null) throw new ArgumentNullException("inFactoryBatchId", "未找到Id=" + view_TrainTipperQueue.InFactoryBatchId + "的批次");

            CmcsFuelKind fuelKind = Dbers.GetInstance().SelfDber.Get<CmcsFuelKind>(inFactoryBatch.FuelKindId);
            List<View_TrainTipperQueue> list = trainTipperDAO.GetView_TrainTipperQueueBy(view_TrainTipperQueue.TrainSampleSchemeId);

            InfBeltSamplePlan oldBeltSamplePlan = Dbers.GetInstance().SelfDber.Entity<InfBeltSamplePlan>("where InFactoryBatchId=:InFactoryBatchId and SampleCode=:SampleCode", new { InFactoryBatchId = view_TrainTipperQueue.InFactoryBatchId, SampleCode = view_TrainTipperQueue.YuSampleCode });
            if (oldBeltSamplePlan == null)
            {
                Log4Neter.Info(this.trainTipper.EquipmentName + " - 向[" + this.trainBeltSampler.EquipmentCode + "]发送采样计划，采样码：" + view_TrainTipperQueue.YuSampleCode);

                return Dbers.GetInstance().SelfDber.Insert<InfBeltSamplePlan>(new InfBeltSamplePlan
                {
                    DataFlag = 0,
                    InterfaceType = this.trainBeltSampler.InterfaceType,
                    InFactoryBatchId = view_TrainTipperQueue.InFactoryBatchId,
                    SampleCode = view_TrainTipperQueue.YuSampleCode,
                    FuelKindName = fuelKind != null ? fuelKind.Name : string.Empty,
                    CarCount = list.Count,
                    Mt = 0,
                    TicketWeight = list.Sum(a => a.TicketQty),
                    SampleType = eEquInfSampleType.到集样罐.ToString(),
                    GatherType = commonDAO.GetCommonAppletConfigString(this.trainBeltSampler.EquipmentCode + "集样方式")
                }) > 0;
            }
            else
            {
                Log4Neter.Info(this.trainTipper.EquipmentName + " - 向[" + this.trainBeltSampler.EquipmentCode + "]更新采样计划，采样码：" + view_TrainTipperQueue.YuSampleCode);

                oldBeltSamplePlan.DataFlag = 0;
                oldBeltSamplePlan.FuelKindName = fuelKind != null ? fuelKind.Name : string.Empty;
                oldBeltSamplePlan.CarCount = list.Count;
                oldBeltSamplePlan.Mt = 0;
                oldBeltSamplePlan.TicketWeight = list.Sum(a => a.TicketQty);
                oldBeltSamplePlan.SampleType = eEquInfSampleType.到集样罐.ToString();
                oldBeltSamplePlan.GatherType = commonDAO.GetCommonAppletConfigString(this.trainBeltSampler.EquipmentCode + "集样方式");

                return Dbers.GetInstance().SelfDber.Update(oldBeltSamplePlan) > 0;
            }
        }

        /// <summary>
        /// 将车号识别和对道记录设置为已处理、已翻车并刷新界面列表
        /// </summary>
        /// <param name="inTrainCarriagePass">车号识别Id</param>
        /// <param name="trainWeightRecordId">火车入厂记录Id</param>
        private void ToHandled(string inTrainCarriagePass, string trainWeightRecordId)
        {
            // 标记车号识别记录为已处理
            carriageRecognitionerDAO.ChangeTrainCarriagePassToHandled(inTrainCarriagePass);
            // 标记对道队列记录为已翻
            TrainTipperDAO.GetInstance().ChangeTrainWeightRecordIsTurnover(trainWeightRecordId, eTrainTipperTurnoverStatus.已翻);
            // 加载翻车机对道队列详情视图
            LoadView_TrainTipperQueue();
        }

        /// <summary>
        /// 加载翻车机对道队列详情视图
        /// </summary>
        private void LoadView_TrainTipperQueue()
        {
            this.view_TrainTipperQueue_All = TrainTipperDAO.GetInstance().GetView_TrainTipperQueue(this.trainTipper.EquipmentCode, dtiptStartArriveTime.Value, dtiptEndArriveTime.Value);

            this.view_TrainTipperQueue_DF = this.view_TrainTipperQueue_All.Where(a => a.IsTurnover == eTrainTipperTurnoverStatus.待翻.ToString()).OrderBy(a => a.OrderNumber).ToList();
            superGridControl_DF.PrimaryGrid.DataSource = this.view_TrainTipperQueue_DF;

            this.view_TrainTipperQueue_YF = this.view_TrainTipperQueue_All.Where(a => a.IsTurnover == eTrainTipperTurnoverStatus.已翻.ToString()).OrderByDescending(a => a.OrderNumber).ToList();
            superGridControl_YF.PrimaryGrid.DataSource = this.view_TrainTipperQueue_YF;

            AllotCellColor();
        }

        /// <summary>
        /// 分配单元格颜色
        /// </summary>
        private void AllotCellColor()
        {
            dicCellColors.Clear();

            foreach (View_TrainTipperQueue view_TrainTipperQueue in this.view_TrainTipperQueue_All)
            {
                string key = view_TrainTipperQueue.InFactoryBatchId + "-" + view_TrainTipperQueue.TrainSampleSchemeId;

                if (!dicCellColors.ContainsKey(key) && dicCellColors.Count < CellColors.Length) dicCellColors.Add(key, CellColors[dicCellColors.Count]);
            }
        }

        #endregion

        #region 控件事件

        /// <summary>
        /// 开始翻车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartTurnover_Click(object sender, EventArgs e)
        {
            Log4Neter.Info(this.trainTipper.EquipmentName + " - 开始翻车");

            if (this.view_TrainTipperQueue_DF.Count == 0)
            {
                MessageBoxEx2Show("翻车队列为空，请查询出队列后再运行", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            btnStartTurnover.Enabled = false;
            btnAddTrainCarriagePass.Enabled = true;
            dtiptStartArriveTime.Enabled = false;
            dtiptEndArriveTime.Enabled = false;

            CreateMainTask();
        }

        /// <summary>
        /// 停止翻车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStopTurnover_Click(object sender, EventArgs e)
        {
            Log4Neter.Info(this.trainTipper.EquipmentName + " - 停止翻车");

            // 取消任务
            this.taskSimpleScheduler.Cancal();

            if (MessageBoxEx2Show("是否立即通知皮带采样机停止采样？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                btnStartTurnover.Enabled = false;
                btnAddTrainCarriagePass.Enabled = false;
                dtiptStartArriveTime.Enabled = false;
                dtiptEndArriveTime.Enabled = false;

                Task task = new Task(() =>
                {
                    // 停止采样机
                    SendSamplerStopCmd(this.lastView_TrainTipperQueue);

                    this.InvokeEx(() =>
                    {
                        btnStartTurnover.Enabled = true;
                        btnAddTrainCarriagePass.Enabled = false;
                        dtiptStartArriveTime.Enabled = true;
                        dtiptEndArriveTime.Enabled = true;
                    });
                });
                task.Start();
            }
            else
            {
                btnStartTurnover.Enabled = true;
                btnAddTrainCarriagePass.Enabled = false;
                dtiptStartArriveTime.Enabled = true;
                dtiptEndArriveTime.Enabled = true;
            }
        }

        /// <summary>
        /// 入厂时间改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtiptStartArriveTime_ValueObjectChanged(object sender, EventArgs e)
        {
            LoadView_TrainTipperQueue();
        }

        /// <summary>
        /// 入厂时间改变事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtiptEndArriveTime_ValueObjectChanged(object sender, EventArgs e)
        {
            LoadView_TrainTipperQueue();
        }

        /// <summary>
        /// 设置为当前翻车
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddTrainCarriagePass_Click(object sender, EventArgs e)
        {
            GridRow gridRow = superGridControl_DF.PrimaryGrid.SelectedRows.OfType<GridRow>().FirstOrDefault();
            if (gridRow == null) return;

            View_TrainTipperQueue view_TrainTipperQueue = gridRow.DataItem as View_TrainTipperQueue;
            if (view_TrainTipperQueue == null) return;

            if (this.CurrentTrainCarriagePass == null
                || (this.CurrentTrainCarriagePass != null && (view_TrainTipperQueue.TrainNumber != this.CurrentTrainCarriagePass.TrainNumber
                || (view_TrainTipperQueue.TrainNumber == this.CurrentTrainCarriagePass.TrainNumber
                && MessageBoxEx.Show("此车已经处于翻车中，确定要重新设置？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))))
            {
                // 跳过车厢设置时进行提示
                if (view_TrainTipperQueue != this.view_TrainTipperQueue_DF.FirstOrDefault() && MessageBoxEx.Show("车厢[" + view_TrainTipperQueue.TrainNumber + "]不是当前队列中第一节车厢，确定要设置？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    return;

                // 插入车号识别通过记录
                if (carriageRecognitionerDAO.SaveTrainCarriagePass(this.carriageRecognitionerMachineCode, view_TrainTipperQueue.TrainNumber, DateTime.Now, eTrainPassDirection.进厂))
                {
                    Log4Neter.Info(this.trainTipper.EquipmentName + " - 设置车厢[" + view_TrainTipperQueue.TrainNumber + "]为当前翻车");
                    OutputRunInfo("设置车厢[" + view_TrainTipperQueue.TrainNumber + "]为当前翻车");
                }
                else
                    MessageBoxEx.Show("设置失败", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region SuperGridControl

        /// <summary>
        /// 格式化单元格颜色
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControl_FormatCellColor_GetCellStyle(object sender, GridGetCellStyleEventArgs e)
        {
            if (e.GridCell.GridColumn.DataPropertyName == "TrainNumber")
            {
                View_TrainTipperQueue view_TrainTipperQueue = e.GridCell.GridRow.DataItem as View_TrainTipperQueue;
                if (view_TrainTipperQueue != null) e.Style.Background.Color1 = this.dicCellColors[view_TrainTipperQueue.InFactoryBatchId + "-" + view_TrainTipperQueue.TrainSampleSchemeId];
            }
        }

        private void superGridControl_BeginEdit(object sender, GridEditEventArgs e)
        {
            // 取消编辑
            e.Cancel = true;
        }

        /// <summary>
        /// 设置行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void superGridControl_GetRowHeaderText(object sender, GridGetRowHeaderTextEventArgs e)
        {
            e.Text = (e.GridRow.RowIndex + 1).ToString();
        }

        #endregion
    }
}

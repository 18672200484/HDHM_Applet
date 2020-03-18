using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CMCS.DumblyConcealer.Win.Core;
using CMCS.Common.Utilities;
using CMCS.Common.Entities;
using CMCS.DumblyConcealer.Enums;
using CMCS.DumblyConcealer.Tasks.AutoCupboard.Entities;
using CMCS.DumblyConcealer.Tasks.AutoCupboard.Enums;
using CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Enums;
using CMCS.DumblyConcealer.Tasks.AutoCupboard;
using CMCS.DumblyConcealer.Tasks.PneumaticTransfer;
using CMCS.DumblyConcealer.Tasks.PneumaticTransfer.Entities;
using CMCS.Common;

namespace CMCS.DumblyConcealer.Win.DumblyTasks
{
    public partial class FrmAutoCupBoard_Test : TaskForm
    {
        RTxtOutputer rTxtOutputer;
        TaskSimpleScheduler taskSimpleScheduler = new TaskSimpleScheduler();
        public FrmAutoCupBoard_Test()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void FrmAutoCupBoard_NCGM_Test_Load(object sender, EventArgs e)
        {

            this.Text = "智能存样柜接口业务测试";

            this.rTxtOutputer = new RTxtOutputer(rtxtOutput);
            DataTable datatable = Dbers.GetInstance().SelfDber.ExecuteDataTable(String.Format("select t.Code from syssmtbcodecontent t where t.kindid in ( select t.id from syssmtbcodekind t where t.kind='样品类型')", Code));
            for (int i = 0; i < datatable.Rows.Count; i++)
			{
                cbYPLX.Items.Add(datatable.Rows[i][0].ToString());
			}
            cbYPLX.SelectedIndex = 0;
            cbStartPlace.DataSource = Enum.GetNames(typeof(eOp));
            cbPlace.DataSource = Enum.GetNames(typeof(eOp));

        }



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
        /// 窗体关闭后
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmAutoCupboard_NCGM_FormClosed(object sender, FormClosedEventArgs e)
        {
            // 注意：必须取消任务
            this.taskSimpleScheduler.Cancal();
        }

        private void btnheart_Click(object sender, EventArgs e)
        {
            if (((Button)sender).Text == "心跳测试")
            {
                taskSimpleScheduler.StartNewTask("心跳测试", () =>
                {
                    setheart(this.rTxtOutputer.Output);
                }, 10000, OutputError);
                ((Button)sender).Text = "停止测试";
            }
            else
            {
                ((Button)sender).Text = "心跳测试";
                this.taskSimpleScheduler.Cancal();
            }
        }

        EquAutoCupboardDAO ncgm = EquAutoCupboardDAO.GetInstance();
        EquPneumaticTransferDAO xmjs = EquPneumaticTransferDAO.GetInstance();
        public void setheart(Action<string, eOutputType> output)
        {
            int res = DcDbers.GetInstance().AutoCupboard_Dber.Execute("UPDATE DATAFLAG SET DATAFLAG=DATAFLAG+1");
            if (res > 0)
            {
                output("心跳传输成功", eOutputType.Normal);
            }
        }

        private void btnCreateCode_Click(object sender, EventArgs e)
        {
            Code.Text = DateTime.Now.ToString("yyMMddHHmmss");
            this.rTxtOutputer.Output("生成成功", eOutputType.Normal);
        }

        private void Sent_Click(object sender, EventArgs e)
        {
            String obj = ncgm.AddNewSendSampleId(Code.Text, (String)cbYPLX.SelectedValue, xmjs.ConvertToInfeOp((String)cbStartPlace.SelectedValue), xmjs.ConvertToInfeOp((String)cbPlace.SelectedValue));
            if (!String.IsNullOrEmpty(obj))
            {
                tbBox.Text = obj;
            }
        }

        private void btnstatus_Click(object sender, EventArgs e)
        {
            tbreturn.Text = ncgm.GetResult(tbBox.Text);
        }

        private void btn_qdcs(object sender, EventArgs e)
        {
            List<EquQDBill> infqdbill = DcDbers.GetInstance().PneumaticTransfer_Dber.Entities<EquQDBill>(" order by Send_Time desc");
            if (((Button)sender).Text.Contains("成功"))
            {
                infqdbill[0].DataStatus = 1;
            }
            else
            {
                infqdbill[0].DataStatus = 2;
            }
            if (DcDbers.GetInstance().PneumaticTransfer_Dber.Execute("UPDATE QD_INTERFACE_TB SET DATASTATUS=" + infqdbill[0].DataStatus + " WHERE DATASTATUS=0") > 0)
            {
                tbQDCS.Text = ((Button)sender).Text;
            }
        }

        private void btn_cyg(object sender, EventArgs e)
        {
            List<EquCYGBill> infcygbill = DcDbers.GetInstance().AutoCupboard_Dber.Entities<EquCYGBill>(" order by CZPFSSJ desc");

            List<EquCYGBillRecord> infcygbillrecords = DcDbers.GetInstance().AutoCupboard_Dber.Entities<EquCYGBillRecord>(" where billid='" + infcygbill[0].Id + "'");

            if (infcygbillrecords.Count == 0)
            {
                EquCYGBillRecord infcygbillrecord = new EquCYGBillRecord();
                infcygbillrecord.BillId = infcygbill[0].Id;
                if (((Button)sender).Text.Contains("成功"))
                {
                    infcygbillrecord.CZPJG = 1;
                }
                else
                {
                    infcygbillrecord.CZPJG = 2;
                }
                DcDbers.GetInstance().AutoCupboard_Dber.Insert(infcygbillrecord);
            }
            else
            {
                if (((Button)sender).Text.Contains("成功"))
                {
                    infcygbillrecords[0].CZPJG = 1;
                }
                else
                {
                    infcygbillrecords[0].CZPJG = 2;
                }
                DcDbers.GetInstance().AutoCupboard_Dber.Update(infcygbillrecords[0]);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<EquCYGSignal> infcygdataflags = DcDbers.GetInstance().AutoCupboard_Dber.Entities<EquCYGSignal>(" where TagName='托盘到位'");
            if (infcygdataflags.Count > 0)
            {
                if (((Button)sender).Text == "托盘到位")
                {
                    infcygdataflags[0].TagValue = 1;
                    infcygdataflags[0].UpdateTime = DateTime.Now;
                    DcDbers.GetInstance().AutoCupboard_Dber.Update(infcygdataflags[0]);
                    ((Button)sender).Text = "托盘未到位";
                }
                else
                {
                    infcygdataflags[0].TagValue = 0;
                    DcDbers.GetInstance().AutoCupboard_Dber.Update(infcygdataflags[0]);
                    ((Button)sender).Text = "托盘到位";
                }
            }
            else
            {
                if (((Button)sender).Text == "托盘到位")
                {
                    EquCYGSignal infcygdataflag = new EquCYGSignal();
                    infcygdataflag.TagName = "托盘到位";
                    infcygdataflag.TagValue = 1;
                    DcDbers.GetInstance().AutoCupboard_Dber.Insert(infcygdataflag);
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            List<EquCYGSignal> infcygdataflags = DcDbers.GetInstance().AutoCupboard_Dber.Entities<EquCYGSignal>(" where TagName='系统'");
            if (infcygdataflags.Count > 0)
            {
                if (((Button)sender).Text == "智能存样柜系统正常")
                {
                    infcygdataflags[0].TagValue = 3;
                    DcDbers.GetInstance().AutoCupboard_Dber.Update(infcygdataflags[0]);
                    ((Button)sender).Text = "智能存样柜系统异常";
                }
                else
                {
                    infcygdataflags[0].TagValue = 2;
                    DcDbers.GetInstance().AutoCupboard_Dber.Update(infcygdataflags[0]);
                    ((Button)sender).Text = "智能存样柜系统正常";
                }
            }
            else
            {
                if (((Button)sender).Text == "智能存样柜系统正常")
                {
                    EquCYGSignal infcygdataflag = new EquCYGSignal();
                    infcygdataflag.TagName = "系统";
                    infcygdataflag.TagValue = 3;
                    DcDbers.GetInstance().AutoCupboard_Dber.Insert(infcygdataflag);
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<EquQDStatus> infcygdataflags = DcDbers.GetInstance().PneumaticTransfer_Dber.Entities<EquQDStatus>("");
            if (infcygdataflags.Count > 0)
            {
                if (((Button)sender).Text == "气动传输正常")
                {
                    infcygdataflags[0].SamReady = 3;
                    DcDbers.GetInstance().AutoCupboard_Dber.Execute("UPDATE QD_STATUS_TB SET SAMREADY=3");
                    ((Button)sender).Text = "气动传输异常";
                }
                else
                {
                    infcygdataflags[0].SamReady = 1;
                    DcDbers.GetInstance().AutoCupboard_Dber.Execute("UPDATE QD_STATUS_TB SET SAMREADY=1");
                    ((Button)sender).Text = "气动传输正常";
                }
            }
            else
            {
                if (((Button)sender).Text == "气动传输正常")
                {
                    EquQDStatus infcygdataflag = new EquQDStatus();
                    infcygdataflag.SamReady = 3;
                    DcDbers.GetInstance().AutoCupboard_Dber.Insert(infcygdataflag);
                }
            }
        }


    }
}
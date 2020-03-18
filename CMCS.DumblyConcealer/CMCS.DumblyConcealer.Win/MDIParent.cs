using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CMCS.DumblyConcealer.Win.DumblyTasks;
using CMCS.DumblyConcealer.Win.Core;
using BasisPlatform.Util;

namespace CMCS.DumblyConcealer.Win
{
    public partial class MDIParent : Form
    {
        public MDIParent()
        {
            InitializeComponent();
        }

        #region 窗口

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        /// <summary>
        /// 判断任务窗体是否已开
        /// </summary>
        /// <param name="form"></param>
        /// <param name="parentForm"></param>
        /// <returns></returns>
        private bool HaveOpened(Form form, Form parentForm)
        {
            bool bReturn = true;
            foreach (Form item in parentForm.MdiChildren)
            {
                if (form.GetType().Name == item.GetType().Name)
                {
                    item.BringToFront();
                    item.Focus();
                    bReturn = false;
                    break;
                }
            }
            return bReturn;
        }

        #endregion

        private void MDIParent1_Shown(object sender, EventArgs e)
        {
            BasisPlatformUtil.StartNewTask("开机延迟启动", () =>
            {
                int minute = 5, surplus = minute;

                while (minute > 0)
                {
                    double d = minute - Environment.TickCount / 1000 / 60;
                    if (Environment.TickCount < 0 || d <= 0) break;

                    System.Threading.Thread.Sleep(60000);

                    surplus--;
                }

                //this.InvokeEx(() => { timer1.Enabled = true; });

            });
        }

        private void MDIParent1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("确认退出系统？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                }
                else
                {
                    e.Cancel = true;
                }
            }
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
        /// 任务索引
        /// </summary>
        int taskFormIndex = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {
            switch (taskFormIndex)
            {
                case 0:
                    //综合事件处理程序
                    tsmiOpenFrmDataHandler_Click(null, null);
                    break;
                case 1:
                    //同步轨道衡数据接口
                    tsmiOpenFrmWeightBridger_Click(null, null);
                    break;
                case 2:
                    //皮带秤称重数据同步程序
                    tsmiOpenFrmBeltBalancer_Click(null, null);
                    break;
                case 3:
                    //车号识别报文TCP/IP同步业务
                    tsmiOpenFrmTrainWeight_Click(null, null);
                    break;
                case 4:
                    //化验设备数据同步程序
                    tsmiOpenFrmAssayDevice_Click(null, null);
                    break;
                case 5:
                    //06.汽车机械采样机接口
                    tsmiOpenFrmCarSampler_Click(null, null);
                    break;
                case 6:
                    //07.全自动制样机接口
                    tsmiOpenFrmAutoMaker_Click(null, null);
                    break;
            }

            if (taskFormIndex == 5)
            {
                TileHorizontalToolStripMenuItem_Click(null, null);
                timer1.Stop();
            }

            taskFormIndex++;
        }

        /// <summary>
        /// 综合事件处理程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmDataHandler_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmDataHandler();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }

        /// <summary>
        /// 02.同步轨道衡数据接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmWeightBridger_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmWeightBridger();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }

        /// <summary>
        /// 03.皮带秤称重数据同步程序
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmBeltBalancer_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmBeltBalancer();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }

        /// <summary>
        /// 04.车号识别报文TCP/IP同步业务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmTrainWeight_Click(object sender, EventArgs e)
        {
            new FrmTrainDiscriminator
            {
                MdiParent = this
            }.Show();
        }

        /// <summary>
        /// 05.化验设备同步业务
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmAssayDevice_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmAssayDevice();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }

        /// <summary>
        /// 06.汽车机械采样机接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmCarSampler_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmCarSampler();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }

        /// <summary>
        /// 07.全自动制样机接口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsmiOpenFrmAutoMaker_Click(object sender, EventArgs e)
        {
            TaskForm taskForm = new FrmAutoMaker();
            if (HaveOpened(taskForm, this))
            {
                taskForm.MdiParent = this;
                taskForm.Show();
            }
        }
    }
}

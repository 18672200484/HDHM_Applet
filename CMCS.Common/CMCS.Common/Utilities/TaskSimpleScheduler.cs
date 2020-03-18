using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CMCS.Common.Utilities
{
    /// <summary>
    /// 多任务线程统一调度类
    /// </summary>
    public class TaskSimpleScheduler
    {
        private CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>
        /// CancellationTokenSource
        /// </summary>
        public CancellationTokenSource Cts
        {
            get { return cts; } 
        }

        /// <summary>
        /// 创建一个任务并立即执行
        /// </summary>
        /// <param name="taskName">任务名称</param>
        /// <param name="taskAction">任务方法</param>
        /// <param name="milliseconds">循环执行间隔，小于等于零时不循环 单位：毫秒</param>
        /// <param name="errorAction">发生异常时触发</param>
        /// <param name="errorTimeout">发生异常后的重试间隔 单位：毫秒</param> 
        public void StartNewTask(string taskName, Action taskAction, int milliseconds = 0, Action<string, Exception> errorAction = null, int errorTimeout = 60000)
        {
            Task task = new Task((a) =>
            {
                int taskInterval;

                while (!((System.Threading.CancellationToken)a).IsCancellationRequested)
                {
                    try
                    {
                        taskAction();

                        taskInterval = milliseconds;
                    }
                    catch (Exception ex)
                    {
                        taskInterval = errorTimeout;

                        if (errorAction != null) errorAction(taskName, ex);
                    }

                    if (milliseconds <= 0) return;

                    Thread.Sleep(taskInterval);
                }
            }, cts.Token);

            task.Start();
        }

        /// <summary>
        /// 取消所有任务
        /// </summary>
        public void Cancal()
        {
            this.cts.Cancel();
        } 
    }
}

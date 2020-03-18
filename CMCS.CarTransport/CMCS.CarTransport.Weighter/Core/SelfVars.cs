using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CMCS.Common.Entities;
using CMCS.CarTransport.Weighter.Frms.Sys;
using CMCS.Common.Entities.iEAA;
using System.IO;

namespace CMCS.CarTransport.Weighter.Core
{
    /// <summary>
    /// 变量集合
    /// </summary>
    public static class SelfVars
    {
        /// <summary>
        /// 主窗体引用
        /// </summary>
        public static FrmMainFrame MainFrameForm;

        /// <summary>
        /// 抓拍照片本地存储路径
        /// </summary>
        public static string CapturePicturePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Camera");
    }
}

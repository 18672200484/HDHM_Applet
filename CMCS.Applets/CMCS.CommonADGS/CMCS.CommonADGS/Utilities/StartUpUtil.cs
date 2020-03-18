using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using System.IO;

namespace CMCS.CommonADGS.Utilities
{
    /// <summary>
    /// 开机启动类
    /// </summary>
    public static class StartUpUtil
    {
        /// <summary>
        /// 添加开机启动
        /// </summary>
        /// <param name="name">键</param>
        /// <param name="filepath">程序路径</param>
        public static void InsertStartUp(string name, string filepath)
        {
            if (!File.Exists(filepath))
                return;

            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (Rkey == null)
                Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");

            Rkey.SetValue(name, filepath);
        }

        /// <summary>
        /// 删除开机启动
        /// </summary>
        /// <param name="name">键</param>
        public static void DeleteStartUp(string name)
        {
            Microsoft.Win32.RegistryKey Rkey = Microsoft.Win32.Registry.LocalMachine.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
            Rkey.DeleteValue(name, false);
        }
    }
}

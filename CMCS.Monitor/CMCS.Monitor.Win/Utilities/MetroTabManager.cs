using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Metro;

namespace CMCS.Monitor.Win.Utilities
{
    /// <summary>
    /// MetroTab 辅助类
    /// </summary>
    public class MetroTabManager
    {
        private MetroShell metroShell;

        public MetroShell MetroShell
        {
            get { return metroShell; }
        }

        public MetroTabManager(MetroShell metroShell)
        {
            this.metroShell = metroShell;
        }

        private void Init()
        {

        }

        /// <summary> 
        /// 添加一个选项卡 
        /// </summary> 
        /// <param name="tabName">选项卡标题</param>  
        /// <param name="uniqueKey">唯一标识符，用于区别于其他选项卡</param> 
        /// <param name="form">要被添加到选项卡的窗体</param> 
        /// <param name="isSelected">是否选中</param> 
        /// <param name="isFill">是否填满</param> 
        public void CreateTab(string tabName, string uniqueKey, Form form, bool isSelected, bool isFill)
        {
            MetroTabItem metroTabItem = GetMetroTabItem(uniqueKey);
            if (metroTabItem == null)
            {
                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                if (isFill)
                    form.Dock = DockStyle.Fill;
                else
                    form.Dock = DockStyle.None;


                metroTabItem = metroShell.CreateTab(tabName, tabName);
                metroTabItem.GlobalName = uniqueKey;

                metroTabItem.Panel.AutoScroll = true;
                if (!isFill) metroTabItem.Panel.SizeChanged += new EventHandler(Panel_SizeChanged);
                metroTabItem.Panel.Controls.Add(form);
            }

            if (isSelected) metroTabItem.Select();
        }

        /// <summary>
        /// 大小改变时，调整窗体位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Panel_SizeChanged(object sender, EventArgs e)
        {
            MetroTabPanel metroTabPanel = sender as MetroTabPanel;

            Form form = metroTabPanel.Controls.OfType<Form>().FirstOrDefault();
            if (form == null) return;

            int x = 0, y = 0;
            if (form.Size.Width < metroTabPanel.Size.Width)
                x = (metroTabPanel.Size.Width - form.Size.Width) / 2;

            if (form.Size.Height < metroTabPanel.Size.Height)
                y = (metroTabPanel.Size.Height - form.Size.Height) / 2;

            form.Location = new Point(x, y);

            metroTabPanel.AutoScroll = (form.Size.Width > metroTabPanel.Size.Width || form.Size.Height > metroTabPanel.Size.Height);
        }

        /// <summary> 
        /// 判断SuperTabControl是否已经存在某选项卡
        /// </summary> 
        /// <param name="uniqueKey">唯一标识符，用于区别于其他选项卡</param>  
        /// <returns></returns> 
        private MetroTabItem GetMetroTabItem(string uniqueKey)
        {
            return this.metroShell.Items.OfType<MetroTabItem>().FirstOrDefault(a => a.GlobalName == uniqueKey);
        }

        /// <summary>
        /// 关闭选项卡
        /// </summary>
        /// <param name="uniqueKey">唯一标识符</param>
        public void CloseTab(string uniqueKey)
        {
            IEnumerable<MetroTabItem> metroTabItems = this.metroShell.Items.OfType<MetroTabItem>();
            if (metroTabItems.Count() == 1)
            {
                MessageBoxEx.Show("至少保留一个选项卡", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MetroTabItem metroTabItem = GetMetroTabItem(uniqueKey);
            if (metroTabItem == null) return;

            IEnumerable<Form> forms = metroTabItem.Panel.Controls.OfType<Form>();
            foreach (Form form in forms)
            {
                form.Close();
            }

            this.metroShell.Items.Remove(metroTabItem);
            // 选择最后一个MetroTabItem
            this.metroShell.SelectedTab = this.metroShell.Items.OfType<MetroTabItem>().LastOrDefault();
        }
    }
}

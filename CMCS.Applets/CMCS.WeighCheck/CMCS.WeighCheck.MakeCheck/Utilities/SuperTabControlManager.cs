using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//
using DevComponents.DotNetBar;
using System.Windows.Forms;
using System.Drawing;
using DevComponents.DotNetBar.Rendering;

namespace CMCS.WeighCheck.MakeCheck.Utilities
{
    /// <summary>
    /// SuperTabControl管理类
    /// </summary>
    public class SuperTabControlManager
    {
        private SuperTabControl superTabControl;

        public SuperTabControl SuperTabControl
        {
            get { return superTabControl; }
        }

        public SuperTabControlManager(SuperTabControl superTabControl)
        {
            this.superTabControl = superTabControl;
        }

        private void Init()
        {
            this.superTabControl.TabItemClose += new EventHandler<SuperTabStripTabItemCloseEventArgs>(superTabControl_TabItemClose);
        }

        /// <summary>
        /// 选项卡关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void superTabControl_TabItemClose(object sender, SuperTabStripTabItemCloseEventArgs e)
        {
            IEnumerable<Form> forms = (e.Tab as SuperTabItem).AttachedControl.Controls.OfType<Form>();
            foreach (Form form in forms)
            {
                form.Close();
            }
        }

        /// <summary> 
        /// 添加一个选项卡 
        /// </summary> 
        /// <param name="tabName">选项卡标题</param>  
        /// <param name="uniqueKey">唯一标识符，用于区别于其他选项卡</param> 
        /// <param name="form">要被添加到选项卡的窗体</param> 
        /// <param name="isFill">是否填满</param> 
        /// <param name="closeButtonVisible">显示关闭选项卡按钮</param> 
        public void CreateTab(string tabName, string uniqueKey, Form form, bool isFill, bool closeButtonVisible)
        {
            SuperTabItem superTabItem = GetTab(uniqueKey);
            if (superTabItem == null)
            {
                superTabItem = this.superTabControl.CreateTab(tabName);
                superTabItem.GlobalItem = true;
                superTabItem.GlobalName = uniqueKey;
                superTabItem.CloseButtonVisible = closeButtonVisible;
                superTabItem.TextAlignment = eItemAlignment.Center;

                SuperTabControlPanel superTabControlPanel = superTabItem.AttachedControl as SuperTabControlPanel;
                // 当窗体尺寸超过本身时显示滚动条
                superTabControlPanel.AutoScroll = true;
                //superTabControlPanel.PanelColor.Default = new SuperTabPanelItemColorTable()
                //{
                //    Background = new SuperTabLinearGradientColorTable()
                //    {
                //        Colors = new Color[] { Color.White }
                //    }
                //}; 

                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                if (isFill)
                    form.Dock = DockStyle.Fill;
                else
                {
                    form.Dock = DockStyle.None;
                    superTabControlPanel.SizeChanged += new EventHandler(superTabControlPanel_SizeChanged);
                }

                superTabItem.AttachedControl.Controls.Add(form);

            }

            // 设为当前选中的选项 
            this.superTabControl.SelectedTab = superTabItem;
        }

        /// <summary>
        /// 大小改变时，调整窗体位置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void superTabControlPanel_SizeChanged(object sender, EventArgs e)
        {
            SuperTabControlPanel superTabControlPanel = sender as SuperTabControlPanel;

            Form form = superTabControlPanel.Controls[0] as Form;
            if (form == null) return;

            int x = 0, y = 0;
            if (form.Size.Width < superTabControlPanel.Size.Width)
                x = (superTabControlPanel.Size.Width - form.Size.Width) / 2;

            if (form.Size.Height < superTabControlPanel.Size.Height)
                y = (superTabControlPanel.Size.Height - form.Size.Height) / 2;

            form.Location = new Point(x, y);

            superTabControlPanel.AutoScroll = (form.Size.Width > superTabControlPanel.Size.Width || form.Size.Height > superTabControlPanel.Size.Height);
        }

        /// <summary> 
        /// 判断SuperTabControl是否已经存在某选项卡
        /// </summary> 
        /// <param name="uniqueKey">唯一标识符，用于区别于其他选项卡</param>  
        /// <returns></returns> 
        public SuperTabItem GetTab(string uniqueKey)
        {
            foreach (SuperTabItem superTabItem in this.superTabControl.Tabs)
            {
                if (superTabItem.GlobalName == uniqueKey) return superTabItem;
            }

            return null;
        }

        /// <summary>
        /// 切换到指定选项卡
        /// </summary>
        /// <param name="uniqueKey">唯一标识符，用于区别于其他选项卡</param>
        public void ChangeToTab(string uniqueKey)
        {
            SuperTabItem superTabItem = GetTab(uniqueKey);
            if (superTabItem != null) this.superTabControl.SelectedTab = superTabItem;
        }
    }
}

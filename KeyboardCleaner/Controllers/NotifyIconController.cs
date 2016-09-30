using InputBlocker.Interfaces;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace InputBlocker.Controllers
{
    class NotifyIconController : INotifyIconController
    {
        private NotifyIcon notifyIcon;
        private ContextMenu contextMenu;
        
        public void InitContextMenu(params EventHandler[] menuStripClicks)
        {
            ContextMenu c = new ContextMenu();
            c.MenuItems.Add("Block Now");
            c.MenuItems[0].Click += menuStripClicks[0];
            c.MenuItems.Add("-");
            c.MenuItems.Add("About");
            c.MenuItems[2].Click += menuStripClicks[1];
            c.MenuItems.Add("Exit");
            c.MenuItems[3].Click += menuStripClicks[2];
            contextMenu = c;
        }

        public void InitNotifyIcon(Icon image, MouseEventHandler doubleClick)
        {
            notifyIcon = new NotifyIcon() { Icon = image };
            notifyIcon.MouseDoubleClick += doubleClick;
            notifyIcon.ContextMenu = contextMenu;
        }

        public NotifyIcon AccessNotifyIcon()
        {
            if (notifyIcon == null)
                throw new NullReferenceException("The NotifyIcon has not been initialized! ");
            else
                return notifyIcon;
        }

        public void HideNotifyIcon()
        {
            if (notifyIcon != null)
                notifyIcon.Visible = false;
        }

        public void ShowNotifyIcon()
        {
            if (notifyIcon != null)
                notifyIcon.Visible = true;
        }
    }
}

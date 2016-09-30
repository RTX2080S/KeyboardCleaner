using System;
using System.Drawing;
using System.Windows.Forms;

namespace InputBlocker.Interfaces
{
    interface INotifyIconController
    {
        void InitContextMenu(params EventHandler[] menuStripClicks);
        void InitNotifyIcon(Icon image, MouseEventHandler doubleClick);
        NotifyIcon AccessNotifyIcon();
        void ShowNotifyIcon();
        void HideNotifyIcon();
    }
}

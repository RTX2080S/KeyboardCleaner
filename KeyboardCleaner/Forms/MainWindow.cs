using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace InputBlocker
{

    public partial class MainWindow : Form
    {

        private AppCore kernel;

        public MainWindow()
        {
            InitializeComponent();
            Text = ProductName;
            kernel = new AppCore();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private NotifyIcon myNotifyIcon = null;
        private bool notifyIconCreated = false;

        private void InitUI()
        {
            this.Icon = Properties.Resources.mainIcon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toNotifyIcon();
            kernel.BlockAllInput();
        }

        private void toNotifyIcon()
        {
            if (!notifyIconCreated)
                createNotifyIcon();
            else
                myNotifyIcon.Visible = true;
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void createNotifyIcon()
        {
            myNotifyIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.mainIcon,
            };

            ContextMenu c = new ContextMenu();
            c.MenuItems.Add("Block Now");
            c.MenuItems[0].Click += MenuStrip0_Click;
            c.MenuItems.Add("-");
            c.MenuItems.Add("About");
            c.MenuItems[2].Click += MenuStrip2_Click;
            c.MenuItems.Add("Exit");
            c.MenuItems[3].Click += MenuStrip1_Click;
            myNotifyIcon.ContextMenu = c;
            myNotifyIcon.MouseDoubleClick += myNotifyIcon_MouseDoubleClick;
            notifyIconCreated = myNotifyIcon.Visible = true;
        }

        private void MenuStrip2_Click(object sender, EventArgs e)
        {
            showAbout();
        }

        private void showAbout()
        {
            AboutBox myAbout = new AboutBox();
            myAbout.Show();
        }

        void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            myNotifyIcon.Visible = false;
        }

        private void MenuStrip1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MenuStrip0_Click(object sender, EventArgs e)
        {
            kernel.BlockAllInput();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showAbout();
        }

        private void MainWindow_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
                toNotifyIcon();
        }
    }
}

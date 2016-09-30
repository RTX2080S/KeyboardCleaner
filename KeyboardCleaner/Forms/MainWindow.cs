using InputBlocker.Controllers;
using InputBlocker.Interfaces;
using System;
using System.Windows.Forms;

namespace InputBlocker
{

    public partial class MainWindow : Form
    {
        private ICoreController kernel;
        private INotifyIconController myNotifyIcon;

        public MainWindow()
        {
            InitializeComponent();
            kernel = new CoreController();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            InitUI();
        }

        private void InitUI()
        {
            Icon = Properties.Resources.mainIcon;
            Text = ProductName;

            // Initialize NotifyIcon
            myNotifyIcon = new NotifyIconController();
            myNotifyIcon.InitContextMenu(MenuStrip0_Click, MenuStrip2_Click, MenuStrip1_Click);
            myNotifyIcon.InitNotifyIcon(Properties.Resources.mainIcon, myNotifyIcon_MouseDoubleClick);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toNotifyIcon();
            kernel.BlockAllInput();
        }

        private void toNotifyIcon()
        {
            myNotifyIcon.ShowNotifyIcon();
            WindowState = FormWindowState.Minimized;
            Hide();
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

        public void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            WindowState = FormWindowState.Normal;
            myNotifyIcon.HideNotifyIcon();
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

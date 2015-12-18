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
        private NotifyIcon myNotifyIcon = null;
        private bool notifyIconCreated = false;

        public MainWindow()
        {
            InitializeComponent();
            kernel = new AppCore();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitUI();
        }

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
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            if (!notifyIconCreated)
                myNotifyIcon = getNotifyIcon();
            else
                myNotifyIcon.Visible = true;
        }

        private NotifyIcon getNotifyIcon()
        {
            ContextMenu c = new ContextMenu();
            c.MenuItems.Add("Block Now");
            c.MenuItems[0].Click += MenuStrip0_Click;
            c.MenuItems.Add("About");
            c.MenuItems[1].Click += MenuStrip2_Click;
            c.MenuItems.Add("Exit");
            c.MenuItems[2].Click += MenuStrip1_Click;

            NotifyIcon resultIcon = new NotifyIcon()
            {
                Icon = Properties.Resources.mainIcon,
                ContextMenu = c,
                Visible = true
            };

            resultIcon.MouseDoubleClick += myNotifyIcon_MouseDoubleClick;
            return resultIcon;
        }

        void myNotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
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
        
        private void MenuStrip2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, ProductName + " [Version " + ProductVersion + "] \n\n"
                + CompanyName, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        
        private void MainWindow_Shown(object sender, EventArgs e)
        {
            toNotifyIcon();
        }

    }
}

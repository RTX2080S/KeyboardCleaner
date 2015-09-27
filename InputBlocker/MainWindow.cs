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

        [DllImport("user32.dll")]
        static extern void BlockInput(bool Block);

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
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
            BlockInput(true);
        }

        private void toNotifyIcon()
        {
            this.WindowState = FormWindowState.Minimized;
            this.Hide();
            if (!notifyIconCreated)
                createNotifyIcon();
            else
                myNotifyIcon.Visible = true;
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
            c.MenuItems.Add("About");
            c.MenuItems[1].Click += MenuStrip2_Click;
            c.MenuItems.Add("Exit");
            c.MenuItems[2].Click += MenuStrip1_Click;
            myNotifyIcon.ContextMenu = c;
            myNotifyIcon.MouseDoubleClick += myNotifyIcon_MouseDoubleClick;
            myNotifyIcon.Visible = true;            
        }

        private void MenuStrip2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(this, ProductName + " [Version " + ProductVersion + "] \n\n"
                + CompanyName, ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            BlockInput(true);
        }

        private void MainWindow_Shown(object sender, EventArgs e)
        {
            toNotifyIcon();
        }

    }
}

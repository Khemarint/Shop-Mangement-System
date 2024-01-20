using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computer;
using Guna.UI2.WinForms;
using System.Runtime.InteropServices;

namespace Computer_Shop.PAL
{
    public partial class FormMain : Form
    {
        public string name = "{?}";
        public FormLogin LoginForm { get; set; }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.WindowState = FormWindowState.Minimized;
                return true; // Indicate that you have handled this key
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        public FormMain()
        {
            InitializeComponent();
        }
     

        private void MovePanel(Control btn)
        {
            pnlMove.Top = btn.Top;
            pnlMove.Height = btn.Height;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblUsername.Text = name;
            timerDateAndTime.Start();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you want to log out?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                MovePanel(btnClose);
                this.DialogResult = DialogResult.OK;
                this.Close();
                Application.OpenForms["FormLogin"].Show();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            MovePanel(btnDashboard);
            userControlBrand1.Visible = false;
            userControlDashboard1.Visible = true;
            userControlCategory1.Visible = false;
            //pnlCenter.Controls.Clear();
            //test abc = new test();
            //abc.TopMost = true;
            //abc.TopLevel = false;

            //pnlCenter.Controls.Add(abc);
            //abc.Show();
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            MovePanel(btnBrand);
            userControlDashboard1.Visible = false;
            userControlCategory1.Visible = false;
            userControlBrand1.EmptyBox();
            userControlBrand1.Visible = true;
            //pnlCenter.Controls.Clear();
            //UserControlBrand abc = new UserControlBrand();

            //pnlCenter.Controls.Add(abc);
            //abc.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            MovePanel(btnCategory);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.EmptyBox();
            userControlCategory1.Visible = true;
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            MovePanel(btnProduct);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible=false;
        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            MovePanel(btnOrders);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MovePanel(btnReport);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MovePanel(btnUsers);
            userControlDashboard1.Visible = false;
            userControlBrand1.Visible = false;
            userControlCategory1.Visible = false;
        }
    }
}

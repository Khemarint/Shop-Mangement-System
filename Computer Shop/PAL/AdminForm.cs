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
using System.IO;

namespace Computer_Shop.PAL
{
    public partial class AdminForm : Form
    {
        //public string name = "{?}";
        public string userName;
        public string userGender;
        public string userEmail;
        public byte[] userImage;
      

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


        public AdminForm(string userName, string userGender, string userEmail, byte[] userImage)
        {
            InitializeComponent();
            this.userName = userName;
            this.userGender = userGender;
            this.userEmail = userEmail;
            this.userImage = userImage;
        }

        private void MovePanel(Control btn)
        {
            pnlMove.Top = btn.Top;
            pnlMove.Height = btn.Height;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            lblUsername.Text = this.userName;
            lblGender.Text = this.userGender;
            lblEmail.Text = this.userEmail;
            using (MemoryStream ms = new MemoryStream(this.userImage))
            {
                picProfile.Image = Image.FromStream(ms);
            }


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
            userControlBrand2.Visible = false;
            userControlDashboard2.Visible = true;
            userControlCategory2.Visible = false;
            userControlProduct2.Visible = false;
            userControlOrder2.Visible = false;
            userControlReport2.Visible = false;
            userControlDashboard2.Count();
            userControlUser1.Visible = false;
        }

        private void btnBrand_Click(object sender, EventArgs e)
        {
            MovePanel(btnBrand);
            userControlDashboard2.Visible = false;
            userControlCategory2.Visible = false;
            userControlBrand2.EmptyBox();
            userControlBrand2.Visible = true;
            userControlProduct2.Visible = false;
            userControlOrder2.Visible = false;
            userControlReport2.Visible = false;
            userControlUser1.Visible = false;

            //pnlCenter.Controls.Clear();
            //UserControlBrand abc = new UserControlBrand();

            //pnlCenter.Controls.Add(abc);
            //abc.Show();
        }

        private void btnCategory_Click(object sender, EventArgs e)
        {
            MovePanel(btnCategory);
            userControlDashboard2.Visible = false;
            userControlBrand2.Visible = false;
            userControlCategory2.EmptyBox();
            userControlCategory2.Visible = true;
            userControlProduct2.Visible = false;
            userControlOrder2.Visible = false;
            userControlReport2.Visible = false;
            userControlUser1.Visible = false;


        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            MovePanel(btnProduct);
            userControlDashboard2.Visible = false;
            userControlBrand2.Visible = false;
            userControlCategory2.Visible=false;
            userControlProduct2.EmptyBox();
            userControlProduct2.Visible=true;
            userControlOrder2.Visible = false;
            userControlReport2.Visible=false;
            userControlUser1.Visible = false;


        }

        private void btnOrders_Click(object sender, EventArgs e)
        {
            MovePanel(btnOrders);
            userControlDashboard2.Visible = false;
            userControlBrand2.Visible = false;
            userControlCategory2.Visible = false;
            userControlProduct2.Visible = false;
            userControlOrder2.Visible = true;
            userControlOrder2.EmptyBox();
            userControlReport2.Visible = false;
            userControlUser1.Visible = false;


        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            MovePanel(btnReport);
            userControlDashboard2.Visible = false;
            userControlBrand2.Visible = false;
            userControlCategory2.Visible = false;
            userControlProduct2.Visible=false;
            userControlOrder2.Visible = false;
            userControlReport2.Visible = true;
            userControlUser1.Visible = false;

        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            MovePanel(btnUsers);
            userControlDashboard2.Visible = false;
            userControlBrand2.Visible = false;
            userControlCategory2.Visible = false;
            userControlProduct2.Visible=false;
            userControlOrder2.Visible = false;
            userControlReport2.Visible = false;
            userControlUser1.Visible = true;
         
        }

        private void userControlUser1_Load(object sender, EventArgs e)
        {

        }
    }
}

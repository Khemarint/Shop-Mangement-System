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

namespace Computer_Shop.PAL
{
    public partial class FormForgotPassword : Form
    {
      
        public FormForgotPassword()
        {
            InitializeComponent();
        }

     
        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "JohnDoe")
            {
                txtUsername.Text = "";
            }
        }

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "johndoe@example.com")
            {
                txtEmail.Text = "";
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string pass = Computer.Computer.ForgotPassword(txtUsername.Text.Trim(), txtEmail.Text.Trim());
                if (pass != string.Empty)
                {
                    MessageBox.Show($"Your Password is: {pass}", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                    Close();
                }
                else
                {
                    MessageBox.Show("Username or Email is incorrect.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FormForgotPassword_Load(object sender, EventArgs e)
        {

        }
    }
}

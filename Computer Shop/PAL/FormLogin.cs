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
    public partial class FormLogin : Form
    {
        

        public FormLogin()
        {
            InitializeComponent();
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text == "Username")
            {
                txtUsername.Text = "";
            }
        }

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }



        private void EmptyBox()
        {
            txtUsername.Clear();
            txtPassword.Clear();
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void picShow_Click(object sender, EventArgs e)
        {
            if(picShow.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = false;
                picShow.Visible = false;
                picHide.Visible = true;
            }
        }

        private void picHide_Click(object sender, EventArgs e)
        {
            if (picHide.Visible == true)
            {
                txtPassword.UseSystemPasswordChar = true;
                picShow.Visible = true;
                picHide.Visible = false;
            }
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                bool check = Computer.Computer.IsValidNamePass(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (check)
                {
                    FormMain formMain = new FormMain();
                    string username = txtUsername.Text;
                    username = char.ToUpper(username[0]) + username.Substring(1); // Capitalize the first letter
                    formMain.name = username;
                    this.Hide();
                    formMain.ShowDialog();


                }
                else
                {

                    MessageBox.Show("Username or Passowrd is incorrect", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void lbForgetPassword_Click(object sender, EventArgs e)
        {
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }

    }
}

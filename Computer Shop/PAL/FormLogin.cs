using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computer;

namespace Computer_Shop.PAL
{
    public partial class FormLogin : Form
    {

        private DataRow userDetails;

        // Add a method to get the user details
        public DataRow GetUserDetails()
        {
            return userDetails;
        }
        public FormLogin()
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

        private void txtPassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "123")
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
            if (picShow.Visible == true)
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

        private void lbForgetPassword_Click(object sender, EventArgs e)
        {
            FormForgotPassword formForgotPassword = new FormForgotPassword();
            formForgotPassword.ShowDialog();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {

        }



        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text.Trim() == string.Empty)
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
                DataRow userDetails = Computer.Computer.IsValidNamePass(txtUsername.Text.Trim(), txtPassword.Text.Trim());
                if (userDetails != null)
                {
                    string userName = userDetails["Users_Name"].ToString();
                    string userGender = userDetails["Users_Gender"].ToString();
                    string userEmail = userDetails["Users_Email"].ToString();
                    byte[] userImage = (byte[])userDetails["User_Image"];
                    bool isAdmin = userDetails["IsAdmin"] == DBNull.Value ? false : Convert.ToBoolean(userDetails["IsAdmin"]);
                    if (isAdmin)
                    {
                        // Open the admin form
                        AdminForm adminForm = new AdminForm(userName, userGender, userEmail,userImage);
                        adminForm.Show();
                    }
                    else
                    {
                        // Create an instance of the main form
                        FormMain formMain = new FormMain(userName, userGender, userEmail,userImage);

                        // Hide the login form
                        this.Hide();

                        // Show the main form
                        formMain.ShowDialog();

                        // Close the login form
                        this.Show();

                    }
                }
                else
                {
                    MessageBox.Show("Username or Password is incorrect", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
     

    }
}

using Computer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Computer_Shop.PAL
{
    public partial class UserControlUser : UserControl
    {
        private string id = "";
        public UserControlUser()
        {
            InitializeComponent();
        }

        public void EmptyBox()
        {
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
        }

        private void EmptyBox1()
        {
            txtUsername1.Clear();
            txtEmail1.Clear();
            txtPassword1.Clear();
            id = "";
        }

        private void picSearch_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(picSearch, "Search");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information); 
                return;
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Email.","Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                User user = new User (txtUsername.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim());
                Computer.Computer.AddUser(user);
                EmptyBox();
            }
        }

       

        private void tpManageUser_Enter (object sender , EventArgs e)
        {
            txtSearchUserName.Clear();
            Computer.Computer.DisplayAndSearch("SELECT * FROM Users;", dgvUser);
            lblTotal.Text = dgvUser.Rows.Count.ToString();
            dgvUser.Columns["Users_Id"].DisplayIndex = 0;
            dgvUser.Columns[0].Visible = false;
        }

        private void txtSearchUserName_TextChange(object sender, EventArgs e)
        {
            Computer.Computer.DisplayAndSearch("SELECT * FROM Users WHERE Users_Name LIKE '%" + txtSearchUserName.Text + "%';" , dgvUser);
            lblTotal.Text = dgvUser.Rows.Count.ToString();
           
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridViewRow row = dgvUser.Rows[e.RowIndex];
                id = row.Cells[0].Value.ToString();
                txtUsername1.Text = row.Cells[1].Value.ToString();
                txtEmail1.Text = row.Cells[2].Value.ToString();
                txtPassword1.Text = row.Cells[3].Value.ToString();
                tcUser.SelectedTab = tpOption;

            }
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please select row from table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtUsername1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                User user = new User(txtUsername1.Text.Trim(), txtEmail1.Text.Trim(), txtPassword1.Text.Trim());
                Computer.Computer.ChangeUser(user, id);
                EmptyBox1();
                tcUser.SelectedTab = tpManageUser;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (id == "")
            {
                MessageBox.Show("Please select row from table.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtUsername1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you want to delete this User?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    Computer.Computer.RemoveUser(id);
                    EmptyBox1();
                    tcUser.SelectedTab = tpManageUser;
                }
            }
        }

        private void tpOption_Enter(object sender, EventArgs e)
        {
            if(id == "")
            {
                tcUser.SelectedTab = tpManageUser;
            }
        }

        private void tpOption_Leave(object sender, EventArgs e)
        {
            EmptyBox1();
        }

        private void tpAddUser_Enter(object sender, EventArgs e)
        {
            EmptyBox();
        }
    }
}

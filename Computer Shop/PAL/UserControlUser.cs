using Computer;
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

namespace Computer_Shop.PAL
{
    public partial class UserControlUser : UserControl
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        private string id = "";
        byte[] image;
        ImageConverter imageConverter;
        MemoryStream memoryStream;
        public UserControlUser()
        {
            InitializeComponent();
            imageConverter = new ImageConverter();
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            ImageUpload(picPhoto1);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            ImageUpload(picPhoto);
        }
        private void ImageUpload(PictureBox picture)
        {
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    picture.Image = Image.FromFile(openFileDialog.FileName);
                    image = (byte[])imageConverter.ConvertTo(picture.Image, typeof(byte[]));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Image upload error!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        public void EmptyBox()
        {
            DateOfBirth.Value = DateTime.Now;
            txtUsername.Clear();
            txtEmail.Clear();
            txtPassword.Clear();
            mtbPhoneNumber.Clear();
            rdbMale.Checked = false;
            rdbFemale.Checked = false;
            cmbAddress.SelectedIndex = 0;
            rdoUser.Checked = false;
            rdoAdmin.Checked = false;
            picPhoto.Image = null;
        }

        private void EmptyBox1()
        {
            picPhoto1.Image = null;
            cmbAddress1.SelectedIndex = 0;
            rdoUser1.Checked = false;
            rdoAdmin1.Checked = false ;
            mtbPhoneNumber1.Clear();
            DateOfBirth1.Value = DateTime.Now;
            rdbMale1.Checked = false;
            rdbFemale1.Checked = false;
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
            if (txtUsername.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Username.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtEmail.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Email.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Password.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (cmbAddress.SelectedIndex == 0)
            {
                MessageBox.Show("Please select Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (DateOfBirth.Value == DateTime.Now) // Assuming dtpDateOfBirth is your DateTimePicker control for DateOfBirth
            {
                MessageBox.Show("Please select Date of Birth.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (picPhoto.Image == null)
            {
                MessageBox.Show("Please select Image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!rdbMale.Checked && !rdbFemale.Checked)
            {
                MessageBox.Show("Please select Gender.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!rdoUser.Checked && !rdoAdmin.Checked)
            {
                MessageBox.Show("Please select Role.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (mtbPhoneNumber.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Phone Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string gender = rdbMale.Checked ? "Male" : "Female";
                bool? isAdmin = null;
                if (rdoUser.Checked)
                {
                    isAdmin = false;
                }
                else if (rdoAdmin.Checked)
                {
                    isAdmin = true;
                }
               
                User user = new User(txtUsername.Text.Trim(), txtEmail.Text.Trim(), txtPassword.Text.Trim(), cmbAddress.SelectedItem.ToString(), DateOfBirth.Value.Date, gender, mtbPhoneNumber.Text, isAdmin, (byte[])imageConverter.ConvertTo(picPhoto.Image, typeof(byte[]))); // Add 'image' here
                Computer.Computer.AddUser(user);
                EmptyBox();
            }
        }


      

       

        private void tpManageUser_Enter (object sender , EventArgs e)
        {
            txtSearchUserName.Clear();
            Computer.Computer.DisplayAndSearch("SELECT * FROM Users;", dgvUser);
            lblTotal.Text = dgvUser.Rows.Count.ToString();
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
                cmbAddress1.Text = row.Cells[4].Value.ToString();
                DateOfBirth1.Text = row.Cells[5].Value.ToString();
                if (row.Cells[6].Value.ToString() == "Male")
                {
                    rdbMale1.Checked = true;
                }
                else
                {
                    rdbFemale1.Checked = true;
                }
                mtbPhoneNumber1.Text = row.Cells[7].Value.ToString();

                // Check the IsAdmin column and set the radio buttons
                if (row.Cells[8].Value != null && bool.TryParse(row.Cells[8].Value.ToString(), out bool isAdmin))
                {
                    rdoAdmin1.Checked = isAdmin;
                    rdoUser1.Checked = !isAdmin;
                }
                else
                {
                    // Handle the case where the value is null or not a valid boolean
                    // For example, you might want to uncheck both radio buttons
                    rdoAdmin1.Checked = false;
                    rdoUser1.Checked = false;
                }
                image = (byte[])row.Cells[9].Value;
                memoryStream = new MemoryStream(image);
                picPhoto1.Image = Image.FromStream(memoryStream);
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
            else if (picPhoto1.Image == null)
            {
                MessageBox.Show("Please select Image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (cmbAddress1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (DateOfBirth1.Value == DateTime.Now) // Assuming dtpDateOfBirth is your DateTimePicker control for DateOfBirth
            {
                MessageBox.Show("Please select Date of Birth.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            else if (!rdbMale1.Checked && !rdbFemale1.Checked)
            {
                MessageBox.Show("Please select Gender.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (mtbPhoneNumber1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Phone Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!rdoUser1.Checked && !rdoAdmin1.Checked)
            {
                MessageBox.Show("Please select Role.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                string gender = rdbMale1.Checked ? "Male" : "Female";

                bool? isAdmin = null;
                if (rdoUser1.Checked)
                {
                    isAdmin = false;
                }
                else if (rdoAdmin1.Checked)
                {
                    isAdmin = true;
                }
                
                User user = new User(txtUsername1.Text.Trim(), txtEmail1.Text.Trim(), txtPassword1.Text.Trim(), cmbAddress1.SelectedItem.ToString(), DateOfBirth1.Value.Date, gender, mtbPhoneNumber1.Text, isAdmin, (byte[])imageConverter.ConvertTo(picPhoto1.Image, typeof(byte[]))); // Add 'image' here
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


            else if (cmbAddress1.SelectedIndex == 0)
            {
                MessageBox.Show("Please enter Address.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            else if (!rdbMale1.Checked && !rdbFemale1.Checked)
            {
                MessageBox.Show("Please select Gender.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (DateOfBirth1.Value == DateTime.Now) // Assuming dtpDateOfBirth is your DateTimePicker control for DateOfBirth
            {
                MessageBox.Show("Please select Date of Birth.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (picPhoto1.Image == null)
            {
                MessageBox.Show("Please select Image.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (mtbPhoneNumber1.Text.Trim() == string.Empty)
            {
                MessageBox.Show("Please enter Phone Number.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else if (!rdoUser1.Checked && !rdoAdmin1.Checked)
            {
                MessageBox.Show("Please select Role.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this User?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
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

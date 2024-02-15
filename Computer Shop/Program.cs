using Computer_Shop.PAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Computer;
using System.Drawing;
using System.IO;

namespace Computer_Shop
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            FormLogin loginForm = new FormLogin();
            while (true)
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    DataRow userDetails = loginForm.GetUserDetails();
                    if (userDetails != null)
                    {
                        string userName = userDetails["Users_Name"].ToString();
                        string userGender = userDetails["Users_Gender"].ToString();
                        string userEmail = userDetails["Users_Email"].ToString();
                        byte[] userImage = (byte[])userDetails["User_Image"];

                        // Create an instance of the main form
                        FormMain mainForm = new FormMain(userName, userGender, userEmail, userImage); // Pass 'userImage' here

                        // Show the main form
                        if (mainForm.ShowDialog() == DialogResult.OK)
                        {
                            // Log out and show the login form again
                            loginForm = new FormLogin();
                            continue;
                        }
                        else
                        {
                            // Exit the application
                            break;
                        }
                    }
                }
                else
                {
                    // Exit the application
                    break;
                }
            }
        }



    }
}

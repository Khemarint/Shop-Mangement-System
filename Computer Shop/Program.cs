using Computer_Shop.PAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            while (true)
            {
                FormLogin loginForm = new FormLogin();
                if (loginForm.ShowDialog() != DialogResult.OK)
                {
                    break; // Exit the application
                }

                FormMain mainForm = new FormMain();
                if (mainForm.ShowDialog() != DialogResult.OK)
                {
                    continue; // Log out and show the login form again
                }
            }
        }
    }
}

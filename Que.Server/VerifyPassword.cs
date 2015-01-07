using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Que.Server.Properties;
using System.Windows.Forms;

namespace Que.Server
{
    public partial class VerifyPassword : Form
    {
        public VerifyPassword()
        {
            InitializeComponent();
        }

        private bool Verify(string password)
        {
            if (password.Equals(Settings.Default.SettingsPassword) ||
                password.Equals(Settings.Default.SUPassword))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void buttonLogin_Click(object sender, EventArgs e)
        {
            if (Verify(textBoxEnterPassword.Text))
            {
                this.Visible = false;
                Preferences preferences = new Preferences();                
                preferences.ShowDialog();
            }
            else
            {
                MessageBox.Show("You entered an invalid password.\nPlease try again.");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EmployeeInformation.DataProcess;

namespace EmployeeInformation
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            CheckConnection();
        }
        private void CheckConnection()
        {
            try
            {
                Config.connection.Open();
                lblConnection.Text = "Connected";
            }
            catch(Exception exc)
            {
                lblConnection.Text = "Failed";
                txtUser.Enabled = false;
                txtPassword.Enabled = false;
                btnLogin.Enabled = false;
                MessageBox.Show(exc.ToString());
            }
            finally
            {
                Config.connection.Close();
            }

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUser.Text != "" && txtPassword.Text != "")
            {
                Config.UserInfo = LoginProcess.LoginCheck(txtUser.Text, txtPassword.Text);

                if (Config.UserInfo.Rows.Count==0)
                {
                    MessageBox.Show("Invalid User!");
                    txtPassword.Text = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                }
                else
                {
                    txtPassword.Text = "";
                    txtUser.Text = "";
                    txtUser.Focus();
                    this.Hide();
                    Form mainmenu = new MainMenu();                    
                    mainmenu.ShowDialog();
                    this.Show();
                    
                }
            }
        }
    }
}

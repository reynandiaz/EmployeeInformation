using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LogTimeSwiping.DataProcess;

namespace LogTimeSwiping
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
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
                MessageBox.Show(exc.ToString());
                lblConnection.Text = "Failed";
            }
            finally
            {
                Config.connection.Close();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != "" || txtUser.Text != "")
            {
                Config.UserInfo = LoginProcess.CheckLogin(txtUser.Text, txtPassword.Text);
                if (Config.UserInfo.Rows.Count==0)
                {
                    MessageBox.Show("Invalid User!");
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                }
                else
                {
                    txtUser.Text = "";
                    txtPassword.Text = "";
                    txtUser.Focus();
                    Form swipe = new Swiping();
                    swipe.ShowDialog();
                }
            }
            else
            { MessageBox.Show("Fill Information!"); }
        }
    }
}

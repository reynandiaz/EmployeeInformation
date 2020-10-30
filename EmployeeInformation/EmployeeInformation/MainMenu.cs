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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to logout?", "System Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                Config.UserInfo = null; 

                foreach (Form frm in this.MdiChildren)
                {
                    frm.Dispose();
                    frm.Close();
                }
                this.Close();
            }
        }

        private void eToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form employees = new Employees();
            this.IsMdiContainer = true;
            employees.MdiParent = this;
            employees.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form add = new AddEmployee();
            this.IsMdiContainer = true;
            add.MdiParent = this;
            add.Show();
        }
    }
}

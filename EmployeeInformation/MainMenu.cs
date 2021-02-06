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
        private Employees employees = new Employees();
        private AddEmployee addemployee = new AddEmployee();
        private Departments dept = new Departments();
        private Sections sect = new Sections();


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
            employees.Dispose();
            employees = new Employees();
            employees.MdiParent = this;
            employees.Show();
        }

        private void addEmployeeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            addemployee.Dispose();
            addemployee = new AddEmployee();
            addemployee.MdiParent = this;
            addemployee.Show();
        }

        private void logtimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form log = new Logtime();
            this.IsMdiContainer = true;
            log.MdiParent = this;
            log.Show();
        }

        private void departmentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dept.Dispose();
            dept = new Departments();
            dept.MdiParent = this;
            dept.Show();
        }

        private void sectionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sect.Dispose();
            sect = new Sections();
            sect.MdiParent = this;
            sect.Show();
        }
    }
}

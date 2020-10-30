using EmployeeInformation.DataProcess;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployeeInformation
{
    public partial class Informations : Form
    {
        public static string EmployeeCode;
        private string Mode;

        public Informations()
        {
            InitializeComponent();
        }

        private void Informations_Load(object sender, EventArgs e)
        {
            if (EmployeeCode != null)
            {
                LoadInformations();
            }
        }


        private void LoadInformations()
        {
            string query = "SELECT * from employees e " +
                        "inner join sections s " +
                        "on s.SectionID = e.SectionID " +
                        "and S.DepartmentID = e.DepartmentID " +
                        "inner join departments d " +
                        "on s.DepartmentID = d.departmentid " +
                        "where e.deleteddate is null and EmployeeCode= @EmployeeCode";

            StringBuilder data = new StringBuilder(query);
            data.Replace("@EmployeeCode", EmployeeCode);

            DataTable info = Config.RetreiveData(data.ToString()); 

            if (info.Rows.Count != 0)
            {
                txtEmployeeCode.Text= info.Rows[0]["EmployeeCode"].ToString();
                txtFirstname.Text = info.Rows[0]["Firstname"].ToString();
                txtLastname.Text = info.Rows[0]["Lastname"].ToString();
                txtMiddle.Text = info.Rows[0]["Middlename"].ToString();
                txtAddress.Text = info.Rows[0]["Address"].ToString();
                txtDepartment.Text = info.Rows[0]["DepartmentName"].ToString();
                txtSection.Text = info.Rows[0]["SectionName"].ToString();
                txtBirthDate.Text = info.Rows[0]["BirthDate"].ToString();
                
            }
            Mode = "Read";
            btnUpdate.Text = Mode;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Mode == "Read")
            {
                //txtEmployeeCode.BackColor = Color.WhiteSmoke;
                txtFirstname.BackColor = Color.PaleGreen;
                txtFirstname.ReadOnly = false;
                txtLastname.BackColor = Color.PaleGreen;
                txtLastname.ReadOnly = false;
                txtMiddle.BackColor = Color.PaleGreen;
                txtMiddle.ReadOnly = false;
                txtAddress.BackColor = Color.PaleGreen;
                txtAddress.ReadOnly = false;
                txtDepartment.BackColor = Color.PaleGreen;
                txtDepartment.ReadOnly = false;
                txtSection.BackColor = Color.PaleGreen;
                txtSection.ReadOnly = false;
                txtBirthDate.BackColor = Color.PaleGreen;
                txtBirthDate.ReadOnly = false;

                Mode = "Update";
                
            }
            else
            {
                txtFirstname.BackColor = Color.WhiteSmoke;
                txtFirstname.ReadOnly = true;
                txtLastname.BackColor = Color.WhiteSmoke;
                txtLastname.ReadOnly = true;
                txtMiddle.BackColor = Color.WhiteSmoke;
                txtMiddle.ReadOnly = true;
                txtAddress.BackColor = Color.WhiteSmoke;
                txtAddress.ReadOnly = true;
                txtDepartment.BackColor = Color.WhiteSmoke;
                txtDepartment.ReadOnly = true;
                txtSection.BackColor = Color.WhiteSmoke;
                txtSection.ReadOnly = true;
                txtBirthDate.BackColor = Color.WhiteSmoke;
                txtBirthDate.ReadOnly = true;

                Mode = "Read";
            }
            btnUpdate.Text = Mode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "System Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string query = "Update employees set " +
                    "Firstname=':1', " +
                    "lastname=':2'," +
                    "middlename=':3'," +
                    "address=':4' " +
                    " where employeecode=':5'";
                StringBuilder data = new StringBuilder(query);
                data.Replace(":1", txtFirstname.Text);
                data.Replace(":2", txtLastname.Text);
                data.Replace(":3", txtMiddle.Text);
                data.Replace(":4", txtAddress.Text);
                data.Replace(":5", txtEmployeeCode.Text);

                try
                {
                    Config.ExecuteCmd(data.ToString());
                    MessageBox.Show("Records Updated!");
                }
                catch (Exception exc)
                { MessageBox.Show(exc.ToString()); }
                finally
                { this.Close(); }


            }
        }

        private void btnPrintID_Click(object sender, EventArgs e)
        {
            //Form id = new Reports.EmployeeID.frmEmployeeID();
            //Form main = new MainMenu();
            //main.IsMdiContainer = true;
            //id.MdiParent = main;
            //id.Show();

            try
            {
                Reports.EmployeeID.frmEmployeeID.EmployeeCode = txtEmployeeCode.Text;
                Reports.EmployeeID.frmEmployeeID id = new Reports.EmployeeID.frmEmployeeID();
                //Form menu = new MainMenu();
                //id.MdiParent = menu;
                id.Show();
            }
            catch(Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }
    }
}

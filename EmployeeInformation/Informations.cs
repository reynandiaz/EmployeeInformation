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
                GenerateDepartments();
            }
        }

        private void GenerateDepartments()
        {
            DataTable data = SettingsProcess.GetDepartments();

            foreach (DataRow row in data.Rows)
            {
                cmbDepartment.Items.Add(row["DepartmentName"].ToString());
            }
        }
        private void cmbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbSection.Text = "";

            DataTable data = SettingsProcess.GetSections(cmbDepartment.Text);

            foreach (DataRow row in data.Rows)
            {
                cmbSection.Items.Add(row["SectionName"].ToString());
            }
        }

        private void LoadInformations()
        {
            string query = "SELECT * from employees e " +
                        "left join sections s " +
                        "on s.SectionID = e.SectionID " +
                        "and S.DepartmentID = e.DepartmentID " +
                        "left join departments d " +
                        "on s.DepartmentID = d.departmentid " +
                        "left join employeerate er "+
                        "on er.EmployeeCode = e.EmployeeCode "+
                        "where e.deleteddate is null and e.EmployeeCode= @EmployeeCode";

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
                txtRate.Text = info.Rows[0]["Rate"].ToString();
                cmbDepartment.Text = info.Rows[0]["DepartmentName"].ToString();
                cmbSection.Text = info.Rows[0]["SectionName"].ToString();
            }
            Mode = "Read";
            btnUpdate.Text = Mode;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (Mode == "Read")
            {
                txtFirstname.BackColor = Color.PaleGreen;
                txtFirstname.ReadOnly = false;
                txtLastname.BackColor = Color.PaleGreen;
                txtLastname.ReadOnly = false;
                txtMiddle.BackColor = Color.PaleGreen;
                txtMiddle.ReadOnly = false;
                txtAddress.BackColor = Color.PaleGreen;
                txtAddress.ReadOnly = false;

                //txtDepartment.BackColor = Color.PaleGreen;
                //txtDepartment.ReadOnly = false;
                //txtSection.BackColor = Color.PaleGreen;
                //txtSection.ReadOnly = false;

                txtDepartment.Visible = false;
                cmbDepartment.Visible = true;
                txtSection.Visible = false;
                cmbSection.Visible = true;

                txtBirthDate.BackColor = Color.PaleGreen;
                txtBirthDate.ReadOnly = false;
                txtRate.BackColor = Color.PaleGreen;
                txtRate.ReadOnly = false;

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


                //txtDepartment.BackColor = Color.WhiteSmoke;
                //txtDepartment.ReadOnly = true;
                //txtSection.BackColor = Color.WhiteSmoke;
                //txtSection.ReadOnly = true;

                txtDepartment.Visible = true;
                cmbDepartment.Visible = false;
                txtSection.Visible = true;
                cmbSection.Visible = false;

                txtBirthDate.BackColor = Color.WhiteSmoke;
                txtBirthDate.ReadOnly = true;
                txtRate.BackColor = Color.WhiteSmoke;
                txtRate.ReadOnly = true;

                Mode = "Read";
            }
            btnUpdate.Text = Mode;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to update?", "System Message", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int DepartmentID = SettingsProcess.GetDepartmentID(cmbDepartment.Text);
                int SectionID = SettingsProcess.GetSectionID(cmbDepartment.Text, cmbSection.Text);

                string query = "Update employees set " +
                    "Firstname='" + txtFirstname.Text + "', " +
                    "lastname='" + txtLastname.Text + "'," +
                    "middlename='"+ txtMiddle.Text + "'," +
                    "address='" + txtAddress.Text + "', " +
                    "DepartmentID=" + DepartmentID + ", " +
                    "SectionID=" + SectionID + ", " +
                    "UpdatedDate = now(), "+
                    "UpdatedBy = '"+ Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "' "+
                    " where employeecode='" + txtEmployeeCode.Text + "'";

                string updateRate = "UPDATE employeerate " +
                                    "SET Rate ='"+ txtRate.Text +"', " +
                                    "UpdatedDate = now(), " +
                                    "UpdatedBy = '" + Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "' " +
                                    "WHERE EmployeeCode ='" + txtEmployeeCode.Text + "'";
                try
                {
                    Config.ExecuteCmd(query);
                    Config.ExecuteCmd(updateRate);
                    MessageBox.Show("Records Updated!");
                }
                catch (Exception exc)
                { MessageBox.Show(exc.ToString()); }
                finally
                { this.Close(); }
            }
        }



        private void Informations_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Dispose();
            }
        }

        private void printInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Reports.EmployeeData.frmEmployeeData.EmployeeCode = txtEmployeeCode.Text;
            Form frm = new Reports.EmployeeData.frmEmployeeData();
            frm.ShowDialog();
        }

        private void printIDToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                Reports.EmployeeID.frmEmployeeID.EmployeeID = txtEmployeeCode.Text;
                Reports.EmployeeID.frmEmployeeID id = new Reports.EmployeeID.frmEmployeeID();
                //Form menu = new MainMenu();
                //id.MdiParent = menu;
                id.Show();
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        private void printPayslipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form month = new MonthSelection();
            MonthSelection.prEmployeeCode = txtEmployeeCode.Text;
            month.ShowDialog();
        }

        private void timeLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form log = new LogInformation();
            LogInformation.EmployeeCode = txtEmployeeCode.Text; 
            log.ShowDialog();
        }
    }
}

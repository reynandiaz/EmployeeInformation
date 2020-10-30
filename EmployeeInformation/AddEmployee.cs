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
    public partial class AddEmployee : Form
    {
        public AddEmployee()
        {
            InitializeComponent();
        }

        private void AddEmployee_Load(object sender, EventArgs e)
        {
            txtEmployeeCode.Text = GenerateEmployeeID();
            GenerateGender();
            GenerateDepartments();
        }

        private string GenerateEmployeeID()
        {
            string query = "Select max(EmployeeCode) as MaxEmpCode from employees";
            string EmployeeCode = (Config.ExecuteIntScalar(query) + 1).ToString();
            return EmployeeCode;
        }
        private void GenerateGender()
        {
            cmbGender.Items.Add("M");
            cmbGender.Items.Add("F");
        }
        private void GenerateDepartments()
        {
            string query = "Select * from Departments where deletedDate is null";

            DataTable departmentdt = Config.RetreiveData(query);
            cmbDepartments.Items.Clear();
            for (int x = 0; x < departmentdt.Rows.Count; x++)
            {
                cmbDepartments.Items.Add(departmentdt.Rows[x]["DepartmentName"].ToString());
            }
        }

        private void cmbDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = " SELECT * from departments d " +
                            "inner join sections s " +
                            "on s.DepartmentID = d.DepartmentID " +
                            "where d.DeletedDate is null " +
                            "and d.DepartmentName = ':1' ";

            StringBuilder newquery = new StringBuilder(query);
            newquery.Replace(":1", cmbDepartments.Text);
            DataTable sectionsdt = Config.RetreiveData(newquery.ToString());
            cmbSections.Items.Clear();
            cmbSections.Text = "";
            for (int x = 0; x < sectionsdt.Rows.Count; x++)
            {
                cmbSections.Items.Add(sectionsdt.Rows[x]["SectionName"].ToString());
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                InsertEmployee();
                ClearValues();
                MessageBox.Show("Record Saved!");
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private void ClearValues()
        {
            foreach (Control control in this.Controls)
            {
                if (control.GetType() == typeof(TextBox))
                {
                    control.Text = "";
                }
                else if (control.GetType() == typeof(ComboBox))
                {
                    control.Text = "";
                }
            }
            txtEmployeeCode.Text = GenerateEmployeeID();
        }

        private void InsertEmployee()
        {
            string query = "Insert into employees (`EmployeeCode`,`Firstname`,`Middlename`," +
                            "`Lastname`,`Gender`,`Birthdate`,`Address`, `DepartmentID`,`SectionID`,`CreatedDate`,`UpdatedDate`,`UpdatedBy`) " +
                            "VALUES(" +
                            "'"+ txtEmployeeCode.Text + "'," +
                            "'"+ txtFirst.Text + "'," +
                            "'"+ txtMiddle.Text + "'," +
                            "'"+ txtLast.Text + "'," +
                            "'"+ cmbGender.Text + "'," +
                            "'"+ dtBirth.Value.ToString() + "'," +
                            "'" + txtAddress.Text + "'," +
                            "(Select DepartmentID from Departments where DepartmentName = '"+ cmbDepartments.Text + "')," +
                            "(Select SectionID from sections s " +
                            "inner join departments d " +
                            "on s.DepartmentID = d.DepartmentID " +
                            "where d.DepartmentName = '"+ cmbDepartments.Text + "' and SectionName = '"+ cmbSections.Text  + "')," +
                            "now()," +
                            "now()," +
                            "'"+ Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "'" +
                            ") ";

            Config.ExecuteCmd(query);
        }
    }
}

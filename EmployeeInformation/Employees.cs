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
using MySql.Data.MySqlClient;
using System.Windows.Forms.VisualStyles;

namespace EmployeeInformation
{
    public partial class Employees : Form
    {
        private int intLimit = 15;

        public Employees()
        {
            InitializeComponent();
        }

        private void Employees_Load(object sender, EventArgs e)
        {
            txtPage.Text = "1";
            RefreshTable();
        }
        private void RefreshTable()
        {
            
            double MaxPage = getMaxPage(intLimit);
            txtMaxPage.Text = MaxPage.ToString();

            int intOffset = txtPage.Text=="1"? 0: ( intLimit*(Convert.ToInt32(txtPage.Text)-1) );

            string QueryAll = "SELECT * from employees e " +
                        "inner join sections s " +
                        "on s.SectionID = e.SectionID " +
                        "and S.DepartmentID = e.DepartmentID " +
                        "inner join departments d " +
                        "on s.DepartmentID = d.departmentid " +
                        "where e.deleteddate is null ";
                        if (txtFilter.Text != " ")
                        {
                QueryAll = QueryAll + "and firstname like '%" + txtFilter.Text + "%'  " +
                                    "or lastname like '%" + txtFilter.Text + "%' " +
                                    "or departmentname like '%" + txtFilter.Text + "%' " +
                                    "or sectionname like '%" + txtFilter.Text + "%' ";
                        }
                        QueryAll = QueryAll + " Limit " + intLimit + " offset " + intOffset;
     
                      
            DataTable employeelist = Config.RetreiveData(QueryAll);

            try
            {
                dataGridView1.Rows.Clear();
                dataGridView1.AllowUserToAddRows = true;
                for (int x = 0; x < employeelist.Rows.Count; x++)
                {
                    DataGridViewRow row = (DataGridViewRow)dataGridView1.Rows[x].Clone();
                    row.Cells[0].Value = employeelist.Rows[x]["EmployeeCode"].ToString();
                    row.Cells[1].Value = employeelist.Rows[x]["Lastname"].ToString() + ", " + employeelist.Rows[x]["Firstname"].ToString() + " " + employeelist.Rows[x]["Middlename"].ToString();
                    row.Cells[2].Value = employeelist.Rows[x]["DepartmentName"].ToString();
                    row.Cells[3].Value = employeelist.Rows[x]["SectionName"].ToString();
                    row.Cells[4].Value = ">>";
                    dataGridView1.Rows.Add(row);
                }
                dataGridView1.AllowUserToAddRows = false;
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }

        private double getMaxPage(int intLimit)
        {
            double pageCount = 0.0;

            string query = "SELECT count(employeeCode) as cnt from employees";

            double cnt = Config.ExecuteIntScalar(query) / Convert.ToDouble(intLimit);

            pageCount = Math.Ceiling(cnt);

            return pageCount;
        }   

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4)
            {
                string CellEmployeeCode = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                Informations.EmployeeCode = CellEmployeeCode;
                Form info = new Informations();
                info.ShowDialog();
                Informations.EmployeeCode = null;
                RefreshTable();
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Form employeelist = new Reports.frmEmployeeListReport();
            //Form main = new MainMenu();
            //main.IsMdiContainer = true;
            //employeelist.MdiParent = main;
            employeelist.Show();
        }

        private void btnAddPage_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPage.Text) < Convert.ToInt32(txtMaxPage.Text))
            {
                txtPage.Text = (Convert.ToInt32(txtPage.Text)+1).ToString();
                RefreshTable();
            }
        }

        private void btnLessPage_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(txtPage.Text)>1 && Convert.ToInt32(txtPage.Text) <= Convert.ToInt32(txtMaxPage.Text))
            {
                txtPage.Text = (Convert.ToInt32(txtPage.Text) - 1).ToString();
                RefreshTable();
            }
        }


        private void txtPage_Leave(object sender, EventArgs e)
        {
            if (Convert.ToInt32(txtPage.Text) <= Convert.ToInt32(txtMaxPage.Text))
            {
                RefreshTable();
            }
            else
            { MessageBox.Show("Invalid Page!"); }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshTable();
        }

        private void btnMaxPage_Click(object sender, EventArgs e)
        {
            txtPage.Text=getMaxPage(intLimit).ToString();
            RefreshTable();
        }

        private void btnMinPage_Click(object sender, EventArgs e)
        {
            txtPage.Text = "1";
            RefreshTable();
        }
    }
}

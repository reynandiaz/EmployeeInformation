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
    public partial class Departments : Form
    {
        public Departments()
        {
            InitializeComponent();
        }

        private void Departments_Load(object sender, EventArgs e)
        {
            RefreshTable();
        }


        private void RefreshTable()
        {
            string query = "SELECT D.DepartmentID,d.DepartmentName,count(D.DepartmentID) AS DCount FROM departments D " +
                           "INNER JOIN employees E " +
                           "ON E.DepartmentID = D.DepartmentID " +
                           "WHERE D.DeletedDate IS NULL " +
                           "GROUP BY DepartmentName, D.DepartmentID " +
                           "ORDER BY D.DepartmentID ";

            DataTable data = Config.RetreiveData(query);

            dataGridView1.Rows.Clear();
            dataGridView1.AllowUserToAddRows = true;
            dataGridView1.Rows.Add(data.Rows.Count);
            int x = 0;
            foreach (DataRow row in data.Rows)
            {
                dataGridView1.Rows[x].Cells[0].Value = row[1].ToString();
                dataGridView1.Rows[x].Cells[1].Value = row[2].ToString();
                dataGridView1.Rows[x].Cells[2].Value = ">>";
                x++;
            }
            dataGridView1.AllowUserToAddRows = false;
        }
    }
}

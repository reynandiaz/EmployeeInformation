using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeInformation.DataProcess
{
    public class ReportsData
    {
        public static DataTable getIDData(string EmployeeID)
        {
            DataTable rtnValue = new DataTable();

            string query = "SELECT e.EmployeeCode,concat(e.Lastname, ', ', e.Firstname,' ',e.Middlename) AS EmployeeName , " +
                            "d.DepartmentName , s.SectionName " +
                            "FROM employees e " +
                            "LEFT JOIN departments d " +
                            "ON d.DepartmentID = e.DepartmentID " +
                            "LEFT JOIN sections s " +
                            "ON s.DepartmentID = d.DepartmentID " +
                            "AND s.SectionID = e.SectionID " +
                            "WHERE e.EmployeeCode = '" + EmployeeID + "' ";

            rtnValue = Config.RetreiveData(query);

            return rtnValue;
        }
        public static DataTable getrtpEmployeeData(string employeeid)
        {
            DataTable rtnValue = new DataTable();

            string query = "SELECT e.LastName,e.FirstName,e.MiddleName,e.address,e.Gender,DATE_FORMAT(e.Birthdate, '%M %d %Y') as BirthDate, " +
                            "d.DepartmentName , s.SectionName " +
                            "FROM employees e " +
                            "LEFT JOIN departments d " +
                            "ON d.DepartmentID = e.DepartmentID " +
                            "LEFT JOIN sections s " +
                            "ON s.DepartmentID = d.DepartmentID " +
                            "AND s.SectionID = e.SectionID " +
                            "WHERE e.EmployeeCode = '" + employeeid + "' ";

            rtnValue = Config.RetreiveData(query);

            return rtnValue;
        }

    }
}

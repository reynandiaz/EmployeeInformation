using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EmployeeInformation.DataProcess
{
    public class SettingsProcess
    {
        public struct returnSettingsValue
        {
            public bool isSuccess;
            public string rtnCode;
            public string strMessage;
        }
        public static int GenerateDepartmentID()
        {
            int rtnValue = 0;

            string query = "SELECT max(DepartmentID)+1 AS DepartmentID FROM departments ";

            return rtnValue  = Config.ExecuteIntScalar(query);
        }
        public static int GenerateSectionID(string DepartmentName)
        {
            int rtnValue = 0;

            string query = "SELECT max(SectionID) AS MaxSectionID FROM sections s " +
                            "INNER JOIN departments d " +
                            "ON s.DepartmentID = d.DepartmentID " +
                            "WHERE d.DepartmentName = '"+ DepartmentName + "'";

            return rtnValue = Config.ExecuteIntScalar(query)+1;
        }

        public static  int GetDepartmentID(string DepartmentName)
        {
            int rtnValue = 0;

            string getDeptID = "Select DepartmentID from departments where departmentname = '" + DepartmentName + "'";

            return rtnValue= Config.ExecuteIntScalar(getDeptID);
        }
        public static int GetSectionID(string DepartmentName,string SectionName)
        {
            int rtnValue = 0;

            string getSectionID = "SELECT SectionID FROM sections s "+
                                    "INNER JOIN departments d " +
                                    "ON s.DepartmentID = d.DepartmentID " +
                                    "WHERE d.DepartmentName = '" + DepartmentName + "' " +
                                    "AND s.SectionName = '" + SectionName + "' ";

            return rtnValue = Config.ExecuteIntScalar(getSectionID);
        }

        public static returnSettingsValue AddDepartment(string DepartmentID,string DepartmentName)
        {
            returnSettingsValue rtnValue = new returnSettingsValue();

            try
            {
                string chkQuery = "Select count(DepartmentID) from Departments where DepartmentName ='" + DepartmentName + "'";

                int intCnt = Config.ExecuteIntScalar(chkQuery);
                if (intCnt == 0)
                {
                    string strInsert = "INSERT INTO departments (DepartmentID, DepartmentName, CreatedDate,  UpdatedDate, UpdateBy)  " +
                                        "VALUES(" + DepartmentID + ", '" + DepartmentName + "', now(), now(), '" + Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "') ";

                    Config.ExecuteCmd(strInsert);
                    rtnValue.isSuccess = true;
                    rtnValue.strMessage = "Success!";
                }
                else
                {
                    rtnValue.isSuccess = false;
                    rtnValue.strMessage = "Already Registered!";
                }
            }
            catch (Exception exc)
            {

                rtnValue.isSuccess = false;
                //rtnValue.strMessage = "Error Occurred!";
                rtnValue.strMessage = exc.ToString();
            }
            return rtnValue;
        }
        public static returnSettingsValue AddSection(string SectionID, string SectionName,string DepartmentName)
        {
            returnSettingsValue rtnValue = new returnSettingsValue();

            try
            {
                string chkQuery = "Select count(DepartmentID) from sections where SectionName ='" + SectionName + "'";

                int intCnt = Config.ExecuteIntScalar(chkQuery);
                if (intCnt == 0)
                {
                    int intDepartmentID = SettingsProcess.GetDepartmentID(DepartmentName);

                    string strInsert = "INSERT INTO sections(SectionID, DepartmentID, SectionName, CreatedDate, DeletedDate, UpdatedDate, UpdatedBy) " +
                                       "VALUES("+ SectionID + ", "+ intDepartmentID + ", '" + SectionName + "', now(), null, now(), '"+ Config.UserInfo.Rows[0]["EmployeeCode"].ToString() +"')";

                    Config.ExecuteCmd(strInsert);
                    rtnValue.isSuccess = true;
                    rtnValue.strMessage = "Success!";
                }
                else
                {
                    rtnValue.isSuccess = false;
                    rtnValue.strMessage = "Already Registered!";
                }
            }
            catch
            {
                rtnValue.isSuccess = false;
                rtnValue.strMessage = "Error Occurred!";
            }
            return rtnValue;
        }
        public static returnSettingsValue UpdateDepartment(string DepartmentID, string DepartmentName)
        {
            var rtnValue = new returnSettingsValue();

            string query = "UPDATE departments "+
                            "SET DepartmentName = '"+ DepartmentName + "', "+
                            "UpdatedBy = '"+ Config.UserInfo.Rows[0]["EmployeeCode"].ToString() +"' "+
                            "WHERE DepartmentID = "+ DepartmentID;
            try
            {
                Config.ExecuteCmd(query);
                rtnValue.isSuccess = true;
                rtnValue.strMessage = "Records Updated!";
            }
            catch
            {
                rtnValue.isSuccess = false;
                rtnValue.strMessage = "Error Occurred!";
            }
            return rtnValue;
        }
        public static returnSettingsValue UpdateSection(string SectionID, string SectionName, string DepartmentName)
        {
            var rtnValue = new returnSettingsValue();

            int intDepartmentID = SettingsProcess.GetDepartmentID(DepartmentName);

            string query = "UPDATE sections "+
                            "SET SectionName = '"+ SectionName + "', "+
                            "UpdatedBy = '" + Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "' " +
                            "WHERE SectionID = " + SectionID + " AND DepartmentID = "+ intDepartmentID + " ";
            try
            {
                Config.ExecuteCmd(query);
                rtnValue.isSuccess = true;
                rtnValue.strMessage = "Records Updated!";
            }
            catch
            {
                rtnValue.isSuccess = false;
                rtnValue.strMessage = "Error Occurred!";
            }
            return rtnValue;
        }
        public static returnSettingsValue DeleteDepartment(string DepartmentID)
        {
            var rtnValue = new returnSettingsValue();

            string query = "UPDATE departments " +
                            "SET DeletedDate = now(), " +
                            "UpdatedBy = '" + Config.UserInfo.Rows[0]["EmployeeCode"].ToString() + "' " +
                            "WHERE DepartmentID = " + DepartmentID;
            try
            {
                Config.ExecuteCmd(query);
                rtnValue.isSuccess = true; 
                rtnValue.strMessage = "Records Deleted!";
            }
            catch
            {
                rtnValue.isSuccess = false;
                rtnValue.strMessage = "Error Occurred!";
            }
            return rtnValue;
        }

        public static DataTable GetDepartments()
        {
            DataTable rtnValue = new DataTable();
            string query = "Select * from Departments where deletedDate is null";

            return rtnValue = Config.RetreiveData(query);
        }

        public static DataTable GetSections(string Department)
        {
            DataTable rtnValue = new DataTable();

            string query = "SELECT s.SectionID,s.SectionName,count(EmployeeCode) AS EmpCount FROM sections s "+
                            "left JOIN departments d " +
                            "ON s.DepartmentID = d.DepartmentID " +
                            "left JOIN employees e " +
                            "ON e.DepartmentID = s.DepartmentID " +
                            "AND e.SectionID = s.SectionID " +
                            "WHERE d.DepartmentName = '"+ Department +"' " +
                            "GROUP BY s.SectionID";

            return rtnValue = Config.RetreiveData(query);
        }


    }
}

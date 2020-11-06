using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogTimeSwiping.DataProcess
{
    public class SwipingProcess
    {
        public static int UpdateTimeIN(string EmployeeID,string LogDate,string TimeIn)
        {
            int intReturn = 0;
             
            try
            {
                string chkEmployee = "SELECT count(EmployeeCode) from Employees " +
                                     "where EmployeeCode = '" + EmployeeID + "' and deleteddate is null";

                var cntEmp = Config.ExecuteIntScalar(chkEmployee);
                if (Convert.ToInt32(cntEmp) > 0)
                {
                    string chkLogtime = "SELECT count(logdate) from logtime " +
                                         "where EmployeeCode = '" + EmployeeID + "' " +
                                         "and Left(LogDate,10) = '" + LogDate+"'";

                    var cntEmployee = Config.ExecuteIntScalar(chkLogtime);
                    if (Convert.ToInt32(cntEmployee) == 0)
                    {
                        //INSERT
                        string insert = "INSERT INTO `logtime`(`EmployeeCode`, `LogDate`," +
                            " `DepartmentCode`, `SectionCode`, `TimeIn`, " +
                            "`TimeOut`, `TransIn`, `TransOut`, `StartTime`, " +
                            "`EndTime`, `CreatedDate`, `UpdatedDate`, `UpdatedBy`) " +
                            "VALUES ('"+EmployeeID+"', '"+LogDate+"',null,null," +
                            "'"+ LogDate + " "+ TimeIn +"',null,'IN','OUT',now()," +
                            "null,now(),now(),'"+Config.UserInfo.Rows[0]["EmployeeCode"].ToString()+"')";

                        Config.ExecuteCmd(insert);

                        intReturn = 1;
                    }
                    else
                    { 
                        intReturn =3; 
                    }
                }
                else
                {
                    intReturn = 4;
                }
            }
            catch
            { 
                intReturn = 4; 
            }

            return intReturn;
        }
        public static int UpdateTimeOut(string EmployeeID, string LogDate, string Timeout)
        {
            int intReturn = 0;

            try
            {
                string chkEmployee = "SELECT count(EmployeeCode) from Employees " +
                     "where EmployeeCode = '" + EmployeeID + "' and deleteddate is null";

                var cntEmp = Config.ExecuteIntScalar(chkEmployee);
                if (Convert.ToInt32(cntEmp) > 0)
                {
                    string chkTimein = "Select count(logdate) from logtime " +
                                        "where left(logdate, 10) = '" + LogDate + "' " +
                                        "and EmployeeCode = '" + EmployeeID + "' " +
                                        "and timein is not Null";
                    var cntTimeIn = Config.ExecuteIntScalar(chkTimein);

                    string chkIfOut = "Select count(logdate) from logtime " +
                                        "where left(logdate, 10) = '" + LogDate + "' " +
                                        "and EmployeeCode = '" + EmployeeID + "' " +
                                        "and timein is not Null and Timeout is not null";
                    var cntIfOut = Config.ExecuteIntScalar(chkIfOut);

                    int checkswipe = Convert.ToInt32(cntTimeIn) + Convert.ToInt32(cntIfOut);
                    if (checkswipe == 1)
                    {
                        ///trappings in swiping out not yet done
                        string query = "Update logtime set TimeOut = '" + LogDate + " " + Timeout + "', " +
                                       "EndTime = now(), " +
                                       "UpdatedDate = now() " +
                                       "where EmployeeCode = '" + EmployeeID + "' and left(logdate, 10) = '" + LogDate + "' ";
                        Config.ExecuteCmd(query);
                        intReturn = 1;
                    }
                    else if (checkswipe == 0)
                    {
                        intReturn = 5;
                    }
                    else if (checkswipe == 2)
                    { intReturn = 3; }
                }
                else
                {
                    intReturn = 4;
                }
            }
            catch
            {
                intReturn = 4;
            }

            return intReturn;
        }



        public static  DataTable getInformation(string EmployeeCode)
        {
            string query = "Select * from employees e " +
                           "inner join departments d " +
                           "on d.DepartmentID = e.DepartmentID " +
                           "inner join sections s " +
                           "on s.SectionID = e.SectionID " +
                           "and s.DepartmentID = d.DepartmentID " +
                           "where EmployeeCode = '"+ EmployeeCode + "' ";
            DataTable info = Config.RetreiveData(query);

            return info;
        }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace EmployeeInformation.DataProcess
{
    public class LoginProcess
    {
        public static DataTable LoginCheck(string username, string password)
        {
            DataTable result = new DataTable();

            string query = "Select * from users where username=@username and password = @password";

            var command = new MySqlCommand(query, Config.connection);
            try
            {
                Config.connection.Open();
                command.Parameters.Add("@username", MySqlDbType.VarChar).Value = username;
                command.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                var reader = command.ExecuteReader();
                result.Load(reader);
            }
            finally
            {
                Config.connection.Close();
            }
            return result;
        }
    }
}

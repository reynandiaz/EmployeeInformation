using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace LogTimeSwiping.DataProcess
{
    public class LoginProcess
    {
        public static DataTable CheckLogin(string username, string password)
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

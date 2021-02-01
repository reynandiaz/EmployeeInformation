using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace LogTimeSwiping.DataProcess
{
    public class Config
    {
        //TESTING
        public static MySqlConnection connection = new MySqlConnection("Server=localhost;Database=employee_db;Uid=root;password=admin;SslMode=none;");

        //DEPLOY
        //public static MySqlConnection connection = new MySqlConnection("Server=localhost;Database=employee_db;Uid=root;password=;SslMode=none;");

        public static DataTable UserInfo;

        public static void ExecuteCmd(string query)
        {
            var command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            finally
            {
                connection.Close();
            }
        }
        public static DataTable RetreiveData(string query)
        {
            DataTable dtable = new DataTable();
            var command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                dtable.Load(reader);
            }
            finally
            {
                connection.Close();
            }

            return dtable;
        }
        public static int ExecuteIntScalar(string query)
        {
            int intReturn = 0;

            var command = new MySqlCommand(query, connection);
            try
            {
                connection.Open();
                var cnt = command.ExecuteScalar();
                intReturn = Convert.ToInt32(cnt);
                return intReturn;
            }
            finally
            {
                connection.Close();
            }
        
        
        }
    }
}

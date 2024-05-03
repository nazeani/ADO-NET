using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.DAL
{
    public class AppDb
    {
        string conString = "DESKTOP-2TU58SD\\SQLEXPRESS;Database=ADONET" +
            ";Trusted_Connection=true;Integrated Security=true;TrustServerCertificate=true;";
        public SqlConnection sqlConnection;

        public AppDb()
        {
            sqlConnection = new SqlConnection(conString);
        }
        public void NonQuery(string command)
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
            var result = sqlCommand.ExecuteNonQuery();

            if (result > 0)
            {
                Console.WriteLine("Successfully: " + result);
            }
            else
            {
                Console.WriteLine("Wrong!");
            }
            sqlConnection.Close();
        }

        public DataTable Query(string selectCommand)
        {
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand, sqlConnection);
            DataTable dataTable = new DataTable();
            sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
}

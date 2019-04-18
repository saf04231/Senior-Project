using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Text;

namespace DADS.Models
{
    // DB Connection
    public class DBConnection
    {
        // defines information for connecting to the database
        private static SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
        private static SqlConnection connection;


        public static void Connect()
        {
            try
            {
                builder.DataSource = "zerohp.database.windows.net";
                builder.UserID = "zero";
                builder.Password = "BV7Kg2D&2S&m2P#g";
                builder.InitialCatalog = "zerohp";
                connection = new SqlConnection(builder.ConnectionString);

                connection.Open();
                Console.WriteLine("Connected to Database.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not connect to Database. Exception: " + e);
                throw e;
            }
        }

        private void Disconnect()
        {
            try
            {
                connection.Close();
                Console.WriteLine("Disconnected from Database.");
            }
            catch(Exception e)
            {
                Console.WriteLine("Could not disconnect to Database. Exception: " + e);
                throw e; 
            }
        }

        //TODO

        // INSERT statements
        public void Insert(string role, string query)
        {
            Connect();

            Disconnect();
        }

        // SELECT statements
        public void Read(string role, string query)
        {
            Connect();

            StringBuilder sb = new StringBuilder();
            sb.Append("SELECT * FROM users");

            Disconnect();
        }

        // UPDATE statements
        public void Update(string role, string query)
        {

            Connect();

            Disconnect();
        }

        // DELETE statements 
        public void Delete(string role, string query)
        {

            Connect();

            Disconnect();
        }
    }


}
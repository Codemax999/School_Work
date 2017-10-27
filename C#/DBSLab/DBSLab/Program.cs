using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            // sql connection details: ip, userId, user password, database and port
            string sqlConn = @"server=192.168.120.1;userid=dbsAdmin;password=password;database=example_1610; port=8889";
            MySqlConnection conn = null;

            // topic
            Console.WriteLine("Places in Miami:");

            try
            {
                // open connection to database
                conn = new MySqlConnection(sqlConn);
                MySqlDataReader queryDetails = null;
                conn.Open();

                // sql query: location id, location name and location type in Miami (top 10)
                string query = "SELECT id, name, type FROM location WHERE city = 'Miami' ORDER BY id LIMIT 10";
                MySqlCommand cmd = new MySqlCommand(query, conn);
                queryDetails = cmd.ExecuteReader();

                // loop through results
                while (queryDetails.Read())
                {
                    // print out details to console
                    Console.WriteLine(queryDetails.GetInt32(0) + ": " + queryDetails.GetString(1) + " a " + queryDetails.GetString(2) + " place.");
                }
            }
            catch (MySqlException error)
            {
                // display error details
                Console.WriteLine("Error: {0}", error.ToString());
            }
            finally
            {
                // close connection to db
                if (conn != null)
                {
                    conn.Close();
                }
            }
        }
    }
}

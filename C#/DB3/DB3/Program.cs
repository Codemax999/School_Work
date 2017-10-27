using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace DB3
{
    class Program
    {
        static void Main(string[] args)
        {
            string cs = @"server=192.168.120.1;userid=dbsAdmin;password=password;database=example_1610; port=8889";

            MySqlConnection conn = null;

            Console.Write("Search Term:");
            string searchTerm = Console.ReadLine();

            try
            {
                conn = new MySqlConnection(cs);
                MySqlDataReader rdr = null;
                conn.Open();

                string stm = "SELECT * from item where title like '%" + searchTerm + "%' limit 100";
                MySqlCommand cmd = new MySqlCommand(stm, conn);

                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine(rdr.GetInt32(0) + ": " + rdr.GetString(1));
                }

            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());

            }
            finally
            {

                if (conn != null)
                {
                    conn.Close();
                }

            }

            Console.WriteLine("Done");

        }
    }
}

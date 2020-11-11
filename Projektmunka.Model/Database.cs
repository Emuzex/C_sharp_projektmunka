using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Projektmunka.Model
{
    public class Database
    {
        public MySqlConnection conn;
        #region Private properties
        private string ConnStr = "server=145.236.9.97;user=csharp;database=csharpprojekt;port=3306;password=Csharpisfun!97";
        
        #endregion
        public Database() {
             conn = new MySqlConnection(ConnStr);
        }

        public void addNewProduct(string productName, string itemNum, string stock, string price, string category, string unit)
        {

            try
            {

                conn.Open();

                string sql = "INSERT INTO products VALUES ('{0}', '{1}', '{2}', '0', '{3}', '{4}', '{5}');";
                sql = String.Format(sql, productName, itemNum, stock, price, category, unit);
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                /*while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

        }
        public void updateProduct()
        {
            
            try
            {

                conn.Open();

                string sql = "UPDATE products SET ('{0}' = '{1}');";
                MySqlCommand cmd = new MySqlCommand(String.Format(sql, 1, 2, 3), conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                /*while (rdr.Read())
                {
                    Console.WriteLine(rdr[0] + " -- " + rdr[1]);
                }
                rdr.Close();*/
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

        }

        

    }
}


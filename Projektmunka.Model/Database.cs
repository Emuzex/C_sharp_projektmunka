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

        #region Private properties
        private string ConnStr = "server=145.236.9.97;user=csharp;database=csharpprojekt;port=3306;password=Csharpisfun!97";
        #endregion

        public void addNewProduct(string productName, string itemNum, string stock, string price, string category, string unit)
        {

            MySqlConnection conn = new MySqlConnection(ConnStr);

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
            MySqlConnection conn = new MySqlConnection(ConnStr);
            try
            {

                conn.Open();

                string sql = "UPDATE products SET ('{0}', '{1}', '{2}', '0', '{3}');";
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

        public void searchProducts(string keyword)
        {
            MySqlConnection conn = new MySqlConnection(ConnStr);
            try
            {

                conn.Open();
                StringBuilder returnValue = new StringBuilder();
                string sql = "SELECT * FROM products WHERE name LIKE '%{0}%';";
                sql = String.Format(sql, keyword);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    returnValue.Append(rdr[0] + "\n");
                    // stringet kellene visszaadnia, hogy a Controller be tudja állítani a Label.Text-et
                    Console.WriteLine(returnValue);
                    
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            conn.Close();

        }

    }
}


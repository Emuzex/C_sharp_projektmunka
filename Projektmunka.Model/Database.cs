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
        private string ProductName { get; set; }
        private string ItemNum { get; set; }
        private int Stock { get; set; }
        private int Price { get; set; }
        private string connStr = "server=localhost;user=root;database=csharpprojekt;port=3306";
        #endregion

        #region Constructor
        public Database(string productName, string itemNum, int stock, int price) {
            ProductName = productName;
            ItemNum = itemNum;
            Stock = stock;
            Price = price;
        }
        #endregion

        public void addNewProduct()
        {
            
            MySqlConnection conn = new MySqlConnection(connStr);
            try
            {
                
                conn.Open();

                string sql = "INSERT INTO products VALUES ('{0}', '{1}', '{2}', '0', '{3}');";
                MySqlCommand cmd = new MySqlCommand(String.Format(sql,1, 2, 3 ), conn);
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
        public void updateProduct() {
            MySqlConnection conn = new MySqlConnection(connStr);
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
    }

}


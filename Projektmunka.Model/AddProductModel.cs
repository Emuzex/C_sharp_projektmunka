using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Projektmunka.Model
{
    public class AddProductModel
    {
        
        public int addNewProduct(string productName, string itemNum, string stock, string price, string category, string unit, string unitsize)
        {
            Database db = new Database();
            int rdr = 0;
            try
            {

                db.conn.Open();

                string sql = "INSERT INTO products VALUES ('{0}', '{1}', '{2}', '0', '{3}', '{4}', '{5}', '{6}', NULL);";
                sql = String.Format(sql, productName, itemNum, stock, price, category, unit, unitsize);
                Console.WriteLine(sql);
                MySqlCommand cmd = new MySqlCommand(sql, db.conn);
                rdr = cmd.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            
            db.conn.Close();
            return rdr;
        }
    }
}

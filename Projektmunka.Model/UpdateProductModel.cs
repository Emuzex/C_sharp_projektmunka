using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projektmunka.Model
{
    
    public class UpdateProductModel
    {
        Database db = new Database();
        public DataTable searchProducts(string keyword)
        {

            DataTable returnValue = new DataTable();
            try
            {

                db.conn.Open();

                string sql = "SELECT * FROM products WHERE name LIKE '%{0}%';";
                sql = String.Format(sql, keyword);
                MySqlCommand cmd = new MySqlCommand(sql, db.conn);
                returnValue.Load(cmd.ExecuteReader());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            db.conn.Close();
            return returnValue;

        }
    }
}

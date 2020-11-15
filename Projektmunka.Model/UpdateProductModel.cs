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
        // new instance of Database
        Database db = new Database();
        public DataTable searchProducts(string keyword)
        {
            // new instance of DataTable
            DataTable returnValue = new DataTable();
            try
            {

                db.conn.Open();
                // returns the results of the query (based on product name)
                string sql = "SELECT * FROM products WHERE name LIKE '%{0}%';";
                sql = String.Format(sql, keyword);
                MySqlCommand cmd = new MySqlCommand(sql, db.conn);
                // loads DataTable with result set
                returnValue.Load(cmd.ExecuteReader());

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            // closes database connection, and returns DataTable
            db.conn.Close();
            return returnValue;

        }
        // this method needs to be revised, as it does not work as intended
        public void update(string name, string prodNum, string stock, string unitSize, string unit, string category, string price)
        {
            
            try
            {

                db.conn.Open();
                // updates columns with parameters
                // the structure of the database will have to be revised, since itemnum is the primary key, it cannot be modified
                string sql = "UPDATE products SET name='{0}', itemnum='{1}', stock='{2}', price='{3}', category='{4}', unit='{5}', unit_size='{6}' WHERE itemnum='{1}';";
                sql = String.Format(sql, name, prodNum, stock, price, category, unit, unitSize, prodNum);
                MySqlCommand cmd = new MySqlCommand(sql, db.conn);
                cmd.ExecuteReader();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            db.conn.Close();
        }
    }
}

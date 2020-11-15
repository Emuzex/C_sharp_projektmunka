using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
namespace Projektmunka.Model
{
    // does not really belong in model, will move to another directory
    public class Database
    {
        public MySqlConnection conn;
        #region Private properties
        private string ConnStr = "server=localhost;user=root;database=csharpprojekt;port=3306;";
        
        #endregion
        public Database() {
             conn = new MySqlConnection(ConnStr);
        }

    }
}


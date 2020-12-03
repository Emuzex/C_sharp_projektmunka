using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projektmunka.Model
{
    public class LoginModel
    {
               
        public List<string> checkUser(string username, string pass)
        {
            Database db = new Database();
            db.conn.Open();
            pass = CreateMD5(pass);
            List<string> retvalue = new List<string>();
            string sql = "SELECT username FROM users WHERE username='{0}' AND pass='{1}'";
            
            MySqlCommand cmd = new MySqlCommand(String.Format(sql, username, pass), db.conn);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while(rdr.Read())
            {
                retvalue.Add(rdr[0].ToString());
            }
            db.conn.Close();
            return retvalue;
            

        }
        
        public static string CreateMD5(string input)
        {
         
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

         
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

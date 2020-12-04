using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektmunka.Model;
using System.Windows.Controls;

namespace Projektmunka.Controller
{
    public class LoginController
    {
        LoginModel model = new LoginModel();
        public bool authenticate(string username, string pass)
        {
            bool retvalue = false;
            
            List<string> temp = model.checkUser(username, pass);
            if (temp.Count > 0) retvalue = true;
            return retvalue;

        }
    }
}

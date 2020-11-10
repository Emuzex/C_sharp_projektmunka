using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektmunka.Model;
using System.Windows.Controls;

namespace Projektmunka.Controller
{
    public class UpdateProductController
    {
        Database db = new Database();
        public void searchDatabase(TextBox tb, Label result) {
            
            
            result.Content = db.searchProducts(tb.Text).ToString();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Projektmunka.Model;


namespace Projektmunka.Controller
{
    public class NewProductController
    {
        private AddProductModel Model = new AddProductModel();

        public bool submitData(string prodName, string stockNum, string itemNum, string itemPrice, string category, string unit, string unitSize) {
            bool retVal = false;
            if (Model.addNewProduct(prodName, itemNum, stockNum, itemPrice, category, unit, unitSize) > 0) retVal = true;
            return retVal;
        }
    }
}

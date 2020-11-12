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
        
        public void validateTextInput(TextBox prodName, TextBox stockNum, TextBox itemNum, TextBox itemPrice, TextBox unitMeasurement, Button submit)
        {
            if ((validateNum(stockNum) && validateNum(itemPrice) && validateNum(unitMeasurement)) && !(string.IsNullOrEmpty(prodName.Text) && string.IsNullOrEmpty(stockNum.Text) && string.IsNullOrEmpty(itemNum.Text) && string.IsNullOrEmpty(itemPrice.Text) && string.IsNullOrEmpty(unitMeasurement.Text)))
            {
                submit.IsEnabled = true;
            }
            else submit.IsEnabled = false;
            

        }

        public bool validateNum(TextBox toBeParsed)
        {
            bool isANum = false;
            toBeParsed.Foreground = System.Windows.Media.Brushes.Black;
            if (!String.IsNullOrEmpty(toBeParsed.Text))
            {
                try
                {
                    int.Parse(toBeParsed.Text);
                    isANum = true;
                }
                catch
                {
                    
                    toBeParsed.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            return isANum;

        }
        
        public void submitData(TextBox prodName, TextBox stockNum, TextBox itemNum, TextBox itemPrice, Button submit, ComboBox category, ComboBox unit, TextBox unitSize) {
            TextBox[] array = { prodName, stockNum, itemNum, itemPrice, unitSize };
            
            submit.IsEnabled = false;
            AddProductModel model = new AddProductModel();
            model.addNewProduct(prodName.Text, itemNum.Text, stockNum.Text, itemPrice.Text, category.Text, unit.Text, unitSize.Text);
            foreach (TextBox tb in array)
            {
                tb.Text = "";
            }
        }
    }
}

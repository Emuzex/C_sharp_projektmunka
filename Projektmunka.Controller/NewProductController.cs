using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace Projektmunka.Controller
{
    public class NewProductController
    {
        
        public void validateTextInput(TextBox prodName, TextBox stockNum, TextBox itemNum, TextBox itemPrice, Button submit)
        {
            if (!(string.IsNullOrEmpty(prodName.Text) || string.IsNullOrEmpty(stockNum.Text) || string.IsNullOrEmpty(itemNum.Text) || string.IsNullOrEmpty(itemPrice.Text)) && (validateNum(stockNum) && validateNum(itemPrice)))
            {
                submit.IsEnabled = true;
            }
            else submit.IsEnabled = false;
            

        }

        // lehet ezt is onkeyup-ra kéne rárakni, viszont csak a két számosnál, és az elején mindig feketére állítja a színt
        // 
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
        public void submitData() { }
    }
}

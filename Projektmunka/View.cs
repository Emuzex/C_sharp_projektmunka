using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektmunka.Controller;
using System.Windows.Controls;
using System.Windows;

namespace Projektmunka
{
    class View
    {
        UpdateProductController updateCtrlr = new UpdateProductController();
        NewProductController newProdCtrlr = new NewProductController();
        LoginController loginCtrlr = new LoginController();

        public void populateListview(TextBox tb, ListView result)
        {
            // clears the ListView by default, fills it if searchbox is not empty
            List<Product> searchResults = updateCtrlr.searchDatabase(tb.Text);
            result.ItemsSource = null;
            
                      
           
            foreach (Product item in searchResults)
                    {
                string name = "";
                if (int.Parse(item.Stock.ToString()) < 10)
                        {
                        name = String.Format("{0}{1}", "*", item.Name.ToString());
                        }
                else name = String.Format("{0}", item.Name.ToString());
                    

                        }
            // sets the ListView's ItemsSource
            if (tb.Text.Length > 0) result.ItemsSource = searchResults;
            else result.ItemsSource = null;

            }
        public void clear(ListView result, TextBox searchBox)
        {

            result.ItemsSource = null;
            searchBox.Text = "";

        }
        public void setFields(ListView lv, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize, TextBox id)
        {
            // takes the index of the currently selected item in the ListView
            int index = lv.SelectedIndex;
            Product product;
            List<Product> productList = updateCtrlr.getProductList();
            // takes the product from ProductList corresponding to the selected item
            // if the user modifies the searchbox, an exception is thrown, therefore a try-catch block is implemented
            try
            {
                product = productList[index];

            }
            catch
            {
                // this way the fields are cleared when an exception occurs
                product = new Product();
            }
            name.Text = product.Name;
            itemNum.Text = product.ItemNum;
            stock.Text = product.Stock;
            price.Text = product.Price;
            unitSize.Text = product.UnitSize;
            id.Text = product.Id;
            switch (product.Category)
            {
                case "Élelmiszer": category.SelectedIndex = 0; break;
                case "Szeszesital": category.SelectedIndex = 1; break;
                case "Ital": category.SelectedIndex = 2; break;
                case "Szépség- és babaápolás": category.SelectedIndex = 3; break;
                case "Háztartási vegyiáru": category.SelectedIndex = 4; break;
                case "Állateledel": category.SelectedIndex = 5; break;
                case "Szórakozás": category.SelectedIndex = 6; break;
            }
            switch (product.Unit)
            {
                case "db": unitMeasure.SelectedIndex = 0; break;
                case "g": unitMeasure.SelectedIndex = 1; break;
                case "kg": unitMeasure.SelectedIndex = 2; break;
                case "l": unitMeasure.SelectedIndex = 3; break;
                case "ml": unitMeasure.SelectedIndex = 4; break;

            }
            switch (product.Discount)
            {
                case "0": discount.SelectedIndex = 0; break;
                case "15": discount.SelectedIndex = 1; break;
                case "25": discount.SelectedIndex = 2; break;
                case "50": discount.SelectedIndex = 3; break;
            }
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
                    // sets font colour to red if invalid
                    toBeParsed.Foreground = System.Windows.Media.Brushes.Red;
                }
            }
            return isANum;
        }
        public void validateTextInput(TextBox prodName, TextBox stockNum, TextBox itemNum, TextBox itemPrice, TextBox unitMeasurement, Button submit)
        {
            if ((validateNum(stockNum) && validateNum(itemPrice) && validateNum(unitMeasurement)) && !(string.IsNullOrEmpty(prodName.Text) && string.IsNullOrEmpty(stockNum.Text) && string.IsNullOrEmpty(itemNum.Text) && string.IsNullOrEmpty(itemPrice.Text) && string.IsNullOrEmpty(unitMeasurement.Text)))
            {
                submit.IsEnabled = true;
            }
            else submit.IsEnabled = false;


        }
        public void updateProduct(TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize, TextBox searchBox, TextBox id, ListView results)
        {
            updateCtrlr.update(name.Text.Replace("*", ""), itemNum.Text, stock.Text, category.Text, discount.Text, price.Text, unitMeasure.Text, unitSize.Text, searchBox.Text, id.Text);
            searchBox.Text = "";
            results.ItemsSource = null;
        }
        public void sell(TextBox quantity, TextBox id1, ListView results, TextBox searchBox)
        {
            if (updateCtrlr.sell(quantity.Text, id1.Text))
            {
                MessageBox.Show("Sikeres eladás.");
                clear(results, searchBox);

            }
            else MessageBox.Show("Sikertelen eladás. A megadott mennyiség valószínűleg nagyobb, mint a raktárkészlet.");
        }
        public void authenticate(TextBox username, PasswordBox pass, Button edit, Button add)
        {
            if (loginCtrlr.authenticate(username.Text, pass.Password))
            {
                edit.IsEnabled = true;
                add.IsEnabled = true;
                MessageBox.Show("Sikeres bejelentkezés.");
            }
            else MessageBox.Show("Sikertelen bejelentkezés.");
        }
        public void addNewProduct(TextBox prodName, TextBox stockNum, TextBox itemNum, TextBox itemPrice, Button submit, ComboBox category, ComboBox unit, TextBox unitSize)
        {

            if (newProdCtrlr.submitData(prodName.Text, stockNum.Text, itemNum.Text, itemPrice.Text, category.Text, unit.Text, unitSize.Text))
            {
                submit.IsEnabled = false;
                TextBox[] textBoxes = { prodName, stockNum, itemNum, itemPrice, unitSize };
                foreach (TextBox tb in textBoxes)
                {
                    tb.Text = "";
                }
                category.SelectedIndex = 0;
                unit.SelectedIndex = 0;
            }
            else MessageBox.Show("Hiba történt a termék hozzáadása során.");
        }
    }  
}


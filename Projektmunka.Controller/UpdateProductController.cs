using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projektmunka.Model;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using System.Data;

namespace Projektmunka.Controller
{
    public struct Product
    {
        public string Name { get; set; }
        public string ItemNum { get; set; }
        public string Price { get; set; }
        public string Stock { get; set; }
        public string Category { get; set; }
        public string Discount { get; set; }
        public string Unit { get; set; }
        public string UnitSize { get; set; }
        public string Id { get; set; }
        
    }
    public class UpdateProductController
        
    {
        public List<Product> ProductList = new List<Product>();

        public Product Product;

        UpdateProductModel model = new UpdateProductModel();
        // takes the searchbox as a parameter, and the ListView containing the search results
        public void searchDatabase(TextBox tb, ListView result)
        {
            // clears the ListView by default, fills it if searchbox is not empty
            result.ItemsSource = null;
            if (!String.IsNullOrEmpty(tb.Text))
            {
                ProductList.Clear();
                DataTable dt = model.searchProducts(tb.Text);
                // fills ProductList with new Product structs, with corresponding data from the columns of the DataTable
                foreach (DataRow item in dt.Rows)
                {
                    string name = "";
                    if (Int32.Parse(item["stock"].ToString()) < 10)
                    {
                        name = String.Format("{0}{1}", "*", item["name"].ToString());
                    }
                    else name = String.Format("{0}", item["name"].ToString());
                    ProductList.Add(new Product
                    {
                        
                        Name = name,
                        ItemNum = item["itemnum"].ToString(),
                        Price = item["price"].ToString(),
                        Discount = item["discount"].ToString(),
                        Category = item["category"].ToString(),
                        Stock = item["stock"].ToString(),
                        Unit = item["unit"].ToString(),
                        UnitSize = item["unit_size"].ToString(),
                        Id = item["id"].ToString()
                    });


                }
                // sets the ListView's ItemsSource
                result.ItemsSource = ProductList;
                
            }
            

        }
        public void setFields(ListView lv, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize, TextBox id)
        {
            // takes the index of the currently selected item in the ListView
            int index = lv.SelectedIndex;
            Product product;
            // takes the product from ProductList corresponding to the selected item
            // if the user modifies the searchbox, an exception is thrown, therefore a try-catch block is implemented
            try
            {
                product = ProductList[index];
                
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
                case "0":discount.SelectedIndex = 0; break;
                case "15": discount.SelectedIndex = 1; break;
                case "25": discount.SelectedIndex = 2; break;
                case "50": discount.SelectedIndex = 3; break;
            }
        }
        public void update(ListView lv, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize, TextBox searchBox, TextBox id) {
            model.update(name.Text.Replace("*", ""), itemNum.Text, stock.Text, unitSize.Text, unitMeasure.Text, category.Text, price.Text, id.Text, discount.Text);
            clear(lv, searchBox);




        }
        
        public bool sell(TextBox quantity, TextBox prodNum, ListView results, TextBox searchBox)
        {
            bool retval = false;
            if (model.sellProduct(quantity.Text, prodNum.Text) > 0) retval = true;
            
            clear(results, searchBox);
            return retval;
        }

        public void clear(ListView lv, TextBox searchBox)
        {
            lv.ItemsSource = null;
            searchBox.Text = "";
        }
    }
}
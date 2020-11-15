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
                    ProductList.Add(new Product
                    {
                        Name = item["name"].ToString(),
                        ItemNum = item["itemnum"].ToString(),
                        Price = item["price"].ToString(),
                        Discount = item["discount"].ToString(),
                        Category = item["category"].ToString(),
                        Stock = item["stock"].ToString(),
                        Unit = item["unit"].ToString(),
                        UnitSize = item["unit_size"].ToString()
                    });


                }
                // sets the ListView's ItemsSource
                result.ItemsSource = ProductList;

            }
            

        }
        public void setFields(ListView lv, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize)
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
            switch (product.Category)
            {
                case "Élelmiszer": category.SelectedIndex = 0; break;
                case "Háztartási vegyiáru": category.SelectedIndex = 1; break;
                case "Szeszesital": category.SelectedIndex = 2; break;
                case "Kozmetikum": category.SelectedIndex = 3; break;
            }
            switch (product.Unit)
            {
                case "db": unitMeasure.SelectedIndex = 0; break;
                case "g": unitMeasure.SelectedIndex = 1; break;
                case "kg": unitMeasure.SelectedIndex = 2; break;
                case "l": unitMeasure.SelectedIndex = 3; break;
                case "ml": unitMeasure.SelectedIndex = 4; break;
                
            }
        }
        public void update(ListView lv, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount, TextBox price, ComboBox unitMeasure, TextBox unitSize, TextBox searchBox) {
            model.update(name.Text, itemNum.Text, stock.Text, unitSize.Text, unitMeasure.Text, category.Text, price.Text);
            // this is lousily implemented as of now, but clearing the result list on update is still better (at this stage) than the results showing
            // outdated data... will get back to this later
            lv.ItemsSource = null;
            searchBox.Text = "";




        }
        

        
    }
}

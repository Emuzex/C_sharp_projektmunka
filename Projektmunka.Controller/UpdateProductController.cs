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
        UpdateProductModel model = new UpdateProductModel();
        public void searchDatabase(TextBox tb, ListView result)
        {
            result.ItemsSource = null;
            if (!String.IsNullOrEmpty(tb.Text))
            {
                ProductList.Clear();
                DataTable dt = model.searchProducts(tb.Text);
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
                        UnitSize = item["unit size"].ToString()
                    });


                }
                result.ItemsSource = ProductList;

            }
            

        }
        public void setFields(int index, TextBox name, TextBox itemNum, TextBox stock, ComboBox category, ComboBox discount)
        {
            Product product;
            try
            {
                product = ProductList[index];
                
            }
            catch
            {
                product = new Product();
            }
            name.Text = product.Name;
            itemNum.Text = product.ItemNum;
            stock.Text = product.Stock;
            switch (product.Category)
            {
                case "Élelmiszer": category.SelectedIndex = 0; break;
                case "Háztartási vegyiáru": category.SelectedIndex = 1; break;
                case "Szeszesital": category.SelectedIndex = 2; break;
                case "Kozmetikum": category.SelectedIndex = 3; break;
            }
        }
        

        
    }
}

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
        
        public List<Product> getProductList()
        {
            return ProductList;
        }
        public List<Product> searchDatabase(string keyword)
        {
            
            
            if (!String.IsNullOrEmpty(keyword))
            {
                ProductList.Clear();
                DataTable dt = model.searchProducts(keyword);
                
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
                
            }
            return ProductList;

        }
        
        public void update(string name, string itemNum, string stock, string category, string discount, string price, string unitMeasure, string unitSize, string searchBox, string id) {
            model.update(name, itemNum, stock, unitSize, unitMeasure, category, price, id, discount);
        }
        
        public bool sell(string quantity, string prodNum)
        {
            bool retval = false;
            if (model.sellProduct(quantity, prodNum) > 0) retval = true;
            
            
            return retval;
        }

        
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Projektmunka.Model;
using MySql.Data;
using MySql.Data.MySqlClient;
using Projektmunka.Controller;

namespace Projektmunka
{
    
    public partial class MainWindow : Window
    {

        
        View view = new View();
        
        public MainWindow()
        {
            
            InitializeComponent();
            submit2.IsEnabled = false;
            edit.IsEnabled = false;
            
            

        }
        
        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            
            view.populateListview(searchBox, results);   

        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
              view.updateProduct(prodName1, prodNum1, stock1, category1, discount, price1, unit1, unitSize, searchBox, id1, results);
              view.clear(results, searchBox);

        }

        private void results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            view.setFields(results, prodName1, prodNum1, stock1, category1, discount, price1, unit1, unitSize, id1);
         

        }
        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            
            view.validateTextInput(prodName2, stockNum2, itemNum2, itemPrice2, unitMeasure2, submit2);
            
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            view.addNewProduct(prodName2, stockNum2, itemNum2, itemPrice2, submit2, category2, unit2, unitMeasure2);
            
        }
        private void login_Click(object sender, RoutedEventArgs e)
        {
            view.authenticate(username, pass, edit, submit2);
        }
        private void sell_Click(object sender, RoutedEventArgs e)
        {
            view.sell(stock1, id1, results, searchBox);
        }
        


        }
    }





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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        UpdateProductController ctrl1 = new UpdateProductController();
        NewProductController ctrl2 = new NewProductController();
        public MainWindow()
        {
            
            InitializeComponent();
        }
        
        private void searchBox_KeyUp(object sender, KeyEventArgs e)
        {
            TextBox tb = sender as TextBox;
            ctrl1.searchDatabase(tb, results);
            
            
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {

            ctrl1.update(results, prodName1, prodNum1, stock1, category1, discount, price1, unit1, unitSize, searchBox);
            
        }

        private void results_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ListView lv = sender as ListView;
            // ezt be kell fejezni a Controllerben, meg a .xaml-ben, de már a faszom tele van vele, lefekszem a picsába
            
            ctrl1.setFields(lv, prodName1, prodNum1, stock1, category1, discount, price1, unit1, unitSize);
        }
        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            
            ctrl2.validateTextInput(prodName2, stockNum2, itemNum2, itemPrice2, unitMeasure2, submit2);
            
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            ctrl2.submitData(prodName2, stockNum2, itemNum2, itemPrice2, submit2, category2, unit2, unitMeasure2);
        }

    }

}


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
using System.Windows.Shapes;
using Projektmunka.Controller;

namespace Projektmunka
{
    /// <summary>
    /// Interaction logic for AddProductWindow.xaml
    /// </summary>
    public partial class AddProductWindow : Window
    {
        
        NewProductController ctrl = new NewProductController();
        public AddProductWindow()
        {
            InitializeComponent();
            submit.IsEnabled = false;
        }

        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            
            ctrl.validateTextInput(prodName, stockNum, itemNum, itemPrice, submit);
            
        }

        private void submit_Click(object sender, RoutedEventArgs e)
        {
            ctrl.submitData();
        }

    }
}

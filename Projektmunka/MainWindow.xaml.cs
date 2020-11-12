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
namespace Projektmunka
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void b1_Click(object sender, RoutedEventArgs e)
        {
            AddProductWindow prodWindow = new AddProductWindow();
            prodWindow.Show();
            this.Close();
        }
        private void b2_Click(object sender, RoutedEventArgs e)
        {
            UpdateProduct upd = new UpdateProduct();
            upd.Show();
            this.Close();
        }
    }
}

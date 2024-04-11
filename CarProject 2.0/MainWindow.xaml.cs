using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarProject_2._0.model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarProject_2._0
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
           
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teststackPanel.Visibility = Visibility.Visible;

            Login login = new Login();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            // Your code for Button_Click_3
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            // Your code for Button_Click_1
        }

        private void balanceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            // Your code for balanceText_TextChanged
        }
    }
}
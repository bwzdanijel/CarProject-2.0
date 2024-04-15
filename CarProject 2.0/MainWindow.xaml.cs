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
            InitializeComponent();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teststackPanel.Visibility = Visibility.Visible;

            /*
            Console.WriteLine("The list of databases on this server is: ");
            foreach (var db in dbList)
            {
                Console.WriteLine(db);
            }*/
        }



        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void balanceText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


        private void buttonEngine_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Visible;
            panelSpoiler.Visibility = Visibility.Collapsed;
        }

        private void buttonSpoiler_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Collapsed;
            panelSpoiler.Visibility = Visibility.Visible;
        }




        //ones
        private void oneone_Click(object sender, RoutedEventArgs e)
        {
            oneone.Content = "use";
        }

        private void onetwo_Click(object sender, RoutedEventArgs e)
        {
            onetwo.Content = "use";
        }

        private void onethree_Click(object sender, RoutedEventArgs e)
        {
            onethree.Content = "use";
        }

        //twos
        private void twoone_Click(object sender, RoutedEventArgs e)
        {
            twoone.Content = "use";
        }

        private void twotwo_Click(object sender, RoutedEventArgs e)
        {
            twotwo.Content = "use";
        }

        private void twothree_Click(object sender, RoutedEventArgs e)
        {
            twothree.Content = "use";
        }

        private void brake1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void brake2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void brake3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tires1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tires2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tires3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nitrous1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nitrous2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nitrous3_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
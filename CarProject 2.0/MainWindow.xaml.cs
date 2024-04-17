using System.DirectoryServices.ActiveDirectory;
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
using CarProject_2._0.controller;
using CarProject_2._0.model;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarProject_2._0
{
    public partial class MainWindow : Window
    { 
        private MainController mainController = new MainController();
        private Car selectedCar; 
        private CarModel selectedCarModel;
        private DbAccess dbAccess;

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

        ////////////////Button Navigation List /////////////////////////////////////////////////////////////////////////////////
        private void buttonEngine_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Visible;
            panelSpoiler.Visibility = Visibility.Collapsed;
            panelBrake.Visibility = Visibility.Collapsed;
            panelTires.Visibility = Visibility.Collapsed;
            panelNitrous.Visibility = Visibility.Collapsed;
        }

        private void buttonSpoiler_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Collapsed;
            panelSpoiler.Visibility = Visibility.Visible;
            panelBrake.Visibility = Visibility.Collapsed;
            panelTires.Visibility = Visibility.Collapsed;
            panelNitrous.Visibility = Visibility.Collapsed;
        }

        private void buttonBrake_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Collapsed;
            panelSpoiler.Visibility = Visibility.Collapsed;
            panelBrake.Visibility = Visibility.Visible;
            panelTires.Visibility = Visibility.Collapsed;
            panelNitrous.Visibility = Visibility.Collapsed;
        }

        private void buttonTires_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Collapsed;
            panelSpoiler.Visibility = Visibility.Collapsed;
            panelBrake.Visibility = Visibility.Collapsed;
            panelTires.Visibility = Visibility.Visible;
            panelNitrous.Visibility = Visibility.Collapsed;
        }

        private void buttonNitrous_Click(object sender, RoutedEventArgs e)
        {
            panelEngine.Visibility = Visibility.Collapsed;
            panelSpoiler.Visibility = Visibility.Collapsed;
            panelBrake.Visibility = Visibility.Collapsed;
            panelTires.Visibility = Visibility.Collapsed;
            panelNitrous.Visibility = Visibility.Visible;
        }





        ////////////////RadioButton Navigation List /////////////////////////////////////////////////////////////////////////////////


        private void redCarButton_Checked(object sender, RoutedEventArgs e)
        {
            panelRedCar.Visibility = Visibility.Visible;
            panelBlueCar.Visibility = Visibility.Collapsed;
            panelLamboCar.Visibility = Visibility.Collapsed;

        }

        private void blueCarButton_Checked(object sender, RoutedEventArgs e)
        {
            panelRedCar.Visibility = Visibility.Collapsed;
            panelBlueCar.Visibility = Visibility.Visible;
            panelLamboCar.Visibility = Visibility.Collapsed;

        }

        private void lamboCarButton_Checked(object sender, RoutedEventArgs e)
        {
            panelRedCar.Visibility = Visibility.Collapsed;
            panelBlueCar.Visibility = Visibility.Collapsed;
            panelLamboCar.Visibility = Visibility.Visible;

        }


        ////////////////Select Button/////////////////////////////////////////////////////////////////////////////////
        private void redCarButton1_Click(object sender, RoutedEventArgs e)
        {

            MainController mainController = new MainController();
            mainController.CopyCarToConfiguration("Red Monster");


        }

        private void bluCarButton2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void lamboCarButton3_Click(object sender, RoutedEventArgs e)
        {

        }


        //ENGINE
        private void engine1_Click(object sender, RoutedEventArgs e)
        {
            engine1.Content = "use";

        }
        private void engine2_Click(object sender, RoutedEventArgs e)
        {
            engine2.Content = "use";
        }

        private void engine3_Click(object sender, RoutedEventArgs e)
        {
            engine3.Content = "use";
        }


        //SPOILER
        private void spoiler1_Click(object sender, RoutedEventArgs e)
        {
            spoiler1.Content = "use";
        }

        private void spoiler2_Click(object sender, RoutedEventArgs e)
        {
            spoiler2.Content = "use";
        }

        private void spoiler3_Click(object sender, RoutedEventArgs e)
        {
            spoiler3.Content = "use";
        }


        //BRAKE
        private void brake1_Click(object sender, RoutedEventArgs e)
        {

        }

        private void brake2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void brake3_Click(object sender, RoutedEventArgs e)
        {

        }

        //TIRES
        private void tires1_Click(object sender, RoutedEventArgs e)
        {
        }

        private void tires2_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tires3_Click(object sender, RoutedEventArgs e)
        {
        }

        //NITROUS
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
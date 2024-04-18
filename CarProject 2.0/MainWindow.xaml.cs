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

using System.Xml.Linq;

using MongoDB.Bson;
using MongoDB.Driver;

namespace CarProject_2._0
{
    public partial class MainWindow : Window
    {
        private MainController mainController;
        private Guid loggedInUserId;
        private string selectedCarName;

        public MainWindow()
        {
            InitializeComponent();

            DbAccess dbAccess = new DbAccess();
            dbAccess.DbConnection();
            mainController = new MainController();
            mainController.InsertCars();
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

            redCarButton1.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        }

        private void blueCarButton_Checked(object sender, RoutedEventArgs e)
        {
            panelRedCar.Visibility = Visibility.Collapsed;
            panelBlueCar.Visibility = Visibility.Visible;
            panelLamboCar.Visibility = Visibility.Collapsed;

            bluCarButton2.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));

        }

        private void lamboCarButton_Checked(object sender, RoutedEventArgs e)
        {
            panelRedCar.Visibility = Visibility.Collapsed;
            panelBlueCar.Visibility = Visibility.Collapsed;
            panelLamboCar.Visibility = Visibility.Visible;

            lamboCarButton3.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
        }


        ////////////////Select Button/////////////////////////////////////////////////////////////////////////////////

        const int power1 = 20;
        const int performance1 = 40;
        const int acceleration1 = 10;
        const int grip1 = 30;
        const int steering1 = 45;
        const int nitrous11 = 5;

        const int power2 = 40;
        const int performance2 = 50;
        const int acceleration2 = 30;
        const int grip2 = 45;
        const int steering2 = 35;
        const int nitrous22 = 20;

        const int power3 = 60;
        const int performance3 = 65;
        const int acceleration3 = 50;
        const int grip3 = 45;
        const int steering3 = 55;
        const int nitrous33 = 35;

        private void redCarButton1_Click(object sender, RoutedEventArgs e)
        {
            selectedCarName = "Red Monster";
            engine1.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);

            //progressPower.Value = 20;
            //progressPerformance.Value = 40;
            //progressAcceleration.Value = 10;
            //progressGrip.Value = 30;
            //progressSteering.Value = 45;
            //progressNitrous.Value = 5;

            progressPower.Value = power1;
            progressPerformance.Value = performance1;
            progressAcceleration.Value = acceleration1;
            progressGrip.Value = grip1;
            progressSteering.Value = steering1;
            progressNitrous.Value = nitrous11;
        }

        private void bluCarButton2_Click(object sender, RoutedEventArgs e)
        {
            selectedCarName = "Silver Bullet";
            engine2.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);

            //progressPower.Value = 40;
            //progressPerformance.Value = 50;
            //progressAcceleration.Value = 30;
            //progressGrip.Value = 45;
            //progressSteering.Value = 35;
            //progressNitrous.Value = 20;

            progressPower.Value = power2;
            progressPerformance.Value = performance2;
            progressAcceleration.Value = acceleration2;
            progressGrip.Value = grip2;
            progressSteering.Value = steering2;
            progressNitrous.Value = nitrous22;

        }

        private void lamboCarButton3_Click(object sender, RoutedEventArgs e)
        {
            selectedCarName = "Black Panther";
            engine3.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);

            //progressPower.Value = 60;
            //progressPerformance.Value = 65;
            //progressAcceleration.Value = 50;
            //progressGrip.Value = 45;
            //progressSteering.Value = 55;
            //progressNitrous.Value = 35;

            progressPower.Value = power3;
            progressPerformance.Value = performance3;
            progressAcceleration.Value = acceleration3;
            progressGrip.Value = grip3;
            progressSteering.Value = steering3;
            progressNitrous.Value = nitrous33;
        }



        //ENGINE
        private void engine1_Click(object sender, RoutedEventArgs e)
        {
            engine1.Content = "use";
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "V6");

            progressPower.Value = progressPower.Value + 5;

        }
        private void engine2_Click(object sender, RoutedEventArgs e)
        {
            engine2.Content = "use";
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Inline-4");

            progressPower.Value = progressPower.Value + 10;
            progressAcceleration.Value = progressAcceleration.Value + 5;
        }

        private void engine3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "V10");

            progressPower.Value = progressPower.Value + 20;
            progressAcceleration.Value = progressAcceleration.Value + 10;

        }


        //SPOILER
        private void spoiler1_Click(object sender, RoutedEventArgs e)
        {
            spoiler1.Content = "use";
            mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Carbon Fiber Spoiler");

            progressPerformance.Value = progressPerformance.Value + 5;
            progressPower.Value = progressPower.Value - 10;
        }

        private void spoiler2_Click(object sender, RoutedEventArgs e)
        {
            spoiler2.Content = "use";
            mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Sport Spoiler");

            progressPerformance.Value = progressPerformance.Value + 10;
            progressGrip.Value = progressGrip.Value + 10;
            progressPower.Value = progressPower.Value - 15;
        }

        private void spoiler3_Click(object sender, RoutedEventArgs e)
        {
            spoiler3.Content = "use";
            mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Winged Rear Spoiler");

            progressPerformance.Value = progressPerformance.Value + 25;
            progressSteering.Value = progressSteering.Value + 10;
            progressPower.Value = progressPower.Value - 15;
            progressAcceleration.Value = progressAcceleration.Value - 5;

        }


        //BRAKE
        private void brake1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "Performance Carbon Ceramic Brake");

            progressPerformance.Value = progressPerformance.Value + 5;

        }

        private void brake2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "Sport Performance Brake");

            progressPerformance.Value = progressPerformance.Value + 10;


        }

        private void brake3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "High Performance Brake System");

            progressPerformance.Value = progressPerformance.Value + 15;


        }

        //TIRES
        private void tires1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Ultra Performance Tires");

            progressGrip.Value = progressGrip.Value + 10;
            progressPerformance.Value = progressPerformance.Value + 5;
        }

        private void tires2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Sport Performance Tires");

            progressGrip.Value = progressGrip.Value + 15;
            progressPerformance.Value = progressPerformance.Value + 10;
        }

        private void tires3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "High Performance Tires");

            progressGrip.Value = progressGrip.Value + 20;
            progressPerformance.Value = progressPerformance.Value + 15;

        }

        //NITROUS
        private void nitrous1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "20%");

            progressNitrous.Value = progressNitrous.Value + 20;

        }

        private void nitrous2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "60%");

            progressNitrous.Value = progressNitrous.Value + 60;

        }

        private void nitrous3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "100%");

            progressNitrous.Value = progressNitrous.Value + 100;
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usernameText_TextChanged(object sender, TextChangedEventArgs e)

        {

        }

        private void progressNitrous_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void progressPower_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
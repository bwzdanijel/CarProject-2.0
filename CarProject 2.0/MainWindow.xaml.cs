﻿using System.DirectoryServices.ActiveDirectory;
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
            mainController.InserUser();
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


        /////////////////Balance 


        public void DbConnection()
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("TuningConfigurator");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("User");

            var filter = Builders<BsonDocument>.Filter.Eq("Name", "player1");
            var userDocument = collection.Find(filter).FirstOrDefault();

            if (userDocument != null)
            {
                if (userDocument.TryGetValue("Balance", out BsonValue balanceValue))
                {
                    balanceText.Text = balanceValue.ToString();
                }
                else
                {
                    Console.WriteLine("Balance-Feld nicht gefunden");
                }
            }
            else
            {
                Console.WriteLine("Benutzer nicht gefunden");
            }
        }

        private void balanceText_TextChanged(object sender, TextChangedEventArgs e)
        {
            DbConnection();
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
            selectedCarName = "Red Monster";
            engine1.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);

        }

        private void bluCarButton2_Click(object sender, RoutedEventArgs e)
        {
            selectedCarName = "Silver Bullet";
            engine2.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);
        }

        private void lamboCarButton3_Click(object sender, RoutedEventArgs e)
        {
            selectedCarName = "Black Panther";
            engine3.Content = "use"; 
            mainController.CopyCarData(new List<string> { selectedCarName }, loggedInUserId);
        }



        //ENGINE
        private void engine1_Click(object sender, RoutedEventArgs e)
        {
            engine1.Content = "use";
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "V6");
        }
        private void engine2_Click(object sender, RoutedEventArgs e)
        {
            engine2.Content = "use";
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Inline-4");
        }

        private void engine3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "V10");
        }


        //SPOILER

        private string previousSpoilerButton = ""; 

        private void UpdateSpoilerStatus(Button clickedSpoilerButton)
        {
            if (clickedSpoilerButton.Content.ToString() == "BUY")
            {
                clickedSpoilerButton.Content = "USE";
            }
            else if (clickedSpoilerButton.Content.ToString() == "USE")
            {
                clickedSpoilerButton.Content = "USED";
            }

            // Setze die anderen Buttons zurück
            if (previousSpoilerButton != "")
            {
                Button previousButton = FindName(previousSpoilerButton) as Button;
                if (previousButton != null && previousButton != clickedSpoilerButton)
                {
                    previousButton.Content = "USE";
                }
            }

            // Aktualisiere den vorherigen Button
            previousSpoilerButton = clickedSpoilerButton.Name;
        }

        private void spoiler1_Click(object sender, RoutedEventArgs e)
        {
            UpdateSpoilerStatus(sender as Button);

            if (spoiler1.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-1000);
                DbConnection();
            }
            else if (spoiler1.Content.ToString() == "USED")
            {
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Carbon Fiber Spoiler");
            }
        }

        private void spoiler2_Click(object sender, RoutedEventArgs e)
        {
            UpdateSpoilerStatus(sender as Button);

            if (spoiler2.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-17000);
                DbConnection();
            }
            else if(spoiler2.Content.ToString() == "USED")
            {
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Sport Spoiler");

            }
        }

        private void spoiler3_Click(object sender, RoutedEventArgs e)
        {
            UpdateSpoilerStatus(sender as Button);

            if (spoiler3.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-28000);
                DbConnection();
            }
            else if (spoiler3.Content.ToString() == "USED")
            {
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Winged Rear Spoiler");
            }
        }







        //BRAKE
        private void brake1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "Performance Carbon Ceramic Brake");

        }

        private void brake2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "Sport Performance Brake");

        }

        private void brake3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "High Performance Brake System");

        }

        //TIRES
        private void tires1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Ultra Performance Tires");

        }

        private void tires2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Sport Performance Tires");

        }

        private void tires3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "High Performance Tires");

        }

        //NITROUS
        private void nitrous1_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "20%");

        }

        private void nitrous2_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "60%");

        }

        private void nitrous3_Click(object sender, RoutedEventArgs e)
        {
            mainController.UpdateCarNitrous(selectedCarName ?? "DefaultCarName", "100%");

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usernameText_TextChanged(object sender, TextChangedEventArgs e)

        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("TuningConfigurator");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("User");

            var filter = Builders<BsonDocument>.Filter.Eq("Name", "player1");
            var userDocument = collection.Find(filter).FirstOrDefault();

            if (userDocument != null)
            {
                string username = userDocument.GetValue("Name").AsString;
            }
            else
            {
                Console.WriteLine("Benutzer nicht gefunden");
            }
        }
    }
}
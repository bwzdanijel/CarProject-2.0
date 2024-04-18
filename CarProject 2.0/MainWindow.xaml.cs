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


        private string previousEngineButton = "";

        private void UpdateEngineStatus(Button clickedEngineButton)
        {
            if (clickedEngineButton.Content.ToString() == "BUY")
            {
                clickedEngineButton.Content = "USE";
            }
            else if (clickedEngineButton.Content.ToString() == "USE")
            {
                clickedEngineButton.Content = "USED";
            }

            if (previousEngineButton != "")
            {
                Button previousButton = FindName(previousSpoilerButton) as Button;
                if (previousButton != null && previousButton != clickedEngineButton)
                {
                    previousButton.Content = "USE";
                }
            }

            previousEngineButton = clickedEngineButton.Name;
        }

        //ENGINE
        private void engine1_Click(object sender, RoutedEventArgs e)
        {

            UpdateEngineStatus(sender as Button);


            if (engine1.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-1000);
                DbConnection();
            }
            else if (engine1.Content.ToString() == "USED")
            {
                mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Endgy Engine");
                progressPower.Value = progressPower.Value + 5;
            }


        }
        private void engine2_Click(object sender, RoutedEventArgs e)
        {
            UpdateEngineStatus(sender as Button);


            if (engine2.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-17000);
                DbConnection();
            }
            else if (engine2.Content.ToString() == "USED")
            {
                mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Engunus Maximus");
                progressPower.Value = progressPower.Value + 10;
                progressAcceleration.Value = progressAcceleration.Value + 5;

            }

        }

        private void engine3_Click(object sender, RoutedEventArgs e)
        {
            UpdateEngineStatus(sender as Button);


            if (engine3.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-28000);
                DbConnection();
            }
            else if (engine3.Content.ToString() == "USED")
            {
                mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Engine Ultra Pro Max 5000");

                progressPower.Value = progressPower.Value + 20;
                progressAcceleration.Value = progressAcceleration.Value + 10;
            }
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
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Spoily Spoiler");
                progressPerformance.Value = progressPerformance.Value + 5;
                progressPower.Value = progressPower.Value - 10;
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
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Spoilerus Maximus");
                progressPerformance.Value = progressPerformance.Value + 10;
                progressGrip.Value = progressGrip.Value + 10;
                progressPower.Value = progressPower.Value - 15;

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
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Spoily Ultra Pro Max 6000");

                progressPerformance.Value = progressPerformance.Value + 25;
                progressSteering.Value = progressSteering.Value + 10;
                progressPower.Value = progressPower.Value - 15;
                progressAcceleration.Value = progressAcceleration.Value - 5;
            }


        }







        //BRAKE
        private string previousBrakeButton = "";

        private void UpdateBrakeStatus(Button clickedBrakeButton)
        {
            if (clickedBrakeButton.Content.ToString() == "BUY")
            {
                clickedBrakeButton.Content = "USE";
            }
            else if (clickedBrakeButton.Content.ToString() == "USE")
            {
                clickedBrakeButton.Content = "USED";
            }

            // Setze die anderen Buttons zurück
            if (previousBrakeButton != "")
            {
                Button previousButton = FindName(previousBrakeButton) as Button;
                if (previousButton != null && previousButton != clickedBrakeButton)
                {
                    previousButton.Content = "USE";
                }
            }

            // Aktualisiere den vorherigen Button
            previousBrakeButton = clickedBrakeButton.Name;
        }

        private void brake1_Click(object sender, RoutedEventArgs e)
        {
            UpdateBrakeStatus(sender as Button);


            if (brake1.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-1000);
                DbConnection();
            }
            else if (brake1.Content.ToString() == "USED")
            {
                mainController.UpdateCarBrake(selectedCarName ?? "DefaultCarName", "Breaky Brake");
                progressPerformance.Value = progressPerformance.Value + 5;
            }

        }

        private void brake2_Click(object sender, RoutedEventArgs e)
        {
            UpdateBrakeStatus(sender as Button);


            if (brake2.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-17000);
                DbConnection();
            }
            else if (brake2.Content.ToString() == "USED")
            {
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Breaking King");
                progressPerformance.Value = progressPerformance.Value + 10;

            }


        }

        private void brake3_Click(object sender, RoutedEventArgs e)
        {
            UpdateBrakeStatus(sender as Button);


            if (brake3.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-28000);
                DbConnection();
            }
            else if (brake3.Content.ToString() == "USED")
            {
                mainController.UpdateCarSpoiler(selectedCarName ?? "DefaultCarName", "Breakus Maximus");

                progressPerformance.Value = progressPerformance.Value + 15;
            }


        }

        //TIRES
        private string previousTiresButton = "";

        private void UpdateTiresStatus(Button clickedTiresButton)
        {
            if (clickedTiresButton.Content.ToString() == "BUY")
            {
                clickedTiresButton.Content = "USE";
            }
            else if (clickedTiresButton.Content.ToString() == "USE")
            {
                clickedTiresButton.Content = "USED";
            }

            // Setze die anderen Buttons zurück
            if (previousTiresButton != "")
            {
                Button previousButton = FindName(previousTiresButton) as Button;
                if (previousButton != null && previousButton != clickedTiresButton)
                {
                    previousButton.Content = "USE";
                }
            }

            // Aktualisiere den vorherigen Button
            previousTiresButton = clickedTiresButton.Name;
        }

        private void tires1_Click(object sender, RoutedEventArgs e)
        {
            UpdateTiresStatus(sender as Button);


            if (tires1.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-1000);
                DbConnection();
            }
            else if (tires1.Content.ToString() == "USED")
            {
                mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Spoily Spoiler");//name
                progressGrip.Value = progressGrip.Value + 10;
                progressPerformance.Value = progressPerformance.Value + 5;
            }


        }

        private void tires2_Click(object sender, RoutedEventArgs e)
        {
            UpdateTiresStatus(sender as Button);


            if (tires2.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-17000);
                DbConnection();
            }
            else if (tires2.Content.ToString() == "USED")
            {
                mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Spoilerus Maximus");//name


                progressGrip.Value = progressGrip.Value + 15;
                progressPerformance.Value = progressPerformance.Value + 10;

            }

        }

        private void tires3_Click(object sender, RoutedEventArgs e)
        {
            UpdateTiresStatus(sender as Button);


            if (tires3.Content.ToString() == "USE")
            {
                mainController.UpdateUserBalance(-28000);
                DbConnection();
            }
            else if (tires3.Content.ToString() == "USED")
            {
                mainController.UpdateCarTire(selectedCarName ?? "DefaultCarName", "Spoily Ultra Pro Max 6000");//Name

                progressGrip.Value = progressGrip.Value + 20;
                progressPerformance.Value = progressPerformance.Value + 15;
            }



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

        private void progressNitrous_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }

        private void progressPower_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
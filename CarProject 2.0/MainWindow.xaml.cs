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
using System.Xml.Linq;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CarProject_2._0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("TuningConfigurator");

            var collection = database.GetCollection<BsonDocument>("Properties");
            var document = collection.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            var collection2 = database.GetCollection<BsonDocument>("User");
            var document2 = collection2.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            progressPower.Value = document.GetValue("Power").AsInt32;
            progressPerformance.Value = document.GetValue("Performance").AsInt32;
            progressAcceleration.Value = document.GetValue("Acceleration").AsInt32;
            progressGrip.Value = document.GetValue("Grip").AsInt32;
            progressSteering.Value = document.GetValue("Steering").AsInt32;
            progressNitrous.Value = document.GetValue("Nitrous").AsInt32;

            //balanceText.Text = document2.GetValue("Balance").ToString("#,##0");

            int balance = document2.GetValue("Balance").AsInt32;
            balanceText.Text = balance.ToString("#,##0");


            //crate a document in collection
            /*
            MongoClient createMongo = new MongoClient("mongodb://localhost:27017");
            var cdb = createMongo.GetDatabase("TuningConfigurator");
            var createcollection = cdb.GetCollection<BsonDocument>("User");

            BsonDocument createDocument = new BsonDocument()
            {
                { "User", "Mademidda187" },
                { "Password", "xyz" },
                { "Balance", 100700 },


            };

            createcollection.InsertOne(createDocument);
            */

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
            DBconnection dbconnectionUser = new DBconnection();
            BsonDocument documentUser = dbconnectionUser.UserConnection();
            IMongoCollection<BsonDocument> collectionUsers = dbconnectionUser.GetUserCollection();




            if ((String)oneone.Content == "BUY")
            {
                int newBalanceEngine1 = documentUser.GetValue("Balance").AsInt32;

                if (newBalanceEngine1 >= 1500) 
                {
                    int result = newBalanceEngine1 - 1500;

                    var filter = Builders<BsonDocument>.Filter.Eq("Balance", newBalanceEngine1);
                    var update = Builders<BsonDocument>.Update.Set("Balance", result);

                    collectionUsers.UpdateOne(filter, update);

                    int balance2 = result;
                    balanceText.Text = balance2.ToString("#,##0");

                }
                else
                {
                    MessageBox.Show("You are too broke", "Not enough money to buy this", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

                oneone.Content = "use";





            }
            else if ((String)oneone.Content == "use")
            {
                oneone.Content = "used";
                onetwo.Content = "use";
                onethree.Content = "use";
            }

        }

        private void onetwo_Click(object sender, RoutedEventArgs e)
        {
            if ((String)onetwo.Content == "BUY")
            {
                onetwo.Content = "use";
            }
            else if ((String)onetwo.Content == "use")
            {
                onetwo.Content = "used";
                oneone.Content = "use";
                onethree.Content = "use";
            }

        }

        private void onethree_Click(object sender, RoutedEventArgs e)
        {
            if ((String)onethree.Content == "BUY")
            {
                onethree.Content = "use";
            }
            else if ((String)onethree.Content == "use")
            {
                onethree.Content = "used";
                onetwo.Content = "use";
                oneone.Content = "use";
            }

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
    }
}
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


            MongoClient dbClientEngine = new MongoClient("mongodb://localhost:27017");

            var databaseEngine = dbClientEngine.GetDatabase("TuningConfigurator");

            var collectionEngine = databaseEngine.GetCollection<BsonDocument>("Engine");

            var documentEngine = collectionEngine.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();



            bool engineIsBought1 = documentEngine.GetValue("1EngineIsBought").AsBoolean;
            bool engineIsBought2 = documentEngine.GetValue("2EngineIsBought").AsBoolean;
            bool engineIsBought3 = documentEngine.GetValue("3EngineIsBought").AsBoolean;

            bool engineIsSelected1 = documentEngine.GetValue("1EngineIsSelected").AsBoolean;
            bool engineIsSelected2 = documentEngine.GetValue("2EngineIsSelected").AsBoolean;
            bool engineIsSelected3 = documentEngine.GetValue("3EngineIsSelected").AsBoolean;

            

            //first engine button
            if (engineIsBought1 == false)
            {
                oneone.Content = "BUY";
            }
            else if (engineIsBought1 == true)
            {
                oneone.Content = "use";
            }
            else if (engineIsSelected1 == true)
            {
                oneone.Content = "used";


                if (engineIsBought2 == true)
                {
                    onetwo.Content = "use";
                }
                else if (engineIsBought3 == true)
                {
                    onethree.Content = "use";
                }
            }


            //second engine Button
            if (engineIsBought2 == false)
            {
                onetwo.Content = "BUY";
            }
            else if (engineIsBought2 == true)
            {
                onetwo.Content = "use";
            }
            else if (engineIsSelected2 == true)
            {
                onetwo.Content = "used";


                if (engineIsBought1 == true)
                {
                    oneone.Content = "use";
                }
                else if (engineIsBought3 == true)
                {
                    onethree.Content = "use";
                }
            }


            //third engine button
            if (engineIsBought3 == false)
            {
                onethree.Content = "BUY";
            }
            else if (engineIsBought3 == true)
            {
                onethree.Content = "use";
            }
            else if (engineIsSelected3 == true)
            {
                onethree.Content = "used";


                if (engineIsBought2 == true)
                {
                    onetwo.Content = "use";
                }
                else if (engineIsBought1 == true)
                {
                    oneone.Content = "use";
                }
            }

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




       

        // oneone_Click
        private void oneone_Click(object sender, RoutedEventArgs e)
        {
            DBconnection dbconnectionUser = new DBconnection();
            BsonDocument documentUser = dbconnectionUser.UserConnection();
            IMongoCollection<BsonDocument> collectionUsers = dbconnectionUser.GetUserCollection();

            MongoClient dbClientEngine = new MongoClient("mongodb://localhost:27017");
            var databaseEngine = dbClientEngine.GetDatabase("TuningConfigurator");
            var collectionEngine = databaseEngine.GetCollection<BsonDocument>("Engine");
            var documentEngine = collectionEngine.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            bool engineIsBought1 = documentEngine.GetValue("1EngineIsBought").AsBoolean;
            bool engineIsBought2 = documentEngine.GetValue("2EngineIsBought").AsBoolean;
            bool engineIsBought3 = documentEngine.GetValue("3EngineIsBought").AsBoolean;

            bool engineIsSelected1 = documentEngine.GetValue("1EngineIsSelected").AsBoolean;
            bool engineIsSelected2 = documentEngine.GetValue("2EngineIsSelected").AsBoolean;
            bool engineIsSelected3 = documentEngine.GetValue("3EngineIsSelected").AsBoolean;

            if ((String)oneone.Content == "BUY")
            {
                int newBalanceEngine1 = documentUser.GetValue("Balance").AsInt32;

                if (newBalanceEngine1 >= 1500)
                {
                    int result = newBalanceEngine1 - 1500;

                    var filterUser1 = Builders<BsonDocument>.Filter.Eq("Balance", newBalanceEngine1);
                    var updateUser1 = Builders<BsonDocument>.Update.Set("Balance", result);

                    collectionUsers.UpdateOne(filterUser1, updateUser1);

                    int balance2 = result;
                    balanceText.Text = balance2.ToString("#,##0");
                }
                else
                {
                    MessageBox.Show("Not enough money to buy this", "You are too broke", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

                var filterEngine1 = Builders<BsonDocument>.Filter.Eq("1EngineIsBought", engineIsBought1);
                var updateEngine1 = Builders<BsonDocument>.Update.Set("1EngineIsBought", true);

                collectionEngine.UpdateOne(filterEngine1, updateEngine1);

                oneone.Content = "use";
            }
            else if ((String)oneone.Content == "use")
            {
                var filterEngineSelect1 = Builders<BsonDocument>.Filter.Eq("1EngineIsSelected", engineIsSelected1);
                var updateEngineSelected1 = Builders<BsonDocument>.Update.Set("1EngineIsSelected", true);

                collectionEngine.UpdateOne(filterEngineSelect1, updateEngineSelected1);

                progressPower.Value = 90;
                oneone.Content = "used";

                if (engineIsBought2)
                {
                    var filterEngineSelect2 = Builders<BsonDocument>.Filter.Eq("2EngineIsSelected", true);
                    var updateEngineSelected2 = Builders<BsonDocument>.Update.Set("2EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelect2, updateEngineSelected2);

                    onetwo.Content = "use";
                }
                else if (engineIsBought3)
                {
                    var filterEngineSelect3 = Builders<BsonDocument>.Filter.Eq("3EngineIsSelected", true);
                    var updateEngineSelected3 = Builders<BsonDocument>.Update.Set("3EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelect3, updateEngineSelected3);

                    onethree.Content = "use";
                }
            }
            if (engineIsSelected1)
            {
                var filterEngineSelct111 = Builders<BsonDocument>.Filter.Eq("1EngineIsSelected", engineIsSelected1);
                var updateEngineSelected111 = Builders<BsonDocument>.Update.Set("1EngineIsSelected", true);

                collectionEngine.UpdateOne(filterEngineSelct111, updateEngineSelected111);

                progressPower.Value = 90;
                oneone.Content = "used";

                if (engineIsBought2)
                {
                    var filterEngineSelct11 = Builders<BsonDocument>.Filter.Eq("2EngineIsSelected", engineIsSelected2);
                    var updateEngineSelected11 = Builders<BsonDocument>.Update.Set("2EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelct11, updateEngineSelected11);

                    onetwo.Content = "use";
                }
                else if (engineIsBought3)
                {
                    var filterEngineSelct1111 = Builders<BsonDocument>.Filter.Eq("3EngineIsSelected", engineIsSelected3);
                    var updateEngineSelected1111 = Builders<BsonDocument>.Update.Set("3EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelct1111, updateEngineSelected1111);

                    onethree.Content = "use";
                }
            }
        }



       
        // onetwo_Click
        private void onetwo_Click(object sender, RoutedEventArgs e)
        {
            DBconnection dbconnectionUser = new DBconnection();
            BsonDocument documentUser = dbconnectionUser.UserConnection();
            IMongoCollection<BsonDocument> collectionUsers = dbconnectionUser.GetUserCollection();

            MongoClient dbClientEngine = new MongoClient("mongodb://localhost:27017");
            var databaseEngine = dbClientEngine.GetDatabase("TuningConfigurator");
            var collectionEngine = databaseEngine.GetCollection<BsonDocument>("Engine");
            var documentEngine = collectionEngine.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            bool engineIsBought1 = documentEngine.GetValue("1EngineIsBought").AsBoolean;
            bool engineIsBought2 = documentEngine.GetValue("2EngineIsBought").AsBoolean;
            bool engineIsBought3 = documentEngine.GetValue("3EngineIsBought").AsBoolean;

            bool engineIsSelected1 = documentEngine.GetValue("1EngineIsSelected").AsBoolean;
            bool engineIsSelected2 = documentEngine.GetValue("2EngineIsSelected").AsBoolean;
            bool engineIsSelected3 = documentEngine.GetValue("3EngineIsSelected").AsBoolean;

            if ((String)onetwo.Content == "BUY")
            {
                int newBalanceEngine2 = documentUser.GetValue("Balance").AsInt32;

                if (newBalanceEngine2 >= 20000)
                {
                    int result = newBalanceEngine2 - 20000;

                    var filterUser2 = Builders<BsonDocument>.Filter.Eq("Balance", newBalanceEngine2);
                    var updateUser2 = Builders<BsonDocument>.Update.Set("Balance", result);

                    collectionUsers.UpdateOne(filterUser2, updateUser2);

                    int balance2 = result;
                    balanceText.Text = balance2.ToString("#,##0");

                }
                else
                {
                    MessageBox.Show("Not enough money to buy this", "You are too broke", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

                var filterEngine2 = Builders<BsonDocument>.Filter.Eq("2EngineIsBought", engineIsBought2);
                var updateEngine2 = Builders<BsonDocument>.Update.Set("2EngineIsBought", true);

                collectionEngine.UpdateOne(filterEngine2, updateEngine2);

                onetwo.Content = "use";
            }

            else if ((String)onetwo.Content == "use")
            {
                var filterEngineSelct2 = Builders<BsonDocument>.Filter.Eq("2EngineIsSelected", engineIsSelected2);
                var updateEngineSelected2 = Builders<BsonDocument>.Update.Set("2EngineIsSelected", true);

                collectionEngine.UpdateOne(filterEngineSelct2, updateEngineSelected2);

                progressPower.Value = 20;
                onetwo.Content = "used";

                if (engineIsBought1)
                {
                    var filterEngineSelect1 = Builders<BsonDocument>.Filter.Eq("1EngineIsSelected", true);
                    var updateEngineSelected1 = Builders<BsonDocument>.Update.Set("1EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelect1, updateEngineSelected1);

                    oneone.Content = "use";
                }
                else if (engineIsBought3)
                {
                    var filterEngineSelect3 = Builders<BsonDocument>.Filter.Eq("3EngineIsSelected", true);
                    var updateEngineSelected3 = Builders<BsonDocument>.Update.Set("3EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelect3, updateEngineSelected3);

                    onethree.Content = "use";
                }
            }
        }



        private void onethree_Click(object sender, RoutedEventArgs e)
        {
            DBconnection dbconnectionUser = new DBconnection();
            BsonDocument documentUser = dbconnectionUser.UserConnection();
            IMongoCollection<BsonDocument> collectionUsers = dbconnectionUser.GetUserCollection();

            MongoClient dbClientEngine = new MongoClient("mongodb://localhost:27017");
            var databaseEngine = dbClientEngine.GetDatabase("TuningConfigurator");
            var collectionEngine = databaseEngine.GetCollection<BsonDocument>("Engine");
            var documentEngine = collectionEngine.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            bool engineIsBought1 = documentEngine.GetValue("1EngineIsBought").AsBoolean;
            bool engineIsBought2 = documentEngine.GetValue("2EngineIsBought").AsBoolean;
            bool engineIsBought3 = documentEngine.GetValue("3EngineIsBought").AsBoolean;

            bool engineIsSelected1 = documentEngine.GetValue("1EngineIsSelected").AsBoolean;
            bool engineIsSelected2 = documentEngine.GetValue("2EngineIsSelected").AsBoolean;
            bool engineIsSelected3 = documentEngine.GetValue("3EngineIsSelected").AsBoolean;

            if ((String)onethree.Content == "BUY")
            {
                int newBalanceEngine3 = documentUser.GetValue("Balance").AsInt32;

                if (newBalanceEngine3 >= 1000000)
                {
                    int result = newBalanceEngine3 - 1000000;

                    var filterUser3 = Builders<BsonDocument>.Filter.Eq("Balance", newBalanceEngine3);
                    var updateUser3 = Builders<BsonDocument>.Update.Set("Balance", result);

                    collectionUsers.UpdateOne(filterUser3, updateUser3);

                    int balance3 = result;
                    balanceText.Text = balance3.ToString("#,##0");

                }
                else
                {
                    MessageBox.Show("Not enough money to buy this", "You are too broke", MessageBoxButton.OK, MessageBoxImage.Stop);
                }

                var filterEngine3 = Builders<BsonDocument>.Filter.Eq("3EngineIsBought", engineIsBought3);
                var updateEngine3 = Builders<BsonDocument>.Update.Set("3EngineIsBought", true);

                collectionEngine.UpdateOne(filterEngine3, updateEngine3);

                onethree.Content = "use";

            }
            else if ((String)onethree.Content == "use")
            {
                var filterEngineSelct3 = Builders<BsonDocument>.Filter.Eq("3EngineIsSelected", true);
                var updateEngineSelected3 = Builders<BsonDocument>.Update.Set("3EngineIsSelected", false);

                collectionEngine.UpdateOne(filterEngineSelct3, updateEngineSelected3);

                progressPower.Value = 50;
                onethree.Content = "used";

                if (engineIsBought1)
                {
                    var filterEngineSelect1 = Builders<BsonDocument>.Filter.Eq("1EngineIsSelected", true);
                    var updateEngineSelected1 = Builders<BsonDocument>.Update.Set("1EngineIsSelected", false);

                    collectionEngine.UpdateOne(filterEngineSelect1, updateEngineSelected1);

                    oneone.Content = "use";
                }
                else if (engineIsBought2)
                {
                    var filterEngineSelect2 = Builders<BsonDocument>.Filter.Eq("2EngineIsSelected", true);
                    var updateEngineSelected2 = Builders<BsonDocument>.Update.Set("2EngineIsSelected", false);
                    collectionEngine.UpdateOne(filterEngineSelect2, updateEngineSelected2);
                    onetwo.Content = "use";
                }
            }
        }




        //twos
        //not yet
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void usernameText_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
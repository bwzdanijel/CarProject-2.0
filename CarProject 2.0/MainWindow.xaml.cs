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

            DbAccess dbAccess = new DbAccess();
            UserModel userHandler = new UserModel(dbAccess);

            User user1 = new User("1", "user1", "password1");
            User user2 = new User("2", "user2", "password2");

            User[] usersToInsert = new User[] { user1, user2 };
            userHandler.InsertUsers(usersToInsert);


            MongoClient dbClient = new MongoClient("mongodb://localhost:27017");

            var database = dbClient.GetDatabase("TuningConfigurator");
            var collection = database.GetCollection<BsonDocument>("Properties");
            var document = collection.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            progressPower.Value = document.GetValue("Power").AsInt32;
            progressPerformance.Value = document.GetValue("Performance").AsInt32;
            progressAcceleration.Value = document.GetValue("Acceleration").AsInt32;
            progressGrip.Value = document.GetValue("Grip").AsInt32;
            progressSteering.Value = document.GetValue("Steering").AsInt32;
            progressNitrous.Value = document.GetValue("Nitrous").AsInt32;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            teststackPanel.Visibility = Visibility.Visible;
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
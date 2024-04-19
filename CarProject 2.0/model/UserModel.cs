using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class UserModel
    {
        private DbAccess dbAccess;
        private IMongoCollection<User> _userCollection;
        private string collectionUser = "User";
        private User currentUser;
        private List<User> users = new List<User>();


        public UserModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _userCollection = dbAccess.Database.GetCollection<User>(collectionUser);

        }


        public void AddUser(User user)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Name, user.Name);
            var existingUser = _userCollection.Find(filter).FirstOrDefault();

            if (existingUser == null)
            {
                _userCollection.InsertOne(user);
            }
            else
            {
                Console.WriteLine(".");
            }
        }

        public User GetUser()
        {
            return currentUser;
        }



        private string GetCurrentUsername()
        {
            return "player1";
        }

        public void UpdateUserBalance(int amount)
        {
            string username = GetCurrentUsername();
            var filter = Builders<User>.Filter.Eq(u => u.Name, username);
            var updateUserBalance = _userCollection.Find(filter).FirstOrDefault();

            if (updateUserBalance != null)
            {
                updateUserBalance.Balance += amount;
                var update = Builders<User>.Update.Set(u => u.Balance, updateUserBalance.Balance);
                _userCollection.UpdateOne(filter, update);
            }
            else
            {
                Console.WriteLine("user not found");
            }
        }

        public bool UserExistsInDatabase(string username)
        {
            MongoClient client = new MongoClient("mongodb://localhost:27017");
            IMongoDatabase database = client.GetDatabase("TuningConfigurator");
            IMongoCollection<BsonDocument> collection = database.GetCollection<BsonDocument>("User");

            var filter = Builders<BsonDocument>.Filter.Eq("Name", username);
            var userDocument = collection.Find(filter).FirstOrDefault();

            return userDocument != null; 
        }


        public void DeleteUser(string username)
        {
            var filter = Builders<User>.Filter.Eq(u => u.Name, username);
            _userCollection.DeleteOne(filter);
        }

    }
}
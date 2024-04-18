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


        public void UpdateUser(User user)
        {
            user = user;
        }


        private string GetCurrentUsername()
        {
            // Hier könntest du die Logik implementieren, um den Benutzernamen dynamisch zu erhalten,
            // zum Beispiel aus der aktuellen Benutzersitzung, aus dem Token, etc.
            // Rückgabe des Benutzernamens
            return "player1"; // Beispiel: Rückgabe des Benutzernamens "player1"
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
                Console.WriteLine("Benutzer nicht gefunden.");
            }
        }
    }
}
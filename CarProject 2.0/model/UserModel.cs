using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    class UserModel
    {
        private List<User> _users;
        private DbAccess dbAccess;
        private IMongoCollection<User> _userCollection;
        private string collectionUser = "User";

        public UserModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _userCollection = dbAccess.Database.GetCollection<User>(collectionUser);
        }


        public string GetHash(string input)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }

    
        public bool AuthenticateUser(string username, string password)
        {
            // Hash the password
            string hashedPassword = GetHash(password);

            var filter = Builders<User>.Filter.And(
                             Builders<User>.Filter.Eq(u => u.Name, username),
                             Builders<User>.Filter.Eq(u => u.Password, hashedPassword)
                         );



            var existingUser = _userCollection.Find(filter).FirstOrDefault();

            return existingUser != null;
        }



        public void AddUser(User[] users)
        {
            foreach (var user in users)
            {
                string hashedPassword = GetHash(user.Password);

                var filter = Builders<User>.Filter.Eq(u => u.Name, user.Name);
                var existingUser = _userCollection.Find(filter).FirstOrDefault();

                if (existingUser == null)
                {
                    user.Password = hashedPassword;
                    _userCollection.InsertOne(user);
                }
                else
                {
                    // Benutzer bereits vorhanden
                    Console.WriteLine($"User with username '{user.Name}' already exists.");
                }
            }
        }
    }
}

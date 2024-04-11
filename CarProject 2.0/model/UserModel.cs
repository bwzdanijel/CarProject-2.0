using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    class UserModel
    {
        private IMongoCollection<BsonDocument> _userCollection;
        private User user;

        public UserModel(DbAccess dbAccess)
        {
            dbAccess.DbConnection();
            dbAccess.CreateCollection("User");
            _userCollection = dbAccess.Database.GetCollection<BsonDocument>("User");
            Console.WriteLine("Collection TuningConfigurator selected successfully");
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

        public void InsertUsers(User[] users)
        {
            foreach (var user in users)
            {
                var hashedPassword = GetHash(user.Password);

                var filter = Builders<BsonDocument>.Filter.Eq("Username", user.Username) &
                             Builders<BsonDocument>.Filter.Eq("Password", hashedPassword);

                var existingUser = _userCollection.Find(filter).FirstOrDefault();

                if (existingUser == null)
                {
                    var document = new BsonDocument
            {
                { "Username", user.Username },
                { "Password", hashedPassword }
            };

                    _userCollection.InsertOne(document);
                }
                else
                {
                    Console.WriteLine($"");
                }
            }
        }


        public bool AuthenticateUser(string username, string password)
        {
            // Hash the password
            string hashedPassword = GetHash(password);

            // Check if the user exists in the database and the password matches
            var filter = Builders<BsonDocument>.Filter.Eq("Username", username) &
                         Builders<BsonDocument>.Filter.Eq("Password", hashedPassword);

            var existingUser = _userCollection.Find(filter).FirstOrDefault();

            return existingUser != null;
        }

    }
}

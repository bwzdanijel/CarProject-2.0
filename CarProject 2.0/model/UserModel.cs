using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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


        public void InsertUsers(User[] users)
        {
            foreach (var user in users)
            {

                var filter = Builders<BsonDocument>.Filter.Eq("Username", user.Username) &
                             Builders<BsonDocument>.Filter.Eq("Password", user.Password);

                var existingUser = _userCollection.Find(filter).FirstOrDefault();

                if (existingUser == null)
                {
                    var document = new BsonDocument
                {
                    { "Username", user.Username },
                    { "Password", user.Password }
                };

                    _userCollection.InsertOne(document);
                }
                else
                {
                    Console.WriteLine($"Benutzer mit Benutzername '{user.Username}' und Passwort '{user.Password}' bereits vorhanden.");
                }
            }
        }
    }

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


            public void InsertUsers(User[] users)
            {
                foreach (var user in users)
                {

                    var filter = Builders<BsonDocument>.Filter.Eq("Username", user.Username) &
                                 Builders<BsonDocument>.Filter.Eq("Password", user.Password);

                    var existingUser = _userCollection.Find(filter).FirstOrDefault();

                    if (existingUser == null)
                    {
                        var document = new BsonDocument
                {
                    { "Username", user.Username },
                    { "Password", user.Password }
                };

                        _userCollection.InsertOne(document);
                    }
                    else
                    {
                        Console.WriteLine($"Benutzer mit Benutzername '{user.Username}' und Passwort '{user.Password}' bereits vorhanden.");
                    }
                }
            }

        }
    } 
}

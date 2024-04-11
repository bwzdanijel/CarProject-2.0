using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0
{
    class DBconnection
    {
        public DBconnection()
        {

        }


        private BsonDocument documentEngine;
        private IMongoCollection<BsonDocument> collectionEngine;
        public BsonDocument EngineConnection()
        {
            MongoClient dbClientEngine = new MongoClient("mongodb://localhost:27017");

            var databaseEngine = dbClientEngine.GetDatabase("TuningConfigurator");

            collectionEngine = databaseEngine.GetCollection<BsonDocument>("Engine");

            documentEngine = collectionEngine.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            return documentEngine;
        }



        private BsonDocument documentUser;
        private IMongoCollection<BsonDocument> collectionUsers;
        public BsonDocument UserConnection()
        {
            MongoClient dbClientUser = new MongoClient("mongodb://localhost:27017");

            var databaseUser = dbClientUser.GetDatabase("TuningConfigurator");

            collectionUsers = databaseUser.GetCollection<BsonDocument>("User");

            documentUser = collectionUsers.Find(Builders<BsonDocument>.Filter.Empty).FirstOrDefault();

            return documentUser;
            

            
        }

        public IMongoCollection<BsonDocument> GetUserCollection()
        {
            return collectionUsers;
        }
    }
}

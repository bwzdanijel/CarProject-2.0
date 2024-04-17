using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class DbAccess
    {
        private MongoClient _mongoClient;
        private IMongoDatabase _database;


        public IMongoDatabase Database
        {
            get { return _database; }
        }

        public void DbConnection()
        {
            _mongoClient = new MongoClient("mongodb://localhost:27017");
            _database = _mongoClient.GetDatabase("TuningConfigurator");
        }
    }
}

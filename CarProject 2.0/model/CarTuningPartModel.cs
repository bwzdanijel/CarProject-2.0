using Amazon.Runtime.Internal;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    using MongoDB.Bson;
    using MongoDB.Driver;
    using System;

    public class CarTuningPartModel
    {
        private DbAccess dbAccess;
        private IMongoCollection<CarModel> _carModelCollection;
                private IMongoCollection<Car> _carCollection;


        private string collectionCarConfiguration = "CarConfiguration";

        public CarTuningPartModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _carModelCollection = dbAccess.Database.GetCollection<CarModel>(collectionCarConfiguration);
        }

    }

}


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
        private IMongoCollection<Car> _carCollection;
        private IMongoCollection<Car> _carConfigurationCollection;
        private string collectionCar = "Car";
        private string collectionCarConfiguration = "CarConfiguration";

        public CarTuningPartModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _carCollection = dbAccess.Database.GetCollection<Car>(collectionCar);
            _carConfigurationCollection = dbAccess.Database.GetCollection<Car>(collectionCarConfiguration); // Initialisiere die CarConfiguration-Collection
        }

        public void AddCars(Car[] cars)
        {
            foreach (Car car in cars)
            {
                _carCollection.InsertOne(car);

                var filter = Builders<Car>.Filter.Eq(u => u.Name, car.Name);
                var existingCar = _carCollection.Find(filter).FirstOrDefault();

                if (existingCar != null)
                {
                    Console.WriteLine($"Auto mit dem Namen '{car.Name}' bereits vorhanden.");
                }
            }
        }

        public List<Car> GetAllCars()
        {
            var result = _carCollection.Find(new BsonDocument()).ToList();
            return result;
        }

        public void CopyCarData(List<string> carNames, Guid userId)
        {
            foreach (var carName in carNames)
            {
                try
                {
                    var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                    var carToCopy = _carCollection.Find(filter).FirstOrDefault();

                    if (carToCopy != null)
                    {
                        carToCopy.Id = userId;

                        _carConfigurationCollection.InsertOne(carToCopy);
                        Console.WriteLine($"Das Auto mit dem Namen '{carName}' wurde erfolgreich in die CarConfiguration Collection kopiert.");
                    }
                    else
                    {
                        Console.WriteLine($"Das Auto mit dem Namen '{carName}' wurde nicht in der Car Collection gefunden.");
                    }
                }
                catch (MongoWriteException ex)
                {
                    Console.WriteLine($"Fehler beim Kopieren des Autos '{carName}': {ex.Message}");
                }
            }
        }

    }
}


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
        private IMongoCollection<User> _userCollection;
        private IMongoCollection<Car> _carCollection;
        private string collectionCar = "Car";

        public CarTuningPartModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _userCollection = dbAccess.Database.GetCollection<User>("User");
            _carCollection = dbAccess.Database.GetCollection<Car>(collectionCar);
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

        public void SelectCarsForUser(List<string> carNames, Guid userId)
        {
            var userFilter = Builders<User>.Filter.Eq(u => u.Id, userId);
            var userToUpdate = _userCollection.Find(userFilter).FirstOrDefault();

            if (userToUpdate == null)
            {
                Console.WriteLine($"Benutzer mit der ID '{userId}' wurde nicht gefunden.");
                return;
            }

            foreach (var carName in carNames)
            {
                var carFilter = Builders<Car>.Filter.Eq(c => c.Name, carName);
                var carToSelect = _carCollection.Find(carFilter).FirstOrDefault();

                if (carToSelect != null)
                {
                     userToUpdate.myCarCollectioList.Add(carToSelect);
                }
                else
                {
                    Console.WriteLine($"Das Auto mit dem Namen '{carName}' wurde nicht in der Car Collection gefunden.");
                }
            }

            var userUpdate = Builders<User>.Update.Set(u => u.myCarCollectioList, userToUpdate.myCarCollectioList);
            _userCollection.UpdateOne(userFilter, userUpdate);
        }
    }
}


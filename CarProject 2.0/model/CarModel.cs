using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.model
{
    public class CarModel
    {
        private List<Car> cars;
        private DbAccess dbAccess;
        private IMongoCollection<Car> _carCollection;
        private string collectionCar = "Car";

        public CarModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _carCollection = dbAccess.Database.GetCollection<Car>(collectionCar);
        }

        public void AddCars(Car[] cars)
        {
            foreach (Car car in cars)
            {
                _carCollection.InsertOne(car);

                var filter = Builders<Car>.Filter.Eq(u => u.Name, car.Name);
                var existingUser = _carCollection.Find(filter).FirstOrDefault();

                if (existingUser == null)
                {
                    _carCollection.InsertOne(car);
                }
                else
                {
                    // Benutzer bereits vorhanden
                    Console.WriteLine($"");
                }
            }
        }
    }
}

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
        private IMongoCollection<CarModel> _carModelCollection; // Hier sollte _carModelCollection sein, nicht _carCollection
        private IMongoCollection<Car> _carCollection;
        private string collectionCarConfiguration = "CarConfiguration";

        public CarTuningPartModel(DbAccess dbAccess)
        {
            this.dbAccess = dbAccess;
            dbAccess.DbConnection();
            _carModelCollection = dbAccess.Database.GetCollection<CarModel>(collectionCarConfiguration);
            _carCollection = dbAccess.Database.GetCollection<Car>("Car"); // Initialisierung der _carCollection
        }

        public void CopyCarToConfiguration(string carName)
        {
            var filter = Builders<Car>.Filter.Eq(c => c.Name, carName);
            var car = _carCollection.Find(filter).FirstOrDefault(); 

            if (car != null)
            {
                // Hier sollten Sie das Auto-Objekt in ein CarModel-Objekt umwandeln, bevor Sie es in die CarConfiguration-Collection einfügen
                var carModel = new CarModel(dbAccess); // Neue Instanz von CarModel
                carModel.AddCars(new Car[] { car }); // Fügen Sie das Auto der Car-Collection des CarModel-Objekts hinzu

                Console.WriteLine($"Auto '{carName}' wurde erfolgreich in die CarConfiguration kopiert.");
            }
            else
            {
                Console.WriteLine($"Auto '{carName}' wurde nicht gefunden.");
            }
        }
    }

}


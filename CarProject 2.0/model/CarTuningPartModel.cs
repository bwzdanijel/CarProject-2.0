﻿using Amazon.Runtime.Internal;
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
            _carConfigurationCollection = dbAccess.Database.GetCollection<Car>(collectionCarConfiguration);
        }

        public void AddCars(Car[] cars)
        {
            foreach (Car car in cars)
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, car.Name);
                var existingCar = _carCollection.Find(filter).FirstOrDefault();

                if (existingCar == null)
                {
                    _carCollection.InsertOne(car);
                }
                else
                {
                    Console.WriteLine();
                }
            }
        }


        public List<Car> GetAllCars()
        {
            var result = _carCollection.Find(new BsonDocument()).ToList();
            return result;
        }

        public void CopyCarData(List<string> carNames)
        {
            foreach (var carName in carNames)
            {
                try
                {
                    var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                    var carToCopy = _carCollection.Find(filter).FirstOrDefault();

                    if (carToCopy != null)
                    {
                        var existingCarConfig = _carConfigurationCollection.Find(filter).FirstOrDefault();

                        if (existingCarConfig == null)
                        {
                            _carConfigurationCollection.InsertOne(carToCopy);
                        }
                        else
                        {
                            Console.WriteLine($" '{carName}' already exitsts");
                        }
                    }
                    else
                    {
                        Console.WriteLine($" '{carName}' not found");
                    }
                }
                catch (MongoWriteException ex)
                {
                    Console.WriteLine($"Error '{carName}': {ex.Message}");
                }
            }
        }


        public bool UpdateCarEngine(string carName, string engine)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                var update = Builders<Car>.Update.Set(u => u.TuningPart.Engine, engine);

                var result = _carConfigurationCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updting car '{carName}': {ex.Message}");
                return false;
            }
        }



        public bool UpdateCarSpoiler(string carName, string spoiler)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                var update = Builders<Car>.Update.Set(u => u.TuningPart.Spoiler, spoiler);

                var result = _carConfigurationCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"'{carName}': {ex.Message}");
                return false;
            }
        }


        public bool UpdateCarBrake(string carName, string brake)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                var update = Builders<Car>.Update.Set(u => u.TuningPart.Brake, brake);

                var result = _carConfigurationCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"'{carName}': {ex.Message}");
                return false;
            }
        }

        public bool UpdateCarTire(string carName, string tire)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                var update = Builders<Car>.Update.Set(u => u.TuningPart.Tires, tire);

                var result = _carConfigurationCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public bool UpdateCarNitrous(string carName, string nitrous)
        {
            try
            {
                var filter = Builders<Car>.Filter.Eq(u => u.Name, carName);
                var update = Builders<Car>.Update.Set(u => u.TuningPart.Nitrous, nitrous);

                var result = _carConfigurationCollection.UpdateOne(filter, update);

                return result.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}


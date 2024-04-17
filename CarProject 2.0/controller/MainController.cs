using CarProject_2._0.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarProject_2._0.controller
{
    public class MainController
    {
        private CarTuningPartModel carTuningPartModel;
        private UserModel userModel;

        public MainController()
        {
            DbAccess dbAccess = new DbAccess();
            carTuningPartModel = new CarTuningPartModel(dbAccess);
            userModel = new UserModel(dbAccess);
        }
        public void InsertCars()
        {

            TuningPart tuningPart1 = new TuningPart("V8", "Sport", "Performance", "High-performance", "Yes", 1500.0);
            Car car1 = new Car("Red Monster", "Ferarri", "F8 Spider", tuningPart1);

            TuningPart tuningPar2 = new TuningPart("Flat-6", "Aerodynamic", "Performance", "Sport", "No", 1800.0);
            Car car2 = new Car("Silver Bullet", "Porsche", "911 Turbo S", tuningPar2);

            TuningPart tuningPar3 = new TuningPart("V12", "Carbon fiber", "High-performance", "Ultra-performance", "Yes", 2500.0);
            Car car3 = new Car("Black Panther", "Lamborghini", "Aventador SVJ",tuningPar3);


            Car[] CarsToInsert = new Car[] { car1, car2, car3 };
            carTuningPartModel.AddCars(CarsToInsert);
        }

        public void SelectCarsForUser(List<string> carNames, Guid userId)
        {
            carTuningPartModel.SelectCarsForUser(carNames, userId);
        }

    }
} 

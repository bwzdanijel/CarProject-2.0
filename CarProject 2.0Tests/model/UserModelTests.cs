using Microsoft.VisualStudio.TestTools.UnitTesting;
using CarProject_2._0.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarProject_2._0.controller;

namespace CarProject_2._0.model.Tests
{
    [TestClass()]
    public class UserModelTests
    {
        [TestMethod()]
        public void AddUserTest()
        {

            // Arrange
            DbAccess dbAccess = new DbAccess();
            UserModel userModel = new UserModel(dbAccess);
            User user = new User("Enes", 17);

            // Action
            userModel.AddUser(user);

            // Assert
            Assert.IsTrue(userModel.UserExistsInDatabase(user.Name));
            userModel.DeleteUser(user.Name);
        }

        [TestMethod()]
        public void AddCarTest()
        {
            DbAccess dbAccess = new DbAccess();
            CarTuningPartModel carTuningPartModel = new CarTuningPartModel(dbAccess);

            TuningPart tuningPart1 = new TuningPart("V8", "Sport", "Performance", "High-performance", "Yes", 1500.0);
            Car car1 = new Car("Red Monster", "Ferarri", "F8 Spider", tuningPart1);

            TuningPart tuningPar2 = new TuningPart("Flat-6", "Aerodynamic", "Performance", "Sport", "No", 1800.0);
            Car car2 = new Car("Silver Bullet", "Porsche", "911 Turbo S", tuningPar2);

            Car[] CarsToInsert = new Car[] { car1, car2 };

            carTuningPartModel.AddCars(CarsToInsert);

        }

        [TestMethod()]
        public void CanButtonCopyCarTest()
        {
            DbAccess dbAccess = new DbAccess();
            CarTuningPartModel carTuningPartModel = new CarTuningPartModel(dbAccess);


            MainController mainController = new MainController();
            string selectedCarName;
            selectedCarName = "Red Monster";
            mainController.CopyCarData(new List<string> { selectedCarName });

        }



        [TestMethod()]

        public void CanCarEngineUpdateTuninPartTest()
        {
            DbAccess dbAccess = new DbAccess();
            CarTuningPartModel carTuningPartModel = new CarTuningPartModel(dbAccess);

            MainController mainController = new MainController();
            string selectedCarName;
            selectedCarName = "Red Monster";
            mainController.UpdateCarEngine(selectedCarName ?? "DefaultCarName", "Enginus Maximus");
        }


        [TestMethod()]

        public void CanButtonUpdateUserBalanceTest ()
        {
            DbAccess dbAccess = new DbAccess();
            CarTuningPartModel carTuningPartModel = new CarTuningPartModel(dbAccess);

            MainController mainController = new MainController();
            mainController.UpdateUserBalance(-1500);

        }
    }
}
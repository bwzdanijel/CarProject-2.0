using CarProject_2._0.controller;

namespace CarProject2._0Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]

        public void TestMethod1()
        {

        }


        [TestMethod]
        public void TestInsertCars()
        {
            // Arrange
            DbAccess dbAccess = new DbAccess(); 
            var carTuningPartModel = new CarTuningPartModel(dbAccess); 
            var mainController = new MainController(carTuningPartModel); 

            // Act
            mainController.InsertCars();

            // Assert
            var allCars = carTuningPartModel.GetAllCars();
            Assert.AreEqual(3, allCars.Count);
            Assert.IsTrue(allCars.Any(car => car.Name == "Red Monster"));
        }


        [TestMethod]
        public void TestInsertUser()
        {
            // Arrange
            var mainController = new MainController();

            // Act
            mainController.InsertUser();

            // Assert
            // Hier könntest du Assertions hinzufügen, um sicherzustellen, dass der Benutzer erfolgreich hinzugefügt wurde.
        }
    }

    /*
    internal class MainController
    {
        public MainController()
        {
        }

         

        internal void InsertUser()
        {
            Console.WriteLine("Users werden eingefügt");
            throw new NotImplementedException();
        }
    }*/
}
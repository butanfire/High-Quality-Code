namespace AirConditionTets
{
    using System;
    using AirConditionerTestingSystem.Core;
    using AirConditionerTestingSystem.Core.IO;
    using AirConditionerTestingSystem.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RegisterStationaryTests
    {
        private Database data;
        private Controller controller;

        [TestInitialize]
        public void Init()
        {
            this.data = new Database();
            this.controller = new Controller(data, new ConsoleWriter());
        }

        [TestMethod]
        public void RegisterStationary_ValidData_ShouldCorrectlyReturn()
        {
            controller.RegisterStationaryAirConditioner("Test123", "Test123", "A", 200);
            var element = data.GetAirConditioner("Test123", "Test123");
            Assert.AreEqual(element.Model, "Test123");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationary_InValidModel_ShouldThrow()
        {
            controller.RegisterStationaryAirConditioner("Test123", "T", "A", 200);

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationary_InValidManufacturer_ShouldThrow()
        {
            controller.RegisterStationaryAirConditioner("Tes", "Test1234", "A", 200);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RegisterStationary_InValidEnergy_ShouldThrow()
        {
            controller.RegisterStationaryAirConditioner("Tet1234s", "Test1234", "S", 200);
        }
    }
}

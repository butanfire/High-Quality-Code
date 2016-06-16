using AirConditionerTestingSystem.Core;
using AirConditionerTestingSystem.Core.IO;
using AirConditionerTestingSystem.Data;
using AirConditionerTestingSystem.Exceptions;
using AirConditionerTestingSystem.Models;
using AirConditionerTestingSystem.Utilities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AirConditionTets
{
    [TestClass]
    public class MockTestAirConditioner
    {
        private Database data;
        private Controller controller;
        private Mock<Database> moqData;

        [TestInitialize]
        public void Init()
        {
            this.data = new Database();
            this.controller = new Controller(data, new ConsoleWriter());
            this.moqData = new Mock<Database>();
        }

        [TestMethod]
        [ExpectedException(typeof(NonExistantEntryException))]
        public void TestAirConditioner_NoData_ShouldThrow()
        {
            controller.TestAirConditioner("no matter", "no matter");
        }

        [TestMethod]
        [ExpectedException(typeof(DuplicateEntryException))]
        public void TestAirCOnditioner_DuplicateReport_ShouldThrow()
        {
            AirConditioner airConditioner = new CarAirConditioner("Manufacturer", "SomeModel", 500);
            moqData.Setup(s => s.GetAirConditioner(It.IsAny<string>(), It.IsAny<string>())).Returns(airConditioner);

            this.controller.TestAirConditioner("Manufacturer", "SomeModel");
        }

        [TestMethod]
        public void TestAirCOnditioner_ValidData_ShouldReturnOutput()
        {
            AirConditioner airConditioner = new CarAirConditioner("Manufacturer", "SomeModel", 500);
            moqData.Setup(s => s.GetAirConditioner(It.IsAny<string>(), It.IsAny<string>())).Returns(airConditioner);
            var expectedMEssage = string.Format(Constants.TEST, airConditioner.Model, airConditioner.Manufacturer);
            var actual = this.controller.TestAirConditioner(airConditioner.Manufacturer, airConditioner.Model);

            Assert.AreEqual(expectedMEssage, actual);
        }
    }
}

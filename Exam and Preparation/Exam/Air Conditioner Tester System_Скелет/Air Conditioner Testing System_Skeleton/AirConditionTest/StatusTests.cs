using AirConditionerTestingSystem.Core;
using AirConditionerTestingSystem.Core.IO;
using AirConditionerTestingSystem.Data;

namespace AirConditionTets
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
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
        public void Status_NoData_ShouldReturn0()
        {
            var message = this.controller.Status();
            var expectedMessage = "Jobs complete: 0.00%";
            Assert.AreEqual(expectedMessage, message);
        }
        [TestMethod]
        public void Status_ValidData_ShouldReturnCorrectResult()
        {
            controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            controller.TestAirConditioner("Toshiba", "EX1000");
            var message = this.controller.Status();
            var expectedMessage = "Jobs complete: 100.00%";
            Assert.AreEqual(expectedMessage, message);
        }
    }
}

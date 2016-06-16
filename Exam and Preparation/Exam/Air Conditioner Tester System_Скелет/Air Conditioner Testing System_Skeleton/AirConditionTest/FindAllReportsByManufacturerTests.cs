namespace AirConditionTets
{
    using AirConditionerTestingSystem.Core;
    using AirConditionerTestingSystem.Core.IO;
    using AirConditionerTestingSystem.Data;
    using AirConditionerTestingSystem.Utilities;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FindAllReportsByManufacturerTests
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
        public void FindAllReportsByManufacturer_NoReports_ShouldReturnNoReport()
        {
            var message = this.controller.FindAllReportsByManufacturer("SomeManufcaturer");
            Assert.AreEqual(Constants.NOREPORTS, message);
        }

        [TestMethod]
        public void FindAllReportsByManufacturer_ValidReports_ShouldReturnReport()
        {
            controller.RegisterStationaryAirConditioner("Toshiba", "EX1000", "B", 1000);
            controller.TestAirConditioner("Toshiba", "EX1000");
            var message = controller.FindAllReportsByManufacturer("Toshiba");
            var expectedMessage = "Reports from Toshiba:\r\nReport\r\n====================\r\nManufacturer: Toshiba\r\nModel: EX1000\r\nMark: Passed\r\n==================== ";
            Assert.AreEqual(expectedMessage.Trim(), message.Trim());
        }
    }
}

using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheatreApp;
using TheatreApp.Exceptions;

namespace ThreatreTest
{
    [TestClass]
    public class ThreatreTest
    {
        private CommandManager theatreCommander;

        [TestInitialize]
        public void Initializer()
        {
            theatreCommander = new CommandManager();
        }

        [TestMethod]
        public void ListTheatres_EmptyList()
        {
            var number = theatreCommander.GetDB.ListTheatres().Count();
            Assert.AreEqual(0, number);
        }

        [TestMethod]
        public void ListTheatres_NonEmptyList_ShouldReturnOneTheatre()
        {
            theatreCommander.GetDB.AddTheatre("SomeTheatre");

            var number = theatreCommander.GetDB.ListTheatres().Count();
            Assert.AreEqual(1, number);
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void AddPerformance_InvalidTheatre_ShouldReturnException()
        {
            theatreCommander.GetDB.AddPerformance("SomeTheatre", "SomePerformance", DateTime.Now, TimeSpan.MinValue, 12);
        }

        [TestMethod]
        [ExpectedException(typeof(TimeDurationOverlapException))]
        public void AddPerformance_InvalidTime_ShouldReturnException()
        {
            theatreCommander.GetDB.AddTheatre("Theatre");

            theatreCommander.GetDB.AddPerformance("SomePerformance", "Theatre", DateTime.Now, TimeSpan.Parse("01:00"), 12);
            theatreCommander.GetDB.AddPerformance("SomePerformance", "Theatre", DateTime.Now, TimeSpan.Parse("01:00"), 12);
        }

        [TestMethod]
        public void AddPerformance_ValidData_ShouldIncrementList()
        {
            theatreCommander.GetDB.AddTheatre("Test");
            theatreCommander.GetDB.AddPerformance("SomePerformance", "Test", DateTime.Now, TimeSpan.Zero, 115);
            Assert.AreEqual(1, theatreCommander.GetDB.ListPerformances("Test").Count());
        }

        [TestMethod]
        [ExpectedException(typeof(TheatreNotFoundException))]
        public void ListPerformances_NoTheatre_ShouldThrow()
        {
            theatreCommander.GetDB.ListPerformances("SomeTheatre");
        }

        [TestMethod]
        public void ListPerformances_NoTheatre_ShouldReturn0()
        {
            theatreCommander.GetDB.AddTheatre("SomeTheatre");
            Assert.AreEqual(0, theatreCommander.GetDB.ListPerformances("SomeTheatre").Count());
        }

        [TestMethod]
        public void ListPerformances_NoTheatre_ShouldIncrement()
        {
            theatreCommander.GetDB.AddTheatre("SomeTheatre");
            theatreCommander.GetDB.AddPerformance("SomePerform", "SomeTheatre", DateTime.Now, TimeSpan.Zero, 10);
            Assert.AreEqual(1, theatreCommander.GetDB.ListPerformances("SomeTheatre").Count());
        }



    }
}

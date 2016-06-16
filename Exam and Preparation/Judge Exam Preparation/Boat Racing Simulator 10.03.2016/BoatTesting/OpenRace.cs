using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoatRacingSimulator.Exceptions;
using BoatRacingSimulator.Controllers;

namespace BoatTesting
{
    [TestClass]
    public class OpenRace
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void OpenRace_Race_NegativeValueDistanceThrow()
        {
            BoatSimulatorController controller = new BoatSimulatorController();
            controller.OpenRace(-10, 1, 1, false);
        }

        [TestMethod]
        public void OpenRace__Race_NegativeValueWindSpeedNoThrow()
        {
            BoatSimulatorController controller = new BoatSimulatorController();
            var output = controller.OpenRace(1, -10, 1, false);
            Assert.AreEqual("A new race with distance 1 meters, wind speed -10 m/s and ocean current speed 1 m/s has been set.", output);
        }

        [TestMethod]
        public void OpenRace__Race_NegativeValueOceanSpeedNoThrow()
        {
            BoatSimulatorController test = new BoatSimulatorController();
            var output = test.OpenRace(1, 1, -10, false);
            Assert.AreEqual("A new race with distance 1 meters, wind speed 1 m/s and ocean current speed -10 m/s has been set.", output);
        }

        [TestMethod]
        public void OpenRace__Race_CheckRace()
        {
            BoatSimulatorController test = new BoatSimulatorController();
            var race = test.CurrentRace;
            Assert.AreEqual(race, null);
        }

        [TestMethod]
        [ExpectedException(typeof(RaceAlreadyExistsException))]
        public void OpenRace__DuplicateRace_ShouldThrow()
        {
            BoatSimulatorController controller = new BoatSimulatorController();
            controller.OpenRace(1, 1, 1, true);
            controller.OpenRace(1, 1, 1, true);
        }
    }
}

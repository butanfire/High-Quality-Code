using System;
using Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BoatRacingSimulator.Controllers;
using BoatRacingSimulator.Models;
using BoatRacingSimulator.Database;
using BoatRacingSimulator.Models.Boats;
using BoatRacingSimulator.Exceptions;

namespace BoatTesting
{
    [TestClass]
    public class SignUpBoatMoq
    {
        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void SignupBoat_ValidBoat_NoRace()
        {
            BoatSimulatorDatabase data = new BoatSimulatorDatabase();
            Mock<Repository<MotorBoat>> mock = new Mock<Repository<MotorBoat>>();
            mock.Setup(s=>s.GetItem(It.IsAny<string>())).Returns(new Yacht("Luxury", 100));

            BoatSimulatorController controller = new BoatSimulatorController(data, null);
            data.Boats = mock.Object;
            var actual = controller.SignUpBoat("Luxury");            
        }

        [TestMethod]
        public void SignupBoat_ValidBoat_CorrectResult()
        {
            BoatSimulatorDatabase data = new BoatSimulatorDatabase();
            Mock<Repository<MotorBoat>> mock = new Mock<Repository<MotorBoat>>();
            mock.Setup(s => s.GetItem(It.IsAny<string>())).Returns(new Yacht("Luxury", 100));

            BoatSimulatorController controller = new BoatSimulatorController(data, new Race(1,1,1,true));
            data.Boats = mock.Object;
            var actual = controller.SignUpBoat("Luxury");

            var expected = "Boat with model Luxury has signed up for the current Race.";
            Assert.AreEqual(expected, actual);
        } 

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SignupBoat_InValidBoatForRace_ShouldThrow()
        {
            BoatSimulatorDatabase data = new BoatSimulatorDatabase();
            Mock<Repository<MotorBoat>> mock = new Mock<Repository<MotorBoat>>();
            mock.Setup(s => s.GetItem(It.IsAny<string>())).Returns(new Yacht("Luxury", 100));

            BoatSimulatorController controller = new BoatSimulatorController(data, new Race(1, 1, 1, false));
            data.Boats = mock.Object;
            var actual = controller.SignUpBoat("Luxury");
        }

        [TestMethod]
        public void SignupBoat_ValidBoat_ReturnedCorrectly()
        {
            BoatSimulatorDatabase data = new BoatSimulatorDatabase();
            Mock<Repository<MotorBoat>> mock = new Mock<Repository<MotorBoat>>();
            Yacht tester = new Yacht("Luxury", 100);
            mock.Setup(s => s.GetItem(It.IsAny<string>())).Returns(tester);

            BoatSimulatorController controller = new BoatSimulatorController(data, new Race(1, 1, 1, true));
            data.Boats = mock.Object;
            var actual = controller.SignUpBoat("Luxury");

            var yacht = controller.Database.Boats.GetItem("Luxury");
            Assert.AreEqual(tester, yacht);
        }

        [TestMethod]
        public void SignupBoat_ValidBoat_AddedInParticipants()
        {
            BoatSimulatorDatabase data = new BoatSimulatorDatabase();
            Mock<Repository<MotorBoat>> mock = new Mock<Repository<MotorBoat>>();
            Yacht tester = new Yacht("Luxury", 100);
            mock.Setup(s => s.GetItem(It.IsAny<string>())).Returns(tester);

            BoatSimulatorController controller = new BoatSimulatorController(data, new Race(1, 1, 1, true));
            data.Boats = mock.Object;
            var actual = controller.SignUpBoat("Luxury");

            var participants = controller.CurrentRace.GetParticipants();
            Assert.AreEqual(1, participants.Count);
        }
    }
}

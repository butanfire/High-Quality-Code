using BoatRacingSimulator.Controllers;
using BoatRacingSimulator.Exceptions;
using BoatRacingSimulator.Models.Boats;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace BoatTesting
{
    [TestClass]
    public class StartRace
    {
        [TestMethod]
        [ExpectedException(typeof(NoSetRaceException))]
        public void StartRarce_NoRace_ShouldThrow()
        {
            BoatSimulatorController boatSimulatorController = new BoatSimulatorController();
            boatSimulatorController.StartRace();
        }

        [TestMethod]
        [ExpectedException(typeof(InsufficientContestantsException))]
        public void StartRarce_Race_NoParticipantsShouldThrow()
        {
            BoatSimulatorController controller = new BoatSimulatorController();
            controller.OpenRace(1, 1, 1, true);
            controller.StartRace();
        }

        [TestMethod]        
        public void StartRarce_Race_Participants()
        {
            BoatSimulatorController controller = new BoatSimulatorController();
            controller.OpenRace(1, 1, 1, true);            
            controller.Database.Boats.Add(new RowBoat("Boat1", 1));
            controller.Database.Boats.Add(new RowBoat("Boat2", 20));
            controller.Database.Boats.Add(new RowBoat("Boat3", 30));
            controller.SignUpBoat("Boat1");
            controller.SignUpBoat("Boat2");
            controller.SignUpBoat("Boat3");
            var output = controller.StartRace();

            StringBuilder expected = new StringBuilder();
            expected.AppendLine("First place: RowBoat Model: Boat1 Time: Did not finish!");
            expected.AppendLine("Second place: RowBoat Model: Boat2 Time: Did not finish!");
            expected.AppendLine("Third place: RowBoat Model: Boat3 Time: Did not finish!");

            Assert.AreEqual(expected.ToString(),output);
        }


    }
}

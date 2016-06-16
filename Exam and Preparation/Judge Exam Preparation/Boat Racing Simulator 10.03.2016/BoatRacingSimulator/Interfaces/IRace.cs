namespace BoatRacingSimulator.Interfaces
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Interface for the Race parameters
    /// </summary>
    public interface IRace
    {
        /// <summary>
        /// The distance covered by the race
        /// </summary>
        int Distance { get; }

        /// <summary>
        /// The speed of the wind for the race.
        /// </summary>
        int WindSpeed { get; }

        /// <summary>
        /// The speed of the ocean for the race.
        /// </summary>
        int OceanCurrentSpeed { get; }

        /// <summary>
        /// Boolean variable used for setting restrictions for Boats - whether to use Engines or not
        /// </summary>
        bool AllowsMotorboats { get; }

        /// <summary>
        /// Function for adding participants in the race
        /// </summary>
        /// <param name="boat"></param>
        void AddParticipant(MotorBoat boat);

        /// <summary>
        /// List that holds the participants for the race
        /// </summary>
        /// <returns>Returns a list of the participants signed for that race.</returns>
        IList<MotorBoat> GetParticipants();
    }
}

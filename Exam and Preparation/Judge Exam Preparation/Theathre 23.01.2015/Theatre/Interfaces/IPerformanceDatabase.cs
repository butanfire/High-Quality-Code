using System;
using System.Collections.Generic;
using TheatreApp.ProgramObjects;

namespace TheatreApp.Interfaces
{
    public interface IPerformanceDatabase
    {        
        /// <summary>
        /// Function for adding a theatre in the DB.
        /// </summary>
        /// <param name="theatreName">Theatre name</param>
        void AddTheatre(string theatreName);
                
        /// <summary>
        /// Function for listing all theatres from the DB.
        /// </summary>
        /// <returns>All available theatres.</returns>
        IEnumerable<string> ListTheatres();
                
        /// <summary>
        /// Function for adding a performance in a theatre.
        /// </summary>
        /// <param name="theatreName">Theatre name.</param>
        /// <param name="performanceTitle">Name of the performance.</param>
        /// <param name="startDateTime">Start time of the performance.</param>
        /// <param name="duration">Duration of the performance.</param>
        /// <param name="price">Price for the performance.</param>
        void AddPerformance(string performanceTitle, string threatre, DateTime startDateTime, TimeSpan duration, decimal price);

             /// <summary>
        /// Function for listing all performances in all theatres.
        /// </summary>
        /// <returns>All performances in all theatres.</returns>
        IEnumerable<Performance> ListAllPerformances();

        /// <summary>
        /// Function for listing all performances in a specific theatre.
        /// </summary>
        /// <param name="theatreName">Theatre name.</param>
        /// <returns>All performances for the theatre provided.</returns>
        IEnumerable<Performance> ListPerformances(string theatreName);
    }
}

using System;
using System.Collections.Generic;
using TheatreApp.Exceptions;
using TheatreApp.Interfaces;
using TheatreApp.ProgramObjects;

namespace TheatreApp.Data
{
    public class PerformanceDB : IPerformanceDatabase
    {
        private readonly SortedDictionary<string, SortedSet<Performance>> theathrePerformances = new SortedDictionary<string, SortedSet<Performance>>();

        public void AddTheatre(string theatre)
        {
            if (this.theathrePerformances.ContainsKey(theatre))
            {
                throw new DuplicateTheatreException("Duplicate theatre");
            }

            this.theathrePerformances[theatre] = new SortedSet<Performance>();
        }

        public void AddPerformance(string performanceName, string theatre, DateTime startTime, TimeSpan duration, decimal price)
        {
            if (!this.theathrePerformances.ContainsKey(theatre))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            if (this.theathrePerformances[theatre] != null)
            {
                var totalTime = startTime.Add(duration);
                if (PerformanceTimeValidator(this.theathrePerformances[theatre], startTime, totalTime))
                {
                    throw new TimeDurationOverlapException("Time/duration overlap");
                }
            }

            this.theathrePerformances[theatre].Add(new Performance(performanceName, theatre, startTime, duration, price));
        }

        public IEnumerable<string> ListTheatres()
        {
            return this.theathrePerformances.Keys;
        }

        public IEnumerable<Performance> ListAllPerformances()
        {
            var result2 = new List<Performance>();

            foreach (var theatre in this.theathrePerformances.Keys)
            {
                var performances = this.theathrePerformances[theatre];
                result2.AddRange(performances);
            }

            return result2;
        }

        public IEnumerable<Performance> ListPerformances(string theatreName)
        {
            if (!this.theathrePerformances.ContainsKey(theatreName))
            {
                throw new TheatreNotFoundException("Theatre does not exist");
            }

            return this.theathrePerformances[theatreName];
        }

        protected static bool PerformanceTimeValidator(IEnumerable<Performance> performances, DateTime nextStartTime, DateTime nextTotalDuration)
        {
            foreach (var performance in performances)
            {
                var startTime = performance.StartTime;
                var totalTime = performance.StartTime.Add(performance.Duration);

                var conditionA = nextStartTime <= totalTime && (totalTime <= nextTotalDuration || startTime <= nextStartTime);
                var conditionB = startTime <= nextTotalDuration && (nextStartTime <= startTime || nextTotalDuration <= totalTime);

                if (conditionA || conditionB)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

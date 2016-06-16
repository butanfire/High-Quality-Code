namespace HotelBookingSystem.Models
{
    using System;

    public class AvailableDate
    {
        public AvailableDate(DateTime startDate, DateTime endDate)
        {
            this.StartDate = startDate;
            this.EndDate = endDate;
        }

        public DateTime StartDate { get; protected set; }

        public DateTime EndDate { get; protected set; }
    }
}
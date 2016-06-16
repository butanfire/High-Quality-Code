namespace HotelBookingSystem.Models
{
    using System.Collections.Generic;
    using Interfaces;

    public class Room : IDbEntity
    {
        public Room(int places, decimal pricePerDay)
        {
            this.Places = places;
            this.PricePerDay = pricePerDay;
            this.Bookings = new List<Booking>();
            this.AvailableDates = new List<AvailableDate>();
        }

        public int ID { get; set; }

        public int Places { get; private set; }

        public decimal PricePerDay { get; protected set; }

        public ICollection<AvailableDate> AvailableDates { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}
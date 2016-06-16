namespace HotelBookingSystem.Models
{
    using System;
    using Interfaces;

    public class Booking : IDbEntity
    {
        public Booking(User client, DateTime startBookDate, DateTime endBookDate, decimal totalPrice, string comments)
        {
            this.StartBookDate = startBookDate;
            this.EndBookDate = endBookDate;
            this.TotalPrice = totalPrice;
            this.Comments = comments;
            this.Client = client;
        }

        public int ID { get; set; }

        public User Client { get; protected set; }

        public string Comments { get; protected set; }

        public DateTime StartBookDate { get; protected set; }

        public DateTime EndBookDate { get; protected set; }

        public decimal TotalPrice { get; private set; }
    }
}
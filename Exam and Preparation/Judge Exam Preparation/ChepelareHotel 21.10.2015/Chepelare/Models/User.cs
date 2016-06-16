namespace HotelBookingSystem.Models
{
    using System.Collections.Generic;
    using Interfaces;
    using Utilities;

    public class User : IDbEntity
    {
        private string passwordHash;

        public User(string username, string password, Roles role)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.Role = role;
            this.Bookings = new List<Booking>();
        }

        public int ID { get; set; }

        public string Username { get; protected set; }

        public string PasswordHash
        {
            get
            {
                return this.passwordHash;
            }

            protected set
            {
                this.passwordHash = HashUtilities.GetSha256Hash(value);
            }
        }

        public Roles Role { get; protected set; }

        public ICollection<Booking> Bookings { get; set; }
    }
}


namespace HotelBookingSystem.Models
{
    using System;
    using System.Collections.Generic;
    using Interfaces;

    public class Venue : IDbEntity
    {
        private string name;
        private string address;

        public Venue(string name, string address, string description, User owner)
        {
            this.Name = name;
            this.Address = address;
            this.Description = description;
            this.Owner = owner;
            this.Rooms = new List<Room>();
        }

        public int ID
        {
            get;
            set;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            protected set
            {
                this.name = value;
            }
        }

        public string Address
        {
            get
            {
                return this.address;
            }

            protected set
            {
                this.address = value;
            }
        }

        public string Description
        {
            get;

            set;
        }

        public User Owner
        {
            get;

            set;
        }

        public ICollection<Room> Rooms
        {
            get;

            set;
        }
    }
}

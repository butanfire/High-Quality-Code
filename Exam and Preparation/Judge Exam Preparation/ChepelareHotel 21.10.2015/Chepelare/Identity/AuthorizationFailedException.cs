namespace HotelBookingSystem.Identity
{
    using Models;
    using System;

    [Serializable]public class AuthorizationFailedException : ArgumentException
    {
        public AuthorizationFailedException(string message, User user) : base(message)
        {
            this.User = user;
        }

        public User User { get; set; }
    }
}

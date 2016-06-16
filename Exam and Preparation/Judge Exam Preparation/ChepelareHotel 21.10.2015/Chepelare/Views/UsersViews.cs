﻿namespace HotelBookingSystem.Views.Users
{
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;

    public class Register : View
    {
        public Register(User user) : base(user)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            if (Model != null)
            {
                viewResult.AppendFormat("The user {0} has been registered and may login.", user.Username).AppendLine();
            }

            return viewResult.ToString();
        }
    }

    public class Login : View
    {
        public Login(User user)
            : base(user)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            if (Model != null)
            {
                viewResult.AppendFormat("The user {0} has logged in.", user.Username).AppendLine();
            }

            return viewResult.ToString();
        }
    }

    public class MyProfile : View
    {
        public MyProfile(User user)
            : base(user)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            if (this.Model != null)
            {
                var user = this.Model as User;
                viewResult.AppendLine(user.Username);
                if (!user.Bookings.Any())
                {
                    viewResult.AppendLine("You have not made any bookings yet.");
                }
                else
                {
                    viewResult.AppendLine("Your bookings:");
                    foreach (var booking in user.Bookings)
                    {
                        viewResult.AppendFormat("* {0:dd.MM.yyyy} - {1:dd.MM.yyyy} (${2:F2})", 
                            booking.StartBookDate, booking.EndBookDate, booking.TotalPrice).AppendLine();
                    }
                }
            }

            return viewResult.ToString();
        }
    }

    public class Logout : View
    {
        public Logout(User user)
            : base(user)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            if (this.Model != null)
            {
                var user = this.Model as User;
                viewResult.AppendFormat("The user {0} has logged out.", user.Username).AppendLine();
                return viewResult.ToString();
            }

            return viewResult.ToString();
        }
    }
}

namespace HotelBookingSystem.Controllers
{
    using System;
    using System.Linq;
    using Infrastructure;
    using Interfaces;
    using Models;
    using Identity;

    public class RoomsController : Controller
    {
        public RoomsController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Add(int venueId, int places, string pricePerDay)
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }
            else
            {
                try
                {
                    this.Authorize(Roles.VenueAdmin);
                    var venue = Data.RepositoryWithVenues.Get(venueId);
                    if (venue == null)
                    {
                        return this.NotFound(string.Format("The venue with ID {0} does not exist.", venueId));
                    }

                    if (places < 0)
                    {
                        return this.NotFound("The places must not be less than 0.");
                    }

                    if (Convert.ToDecimal(pricePerDay) < 0)
                    {
                        return this.NotFound("The price per day must not be less than 0.");
                    }

                    var newRoom = new Room(places, Convert.ToDecimal(pricePerDay));
                    venue.Rooms.Add(newRoom);
                    Data.RepositoryWithRooms.Add(newRoom);
                    return this.View(newRoom);
                }

                catch (AuthorizationFailedException)
                {
                    return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
                }
            }

        }

        public IView AddPeriod(int roomId, DateTime startDate, DateTime endDate)
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }
            else
            {
                try
                {
                    this.Authorize(Roles.VenueAdmin);
                }
                catch (AuthorizationFailedException)
                {
                    return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
                }
                var room = Data.RepositoryWithRooms.Get(roomId);
                if (room == null)
                {
                    return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
                }
                if (startDate > endDate)
                {
                    return this.NotFound("The date range is invalid.");
                }

                var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);

                room.AvailableDates.Add(new AvailableDate(startDate, endDate));

                return this.View(room);
            }

        }


        public IView ViewBookings(int id)
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }
            else
            {
                try
                {
                    this.Authorize(Roles.VenueAdmin);
                }

                catch (AuthorizationFailedException)
                {
                    return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
                }

                var room = Data.RepositoryWithRooms.Get(id);
                if (room == null)
                {
                    return this.NotFound(string.Format("The room with ID {0} does not exist.", id));
                }
                else
                {
                    return this.View(room.Bookings);
                }
            }
        }

        public IView Book(int roomId, DateTime startDate, DateTime endDate, string comments)
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }
            else
            {
                try
                {
                    if (this.CurrentUser.Role == Roles.User)
                    {
                        this.Authorize(Roles.User);
                    }
                    else
                    {
                        this.Authorize(Roles.VenueAdmin);
                    }
                }
                catch (AuthorizationFailedException)
                {
                    return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
                }
                var room = Data.RepositoryWithRooms.Get(roomId);
                if (room == null)
                {
                    return this.NotFound(string.Format("The room with ID {0} does not exist.", roomId));
                }

                if (startDate > endDate)
                {
                    return this.NotFound("The date range is invalid.");
                }

                var availablePeriod = room.AvailableDates.FirstOrDefault(d => d.StartDate <= startDate || d.EndDate >= endDate);
                if (availablePeriod == null)
                {
                    return this.NotFound(string.Format("The room is not available to book in the period {0:dd.MM.yyyy} - {1:dd.MM.yyyy}.", startDate, endDate));
                }

                decimal totalPrice = (endDate - startDate).Days * room.PricePerDay;
                if (totalPrice < 0)
                {
                    return this.NotFound("The total price must not be less than 0.");
                }

                var booking = new Booking(CurrentUser, startDate, endDate, totalPrice, comments);
                room.Bookings.Add(booking);
                CurrentUser.Bookings.Add(booking);
                this.UpdateRoomAvailability(startDate, endDate, room, availablePeriod);
                return this.View(booking);
            }
        }

        protected void UpdateRoomAvailability(DateTime startDate, DateTime endDate, Room room, AvailableDate availablePeriod)
        {
            room.AvailableDates.Remove(availablePeriod);
            var periodBeforeBooking = startDate - availablePeriod.StartDate;
            if (periodBeforeBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.StartDate, availablePeriod.StartDate.Add(periodBeforeBooking)));
            }

            var periodAfterBooking = availablePeriod.EndDate - endDate;
            if (periodAfterBooking > TimeSpan.Zero)
            {
                room.AvailableDates.Add(new AvailableDate(availablePeriod.EndDate.Subtract(periodAfterBooking), availablePeriod.EndDate));
            }
        }
    }
}

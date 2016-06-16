namespace HotelBookingSystem.Controllers
{
    using Identity;
    using Infrastructure;
    using Interfaces;
    using Models;
    using System;

    public class VenuesController : Controller
    {
        public VenuesController(IHotelBookingSystemData data, User user) : base(data, user)
        {
        }

        public IView All()
        {
            var venues = this.Data.RepositoryWithVenues.GetAll();
            return this.View(venues);
        }

        public IView Details(int id)
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }
            try
            {
                this.Authorize(Roles.VenueAdmin, Roles.User);
                var venue = this.Data.RepositoryWithVenues.Get(id);
                if (venue == null)
                {
                    return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
                }

                return this.View(venue);
            }

            catch (AuthorizationFailedException)
            {
                return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
            }
        }

        public IView Rooms(int id)
        {
            try
            {
                this.Authorize(Roles.User, Roles.VenueAdmin);
                var venue = this.Data.RepositoryWithVenues.Get(id);
                if (venue == null)
                {
                    return this.NotFound(string.Format("The venue with ID {0} does not exist.", id));
                }

                return this.View(venue);
            }

            catch (AuthorizationFailedException)
            {
                return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
            }
        }


        public IView Add(string name, string address, string description)
        {
            try
            {
                this.Authorize(Roles.User, Roles.VenueAdmin);
                if (address.Length < 3)
                {
                    return this.NotFound("The venue address must be at least 3 symbols long.");
                }

                if (name.Length < 3)
                {
                    return this.NotFound("The venue name must be at least 3 symbols long.");
                }

                var newVenue = new Venue(name, address, description, CurrentUser);
                this.Data.RepositoryWithVenues.Add(newVenue);
                return this.View(newVenue);
            }

            catch (AuthorizationFailedException)
            {
                return this.NotFound("The currently logged in user doesn't have sufficient rights to perform this operation.");
            }
        }
    }
}
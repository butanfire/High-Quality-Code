namespace HotelBookingSystem.Views.Venues
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Infrastructure;
    using Models;

    public class All : View
    {
        public All(IEnumerable<Venue> venues) : base(venues)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var venues = this.Model as IEnumerable<Venue>;
            if (!venues.Any())
            {
                viewResult.AppendLine("There are currently no venues to show.");
            }
            else
            {
                var listVenues = venues.ToList();
                foreach (var venue in listVenues)
                {
                    viewResult.AppendFormat("*[{0}] {1}, located at {2}", venue.ID, venue.Name, venue.Address).AppendLine();
                    if (venue.Rooms != null)
                    {
                        viewResult.AppendFormat("Free rooms: {0}", venue.Rooms.Count).AppendLine();
                    }
                    else
                    {
                        viewResult.AppendFormat("Free rooms: 0").AppendLine();
                    }
                }
            }

            return viewResult.ToString();
        }
    }

    public class Details : View
    {
        public Details(Venue venue) : base(venue)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendLine(venue.Name)
                .AppendFormat("Located at {0}", venue.Address).AppendLine()
                .AppendFormat("Description: {0}", venue.Description).AppendLine();

            if (venue.Rooms == null)
            {
                viewResult.AppendFormat("No rooms are currently available.").AppendLine();
            }
            else
            {
                if (venue.Rooms.Count != 0)
                {
                    viewResult.AppendLine("Available rooms:");
                    foreach (var room in venue.Rooms)
                    {
                        viewResult.AppendFormat(" * {0} places (${1:F2} per day)", room.Places, room.PricePerDay).AppendLine();
                    }
                }
                else
                {
                    viewResult.AppendFormat("No rooms are currently available.").AppendLine();
                }
            }

            return viewResult.ToString();
        }
    }

    public class Rooms : View
    {
        public Rooms(Venue venue) : base(venue)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            if (venue != null)
            {
                viewResult.AppendFormat("Available rooms for venue {0}:", venue.Name).AppendLine();
                if (!venue.Rooms.Any())
                {
                    viewResult.AppendFormat("No rooms are currently available.");
                }
                else
                {
                    foreach (var room in venue.Rooms)
                    {
                        viewResult.AppendFormat(" *[{0}] {1} places, ${2:F2} per day", room.ID, room.Places, room.PricePerDay).AppendLine();
                        if (!room.AvailableDates.Any())
                        {
                            viewResult.AppendLine("This room is not currently available.");
                        }
                        else
                        {
                            viewResult.AppendLine("Available dates:");
                            foreach (var datePair in room.AvailableDates.OrderBy(datePair => datePair.EndDate))
                            {
                                viewResult.AppendFormat(" - {0:dd.MM.yyyy} - {1:dd.MM.yyyy}", datePair.StartDate, datePair.EndDate).AppendLine();
                            }
                        }
                    }
                }
            }

            return viewResult.ToString();
        }
    }

    public class Add : View
    {
        public Add(Venue venue)
            : base(venue)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var venue = this.Model as Venue;
            viewResult.AppendFormat("The venue {0} with ID {1} has been created successfully.", venue.Name, venue.ID).AppendLine();
            return viewResult.ToString();
        }
    }
}
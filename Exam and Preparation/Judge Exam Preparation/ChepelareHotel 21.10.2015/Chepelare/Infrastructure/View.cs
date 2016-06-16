namespace HotelBookingSystem.Infrastructure
{
    using System.Text;
    using Interfaces;

    public abstract class View : IView
    {
        public View(object model)
        {
            this.Model = model;
        }

        public object Model { get; protected set; }

        public string Display()
        {
            var viewResult = new StringBuilder();
            string output = this.BuildViewResult(viewResult);
            return output.Trim();
        }

        protected abstract string BuildViewResult(StringBuilder viewResult);
    }
}

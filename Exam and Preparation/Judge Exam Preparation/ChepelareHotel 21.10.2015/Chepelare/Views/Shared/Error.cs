namespace HotelBookingSystem.Views.Shared
{
    using System.Text;
    using Infrastructure;    

    public class Error : View
    {
        public Error(object model) : base(model)
        {
        }

        protected override string BuildViewResult(StringBuilder viewResult)
        {
            var message = this.Model as string;
            viewResult.AppendLine("Something happened!!1").AppendLine(message);
            return viewResult.ToString();
        }
    }
}

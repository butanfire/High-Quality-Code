namespace BangaloreUniversityLearningSystem.Core
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
            this.BuildViewResult(viewResult);
            return viewResult.ToString().Trim();
        }

        internal virtual void BuildViewResult(StringBuilder viewResult)
        {
        }
    }
}

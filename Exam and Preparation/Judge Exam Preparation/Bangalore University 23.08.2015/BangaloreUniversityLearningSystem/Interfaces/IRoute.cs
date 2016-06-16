namespace BangaloreUniversityLearningSystem.Interfaces
{
    public interface IRoute
    {
        string ControllerName { get; }

        string ActionName { get; }
    }
}

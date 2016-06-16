namespace BangaloreUniversityLearningSystem.Views.Users
{
    using Core;
    using Models;
    using System.Text;

    public class Login : View
    {
        public Login(User user) : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} logged in successfully.", user.Username).AppendLine();
        }
    }
}

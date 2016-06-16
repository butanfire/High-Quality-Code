﻿namespace BangaloreUniversityLearningSystem.Views.Users
{
    using Core;
    using Models;
    using System.Text;

    public class Logout : View
    {
        public Logout(User user) : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;

            viewResult.AppendFormat("User {0} logged out successfully.",user.Username).AppendLine();
        }
    }
}

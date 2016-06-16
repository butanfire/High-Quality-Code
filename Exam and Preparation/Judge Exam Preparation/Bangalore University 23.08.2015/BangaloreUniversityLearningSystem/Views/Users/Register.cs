﻿namespace BangaloreUniversityLearningSystem.Views.Users
{
    using Core;
    using Models;
    using System.Text;

    public class Register : View
    {
        public Register(User user) : base(user)
        {
        }

        internal override void BuildViewResult(StringBuilder viewResult)
        {
            var user = this.Model as User;
            viewResult.AppendFormat("User {0} registered successfully.", user.Username).AppendLine();
        }
    }
}

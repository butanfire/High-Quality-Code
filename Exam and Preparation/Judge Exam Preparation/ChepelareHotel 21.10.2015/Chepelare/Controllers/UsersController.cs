namespace HotelBookingSystem.Controllers
{
    using System;
    using Infrastructure;
    using Interfaces;
    using Identity;
    using Models;
    using Utilities;

    public class UsersController : Controller
    {
        public UsersController(IHotelBookingSystemData data, User user)
            : base(data, user)
        {
        }

        public IView Register(string username, string password, string confirmPassword, string role)
        {
            if (password != confirmPassword)
            {
                return this.NotFound("The provided passwords do not match.");
            }

            if (this.EnsureNoLoggedInUser())
            {
                var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
                if (existingUser != null)
                {
                    return this.NotFound("A user with username " + existingUser.Username + " already exists.");
                }

                if(password.Length < 6)
                {
                    return this.NotFound("The password must be at least 6 symbols long.");
                }

                if (username.Length < 5)
                {
                    return this.NotFound("The username must be at least 5 symbols long.");
                }

                Roles userRole = (Roles)Enum.Parse(typeof(Roles), role, true);
                var user = new User(username, password, userRole);
                this.Data.RepositoryWithUsers.Add(user);
                return this.View(user);
            }
            return this.NotFound("There is already a logged in user.");
        }

        public IView Login(string username, string password)
        {
            if (this.EnsureNoLoggedInUser())
            {
                var existingUser = this.Data.RepositoryWithUsers.GetByUsername(username);
                if (existingUser == null)
                {
                    return this.NotFound(string.Format("A user with username {0} does not exist.", username));
                }

                if (existingUser.PasswordHash != HashUtilities.GetSha256Hash(password))
                {
                    return this.NotFound("The provided password is wrong.");
                }

                this.CurrentUser = existingUser;
                return this.View(existingUser);
            }

            return this.NotFound("There is already a logged in user.");
        }

        public IView MyProfile()
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }

            return this.View(this.CurrentUser);
        }

        public IView Logout()
        {
            if (this.CurrentUser == null)
            {
                return NotFound(string.Format("There is no currently logged in user."));
            }

            var user = this.CurrentUser;
            this.CurrentUser = null;
            return this.View(user);

        }

        private bool EnsureNoLoggedInUser()
        {
            foreach (var user in this.Data.RepositoryWithUsers.GetAll())
            {
                if (user != null)
                {
                    if (string.IsNullOrEmpty(user.Username) || (this.CurrentUser != null && this.CurrentUser.Username == user.Username))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}

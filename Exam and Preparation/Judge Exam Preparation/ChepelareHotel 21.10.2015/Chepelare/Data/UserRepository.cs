namespace HotelBookingSystem.Data
{
    using System.Collections.Generic;
    using Interfaces;
    using Models;

    public class UserRepository : Repository<User>, IUserRepository
    {
        private Dictionary<string, User> usersByUsername;

        public UserRepository()
        {
            this.usersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            if (!this.usersByUsername.ContainsKey(username))
            {
                return null;
            }

            return this.usersByUsername[username];
        }

        public override void Add(User user)
        {
            this.usersByUsername.Add(user.Username, user);
            base.Add(user);
        }

        public override bool Delete(int id)
        {
            var user = this.Get(id);
            this.usersByUsername.Remove(user.Username);
            return base.Delete(id);
        }
    }
}

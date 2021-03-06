﻿namespace BangaloreUniversityLearningSystem.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    public class UsersRepository : Repository<User>
    {
        private Dictionary<string, User> UsersByUsername;

        public UsersRepository()
        {
            this.UsersByUsername = new Dictionary<string, User>();
        }

        public User GetByUsername(string username)
        {
            return this.items.FirstOrDefault(u => u.Username == username);            
        }
    }
}

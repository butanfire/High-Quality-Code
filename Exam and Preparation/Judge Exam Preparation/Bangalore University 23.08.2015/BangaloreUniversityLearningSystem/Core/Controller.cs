namespace BangaloreUniversityLearningSystem.Core
{
    using System.Linq;
    using System;
    using System.Diagnostics;
    using Interfaces;
    using System.Reflection;
    using Utilities;
    using Models;
    using Exceptions;

    public abstract class Controller
    {
        private User user;
        private IBangaloreUniversityData data;

        public Controller(User user, IBangaloreUniversityData data)
        {
            this.User = user;
            this.Data = data;
        }

        public User User
        {
            get
            {
                return this.user;
            }

            set
            {
                this.user = value;
            }
        }

        public IBangaloreUniversityData Data
        {
            get
            {
                return this.data;
            }
            set
            {
                this.data = value;
            }
        }

        protected IView View(object model)
        {
            string fullNamespace = this.GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(".");
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = this.GetType().Name.Replace("Controller", string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = baseNamespace + ".Views." + controllerName + "." + actionName;
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);

            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected void EnsureAuthorization(params Role[] roles)
        {
            if (!this.HasCurrentUser)
            {
                throw new ArgumentException(ExceptionMessages.NoLoggedUser);
            }

            bool UserHasRole = roles.Any(role => this.User.IsInRole(role));

            if (!UserHasRole)
            {
                throw new AuthorizationFailedException(ExceptionMessages.AuthorizationFailed);
            }
        }

        public bool HasCurrentUser
        {
            get
            {
                return this.User != null;
            }
        }
    }
}

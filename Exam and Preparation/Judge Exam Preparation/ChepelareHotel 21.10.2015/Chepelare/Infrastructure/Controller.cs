namespace HotelBookingSystem.Infrastructure
{
    using System;
    using System.Diagnostics;
    using System.Linq;
    using System.Reflection;
    using Interfaces;
    using Identity;
    using Models;
    using Utilities;
    using Views.Shared;

    public class Controller
    {
        public Controller(IHotelBookingSystemData data, User user)
        {
            this.Data = data;
            this.CurrentUser = user;
        }

        public User CurrentUser
        {
            get;

            set;
        }

        public IHotelBookingSystemData Data
        {
            get;

            protected set;
        }

        protected IView View(object model)
        {
            string fullNamespace = GetType().Namespace;
            int firstSeparatorIndex = fullNamespace.IndexOf(Constants.NamespaceSeparator);
            string baseNamespace = fullNamespace.Substring(0, firstSeparatorIndex);
            string controllerName = GetType().Name.Replace(Constants.ControllerSuffix, string.Empty);
            string actionName = new StackTrace().GetFrame(1).GetMethod().Name;
            string fullPath = string.Join(
                Constants.NamespaceSeparator,
                new[] { baseNamespace, Constants.ViewsFolder, controllerName, actionName });
            var viewType = Assembly
                .GetExecutingAssembly()
                .GetType(fullPath);
            return Activator.CreateInstance(viewType, model) as IView;
        }

        protected IView NotFound(string message)
        {
            return new Error(message);
        }

        protected void Authorize(params Roles[] roles)
        {
            if (this.CurrentUser == null)
            {
                this.NotFound(string.Format("There is no currently logged in user."));
            }
            else
            {
                if (!roles.Any(role => Authorization.IsInRole(this.CurrentUser, role)))
                {
                    throw new AuthorizationFailedException("The currently logged in user doesn't have sufficient rights to perform this operation.", this.CurrentUser);
                }
            }
        }

    }

}


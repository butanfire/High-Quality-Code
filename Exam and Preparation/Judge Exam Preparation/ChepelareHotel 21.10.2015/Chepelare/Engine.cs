namespace HotelBookingSystem.Core
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Identity;
    using Interfaces;
    using Infrastructure;
    using Models;
    using Utilities;


    public class Engine : IEngine
    {
        public void StartOperation()
        {
            var database = new HotelBookingSystemData();
            User currentUser = null;

            while (true)
            {
                string url = Console.ReadLine();
                if (url == null)
                {
                    break;
                }

                var executionEndpoint = new Endpoint(url);

                var controllerType = Assembly
                    .GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == executionEndpoint.ControllerName);
                var controller = Activator.CreateInstance(controllerType, database, currentUser) as Controller;
                var action = controllerType.GetMethod(executionEndpoint.ActionName);
                object[] parameters = MapParameters(executionEndpoint, action);
                string viewResult = string.Empty;

                var view = action.Invoke(controller, parameters) as IView;
                viewResult = view.Display();

                if (executionEndpoint.ActionName == "Logout")
                {
                    currentUser = null;
                }
                else
                {
                    currentUser = controller.CurrentUser;
                }


                Console.WriteLine(viewResult);
            }
        }




        private static object[] MapParameters(IEndpoint executionEndpoint, MethodInfo action)
        {
            var parameters = action
            .GetParameters()
            .Select<ParameterInfo, object>(p =>
            {
                if (p.ParameterType == typeof(int))
                {
                    return int.Parse(executionEndpoint.Parameters[p.Name]);
                }
                else if (p.ParameterType == typeof(DateTime))
                {
                    return DateTime.ParseExact(executionEndpoint.Parameters[p.Name], Constants.DateFormat, CultureInfo.InvariantCulture);
                }
                else
                {
                    return executionEndpoint.Parameters[p.Name];
                }
            })
           .ToArray();
            return parameters;
        }
    }
}

namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Data;
    using Interfaces;
    using Models;

    public class Engine : IEngine
    {
        public void Run()
        {
            var db = new BangaloreUniversityData();
            User user = null;
            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    break;
                }

                var route = new Route(input);
                var controllerType = Assembly.GetExecutingAssembly().GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);
                var controller = Activator.CreateInstance(controllerType, user, db) as Controller;
                var execute = controllerType.GetMethod(route.ActionName);
                object[] parameters = MapParameters(route, execute);
                try
                {
                    var view = execute.Invoke(controller, parameters) as IView;
                    Console.WriteLine(view.Display());
                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            return action.GetParameters().Select<ParameterInfo, object>(
                p =>
                {
                    if (p.ParameterType == typeof(int))
                    {
                        return int.Parse(route.arguments[p.Name]);
                    }
                    else
                    {
                        return route.arguments[p.Name];
                    }
                }
                ).ToArray();
        }
    }
}
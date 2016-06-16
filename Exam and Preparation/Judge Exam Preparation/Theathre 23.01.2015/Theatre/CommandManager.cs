/*//////////////////////////////////////
///                                  ///
///   Author: Huy Phuong Nguyen,     ///
///   Qui Nhơn, Bình Định, Vietnam   ///
///   Email: huy_p_n@yahoo.vn        ///
///                                  ///
//////////////////////////////////////*/

using System;
using System.Globalization;
using System.Linq;
using System.Threading;
using TheatreApp.Data;
using TheatreApp.Interfaces;

namespace TheatreApp
{
    public class CommandManager : IGetDB
    {
        private TheatherCommandManager theatreCommander;
        private PerformanceCommandManager performanceManager;

        public CommandManager()
        {
            this.GetDB = new PerformanceDB();
            this.theatreCommander = new TheatherCommandManager(this.GetDB);
            this.performanceManager = new PerformanceCommandManager(this.GetDB);
        }

        public IPerformanceDatabase GetDB
        {
            get; set;
        }

        public static void Main()
        {
            CommandManager commander = new CommandManager();

            Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                string input = Console.ReadLine();
                if (input == null)
                {
                    return;
                }

                if (input != string.Empty)
                {
                    string[] inputLines = input.Split('(');
                    string command = inputLines[0];
                    string commandResult;
                    string[] commandParameters = input.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).Skip(1).Select(p => p.Trim()).ToArray();

                    try
                    {
                        switch (command)
                        {
                            case "AddTheatre":
                                commandResult = commander.theatreCommander.ExecuteAddTheatreCommand(commandParameters);
                                break;

                            case "PrintAllTheatres":
                                commandResult = commander.theatreCommander.ExecutePrintAllTheatresCommand();
                                break;

                            case "AddPerformance":
                                commander.GetDB.AddPerformance(
                                commandParameters[1],
                                    commandParameters[0],
                                    DateTime.ParseExact(commandParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture),
                                    TimeSpan.Parse(commandParameters[3]),
                                    decimal.Parse(commandParameters[4]));
                                commandResult = "Performance added";
                                break;

                            case "PrintAllPerformances":
                                commandResult = commander.performanceManager.ExecutePrintAllPerformancesCommand();
                                break;

                            case "PrintPerformances":
                                string theatre = commandParameters[0];
                                var performances = commander.GetDB.ListPerformances(theatre)
                                    .Select(p =>
                                    {
                                        return string.Format("({0}, {1})", p.Name, p.StartTime.ToString("dd.MM.yyyy HH:mm"));
                                    }).ToList();

                                if (performances.Any())
                                {
                                    commandResult = string.Join(", ", performances);
                                }
                                else
                                {
                                    commandResult = "No performances";
                                }

                                break;
                            default:
                                commandResult = "Invalid command!";
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        commandResult = "Error: " + ex.Message;
                    }

                    Console.WriteLine(commandResult);
                }
            }
        }
    }
}

using SimpleLogger.ConsoleApp.Core.Interfaces;
using SimpleLogger.ConsoleApp.Factories;
using SimpleLogger.ConsoleApp.Factories.Interfaces;
using SimpleLogger.Core.Appenders;
using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.Enums;
using SimpleLogger.Core.IO;
using SimpleLogger.Core.Layouts.Interfaces;
using SimpleLogger.Core.Loggers;
using SimpleLogger.Core.Loggers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.ConsoleApp.Core
{
    public class Engine : IEngine
    {
        private IAppenderFactory appenderFactory;
        private ILayoutFactory layoutFactory;

        private ILogger logger; 
        private readonly ICollection<IAppender> appenders;

        public Engine()
        {
          appenderFactory = new AppenderFactory();
          layoutFactory = new LayoutFactory();
          appenders = new HashSet<IAppender>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                try
                {
                    CreateAppender();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }

            logger = new Logger(appenders.ToArray());
            LogMessages();
            Console.WriteLine("Logger info");
            Console.WriteLine(string.Join(Environment.NewLine, appenders));

        }
        private void CreateAppender()
        {
            string[] input= Console.ReadLine().Split();
            string type = input[0];
            ILayout layout = layoutFactory.Create(input[1]);
            ReportLevel reportLevel = ReportLevel.Info;
            IAppender appender;

            if (input.Length == 3)
            {
                bool isReportLevelValid = Enum.TryParse<ReportLevel>(input[2], true, out reportLevel);
                if (!isReportLevelValid)
                {
                    throw new InvalidOperationException("Report level is not valid!");
                }
            }

            if (type == "FileAppender")
            {
                ILogFile logFile = new LogFile();

                appender = appenderFactory.Create(type, layout, reportLevel, logFile);
            }
            else
            {
                appender = appenderFactory.Create(type, layout, reportLevel);
            }

            appenders.Add(appender);
            
        }

        private void LogMessages()
        {
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);
                string reportLevelStr = tokens[0];
                string dateTime = tokens[1];
                string message = tokens[2];

                try
                {
                    switch (reportLevelStr)
                    {
                        case "INFO":
                            logger.Info(dateTime, message);
                            break;
                        case "WARNING":
                            logger.Warning(dateTime, message);
                            break;
                        case "ERROR":
                            logger.Error(dateTime, message);
                            break;
                        case "CRITICAL":
                            logger.Critical(dateTime, message);
                            break;
                        case "FATAL":
                            logger.Fatal(dateTime, message);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}

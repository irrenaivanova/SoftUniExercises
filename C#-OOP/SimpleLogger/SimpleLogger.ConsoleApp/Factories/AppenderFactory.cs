using SimpleLogger.ConsoleApp.Factories.Interfaces;
using SimpleLogger.Core.Appenders;
using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.Enums;
using SimpleLogger.Core.IO;
using SimpleLogger.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.ConsoleApp.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
           
            public IAppender Create(string name, ILayout layout, ReportLevel reportlevel=0, ILogFile logFile = null)
        {
            switch (name)
            {
                case "ConsoleAppender":return new ConsoleAppender(layout, reportlevel);
                case "FileAppender":return new FileAppender(layout, logFile, reportlevel);
                default: throw new ArgumentException("Invalid input for appender");
            }
        }
    }
}

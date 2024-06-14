using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.Enums;
using SimpleLogger.Core.IO;
using SimpleLogger.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.ConsoleApp.Factories.Interfaces
{
    public interface IAppenderFactory
    {
        IAppender Create(string name, ILayout layout, ReportLevel reportlevel, ILogFile logFile = null);
    }
}

using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.Enums;
using SimpleLogger.Core.Layouts.Interfaces;
using SimpleLogger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Appenders
{
    public class ConsoleAppender : Appender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info) 
            : base(layout, reportLevel)
        {
        }

        public override void Append(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format,message.DateTime, message.Reportlevel, message.MessageText));
            MessageAppends++;
        }
    }
}

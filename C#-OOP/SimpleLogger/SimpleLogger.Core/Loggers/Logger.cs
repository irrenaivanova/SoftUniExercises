using SimpleLogger.Core.Appenders;
using SimpleLogger.Core.Appenders.Interfaces;
using SimpleLogger.Core.Enums;
using SimpleLogger.Core.Loggers.Interfaces;
using SimpleLogger.Core.Models;

namespace SimpleLogger.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;
     
        public Logger(params IAppender[] appenders)
        {
            this.appenders = appenders;
        }

        public void Critical(string dateTime, string message) 
            => AppendALL(dateTime,message, ReportLevel.Critical);

        public void Error(string dateTime, string message)
             => AppendALL(dateTime, message, ReportLevel.Error);

        public void Fatal(string dateTime, string message)
            => AppendALL(dateTime, message, ReportLevel.Fatal);

        public void Info(string dateTime, string message)
            => AppendALL(dateTime, message, ReportLevel.Info);
        public void Warning(string dateTime, string message)
            => AppendALL(dateTime, message, ReportLevel.Warning);

        private void AppendALL(string dateTime, string messagetext, ReportLevel reportlevel)
        {
            Message message = new Message(dateTime, messagetext, reportlevel);

            foreach (var appender in appenders)
            {
                if (appender.ReportLevel<=message.Reportlevel)
                {
                    appender.Append(message);
                
                }
            }
        }
    }
}
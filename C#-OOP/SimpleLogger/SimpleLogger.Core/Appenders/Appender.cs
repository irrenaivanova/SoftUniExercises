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
    public abstract class Appender : IAppender
    {
        private const ReportLevel defaultReportLevel = ReportLevel.Info;
        protected Appender(ILayout layout, ReportLevel reportLevel=defaultReportLevel)
        {
            Layout = layout;
            ReportLevel = reportLevel;
        }

        public ILayout Layout { get; private set; }

        public ReportLevel ReportLevel { get;  set; }

        public int MessageAppends { get; set; }

        public abstract void Append(Message message);
        public override string ToString()
            => $"Appender type: {GetType().Name}, Layout type: {Layout.GetType().Name},  " +
            $"Report level: {ReportLevel.GetType().Name.ToUpper()}, Messags appended: {MessageAppends}";
}
}

using SimpleLogger.Core.Enums;
using SimpleLogger.Core.Layouts.Interfaces;
using SimpleLogger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Appenders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        void Append(Message message);
        int MessageAppends { get;}
    }
}

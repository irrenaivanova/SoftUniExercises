using SimpleLogger.Core.Enums;
using SimpleLogger.Core.IO;
using SimpleLogger.Core.Layouts.Interfaces;
using SimpleLogger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.Appenders
{
    public class FileAppender : Appender
    {
       
        public FileAppender(ILayout layout,ILogFile file, ReportLevel reportLevel = ReportLevel.Info) 
            : base(layout, reportLevel)
        {
            File = file;
        }
        public ILogFile File { get; private set; }

        public override void Append(Message message)
        {
            System.IO.File.AppendAllText(File.FullPath,
                string.Format(Layout.Format,message.DateTime,message.Reportlevel,message.MessageText) + Environment.NewLine);
            MessageAppends++;
        }

        public override string ToString()
            => $"{base.ToString()}, File size: {File.Length}";
    }
}

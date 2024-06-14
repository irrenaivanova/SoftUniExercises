using SimpleLogger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.IO
{
    public interface ILogFile
    {
        string Name { get; }
        string FullPath { get; }
        int Length { get; }
 
    }
}

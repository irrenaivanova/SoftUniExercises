using SimpleLogger.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.Core.IO
{
    public class LogFile : ILogFile
    {

        private static readonly string defaultName = $"Log_{DateTime.Now:yyyy-MM-dd-HH-mm-ss}";
        private static readonly string defaultPath = $@"C:\Users\schhh\Desktop\SoftUni\SoftUniExercises\C#-OOP\SimpleLogger\{defaultName}.txt";

        public LogFile()
        {
            Name = defaultName;
            FullPath = defaultPath;
        }

        public LogFile(string name, string fullPath)
        {
            Name = name;
            FullPath = fullPath;
        }

        public string Name { get; private set; }

        public string FullPath { get; private set; }

        public int Length => System.IO.File.ReadAllText(FullPath).Length;   

    }
}

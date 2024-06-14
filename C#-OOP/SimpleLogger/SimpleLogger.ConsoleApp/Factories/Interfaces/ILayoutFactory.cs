using SimpleLogger.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.ConsoleApp.Factories.Interfaces
{
    public interface ILayoutFactory
    {
        ILayout Create(string name);
    }
}

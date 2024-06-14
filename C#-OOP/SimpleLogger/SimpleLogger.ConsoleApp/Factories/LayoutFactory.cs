using SimpleLogger.ConsoleApp.Factories.Interfaces;
using SimpleLogger.Core.Layouts;
using SimpleLogger.Core.Layouts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLogger.ConsoleApp.Factories
{
    public class LayoutFactory : ILayoutFactory
    {
        public ILayout Create(string name)
        {
            switch(name)
            {
                case "SimpleLayout": return new SimpleLayout();
                case "XmlLayout":return new SimpleLayout();  
                default: throw new ArgumentException("Invalid Layout");
            }
        }
    }
}

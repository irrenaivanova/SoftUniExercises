using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class Engine : IEngine
    {
        private ICommandInterpreter interpeter;

        public Engine(ICommandInterpreter interpeter)
        {
            this.interpeter = interpeter;
        }

        public void Run()
        {
            
            while (true)
            {
                string args = Console.ReadLine();
                try
                {
                    Console.WriteLine(interpeter.Read(args));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
              
            }
        }
    }
}

namespace SimpleSnake
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Utilities;

    public partial class StartUp
    {
        public static void Main()
        {
            //ConsoleWindow.CustomizeConsole();
            var types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine(type.Name);
            }
            var methods = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name == nameof(SYmbol)).GetMethods((BindingFlags)(60));
          

            foreach (var method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }

  
    }
}

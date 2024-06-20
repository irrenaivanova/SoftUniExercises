using CommandPattern.Core.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] input = args.Split();
            string command = input[0];
            string[] argsCommand = input.Skip(1).ToArray();
            Assembly assembly = Assembly.GetEntryAssembly();
            Type[] types = assembly.GetTypes();
            List<Type> commandsType = types.Where(t => typeof(ICommand).IsAssignableFrom(t)).ToList();
            Type therightCommand = commandsType.Where(t=>t.Name.Contains(command)).First();
            ICommand instance = (ICommand)Activator.CreateInstance(therightCommand);
            return instance.Execute(argsCommand); 
        }
    }
}

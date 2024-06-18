using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _02.CreateAttribute
{
    public class Tracker
    {
        public string PrintMethodsByAuthor()
        {
            StringBuilder sb = new StringBuilder();
            Assembly assembly= Assembly.GetExecutingAssembly();
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (!type.IsClass && type.GetCustomAttributes().Any(x => x.GetType() == typeof(AuthorAttribute)))
                {
                    continue;
                }

                var attributes = type.GetCustomAttributes().Where(x => x.GetType() == typeof(AuthorAttribute));
                foreach (var attribute in attributes)
                {
                    sb.AppendLine($"{type.Name} class is made of {((AuthorAttribute)attribute).Name}");
                }
                sb.Append(type.Name);
                MethodInfo[] methods = type.GetMethods((BindingFlags)(60));

                foreach (var method in methods)
                {
                    if (method.GetCustomAttributes().Any(x => x.GetType() == typeof(AuthorAttribute)))
                    {
                        var attributes2 = method.GetCustomAttributes().Where(x => x.GetType() == typeof(AuthorAttribute));
                        foreach (var attribute in attributes2)
                        {
                            sb.AppendLine($"{method.Name} is written by {((AuthorAttribute)attribute).Name}");
                        }
                    }
                }

            }

            return sb.ToString();
        }
    }
}

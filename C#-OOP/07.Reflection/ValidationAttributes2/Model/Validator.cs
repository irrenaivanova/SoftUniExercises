using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ValidationAttributes2.Attributes;

namespace ValidationAttributes2.Model
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            //var assembly = Assembly.GetEntryAssembly();
            //Type classPerson = assembly.GetTypes().Where(t => t.IsClass && t.Name=="Person").First();
            
           
            var properties = obj.GetType().GetProperties();
            foreach (var property in properties)
            {
                var attributes = property.GetCustomAttributes();
                var realatt = attributes.Where(a => a.GetType().IsAssignableTo(typeof(MyValidationAttribute)));
                if (!attributes.Any())
                {
                    continue;
                }

                foreach (MyValidationAttribute attribute in realatt)
                {
                    if (!attribute.IsValid(property.GetValue(obj)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}

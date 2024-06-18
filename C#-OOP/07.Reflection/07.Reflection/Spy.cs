using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace Stealer;

public class Spy
{
    public string StealFieldInfo (string name, params string[] fields)
    {
        Type classType = Type.GetType(name);
        var instance=Activator.CreateInstance(classType, new object[] { });
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Class under investigation: {classType.FullName}");
        foreach ( var field in fields ) 
        {
            FieldInfo fieldinfo = classType.GetField(field, (BindingFlags)(60));
            sb.AppendLine($"{fieldinfo.Name} = {fieldinfo.GetValue(instance)}");
        }

        return sb.ToString();
    }

    public string AnalyzeAccessModifiers(string className)
    {
        Type classType = Type.GetType(className);
        StringBuilder sb = new StringBuilder();
        FieldInfo[] fields = classType.GetFields((BindingFlags)(60));
        foreach ( FieldInfo field in fields ) 
        {
            if (field.IsPublic)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }
        }

        PropertyInfo[] properties = classType.GetProperties((BindingFlags)(60));
        foreach (PropertyInfo property in properties)
        {
            if(property.GetMethod.IsPrivate)
            {
                sb.AppendLine($"{property.GetMethod.Name} have to be public!");
            }
            if (property.SetMethod.IsPublic)
            {
                sb.AppendLine($"{property.SetMethod.Name} have to be public!");
            }
        }

        return sb.ToString();
    }


    public string RevealPrivateMethods(string className) 
    {
        Type type = Type.GetType(className);
        StringBuilder sb = new();
        MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
        sb.AppendLine($"All Private Methods of Class:{type.FullName}");
        sb.AppendLine($"Base Class: {type.BaseType}");
        foreach (var method in methods)
        {
            sb.AppendLine(method.Name);
        }
        return sb.ToString();
    }

    public string CollectGetterAndSetters(string classname)
    {
        Type type = Type.GetType(classname);
        StringBuilder sb = new();
        MethodInfo[] methods = type.GetMethods((BindingFlags)(60));
        
        foreach (var method in methods.Where(x=>x.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} will return {method.ReturnType.FullName}");
        }
        foreach (var method in methods.Where(x => x.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} will set field {method.GetParameters().First().ParameterType}");
            sb.AppendLine($"{method.Name} will set field {method.GetParameters().Last().ParameterType}");
            sb.AppendLine($"{method.Name} will set field {method.GetParameters().Count()}");
        }

        return sb.ToString();
    }

}

using System;
using System.Globalization;

namespace Stealer;

public class StartUp
{
    public static void Main(string[] args)
    {
        Spy spy = new Spy();
        string result  = spy.StealFieldInfo(typeof(Hacker).FullName, "username", "password");
        string result2 = spy.AnalyzeAccessModifiers(typeof(Hacker).FullName);
        string result3 = spy.RevealPrivateMethods(typeof(Hacker).FullName);
        string result4 = spy.CollectGetterAndSetters(typeof(Hacker).FullName);

        Console.WriteLine(result);
        Console.WriteLine(result2);
        Console.WriteLine(result3);
        Console.WriteLine(result4);


    }
}
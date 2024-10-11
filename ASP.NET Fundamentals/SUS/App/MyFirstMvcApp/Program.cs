
using Microsoft.Win32;
using MyFirstMvcApp;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;
using System.Text;

public class Program
{
    static async Task Main(string[] args)
    {
        await WebHost.RunAsync(new StartUp(),80);
    }
}

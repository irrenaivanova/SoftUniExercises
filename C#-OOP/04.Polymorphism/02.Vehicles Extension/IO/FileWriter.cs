using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _04.VehicleExtension.IO.Interfaces;

namespace _04.VehicleExtension.IO
{
    public class FileWriter : IWriter
    {
        string path = @"C:\Users\schhh\Desktop\SoftUni\C#-OOP\vehicle.txt";
        public void WriteLine(string str) => File.WriteAllText(path, str);

    }
}

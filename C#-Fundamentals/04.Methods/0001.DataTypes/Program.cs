using System;

namespace _09.GreaterThan2Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            string type = Console.ReadLine();

            if (type == "int")
            {
                int input = int.Parse(Console.ReadLine());
                Console.WriteLine(MathCommand(input));
            }
            else if (type == "real")
            {
                double input = double.Parse(Console.ReadLine());
                Console.WriteLine($"{MathCommand(input):f2}");
            }
            else if (type == "string")
            {
                string input = Console.ReadLine();
                MathCommand(input);
            }


        }

        static int MathCommand(int input)
        {
            return input * 2;
        }
        static double MathCommand(double input)
        {
            return input * 1.5;
        }
        static void MathCommand(string input)
        {
            Console.WriteLine($"${input}$");
        }

    }
}
namespace Gym.IO
{
    using Gym.IO.Contracts;
    using System;
    using System.IO;

    public class Writer : IWriter
    {
        public void Write(string message)
        {
            string path = "../../../output.txt";
            File.AppendAllText(path,message+"\n");
            Console.Write(message);
        }

        public void WriteLine(string message)
        {
            string path = "../../../output.txt";
            File.AppendAllText(path, message+"\n");
            Console.WriteLine(message);
        }
    }
}

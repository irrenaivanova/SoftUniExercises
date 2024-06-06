using P01.Stream_Progress.Interfaces;
using P01.Stream_Progress.Models;
using System;

namespace P01.Stream_Progress
{
    public class StartUp
    {
        static void Main()
        {
            IStream stream = new File("Peter", 50, 20);
            StreamProgressInfo streamer = new StreamProgressInfo(stream);
        }
    }
}

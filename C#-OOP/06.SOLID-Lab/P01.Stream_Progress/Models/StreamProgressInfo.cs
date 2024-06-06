using P01.Stream_Progress.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Models
{
    public class StreamProgressInfo:IStreamer
    {
     
        public StreamProgressInfo(IStream stream)
        {
            Stream = stream;
        }

        public IStream Stream { get; private set; }

        public int CalculateCurrentPercent()
        {
            return Stream.BytesSent * 100 / Stream.Length;
        }
    }
}

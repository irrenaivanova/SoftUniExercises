﻿using System;
using System.Collections.Generic;
using System.Text;

namespace P01.Stream_Progress.Interfaces
{
    public interface IStreamer
    {
        public IStream Stream {get; }

        public abstract int CalculateCurrentPercent();
        
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge.Interfaces
{
    internal interface IWorker
    {
        string Id { get; }
        int WorkingHours { get; }
        void Work(int hours);
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P04.Recharge.Interfaces
{
    public interface IRechargeable
    {
        int Capacity { get; }

        void Recharge();
    }
}
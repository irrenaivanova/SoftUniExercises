using P03.Detail_Printer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Interfaces
{
    public interface IPrinter
    {
        IReadOnlyList<IEmployee> Employees { get; }
        string Print();
    }
}

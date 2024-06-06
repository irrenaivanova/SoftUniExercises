using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Interfaces
{
    public interface IDocumentHaving : IEmployee
    {
        public IReadOnlyCollection<string> Documents { get; }
    }
}

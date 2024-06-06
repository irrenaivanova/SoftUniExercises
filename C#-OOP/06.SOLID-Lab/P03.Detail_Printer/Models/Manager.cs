using P03.Detail_Printer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03.Detail_Printer.Models
{
    public class Manager : Employee, IDocumentHaving
    {
        public Manager(string name, IReadOnlyCollection<string> documents) : base(name)
        {
            Documents = documents;
        }

        public IReadOnlyCollection<string> Documents { get; private set; }
        public override string ToString()=> base.ToString() +Environment.NewLine + string.Join(", ", Documents);
     
    }
}

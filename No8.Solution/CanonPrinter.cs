using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class CanonPrinter : Printer
    {
        protected override void SpecialPrint(FileStream @from, TextWriter to)
        {
            for (int i = 0; i < from.Length; i++)
            {
                to.Write(from.ReadByte());
            }
        }
    }
}

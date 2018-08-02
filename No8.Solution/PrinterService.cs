using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class PrinterService
    {
        private readonly IPrinterRepository repository;

        private readonly HashSet<PrinterEntity> printers = new HashSet<PrinterEntity>();
            
        public void Print(string source, string drain, string name, string model)
        {
            var printer = printers.FirstOrDefault(n => n == new PrinterEntity(name, model));
        }

        public void Add(string name, string model)
        {
            printers.Add(repository.Read(name, model));
        }
    }
}

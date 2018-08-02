using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public class FakeRepository : IPrinterRepository
    {
        private readonly HashSet<PrinterEntity> printers;

        public FakeRepository(IEnumerable<PrinterEntity> printers)
        {
            if (printers == null)
            {
                throw new ArgumentNullException();
            }

            foreach (var item in printers)
            {
                this.printers.Add(item);
            }
        }

        public PrinterEntity Read(string name, string model)
        {
            var printer = new PrinterEntity(name, model);

            return printers.First(p => p == printer);
        }
    }
}

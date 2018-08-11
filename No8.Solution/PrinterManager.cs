namespace No8.Solution
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Windows.Forms;
    using Logers;

    public sealed class PrinterManager
    {
        private static readonly Lazy<PrinterManager> lazyManager;

        private readonly HashSet<Printer> printers;

        static PrinterManager()
        {
            lazyManager = new Lazy<PrinterManager>(() => new PrinterManager());
        }

        private PrinterManager()
        {
            this.printers = new HashSet<Printer>();
        }

        public static PrinterManager Instance => lazyManager.Value;

        public ILoger loger { get; set; }

        public IEnumerable<Printer> Printers => printers;

        public void Add(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} cannot be null");
            }

            if (!printers.Add(printer))
            {
                const string message = "You cannot assign the printer which already exists";

                loger?.Error(message);

                throw new ArgumentException(message);
            }
            
            printer.PrintStarted += (sender, args) => loger?.Info($"{printer.ToString()} started");
            printer.PrintFinished += (sender, args) => loger?.Info($"{printer.ToString()} finished");
        }

        public void Remove(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} cannot be null");
            }

            if (!printers.Remove(printer))
            {
                const string message = "You cannot remove the printer which does not exist";

                loger?.Error(message);

                throw new ArgumentException(message);
            }
        }

        public void Print(Printer printer)
        {
            if (printer == null)
            {
                throw new ArgumentNullException($"{nameof(printer)} cannot be null");
            }

            if (!printers.Contains(printer))
            {
                const string message = "There is no such printer";

                loger?.Error(message);

                throw new ArgumentException(message);
            }

            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.ShowDialog();

                using (Stream stream = File.OpenRead(ofd.FileName))
                {
                    printer.Print(stream);
                }
            }
        }
    }
}

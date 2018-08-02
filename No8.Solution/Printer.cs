using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace No8.Solution
{
    public abstract class Printer
    {
        public string Name { get; protected set; }

        public string Model { get; protected set; }

        public void Print(FileStream from, TextWriter to)
        {
            OnPrintStarted();

            SpecialPrint(from, to);

            OnPrintFinished();
        }

        protected abstract void SpecialPrint(FileStream from, TextWriter to);

        public event EventHandler<PrintStartedEventArgs> PrintStarted;

        public event EventHandler<PrintFinishedEventArgs> PrintFinished;

        protected virtual void OnPrintStarted()
        {
            this.PrintStarted?.Invoke(this, new PrintStartedEventArgs());
        }

        protected virtual void OnPrintFinished()
        {
            this.PrintFinished?.Invoke(this, new PrintFinishedEventArgs());   
        }
    }
}

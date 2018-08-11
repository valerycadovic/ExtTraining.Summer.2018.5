namespace No8.Solution.Console.PrinterFactories
{
    using System.IO;

    public class CanonPrinterFactory : PrinterFactory
    {
        public override Printer CreatePrinter()
        {
            return new CanonPrinter(new StreamWriter(System.Console.OpenStandardOutput()), "PIXMA iP110");
        }
    }
}

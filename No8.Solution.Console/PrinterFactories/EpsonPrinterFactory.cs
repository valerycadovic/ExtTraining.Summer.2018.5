namespace No8.Solution.Console.PrinterFactories
{
    using System.IO;

    public class EpsonPrinterFactory : PrinterFactory
    {
        public override Printer CreatePrinter()
        {
            return new EpsonPrinter(new StreamWriter(System.Console.OpenStandardOutput()), "L132");
        }
    }
}

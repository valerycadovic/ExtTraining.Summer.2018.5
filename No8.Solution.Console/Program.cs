using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using No8.Solution.Console.PrinterFactories;

namespace No8.Solution.Console
{
    public class Program
    {
        private static PrinterManager printerManager;

        [STAThread]
        public static void Main(string[] args)
        {
            printerManager = PrinterManager.Instance;
            ShowMainMenu();
        }

        private static void ShowMainMenu()
        {
            AGAIN:
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("\tMain Menu\n");
            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("1. Print");
            System.Console.WriteLine("2. Add Printer");
            System.Console.WriteLine("3. Remove Printer");
            System.Console.WriteLine("4. Exit");

            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("\n\nYour choice: ");

            var key = System.Console.ReadKey();

            System.Console.ResetColor();
            
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    System.Console.Clear();
                    ShowPrintMenu();
                    goto AGAIN;
                case ConsoleKey.D2:
                    System.Console.Clear();
                    ShowAddMenu();
                    goto AGAIN;
                case ConsoleKey.D3:
                    System.Console.Clear();
                    ShowRemoveMenu();
                    goto AGAIN;
                case ConsoleKey.D4:
                    return;
                default:
                    System.Console.Clear();
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.WriteLine("Wrong key: press 1 or 2");
                    System.Console.ResetColor();
                    goto AGAIN;
            }
        }

        private static void ShowPrintMenu()
        {
            AGAIN:
            ShowPrinters();

            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("Non-number: Back To Main Menu");

            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("Your Choice: ");
            
            string typeResult = System.Console.ReadLine();

            if (!int.TryParse(typeResult, out int index))
            {
                return;
            }

            Printer[] printers = printerManager.Printers.ToArray();

            if (index >= printers.Length || index < 0)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Clear();
                System.Console.WriteLine("Invalid index of printer");
                System.Console.ResetColor();
                goto AGAIN;
            }

            printerManager.Print(printers[index]);
        }

        private static void ShowAddMenu()
        {
            AGAIN:
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("\tAvailable Producers\n");

            System.Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine("1. Epson");
            System.Console.WriteLine("2. Canon\n\n");
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("0. Exit ");

            System.Console.ForegroundColor = ConsoleColor.Blue;
            System.Console.Write("Your choice: ");

            var key = System.Console.ReadKey();

            switch (key.Key)
            {
                case ConsoleKey.D0:
                    System.Console.ReadKey();
                    System.Console.Clear();
                    return;
                case ConsoleKey.D1:
                    Add(new EpsonPrinterFactory());
                    System.Console.WriteLine("Epson Added");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    break;
                case ConsoleKey.D2:
                    System.Console.WriteLine("Canon Added");
                    System.Console.ReadKey();
                    System.Console.Clear();
                    Add(new CanonPrinterFactory());
                    break;
                default:
                    System.Console.ForegroundColor = ConsoleColor.Red;
                    System.Console.Clear();
                    System.Console.WriteLine("Invalid producer of printers");
                    System.Console.ResetColor();
                    goto AGAIN;
            }

            System.Console.WriteLine();
        }
        
        private static void ShowRemoveMenu()
        {
            AGAIN:
            ShowPrinters();
            System.Console.WriteLine("Non-number: Back to Main Menu");

            System.Console.Write("Your choice: ");

            string typeResult = System.Console.ReadLine();

            if (!int.TryParse(typeResult, out int index))
            {
                return;
            }

            var length = printerManager.Printers.Count();

            if (index >= length || index < 0)
            {
                System.Console.ForegroundColor = ConsoleColor.Red;
                System.Console.Clear();
                System.Console.WriteLine("Invalid index of printer");
                System.Console.ResetColor();
                goto AGAIN;
            }

            Remove(index);
        }

        private static void Add(PrinterFactory factory)
        {
            try
            {
                printerManager.Add(factory.CreatePrinter());
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                System.Console.ReadKey();
            }
        }

        private static void Remove(int index)
        {
            var printer = printerManager.Printers.ElementAt(index);

            try
            {
                printerManager.Remove(printer);
                printer.Dispose();
            }
            catch (Exception e)
            {
                System.Console.WriteLine(e);
                System.Console.ReadKey();
            }
        }

        private static void ShowPrinters()
        {
            System.Console.ForegroundColor = ConsoleColor.Yellow;
            System.Console.WriteLine("\tAvailavle Printers\n");
            System.Console.ForegroundColor = ConsoleColor.Green;

            int i = 0;
            foreach (var item in printerManager.Printers)
            {
                System.Console.WriteLine($"{i++}: {item.ToString()}");
            }

            System.Console.WriteLine();
            System.Console.ResetColor();
        }
    }
}

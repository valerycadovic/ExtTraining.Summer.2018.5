namespace No8.Solution.Console.Logers
{
    using System;
    using No8.Solution.Logers;

    public class ConsoleLoger : ILoger
    {
        public void Warn(string message)
        {
            Console.WriteLine($"WARN: {message}");
        }

        public void Error(string message)
        {
            Console.WriteLine($"ERROR: {message}");
        }

        public void Fatal(string message)
        {
            Console.WriteLine($"FATAL: {message}");
        }

        public void Debug(string message)
        {
            Console.WriteLine($"DEBUG: {message}");
        }

        public void Info(string message)
        {
            Console.WriteLine($"INFO: {message}");
        }
    }
}

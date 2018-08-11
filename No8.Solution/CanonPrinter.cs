using System;
using System.Linq;
using System.Text;

namespace No8.Solution
{
    using System.IO;

    public sealed class CanonPrinter : Printer
    {
        private const int DefaultBufferSize = 32;

        private readonly TextWriter drain;

        public CanonPrinter(TextWriter drain, string model) : base(model)
        {
            ValidateOnNull(drain, nameof(drain));
            this.drain = drain;
        }

        public override string Name => "Canon";

        protected override void UniquePrint(Stream stream)
        {
            byte[] dummy = new byte[DefaultBufferSize];

            while (true)
            {
                Array.Clear(dummy, 0, dummy.Length);
                int bytesRead = stream.Read(dummy, 0, dummy.Length);
                
                if (bytesRead == 0)
                {
                    break;
                }
                drain.Write(string.Join(string.Empty, dummy.Take(bytesRead).Select(b => (char)b)));
            }

        }

        public override void Dispose()
        {
            drain.Dispose();
        }
    }
}

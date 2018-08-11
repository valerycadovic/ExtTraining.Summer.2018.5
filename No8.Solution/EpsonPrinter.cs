namespace No8.Solution
{
    using System;
    using System.IO;

    public sealed class EpsonPrinter : Printer
    {
        private readonly TextWriter drain;

        public EpsonPrinter(TextWriter drain, string model) : base(model)
        {
            ValidateOnNull(drain, nameof(drain));

            this.drain = drain;
        }

        public override string Name => "Epson";

        protected override void UniquePrint(Stream stream)
        {
            for (int i = 0; i < stream.Length; i++)
            {
                drain.Write((char)stream.ReadByte());
            }
        }

        public override void Dispose()
        {
            drain.Dispose();
        }
    }
}

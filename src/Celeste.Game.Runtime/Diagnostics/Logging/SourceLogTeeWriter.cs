using System.IO;
using System.Text;

namespace Celeste.Game.Runtime.Diagnostics.Logging
{
    // Instance synchronization covers loader and logger callers; neither sink is replaced globally.
    public sealed class SourceLogTeeWriter : TextWriter
    {
        private readonly object sync = new();
        private readonly TextWriter output;
        private readonly TextWriter log;

        public SourceLogTeeWriter(TextWriter output, TextWriter log)
        {
            this.output = output;
            this.log = log;
        }

        public override Encoding Encoding => output.Encoding;

        public override void Write(char value)
        {
            lock (sync)
            {
                output.Write(value);
                log.Write(value);
                if (value == '\n') log.Flush();
            }
        }

        public override void Write(string? value)
        {
            lock (sync)
            {
                output.Write(value);
                log.Write(value);
            }
        }

        public override void WriteLine(string? value)
        {
            lock (sync)
            {
                output.WriteLine(value);
                log.WriteLine(value);
                log.Flush();
            }
        }

        public override void WriteLine()
        {
            lock (sync)
            {
                output.WriteLine();
                log.WriteLine();
                log.Flush();
            }
        }

        public override void Flush()
        {
            lock (sync)
            {
                output.Flush();
                log.Flush();
            }
        }
    }
}

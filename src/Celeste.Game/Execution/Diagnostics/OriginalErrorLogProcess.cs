using System;
using System.IO;

namespace Celeste.Game.Execution.Diagnostics
{
    public class OriginalErrorLogProcess
    {
        public const string Marker = "==========================================";
        public string Filename;
        protected readonly IOriginalErrorLogIo Io;
        protected readonly IOriginalErrorLogEnvironment Environment;

        public OriginalErrorLogProcess(IOriginalErrorLogIo io, IOriginalErrorLogEnvironment environment,
            string filename = "error_log.txt")
        {
            Io = io;
            Environment = environment;
            Filename = filename;
        }

        public virtual void Write(Exception exception) => Write(exception.ToString());
        protected virtual string GetVersionText() => Environment.Engine.Version.ToString();

        public virtual void Write(string str)
            => Celeste.Game.Execution.Threading.OriginalGameErrorLog.Write(
                str, Environment.Engine, Io, Filename, GetVersionText);

        public virtual void Open()
        {
            if (Io.FileExists(Filename)) Io.OpenDocument(Filename);
        }
    }
}

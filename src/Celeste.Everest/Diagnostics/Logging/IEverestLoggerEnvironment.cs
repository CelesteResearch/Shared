using System.IO;

namespace Celeste.Everest.Diagnostics.Logging
{
    public interface IEverestLoggerEnvironment
    {
        EverestCoreSettings Settings { get; }
        TextWriter ConsoleWriter { get; }
        global::Celeste.Core.IO.Console.ISourceConsoleModeIO ConsoleModes { get; }
    }
}

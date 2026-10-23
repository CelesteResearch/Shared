using System.IO;
using Celeste.Core.IO.Console;

namespace Celeste.Everest.Diagnostics.Logging
{
    public interface IEverestLoggerEnvironment
    {
        EverestCoreSettings Settings { get; }
        TextWriter ConsoleWriter { get; }
        ISourceConsoleModeIO ConsoleModes { get; }
    }
}

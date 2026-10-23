using MonoMod.Cil;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        internal void VerboseCoreNLuaRedirect(ILContext il, ILCursor cursor)
        {
            if (shouldLog("core", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "core",
                    $"Redirecting Assembly.GetTypes => Extensions.GetTypesSafe in {il.Method.FullName}, index {cursor.Index}");
        }

        internal void VerboseCoreLogHistory(int keep, string file)
        {
            if (shouldLog("core", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "core",
                    $"log.txt history: keeping {keep} file(s) of history, deleting {file}");
        }
    }
}

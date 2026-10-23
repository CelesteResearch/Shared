using Celeste.Everest.Content.Registry;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess : IEverestContentDumpDiagnostics
    {
        public void DumpAsset(string fullName, object asset)
        {
            if (shouldLog("dump", EverestLogLevel.Verbose))
                LogUnchecked(EverestLogLevel.Verbose, "dump", fullName + " " + asset.GetType().FullName);
        }
    }
}

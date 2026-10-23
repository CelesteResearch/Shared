namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void AtlasTextureMissing(string relativeDataPath, string id)
        {
            if (shouldLog("Atlas", EverestLogLevel.Warn))
                LogUnchecked(EverestLogLevel.Warn, "Atlas",
                    "Requested texture that does not exist: " + relativeDataPath + id);
        }
    }
}

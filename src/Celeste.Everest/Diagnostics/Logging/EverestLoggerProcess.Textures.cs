using Celeste.Everest.Content.Textures;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess : IEverestVirtualTextureDiagnostics
    {
        public void InvalidPngMagic(ulong value, string path)
        {
            if (shouldLog("vtex", EverestLogLevel.Error))
                LogUnchecked(EverestLogLevel.Error, "vtex",
                    "Failed preloading PNG: Expected magic to be 0x0A1A0A0D474E5089, got 0x" + value.ToString("X16") +
                    " - " + path);
        }

        public void InvalidPngFirstChunkLength(uint value, string path)
        {
            if (shouldLog("vtex", EverestLogLevel.Error))
                LogUnchecked(EverestLogLevel.Error, "vtex",
                    "Failed preloading PNG: Expected first chunk length to be 0x0D000000, got 0x" +
                    value.ToString("X8") +
                    " - " + path);
        }

        public void InvalidPngHeaderMarker(uint value, string path)
        {
            if (shouldLog("vtex", EverestLogLevel.Error))
                LogUnchecked(EverestLogLevel.Error, "vtex",
                    "Failed preloading PNG: Expected IHDR marker 0x52444849, got 0x" + value.ToString("X8") + " - " +
                    path);
        }
    }
}

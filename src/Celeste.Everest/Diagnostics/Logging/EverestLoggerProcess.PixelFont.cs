using Celeste.Core.Text;
using Celeste.Everest.Content.Assets;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void VerbosePixelFontLoading(string path)
        {
            if (!shouldLog("PixelFont", EverestLogLevel.Verbose)) return;
            var message = new SourceDefaultInterpolatedStringHandler(14, 1);
            message.AppendLiteral("Loading font: ");
            message.AppendFormatted(path);
            LogUnchecked(EverestLogLevel.Verbose, "PixelFont", message.ToStringAndClear());
        }

        public void VerbosePixelFontVanilla()
        {
            if (!shouldLog("PixelFont", EverestLogLevel.Verbose)) return;
            LogUnchecked(EverestLogLevel.Verbose, "PixelFont", "=> vanilla font file");
        }

        public void VerbosePixelFontMod(EverestContentAsset asset)
        {
            if (!shouldLog("PixelFont", EverestLogLevel.Verbose)) return;
            var message = new SourceDefaultInterpolatedStringHandler(22, 1);
            message.AppendLiteral("=> mod font file from ");
            message.AppendFormatted(asset.Source.Name);
            LogUnchecked(EverestLogLevel.Verbose, "PixelFont", message.ToStringAndClear());
        }

        public void VerbosePixelFontImported(int imported)
        {
            if (!shouldLog("PixelFont", EverestLogLevel.Verbose)) return;
            var message = new SourceDefaultInterpolatedStringHandler(28, 1);
            message.AppendLiteral("==> Imported ");
            message.AppendFormatted(imported);
            message.AppendLiteral(" new characters");
            LogUnchecked(EverestLogLevel.Verbose, "PixelFont", message.ToStringAndClear());
        }
    }
}

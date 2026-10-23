using Celeste.Core.Text;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void FileSelectMissingVanillaData(int slot)
        {
            if (!shouldLog("OuiFileSelect", EverestLogLevel.Warn)) return;
            var message = new SourceDefaultInterpolatedStringHandler(74, 1);
            message.AppendLiteral("Save slot ");
            message.AppendFormatted(slot);
            message.AppendLiteral(" has modded data but no vanilla save data, flagging as corrupted");
            LogUnchecked(EverestLogLevel.Warn, "OuiFileSelect", message.ToStringAndClear());
        }
    }
}

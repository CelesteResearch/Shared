using Celeste.Core.Text;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public bool BeginCoreMapFixupWarning(int literalLength, int formattedCount,
            out SourceDefaultInterpolatedStringHandler message)
        {
            bool enabled = shouldLog("core", EverestLogLevel.Warn);
            message = enabled
                ? new SourceDefaultInterpolatedStringHandler(literalLength, formattedCount)
                : default;
            return enabled;
        }

        public void EndCoreMapFixupWarning(ref SourceDefaultInterpolatedStringHandler message,
            bool enabled)
        {
            if (enabled) LogUnchecked(EverestLogLevel.Warn, "core", message.ToStringAndClear());
        }
    }
}

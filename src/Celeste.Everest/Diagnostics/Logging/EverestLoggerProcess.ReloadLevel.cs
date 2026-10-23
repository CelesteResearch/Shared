using Celeste.Core.Text;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void WarnReloadLevelFailed(string sid, string suffix)
        {
            var shouldLog = this.shouldLog("reload", EverestLogLevel.Warn);
            SourceDefaultInterpolatedStringHandler message = default;
            if (shouldLog)
            {
                message = new(26, 2);
                message.AppendLiteral("Failed reloading level '");
                message.AppendFormatted(sid);
                message.AppendFormatted(suffix);
                message.AppendLiteral("':");
            }

            LogUnchecked(EverestLogLevel.Warn, "reload", shouldLog ? message.ToStringAndClear() : string.Empty);
        }
    }
}

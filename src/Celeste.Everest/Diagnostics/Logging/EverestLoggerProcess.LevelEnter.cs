using Celeste.Core.Text;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void LevelEnterFailed(string sid, string areaLabel)
        {
            const string tag = "LevelEnter";
            if (!shouldLog(tag, EverestLogLevel.Warn))
                return;
            var text = new SourceDefaultInterpolatedStringHandler(20, 2);
            text.AppendLiteral("Failed entering map ");
            text.AppendFormatted(sid);
            text.AppendFormatted(areaLabel);
            LogUnchecked(EverestLogLevel.Warn, tag, text.ToStringAndClear());
        }
    }
}

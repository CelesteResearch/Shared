using Celeste.Core.Text;
using Celeste.Everest.Content.Maps.Registry;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void VerboseAreaSides(int index, EverestArea area)
        {
            if (!shouldLog("AreaData", EverestLogLevel.Verbose)) return;
            var message = new SourceDefaultInterpolatedStringHandler(11, 3);
            message.AppendFormatted(index);
            message.AppendLiteral(": ");
            message.AppendFormatted(area.SID);
            message.AppendLiteral(" - ");
            message.AppendFormatted(area.Mode.Length);
            message.AppendLiteral(" sides");
            LogUnchecked(EverestLogLevel.Verbose, "AreaData", message.ToStringAndClear());
        }
    }
}

using Celeste.Core.Text;
using Celeste.Game.Content.Maps.Entities;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void WarnUnknownLevelEntity(OriginalLevelEntityData record)
        {
            if (!shouldLog("LoadLevel", EverestLogLevel.Warn))
                return;
            var message = new SourceDefaultInterpolatedStringHandler(41, 3);
            message.AppendLiteral("Failed loading entity ");
            message.AppendFormatted(record.Name);
            message.AppendLiteral(". Room: ");
            message.AppendFormatted(record.Level.Name);
            message.AppendLiteral(" Position: ");
            message.AppendFormattedSourceVector2(record.Position);
            LogUnchecked(EverestLogLevel.Warn, "LoadLevel", message.ToStringAndClear());
        }
    }
}

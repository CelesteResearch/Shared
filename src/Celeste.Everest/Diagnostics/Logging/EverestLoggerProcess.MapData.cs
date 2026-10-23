using Celeste.Core.Text;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Diagnostics.Logging
{
    public sealed partial class EverestLoggerProcess
    {
        public void WarnMapDataUnloadedParent(OriginalChapterMapData map, IOriginalAreaKeyPolicy areas)
        {
            var enabled = shouldLog("MapData", EverestLogLevel.Warn);
            var text = enabled ? new SourceDefaultInterpolatedStringHandler(55, 1) : default;
            if (!enabled)
                return;
            text.AppendLiteral("Failed auto-assigning data from ");
            text.AppendFormatted(areas.Format(map.Area));
            text.AppendLiteral(" to its unloaded parent");
            LogUnchecked(EverestLogLevel.Warn, "MapData", text.ToStringAndClear());
        }

        public void WarnMapDataLoadFailure(OriginalChapterMapData map, IOriginalAreaKeyPolicy areas)
        {
            var enabled = shouldLog("MapData", EverestLogLevel.Warn);
            var text = enabled ? new SourceDefaultInterpolatedStringHandler(23, 1) : default;
            if (!enabled)
                return;
            text.AppendLiteral("Failed loading MapData ");
            text.AppendFormatted(areas.Format(map.Area));
            LogUnchecked(EverestLogLevel.Warn, "MapData", text.ToStringAndClear());
        }

        public void WarnMapDataDuplicateRoom(OriginalChapterMapData map, OriginalLevelRoomData level)
        {
            var enabled = shouldLog("MapData", EverestLogLevel.Warn);
            var text = enabled ? new SourceDefaultInterpolatedStringHandler(43, 2) : default;
            if (!enabled)
                return;
            text.AppendLiteral("Failed to load duplicate room name ");
            text.AppendFormatted(level.Name);
            text.AppendLiteral(" in map ");
            text.AppendFormatted(map.Data?.SID);
            LogUnchecked(EverestLogLevel.Warn, "MapData", text.ToStringAndClear());
        }
    }
}

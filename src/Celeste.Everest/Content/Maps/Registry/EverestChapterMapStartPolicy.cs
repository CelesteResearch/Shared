using System.Linq;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Content.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Areas;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class EverestChapterMapStartPolicy : IOriginalChapterMapStartPolicy
    {
        private readonly IOriginalAreaKeyEnvironment areas;
        private readonly IEverestLoggerProcessEnvironment logging;
        private readonly OriginalChapterMapStartPolicy original;

        public EverestChapterMapStartPolicy(IOriginalAreaKeyEnvironment areas,
            IEverestLoggerProcessEnvironment logging, OriginalChapterMapStartPolicy original)
        {
            this.areas = areas;
            this.logging = logging;
            this.original = original;
        }

        public OriginalLevelRoomData StartLevel(OriginalChapterMapData map)
        {
            var areaMetadata = ((EverestArea)areas.AreaKeys.GetArea(map.Area)).Metadata;
            var metadata = (areaMetadata?.Modes?.Length).GetValueOrDefault() <= map.Area.Mode
                ? null
                : areaMetadata.Modes[map.Area.Mode];
            OriginalLevelRoomData room;
            if (!string.IsNullOrEmpty(metadata?.StartLevel))
            {
                room = map.Levels.FirstOrDefault(level => level.Name == metadata.StartLevel);
                if (room != null) return room;
                var message = logging.Logger.BeginEnabledMessage("MapData", EverestLogLevel.Warn);
                if (message.ShouldLog)
                    message.Write("The starting room defined in metadata, \"" + metadata.StartLevel +
                                  "\", does not exist for map " + map.Data?.SID + "!");
            }

            room = original.StartLevel(map);
            if (room != null) return room;
            var fallbackMessage = logging.Logger.BeginEnabledMessage("MapData", EverestLogLevel.Debug);
            if (fallbackMessage.ShouldLog)
                fallbackMessage.Write("There is no room at (0,0) in map " + map.Data?.SID +
                                      ", attempting fallback to the first room.");
            room = map.Levels.FirstOrDefault();
            if (room == null)
            {
                var emptyMessage = logging.Logger.BeginEnabledMessage("MapData", EverestLogLevel.Warn);
                if (emptyMessage.ShouldLog)
                    emptyMessage.Write("Map " + map.Data?.SID + " has no rooms!");
            }

            return room;
        }
    }
}

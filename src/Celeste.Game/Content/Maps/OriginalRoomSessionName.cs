using Celeste.Core.Maps;
using Celeste.Simulation.Content;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalRoomSessionName : IRoomSessionName
    {
        public static readonly OriginalRoomSessionName Instance = new OriginalRoomSessionName();

        private OriginalRoomSessionName()
        {
        }

        // Preserve ChapterSessionMap.LevelName's exact four-character cut.
        public string LevelName(MapElement room) => room.Text("name").Substring(4);
    }
}

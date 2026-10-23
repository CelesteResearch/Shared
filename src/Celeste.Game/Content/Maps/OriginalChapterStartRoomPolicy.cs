using Celeste.Core.Maps;
using Celeste.Simulation;
using Celeste.Simulation.Content;

namespace Celeste.Game.Content.Maps
{
    public sealed class OriginalChapterStartRoomPolicy : IChapterStartRoomPolicy
    {
        public static readonly OriginalChapterStartRoomPolicy Instance = new OriginalChapterStartRoomPolicy();

        private OriginalChapterStartRoomPolicy()
        {
        }

        public MapElement Select(MapDocument map)
        {
            foreach (MapElement room in map.Rooms)
            {
                global::Celeste.Core.Geometry.Bounds bounds = RoomSpawnPoints.Bounds(room);
                if (0 >= bounds.X && 0 >= bounds.Y && 0 < bounds.Right && 0 < bounds.Bottom) return room;
            }

            return null;
        }
    }
}

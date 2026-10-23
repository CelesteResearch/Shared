using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    // Name stored in a chapter session for a room in this content format.
    public interface IRoomSessionName
    {
        string LevelName(MapElement room);
    }
}

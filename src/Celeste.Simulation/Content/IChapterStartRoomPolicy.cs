using Celeste.Core.Maps;

namespace Celeste.Simulation.Content
{
    // Selects the default chapter start room when no session override was supplied.
    public interface IChapterStartRoomPolicy
    {
        MapElement Select(MapDocument map);
    }
}

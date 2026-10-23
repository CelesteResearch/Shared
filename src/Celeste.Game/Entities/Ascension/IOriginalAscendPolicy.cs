using Celeste.Simulation;

namespace Celeste.Game.Entities.Ascension
{
    public interface IOriginalAscendPolicy
    {
        bool ShouldRestorePlayerX(RoomPlayerSession player);
        bool HeightDisplayPlayerAirborne(RoomPlayerSession player);
    }
}

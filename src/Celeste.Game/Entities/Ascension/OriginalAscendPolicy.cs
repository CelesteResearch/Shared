using Celeste.Simulation;

namespace Celeste.Game.Entities.Ascension
{
    public sealed class OriginalAscendPolicy : IOriginalAscendPolicy
    {
        public bool ShouldRestorePlayerX(RoomPlayerSession player)
        {
            return false;
        }

        public bool HeightDisplayPlayerAirborne(RoomPlayerSession player)
        {
            return !player.OnGround();
        }
    }
}

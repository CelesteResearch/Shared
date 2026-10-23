using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Ascension
{
    public sealed class OriginalAscendPolicy : IOriginalAscendPolicy
    {
        public bool ShouldRestorePlayerX(RoomPlayerSession player) => false;
        public bool HeightDisplayPlayerAirborne(RoomPlayerSession player) => !player.OnGround();
    }
}

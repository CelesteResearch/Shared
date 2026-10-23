using System.Numerics;
using Celeste.Core.Maps;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public readonly struct PlayerDeathRequest
    {
        public readonly Vector2 Direction;
        public readonly bool EvenIfInvincible, RegisterDeathInStats;
        public readonly MapElement Source;

        public PlayerDeathRequest(Vector2 direction, bool evenIfInvincible = false, bool registerDeathInStats = true,
            MapElement source = null)
        {
            Direction = direction;
            EvenIfInvincible = evenIfInvincible;
            RegisterDeathInStats = registerDeathInStats;
            Source = source;
        }
    }
}

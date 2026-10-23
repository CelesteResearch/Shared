using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public readonly struct PlayerDeathRequest
    {
        public readonly Vector2 Direction;
        public readonly bool EvenIfInvincible, RegisterDeathInStats;
        public readonly global::Celeste.Core.Maps.MapElement Source;

        public PlayerDeathRequest(Vector2 direction, bool evenIfInvincible = false, bool registerDeathInStats = true,
            global::Celeste.Core.Maps.MapElement source = null)
        {
            Direction = direction;
            EvenIfInvincible = evenIfInvincible;
            RegisterDeathInStats = registerDeathInStats;
            Source = source;
        }
    }
}

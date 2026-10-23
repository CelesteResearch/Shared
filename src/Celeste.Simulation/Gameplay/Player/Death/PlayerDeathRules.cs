using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Gameplay.Player.Death
{
    public static class PlayerDeathRules
    {
        public static bool CanDie(bool dead, int state, bool invincible, bool evenIfInvincible = false)
            => !dead && state != 18 && (!invincible || evenIfInvincible);
    }
}

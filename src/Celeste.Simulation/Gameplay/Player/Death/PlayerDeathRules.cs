namespace Celeste.Simulation.Gameplay.Player.Death
{
    public static class PlayerDeathRules
    {
        public static bool CanDie(bool dead, int state, bool invincible, bool evenIfInvincible = false)
        {
            return !dead && state != 18 && (!invincible || evenIfInvincible);
        }
    }
}

using Celeste.Simulation.Gameplay.Player.State;

namespace Celeste.Simulation.Gameplay.Player.Inventory
{
    public static class PlayerRefills
    {
        public static bool Use(PlayerState player, int maxDashes, bool twoDashes)
        {
            int target = twoDashes ? 2 : maxDashes;
            // Keep the original positive predicate, including unordered floating values.
            if (player.Dashes < target || player.Stamina < 20)
            {
                player.Dashes = target;
                player.Stamina = 110;
                return true;
            }

            return false;
        }
    }
}

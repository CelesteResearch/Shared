using System.Numerics;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Hair
{
    public interface IPlayerHairOwner
    {
        Vector2 HairOwnerPosition { get; }
        bool HairOwnerActive { get; }
    }
}

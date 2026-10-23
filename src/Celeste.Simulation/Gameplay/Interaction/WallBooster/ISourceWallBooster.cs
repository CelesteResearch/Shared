using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Interaction.WallBooster
{
    public interface ISourceWallBooster : ISourceEntityCollider
    {
        int Facing { get; }
    }
}

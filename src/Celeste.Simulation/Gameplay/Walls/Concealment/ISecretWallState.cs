using Celeste.Core.Components;
using Celeste.Physics.Collision;

namespace Celeste.Simulation.Gameplay.Walls.Concealment
{
    public interface ISecretWallState : ISourceMutableEntityState, ISourceEntityCollider
    {
        void Update();
    }
}

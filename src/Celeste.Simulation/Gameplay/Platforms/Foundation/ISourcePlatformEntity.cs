using System.Numerics;
using Celeste.Core.Components;
using Celeste.Physics.Collision;
using Celeste.Simulation.Gameplay.Platforms.StaticMovers;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface ISourcePlatformEntity : ISourceMutableEntityState, ISourceEntityCollider
    {
        new Vector2 Position { get; set; }
        new bool Collidable { get; set; }
        Vector2 LiftSpeed { get; }
        void MoveStaticMovers(Vector2 amount);
        void ShakeStaticMovers(Vector2 amount);
        void DestroyStaticMovers();
        void EnableStaticMovers();
        void DisableStaticMovers();
        void OnStaticMoverTrigger(SourceStaticMoverState mover);
    }
}

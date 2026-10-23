using Celeste.Core.Randomness;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Movement;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public interface ISourceSolidWorld
    {
        StaticMoverAttachmentCheckOrder AttachmentCheckOrder { get; }
        CollisionPlatform Platform { get; }
        SolidPlatformMover Mover { get; }
        ISourceRandom GameplayRandom { get; }
        Celeste.Core.Scheduling.ISourceEngineContext EngineContext { get; }
        ISourceSolidAssistPolicy SolidAssistPolicy { get; }
        IPlatformTargetMotionPolicy TargetMotionPolicy { get; }
        ISourcePlatformCollisionEffects CollisionEffects { get; }
    }
}

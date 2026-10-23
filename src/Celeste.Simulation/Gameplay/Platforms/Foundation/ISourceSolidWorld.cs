using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
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
        ISourceEngineContext EngineContext { get; }
        ISourceSolidAssistPolicy SolidAssistPolicy { get; }
        IPlatformTargetMotionPolicy TargetMotionPolicy { get; }
        ISourcePlatformCollisionEffects CollisionEffects { get; }
    }
}

using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Movement;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public sealed class SourceSolidWorld : ISourceSolidWorld
    {
        public StaticMoverAttachmentCheckOrder AttachmentCheckOrder { get; }
        public CollisionPlatform Platform { get; }
        public SolidPlatformMover Mover { get; }
        public ISourceRandom GameplayRandom => ((ISourceRandomEnvironment)EngineContext).Random;
        public ISourceEngineContext EngineContext { get; }
        public ISourceSolidAssistPolicy SolidAssistPolicy { get; }
        public IPlatformTargetMotionPolicy TargetMotionPolicy { get; }
        public ISourcePlatformCollisionEffects CollisionEffects { get; }

        internal SourceSolidWorld(CollisionPlatform platform, SolidPlatformMover mover,
            ISourceEngineContext engineContext, ISourceSolidAssistPolicy solidAssistPolicy,
            IPlatformTargetMotionPolicy targetMotionPolicy, ISourcePlatformCollisionEffects collisionEffects,
            StaticMoverAttachmentCheckOrder attachmentCheckOrder)
        {
            AttachmentCheckOrder = attachmentCheckOrder;
            Platform = platform;
            Mover = mover;
            EngineContext = engineContext;
            SolidAssistPolicy = solidAssistPolicy;
            TargetMotionPolicy = targetMotionPolicy;
            CollisionEffects = collisionEffects;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Gameplay.Actors;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Movement;

namespace Celeste.Simulation.Gameplay.Platforms.Foundation
{
    public sealed class SourceSolidWorldFactory : ISourceSolidWorldFactory
    {
        private readonly StaticMoverAttachmentCheckOrder attachmentCheckOrder;
        private readonly PlatformCollisionWorld collisionWorld;
        private readonly ISourceEngineContext engineContext;
        private readonly ISourceSolidAssistPolicy solidAssistPolicy;
        private readonly IPlatformTargetMotionPolicy targetMotionPolicy;
        private readonly ISourcePlatformCollisionEffects collisionEffects;

        public SourceSolidWorldFactory(PlatformCollisionWorld collisionWorld,
            ISourceEngineContext engineContext, ISourceSolidAssistPolicy solidAssistPolicy,
            IPlatformTargetMotionPolicy targetMotionPolicy, ISourcePlatformCollisionEffects collisionEffects,
            StaticMoverAttachmentCheckOrder attachmentCheckOrder)
        {
            this.attachmentCheckOrder = attachmentCheckOrder;
            this.collisionWorld = collisionWorld ?? throw new ArgumentNullException(nameof(collisionWorld));
            this.engineContext = engineContext ?? throw new ArgumentNullException(nameof(engineContext));
            this.solidAssistPolicy = solidAssistPolicy ?? throw new ArgumentNullException(nameof(solidAssistPolicy));
            this.targetMotionPolicy = targetMotionPolicy ?? throw new ArgumentNullException(nameof(targetMotionPolicy));
            this.collisionEffects = collisionEffects ?? throw new ArgumentNullException(nameof(collisionEffects));
        }


        public ISourceSolidWorld CreateJumpThru(Vector2 position, bool safe)
        {
            var platform = new CollisionPlatform(position, isJumpThru: true, safe: safe);
            var mover = new SolidPlatformMover(platform, collisionWorld);
            return new SourceSolidWorld(platform, mover, engineContext, solidAssistPolicy,
                targetMotionPolicy, collisionEffects, attachmentCheckOrder);
        }

        public ISourceSolidWorld Create(Vector2 position, bool safe)
        {
            var platform = new CollisionPlatform(position, safe: safe);
            var mover = new SolidPlatformMover(platform, collisionWorld);
            return new SourceSolidWorld(platform, mover, engineContext, solidAssistPolicy, targetMotionPolicy,
                collisionEffects, attachmentCheckOrder);
        }
    }
}

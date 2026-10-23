using System;
using Celeste.Game.Audio.Runtime;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Game.Gameplay.Assists.Solids;
using Celeste.Game.Save.Runtime;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation.Gameplay.Platforms.Collision;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot : ISourcePlatformCollisionScene
    {
        private PlatformCollisionWorld platformWorld;
        private ISourceSolidWorldFactory solidWorldFactory;

        public PlatformCollisionWorld PlatformWorld
        {
            get
            {
                if (platformWorld == null)
                    platformWorld = new PlatformCollisionWorld
                    {
                        PlatformSource = new SourceTrackedPlatformSource<CollisionPlatform>(Scheduler.Entities,
                            "Celeste.Solid", "Celeste.JumpThru")
                    };
                return platformWorld;
            }
        }

        public ISourceSolidWorldFactory SolidWorldFactory => solidWorldFactory ??
                                                             throw new InvalidOperationException(
                                                                 "The actual Level platform construction has not been bound.");

        public void BindSourcePlatformConstruction(OriginalGameAudioSession audio,
            IOriginalGameSaveContext saveContext, IPlatformTargetMotionPolicy targetMotionPolicy,
            StaticMoverAttachmentCheckOrder attachmentCheckOrder)
        {
            if (solidWorldFactory != null)
                throw new InvalidOperationException("The actual Level platform construction is already bound.");
            solidWorldFactory = new SourceSolidWorldFactory(PlatformWorld,
                EngineContext,
                new OriginalSolidAssistPolicy(audio, saveContext),
                targetMotionPolicy ?? throw new ArgumentNullException(nameof(targetMotionPolicy)),
                this, attachmentCheckOrder);
        }
    }
}

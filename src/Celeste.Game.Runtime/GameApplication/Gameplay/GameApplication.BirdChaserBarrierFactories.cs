using System;
using Celeste.Game.Profiles;
using Celeste.Game.Entities.Birds.Paths;
using Celeste.Game.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Enemies.Seeker;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalBirdPathEnvironment, IOriginalBadelineOldsiteEnvironment,
        ISourceSeekerBarrierBehaviorEnvironment
    {
        private IOriginalBirdPathFactory sourceBirdPaths;
        private IOriginalBadelineOldsiteFactory sourceBadelineOldsites;
        private BadelineOldsiteStaticState sourceBadelineOldsiteStatics;
        private ISourceSeekerBarrierBehavior sourceSeekerBarrierBehavior;

        public IOriginalBirdPathFactory BirdPaths => sourceBirdPaths ??
                                                     throw new InvalidOperationException(
                                                         "The actual BirdPath factory is not constructed.");

        public IOriginalBadelineOldsiteFactory BadelineOldsites => sourceBadelineOldsites ??
                                                                   throw new InvalidOperationException(
                                                                       "The actual BadelineOldsite factory is not constructed.");

        public BadelineOldsiteStaticState BadelineOldsiteStatics => sourceBadelineOldsiteStatics ??
                                                                    throw new InvalidOperationException(
                                                                        "The actual BadelineOldsite static state is not constructed.");

        public ISourceSeekerBarrierBehavior SeekerBarrierBehavior => sourceSeekerBarrierBehavior ??
                                                                     throw new InvalidOperationException(
                                                                         "The actual seeker barrier policy is not constructed.");

        public void ConstructSourceBirdChaserBarrierFactories()
        {
            if (sourceBirdPaths != null)
                throw new InvalidOperationException(
                    "The actual BirdPath/chaser/barrier factories are already constructed.");
            if (SourceProfile == GameProfile.Original)
            {
                sourceBirdPaths = new OriginalBirdPathFactory();
                sourceBadelineOldsites = new OriginalBadelineOldsiteFactory();
                sourceSeekerBarrierBehavior =
                    new Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerBarrierBehavior();
            }
            else
            {
                sourceBirdPaths = new Celeste.Everest.Entities.Birds.Paths.EverestBirdPathFactory();
                sourceBadelineOldsites =
                    new Celeste.Everest.Gameplay.Enemies.Badeline.Chasers.EverestBadelineOldsiteFactory();
                sourceSeekerBarrierBehavior =
                    new Celeste.Everest.Gameplay.Enemies.Seekers.EverestSeekerBarrierBehavior();
            }
        }

        public void ConstructSourceBadelineOldsiteStatics()
        {
            if (sourceBadelineOldsiteStatics != null)
                throw new InvalidOperationException("The actual BadelineOldsite static state is already constructed.");
            sourceBadelineOldsiteStatics = new BadelineOldsiteStaticState();
        }
    }
}

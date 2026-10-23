using System;
using Celeste.Core.Threading;
using Celeste.Everest.Gameplay.Enemies.Seekers;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Game.Presentation.Particles.Definitions.Seeker;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalSeekerProcess, IEverestSeekerEventsEnvironment
    {
        private IOriginalSeekerFactory sourceSeekerFactory;
        private EverestSeekerEvents sourceSeekerEvents;
        private SourceTypeInitialization<SeekerPatrolPoint[]> sourceSeekerPatrolChoices;

        public IOriginalSeekerFactory SeekerFactory => sourceSeekerFactory ??
                                                       throw new InvalidOperationException(
                                                           "The actual Seeker factory is not constructed.");

        public EverestSeekerEvents SeekerEvents => sourceSeekerEvents ??
                                                   throw new InvalidOperationException(
                                                       "Installed Seeker events are not published for this profile.");

        public SeekerParticleDefinitions SeekerParticles => ParticleTypes.Seeker;

        public SeekerPatrolPoint[] SeekerPatrolChoices => (sourceSeekerPatrolChoices ??
                                                           throw new InvalidOperationException(
                                                               "The actual Seeker type initialization is not bound."))
            .Value;

        internal void ConstructSourceSeekerProcess()
        {
            if (sourceSeekerFactory != null || sourceSeekerPatrolChoices != null)
                throw new InvalidOperationException("The actual Seeker process is already constructed.");
            if (SourceProfile == GameProfile.Original)
            {
                sourceSeekerFactory = new OriginalSeekerFactory();
            }
            else if (SourceProfile == GameProfile.InstalledEverest)
            {
                sourceSeekerEvents = new();
                sourceSeekerFactory = new EverestSeekerFactory(sourceSeekerEvents);
            }
            else
            {
                throw new InvalidOperationException("No actual Seeker process exists for this source profile.");
            }

            sourceSeekerPatrolChoices = new(
                "Celeste.Seeker", new OriginalSeekerPatrolChoicesInitializationFactory());
        }
    }
}

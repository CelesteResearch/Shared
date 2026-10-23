using System;
using Celeste.Core.Threading;
using Celeste.Everest.Gameplay.Collectibles.Hearts;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalHeartGemEnvironment
    {
        private SourceTypeInitialization<IOriginalHeartGemRuntimePolicy> sourceHeartGemPolicy;

        public IOriginalHeartGemRuntimePolicy HeartGemPolicy => (sourceHeartGemPolicy ??
                                                                 throw new InvalidOperationException(
                                                                     "The actual HeartGem type initialization descriptor has not been constructed."))
            .Value;

        internal void ConstructSourceHeartGemTypeInitialization()
        {
            if (sourceHeartGemPolicy != null)
                throw new InvalidOperationException(
                    "The actual HeartGem type initialization descriptor is already constructed.");
            sourceHeartGemPolicy = new(
                "Celeste.HeartGem", new HeartGemSourceTypeInitialization(SourceProfile));
        }

        private sealed class
            HeartGemSourceTypeInitialization : ISourceTypeInitializationFactory<IOriginalHeartGemRuntimePolicy>
        {
            private readonly GameProfile profile;

            public HeartGemSourceTypeInitialization(GameProfile profile)
            {
                this.profile = profile;
            }

            public IOriginalHeartGemRuntimePolicy Allocate()
            {
                return profile switch
                {
                    GameProfile.Original => new OriginalHeartGemRuntimePolicy(),
                    GameProfile.InstalledEverest =>
                        new EverestHeartGemRuntimePolicy(),
                    _ => throw new InvalidOperationException("A supported source profile is required."),
                };
            }

            // Complete field initializers execute in the existing constructor; no later initializer body.
            public void Initialize(IOriginalHeartGemRuntimePolicy instance)
            {
            }
        }
    }
}

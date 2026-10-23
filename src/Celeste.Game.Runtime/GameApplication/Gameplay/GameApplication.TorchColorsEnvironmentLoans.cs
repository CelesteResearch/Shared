using System;
using Celeste.Core.Threading;
using Celeste.Everest.Entities.LightSources.Torches;
using Celeste.Game.Entities.LightSources.Torches;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalTorchColorsEnvironment
    {
        private SourceTypeInitialization<IOriginalTorchColors> sourceTorchColors;

        public IOriginalTorchColors TorchColors => (sourceTorchColors ??
                                                    throw new InvalidOperationException(
                                                        "The actual TorchColors type initialization descriptor has not been constructed."))
            .Value;

        internal void ConstructSourceTorchColorsTypeInitialization()
        {
            if (sourceTorchColors != null)
                throw new InvalidOperationException(
                    "The actual TorchColors type initialization descriptor is already constructed.");
            sourceTorchColors = new(
                "Celeste.Torch", new TorchColorsSourceTypeInitialization(SourceProfile));
        }

        private sealed class
            TorchColorsSourceTypeInitialization : ISourceTypeInitializationFactory<IOriginalTorchColors>
        {
            private readonly GameProfile profile;

            public TorchColorsSourceTypeInitialization(GameProfile profile)
            {
                this.profile = profile;
            }

            public IOriginalTorchColors Allocate()
            {
                return profile switch
                {
                    GameProfile.Original => new OriginalTorchColorsState(),
                    GameProfile.InstalledEverest =>
                        new EverestTorchColorsState(),
                    _ => throw new InvalidOperationException("A supported source profile is required."),
                };
            }

            // Complete field initializers execute in the existing constructor; no later initializer body.
            public void Initialize(IOriginalTorchColors instance)
            {
            }
        }
    }
}

using System;
using Celeste.Core.Threading;
using Celeste.Everest.Entities.Platforms.ZipMovers;
using Celeste.Game.Entities.Platforms.ZipMovers;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalZipMoverColorsEnvironment
    {
        private SourceTypeInitialization<IOriginalZipMoverColors> sourceZipMoverColors;

        public IOriginalZipMoverColors ZipMoverColors => (sourceZipMoverColors ??
                                                          throw new InvalidOperationException(
                                                              "The actual ZipMoverColors type initialization descriptor has not been constructed."))
            .Value;

        internal void ConstructSourceZipMoverColorsTypeInitialization()
        {
            if (sourceZipMoverColors != null)
                throw new InvalidOperationException(
                    "The actual ZipMoverColors type initialization descriptor is already constructed.");
            sourceZipMoverColors = new(
                "Celeste.ZipMover", new ZipMoverColorsSourceTypeInitialization(SourceProfile));
        }

        private sealed class
            ZipMoverColorsSourceTypeInitialization : ISourceTypeInitializationFactory<IOriginalZipMoverColors>
        {
            private readonly GameProfile profile;

            public ZipMoverColorsSourceTypeInitialization(GameProfile profile)
            {
                this.profile = profile;
            }

            public IOriginalZipMoverColors Allocate()
            {
                return profile switch
                {
                    GameProfile.Original => new OriginalZipMoverColorsState(),
                    GameProfile.InstalledEverest =>
                        new EverestZipMoverColorsState(),
                    _ => throw new InvalidOperationException("A supported source profile is required."),
                };
            }

            // Complete field initializers execute in the existing constructor; no later initializer body.
            public void Initialize(IOriginalZipMoverColors instance)
            {
            }
        }
    }
}

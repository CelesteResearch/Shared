using System;
using Celeste.Core.Threading;
using Celeste.Game.Entities.StarJump;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalStarJumpEnvironment
    {
        private SourceTypeInitialization<StarClimbGraphicsProcessState> sourceStarClimbGraphics;

        public StarJumpRuntimeProfile StarJumpProfile => SourceProfile switch
        {
            GameProfile.Original => StarJumpRuntimeProfile.Original,
            GameProfile.InstalledEverest => StarJumpRuntimeProfile.Installed,
            _ => throw new InvalidOperationException("A supported source profile is required.")
        };

        public StarClimbGraphicsProcessState StarClimbGraphics => (sourceStarClimbGraphics ??
                                                                   throw new InvalidOperationException(
                                                                       "The actual StarJump type initialization descriptor has not been constructed."))
            .Value;

        internal void ConstructSourceStarJumpTypeInitialization()
        {
            if (sourceStarClimbGraphics != null)
                throw new InvalidOperationException(
                    "The actual StarJump type initialization descriptor is already constructed.");
            sourceStarClimbGraphics = new SourceTypeInitialization<StarClimbGraphicsProcessState>(
                "Celeste.Mod.Entities.StarClimbGraphicsController",
                new StarJumpSourceTypeInitialization(SourceProfile));
        }

        private sealed class
            StarJumpSourceTypeInitialization : ISourceTypeInitializationFactory<StarClimbGraphicsProcessState>
        {
            private readonly GameProfile profile;
            public StarJumpSourceTypeInitialization(GameProfile profile) => this.profile = profile;

            public StarClimbGraphicsProcessState Allocate() => profile switch
            {
                GameProfile.Original => new StarClimbGraphicsProcessState(),
                GameProfile.InstalledEverest => new StarClimbGraphicsProcessState(),
                _ => throw new InvalidOperationException("A supported source profile is required.")
            };

            // Complete field initializers execute in the existing constructor; no later initializer body.
            public void Initialize(StarClimbGraphicsProcessState instance)
            {
            }
        }
    }
}

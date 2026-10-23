using System;
using Celeste.Simulation.Gameplay.Player.Runtime;
using Celeste.Everest.Runtime.Events.Player;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourcePlayerRuntimeEnvironment
    {
        private ISourcePlayerRuntimePolicy sourcePlayerRuntimePolicy;

        public ISourcePlayerRuntimePolicy PlayerRuntimePolicy => sourcePlayerRuntimePolicy ??
                                                                 throw new InvalidOperationException(
                                                                     "The selected actual player runtime policy is not constructed.");

        public void ConstructSourcePlayerRuntimePolicy()
        {
            if (sourcePlayerRuntimePolicy != null)
                throw new InvalidOperationException(
                    "The selected actual player runtime policy is already constructed.");
            sourcePlayerRuntimePolicy = SourceProfile == GameProfile.Original
                ? (ISourcePlayerRuntimePolicy)new OriginalPlayerRuntimePolicy()
                : new InstalledPlayerRuntimePolicy(this);
        }
    }
}

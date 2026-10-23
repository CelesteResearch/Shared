using Celeste.Everest.Runtime.Events.Player;
using Celeste.Game.Profiles;
using Celeste.Simulation.Gameplay.Player.Runtime;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourcePlayerStarFlyExitEnvironment
    {
        private ISourcePlayerStarFlyExitPolicy sourceStarFlyExitPolicy;

        public ISourcePlayerStarFlyExitPolicy StarFlyExitPolicy => sourceStarFlyExitPolicy ??=
            SourceProfile == GameProfile.Original
                ? (ISourcePlayerStarFlyExitPolicy)new OriginalPlayerStarFlyExitPolicy()
                : new InstalledPlayerStarFlyExitPolicy();
    }
}

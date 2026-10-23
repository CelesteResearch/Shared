using Celeste.Core.Scheduling;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : ISourceCoroutineUpdateEnvironment
    {
        public bool SourceUsesInstalledCoroutine => SourceProfile == GameProfile.InstalledEverest;
    }
}

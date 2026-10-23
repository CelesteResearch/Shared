using Celeste.Game.Presentation.Particles;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalDustBurstEnvironment
    {
        OriginalDustBurstRuntimeProfile IOriginalDustBurstEnvironment.DustBurstProfile =>
            SourceProfile == GameProfile.Original
                ? OriginalDustBurstRuntimeProfile.Original
                : OriginalDustBurstRuntimeProfile.Installed;
    }
}

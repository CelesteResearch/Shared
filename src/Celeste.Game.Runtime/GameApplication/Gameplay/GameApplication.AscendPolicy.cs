using Celeste.Game.Entities.Ascension;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalAscendPolicyEnvironment
    {
        private readonly IOriginalAscendPolicy ascendPolicy;

        IOriginalAscendPolicy IOriginalAscendPolicyEnvironment.AscendPolicy => ascendPolicy;

        private IOriginalAscendPolicy CreateAscendPolicy()
        {
            return SourceProfile == GameProfile.Original
                ? new OriginalAscendPolicy()
                : new EverestAscendPolicy(this);
        }
    }
}

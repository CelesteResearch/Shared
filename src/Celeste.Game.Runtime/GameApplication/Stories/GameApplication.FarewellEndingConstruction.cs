using Celeste.Everest.Stories.Farewell.Ending;
using Celeste.Game.Profiles;
using Celeste.Game.Stories.Farewell.Ending;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFarewellEndingConstructionEnvironment
    {
        IOriginalFarewellEndingConstructionPolicy IOriginalFarewellEndingConstructionEnvironment.
            FarewellEndingConstruction
            => SourceProfile == GameProfile.Original
                ? OriginalFarewellEndingConstructionPolicy.Instance
                : EverestFarewellEndingConstructionPolicy.Instance;
    }
}

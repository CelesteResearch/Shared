using Celeste.Everest.Entities.Npcs.Granny;
using Celeste.Game.Entities.Npcs.Granny;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalGrannyEndingConstructionEnvironment
    {
        IOriginalGrannyEndingConstructionPolicy IOriginalGrannyEndingConstructionEnvironment.GrannyEndingConstruction
            => SourceProfile == GameProfile.Original
                ? OriginalGrannyEndingConstructionPolicy.Instance
                : EverestGrannyEndingConstructionPolicy.Instance;
    }
}

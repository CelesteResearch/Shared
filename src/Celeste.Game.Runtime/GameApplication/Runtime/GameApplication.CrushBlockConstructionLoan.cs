using Celeste.Everest.Gameplay.Platforms.CrushBlocks;
using Celeste.Game.Gameplay.Platforms.CrushBlocks;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalCrushBlockConstructionEnvironment
    {
        public IOriginalCrushBlockConstructionPolicy
            CrushBlockConstruction => SourceProfile == Profile.Original
            ? OriginalCrushBlockConstructionPolicy.Instance
            : EverestCrushBlockConstructionPolicy.Instance;
    }
}

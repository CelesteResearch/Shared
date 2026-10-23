using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : global::Celeste.Game.Gameplay.Platforms.CrushBlocks.
        IOriginalCrushBlockConstructionEnvironment
    {
        public global::Celeste.Game.Gameplay.Platforms.CrushBlocks.IOriginalCrushBlockConstructionPolicy
            CrushBlockConstruction => SourceProfile == Profile.Original
            ? global::Celeste.Game.Gameplay.Platforms.CrushBlocks.OriginalCrushBlockConstructionPolicy.Instance
            : global::Celeste.Everest.Gameplay.Platforms.CrushBlocks.EverestCrushBlockConstructionPolicy.Instance;
    }
}

using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : global::Celeste.Game.Gameplay.Platforms.IntroCrusher.
        IOriginalIntroCrusherConstructionEnvironment
    {
        public global::Celeste.Game.Gameplay.Platforms.IntroCrusher.IOriginalIntroCrusherConstructionPolicy
            IntroCrusherConstruction => SourceProfile == Profile.Original
            ? global::Celeste.Game.Gameplay.Platforms.IntroCrusher.OriginalIntroCrusherConstructionPolicy.Instance
            : global::Celeste.Everest.Gameplay.Platforms.IntroCrusher.EverestIntroCrusherConstructionPolicy.Instance;
    }
}

using Celeste.Everest.Gameplay.Platforms.IntroCrusher;
using Celeste.Game.Gameplay.Platforms.IntroCrusher;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalIntroCrusherConstructionEnvironment
    {
        public IOriginalIntroCrusherConstructionPolicy
            IntroCrusherConstruction => SourceProfile == Profile.Original
            ? OriginalIntroCrusherConstructionPolicy.Instance
            : EverestIntroCrusherConstructionPolicy.Instance;
    }
}

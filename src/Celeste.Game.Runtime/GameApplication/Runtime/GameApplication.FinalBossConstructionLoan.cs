using Celeste.Everest.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFinalBossEnvironment
    {
        private IOriginalFinalBossFactory
            sourceFinalBosses;

        public IOriginalFinalBossFactory
            FinalBosses => sourceFinalBosses ??=
            SourceProfile == Profile.Original
                ? new OriginalFinalBossFactory(this)
                : new EverestFinalBossFactory(this);
    }
}

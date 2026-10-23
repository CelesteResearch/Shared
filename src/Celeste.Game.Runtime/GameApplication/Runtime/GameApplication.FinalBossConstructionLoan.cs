using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction.
        IOriginalFinalBossEnvironment
    {
        private global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction.IOriginalFinalBossFactory
            sourceFinalBosses;

        public global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction.IOriginalFinalBossFactory
            FinalBosses => sourceFinalBosses ??=
            SourceProfile == Profile.Original
                ? new global::Celeste.Game.Gameplay.Enemies.BadelineBoss.Construction.OriginalFinalBossFactory(this)
                : new global::Celeste.Everest.Gameplay.Enemies.BadelineBoss.EverestFinalBossFactory(this);
    }
}

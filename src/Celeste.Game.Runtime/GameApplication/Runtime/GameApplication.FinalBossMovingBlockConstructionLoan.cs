using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
        IOriginalFinalBossMovingBlockConstructionEnvironment
    {
        private global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
            IOriginalFinalBossMovingBlockConstruction sourceFinalBossMovingBlockConstruction;

        public global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
            IOriginalFinalBossMovingBlockConstruction FinalBossMovingBlockConstruction =>
            sourceFinalBossMovingBlockConstruction ??=
                SourceProfile == Profile.Original
                    ? new global::Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock.
                        OriginalFinalBossMovingBlockConstruction()
                    : new global::Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock.
                        EverestFinalBossMovingBlockConstruction();
    }
}

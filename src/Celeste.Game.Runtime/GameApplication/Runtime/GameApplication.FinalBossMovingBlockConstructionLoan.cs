using Celeste.Everest.Gameplay.Platforms.FinalBossMovingBlock;
using Celeste.Game.Gameplay.Platforms.FinalBossMovingBlock;
using Profile = Celeste.Game.Profiles.GameProfile;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalFinalBossMovingBlockConstructionEnvironment
    {
        private IOriginalFinalBossMovingBlockConstruction sourceFinalBossMovingBlockConstruction;

        public IOriginalFinalBossMovingBlockConstruction FinalBossMovingBlockConstruction =>
            sourceFinalBossMovingBlockConstruction ??=
                SourceProfile == Profile.Original
                    ? new OriginalFinalBossMovingBlockConstruction()
                    : new EverestFinalBossMovingBlockConstruction();
    }
}

using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;
using Celeste.Simulation;

namespace Celeste.Everest.Gameplay.Enemies.BadelineBoss
{
    public sealed class EverestFinalBossProgressionPolicy : OriginalFinalBossProgressionPolicy
    {
        private readonly ISourceEngineContext engine;

        public EverestFinalBossProgressionPolicy(ISourceEngineContext engine)
        {
            this.engine = engine;
        }

        public override void PushPlayer(FinalBossState boss, RoomPlayerSession player)
        {
            if (boss.NodeIndex >= boss.Nodes.Length)
            {
                ((IEverestLoggerProcessEnvironment)engine).Logger.Log(
                    EverestLogLevel.Warn, "FinalBoss",
                    "FinalBoss entity was hit on its last node, please add an additional node outside of the current room to ensure the player never hits it.");
                ((IOriginalLevelEnterStaticEnvironment)engine).LevelEnterStatics
                    .ErrorMessage =
                    ((IOriginalGameTextEnvironment)engine).Text.Dialog.Get(
                        "postcard_bosslastnodehit");
            }
            else
            {
                base.PushPlayer(boss, player);
            }
        }

        public override bool CanChangeMusic(FinalBossState boss, bool value)
        {
            return boss.Level.AreaData.LevelSet == "Celeste" ? value : boss.CanChangeMusicSetting;
        }

        public override void ApplyMapAttributes(FinalBossState boss, EntityData data)
        {
            boss.CanChangeMusicSetting = EntityAttributeReader.Bool(data.Values, "canChangeMusic", true);
        }
    }
}

using Celeste.Game.Gameplay.Enemies.BadelineBoss;
using Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Everest.Gameplay.Enemies.BadelineBoss
{
    public sealed class EverestFinalBossProgressionPolicy : OriginalFinalBossProgressionPolicy
    {
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        public EverestFinalBossProgressionPolicy(global::Celeste.Core.Scheduling.ISourceEngineContext engine)
            => this.engine = engine;

        public override void PushPlayer(FinalBossState boss, global::Celeste.Simulation.RoomPlayerSession player)
        {
            if (boss.NodeIndex >= boss.Nodes.Length)
            {
                ((global::Celeste.Everest.Diagnostics.Logging.IEverestLoggerProcessEnvironment)engine).Logger.Log(
                    global::Celeste.Everest.EverestLogLevel.Warn, "FinalBoss",
                    "FinalBoss entity was hit on its last node, please add an additional node outside of the current room to ensure the player never hits it.");
                ((global::Celeste.Game.Chapters.Flow.IOriginalLevelEnterStaticEnvironment)engine).LevelEnterStatics
                    .ErrorMessage =
                    ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text.Dialog.Get(
                        "postcard_bosslastnodehit");
            }
            else base.PushPlayer(boss, player);
        }

        public override bool CanChangeMusic(FinalBossState boss, bool value)
            => boss.Level.AreaData.LevelSet == "Celeste" ? value : boss.CanChangeMusicSetting;

        public override void ApplyMapAttributes(FinalBossState boss, EntityData data)
        {
            boss.CanChangeMusicSetting = EntityAttributeReader.Bool(data.Values, "canChangeMusic", true);
        }
    }
}

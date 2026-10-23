using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression
{
    public abstract class FinalBossProgressionPolicy
    {
        public abstract FinalBossEntranceKind Choose(OriginalLevelSceneRoot level, int patternIndex);
        public abstract bool CanChangeMusic(FinalBossState boss, bool value);
        public abstract void PushPlayer(FinalBossState boss, RoomPlayerSession player);
        public abstract void ApplyIntroAudio(FinalBossState boss);
        public abstract void AfterHit(FinalBossState boss, bool last);

        public virtual void ApplyMapAttributes(FinalBossState boss,
            EntityData data)
        {
        }
    }
}

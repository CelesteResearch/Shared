using Celeste.Game.Execution.Levels;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss.Progression
{
    public class OriginalFinalBossProgressionPolicy : FinalBossProgressionPolicy
    {
        public override FinalBossEntranceKind Choose(OriginalLevelSceneRoot level,
            int patternIndex)
        {
            if (patternIndex == 0 && !level.Session.GetFlag("boss_intro") && level.Session.Level == "boss-00")
                return FinalBossEntranceKind.Intro;
            if (patternIndex == 0 && !level.Session.GetFlag("boss_mid") && level.Session.Level == "boss-14")
                return FinalBossEntranceKind.Mid;
            return FinalBossEntranceKind.None;
        }

        public override bool CanChangeMusic(FinalBossState boss, bool value)
        {
            return value;
        }

        public override void PushPlayer(FinalBossState boss, RoomPlayerSession player)
        {
            boss.PushPlayerOriginal(player);
        }

        public override void ApplyIntroAudio(FinalBossState boss)
        {
            boss.Level.Session.Audio.Music.Event = "event:/music/lvl2/phone_loop";
            boss.ApplySessionAudio();
        }

        public override void AfterHit(FinalBossState boss, bool last)
        {
            var level = boss.Level;
            if (boss.CanChangeMusic(level.Session.Mode == 0))
            {
                if (last && level.Session.Level == "boss-19")
                {
                    boss.SchedulePostBossBurst();
                    boss.SetAmbienceParam("postboss", 1f);
                    boss.SetMusic(null);
                }
                else if (boss.StartHit && level.Session.Audio.Music.Event != "event:/music/lvl6/badeline_glitch")
                {
                    level.Session.Audio.Music.Event = "event:/music/lvl6/badeline_glitch";
                    boss.ApplySessionAudio();
                }
                else if (level.Session.Audio.Music.Event != "event:/music/lvl6/badeline_fight" &&
                         level.Session.Audio.Music.Event != "event:/music/lvl6/badeline_glitch")
                {
                    level.Session.Audio.Music.Event = "event:/music/lvl6/badeline_fight";
                    boss.ApplySessionAudio();
                }
            }
        }
    }
}

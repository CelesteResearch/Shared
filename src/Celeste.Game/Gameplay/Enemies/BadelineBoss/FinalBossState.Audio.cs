using Celeste.Game.Audio;
using Celeste.Game.Entities.Hazards.Spinners.Crystal;

namespace Celeste.Game.Gameplay.Enemies.BadelineBoss
{
    public partial class FinalBossState
    {
        public void ApplySessionAudio()
        {
            OriginalAudioSession.Apply(Level.Session.Audio, Process.AudioSession.ChannelOutput,
                Process.AudioApplyPolicy);
        }

        public void SetMusic(string name)
        {
            Process.AudioSession.ChannelOutput.SetMusic(name);
        }

        public void SetAmbienceParam(string name, float value)
        {
            Process.AudioSession.ChannelOutput.SetAmbienceParam(name, value);
        }

        public void SchedulePostBossBurst()
        {
            AddAlarm(.25f, () =>
            {
                Process.AudioSession.Play("event:/game/06_reflection/boss_spikes_burst");
                foreach (OriginalCrystalStaticSpinner spinner in Level.SourceScene.Entities.GetTrackedEntities(
                             "Celeste.CrystalStaticSpinner"))
                    spinner.Destroy(true);
            });
        }
    }
}

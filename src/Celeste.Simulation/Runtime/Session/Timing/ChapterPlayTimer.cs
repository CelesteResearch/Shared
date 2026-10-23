using Celeste.Core.Timing;
using Celeste.Simulation.Save.Progress;

namespace Celeste.Simulation.Runtime.Session.Timing
{
    public sealed class ChapterPlayTimer
    {
        public readonly ChapterProgress Progress;
        public readonly ChapterCompletionSession Session;
        public bool TimerStarted, TimerStopped, TimerHidden;

        public ChapterPlayTimer(ChapterProgress progress,
            ChapterCompletionSession session)
        {
            Progress = progress;
            Session = session;
        }

        public static bool PlayerTimePaused(bool dead, int state)
        {
            return dead || state == 10 || (uint)(state - 12) <= 3u || state == 25;
        }

        // Called by Level.UpdateTime, before entity updates, including pause,
        // retry corpse and transitions. Engine freeze/overlay skip this call;
        // DashAssist's special Engine branch explicitly calls it once.
        public void Step(float rawDeltaTime, bool playerPresent, bool playerDead, int playerState,
            bool inCutscene, bool completed, bool inCredits)
        {
            if (inCredits || Session.AreaID == 8 || TimerStopped) return;
            var ticks = TimeQuantization.SecondsToMillisecondTicks(rawDeltaTime);
            Progress.AddTime(Session.AreaID, Session.Mode, ticks);
            if (!TimerStarted && !inCutscene && playerPresent && !PlayerTimePaused(playerDead, playerState))
                TimerStarted = true;
            if (!completed && TimerStarted) Session.Time += ticks;
        }

        public void LoadLevel()
        {
            TimerHidden = false;
            TimerStopped = false;
        }

        // Only the bookkeeping prefix of Level.Reload. The host continues
        // with effects, UnloadLevel and LoadLevel in their original order.
        public void Reload(bool completed)
        {
            if (completed) return;
            if (Session.FirstLevel && Session.Strawberries.Count <= 0 && !Session.Cassette &&
                !Session.HeartGem && !Session.HitCheckpoint)
            {
                Session.Time = 0;
                Session.Deaths = 0;
                TimerStarted = false;
            }

            Session.Dashes = Session.DashesAtLevelStart;
        }
    }
}

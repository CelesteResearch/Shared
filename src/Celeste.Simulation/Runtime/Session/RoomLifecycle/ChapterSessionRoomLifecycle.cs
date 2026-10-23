using System;
using System.Numerics;
using Celeste.Simulation;

namespace Celeste.Simulation.Runtime.Session.RoomLifecycle
{
    // Level.TransitionRoutine changes the session's room before LoadLevel.
    // LoadLevel records the visit only after its player intro is known.
    public static class ChapterSessionRoomLifecycle
    {
        public static void ChangeRoom(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
            string level,
            bool transition)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.Level = level ?? throw new ArgumentNullException(nameof(level));
            if (transition)
            {
                session.FirstLevel = false;
                session.DeathsInCurrentLevel = 0;
            }
        }

        public static void MarkLoaded(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
            global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType intro)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            if (!PlayerIntroSelection.CountsAsVisit(intro, session.Level)) return;
            if (!session.LevelFlags.Contains(session.Level))
                session.FurthestSeenLevel = session.Level;
            session.LevelFlags.Add(session.Level);
            session.UpdateLevelStartDashes();
        }

        // ChangeRespawnTrigger invokes this only after its own SolidCheck and
        // changed-target test; cassette/spawn-point assignment has different semantics.
        public static void RecordCheckpoint(global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
            Vector2 point)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.HitCheckpoint = true;
            session.RespawnPoint = point;
            session.UpdateLevelStartDashes();
        }

        public static void RecordTransitionSpawn(
            global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session, Vector2 point)
        {
            if (session == null) throw new ArgumentNullException(nameof(session));
            session.RespawnPoint = point;
            session.UpdateLevelStartDashes();
        }
    }
}

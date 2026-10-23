using System;
using System.Collections;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation
{
    public static class PlayerIntroSelection
    {
        public static global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType AreaDefault(int area)
        {
            switch (area)
            {
                case 0:
                case 3:
                case 4:
                case 9: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WalkInRight;
                case 1: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.Jump;
                case 2:
                case 5: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WakeUp;
                case 6:
                case 7: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.None;
                case 8: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WalkInLeft;
                case 10: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.ThinkForABit;
                // Everest initializes newly registered mod areas to WakeUp.
                default: return global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WakeUp;
            }
        }

        // THE ONE IMPLEMENTATION OF THE ENTRY-INTRO DECISION, and now the one that also EXPLAINS itself.
        //
        // `Select` worked; two things around it did not:
        //   * `RoomPresentation.cs:207` did not CALL it on the ordinary first load -- it required a
        //     non-null `incomingChapterSession`, which only a room transition supplies -- so the port's
        //     first load chose `None` where the original chooses the area's `IntroType`, `Jump` for area 1
        //     (`AreaData.cs:177`). That is the missing 88-frame `StIntroJump` of FINDING.md SSNQ/SSNR;
        //   * the C-side branch below was INVERTED. The original tests `session.Area.Mode != AreaMode.CSide`
        //     (`LevelLoader.cs:308`) and so takes the AREA DEFAULT in every mode except C-side; written as
        //     `Mode == 2` it returned the area default only FOR C-side, which is the opposite.
        //
        // And the reason this is now a pair of values rather than one: `ChapterSession.JustStarted` is
        // cleared inside the SAME rebuild that consumes it (`RoomPresentation.cs:524`, `if (initialLoad)`),
        // so by the time anything outside that rebuild can look, the input that decided the intro is gone.
        // A decision whose inputs are destroyed immediately cannot be audited after the fact -- so
        // `SelectExplained` returns the choice AND the tuple that produced it, and the caller records the
        // tuple. One implementation, and it cannot drift from its own explanation.
        public static global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType Select(
            global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
            global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? explicitIntro = null,
            global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? areaDefault = null,
            global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? cSideOverride = null)
            => SelectExplained(session, explicitIntro, areaDefault, cSideOverride).Intro;

        public static (global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType Intro, string Reason)
            SelectExplained(
                global::Celeste.Simulation.Runtime.Session.ChapterCompletionSession session,
                global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? explicitIntro = null,
                global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? areaDefault = null,
                global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType? cSideOverride = null)
        {
            if (explicitIntro.HasValue)
                return (explicitIntro.Value, "explicit override -> " + explicitIntro.Value);
            if (session == null)
                return (global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.None, "no session -> None");
            // LevelLoader.cs:308, term for term.
            bool firstLoad = session.FirstLevel && session.StartedFromBeginning && session.JustStarted;
            bool cSide = session.Mode == 2;
            var intro = !firstLoad ? global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.Respawn
                : cSide ? cSideOverride ?? global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.WalkInRight
                : areaDefault ?? AreaDefault(session.AreaID);
            return (intro, "area=" + session.AreaID + " mode=" + session.Mode
                           + " firstLevel=" + session.FirstLevel + " startedFromBeginning=" +
                           session.StartedFromBeginning
                           + " justStarted=" + session.JustStarted
                           + " -> firstLoad=" + firstLoad + " cSide=" + cSide + " -> " + intro);
        }

        public static bool CountsAsVisit(global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType intro,
            string level) =>
            intro != global::Celeste.Simulation.Gameplay.Player.Intro.PlayerIntroType.Fall || level == "0";
    }
}

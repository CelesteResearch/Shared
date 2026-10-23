using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Simulation
{
    public static class PlayerIntroSelection
    {
        public static PlayerIntroType AreaDefault(int area)
        {
            switch (area)
            {
                case 0:
                case 3:
                case 4:
                case 9: return PlayerIntroType.WalkInRight;
                case 1: return PlayerIntroType.Jump;
                case 2:
                case 5: return PlayerIntroType.WakeUp;
                case 6:
                case 7: return PlayerIntroType.None;
                case 8: return PlayerIntroType.WalkInLeft;
                case 10: return PlayerIntroType.ThinkForABit;
                // Everest initializes newly registered mod areas to WakeUp.
                default: return PlayerIntroType.WakeUp;
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
        public static PlayerIntroType Select(
            ChapterCompletionSession session,
            PlayerIntroType? explicitIntro = null,
            PlayerIntroType? areaDefault = null,
            PlayerIntroType? cSideOverride = null)
        {
            return SelectExplained(session, explicitIntro, areaDefault, cSideOverride).Intro;
        }

        public static (PlayerIntroType Intro, string Reason)
            SelectExplained(
                ChapterCompletionSession session,
                PlayerIntroType? explicitIntro = null,
                PlayerIntroType? areaDefault = null,
                PlayerIntroType? cSideOverride = null)
        {
            if (explicitIntro.HasValue)
                return (explicitIntro.Value, "explicit override -> " + explicitIntro.Value);
            if (session == null)
                return (PlayerIntroType.None, "no session -> None");
            // LevelLoader.cs:308, term for term.
            var firstLoad = session.FirstLevel && session.StartedFromBeginning && session.JustStarted;
            var cSide = session.Mode == 2;
            var intro = !firstLoad ? PlayerIntroType.Respawn
                : cSide ? cSideOverride ?? PlayerIntroType.WalkInRight
                : areaDefault ?? AreaDefault(session.AreaID);
            return (intro, "area=" + session.AreaID + " mode=" + session.Mode
                           + " firstLevel=" + session.FirstLevel + " startedFromBeginning=" +
                           session.StartedFromBeginning
                           + " justStarted=" + session.JustStarted
                           + " -> firstLoad=" + firstLoad + " cSide=" + cSide + " -> " + intro);
        }

        public static bool CountsAsVisit(PlayerIntroType intro,
            string level)
        {
            return intro != PlayerIntroType.Fall || level == "0";
        }
    }
}

using Celeste.Simulation.Gameplay.Player.Intro;

namespace Celeste.Game.Execution.Areas
{
    public static class OriginalAreaIntroDefaults
    {
        public static PlayerIntroType Get(int vanillaAreaId)
        {
            return vanillaAreaId switch
            {
                0 => PlayerIntroType.WalkInRight,
                1 => PlayerIntroType.Jump,
                2 => PlayerIntroType.WakeUp,
                3 => PlayerIntroType.WalkInRight,
                4 => PlayerIntroType.WalkInRight,
                5 => PlayerIntroType.WakeUp,
                6 => PlayerIntroType.None,
                7 => PlayerIntroType.None,
                8 => PlayerIntroType.WalkInLeft,
                9 => PlayerIntroType.WalkInRight,
                10 => PlayerIntroType.ThinkForABit,
                _ => PlayerIntroType.Transition,
            };
        }
    }
}

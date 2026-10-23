using System;
using System.Numerics;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Chapters.Flow
{
    public static class LevelCompleteAreaSequence
    {
        public static ScreenWipePresentation Complete(
            ILevelCompleteAreaWorld world,
            bool spotlightWipe = true, bool skipScreenWipe = false, bool skipCompleteScreen = false)
        {
            world.RegisterAreaComplete();
            world.PauseLock = true;
            var interlude = world.Interlude || skipCompleteScreen;
            var exit = interlude
                ? (Action)(() =>
                    world.RequestExit(LevelExitMode.CompletedInterlude,
                        true))
                : () => world.RequestExit(LevelExitMode.Completed, false);
            if (!world.SkippingCutscene && !skipScreenWipe)
            {
                if (spotlightWipe)
                {
                    var player = world.FirstPlayerPosition;
                    if (player.HasValue) world.SpotlightFocus = player.Value - world.CameraPosition - new Vector2(0, 8);
                    return world.AddSpotlightOut(exit);
                }

                return world.AddFadeOut(exit);
            }

            world.StopGameplaySoundsImmediately();
            exit();
            return null;
        }
    }
}

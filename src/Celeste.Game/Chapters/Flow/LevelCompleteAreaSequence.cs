#nullable disable
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Chapters.Flow
{
    public static class LevelCompleteAreaSequence
    {
        public static global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation Complete(
            global::Celeste.Game.Chapters.Flow.ILevelCompleteAreaWorld world,
            bool spotlightWipe = true, bool skipScreenWipe = false, bool skipCompleteScreen = false)
        {
            world.RegisterAreaComplete();
            world.PauseLock = true;
            bool interlude = world.Interlude || skipCompleteScreen;
            Action exit = interlude
                ? (Action)(() =>
                    world.RequestExit(global::Celeste.Game.Chapters.Flow.LevelExitMode.CompletedInterlude,
                        true))
                : () => world.RequestExit(global::Celeste.Game.Chapters.Flow.LevelExitMode.Completed, false);
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

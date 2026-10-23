#nullable disable
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Game.Chapters.Flow
{
    public interface ILevelCompleteAreaWorld
    {
        void RegisterAreaComplete();
        bool PauseLock { set; }
        bool Interlude { get; }
        bool SkippingCutscene { get; }
        Vector2? FirstPlayerPosition { get; }
        Vector2 CameraPosition { get; }
        Vector2 SpotlightFocus { get; set; }

        global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation AddSpotlightOut(
            Action complete);

        global::Celeste.Simulation.Presentation.Scene.Transitions.ScreenWipePresentation AddFadeOut(Action complete);

        void StopGameplaySoundsImmediately();

        // Assign the next scene request only. Do not destroy this scene from
        // inside a renderer or entity update. Engine commits after AfterUpdate.
        void RequestExit(global::Celeste.Game.Chapters.Flow.LevelExitMode mode, bool inheritLevelSnow);
    }
}

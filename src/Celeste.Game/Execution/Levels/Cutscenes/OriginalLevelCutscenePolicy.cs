using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Mixing;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Presentation.Hud.Statistics;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Simulation.Presentation.Scene.Transitions;

namespace Celeste.Game.Execution.Levels.Cutscenes
{
    public sealed class OriginalLevelCutscenePolicy
    {
        public readonly OriginalLevelCutsceneState State;

        public OriginalLevelCutscenePolicy(OriginalLevelCutsceneState state)
        {
            State = state ?? throw new ArgumentNullException(nameof(state));
        }

        public void StartCutscene(Action<OriginalLevelSceneRoot> onSkip, bool fadeInOnSkip = true,
            bool endingChapterAfterCutscene = false, bool resetZoomOnSkip = true)
        {
            State.EndingChapterAfterCutscene = endingChapterAfterCutscene;
            State.InCutscene = true;
            State.OnCutsceneSkip = onSkip;
            State.OnCutsceneSkipFadeIn = fadeInOnSkip;
            State.OnCutsceneSkipResetZoom = resetZoomOnSkip;
        }

        public void CancelCutscene()
        {
            State.InCutscene = false;
            State.SkippingCutscene = false;
        }

        public void SkipCutscene()
        {
            State.SkippingCutscene = true;
            State.Level.EngineContext.Effects.TimeRate = 1f;
            State.Level.EngineContext.Effects.Anxiety = 0f;
            State.Level.EngineContext.Effects.GameRate = 1f;
            if (State.EndingChapterAfterCutscene)
                OriginalAudioBusPolicy.StopGameplaySfx(
                    ((IOriginalGameplayProcess)State.Level.EngineContext)
                    .AudioSession.Runtime, true);
            var list = new List<TextboxState>();
            foreach (var entity in State.Level.Scheduler.Entities.GetTrackedEntities("Celeste.Textbox"))
                list.Add((TextboxState)entity);
            foreach (var item in list)
                item.RemoveSelf();
            var skipCoroutine = new SimulationCoroutine(State.Level.EngineContext, SkipCutsceneRoutine());
            State.SkipCoroutine = skipCoroutine;
        }

        private IEnumerator SkipCutsceneRoutine()
        {
            var fadeWipe = new FadeWipePresentation(State.Level, false);
            fadeWipe.Duration = .25f;
            yield return fadeWipe.Wait();
            State.OnCutsceneSkip(State.Level);
            State.Level.SourceStrawberriesDisplay.DrawLerp = 0f;
            if (State.OnCutsceneSkipResetZoom)
                State.Level.ResetZoom();
            var gameplayStats = State.Level.Scheduler.Entities.FindFirst<GameplayStatsState>();
            if (gameplayStats != null)
                gameplayStats.DrawLerp = 0f;
            if (State.OnCutsceneSkipFadeIn)
            {
                var fadeWipeIn = new FadeWipePresentation(State.Level, true);
                fadeWipeIn.Duration = .25f;
                State.Level.Renderers.UpdateLists();
                yield return fadeWipeIn.Wait();
            }

            State.SkippingCutscene = false;
            EndCutscene();
        }

        public void EndCutscene()
        {
            if (!State.SkippingCutscene)
                State.InCutscene = false;
        }
    }
}

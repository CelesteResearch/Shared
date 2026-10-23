using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Entities.Birds.Fling
{
    public class OriginalMoonGlitchBackgroundTriggerState : SourceTriggerEntityState
    {
        private enum Duration
        {
            Short,
            Medium,
            Long,
        }

        private readonly Duration duration;

        private bool triggered;

        private readonly bool stayOn;

        private bool running;

        private readonly bool doGlitch;

        private readonly ISourceEngineContext engine;

        public OriginalMoonGlitchBackgroundTriggerState(ISourceEngineContext engine, EntityData data,
            Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            this.engine = engine;
            duration = EntityAttributeReader.Enum(data.Values, "duration", Duration.Short);
            stayOn = EntityAttributeReader.Bool(data.Values, "stay");
            doGlitch = EntityAttributeReader.Bool(data.Values, "glitch", true);
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            Invoke();
        }

        public void Invoke()
        {
            if (!!triggered)
                return;
            triggered = true;
            if (doGlitch)
                OwnedComponents.Add(new SimulationCoroutine(engine, InternalGlitchRoutine()));
            else if (!stayOn) Toggle(engine, false);
        }

        private IEnumerator InternalGlitchRoutine()
        {
            running = true;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.Persistent.Value;
            float num;
            if (duration == Duration.Short)
            {
                num = 0.2f;
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
                ((IOriginalGameplayProcess)engine).AudioSession.Play(
                    "event:/new_content/game/10_farewell/glitch_short");
            }
            else if (duration == Duration.Medium)
            {
                num = 0.5f;
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
                ((IOriginalGameplayProcess)engine).AudioSession.Play(
                    "event:/new_content/game/10_farewell/glitch_medium");
            }
            else
            {
                num = 1.25f;
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/glitch_long");
            }

            yield return GlitchRoutine(engine, num, stayOn);
            Tags = 0;
            running = false;
        }

        private static void Toggle(ISourceEngineContext engine, bool on)
        {
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
            foreach (var item in level.Background.GetEach<BackdropPresentation>("blackhole")) item.ForceVisible = on;

            foreach (var item2 in level.Foreground.GetEach<BackdropPresentation>("blackhole")) item2.ForceVisible = on;
        }

        private static void Fade(ISourceEngineContext engine, float alpha, bool max = false)
        {
            var level = engine.Frame.Scenes.CurrentScene as OriginalLevelSceneRoot;
            foreach (var item in level.Background.GetEach<BackdropPresentation>("blackhole"))
                item.FadeAlphaMultiplier =
                    max
                        ? ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(item.FadeAlphaMultiplier, alpha)
                        : alpha;

            foreach (var item2 in level.Foreground.GetEach<BackdropPresentation>("blackhole"))
                item2.FadeAlphaMultiplier =
                    max
                        ? ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(item2.FadeAlphaMultiplier, alpha)
                        : alpha;
        }

        public static IEnumerator GlitchRoutine(ISourceEngineContext engine, float duration, bool stayOn)
        {
            Toggle(engine, true);
            if (((ISettingsContext)engine).Settings.DisableFlashes)
            {
                for (var a = 0f; a < 1f; a += engine.DeltaTime / 0.1f)
                {
                    Fade(engine, a, true);
                    yield return null;
                }

                Fade(engine, 1f);
                yield return duration;
                if (!stayOn)
                {
                    for (var a = 0f; a < 1f; a += engine.DeltaTime / 0.1f)
                    {
                        Fade(engine, 1f - a);
                        yield return null;
                    }

                    Fade(engine, 1f);
                }
            }
            else if (duration > 0.4f)
            {
                engine.Effects.Glitch = 0.3f;
                yield return 0.2f;
                engine.Effects.Glitch = 0f;
                yield return duration - 0.4f;
                if (!stayOn) engine.Effects.Glitch = 0.3f;

                yield return 0.2f;
                engine.Effects.Glitch = 0f;
            }
            else
            {
                engine.Effects.Glitch = 0.3f;
                yield return duration;
                engine.Effects.Glitch = 0f;
            }

            if (!stayOn) Toggle(engine, false);
        }

        public override void Removed(object scene)
        {
            if (running)
            {
                engine.Effects.Glitch = 0f;
                Fade(engine, 1f);
                if (!stayOn) Toggle(engine, false);
            }

            base.Removed(scene);
        }
    }
}

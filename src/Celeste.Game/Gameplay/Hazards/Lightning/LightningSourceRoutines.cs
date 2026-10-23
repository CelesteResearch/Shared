using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Mathematics;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Game.Entities.Birds.Fling;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public static class LightningSourceRoutines
    {
        public static IEnumerator PulseRoutine(OriginalLevelSceneRoot level)
        {
            for (float t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 8f)
            {
                SetPulseValue(level, t);
                yield return null;
            }

            for (float t = 1f; t > 0f; t -= level.EngineContext.DeltaTime * 8f)
            {
                SetPulseValue(level, t);
                yield return null;
            }

            SetPulseValue(level, 0f);
        }

        private static void SetPulseValue(OriginalLevelSceneRoot level, float t)
        {
            var bloom = level.Bloom;
            LightningRendererState entity =
                level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer");
            level.Glitch.Value =
                ScalarMath.Lerp(0f, 0.075f, t, ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            bloom.Strength = ScalarMath.Lerp(1f, 1.2f, t,
                ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            entity.Fade = t * 0.2f;
        }

        private static void SetBreakValue(OriginalLevelSceneRoot level, float t)
        {
            var bloom = level.Bloom;
            LightningRendererState entity =
                level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer");
            level.Glitch.Value =
                ScalarMath.Lerp(0f, 0.15f, t, ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            bloom.Strength = ScalarMath.Lerp(1f, 1.5f, t,
                ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            entity.Fade = t * 0.6f;
        }

        public static IEnumerator RemoveRoutine(OriginalLevelSceneRoot level, Action onComplete = null)
        {
            List<LightningState> blocks = level.SourceScene.Entities.FindAll<LightningState>();
            foreach (LightningState item in new List<LightningState>(blocks))
            {
                item.Disappearing = true;
                if (item.Right < level.Camera.Position.X || item.Bottom < level.Camera.Position.Y ||
                    item.Left > (level.Camera.Position.X + 320f) || item.Top > (level.Camera.Position.Y + 180f))
                {
                    blocks.Remove(item);
                    item.RemoveSelf();
                }
            }

            LightningRendererState entity =
                level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer");
            entity.StopAmbience();
            entity.UpdateSeeds = false;
            for (float t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 4f)
            {
                SetBreakValue(level, t);
                yield return null;
            }

            SetBreakValue(level, 1f);
            level.Shake();
            for (int num = blocks.Count - 1; num >= 0; num--)
            {
                blocks[num].Shatter();
            }

            for (float t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 8f)
            {
                SetBreakValue(level, 1f - t);
                yield return null;
            }

            SetBreakValue(level, 0f);
            foreach (LightningState item2 in blocks)
            {
                item2.RemoveSelf();
            }

            OriginalFlingBirdState flingBird = level.SourceScene.Entities.FindFirst<OriginalFlingBirdState>();
            if (flingBird != null)
            {
                flingBird.LightningRemoved = true;
            }

            onComplete?.Invoke();
        }
    }
}

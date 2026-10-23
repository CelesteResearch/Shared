using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Mathematics;
using Celeste.Game.Entities.Birds.Fling;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Hazards.Lightning;

namespace Celeste.Game.Gameplay.Hazards.Lightning
{
    public static class LightningSourceRoutines
    {
        public static IEnumerator PulseRoutine(OriginalLevelSceneRoot level)
        {
            for (var t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 8f)
            {
                SetPulseValue(level, t);
                yield return null;
            }

            for (var t = 1f; t > 0f; t -= level.EngineContext.DeltaTime * 8f)
            {
                SetPulseValue(level, t);
                yield return null;
            }

            SetPulseValue(level, 0f);
        }

        private static void SetPulseValue(OriginalLevelSceneRoot level, float t)
        {
            var bloom = level.Bloom;
            var entity =
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
            var entity =
                level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer");
            level.Glitch.Value =
                ScalarMath.Lerp(0f, 0.15f, t, ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            bloom.Strength = ScalarMath.Lerp(1f, 1.5f, t,
                ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            entity.Fade = t * 0.6f;
        }

        public static IEnumerator RemoveRoutine(OriginalLevelSceneRoot level, Action onComplete = null)
        {
            var blocks = level.SourceScene.Entities.FindAll<LightningState>();
            foreach (var item in new List<LightningState>(blocks))
            {
                item.Disappearing = true;
                if (item.Right < level.Camera.Position.X || item.Bottom < level.Camera.Position.Y ||
                    item.Left > level.Camera.Position.X + 320f || item.Top > level.Camera.Position.Y + 180f)
                {
                    blocks.Remove(item);
                    item.RemoveSelf();
                }
            }

            var entity =
                level.SourceScene.Entities.GetTrackedEntity<LightningRendererState>("Celeste.LightningRenderer");
            entity.StopAmbience();
            entity.UpdateSeeds = false;
            for (var t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 4f)
            {
                SetBreakValue(level, t);
                yield return null;
            }

            SetBreakValue(level, 1f);
            level.Shake();
            for (var num = blocks.Count - 1; num >= 0; num--) blocks[num].Shatter();

            for (var t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 8f)
            {
                SetBreakValue(level, 1f - t);
                yield return null;
            }

            SetBreakValue(level, 0f);
            foreach (var item2 in blocks) item2.RemoveSelf();

            var flingBird = level.SourceScene.Entities.FindFirst<OriginalFlingBirdState>();
            if (flingBird != null) flingBird.LightningRemoved = true;

            onComplete?.Invoke();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using Celeste.Core.Mathematics;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Game.Entities.Birds.Fling;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Entities.Lightning
{
    public static class OriginalLightningSequence
    {
        private static void SetEngineGlitchValue(OriginalLevelSceneRoot level, float value) =>
            level.EngineContext.Effects.Glitch = value;

        private static LightningRendererState FirstRenderer(OriginalLevelSceneRoot level)
            => (LightningRendererState)level.SourceScene.Entities.GetTrackedEntities("Celeste.LightningRenderer")[0];

        private static void SetPulseValue(OriginalLevelSceneRoot level, float t)
        {
            var bloom = level.Bloom;
            var renderer = FirstRenderer(level);
            SetEngineGlitchValue(level,
                ScalarMath.Lerp(0f, .075f, t, ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic));
            bloom.Strength = ScalarMath.Lerp(1f, 1.2f, t,
                ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            renderer.Fade = t * .2f;
        }

        private static void SetBreakValue(OriginalLevelSceneRoot level, float t)
        {
            var bloom = level.Bloom;
            var renderer = FirstRenderer(level);
            SetEngineGlitchValue(level,
                ScalarMath.Lerp(0f, .15f, t, ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic));
            bloom.Strength = ScalarMath.Lerp(1f, 1.5f, t,
                ((ISourceScalarEnvironment)level.EngineContext).ScalarArithmetic);
            renderer.Fade = t * .6f;
        }

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

        public static IEnumerator RemoveRoutine(OriginalLevelSceneRoot level, Action onComplete = null)
        {
            // Original EntityList.FindAll<T> creates precisely this independent list.
            var blocks = new List<LightningState>();
            foreach (var record in level.SourceScene.Entities.Entities)
                if (record is LightningState lightning)
                    blocks.Add(lightning);
            foreach (var block in new List<LightningState>(blocks))
            {
                block.Disappearing = true;
                if (block.Right < level.Camera.Left || block.Bottom < level.Camera.Top
                                                    || block.Left > level.Camera.Right ||
                                                    block.Top > level.Camera.Bottom)
                {
                    blocks.Remove(block);
                    block.RemoveSelf();
                }
            }

            var renderer = FirstRenderer(level);
            renderer.StopAmbience();
            renderer.UpdateSeeds = false;
            for (float t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 4f)
            {
                SetBreakValue(level, t);
                yield return null;
            }

            SetBreakValue(level, 1f);
            level.Shake();
            for (int i = blocks.Count - 1; i >= 0; i--) blocks[i].Shatter();
            for (float t = 0f; t < 1f; t += level.EngineContext.DeltaTime * 8f)
            {
                SetBreakValue(level, 1f - t);
                yield return null;
            }

            SetBreakValue(level, 0f);
            foreach (var block in blocks) block.RemoveSelf();
            OriginalFlingBirdState bird = null;
            foreach (var record in level.SourceScene.Entities.Entities)
                if (record is OriginalFlingBirdState found)
                {
                    bird = found;
                    break;
                }

            if (bird != null) bird.LightningRemoved = true;
            onComplete?.Invoke();
        }
    }
}

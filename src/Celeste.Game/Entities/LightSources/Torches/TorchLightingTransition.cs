using System;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.LightSources.Torches
{
    public static class TorchLightingTransition
    {
        public static SourceTweenState Create(ISourceEngineContext engine, VertexLightState light,
            BloomPointState bloom, float startRadius, float endRadius, float bloomAlpha,
            Action<SourceTweenState> updateColor = null)
        {
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.BackOut, 1f, true);
            tween.OnUpdate = t =>
            {
                updateColor?.Invoke(t);
                light.StartRadius = startRadius + (1f - t.Eased) * 32f;
                light.EndRadius = endRadius + (1f - t.Eased) * 32f;
                bloom.Alpha = bloomAlpha + bloomAlpha * (1f - t.Eased);
            };
            return tween;
        }
    }
}

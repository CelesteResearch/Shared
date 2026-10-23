using System.Runtime.CompilerServices;
using Celeste.Core.Mathematics;
using Celeste.Graphics.Animation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Collectibles.Refills
{
    public static partial class RefillPresentation
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void UpdateLighting<TContext>(SceneEntityState owner, in TContext context, Sprite sprite,
            Sprite flash, VertexLightState light, BloomPointState bloom)
            where TContext : struct, IRefillPresentationContext
        {
            light.Alpha = ScalarMath.Approach(light.Alpha, sprite.Visible ? 1f : 0f, 4f * context.DeltaTime,
                context.ExtremaArithmetic);
            bloom.Alpha = light.Alpha * .8f;
            if (context.OnInterval(owner.Scene, 2f) && sprite.Visible)
            {
                flash.Play("flash", restart: true);
                flash.Visible = true;
            }
        }

        private readonly struct DefaultRefillPresentationContext(IOriginalRefillProcess engine)
            : IRefillPresentationContext
        {
            public float DeltaTime => engine.DeltaTime;

            public Celeste.Core.Mathematics.Extrema.ISourceExtremaArithmetic ExtremaArithmetic =>
                engine.ExtremaArithmetic;

            public bool OnInterval(object scene, float interval) =>
                ((ISourceScene)scene).SourceScene.Clock.OnInterval(interval, engine);
        }
    }
}

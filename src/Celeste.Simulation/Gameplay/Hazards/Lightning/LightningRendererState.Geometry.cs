using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Graphics.Rendering.Vertices;

namespace Celeste.Simulation.Gameplay.Hazards.Lightning
{
    public sealed partial class LightningRendererState
    {
        public new static void DrawSimpleLightning(ref int index, ref SourceVertexPositionColor[] vertices, uint seed,
            Vector2 position, Vector2 a, Vector2 b, PackedColor color, ISourceVectorArithmetic arithmetic,
            float thickness = 1f)
            => TiledLightningRendererState<LightningState>.DrawSimpleLightning(ref index, ref vertices, seed, position,
                a, b, color, arithmetic, thickness);

        public new static void DrawBezierLightning(ref int index, ref SourceVertexPositionColor[] vertices, uint seed,
            Vector2 position, Vector2 a, Vector2 b, float anchor, int steps, PackedColor color,
            ISourceCurveArithmetic curveArithmetic, ISourceVectorArithmetic arithmetic)
            => TiledLightningRendererState<LightningState>.DrawBezierLightning(ref index, ref vertices, seed, position,
                a, b, anchor, steps, color, curveArithmetic, arithmetic);

        public new static void DrawFatLightning(ISourceRenderContext context, object entity, uint seed, Vector2 a,
            Vector2 b,
            float size, float gap, PackedColor color, ISourceVectorArithmetic arithmetic)
            => TiledLightningRendererState<LightningState>.DrawFatLightning(context, entity, seed, a, b, size, gap,
                color, arithmetic);

        public new static uint PseudoRand(ref uint seed) =>
            TiledLightningRendererState<LightningState>.PseudoRand(ref seed);

        public new static float PseudoRandRange(ref uint seed, float min, float max) =>
            TiledLightningRendererState<LightningState>.PseudoRandRange(ref seed, min, max);
    }
}

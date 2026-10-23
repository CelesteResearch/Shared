using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Godrays
{
    public class GodraysBackdropPresentation : BackdropPresentation
    {
        protected struct Ray
        {
            public float X, Y, Percent, Duration, Width, Length;
        }

        protected readonly ISourceEngineContext engine;

        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;
        private readonly SourceVertexPositionColor[] vertices;
        private int vertexCount;
        private readonly PackedColor rayColor = new PackedColor(245, 43, 99) * .5f;
        private readonly Ray[] rays;
        private float fade;

        public GodraysBackdropPresentation(ISourceEngineContext engine) : this(engine, 6, true)
        {
        }

        protected GodraysBackdropPresentation(ISourceEngineContext engine, int count, bool initializeRays)
        {
            this.engine = engine;
            rays = new Ray[count];
            vertices = new SourceVertexPositionColor[count * 6];
            UseSpritebatch = false;
            if (initializeRays) InitializeRays();
        }

        protected void InitializeRays()
        {
            for (var i = 0; i < rays.Length; i++)
            {
                ResetRay(ref rays[i], new(384f, 244f));
                rays[i].Percent = SourceRandomMath.NextFloat(Random);
            }
        }

        protected virtual void ResetRay(ref Ray ray, Vector2 wrapBounds)
        {
            ray.Percent = 0f;
            ray.X = SourceRandomMath.NextFloat(Random, 384f);
            ray.Y = SourceRandomMath.NextFloat(Random, 244f);
            ray.Duration = 4f + SourceRandomMath.NextFloat(Random) * 8f;
            ray.Width = Random.Next(8, 16);
            ray.Length = Random.Next(20, 40);
        }

        protected virtual Vector2 GetWrapBounds(ISourceBackdropScene scene)
        {
            return new(384f, 244f);
        }

        protected virtual GodrayMotionConfiguration GetMotionConfiguration()
        {
            return new(Vector2Geometry.AngleToVector(-1.6707964f, 1f),
                new(.9f, .9f), 8f, rayColor);
        }

        public override void Update(ISourceBackdropScene scene)
        {
            var visible = IsVisible(scene);
            fade = ScalarMath.Approach(fade, visible ? 1 : 0, engine.Frame.DeltaTime,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Visible = fade > 0f;
            if (!Visible) return;
            var player = scene.FirstPlayer;
            var motion = GetMotionConfiguration();
            var wrapBounds = GetWrapBounds(scene);
            var direction = motion.Direction;
            var perpendicular = new Vector2(-direction.Y, direction.X);
            var index = 0;
            for (var i = 0; i < rays.Length; i++)
            {
                var width = rays[i].Width;
                var length = rays[i].Length;
                if (rays[i].Percent >= 1f) ResetRay(ref rays[i], wrapBounds);
                if (motion.GeometrySampling == GodrayGeometrySampling.AfterReset)
                {
                    width = rays[i].Width;
                    length = rays[i].Length;
                }

                rays[i].Percent += engine.Frame.DeltaTime / rays[i].Duration;
                rays[i].Y += motion.VerticalVelocity * engine.Frame.DeltaTime;
                if (motion.HorizontalVelocity.HasValue)
                    rays[i].X += motion.HorizontalVelocity.Value * engine.Frame.DeltaTime;
                var percent = rays[i].Percent;
                var modulusX = wrapBounds.X + (motion.ExtendedBounds ? width * 2f : 0f);
                var modulusY = wrapBounds.Y + (motion.ExtendedBounds ? length * 2f : 0f);
                var offsetX = motion.ExtendedBounds ? -width : -32f;
                var offsetY = motion.ExtendedBounds ? -length : -32f;
                var x = offsetX + ScalarMath.Mod(rays[i].X - scene.Camera.X * motion.Scroll.X, modulusX);
                var y = offsetY + ScalarMath.Mod(rays[i].Y - scene.Camera.Y * motion.Scroll.Y, modulusY);
                var at = motion.PositionRounding == GodrayPositionRounding.Floor
                    ? new Vector2((float)Math.Floor(x), (float)Math.Floor(y))
                    : new Vector2((int)x, (int)y);
                var ray = motion.EndColor.HasValue
                    ? PackedColor.Lerp(motion.StartColor, motion.EndColor.Value, percent)
                    : motion.StartColor;
                var color = ray * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeInOut(
                    ScalarMath.Clamp((percent < .5f ? percent : 1f - percent) * 2f, 0f, 1f)) * fade;
                if (player != null)
                {
                    var distance = ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(
                        at + scene.Camera.Position - player.Position);
                    if (distance < 64f) color *= .25f + .75f * (distance / 64f);
                }

                var a = new SourceVertexPositionColor(new(at + perpendicular * width + direction * length, 0f),
                    color);
                var b = new SourceVertexPositionColor(new(at - perpendicular * width, 0f), color);
                var c = new SourceVertexPositionColor(new(at + perpendicular * width, 0f), color);
                var d = new SourceVertexPositionColor(new(at - perpendicular * width - direction * length, 0f),
                    color);
                vertices[index++] = a;
                vertices[index++] = b;
                vertices[index++] = c;
                vertices[index++] = b;
                vertices[index++] = c;
                vertices[index++] = d;
            }

            vertexCount = index;
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (vertexCount > 0 && fade > 0f)
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.Identity, vertices, vertexCount);
        }
    }
}

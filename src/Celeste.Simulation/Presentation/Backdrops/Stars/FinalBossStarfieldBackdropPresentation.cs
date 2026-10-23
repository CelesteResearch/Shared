using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Simulation.Presentation.Backdrops.Stars
{
    public class FinalBossStarfieldBackdropPresentation : BackdropPresentation
    {
        private struct Particle
        {
            public Vector2 Position;

            public Vector2 Direction;

            public float Speed;

            public PackedColor Color;

            public float DirectionApproach;
        }

        public float Alpha = 1f;

        private const int particleCount = 200;

        private readonly Particle[] particles = new Particle[200];

        private readonly SourceVertexPositionColor[] verts = new SourceVertexPositionColor[1206];

        private static readonly PackedColor[] colors =
        [
            new(3, 12, 27),
            new(11, 3, 27),
            new(27, 3, 25),
            new(15, 3, 1),
        ];

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public FinalBossStarfieldBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            UseSpritebatch = false;
            for (var i = 0; i < 200; i++)
            {
                particles[i].Speed = SourceRandomMath.Range(Random, 500f, 1200f);
                particles[i].Direction = new(-1f, 0f);
                particles[i].DirectionApproach = SourceRandomMath.Range(Random, 0.25f, 4f);
                particles[i].Position.X = SourceRandomMath.Range(Random, 0, 384);
                particles[i].Position.Y = SourceRandomMath.Range(Random, 0, 244);
                particles[i].Color = Random.Choose(colors);
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            base.Update(scene);
            if (Visible && Alpha > 0f)
            {
                var vector = new Vector2(-1f, 0f);
                var level = scene;
                if (level.Bounds.Height > level.Bounds.Width) vector = new(0f, -1f);

                var target = Vector2Geometry.Angle(vector);
                for (var i = 0; i < 200; i++)
                {
                    particles[i].Position += particles[i].Direction * particles[i].Speed * engine.Frame.DeltaTime;
                    var val = Vector2Geometry.Angle(particles[i].Direction);
                    val = ScalarMath.AngleApproach(val, target,
                        particles[i].DirectionApproach * engine.Frame.DeltaTime);
                    particles[i].Direction = Vector2Geometry.AngleToVector(val, 1f);
                }
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            var position = scene.Camera.Position;
            var color = PackedColor.Black * Alpha;
            verts[0].Color = color;
            verts[0].Position = new(-10f, -10f, 0f);
            verts[1].Color = color;
            verts[1].Position = new(330f, -10f, 0f);
            verts[2].Color = color;
            verts[2].Position = new(330f, 190f, 0f);
            verts[3].Color = color;
            verts[3].Position = new(-10f, -10f, 0f);
            verts[4].Color = color;
            verts[4].Position = new(330f, 190f, 0f);
            verts[5].Color = color;
            verts[5].Position = new(-10f, 190f, 0f);
            for (var i = 0; i < 200; i++)
            {
                var num = (i + 1) * 6;
                var num2 = ScalarMath.ClampedMap(particles[i].Speed, 0f, 1200f, 1f, 64f);
                var num3 = ScalarMath.ClampedMap(particles[i].Speed, 0f, 1200f, 3f, 0.6f);
                var direction = particles[i].Direction;
                var vector = Vector2Geometry.Perpendicular(direction);
                var position2 = particles[i].Position;
                position2.X = -32f + ScalarMath.Mod(position2.X - position.X * 0.9f, 384f);
                position2.Y = -32f + ScalarMath.Mod(position2.Y - position.Y * 0.9f, 244f);
                var value = position2 - direction * num2 * 0.5f - vector * num3;
                var value2 = position2 + direction * num2 * 1f - vector * num3;
                var value3 = position2 + direction * num2 * 0.5f + vector * num3;
                var value4 = position2 - direction * num2 * 1f + vector * num3;
                var color2 = particles[i].Color * Alpha;
                verts[num].Color = color2;
                verts[num].Position = new(value, 0f);
                verts[num + 1].Color = color2;
                verts[num + 1].Position = new(value2, 0f);
                verts[num + 2].Color = color2;
                verts[num + 2].Position = new(value3, 0f);
                verts[num + 3].Color = color2;
                verts[num + 3].Position = new(value, 0f);
                verts[num + 4].Color = color2;
                verts[num + 4].Position = new(value3, 0f);
                verts[num + 5].Color = color2;
                verts[num + 5].Position = new(value4, 0f);
            }

            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, verts, verts.Length);
        }
    }
}

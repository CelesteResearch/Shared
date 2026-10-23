using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;

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

        private Particle[] particles = new Particle[200];

        private SourceVertexPositionColor[] verts = new SourceVertexPositionColor[1206];

        private static readonly PackedColor[] colors = new PackedColor[4]
        {
            new PackedColor(3, 12, 27),
            new PackedColor(11, 3, 27),
            new PackedColor(27, 3, 25),
            new PackedColor(15, 3, 1)
        };

        private readonly ISourceEngineContext engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public FinalBossStarfieldBackdropPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            UseSpritebatch = false;
            for (int i = 0; i < 200; i++)
            {
                particles[i].Speed = SourceRandomMath.Range(Random, 500f, 1200f);
                particles[i].Direction = new Vector2(-1f, 0f);
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
                Vector2 vector = new Vector2(-1f, 0f);
                ISourceBackdropScene level = scene;
                if (level.Bounds.Height > level.Bounds.Width)
                {
                    vector = new Vector2(0f, -1f);
                }

                float target = Vector2Geometry.Angle(vector);
                for (int i = 0; i < 200; i++)
                {
                    particles[i].Position += particles[i].Direction * particles[i].Speed * engine.Frame.DeltaTime;
                    float val = Vector2Geometry.Angle(particles[i].Direction);
                    val = ScalarMath.AngleApproach(val, target,
                        particles[i].DirectionApproach * engine.Frame.DeltaTime);
                    particles[i].Direction = Vector2Geometry.AngleToVector(val, 1f);
                }
            }
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            Vector2 position = scene.Camera.Position;
            PackedColor color = PackedColor.Black * Alpha;
            verts[0].Color = color;
            verts[0].Position = new Vector3(-10f, -10f, 0f);
            verts[1].Color = color;
            verts[1].Position = new Vector3(330f, -10f, 0f);
            verts[2].Color = color;
            verts[2].Position = new Vector3(330f, 190f, 0f);
            verts[3].Color = color;
            verts[3].Position = new Vector3(-10f, -10f, 0f);
            verts[4].Color = color;
            verts[4].Position = new Vector3(330f, 190f, 0f);
            verts[5].Color = color;
            verts[5].Position = new Vector3(-10f, 190f, 0f);
            for (int i = 0; i < 200; i++)
            {
                int num = (i + 1) * 6;
                float num2 = ScalarMath.ClampedMap(particles[i].Speed, 0f, 1200f, 1f, 64f);
                float num3 = ScalarMath.ClampedMap(particles[i].Speed, 0f, 1200f, 3f, 0.6f);
                Vector2 direction = particles[i].Direction;
                Vector2 vector = Vector2Geometry.Perpendicular(direction);
                Vector2 position2 = particles[i].Position;
                position2.X = -32f + ScalarMath.Mod(position2.X - position.X * 0.9f, 384f);
                position2.Y = -32f + ScalarMath.Mod(position2.Y - position.Y * 0.9f, 244f);
                Vector2 value = position2 - direction * num2 * 0.5f - vector * num3;
                Vector2 value2 = position2 + direction * num2 * 1f - vector * num3;
                Vector2 value3 = position2 + direction * num2 * 0.5f + vector * num3;
                Vector2 value4 = position2 - direction * num2 * 1f + vector * num3;
                PackedColor color2 = particles[i].Color * Alpha;
                verts[num].Color = color2;
                verts[num].Position = new Vector3(value, 0f);
                verts[num + 1].Color = color2;
                verts[num + 1].Position = new Vector3(value2, 0f);
                verts[num + 2].Color = color2;
                verts[num + 2].Position = new Vector3(value3, 0f);
                verts[num + 3].Color = color2;
                verts[num + 3].Position = new Vector3(value, 0f);
                verts[num + 4].Color = color2;
                verts[num + 4].Position = new Vector3(value3, 0f);
                verts[num + 5].Color = color2;
                verts[num + 5].Position = new Vector3(value4, 0f);
            }

            SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                Matrix4x4.Identity, verts, verts.Length);
        }
    }
}

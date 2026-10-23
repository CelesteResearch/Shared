using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Simulation.Presentation.Backdrops.Runtime;

namespace Celeste.Game.Presentation.Backdrops.Tentacles
{
    public class TentaclesBackdropPresentation : BackdropPresentation
    {
        public enum Side
        {
            Right,
            Left,
            Top,
            Bottom,
        }

        private struct Tentacle
        {
            public float Length;

            public float Offset;

            public float Step;

            public float Position;

            public float Approach;

            public float Width;
        }

        private const int NodesPerTentacle = 10;
        private readonly ISourceEngineContext engine;

        private readonly Side side;

        private readonly float width;

        private readonly Vector2 origin;

        private readonly Vector2 outwards;

        private readonly float outwardsOffset;

        private readonly SourceVertexPositionColor[] vertices;

        private int vertexCount;

        private readonly Tentacle[] tentacles;

        private readonly int tentacleCount;

        private float hideTimer = 5f;

        public TentaclesBackdropPresentation(ISourceEngineContext engine, Side side, PackedColor color,
            float outwardsOffset)
        {
            this.engine = engine;
            this.side = side;
            this.outwardsOffset = outwardsOffset;
            UseSpritebatch = false;
            switch (side)
            {
                case Side.Right:
                    outwards = new(-1f, 0f);
                    width = 180f;
                    origin = new(320f, 90f);
                    break;
                case Side.Left:
                    outwards = new(1f, 0f);
                    width = 180f;
                    origin = new(0f, 90f);
                    break;
                case Side.Top:
                    outwards = new(0f, 1f);
                    width = 320f;
                    origin = new(160f, 0f);
                    break;
                case Side.Bottom:
                    outwards = new(0f, -1f);
                    width = 320f;
                    origin = new(160f, 180f);
                    break;
            }

            var num = 0f;
            tentacles = new Tentacle[100];
            for (var i = 0; i < tentacles.Length; i++)
            {
                if (!(num < width + 40f)) break;

                tentacles[i].Length = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Offset = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Step = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Position = -200f;
                tentacles[i].Approach = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                num += tentacles[i].Width =
                    6f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 20f);
                tentacleCount++;
            }

            vertices = new SourceVertexPositionColor[tentacleCount * 11 * 6];
            for (var j = 0; j < vertices.Length; j++) vertices[j].Color = color;
        }

        public override void Update(ISourceBackdropScene scene)
        {
            var num = IsVisible(scene);
            var num2 = 0f;
            if (num)
            {
                var camera = scene.Camera;
                var entity = scene.FirstPlayer;
                if (entity != null)
                {
                    if (side == Side.Right)
                        num2 = 320f - (entity.Position.X - camera.X) - 160f;
                    else if (side == Side.Bottom) num2 = 180f - (entity.Position.Y - camera.Y) - 180f;
                }

                hideTimer = 0f;
            }
            else
            {
                num2 = -200f;
                hideTimer += engine.DeltaTime;
            }

            num2 += outwardsOffset;
            Visible = hideTimer < 5f;
            if (!Visible) return;

            var vector = -Vector2Geometry.Perpendicular(outwards);
            var num3 = 0;
            var vector2 = origin - vector * (width / 2f + 2f);
            for (var i = 0; i < tentacleCount; i++)
            {
                vector2 += vector * tentacles[i].Width * 0.5f;
                tentacles[i].Position += (num2 - tentacles[i].Position) *
                                         (1f - (float)Math.Pow(0.5f * (0.5f + tentacles[i].Approach * 0.5f),
                                             engine.DeltaTime));
                var vector3 = (tentacles[i].Position +
                               (float)Math.Sin(scene.SourceScene.Clock.TimeActive + tentacles[i].Offset * 4f) * 8f +
                               ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(origin - vector2) *
                               0.7f) *
                              outwards;
                var vector4 = vector2 + vector3;
                var num4 = 2f + tentacles[i].Length * 8f;
                var vector5 = vector4;
                var vector6 = vector * tentacles[i].Width * 0.5f;
                vertices[num3++].Position = new(vector2 + vector6, 0f);
                vertices[num3++].Position = new(vector2 - vector6, 0f);
                vertices[num3++].Position = new(vector4 - vector6, 0f);
                vertices[num3++].Position = new(vector4 - vector6, 0f);
                vertices[num3++].Position = new(vector2 + vector6, 0f);
                vertices[num3++].Position = new(vector4 + vector6, 0f);
                for (var j = 1; j < 10; j++)
                {
                    var num5 = scene.SourceScene.Clock.TimeActive * tentacles[i].Offset *
                               (float)Math.Pow(1.100000023841858, j) * 2f;
                    var num6 = tentacles[i].Offset * 3f + j * (0.1f + tentacles[i].Step * 0.2f) +
                               num4 * j * 0.1f;
                    var num7 = 2f + 4f * (j / 10f);
                    var vector7 = (float)Math.Sin(num5 + num6) * vector * num7;
                    var num8 = (1f - j / 10f) * tentacles[i].Width * 0.5f;
                    var vector8 = vector5 + outwards * num4 + vector7;
                    var vector9 =
                        Vector2Geometry.Perpendicular(
                            ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(vector5 - vector8)) *
                        num8;
                    vertices[num3++].Position = new(vector5 + vector6, 0f);
                    vertices[num3++].Position = new(vector5 - vector6, 0f);
                    vertices[num3++].Position = new(vector8 - vector9, 0f);
                    vertices[num3++].Position = new(vector8 - vector9, 0f);
                    vertices[num3++].Position = new(vector5 + vector6, 0f);
                    vertices[num3++].Position = new(vector8 + vector9, 0f);
                    vector5 = vector8;
                    vector6 = vector9;
                }

                vector2 += vector * tentacles[i].Width * 0.5f;
            }

            vertexCount = num3;
        }

        public override void Render(ISourceRenderContext context, ISourceBackdropScene scene)
        {
            if (vertexCount > 0)
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.Identity, vertices, vertexCount);
        }
    }
}

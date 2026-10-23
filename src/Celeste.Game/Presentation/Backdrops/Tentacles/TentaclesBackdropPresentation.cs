using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Simulation.Presentation.Backdrops.Runtime;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;


namespace Celeste.Game.Presentation.Backdrops.Tentacles
{
    public class TentaclesBackdropPresentation : BackdropPresentation
    {
        public enum Side
        {
            Right,
            Left,
            Top,
            Bottom
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

        private Side side;

        private float width;

        private Vector2 origin;

        private Vector2 outwards;

        private float outwardsOffset;

        private SourceVertexPositionColor[] vertices;

        private int vertexCount;

        private Tentacle[] tentacles;

        private int tentacleCount;

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
                    outwards = new Vector2(-1f, 0f);
                    width = 180f;
                    origin = new Vector2(320f, 90f);
                    break;
                case Side.Left:
                    outwards = new Vector2(1f, 0f);
                    width = 180f;
                    origin = new Vector2(0f, 90f);
                    break;
                case Side.Top:
                    outwards = new Vector2(0f, 1f);
                    width = 320f;
                    origin = new Vector2(160f, 0f);
                    break;
                case Side.Bottom:
                    outwards = new Vector2(0f, -1f);
                    width = 320f;
                    origin = new Vector2(160f, 180f);
                    break;
            }

            float num = 0f;
            tentacles = new Tentacle[100];
            for (int i = 0; i < tentacles.Length; i++)
            {
                if (!(num < width + 40f))
                {
                    break;
                }

                tentacles[i].Length = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Offset = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Step = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                tentacles[i].Position = -200f;
                tentacles[i].Approach = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                num += (tentacles[i].Width =
                    6f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 20f));
                tentacleCount++;
            }

            vertices = new SourceVertexPositionColor[tentacleCount * 11 * 6];
            for (int j = 0; j < vertices.Length; j++)
            {
                vertices[j].Color = color;
            }
        }

        public override void Update(ISourceBackdropScene scene)
        {
            bool num = IsVisible(scene);
            float num2 = 0f;
            if (num)
            {
                var camera = scene.Camera;
                ISourceEntityPosition entity = scene.FirstPlayer;
                if (entity != null)
                {
                    if (side == Side.Right)
                    {
                        num2 = 320f - (entity.Position.X - camera.X) - 160f;
                    }
                    else if (side == Side.Bottom)
                    {
                        num2 = 180f - (entity.Position.Y - camera.Y) - 180f;
                    }
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
            if (!Visible)
            {
                return;
            }

            Vector2 vector = -Vector2Geometry.Perpendicular(outwards);
            int num3 = 0;
            Vector2 vector2 = origin - vector * (width / 2f + 2f);
            for (int i = 0; i < tentacleCount; i++)
            {
                vector2 += vector * tentacles[i].Width * 0.5f;
                tentacles[i].Position += (num2 - tentacles[i].Position) *
                                         (1f - (float)Math.Pow(0.5f * (0.5f + tentacles[i].Approach * 0.5f),
                                             engine.DeltaTime));
                Vector2 vector3 = (tentacles[i].Position +
                                   (float)Math.Sin(scene.SourceScene.Clock.TimeActive + tentacles[i].Offset * 4f) * 8f +
                                   ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(origin - vector2) *
                                   0.7f) *
                                  outwards;
                Vector2 vector4 = vector2 + vector3;
                float num4 = 2f + tentacles[i].Length * 8f;
                Vector2 vector5 = vector4;
                Vector2 vector6 = vector * tentacles[i].Width * 0.5f;
                vertices[num3++].Position = new Vector3(vector2 + vector6, 0f);
                vertices[num3++].Position = new Vector3(vector2 - vector6, 0f);
                vertices[num3++].Position = new Vector3(vector4 - vector6, 0f);
                vertices[num3++].Position = new Vector3(vector4 - vector6, 0f);
                vertices[num3++].Position = new Vector3(vector2 + vector6, 0f);
                vertices[num3++].Position = new Vector3(vector4 + vector6, 0f);
                for (int j = 1; j < 10; j++)
                {
                    float num5 = scene.SourceScene.Clock.TimeActive * tentacles[i].Offset *
                                 (float)Math.Pow(1.100000023841858, j) * 2f;
                    float num6 = tentacles[i].Offset * 3f + (float)j * (0.1f + tentacles[i].Step * 0.2f) +
                                 num4 * (float)j * 0.1f;
                    float num7 = 2f + 4f * ((float)j / 10f);
                    Vector2 vector7 = (float)Math.Sin(num5 + num6) * vector * num7;
                    float num8 = (1f - (float)j / 10f) * tentacles[i].Width * 0.5f;
                    Vector2 vector8 = vector5 + outwards * num4 + vector7;
                    Vector2 vector9 =
                        Vector2Geometry.Perpendicular(
                            ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(vector5 - vector8)) *
                        num8;
                    vertices[num3++].Position = new Vector3(vector5 + vector6, 0f);
                    vertices[num3++].Position = new Vector3(vector5 - vector6, 0f);
                    vertices[num3++].Position = new Vector3(vector8 - vector9, 0f);
                    vertices[num3++].Position = new Vector3(vector8 - vector9, 0f);
                    vertices[num3++].Position = new Vector3(vector5 + vector6, 0f);
                    vertices[num3++].Position = new Vector3(vector8 + vector9, 0f);
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
            {
                SourcePrimitiveGraphics.DrawVertices(((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    Matrix4x4.Identity, vertices, vertexCount);
            }
        }
    }
}

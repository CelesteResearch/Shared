using System;
using System.Numerics;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Rendering;

namespace Celeste.Simulation.Presentation.Scene.Transitions
{
    public class DreamWipePresentation : ScreenWipePresentation
    {
        internal struct Circle
        {
            public Vector2 Position;

            public float Radius;

            public float Delay;
        }

        private readonly int circleColumns = 15;

        private readonly int circleRows = 8;

        private const int circleSegments = 32;

        private const float circleFillSpeed = 400f;

        private Circle[] circles
        {
            get => ProcessWipe.DreamCircles;
            set => ProcessWipe.DreamCircles = value;
        }

        private SourceVertexPositionColor[] vertexBuffer
        {
            get => ProcessWipe.DreamVertices;
            set => ProcessWipe.DreamVertices = value;
        }

        public DreamWipePresentation(ISourceRendererScene scene, bool wipeIn, Action onComplete = null)
            : base(scene, wipeIn, onComplete)
        {
            if (vertexBuffer == null)
                vertexBuffer = new SourceVertexPositionColor[(circleColumns + 2) * (circleRows + 2) * 32 * 3];

            if (circles == null) circles = new Circle[(circleColumns + 2) * (circleRows + 2)];

            for (var i = 0; i < vertexBuffer.Length; i++) vertexBuffer[i].Color = WipeColor;

            var num = 1920 / circleColumns;
            var num2 = 1080 / circleRows;
            var j = 0;
            var num3 = 0;
            for (; j < circleColumns + 2; j++)
            for (var k = 0; k < circleRows + 2; k++)
            {
                circles[num3].Position =
                    new((j - 1 + 0.2f + SourceRandomMath.NextFloat(Random, 0.6f)) * num,
                        (k - 1 + 0.2f + SourceRandomMath.NextFloat(Random, 0.6f)) * num2);
                circles[num3].Delay = SourceRandomMath.NextFloat(Random, 0.05f) +
                                      (WipeIn ? circleColumns - j : j) * 0.018f;
                circles[num3].Radius = WipeIn ? 400f * (Duration - circles[num3].Delay) : 0f;
                num3++;
            }
        }

        public override void Update(object scene)
        {
            base.Update(scene);
            for (var i = 0; i < circles.Length; i++)
                if (!WipeIn)
                {
                    circles[i].Delay -= EngineContext.DeltaTime;
                    if (circles[i].Delay <= 0f) circles[i].Radius += EngineContext.DeltaTime * 400f;
                }
                else if (circles[i].Radius > 0f)
                {
                    circles[i].Radius -= EngineContext.DeltaTime * 400f;
                }
                else
                {
                    circles[i].Radius = 0f;
                }
        }

        public override void Render(object scene)
        {
            var num = 0;
            for (var i = 0; i < circles.Length; i++)
            {
                var circle = circles[i];
                var vector = new Vector2(1f, 0f);
                for (var num2 = 0f; num2 < 32f; num2 += 1f)
                {
                    var vector2 = Vector2Geometry.AngleToVector((num2 + 1f) / 32f * ((float)Math.PI * 2f), 1f);
                    vertexBuffer[num++].Position = new(circle.Position, 0f);
                    vertexBuffer[num++].Position =
                        new(
                            SourceVector2Math.Add(circle.Position, SourceVector2Math.Multiply(vector, circle.Radius)),
                            0f);
                    vertexBuffer[num++].Position =
                        new(
                            SourceVector2Math.Add(circle.Position, SourceVector2Math.Multiply(vector2, circle.Radius)),
                            0f);
                    vector = vector2;
                }
            }

            DrawPrimitives(vertexBuffer);
        }
    }
}

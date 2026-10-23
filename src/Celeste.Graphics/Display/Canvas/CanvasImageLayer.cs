using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Graphics.Display.Canvas
{
    public sealed class CanvasImageLayer : CanvasLayer
    {
        public readonly List<AtlasEntry> Images;
        public float Frame, FrameRate, Alpha, Scale;
        public Vector2 Offset, Speed;
        private readonly Func<string, Vector2> pageSize;

        private readonly float mirrorWidth;

        public CanvasImageLayer(Vector2 offset, CanvasImageLayerDefinition definition, Func<string, Vector2> pageSize,
            float mirrorWidth) : base(definition)
        {
            this.pageSize = pageSize;
            this.mirrorWidth = mirrorWidth;
            Position += offset;
            Images = definition.Images;
            FrameRate = definition.FrameRate;
            Alpha = definition.Alpha;
            Speed = definition.Speed;
            Scale = definition.Scale;
        }

        public override void Update(float dt)
        {
            Frame += dt * FrameRate;
            Offset += Speed * dt;
        }

        public override void Render(Vector2 scroll, Action<CanvasDrawCommand> emit, bool mirror)
        {
            var p = GetScrollPosition(scroll);
            p = new((float)Math.Floor(p.X), (float)Math.Floor(p.Y));
            var image = Images[(int)(Frame % Images.Count)];
            if (image == null) return;
            if (mirror)
            {
                p.X = mirrorWidth - p.X - image.OffsetX * Scale - pageSize(image.Page).X * Scale;
                p.Y += image.OffsetY * Scale;
            }
            else
            {
                p += new Vector2(image.OffsetX, image.OffsetY) * Scale;
            }

            var source = new IntRect(image.X, image.Y, image.Width, image.Height);
            var wrap = Offset.X != 0 || Offset.Y != 0;
            if (wrap)
            {
                source = new((int)(-Offset.X / Scale) + 1,
                    (int)(-Offset.Y / Scale) + 1, image.Width - 2,
                    image.Height - 2);
                emit(new() { Kind = CanvasDrawKind.End });
                emit(new() { Kind = CanvasDrawKind.Begin, Sampler = CanvasSampler.LinearWrap });
            }

            emit(new()
            {
                Kind = CanvasDrawKind.Image, Page = image.Page, Source = source, Position = p, Scale = Scale,
                FlipHorizontally = mirror, Color = new(ByteAlpha(Alpha)),
            });
            if (wrap)
            {
                emit(new() { Kind = CanvasDrawKind.End });
                emit(new() { Kind = CanvasDrawKind.Begin, Sampler = CanvasSampler.LinearClamp });
            }
        }

        private static float ByteAlpha(float alpha)
        {
            return ColorMath.Scale(Vector4.One, alpha).W;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.Presentation.Decoration.Cobwebs
{
    public sealed class CobwebPresentation
    {
        public const int Depth = -1;

        private static readonly TileRegion Pixel =
            new(
                new()
                {
                    Name = "pixel", Page = "__particle_pixel", Width = 1, Height = 1, FrameWidth = 1, FrameHeight = 1,
                },
                0, 0,
                1, 1);

        public readonly Vector2 AnchorA, AnchorB;
        private readonly List<Vector2> offshoots = [];
        private readonly List<float> endings = [];

        private readonly List<ImagePlacement> images = [];

        public IReadOnlyList<Vector2> Offshoots => offshoots;
        public IReadOnlyList<float> OffshootEndings => endings;
        public float WaveTimer { get; private set; }
        public Vector4 Color { get; private set; }
        public Vector4 Edge { get; private set; }
        public bool RemovalRequested { get; private set; }

        // Node zero is the other main anchor. Remaining nodes connect to random
        // points on the main curve; all constructor randomness precedes Added.
        public CobwebPresentation(Vector2 position, IReadOnlyList<Vector2> nodes, Random random)
        {
            AnchorA = position;
            AnchorB = nodes[0];
            for (var i = 1; i < nodes.Count; i++)
            {
                offshoots.Add(nodes[i]);
                endings.Add(.3f + (float)random.NextDouble() * .4f);
            }

            WaveTimer = (float)random.NextDouble();
        }

        public CobwebPresentation(MapElement source, Vector2 offset, Random random)
            : this(offset + new Vector2(source.Float("x"), source.Float("y")),
                (Vector2[])
                [
                    .. source.Children.Where(n => n.Name == "node")
                        .Select(n => offset + new Vector2(n.Float("x"), n.Float("y"))),
                ], random)
        {
        }

        public static Vector4[] ColorsForArea(int area)
        {
            if (area == 5) return [new Vector4(159, 33, 102, 255) / 255f];
            if (area == 10)
                return
                [
                    new Vector4(66, 193, 146, 255) / 255f, new Vector4(175, 54, 168, 255) / 255f,
                    new Vector4(52, 116, 166, 255) / 255f,
                ];
            return [new Vector4(105, 106, 106, 255) / 255f];
        }

        public void Added(IReadOnlyList<Vector4> colors, Random random,
            Func<Bounds, bool> solidAt)
        {
            SelectColor(colors, random);
            CheckAnchors(solidAt);
        }

        public void SelectColor(IReadOnlyList<Vector4> colors, Random random)
        {
            Color = colors[random.Next(colors.Count)];
            Edge = ColorMath.Lerp(Color, new Vector4(15, 14, 23, 255) / 255f,
                .2f);
        }

        public void CheckAnchors(Func<Bounds, bool> solidAt)
        {
            if (!solidAt(AnchorBounds(AnchorA)) || !solidAt(AnchorBounds(AnchorB))) RemovalRequested = true;
            for (var i = 0; i < offshoots.Count; i++)
                if (!solidAt(AnchorBounds(offshoots[i])))
                {
                    offshoots.RemoveAt(i);
                    endings.RemoveAt(i);
                    i--;
                }
        }

        private static Bounds AnchorBounds(Vector2 at)
        {
            return new((int)at.X - 2, (int)at.Y - 2, 4, 4);
        }

        public void Update(float deltaTime)
        {
            WaveTimer += deltaTime;
        }

        public IEnumerable<ImagePlacement> Images()
        {
            images.Clear();
            DrawCobweb(AnchorA, AnchorB, 12, true);
            return images;
        }

        private Vector2 Control(Vector2 a, Vector2 b)
        {
            return (a + b) / 2f + Vector2.UnitY * (8f + (float)Math.Sin(WaveTimer) * 4f);
        }

        private static Vector2 Point(Vector2 a, Vector2 b, Vector2 control, float percent)
        {
            var n = 1f - percent;
            return n * n * a + 2f * n * percent * control + percent * percent * b;
        }

        private void DrawCobweb(Vector2 a, Vector2 b, int steps, bool branches)
        {
            var control = Control(a, b);
            if (branches)
                for (var i = 0; i < offshoots.Count; i++)
                    DrawCobweb(offshoots[i], Point(a, b, control, endings[i]), 4, false);
            var previous = a;
            for (var j = 1; j <= steps; j++)
            {
                Vector2 next = Point(a, b, control, (float)j / steps), delta = next - previous;
                images.Add(new(Pixel, previous.X, previous.Y, Depth,
                    (float)Math.Sqrt(delta.X * delta.X + delta.Y * delta.Y), 1, (float)Math.Atan2(delta.Y, delta.X),
                    color: j <= 2 || j >= steps - 1 ? Edge : Color));
                var reverse = previous - next;
                if (reverse != Vector2.Zero)
                    reverse *= 1f / (float)Math.Sqrt(reverse.X * reverse.X + reverse.Y * reverse.Y);
                previous = next + reverse;
            }
        }
    }
}

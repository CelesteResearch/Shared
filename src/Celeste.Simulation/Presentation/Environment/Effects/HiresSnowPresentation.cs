using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.Tiles;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;

namespace Celeste.Simulation.Presentation.Environment.Effects
{
    public sealed class HiresSnowPresentation : ISnowOpacity
    {
        public sealed class Particle
        {
            public float Scale, Speed, Sin, Rotation;
            public Vector2 Position;
            public Vector4 Color;
        }

        public float Alpha { get; set; } = 1;
        public float ParticleAlpha = 1;
        public Vector2 Direction = new(-1, 0);
        public Func<float> AttachedAlpha;
        public Random Random;
        public readonly int Width, Height;
        public readonly float OverlayAlpha;
        public readonly Particle[] Particles = new Particle[50];
        public readonly TileRegion Snow;
        public readonly AtlasEntry Overlay;
        public float Timer { get; private set; }

        public HiresSnowPresentation(AtlasData overworld, Random random,
            float overlayAlpha = .45f, int width = 1920,
            int height = 1080)
        {
            Random = random;
            Width = width;
            Height = height;
            OverlayAlpha = overlayAlpha;
            Overlay = overworld.Entries["overlay"];
            Snow = new(overworld.Entries["snow"], 1, 1, 254, 254);
            for (var i = 0; i < Particles.Length; i++) Particles[i] = new();
            Reset();
        }

        private float NextFloat(float max = 1)
        {
            return (float)Random.NextDouble() * max;
        }

        private void Reset(Particle p)
        {
            var amount = NextFloat();
            amount *= amount * amount * amount;
            p.Scale = .05f + (.8f - .05f) * amount;
            p.Speed = p.Scale * Random.Next(2500, 5000);
            if (Direction.X < 0) p.Position = new(Width + 128, NextFloat(Height));
            else if (Direction.X > 0) p.Position = new(-128, NextFloat(Height));
            else if (Direction.Y > 0) p.Position = new(NextFloat(Width), -128);
            else if (Direction.Y < 0) p.Position = new(NextFloat(Width), Height + 128);
            p.Sin = NextFloat((float)Math.PI * 2);
            p.Rotation = NextFloat((float)Math.PI * 2);
            p.Color = ColorMath.Lerp(Vector4.One, Vector4.Zero,
                amount * .8f);
        }

        public void Reset()
        {
            foreach (var p in Particles)
            {
                Reset(p);
                p.Position.X = NextFloat(Width);
                p.Position.Y = NextFloat(Height);
            }
        }

        public void Update(float dt)
        {
            if (AttachedAlpha != null) Alpha = AttachedAlpha();
            foreach (var p in Particles)
            {
                p.Position += Direction * p.Speed * dt;
                p.Position.Y += (float)Math.Sin(p.Sin) * 100f * dt;
                p.Sin += dt;
                if (p.Position.X < -128 || p.Position.X > Width + 128 || p.Position.Y < -128 ||
                    p.Position.Y > Height + 128) Reset(p);
            }

            Timer += dt;
        }

        // All draws use additive blending and linear wrapping, after HUD/wipes.
        public IReadOnlyList<ImagePlacement> Images()
        {
            var length = Math.Max(0, Math.Min(20, Direction.Length()));
            var stretched = length > 1;
            var rotation = stretched ? (float)Math.Atan2(Direction.Y, Direction.X) : 0;
            var stretch = stretched ? new(length, .2f + (1f - length / 20f) * .8f) : Vector2.One;
            var images = new List<ImagePlacement>(51);
            var alpha = Alpha * ParticleAlpha;
            foreach (var p in Particles)
            {
                var color = alpha < 1
                    ? ColorMath.Scale(p.Color, alpha)
                    : p.Color;
                var scale = stretch * p.Scale;
                images.Add(new(Snow, p.Position.X, p.Position.Y, 0,
                    scale.X, scale.Y,
                    originX: Snow.Width / 2f, originY: Snow.Height / 2f, rotation: stretched ? rotation : p.Rotation,
                    color: color));
            }

            // SpriteBatch draws the untrimmed texture with a wrapping source rect.
            // Preserve that rect instead of clipping it to the atlas entry.
            var source = new AtlasEntry
            {
                Name = Overlay.Name, Page = Overlay.Page,
                X = -(int)(Timer * 32f % Overlay.FrameWidth), Y = -(int)(Timer * 20f % Overlay.FrameHeight),
                Width = 1920, Height = 1080, FrameWidth = 1920, FrameHeight = 1080,
            };
            images.Add(new(
                new(source, 0, 0, 1920, 1080), 0, 0, 0,
                color: ColorMath.Scale(Vector4.One, Alpha * OverlayAlpha)));
            return images;
        }
    }
}

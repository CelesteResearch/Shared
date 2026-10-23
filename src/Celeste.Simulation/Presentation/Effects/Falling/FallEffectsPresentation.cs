using Celeste.Scene.Scheduling;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Presentation.Effects.Falling
{
    public sealed class FallEffectsPresentation
    {
        public sealed class Particle
        {
            public Vector2 Position;
            public float Speed;
            public int Color;
        }

        public static float SpeedMultiplier = 1;
        public readonly Particle[] Particles = new Particle[50];
        public readonly Vector4[] Faded = new Vector4[2];
        public float Fade { get; private set; }
        public bool Enabled { get; private set; }

        public bool Active = true, Visible = true;

        // Monocle.Entity.Position is default zero for FallEffects, but remains
        // independent of its particles and can be changed through TAS queries.
        public Vector2 Position;
        public int Depth = -1000000;
        public SceneTagSet Tags = OriginalSceneTags.Global;
        public object Scene { get; private set; }
        public Action<float, float> UpdateComponents;
        readonly global::Celeste.Graphics.Content.Tiles.TileRegion pixel;

        readonly global::Celeste.Graphics.Display.ImagePlacement[] images =
            new global::Celeste.Graphics.Display.ImagePlacement[50];

        public FallEffectsPresentation(global::Celeste.Graphics.Content.Atlas.AtlasData atlas, Random random)
        {
            pixel = new global::Celeste.Graphics.Content.Tiles.TileRegion(atlas.Entries["util/pixel"], 1, 1, 1, 1);
            for (int i = 0; i < Particles.Length; i++)
                Particles[i] = new Particle
                {
                    Position = new Vector2(random.Next(0, 320), random.Next(0, 180)), Speed = random.Next(120, 240),
                    Color = random.Next(2)
                };
        }

        public static void Show(global::Celeste.Simulation.Presentation.Effects.Falling.IFallEffectsScene scene,
            bool visible)
        {
            var effects = scene.First;
            if (effects == null && visible)
            {
                effects = scene.Create();
                scene.Add(effects);
            }

            if (effects != null) effects.Enabled = visible;
            SpeedMultiplier = 1;
        }

        public void Added(object scene)
        {
            Scene = scene;
        }

        public void Removed()
        {
            Scene = null;
        }

        public void SceneEnd()
        {
        }

        public void Update(float dt, float raw)
        {
            UpdateComponents?.Invoke(dt, raw);
            for (int i = 0; i < Particles.Length; i++)
                Particles[i].Position -= Vector2.UnitY * Particles[i].Speed * SpeedMultiplier * dt;
            Fade = global::Celeste.Core.Mathematics.ScalarMath.Approach(Fade, Enabled ? 1 : 0, (Enabled ? 1 : 4) * dt);
        }

        public IReadOnlyList<global::Celeste.Graphics.Display.ImagePlacement> Images(Vector2 camera)
        {
            if (Fade <= 0) return Array.Empty<global::Celeste.Graphics.Display.ImagePlacement>();
            Faded[0] = global::Celeste.Graphics.Display.Colors.ColorMath.Scale(Vector4.One, Fade);
            Faded[1] = global::Celeste.Graphics.Display.Colors.ColorMath.Scale(
                new Vector4(211, 211, 211, 255) / 255f, Fade);
            for (int i = 0; i < Particles.Length; i++)
            {
                var p = Particles[i];
                float height = 8 * SpeedMultiplier;
                var at = new Vector2(Mod(p.Position.X - camera.X, 320), Mod(p.Position.Y - camera.Y - 16, 212)) +
                         camera;
                images[i] = new global::Celeste.Graphics.Display.ImagePlacement(pixel, (int)at.X,
                    (int)(at.Y - height / 2), Depth, 1, (int)height,
                    color: Faded[p.Color]);
            }

            return images;
        }

        static float Mod(float x, float m) => (x % m + m) % m;
    }
}

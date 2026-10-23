using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Graphics.Content.Atlas;
using Celeste.Simulation.Gameplay.Player.Events;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.Particles.Scene;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Particles
{
    public sealed class PlayerDustParticles
    {
        public ParticleTypePresentation Dust { get; }

        public ParticleTypePresentation SparkyDust { get; }

        public PlayerDustParticles(AtlasData atlas)
        {
            if (atlas == null) throw new ArgumentNullException(nameof(atlas));

            Chooser<AtlasEntry> Sources(
                string prefix)
            {
                var chooser =
                    new Chooser<AtlasEntry>();
                for (var i = 0; i < 4; i++)
                {
                    var entry = atlas.Entries[prefix + i];
                    chooser.Add(entry, 1f);
                }

                return chooser;
            }

            Dust = new()
            {
                SourceChooser = Sources("particles/smoke"),
                Color = PackedColor.White,
                Acceleration = new(0, 4), LifeMin = .3f, LifeMax = .5f, Size = .7f, SizeRange = .2f,
                Direction = (float)Math.PI / 2, DirectionRange = .5f, SpeedMin = 5, SpeedMax = 15,
                RotationMode = ParticleTypePresentation.RotationModes.Random,
                ScaleOut = true, UseActualDeltaTime = true,
            };
            SparkyDust =
                new(Dust)
                {
                    SourceChooser = Sources("particles/zappysmoke0"),
                    Color = new(91, 225, 205, 255),
                    Color2 = new(170, 250, 182, 255),
                    ColorMode = ParticleTypePresentation.ColorModes.Blink,
                };
        }

        public ParticleTypePresentation
            FromSurfaceIndex(int index)
        {
            return index == 40 ? SparkyDust : Dust;
        }

        public bool Emit(RoomPlayerEvent value,
            RoomParticleSystems systems)
        {
            if (!value.Dust.HasValue) return false;
            Emit(value.Dust.Value, systems);
            return true;
        }

        public void Emit(PlayerDustEmission emission,
            RoomParticleSystems systems)
        {
            if (systems == null) throw new ArgumentNullException(nameof(systems));
            Burst(emission.Foreground ? systems.Foreground : systems.Particles, emission.Position, emission.Angle,
                emission.Count, FromSurfaceIndex(emission.SurfaceIndex), emission.Range);
        }

        public void Burst(ParticleSystemPresentation system,
            Vector2 position, float direction, int count = 1,
            ParticleTypePresentation type = null,
            float range = 4)
        {
            type = type ?? Dust;
            var angle = direction - (float)Math.PI / 2;
            var spread = new Vector2(Math.Abs((float)Math.Cos(angle) * range),
                Math.Abs((float)Math.Sin(angle) * range));
            for (var i = 0; i < count; i++)
            {
                // Dust.Burst adds Position AFTER sampling [-spread,+spread].
                // ParticleSystem.Emit(position,range) computes a different float sum.
                var min = -spread;
                var max = spread;
                var offset = min + new Vector2((float)system.Random.NextDouble() * (max.X - min.X),
                    (float)system.Random.NextDouble() * (max.Y - min.Y));
                system.Emit(type, position + offset, direction);
            }
        }
    }
}

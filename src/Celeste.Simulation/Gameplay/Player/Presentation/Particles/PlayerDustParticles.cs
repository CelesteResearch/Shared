using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Simulation.Rendering;

namespace Celeste.Simulation.Gameplay.Player.Presentation.Particles
{
    public sealed class PlayerDustParticles
    {
        public global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation Dust { get; }

        public global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation SparkyDust
        {
            get;
        }

        public PlayerDustParticles(global::Celeste.Graphics.Content.Atlas.AtlasData atlas)
        {
            if (atlas == null) throw new ArgumentNullException(nameof(atlas));

            global::Celeste.Core.Randomness.Chooser<global::Celeste.Graphics.Content.Atlas.AtlasEntry> Sources(
                string prefix)
            {
                var chooser =
                    new global::Celeste.Core.Randomness.Chooser<global::Celeste.Graphics.Content.Atlas.AtlasEntry>();
                for (int i = 0; i < 4; i++)
                {
                    var entry = atlas.Entries[prefix + i];
                    chooser.Add(entry, 1f);
                }

                return chooser;
            }

            Dust = new global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
            {
                SourceChooser = Sources("particles/smoke"),
                Color = global::Celeste.Core.Display.PackedColor.White,
                Acceleration = new Vector2(0, 4), LifeMin = .3f, LifeMax = .5f, Size = .7f, SizeRange = .2f,
                Direction = (float)Math.PI / 2, DirectionRange = .5f, SpeedMin = 5, SpeedMax = 15,
                RotationMode = global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                    .RotationModes.Random,
                ScaleOut = true, UseActualDeltaTime = true
            };
            SparkyDust =
                new global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation(Dust)
                {
                    SourceChooser = Sources("particles/zappysmoke0"),
                    Color = new global::Celeste.Core.Display.PackedColor(91, 225, 205, 255),
                    Color2 = new global::Celeste.Core.Display.PackedColor(170, 250, 182, 255),
                    ColorMode = global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
                        .ColorModes.Blink
                };
        }

        public global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
            FromSurfaceIndex(int index) => index == 40 ? SparkyDust : Dust;

        public bool Emit(global::Celeste.Simulation.Gameplay.Player.Events.RoomPlayerEvent value,
            global::Celeste.Simulation.Presentation.Particles.Scene.RoomParticleSystems systems)
        {
            if (!value.Dust.HasValue) return false;
            Emit(value.Dust.Value, systems);
            return true;
        }

        public void Emit(global::Celeste.Simulation.Gameplay.Player.Presentation.Particles.PlayerDustEmission emission,
            global::Celeste.Simulation.Presentation.Particles.Scene.RoomParticleSystems systems)
        {
            if (systems == null) throw new ArgumentNullException(nameof(systems));
            Burst(emission.Foreground ? systems.Foreground : systems.Particles, emission.Position, emission.Angle,
                emission.Count, FromSurfaceIndex(emission.SurfaceIndex), emission.Range);
        }

        public void Burst(global::Celeste.Simulation.Presentation.Particles.ParticleSystemPresentation system,
            Vector2 position, float direction, int count = 1,
            global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation type = null,
            float range = 4)
        {
            type = type ?? Dust;
            float angle = direction - (float)Math.PI / 2;
            var spread = new Vector2(Math.Abs((float)Math.Cos(angle) * range),
                Math.Abs((float)Math.Sin(angle) * range));
            for (int i = 0; i < count; i++)
            {
                // Dust.Burst adds Position AFTER sampling [-spread,+spread].
                // ParticleSystem.Emit(position,range) computes a different float sum.
                var min = -spread;
                var max = spread;
                Vector2 offset = min + new Vector2((float)system.Random.NextDouble() * (max.X - min.X),
                    (float)system.Random.NextDouble() * (max.Y - min.Y));
                system.Emit(type, position + offset, direction);
            }
        }
    }
}

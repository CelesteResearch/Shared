using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Randomness;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Particles.Sources;
using Celeste.Graphics.Particles.Tracking;
using Celeste.Simulation.Presentation.Particles.Simulation;

namespace Celeste.Simulation.Presentation.Particles.Definitions
{
    public sealed class ParticleTypePresentation
    {
        public enum ColorModes
        {
            Static,
            Choose,
            Blink,
            Fade,
        }

        public enum FadeModes
        {
            None,
            Linear,
            Late,
            InAndOut,
        }

        public enum RotationModes
        {
            None,
            Random,
            SameAsDirection,
        }

        public AtlasEntry Source;

        public Chooser<AtlasEntry>
            SourceChooser;

        public PackedColor Color =
                PackedColor.White,
            Color2 = PackedColor.White;

        public ColorModes ColorMode;
        public FadeModes FadeMode;
        public float SpeedMin, SpeedMax, SpeedMultiplier = 1;
        public Vector2 Acceleration;
        public float Friction, Direction, DirectionRange, LifeMin, LifeMax, Size = 2, SizeRange, SpinMin, SpinMax;
        public bool SpinFlippedChance, ScaleOut, UseActualDeltaTime;
        public RotationModes RotationMode;

        public ParticleTypePresentation()
        {
        }

        public ParticleTypePresentation(ParticleTypeRegistry registry)
            : this()
        {
            registry.Register(this);
        }

        public ParticleTypePresentation(ParticleTypePresentation copy, ParticleTypeRegistry registry)
            : this(copy)
        {
            registry.Register(this);
        }

        public ParticleTypePresentation(
            ParticleTypePresentation copy)
        {
            Source = copy.Source;
            SourceChooser = copy.SourceChooser;
            Color = copy.Color;
            Color2 = copy.Color2;
            ColorMode = copy.ColorMode;
            FadeMode = copy.FadeMode;
            SpeedMin = copy.SpeedMin;
            SpeedMax = copy.SpeedMax;
            SpeedMultiplier = copy.SpeedMultiplier;
            Acceleration = copy.Acceleration;
            Friction = copy.Friction;
            Direction = copy.Direction;
            DirectionRange = copy.DirectionRange;
            LifeMin = copy.LifeMin;
            LifeMax = copy.LifeMax;
            Size = copy.Size;
            SizeRange = copy.SizeRange;
            SpinMin = copy.SpinMin;
            SpinMax = copy.SpinMax;
            SpinFlippedChance = copy.SpinFlippedChance;
            ScaleOut = copy.ScaleOut;
            UseActualDeltaTime = copy.UseActualDeltaTime;
            RotationMode = copy.RotationMode;
        }

        public ParticlePresentation Create(
            ref ParticlePresentation particle,
            Vector2 position, ISourceRandom random,
            ISourceParticleTextureEnvironment environment)
        {
            return Create(ref particle, null, position, Direction, Color, random, environment);
        }

        public ParticlePresentation Create(
            ref ParticlePresentation particle,
            IParticleTrack track, Vector2 position,
            float direction, PackedColor color,
            ISourceRandom random,
            ISourceParticleTextureEnvironment environment)
        {
            particle.Track = track;
            particle.Type = this;
            particle.Active = true;
            particle.Position = position;
            particle.Source = SourceChooser != null
                ? SourceChooser.Choose(random)
                : Source ?? environment.DefaultParticleSource;
            particle.StartSize = particle.Size =
                SizeRange != 0 ? Size - SizeRange * .5f + (float)random.NextDouble() * SizeRange : Size;
            particle.StartColor = particle.Color =
                ColorMode == ColorModes.Choose ? random.Next(2) == 0 ? color : Color2 : color;
            var angle = direction - DirectionRange / 2f + (float)random.NextDouble() * DirectionRange;
            var speed = Range(random, SpeedMin, SpeedMax);
            particle.Speed = new((float)Math.Cos(angle) * speed, (float)Math.Sin(angle) * speed);
            particle.StartLife = particle.Life = Range(random, LifeMin, LifeMax);
            particle.Rotation = RotationMode == RotationModes.Random
                ? (float)random.NextDouble() * ((float)Math.PI * 2f)
                : RotationMode == RotationModes.SameAsDirection
                    ? angle
                    : 0;
            particle.Spin = Range(random, SpinMin, SpinMax);
            if (SpinFlippedChance) particle.Spin *= random.Next(2) == 0 ? 1 : -1;
            return particle;
        }

        internal static float Range(ISourceRandom random, float min, float max)
        {
            return SourceRandomMath.Range(random, min, max);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;

namespace Celeste.Game.Stories.Farewell.Effects
{
    public class OriginalDisperseImageState : SceneEntityState
    {
        private class Particle
        {
            public Vector2 Position;

            public Vector2 Direction;

            public float Speed;

            public float Sin;

            public float Alpha;

            public float Percent;

            public float Duration;

            public AtlasEntry Image;
        }

        private readonly List<Particle> particles = [];

        private readonly Vector2 scale;

        private readonly ISourceEngineContext engine;

        public OriginalDisperseImageState(ISourceEngineContext engine, Vector2 position, Vector2 direction,
            Vector2 origin,
            Vector2 scale, AtlasEntry texture) : base(((ISourceEntitySourceDataEnvironment)engine)
            .EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            this.scale = new(Math.Abs(scale.X), Math.Abs(scale.Y));
            var num = Vector2Geometry.Angle(direction);
            for (var i = 0; i < texture.FrameWidth; i++)
            for (var j = 0; j < texture.FrameHeight; j++)
                particles.Add(new()
                {
                    Position = position + scale * (new Vector2(i, j) - origin),
                    Direction = Vector2Geometry.AngleToVector(
                        num + SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -0.2f, 0.2f), 1f),
                    Sin = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random,
                        (float)Math.PI * 2f),
                    Speed = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 0f, 4f),
                    Alpha = 1f,
                    Percent = 0f,
                    Duration = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 1f, 3f),
                    Image = texture.GetSubtexture(i, j, 1, 1),
                });
        }

        public override void Update()
        {
            var flag = false;
            foreach (var particle in particles)
            {
                particle.Percent += engine.DeltaTime / particle.Duration;
                particle.Position += particle.Direction * particle.Speed * engine.DeltaTime;
                particle.Position += (float)Math.Sin(particle.Sin) * Vector2Geometry.Perpendicular(particle.Direction) *
                                     particle.Percent * 4f * engine.DeltaTime;
                particle.Speed += engine.DeltaTime * (4f + particle.Percent * 80f);
                particle.Sin += engine.DeltaTime * 4f;
                if (particle.Percent < 1f) flag = true;
            }

            if (!flag) RemoveSelf();
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (var particle in particles)
                SourceAtlasDrawing.Draw(context, this, particle.Image, particle.Position, Vector2.Zero,
                    PackedColor.White * (1f - particle.Percent), scale);
        }
    }
}

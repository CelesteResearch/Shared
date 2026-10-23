using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

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

        private List<Particle> particles = new List<Particle>();

        private Vector2 scale;

        private readonly ISourceEngineContext engine;

        public OriginalDisperseImageState(ISourceEngineContext engine, Vector2 position, Vector2 direction,
            Vector2 origin,
            Vector2 scale, AtlasEntry texture) : base(((ISourceEntitySourceDataEnvironment)engine)
            .EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = position;
            this.scale = new Vector2(Math.Abs(scale.X), Math.Abs(scale.Y));
            float num = Vector2Geometry.Angle(direction);
            for (int i = 0; i < texture.FrameWidth; i++)
            {
                for (int j = 0; j < texture.FrameHeight; j++)
                {
                    particles.Add(new Particle
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
                        Image = texture.GetSubtexture(i, j, 1, 1)
                    });
                }
            }
        }

        public override void Update()
        {
            bool flag = false;
            foreach (Particle particle in particles)
            {
                particle.Percent += engine.DeltaTime / particle.Duration;
                particle.Position += particle.Direction * particle.Speed * engine.DeltaTime;
                particle.Position += (float)Math.Sin(particle.Sin) * Vector2Geometry.Perpendicular(particle.Direction) *
                                     particle.Percent * 4f * engine.DeltaTime;
                particle.Speed += engine.DeltaTime * (4f + particle.Percent * 80f);
                particle.Sin += engine.DeltaTime * 4f;
                if (particle.Percent < 1f)
                {
                    flag = true;
                }
            }

            if (!flag)
            {
                RemoveSelf();
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            foreach (Particle particle in particles)
            {
                SourceAtlasDrawing.Draw(context, this, particle.Image, particle.Position, Vector2.Zero,
                    PackedColor.White * (1f - particle.Percent), scale);
            }
        }
    }
}

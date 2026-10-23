using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Execution.Graphics;
using Celeste.Scene.Entities;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.ThreeD.Billboards;

namespace Celeste.Game.Presentation.Mountain.Particles
{
    public sealed class MoonParticle3DState : SceneEntityState, ISourceEngineContextEntity
    {
        public sealed class Particle : BillboardState
        {
            public Vector3 Center;
            public Matrix4x4 Matrix;
            public float Rotation, Distance, YOff, Spd;
            private readonly ISourceEngineContext engine;
            private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

            public Particle(AtlasEntry texture, PackedColor color, Vector3 center, float size,
                Matrix4x4 matrix, ISourceEngineContext engine)
                : base(texture, Vector3.Zero, null, color)
            {
                this.engine = engine;
                Center = center;
                Matrix = matrix;
                Size = Vector2.One * SourceRandomMath.Range(Random, .05f, .15f) * size;
                Distance = SourceRandomMath.Range(Random, 1.8f, 1.9f);
                Rotation = SourceRandomMath.NextFloat(Random, (float)Math.PI * 2f);
                YOff = SourceRandomMath.Range(Random, -.1f, .1f);
                Spd = SourceRandomMath.Range(Random, .8f, 1.2f);
            }

            public override void Update()
            {
                Rotation += engine.DeltaTime * .4f * Spd;
                Vector3 position = new Vector3((float)Math.Cos(Rotation) * Distance,
                    (float)Math.Sin(Rotation * 3f) * .25f + YOff,
                    (float)Math.Sin(Rotation) * Distance);
                Position = Center + SourceVector3Math.Transform(position, Matrix);
            }
        }

        private MountainModelState model;
        private List<Particle> particles = new List<Particle>();
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;
        private ISourceRandom Random => ((ISourceRandomEnvironment)engine).Random;

        public MoonParticle3DState(MountainModelState model, Vector3 center)
            : base(((ISourceEntitySourceDataEnvironment)model.EngineContext).EntitySourceDataRegistration)
        {
            engine = model.EngineContext;
            this.model = model;
            Visible = false;
            Matrix4x4 matrix = SourceMatrixMath.CreateRotationZ(.4f);
            PackedColor[] choices = new[] { PackedColor.FromHex("53f3dd"), PackedColor.FromHex("53c9f3") };
            for (int i = 0; i < 20; i++)
                Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["star"],
                    RandomSelection.Choose(Random, choices), center, 1f, matrix, engine));
            for (int j = 0; j < 30; j++)
                Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"],
                    RandomSelection.Choose(Random, choices), center, .3f, matrix, engine));
            Matrix4x4 matrix2 = SourceMatrixMath.Multiply(SourceMatrixMath.CreateRotationZ(.8f),
                SourceMatrixMath.CreateRotationX(.4f));
            PackedColor[] choices2 = new[] { PackedColor.FromHex("ab6ffa"), PackedColor.FromHex("fa70ea") };
            for (int k = 0; k < 20; k++)
                Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["star"],
                    RandomSelection.Choose(Random, choices2), center, 1f, matrix2, engine));
            for (int l = 0; l < 30; l++)
                Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"],
                    RandomSelection.Choose(Random, choices2), center, .3f, matrix2, engine));
        }

        public MoonParticle3DState(MountainModelState model, Vector3 center,
            PackedColor[] starColors1, PackedColor[] starColors2)
            : base(((ISourceEntitySourceDataEnvironment)model.EngineContext).EntitySourceDataRegistration)
        {
            engine = model.EngineContext;
            this.model = model;
            Visible = false;
            Matrix4x4 matrix = SourceMatrixMath.CreateRotationZ(.4f);
            if (starColors1.Length != 0)
            {
                for (int i = 0; i < 20; i++)
                    Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["star"],
                        RandomSelection.Choose(Random, starColors1), center, 1f, matrix, engine));
                for (int j = 0; j < 30; j++)
                    Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"],
                        RandomSelection.Choose(Random, starColors1), center, .3f, matrix, engine));
            }

            matrix = SourceMatrixMath.Multiply(SourceMatrixMath.CreateRotationZ(.8f),
                SourceMatrixMath.CreateRotationX(.4f));
            if (starColors2.Length != 0)
            {
                for (int k = 0; k < 20; k++)
                    Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["star"],
                        RandomSelection.Choose(Random, starColors2), center, 1f, matrix, engine));
                for (int l = 0; l < 30; l++)
                    Add(new Particle(((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"],
                        RandomSelection.Choose(Random, starColors2), center, .3f, matrix, engine));
            }
        }

        public override void Update()
        {
            base.Update();
            Visible = model.StarEase > 0f;
        }
    }
}

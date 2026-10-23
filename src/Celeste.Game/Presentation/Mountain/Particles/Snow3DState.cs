using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Geometry.Intersections;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Scene.Scenes;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.ThreeD.Billboards;

namespace Celeste.Game.Presentation.Mountain.Particles
{
    public sealed class Snow3DState : SceneEntityState, ISourceEngineContextEntity
    {
        public sealed class Particle : BillboardState
        {
            public Snow3DState Manager;
            public Vector2 Float;
            public float Percent, Duration, Speed;
            private float size;
            private ISourceRandom Random => ((ISourceRandomEnvironment)Manager.engine).Random;

            public Particle(Snow3DState manager, float size)
                : base(((IOriginalOverworldGraphicsEnvironment)manager.engine).OverworldGraphics.Atlas["snow"],
                    Vector3.Zero)
            {
                Manager = manager;
                this.size = size;
                Size = Vector2.One * size;
                Reset(SourceRandomMath.NextFloat(Random));
                ResetPosition();
            }

            public void ResetPosition()
            {
                float range = Manager.Range;
                Position = Manager.Model.Camera.Position + Manager.Model.Forward * range * .5f +
                           new Vector3(SourceRandomMath.Range(Random, 0f - range, range),
                               SourceRandomMath.Range(Random, 0f - range, range),
                               SourceRandomMath.Range(Random, 0f - range, range));
            }

            public void Reset(float percent = 0f)
            {
                float num = Manager.Range / 30f;
                Speed = SourceRandomMath.Range(Random, 1f, 6f) * num;
                Percent = percent;
                Duration = SourceRandomMath.Range(Random, 1f, 5f);
                Float = ((ISourceVectorEnvironment)Manager.engine).VectorArithmetic.SafeNormalize(
                    new Vector2(SourceRandomMath.Range(Random, -1, 1), SourceRandomMath.Range(Random, -1, 1))) * .25f;
                Scale = Vector2.One * .05f * num;
            }

            public override void Update()
            {
                if (Percent > 1f || !InView())
                {
                    ResetPosition();
                    int num = 0;
                    while (!InView() && num++ < 10) ResetPosition();
                    if (num > 10)
                    {
                        Color = PackedColor.Transparent;
                        return;
                    }

                    Reset(!InLastView() ? SourceRandomMath.NextFloat(Random) : 0f);
                }

                Percent += Manager.engine.DeltaTime / Duration;
                float num2 = ScalarMath.YoYo(Percent);
                if (Manager.Model.SnowForceFloat > 0f) num2 *= Manager.Model.SnowForceFloat;
                else if (Manager.Model.StarEase > 0f) num2 *= ScalarMath.Map(Manager.Model.StarEase, 0f, 1f, 1f, 0f);
                Color = PackedColor.White * num2;
                Size.Y = size + Manager.Model.SnowStretch * (1f - Manager.Model.SnowForceFloat);
                Position.Y -= (Speed + Manager.Model.SnowSpeedAddition) * (1f - Manager.Model.SnowForceFloat) *
                              Manager.engine.DeltaTime;
                Position.X += Float.X * Manager.engine.DeltaTime;
                Position.Z += Float.Y * Manager.engine.DeltaTime;
            }

            private bool InView()
            {
                if (Manager.Frustum.Contains(Position) == ContainmentType.Contains) return Position.Y > 0f;
                return false;
            }

            private bool InLastView()
            {
                if (Manager.LastFrustum != null)
                    return Manager.LastFrustum.Contains(Position) == ContainmentType.Contains;
                return false;
            }
        }

        private static PackedColor[] alphas = new PackedColor[32];
        private List<Particle> particles = new List<Particle>();
        private BoundingFrustum Frustum;
        private BoundingFrustum LastFrustum;
        private MountainModelState Model;
        private float Range = 30f;
        private readonly ISourceEngineContext engine;
        ISourceEngineContext ISourceEngineContextEntity.EngineContext => engine;

        public Snow3DState(MountainModelState model)
            : base(((ISourceEntitySourceDataEnvironment)model.EngineContext).EntitySourceDataRegistration)
        {
            engine = model.EngineContext;
            Frustum = new BoundingFrustum(Matrix4x4.Identity, ((ISourceVectorEnvironment)engine).VectorArithmetic,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            LastFrustum = new BoundingFrustum(Matrix4x4.Identity, ((ISourceVectorEnvironment)engine).VectorArithmetic,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            Model = model;
            for (int i = 0; i < alphas.Length; i++) alphas[i] = PackedColor.White * ((float)i / (float)alphas.Length);
            for (int j = 0; j < 400; j++)
            {
                Particle particle = new Particle(this, 1f);
                particles.Add(particle);
                Add(particle);
            }
        }

        public override void Update()
        {
            OverworldSequence overworld = Scene as OverworldSequence;
            Range = 20f;
            if (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave != null && overworld != null &&
                (overworld.IsCurrent<ChapterPanelSequence>() || overworld.IsCurrent<ChapterSelectSequence>()))
            {
                switch (((IOriginalGameplayProcess)engine).SaveContext.CurrentSave.LastArea.ID)
                {
                    case 0:
                    case 2:
                    case 8: Range = 3f; break;
                    case 1: Range = 12f; break;
                }
            }

            var graphics = ((IOriginalEngineGraphicsEnvironment)engine).EngineGraphics;
            Matrix4x4 matrix = SourceMatrixMath.CreatePerspectiveFieldOfView((float)Math.PI * 5f / 16f,
                (float)graphics.Width / (float)graphics.Height, .1f, Range);
            Matrix4x4 matrix2 = SourceMatrixMath.Multiply(SourceMatrixMath.Multiply(
                SourceMatrixMath.CreateTranslation(-Model.Camera.Position),
                SourceMatrixMath.CreateFromQuaternion(Model.Camera.Rotation)), matrix);
            if (((SourceSceneState)Scene).OnInterval(.05f)) LastFrustum.Matrix = matrix2;
            Frustum.Matrix = matrix2;
            base.Update();
        }
    }
}

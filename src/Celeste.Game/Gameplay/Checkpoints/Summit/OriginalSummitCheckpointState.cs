using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation;

namespace Celeste.Game.Gameplay.Checkpoints.Summit
{
    public partial class OriginalSummitCheckpointState : SceneEntityState
    {
        public class ConfettiRenderer : SceneEntityState
        {
            private struct Particle
            {
                public Vector2 Position;

                public PackedColor Color;

                public Vector2 Speed;

                public float Timer;

                public float Percent;

                public float Duration;

                public float Alpha;

                public float Approach;
            }

            private static PackedColor[] confettiColors = new PackedColor[3]
            {
                PackedColor.FromHex("fe2074"),
                PackedColor.FromHex("205efe"),
                PackedColor.FromHex("cefe20")
            };

            private Particle[] particles = new Particle[30];

            private readonly ISourceEngineContext engine;

            public ConfettiRenderer(ISourceEngineContext engine, Vector2 position)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
            {
                this.engine = engine;
                base.Depth = -10010;
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].Position = SourceVector2Math.Add(Position,
                        new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -3, 3),
                            SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -3, 3)));
                    particles[i].Color =
                        RandomSelection.Choose(((ISourceRandomEnvironment)engine).Random, confettiColors);
                    particles[i].Timer = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                    particles[i].Duration = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 2, 4);
                    particles[i].Alpha = 1f;
                    float angleRadians = -(float)Math.PI / 2f +
                                         SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -0.5f, 0.5f);
                    int num = SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 140, 220);
                    particles[i].Speed = Vector2Geometry.AngleToVector(angleRadians, num);
                }
            }

            public override void Update()
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    particles[i].Position = SourceVector2Math.Add(particles[i].Position,
                        SourceVector2Math.Multiply(particles[i].Speed, engine.DeltaTime));
                    particles[i].Speed.X = ScalarMath.Approach(particles[i].Speed.X, 0f, 80f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    particles[i].Speed.Y = ScalarMath.Approach(particles[i].Speed.Y, 20f, 500f * engine.DeltaTime,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    particles[i].Timer += engine.DeltaTime;
                    particles[i].Percent += engine.DeltaTime / particles[i].Duration;
                    particles[i].Alpha = ScalarMath.ClampedMap(particles[i].Percent, 0.9f, 1f, 1f, 0f);
                    if (particles[i].Speed.Y > 0f)
                    {
                        particles[i].Approach = ScalarMath.Approach(particles[i].Approach, 5f, engine.DeltaTime * 16f,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                    }
                }
            }

            public override void Render(ISourceRenderContext context)
            {
                for (int i = 0; i < particles.Length; i++)
                {
                    float num = 0f;
                    Vector2 position = particles[i].Position;
                    if (particles[i].Speed.Y < 0f)
                    {
                        num = Vector2Geometry.Angle(particles[i].Speed);
                    }
                    else
                    {
                        num = (float)Math.Sin(particles[i].Timer * 4f) * 1f;
                        position = SourceVector2Math.Add(position,
                            Vector2Geometry.AngleToVector((float)Math.PI / 2f + num, particles[i].Approach));
                    }

                    SourceAtlasDrawing.DrawCentered(context, this,
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["particles/confetti"],
                        SourceVector2Math.Add(position, Vector2.UnitY), PackedColor.Black * (particles[i].Alpha * 0.5f),
                        1f,
                        num);
                    SourceAtlasDrawing.DrawCentered(context, this,
                        ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["particles/confetti"], position,
                        particles[i].Color * particles[i].Alpha, 1f, num);
                }
            }
        }

        private const string Flag = "summit_checkpoint_";

        public bool Activated;

        public readonly int Number;

        private string numberString;

        private Vector2 respawn;

        private AtlasEntry baseEmpty;

        private AtlasEntry baseToggle;

        private AtlasEntry baseActive;

        private List<AtlasEntry> numbersEmpty;

        private List<AtlasEntry> numbersActive;

        private readonly ISourceEngineContext engine;

        public OriginalSummitCheckpointState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration,
                SourceVector2Math.Add(data.Position, offset))
        {
            this.engine = engine;
            Number = EntityAttributeReader.Int(data.Values, "number");
            numberString = Number.ToString("D2");
            baseEmpty =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/summitcheckpoints/base00"];
            baseToggle =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/summitcheckpoints/base01"];
            baseActive =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["scenery/summitcheckpoints/base02"];
            numbersEmpty =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "scenery/summitcheckpoints/numberbg");
            numbersActive =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas.GetAtlasSubtextures(
                    "scenery/summitcheckpoints/number");
            base.Collider = new HitboxColliderGeometry(32f, 32f, -16f, -8f);
            base.Depth = 8999;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if ((scene as OriginalLevelSceneRoot).Session.GetFlag("summit_checkpoint_" + Number))
            {
                Activated = true;
            }

            respawn = (Scene as OriginalLevelSceneRoot).GetSpawnPoint(Position);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!Activated && CollideCheck(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName))

            {
                Activated = true;
                OriginalLevelSceneRoot obj = base.Scene as OriginalLevelSceneRoot;
                obj.Session.SetFlag("summit_checkpoint_" + Number);
                obj.Session.RespawnPoint = respawn;
            }
        }

        public override void Update()
        {
            if (!Activated)
            {
                RoomPlayerSession player =
                    CollideFirst<RoomPlayerSession>(typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (player != null && player.OnGround() && player.Data.Motion.Normal.Speed.Y >= 0f)
                {
                    OriginalLevelSceneRoot obj = base.Scene as OriginalLevelSceneRoot;
                    Activated = true;
                    obj.Session.SetFlag("summit_checkpoint_" + Number);
                    obj.Session.RespawnPoint = respawn;
                    obj.Session.UpdateLevelStartDashes();
                    obj.Session.HitCheckpoint = true;
                    obj.Displacement.AddBurst(Position, 0.5f, 4f, 24f, 0.5f);
                    obj.SourceScene.QueueSourceEntity(new ConfettiRenderer(engine, Position));
                    ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/game/07_summit/checkpoint_confetti",
                        Position, ((IOriginalGameplayProcess)engine).SaveContext);
                }
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            List<AtlasEntry> obj = (Activated ? numbersActive : numbersEmpty);
            AtlasEntry mTexture = baseActive;
            if (!Activated)
            {
                mTexture = (((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(0.25f) ? baseEmpty : baseToggle);
            }

            SourceAtlasDrawing.Draw(context, this, mTexture,
                SourceVector2Math.Subtract(Position,
                    new Vector2(mTexture.FrameWidth / 2 + 1, mTexture.FrameHeight / 2)));
            SourceAtlasDrawing.DrawJustified(context, this, obj[numberString[0] - 48],
                SourceVector2Math.Add(Position, new Vector2(-1f, 1f)), new Vector2(1f, 0f), PackedColor.White);
            SourceAtlasDrawing.DrawJustified(context, this, obj[numberString[1] - 48],
                SourceVector2Math.Add(Position, new Vector2(0f, 1f)), new Vector2(0f, 0f), PackedColor.White);
        }
    }
}

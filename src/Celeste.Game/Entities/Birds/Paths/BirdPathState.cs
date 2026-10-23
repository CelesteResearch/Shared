using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Display;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Birds.Paths
{
    public class BirdPathState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;
        protected float SourceSpeedMultiplier => speedMult;
        protected Vector2 SourceSpeed => speed;
        protected virtual float RoutineSpeedMultiplier => speedMult;

        protected virtual float CalculateRotation()
        {
            float startAngle = (float)Math.Atan2(speed.Y, speed.X);
            float endAngle = (float)Math.Atan2(target.Y - Position.Y, target.X - Position.X);
            float angle = ScalarMath.AngleLerp(startAngle, endAngle, 0.5f);
            return (float)Math.PI / 2f + angle;
        }

        private Vector2 start;

        private Sprite sprite;

        private Vector2[] nodes;

        private PackedColor trailColor = new PackedColor(99, 155, 255, 255);

        private Vector2 target;

        private Vector2 speed;

        private float maxspeed;

        private Vector2 lastTrail;

        private float speedMult;

        private MapEntityId ID;

        private bool onlyOnce;

        private bool onlyIfLeft;

        public BirdPathState(MapEntityId id, EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(id, data.Position + offset, data.NodesOffset(offset),
                EntityAttributeReader.Bool(data.Values, "only_once"),
                EntityAttributeReader.Bool(data.Values, "onlyIfLeft"),
                EntityAttributeReader.Float(data.Values, "speedMult", 1f), engine)
        {
        }

        public BirdPathState(MapEntityId id, Vector2 position, Vector2[] nodes, bool onlyOnce, bool onlyIfLeft,
            float speedMult, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((ISourcePersistentTransitionExecutionTagsEnvironment)engine).PersistentTransitionExecutionTags
                .TransitionUpdate.Value;
            ID = id;
            Position = position;
            start = position;
            this.nodes = nodes;
            this.onlyOnce = onlyOnce;
            this.onlyIfLeft = onlyIfLeft;
            this.speedMult = speedMult;
            maxspeed = 150f * speedMult;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("bird"));
            sprite.Play("flyupRoll");
            sprite.JustifyOrigin(0.5f, 0.75f);
            var initialSound = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            initialSound.Play("event:/new_content/game/10_farewell/bird_flyuproll");
            initialSound.RemoveOnOneshotEnd = true;
            OwnedComponents.Add(initialSound);
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        public void WaitForTrigger()
        {
            Visible = (Active = false);
        }

        public void Trigger()
        {
            Visible = (Active = true);
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (onlyOnce)
            {
                ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(ID);
            }
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (onlyIfLeft)
            {
                RoomPlayerSession entity =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                        typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);

                if (entity != null && entity.X > base.X)
                {
                    RemoveSelf();
                }
            }
        }

        private IEnumerator Routine()
        {
            Vector2 begin = start;
            for (int i = 0; i <= nodes.Length - 1; i += 2)
            {
                Vector2 control = nodes[i];
                Vector2 next = nodes[i + 1];
                SimpleCurve curve = new SimpleCurve(begin, next, control);
                float lengthParametric = curve.GetLengthParametric(32,
                    ((ISourceCurveEnvironment)engine).CurveArithmetic,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                float duration = lengthParametric / maxspeed;
                bool playedSfx = false;
                _ = Position;
                for (float p = 0f; p < 1f; p += engine.DeltaTime * RoutineSpeedMultiplier / duration)
                {
                    target = curve.GetPoint(p, ((ISourceCurveEnvironment)engine).CurveArithmetic);
                    if (p > 0.9f)
                    {
                        if (!playedSfx && sprite.CurrentAnimationID != "flyupRoll")
                        {
                            SoundSourceComponentState soundSource =
                                ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
                            soundSource.Play("event:/new_content/game/10_farewell/bird_flyuproll");
                            soundSource.RemoveOnOneshotEnd = true;
                            OwnedComponents.Add(soundSource);
                            playedSfx = true;
                        }

                        sprite.Play("flyupRoll");
                    }

                    yield return null;
                }

                begin = next;
            }

            RemoveSelf();
        }

        public override void Update()
        {
            if (((OriginalLevelSceneRoot)Scene).Transitioning)
            {
                using (IEnumerator<SourceComponentState> enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        if (enumerator.Current is SoundSourceComponentState soundSource)
                        {
                            soundSource.UpdateSfxPosition();
                        }
                    }

                    return;
                }
            }

            base.Update();
            int num = Math.Sign(base.X - target.X);
            Vector2 vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(target - Position);
            float num2 = 800f;
            speed += vector * num2 * engine.DeltaTime;
            if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(speed) > maxspeed)
            {
                speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(speed, maxspeed);
            }

            Position += speed * engine.DeltaTime;
            if (num != Math.Sign(base.X - target.X))
            {
                speed.X *= 0.75f;
            }

            sprite.Rotation = CalculateRotation();
            if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(lastTrail - Position) > 32f)
            {
                TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this, trailColor);
                lastTrail = Position;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
        }

        public override void DebugRender(ISourceRenderContext context, object actualCamera)
        {
            Vector2 begin = start;
            for (int i = 0; i < nodes.Length - 1; i += 2)
            {
                Vector2 vector = nodes[i + 1];
                SourceSimpleCurveDrawing.Render(context, this, new SimpleCurve(begin, vector, nodes[i]), Vector2.Zero,
                    PackedColor.Red * 0.25f, 32, ((ISourceCurveEnvironment)engine).CurveArithmetic,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                begin = vector;
            }

            SourcePrimitiveDrawing.Line(context, this, Position,
                Position + ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(target - Position) *
                (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(target - Position) - 3f),
                PackedColor.Yellow,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
            SourcePrimitiveDrawing.Circle(context, this, target, 3f, PackedColor.Yellow, 16,
                ((ISourceVectorEnvironment)engine).VectorArithmetic);
        }
    }
}

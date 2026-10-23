using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Scheduling.ExecutionTags;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Entities.Birds.Paths
{
    public class BirdPathState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;
        protected float SourceSpeedMultiplier { get; }

        protected Vector2 SourceSpeed => speed;
        protected virtual float RoutineSpeedMultiplier => SourceSpeedMultiplier;

        protected virtual float CalculateRotation()
        {
            var startAngle = (float)Math.Atan2(speed.Y, speed.X);
            var endAngle = (float)Math.Atan2(target.Y - Position.Y, target.X - Position.X);
            var angle = ScalarMath.AngleLerp(startAngle, endAngle, 0.5f);
            return (float)Math.PI / 2f + angle;
        }

        private readonly Vector2 start;

        private readonly Sprite sprite;

        private readonly Vector2[] nodes;

        private readonly PackedColor trailColor = new(99, 155, 255, 255);

        private Vector2 target;

        private Vector2 speed;

        private readonly float maxspeed;

        private Vector2 lastTrail;

        private readonly MapEntityId ID;

        private readonly bool onlyOnce;

        private readonly bool onlyIfLeft;

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
            SourceSpeedMultiplier = speedMult;
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
            Visible = Active = false;
        }

        public void Trigger()
        {
            Visible = Active = true;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            if (onlyOnce) ((OriginalLevelSceneRoot)Scene).Session.DoNotLoad.Add(ID);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!onlyIfLeft)
                return;
            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && entity.X > X) RemoveSelf();
        }

        private IEnumerator Routine()
        {
            var begin = start;
            for (var i = 0; i <= nodes.Length - 1; i += 2)
            {
                var control = nodes[i];
                var next = nodes[i + 1];
                var curve = new SimpleCurve(begin, next, control);
                var lengthParametric = curve.GetLengthParametric(32,
                    ((ISourceCurveEnvironment)engine).CurveArithmetic,
                    ((ISourceVectorEnvironment)engine).VectorArithmetic);
                var duration = lengthParametric / maxspeed;
                var playedSfx = false;
                _ = Position;
                for (var p = 0f; p < 1f; p += engine.DeltaTime * RoutineSpeedMultiplier / duration)
                {
                    target = curve.GetPoint(p, ((ISourceCurveEnvironment)engine).CurveArithmetic);
                    if (p > 0.9f)
                    {
                        if (!playedSfx && sprite.CurrentAnimationID != "flyupRoll")
                        {
                            var soundSource =
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
                using (var enumerator = GetEnumerator())
                {
                    while (enumerator.MoveNext())
                        if (enumerator.Current is SoundSourceComponentState soundSource)
                            soundSource.UpdateSfxPosition();

                    return;
                }

            base.Update();
            var num = Math.Sign(X - target.X);
            var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(target - Position);
            var num2 = 800f;
            speed += vector * num2 * engine.DeltaTime;
            if (((ISourceVectorEnvironment)engine).VectorArithmetic.Length(speed) > maxspeed)
                speed = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(speed, maxspeed);

            Position += speed * engine.DeltaTime;
            if (num != Math.Sign(X - target.X)) speed.X *= 0.75f;

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
            var begin = start;
            for (var i = 0; i < nodes.Length - 1; i += 2)
            {
                var vector = nodes[i + 1];
                SourceSimpleCurveDrawing.Render(context, this, new(begin, vector, nodes[i]), Vector2.Zero,
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

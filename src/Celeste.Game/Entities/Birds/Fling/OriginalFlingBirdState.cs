using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Gameplay.FlingBirds;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Rendering;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Hazards.Lightning;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;

namespace Celeste.Game.Entities.Birds.Fling
{
    public class OriginalFlingBirdState : SceneEntityState, ISourceFlingBird
    {
        private readonly ISourceEngineContext engine;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;

        private enum States
        {
            Wait,
            Fling,
            Move,
            WaitForLightningClear,
            Leaving,
        }


        public const float SkipDist = 100f;

        private Vector2 FlingSpeed => ((ISourceFlingBirdEnvironment)engine).FlingBirdStatics.FlingSpeed;

        private readonly Vector2 spriteOffset = new(0f, 8f);

        private readonly Sprite sprite;

        private States state;

        private Vector2 flingSpeed;

        private Vector2 flingTargetSpeed;

        private float flingAccel;

        private readonly PackedColor trailColor = new(99, 155, 255);

        private readonly OriginalLevelEntityData entityData;

        private readonly SoundSourceComponentState moveSfx;

        private int segmentIndex;

        public List<Vector2[]> NodeSegments;

        public List<bool> SegmentsWaiting;

        public bool LightningRemoved;

        public OriginalFlingBirdState(ISourceEngineContext engine, Vector2[] nodes, bool skippable)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, nodes[0])
        {
            this.engine = engine;
            Depth = -1;
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("bird"));
            sprite.Play("hover");
            sprite.Scale.X = -1f;
            sprite.Position = spriteOffset;
            sprite.OnFrameChange = delegate { BirdNpcState.FlapSfxCheck(engine, sprite); };
            Collider = new CircleColliderGeometry(VectorArithmetic, 16f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(moveSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            NodeSegments = [];
            // ReSharper disable once AppendToCollectionExpression
            NodeSegments.Add(nodes);
            SegmentsWaiting = [];
            // ReSharper disable once AppendToCollectionExpression
            SegmentsWaiting.Add(skippable);
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOut = delegate(float t) { sprite.Color = PackedColor.White * (1f - ScalarMath.Map(t, 0f, 0.4f)); },
            });
        }

        public OriginalFlingBirdState(OriginalLevelEntityData data, Vector2 levelOffset, ISourceEngineContext engine)
            : this(engine, data.NodesWithPosition(levelOffset), EntityAttributeReader.Bool(data.Values, "waiting"))
        {
            entityData = data;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            var
                list = ((ISourceScene)Scene).SourceScene.Entities.FindAll<OriginalFlingBirdState>();
            for (var num = list.Count - 1; num >= 0; num--)
                if (list[num].entityData.Level.Name != entityData.Level.Name)
                    list.RemoveAt(num);

            list.Sort((a, b) => Math.Sign(a.X - b.X));
            if (list[0] == this)
                for (var num2 = 1; num2 < list.Count; num2++)
                {
                    NodeSegments.Add(list[num2].NodeSegments[0]);
                    SegmentsWaiting.Add(list[num2].SegmentsWaiting[0]);
                    list[num2].RemoveSelf();
                }

            if (SegmentsWaiting[0])
            {
                sprite.Play("hoverStressed");
                sprite.Scale.X = 1f;
            }

            var entity =
                ((ISourceScene)scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && entity.X > X) RemoveSelf();
        }

        private void Skip()
        {
            state = States.Move;
            OwnedComponents.Add(new SimulationCoroutine(engine, MoveRoutine()));
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (state == States.Wait && player.DoFlingBird(this))
            {
                flingSpeed = player.Data.Motion.Normal.Speed * 0.4f;
                flingSpeed.Y = 120f;
                flingTargetSpeed = Vector2.Zero;
                flingAccel = 1000f;
                player.Data.Motion.Normal.Speed = Vector2.Zero;
                state = States.Fling;
                OwnedComponents.Add(new SimulationCoroutine(engine, DoFlingRoutine(player)));
                ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/new_content/game/10_farewell/bird_throw",
                    Center, ((IOriginalGameplayProcess)engine).SaveContext);
            }
        }

        public override void Update()
        {
            base.Update();
            if (state != States.Wait)
                sprite.Position = VectorArithmetic.Approach(sprite.Position, spriteOffset, 32f * engine.DeltaTime);

            switch (state)
            {
                case States.Wait:
                {
                    var entity =
                        ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                            typeof(RoomPlayerSession).FullName);

                    if (entity != null && entity.X - X >= 100f)
                    {
                        Skip();
                    }
                    else if (SegmentsWaiting[segmentIndex] && LightningRemoved)
                    {
                        Skip();
                    }
                    else if (entity != null)
                    {
                        var num = ScalarMath.ClampedMap(VectorArithmetic.Length(entity.Center - Position), 16f, 64f,
                            12f,
                            0f);
                        var vector = VectorArithmetic.SafeNormalize(entity.Center - Position);
                        sprite.Position = VectorArithmetic.Approach(sprite.Position, spriteOffset + vector * num,
                            32f * engine.DeltaTime);
                    }

                    break;
                }
                case States.Fling:
                    if (flingAccel > 0f)
                        flingSpeed = VectorArithmetic.Approach(flingSpeed, flingTargetSpeed,
                            flingAccel * engine.DeltaTime);

                    Position += flingSpeed * engine.DeltaTime;
                    break;
                case States.WaitForLightningClear:
                    if (((ISourceScene)Scene).SourceScene.Entities
                        .FindFirst<LightningState>() == null ||
                        X > (Scene as OriginalLevelSceneRoot).Bounds.Right)
                    {
                        sprite.Scale.X = 1f;
                        state = States.Leaving;
                        OwnedComponents.Add(new SimulationCoroutine(engine, LeaveRoutine()));
                    }

                    break;
                case States.Move:
                    break;
            }
        }

        private IEnumerator DoFlingRoutine(RoomPlayerSession player)
        {
            var level = Scene as OriginalLevelSceneRoot;
            var position = level.Camera.Position;
            var screenSpaceFocusPoint = player.Position - position;
            screenSpaceFocusPoint.X = ScalarMath.Clamp(screenSpaceFocusPoint.X, 145f, 215f);
            screenSpaceFocusPoint.Y = ScalarMath.Clamp(screenSpaceFocusPoint.Y, 85f, 95f);
            OwnedComponents.Add(new SimulationCoroutine(engine, level.ZoomTo(screenSpaceFocusPoint, 1.1f, 0.2f)));
            engine.Effects.TimeRate = 0.8f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);
            while (flingSpeed != Vector2.Zero) yield return null;

            sprite.Play("throw");
            sprite.Scale.X = 1f;
            flingSpeed = new(-140f, 140f);
            flingTargetSpeed = Vector2.Zero;
            flingAccel = 1400f;
            yield return 0.1f;
            OriginalCelesteFreeze.Freeze(engine, 0.05f);
            flingTargetSpeed = FlingSpeed;
            flingAccel = 6000f;
            yield return 0.1f;
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            engine.Effects.TimeRate = 1f;
            level.Shake();
            OwnedComponents.Add(new SimulationCoroutine(engine, level.ZoomBack(0.1f)));
            player.FinishFlingBird();
            flingTargetSpeed = Vector2.Zero;
            flingAccel = 4000f;
            yield return 0.3f;
            OwnedComponents.Add(new SimulationCoroutine(engine, MoveRoutine()));
        }

        private IEnumerator MoveRoutine()
        {
            state = States.Move;
            sprite.Play("fly");
            sprite.Scale.X = 1f;
            moveSfx.Play("event:/new_content/game/10_farewell/bird_relocate");
            for (var nodeIndex = 1; nodeIndex < NodeSegments[segmentIndex].Length - 1; nodeIndex += 2)
            {
                var position = Position;
                var anchor = NodeSegments[segmentIndex][nodeIndex];
                var to = NodeSegments[segmentIndex][nodeIndex + 1];
                yield return MoveOnCurve(position, anchor, to);
            }

            segmentIndex++;
            var atEnding = segmentIndex >= NodeSegments.Count;
            if (!atEnding)
            {
                var position2 = Position;
                var anchor2 = NodeSegments[segmentIndex - 1][NodeSegments[segmentIndex - 1].Length - 1];
                var to2 = NodeSegments[segmentIndex][0];
                yield return MoveOnCurve(position2, anchor2, to2);
            }

            sprite.Rotation = 0f;
            sprite.Scale = Vector2.One;
            if (atEnding)
            {
                sprite.Play("hoverStressed");
                sprite.Scale.X = 1f;
                state = States.WaitForLightningClear;
                yield break;
            }

            if (SegmentsWaiting[segmentIndex])
                sprite.Play("hoverStressed");
            else
                sprite.Play("hover");

            sprite.Scale.X = -1f;
            state = States.Wait;
        }

        private IEnumerator LeaveRoutine()
        {
            sprite.Scale.X = 1f;
            sprite.Play("fly");
            var vector = new Vector2((Scene as OriginalLevelSceneRoot).Bounds.Right + 32, Y);
            yield return MoveOnCurve(Position, (Position + vector) * 0.5f - Vector2.UnitY * 12f, vector);
            RemoveSelf();
        }

        private IEnumerator MoveOnCurve(Vector2 from, Vector2 anchor, Vector2 to)
        {
            var curve = new SimpleCurve(from, to, anchor);
            var duration = curve.GetLengthParametric(32, CurveArithmetic, VectorArithmetic) / 500f;
            _ = from;
            var was = from;
            for (var t = 0.016f; t <= 1f; t += engine.DeltaTime / duration)
            {
                Position = Vector2Geometry.Floor(CurveArithmetic.GetPoint(curve, t));
                sprite.Rotation = Vector2Geometry.Angle(CurveArithmetic.GetPoint(curve, Extrema.Max(0f, t - .05f)),
                    CurveArithmetic.GetPoint(curve, Extrema.Min(1f, t + .05f)));
                sprite.Scale.X = 1.25f;
                sprite.Scale.Y = 0.7f;
                if (VectorArithmetic.Length(was - Position) > 32f)
                {
                    TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this, trailColor);
                    was = Position;
                }

                yield return null;
            }

            Position = to;
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
        }

        private void DrawLine(ISourceRenderContext context, Vector2 a, Vector2 anchor, Vector2 b)
        {
            var curve = new SimpleCurve(a, b, anchor);
            var start = curve.Begin;
            for (var i = 1; i <= 32; i++)
            {
                var point = CurveArithmetic.GetPoint(curve, i / 32f);
                SourcePrimitiveDrawing.Line(context, this, start, point, PackedColor.Red, VectorArithmetic);
                start = point;
            }
        }
    }
}

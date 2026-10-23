using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Entities.Platforms.Barriers;
using Celeste.Game.Execution.Engine.Actions;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Platforms.Cassette;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Player.Collision.Components;

namespace Celeste.Game.Entities.Birds.Fling
{
    public class OriginalFlingBirdIntroState : SceneEntityState
    {
        public Vector2 BirdEndPosition;

        public Sprite Sprite;

        public SoundEmitterState CrashSfxEmitter;

        private readonly Vector2[] nodes;

        private bool startedRoutine;

        private Vector2 start;

        private OriginalInvisibleBarrierState fakeRightWall;

        private readonly bool crashes;

        private SimulationCoroutine flyToRoutine;

        private bool emitParticles;

        private bool inCutscene;

        private readonly ISourceEngineContext engine;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private OriginalLevelSceneRoot SourceLevel => (OriginalLevelSceneRoot)Scene;

        public OriginalFlingBirdIntroState(ISourceEngineContext engine, Vector2 position, Vector2[] nodes, bool crashes)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.crashes = crashes;
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("bird"));
            Sprite.Play(crashes ? "hoverStressed" : "hover");
            Sprite.Scale.X = !crashes ? 1 : -1;
            Sprite.OnFrameChange = delegate
            {
                if (!inCutscene) BirdNpcState.FlapSfxCheck(engine, Sprite);
            };
            Collider = new CircleColliderGeometry(VectorArithmetic, 16f, 0f, -8f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            this.nodes = nodes;
            start = position;
            BirdEndPosition = nodes[nodes.Length - 1];
        }

        public OriginalFlingBirdIntroState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(engine, data.Position + offset, data.NodesOffset(offset),
                EntityAttributeReader.Bool(data.Values, "crashes"))
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (!crashes && (scene as OriginalLevelSceneRoot).Session.GetFlag("MissTheBird"))
            {
                RemoveSelf();
                return;
            }

            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(RoomPlayerSession).FullName);

            if (entity != null && entity.X > X)
            {
                if (crashes) CS10CatchTheBirdState.HandlePostCutsceneSpawn(this, scene as OriginalLevelSceneRoot);

                var entity2 =
                    ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalCassetteBlockManagerState>(
                        "Celeste.CassetteBlockManager");
                if (entity2 != null)
                {
                    entity2.StopBlocks();
                    entity2.Finish();
                }

                RemoveSelf();
            }
            else
            {
                SourceLevel.Scheduler.QueueSourceEntity(fakeRightWall = new(engine,
                    new(X + 160f, Y - 200f), 8f, 400f, SourceLevel.SolidWorldFactory));
            }

            if (!crashes)
            {
                var position = Position;
                Position = new(X - 150f, (scene as OriginalLevelSceneRoot).Bounds.Top - 8);
                OwnedComponents.Add(flyToRoutine = new(engine, FlyTo(position)));
            }
        }

        private IEnumerator FlyTo(Vector2 to)
        {
            OwnedComponents.Add(((ISourceSoundSourceEnvironment)engine).SoundSources.Create()
                .Play("event:/new_content/game/10_farewell/bird_flappyscene_entry"));
            Sprite.Play("fly");
            var from = Position;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 0.3f)
            {
                Position = from + (to - from) * ((ISourceEasingEnvironment)engine).EasingArithmetic.SineOut(p);
                yield return null;
            }

            Sprite.Play("hover");
            var sine = 0f;
            while (true)
            {
                Position = to + Vector2.UnitY * (float)Math.Sin(sine) * 8f;
                sine += engine.DeltaTime * 2f;
                yield return null;
            }
        }

        public override void Removed(object scene)
        {
            if (fakeRightWall != null) fakeRightWall.RemoveSelf();

            fakeRightWall = null;
            base.Removed(scene);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (player.Dead || startedRoutine) return;

            if (flyToRoutine != null) flyToRoutine.RemoveSelf();

            startedRoutine = true;
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            Depth = player.Depth - 5;
            Sprite.Play("hoverStressed");
            Sprite.Scale.X = 1f;
            fakeRightWall.RemoveSelf();
            fakeRightWall = null;
            if (!crashes)
            {
                SourceLevel.Scheduler.QueueSourceEntity(new CS10MissTheBirdState(engine, player, this));
                return;
            }

            var entity =
                ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<OriginalCassetteBlockManagerState>(
                    "Celeste.CassetteBlockManager");
            if (entity != null)
            {
                entity.StopBlocks();
                entity.Finish();
            }

            SourceLevel.Scheduler.QueueSourceEntity(new CS10CatchTheBirdState(engine, player, this));
        }

        public override void Update()
        {
            if (!startedRoutine && fakeRightWall != null)
            {
                var level = Scene as OriginalLevelSceneRoot;
                if (level.Camera.X > fakeRightWall.X - 320f - 16f) level.Camera.X = fakeRightWall.X - 320f - 16f;
            }

            if (emitParticles && SourceLevel.OnInterval(.1f))
                SourceLevel.ParticlesBG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.FlingBird.P_Feather, 1,
                    Position + new Vector2(0f, -8f), new(6f, 4f));

            base.Update();
        }

        public IEnumerator DoGrabbingRoutine(RoomPlayerSession player)
        {
            var level = Scene as OriginalLevelSceneRoot;
            inCutscene = true;
            if (!crashes)
                CrashSfxEmitter =
                    SoundEmitterState.Play("event:/new_content/game/10_farewell/bird_flappyscene", this, engine);
            else
                CrashSfxEmitter = SoundEmitterState.Play("event:/new_content/game/10_farewell/bird_crashscene_start",
                    this,
                    engine);

            player.Machine.State = 11;
            player.Dummy.Gravity = false;
            player.Dummy.AutoAnimate = false;
            player.ForceCameraUpdate = true;
            player.Sprite.Play("jumpSlow_carry");
            player.Data.Motion.Normal.Speed = Vector2.Zero;
            player.Data.Facing = 1;
            OriginalCelesteFreeze.Freeze(engine, 0.1f);
            level.Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 0);
            emitParticles = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, level.ZoomTo(new(140f, 120f), 1.5f, 4f)));
            var sin = 0f;
            for (var index = 0; index < nodes.Length - 1; index++)
            {
                var position = Position;
                var vector = nodes[index];
                var curve = new SimpleCurve(position, vector,
                    position + (vector - position) * 0.5f + new Vector2(0f, -24f));
                var lengthParametric = curve.GetLengthParametric(32, CurveArithmetic, VectorArithmetic);
                var duration = lengthParametric / 100f;
                if (vector.Y < position.Y)
                {
                    duration *= 1.1f;
                    Sprite.Rate = 2f;
                }
                else
                {
                    duration *= 0.8f;
                    Sprite.Rate = 1f;
                }

                if (!crashes)
                {
                    if (index == 0) duration = 0.7f;

                    if (index == 1) duration += 0.191f;

                    if (index == 2) duration += 0.191f;
                }

                for (var p = 0f; p < 1f; p += engine.DeltaTime / duration)
                {
                    sin += engine.DeltaTime * 10f;
                    Position = Vector2Geometry.Floor(CurveArithmetic.GetPoint(curve, p) +
                                                     Vector2.UnitY * (float)Math.Sin(sin) * 8f);
                    player.Position = Position + new Vector2(2f, 10f);
                    switch (Sprite.CurrentAnimationFrame)
                    {
                        case 1:
                            player.Position += new Vector2(1f, -1f);
                            break;
                        case 2:
                            player.Position += new Vector2(-1f, 0f);
                            break;
                        case 3:
                            player.Position += new Vector2(-1f, 1f);
                            break;
                        case 4:
                            player.Position += new Vector2(1f, 3f);
                            break;
                        case 5:
                            player.Position += new Vector2(2f, 5f);
                            break;
                    }

                    yield return null;
                }

                level.Shake();
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(1, 0);
            }

            Sprite.Rate = 1f;
            OriginalCelesteFreeze.Freeze(engine, 0.05f);
            yield return null;
            level.Shake();
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
            level.Flash(PackedColor.White);
            emitParticles = false;
            inCutscene = false;
        }
    }
}

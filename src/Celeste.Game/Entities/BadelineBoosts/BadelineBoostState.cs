using System;
using System.Collections;
using System.Diagnostics;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Entities.BadelineDummy;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Profiles;
using Celeste.Game.Stories.Farewell.FinalLaunch;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Camera;
using Celeste.Simulation.Gameplay.Collectibles.Strawberry;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.BadelineBoosts
{
    public class BadelineBoostState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private readonly Sprite sprite;
        private readonly SpriteImage stretch;
        private readonly WigglerComponent wiggler;
        private readonly VertexLightState light;
        private readonly BloomPointState bloom;
        private readonly bool canSkip, finalCh9Boost, finalCh9GoldenBoost, finalCh9Dialog;
        private readonly Vector2[] nodes;
        private int nodeIndex;
        private bool travelling;
        private RoomPlayerSession holding;
        private readonly SoundSourceComponentState relocateSfx;
        public FmodEventReference Ch9FinalBoostSfx;
        private OriginalLevelSceneRoot CurrentLevel => (OriginalLevelSceneRoot)Scene;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private ISourceGameGraphicsResources Graphics => ((ISourceGameGraphicsEnvironment)engine).GameGraphics;
        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;

        public BadelineBoostState(ISourceEngineContext engine,
            Vector2[] nodes, bool lockCamera, bool canSkip = false, bool finalCh9Boost = false,
            bool finalCh9GoldenBoost = false, bool finalCh9Dialog = false)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = nodes[0];
            Depth = -1000000;
            this.nodes = nodes;
            this.canSkip = canSkip;
            this.finalCh9Boost = finalCh9Boost;
            this.finalCh9GoldenBoost = finalCh9GoldenBoost;
            this.finalCh9Dialog = finalCh9Dialog;
            Collider = new CircleColliderGeometry(
                ((ISourceVectorEnvironment)engine).VectorArithmetic, 16f);
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            sprite = Graphics.SpriteFactory.Create("badelineBoost");
            OwnedComponents.Add(sprite);
            stretch = new(Graphics.GameAtlas.Entries["objects/badelineboost/stretch"]);
            OwnedComponents.Add(stretch);
            stretch.Visible = false;
            stretch.CenterOrigin();
            light = new(engine, Vector2.Zero, PackedColor.White, .7f, 12, 20);
            OwnedComponents.Add(light);
            bloom = new(.5f, 12f);
            OwnedComponents.Add(bloom);
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.4f, 3f,
                _ => sprite.Scale = Vector2.One * (1f + wiggler.Value * .4f));
            OwnedComponents.Add(wiggler);
            if (lockCamera) OwnedComponents.Add(new RoomCameraLocker(RoomCameraLockMode.BoostSequence, 0f, 160f));
            relocateSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create();
            OwnedComponents.Add(relocateSfx);
        }

        public override void Awake(object actualScene)
        {
            base.Awake(actualScene);
            if (SourceTrackedEntityCollision.First<object>(((ISourceScene)Scene).SourceScene.Entities,
                    "Celeste.FakeWall",
                    this) != null) Depth = -12500;
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            Add(new SimulationCoroutine(engine, BoostRoutine(player)));
        }

        private void Add(SimulationCoroutine coroutine)
        {
            OwnedComponents.Add(coroutine);
        }

        private void Add(SourceAlarmState alarm)
        {
            OwnedComponents.Add(alarm);
        }

        private void Add(SourceTweenState tween)
        {
            OwnedComponents.Add(tween);
        }

        private FmodEventReference PlaySound(string path, Vector2 position)
        {
            return Process.AudioSession.Play(path, position, Process.SaveContext);
        }

        private RoomPlayerSession FirstPlayer()
        {
            var list = ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntities(
                typeof(RoomPlayerSession).FullName);

            return list.Count == 0 ? null : (RoomPlayerSession)list[0];
        }

        private IEnumerator BoostRoutine(RoomPlayerSession player)
        {
            holding = player;
            travelling = true;
            nodeIndex++;
            sprite.Visible = false;
            sprite.Position = Vector2.Zero;
            Collidable = false;
            var finalBoost = nodeIndex >= nodes.Length;
            var level = CurrentLevel;
            bool endLevel;
            if (finalBoost && finalCh9GoldenBoost)
            {
                endLevel = true;
            }
            else
            {
                var flag = false;
                foreach (var follower in player.Leader.Followers)
                    if (follower.Entity is ISourceStrawberryFollower { Golden: not false })
                    {
                        flag = true;
                        break;
                    }

                endLevel = finalBoost && finalCh9Boost && !flag;
            }

            var sw = new Stopwatch();
            sw.Start();
            if (finalCh9Boost)
                PlaySound("event:/new_content/char/badeline/booster_finalfinal_part1", Position);
            else if (!finalBoost)
                PlaySound("event:/char/badeline/booster_begin", Position);
            else
                PlaySound("event:/char/badeline/booster_final", Position);

            if (player.Holding.Holding != null) player.Holding.Drop();

            player.Machine.State = 11;
            player.Dummy.AutoAnimate = false;
            player.Dummy.Gravity = false;
            if (((OriginalLevelSceneRoot)player.Scene).Session.Inventory.Dashes > 1)
                player.Data.Dashes = 1;
            else
                player.World.RefillDash();

            player.Data.Stamina = 110f;
            player.Speed = Vector2.Zero;
            var num = Math.Sign(player.Position.X - X);
            if (num == 0) num = -1;

            var badeline = BadelineDummyPresentation.Create(level, Position);
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(badeline);
            player.Data.Facing = -num;
            badeline.Sprite.Scale.X = num;
            var playerFrom = player.Position;
            var playerTo = Position + new Vector2(num * 4, -3f);
            var badelineFrom = badeline.Position;
            var badelineTo = Position + new Vector2(-num * 4, 3f);
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 0.2f)
            {
                var vector = Vector2Interpolation.Lerp(playerFrom, playerTo, p,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                if (player.Scene != null) player.MoveToX(vector.X);

                if (player.Scene != null) player.MoveToY(vector.Y);

                badeline.Position = Vector2Interpolation.Lerp(badelineFrom, badelineTo, p,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            if (finalBoost)
            {
                var screenSpaceFocusPoint =
                    new Vector2(ScalarMath.Clamp(player.Position.X - level.Camera.Position.X, 120f, 200f),
                        ScalarMath.Clamp(player.Position.Y - level.Camera.Position.Y, 60f, 120f));
                Add(new SimulationCoroutine(engine, level.ZoomTo(screenSpaceFocusPoint, 1.5f, 0.18f)));
                engine.Effects.TimeRate = 0.5f;
            }
            else
            {
                PlaySound("event:/char/badeline/booster_throw", Position);
            }

            badeline.Sprite.Play("boost");
            yield return 0.1f;
            if (!player.Dead) player.MoveV(5f);

            yield return 0.1f;
            if (endLevel)
            {
                level.TimerStopped = true;
                level.RegisterAreaComplete();
            }

            if (finalBoost && finalCh9Boost)
            {
                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new FinalLaunchCutscene(engine, player, this,
                    finalCh9Dialog));
                player.Active = false;
                badeline.Active = false;
                Active = false;
                yield return null;
                player.Active = true;
                badeline.Active = true;
            }

            Add(SourceAlarmState.Create(engine.AlarmPool, SourceAlarmState.AlarmMode.Oneshot, delegate
            {
                if (player.Data.Dashes < ((OriginalLevelSceneRoot)player.Scene).Session.Inventory.Dashes)
                    player.Data.Dashes++;

                ((ISceneEntityRemovalScene)Scene).RemoveEntity(badeline);
                CurrentLevel.Displacement.AddBurst(badeline.Position, 0.25f, 8f, 32f, 0.5f);
            }, 0.15f, true));
            CurrentLevel.Shake();
            holding = null;
            if (!finalBoost)
            {
                player.BadelineBoostLaunch(CenterX);
                var from = Position;
                var to = nodes[nodeIndex];
                var val = VectorArithmetic.Distance(from, to) / 320f;
                val = Math.Min(3f, val);
                stretch.Visible = true;
                stretch.Rotation = Vector2Geometry.Angle(to - from);
                var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, val, true);
                tween.OnUpdate = delegate(SourceTweenState t)
                {
                    Position = Vector2Interpolation.Lerp(from, to, t.Eased,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    stretch.Scale.X = 1f + ScalarMath.YoYo(t.Eased) * 2f;
                    stretch.Scale.Y = 1f - ScalarMath.YoYo(t.Eased) * 0.75f;
                    if (t.Eased < 0.9f && CurrentLevel.Clock.OnInterval(0.03f, engine))
                    {
                        TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this,
                            PlayerHairAppearance
                                .TwoDashesHairColor, 0.5f);
                        level.ParticlesFG.Emit(Process.ParticleTypes.BadelineBoost.P_Move, 1, Center,
                            Vector2.One * 4f);
                    }
                };
                tween.OnComplete = delegate
                {
                    if (X >= level.Bounds.Right)
                    {
                        RemoveSelf();
                    }
                    else
                    {
                        travelling = false;
                        stretch.Visible = false;
                        sprite.Visible = true;
                        Collidable = true;
                        PlaySound("event:/char/badeline/booster_reappear", Position);
                    }
                };
                Add(tween);
                relocateSfx.Play("event:/char/badeline/booster_relocate");
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
                level.DirectionalShake(-Vector2.UnitY);
                level.Displacement.AddBurst(Center, 0.4f, 8f, 32f, 0.5f);
            }
            else
            {
                if (finalCh9Boost)
                    Ch9FinalBoostSfx = PlaySound("event:/new_content/char/badeline/booster_finalfinal_part2", Position);

                if (((IGameProfileEnvironment)engine).SourceProfile == GameProfile.Original)
                    Console.WriteLine("TIME: " + sw.ElapsedMilliseconds);
                engine.Effects.FreezeTimer = 0.1f;
                yield return null;
                if (endLevel) level.TimerHidden = true;

                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 2);
                level.Flash(PackedColor.White * .5f, true);
                level.DirectionalShake(-Vector2.UnitY, 0.6f);
                level.Displacement.AddBurst(Center, 0.6f, 8f, 64f, 0.5f);
                level.ResetZoom();
                player.SummitLaunch(X);
                engine.Effects.TimeRate = 1f;
                Finish();
            }
        }

        private void Skip()
        {
            travelling = true;
            nodeIndex++;
            Collidable = false;
            var level = CurrentLevel;
            var from = Position;
            var to = nodes[nodeIndex];
            var val = VectorArithmetic.Distance(from, to) / 320f;
            val = Math.Min(3f, val);
            stretch.Visible = true;
            stretch.Rotation = Vector2Geometry.Angle(to - from);
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, val, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                Position = Vector2Interpolation.Lerp(from, to, t.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                stretch.Scale.X = 1f + ScalarMath.YoYo(t.Eased) * 2f;
                stretch.Scale.Y = 1f - ScalarMath.YoYo(t.Eased) * 0.75f;
                if (t.Eased < 0.9f && CurrentLevel.Clock.OnInterval(0.03f, engine))
                {
                    TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this,
                        PlayerHairAppearance
                            .TwoDashesHairColor, 0.5f);
                    level.ParticlesFG.Emit(Process.ParticleTypes.BadelineBoost.P_Move, 1, Center,
                        Vector2.One * 4f);
                }
            };
            tween.OnComplete = delegate
            {
                if (X >= level.Bounds.Right)
                {
                    RemoveSelf();
                }
                else
                {
                    travelling = false;
                    stretch.Visible = false;
                    sprite.Visible = true;
                    Collidable = true;
                    PlaySound("event:/char/badeline/booster_reappear", Position);
                }
            };
            Add(tween);
            relocateSfx.Play("event:/char/badeline/booster_relocate");
            level.Displacement.AddBurst(Center, 0.4f, 8f, 32f, 0.5f);
        }

        public void Wiggle()
        {
            wiggler.Start();
            CurrentLevel.Displacement.AddBurst(Position, 0.3f, 4f, 16f, 0.25f);
            PlaySound("event:/game/general/crystalheart_pulse", Position);
        }

        public override void Update()
        {
            if (sprite.Visible && CurrentLevel.Clock.OnInterval(0.05f, engine))
                CurrentLevel.ParticlesBG.Emit(Process.ParticleTypes.BadelineBoost.P_Ambience, 1, Center,
                    Vector2.One * 3f);

            if (holding != null) holding.Speed = Vector2.Zero;

            if (!travelling)
            {
                var entity = FirstPlayer();
                if (entity != null)
                {
                    var num = ScalarMath.ClampedMap(VectorArithmetic.Length(entity.Center - Position), 16f, 64f, 12f,
                        0f);
                    var vector = VectorArithmetic.SafeNormalize(entity.Center - Position);
                    sprite.Position = VectorArithmetic.Approach(sprite.Position, vector * num, 32f * engine.DeltaTime);
                    if (canSkip && entity.Position.X - X >= 100f && nodeIndex + 1 < nodes.Length) Skip();
                }
            }

            light.Visible = bloom.Visible = sprite.Visible || stretch.Visible;
            base.Update();
        }

        private void Finish()
        {
            CurrentLevel.Displacement.AddBurst(Center, 0.5f, 24f, 96f, 0.4f);
            CurrentLevel.Particles.Emit(Process.ParticleTypes.BadelineOldsite.P_Vanish, 12, Center,
                Vector2.One * 6f);
            CurrentLevel.CameraLockMode = RoomCameraLockMode.None;
            CurrentLevel.CameraOffset = new(0f, -16f);
            RemoveSelf();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Audio;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Enemies.Badeline.Chasers;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Presentation.Hair;
using Celeste.Simulation.Gameplay.Player.Presentation.Sprites;
using Celeste.Simulation.Presentation.Effects.Trails.Lifecycle;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Gameplay.Enemies.Badeline.Chasers
{
    public class BadelineOldsiteState : SceneEntityState
    {
        protected readonly ISourceEngineContext engine;

        public PlayerSprite Sprite;

        public PlayerHair Hair;

        private LightOccludeState occlude;

        protected bool ignorePlayerAnim;

        private readonly int index;

        private RoomPlayerSession player;

        protected bool following;

        private readonly float followBehindTime;

        private readonly float followBehindIndexDelay;

        public bool Hovering;

        private float hoveringTimer;

        private readonly Dictionary<string, SoundSourceComponentState> loopingSounds = new();

        private readonly List<SoundSourceComponentState> inactiveLoopingSounds = [];

        public BadelineOldsiteState(ISourceEngineContext engine, Vector2 position, int index)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            this.engine = engine;
            this.index = index;
            Depth = -1;
            Collider = new HitboxColliderGeometry(6f, 6f, -3f, -7f);
            Collidable = false;
            Sprite = new(engine, PlayerSpriteMode.Badeline);
            Sprite.Play("fallSlow", true);
            Hair = new(Sprite, engine);
            Hair.Color = PackedColor.Lerp(
                ((IOriginalBadelineOldsiteEnvironment)engine).BadelineOldsiteStatics.HairColor,
                PackedColor.White, index / 6f);
            Hair.Border = PackedColor.Black;
            OwnedComponents.Add(Hair);
            OwnedComponents.Add(Sprite);
            Visible = false;
            followBehindTime = 1.55f;
            followBehindIndexDelay = 0.4f * index;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
        }

        public BadelineOldsiteState(EntityData data, Vector2 offset,
            int index, ISourceEngineContext engine)
            : this(engine, data.Position + offset, index)
        {
        }

        protected void AddedSourceEntityBase(object scene)
        {
            base.Added(scene);
        }

        public virtual bool CanChangeMusic(bool value)
        {
            return value;
        }

        public virtual bool IsChaseEnd(bool value)
        {
            return value;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            var session = ((OriginalLevelSceneRoot)Scene).Session;
            if (session.GetLevelFlag("11") &&
                ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(session).Mode ==
                (int)OriginalAreaMode.Normal)
            {
                RemoveSelf();
            }
            else if (!session.GetLevelFlag("3") &&
                     ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(session).Mode ==
                     (int)OriginalAreaMode.Normal)
            {
                RemoveSelf();
            }
            else if (!session.GetFlag("evil_maddy_intro") && session.Level == "3" &&
                     ((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(session).Mode ==
                     (int)OriginalAreaMode.Normal)
            {
                Hovering = false;
                Visible = true;
                Hair.Visible = false;
                Sprite.Play("pretendDead");
                if (((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(session).Mode ==
                    (int)OriginalAreaMode.Normal)
                {
                    session.Audio.Music.Event = null;
                    OriginalAudioSession.Apply(session.Audio,
                        ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                        ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
                }

                ((ISourceScene)Scene).SourceScene.QueueSourceEntity(new BadelineIntroCutsceneState(engine, this));
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(engine,
                    StartChasingRoutine(Scene as OriginalLevelSceneRoot)));
            }
        }

        public IEnumerator StartChasingRoutine(OriginalLevelSceneRoot level)
        {
            Hovering = true;
            while ((player =
                       ((ISourceScene)Scene).SourceScene.Entities.GetTrackedEntity<RoomPlayerSession>(
                           typeof(RoomPlayerSession).FullName)) ==
                   null || player.JustRespawned)
                yield return null;

            var to = player.Position;
            yield return followBehindIndexDelay;
            if (!Visible) PopIntoExistance(0.5f);

            Sprite.Play("fallSlow");
            Hair.Visible = true;
            Hovering = false;
            if (CanChangeMusic(((IOriginalAreaKeyEnvironment)engine).AreaKeys.GetSessionArea(level.Session).Mode ==
                               (int)OriginalAreaMode.Normal))
            {
                level.Session.Audio.Music.Event = "event:/music/lvl2/chase";
                OriginalAudioSession.Apply(level.Session.Audio,
                    ((IOriginalGameplayProcess)engine).AudioSession.ChannelOutput,
                    ((IOriginalGameplayProcess)engine).AudioApplyPolicy);
            }

            yield return TweenToPlayer(to);
            Collidable = true;
            following = true;
            OwnedComponents.Add(occlude = new());
            if (IsChaseEnd(level.Session.Level == "2"))
                OwnedComponents.Add(new SimulationCoroutine(engine, StopChasing()));
        }

        private IEnumerator TweenToPlayer(Vector2 to)
        {
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/badeline/level_entry", Position,
                "chaser_count", index);
            var from = Position;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn, followBehindTime - 0.1f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                Position = Vector2Interpolation.Lerp(from, to, t.Eased,
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                if (to.X != from.X) Sprite.Scale.X = Math.Abs(Sprite.Scale.X) * Math.Sign(to.X - from.X);

                Trail();
            };
            OwnedComponents.Add(tween);
            yield return tween.Duration;
        }

        protected virtual IEnumerator StopChasing()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            var boundsRight = level.Bounds.X + 148;
            var boundsBottom = level.Bounds.Y + 168 + 184;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (X != boundsRight || /* ReSharper disable once CompareOfFloatsByEqualityOperator */ Y != boundsBottom)
            {
                yield return null;
                if (X > boundsRight) X = boundsRight;

                if (Y > boundsBottom) Y = boundsBottom;
            }

            following = false;
            ignorePlayerAnim = true;
            Sprite.Play("laugh");
            Sprite.Scale.X = 1f;
            yield return 1f;
            ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play("event:/char/badeline/disappear", Position);
            level.Displacement.AddBurst(Center, 0.5f, 24f, 96f, 0.4f);
            level.Particles.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.BadelineOldsite.P_Vanish, 12,
                Center,
                Vector2.One * 6f);
            RemoveSelf();
        }

        public override void Update()
        {
            ChaserState chaseState;
            if (player != null && player.Dead)
            {
                Sprite.Play("laugh");
                Sprite.Position.X = (float)(Math.Sin(hoveringTimer) * 4.0);
                Hovering = true;
                hoveringTimer += engine.DeltaTime * 2f;
                Depth = -12500;
                foreach (var loopingSound in loopingSounds) loopingSound.Value.Stop();

                Trail();
            }
            else if (following && player.GetChasePosition(((ISourceScene)Scene).SourceScene.Clock.TimeActive,
                         followBehindTime + followBehindIndexDelay, out chaseState))
            {
                Position = ((ISourceVectorEnvironment)engine).VectorArithmetic.Approach(Position, chaseState.Position,
                    500f * engine.DeltaTime);
                if (!ignorePlayerAnim && chaseState.Animation != Sprite.CurrentAnimationID &&
                    chaseState.Animation != null && Sprite.Has(chaseState.Animation))
                    Sprite.Play(chaseState.Animation, true);

                if (!ignorePlayerAnim) Sprite.Scale.X = Math.Abs(Sprite.Scale.X) * chaseState.Facing;

                for (var i = 0; i < chaseState.Sounds; i++)
                    if (chaseState[i].Action == ChaserStateSound.Actions.Oneshot)
                    {
                        ((ISourceSpatialAudioEnvironment)engine).SpatialAudio.Play(chaseState[i].Event, Position,
                            chaseState[i].Parameter, chaseState[i].ParameterValue, "chaser_count", index);
                    }
                    else if (chaseState[i].Action == ChaserStateSound.Actions.Loop &&
                             !loopingSounds.ContainsKey(chaseState[i].Event))
                    {
                        SoundSourceComponentState soundSource;
                        if (inactiveLoopingSounds.Count > 0)
                        {
                            soundSource = inactiveLoopingSounds[0];
                            inactiveLoopingSounds.RemoveAt(0);
                        }
                        else
                        {
                            OwnedComponents.Add(soundSource =
                                ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
                        }

                        soundSource.Play(chaseState[i].Event, "chaser_count", index);
                        loopingSounds.Add(chaseState[i].Event, soundSource);
                    }
                    else if (chaseState[i].Action == ChaserStateSound.Actions.Stop)
                    {
                        SoundSourceComponentState value = null;
                        if (loopingSounds.TryGetValue(chaseState[i].Event, out value))
                        {
                            value.Stop();
                            loopingSounds.Remove(chaseState[i].Event);
                            inactiveLoopingSounds.Add(value);
                        }
                    }

                Depth = chaseState.Depth;
                Trail();
            }

            if (Sprite.Scale.X != 0f) Hair.Facing = Math.Sign(Sprite.Scale.X);

            if (Hovering)
            {
                hoveringTimer += engine.DeltaTime;
                Sprite.Position.Y = (float)(Math.Sin(hoveringTimer * 2f) * 4.0);
            }
            else
            {
                Sprite.Position.Y = ScalarMath.Approach(Sprite.Position.Y, 0f, engine.DeltaTime * 4f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            if (occlude != null) occlude.Visible = !CollideCheck("Celeste.Solid");

            base.Update();
        }

        private void Trail()
        {
            if (((ISourceScene)Scene).SourceScene.Clock.OnInterval(0.1f, engine))
                TrailManagerState.Add(engine, (ISourceRenderEnvironment)engine, this,
                    PlayerHairAppearance.NormalHairColor);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            player.Die(((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(player.Position - Position));
        }

        private void Die()
        {
            RemoveSelf();
        }

        private void PopIntoExistance(float duration)
        {
            Visible = true;
            Sprite.Scale = Vector2.Zero;
            Sprite.Color = PackedColor.Transparent;
            Hair.Visible = true;
            Hair.Alpha = 0f;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn, duration, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                Sprite.Scale = Vector2.One * t.Eased;
                Sprite.Color = PackedColor.White * t.Eased;
                Hair.Alpha = t.Eased;
            };
            OwnedComponents.Add(tween);
        }

        private bool OnGround(int dist = 1)
        {
            for (var i = 1; i <= dist; i++)
                if (CollideCheck("Celeste.Solid", Position + new Vector2(0f, i)))
                    return true;

            return false;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Components.Timing;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Entities;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Entities.Protocols;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Environment.Core;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Liquids;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Gameplay.Environment.Lava.Rising;

namespace Celeste.Game.Gameplay.Environment.Lava.Sandwich
{
    public class OriginalSandwichLavaState : SceneEntityState
    {
        private readonly IOriginalLavaProcess engine;

        private RoomPlayerSession FindPlayer()
        {
            return ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
        }

        private float Approach(float value, float target, float amount)
            => ScalarMath.Approach(value, target, amount, engine.ExtremaArithmetic);

        private const float TopOffset = -160f;

        private const float Speed = 20f;

        public bool Waiting;

        private bool iceMode;

        private float startX;

        private float lerp;

        private float transitionStartY;

        private bool leaving;

        private float delay;

        private LavaRectangleComponentState bottomRect;

        private LavaRectangleComponentState topRect;

        private bool persistent;

        private SoundSourceComponentState loopSfx;

        private float centerY => (float)((OriginalLevelSceneRoot)Scene).Bounds.Bottom - 10f;

        public OriginalSandwichLavaState(float startX, IOriginalLavaProcess engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.startX = startX;
            base.Depth = -1000000;
            base.Collider = new ColliderListGeometry(new HitboxColliderGeometry(340f, 120f),
                new HitboxColliderGeometry(340f, 120f, 0f, -280f));
            Visible = false;
            OwnedComponents.Add(loopSfx = engine.SoundSources.Create());
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
            OwnedComponents.Add(bottomRect =
                new LavaRectangleComponentState(400f, 200f, 4, engine, "danger/lava/bubble_a", "particles/bubble"));
            bottomRect.Position = new Vector2(-40f, 0f);
            bottomRect.OnlyMode = LavaRectangleComponentState.OnlyModes.OnlyTop;
            bottomRect.SmallWaveAmplitude = 2f;
            OwnedComponents.Add(topRect =
                new LavaRectangleComponentState(400f, 200f, 4, engine, "danger/lava/bubble_a", "particles/bubble"));
            topRect.Position = new Vector2(-40f, -360f);
            topRect.OnlyMode = LavaRectangleComponentState.OnlyModes.OnlyBottom;
            topRect.SmallWaveAmplitude = 2f;
            topRect.BigWaveAmplitude = (bottomRect.BigWaveAmplitude = 2f);
            topRect.CurveAmplitude = (bottomRect.CurveAmplitude = 4f);
            OwnedComponents.Add(new RoomTransitionListener
            {
                OnOutBegin = delegate
                {
                    transitionStartY = base.Y;
                    if (persistent && base.Scene != null && ((OriginalLevelSceneRoot)base.Scene).Scheduler.Entities
                        .FindAll<OriginalSandwichLavaState>().Count <= 1)
                    {
                        Leave();
                    }
                },
                OnOut = delegate(float f)
                {
                    if (base.Scene != null)
                    {
                        base.X = (base.Scene as OriginalLevelSceneRoot).Camera.X;
                        if (!leaving)
                        {
                            base.Y = ScalarMath.Lerp(transitionStartY, centerY, f, engine.ScalarArithmetic);
                        }
                    }

                    if ((f > 0.95f) & leaving)
                    {
                        RemoveSelf();
                    }
                }
            });
        }


        public override void Added(object scene)
        {
            base.Added(scene);
            base.X = ((OriginalLevelSceneRoot)Scene).Bounds.Left - 10;
            base.Y = centerY;
            iceMode = ((OriginalLevelSceneRoot)Scene).Session.CoreMode == RoomCoreMode.Cold;
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            RoomPlayerSession entity = FindPlayer();
            if (entity != null && (entity.JustRespawned || entity.X < startX))
            {
                Waiting = true;
            }

            List<OriginalSandwichLavaState> list =
                ((OriginalLevelSceneRoot)base.Scene).Scheduler.Entities.FindAll<OriginalSandwichLavaState>();
            bool flag = false;
            if (!persistent && list.Count >= 2)
            {
                OriginalSandwichLavaState sandwichLava = ((list[0] == this) ? list[1] : list[0]);
                if (!sandwichLava.leaving)
                {
                    sandwichLava.startX = startX;
                    sandwichLava.Waiting = true;
                    RemoveSelf();
                    flag = true;
                }
            }

            if (!flag)
            {
                persistent = true;
                base.Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags
                    .Persistent.Value;
                if ((scene as OriginalLevelSceneRoot).LastIntroType != PlayerIntroType.Respawn)
                {
                    topRect.Position.Y -= 60f;
                    bottomRect.Position.Y += 60f;
                }
                else
                {
                    Visible = true;
                }

                loopSfx.Play("event:/game/09_core/rising_threat", "room_state", iceMode ? 1 : 0);
                loopSfx.Position = new Vector2(base.Width / 2f, 0f);
            }
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            iceMode = mode == RoomCoreMode.Cold;
            loopSfx.Param("room_state", iceMode ? 1 : 0);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (Waiting)
            {
                return;
            }

            if (engine.SaveContext.CurrentSave.Assists.Invincible)
            {
                if (delay <= 0f)
                {
                    int num = ((player.Y > base.Y + bottomRect.Position.Y - 32f) ? 1 : (-1));
                    float from = base.Y;
                    float to = base.Y + (float)(num * 48);
                    player.Data.Motion.Normal.Speed.Y = -num * 200;
                    if (num > 0)
                    {
                        player.RefillDash();
                    }

                    SourceTweenState.Set(engine.TweenPool, OwnedComponents, SourceTweenState.TweenMode.Oneshot, 0.4f,
                        engine.EasingArithmetic.CubeOut,
                        delegate(SourceTweenState t)
                        {
                            base.Y = ScalarMath.Lerp(from, to, t.Eased, engine.ScalarArithmetic);
                        });
                    delay = 0.5f;
                    loopSfx.Param("rising", 0f);
                    engine.SpatialAudio.Play("event:/game/general/assist_screenbottom", player.Position);
                }
            }
            else
            {
                player.Die(-Vector2.UnitY);
            }
        }

        public void Leave()
        {
            AddTag(((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate
                .Value);
            leaving = true;
            Collidable = false;
            SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 2f, delegate { RemoveSelf(); });
        }

        public override void Update()
        {
            OriginalLevelSceneRoot level = base.Scene as OriginalLevelSceneRoot;
            base.X = level.Camera.X;
            delay -= engine.DeltaTime;
            base.Update();
            Visible = true;
            if (Waiting)
            {
                base.Y = Approach(base.Y, centerY, 128f * engine.DeltaTime);
                loopSfx.Param("rising", 0f);
                RoomPlayerSession entity = FindPlayer();
                if (entity != null && entity.X >= startX && !entity.JustRespawned && entity.Machine.State != 11)
                {
                    Waiting = false;
                }
            }
            else if (!leaving && delay <= 0f)
            {
                loopSfx.Param("rising", 1f);
                if (iceMode)
                {
                    base.Y += 20f * engine.DeltaTime;
                }
                else
                {
                    base.Y -= 20f * engine.DeltaTime;
                }
            }

            topRect.Position.Y = Approach(topRect.Position.Y, -160f - topRect.Height + (float)(leaving ? (-512) : 0),
                (float)(leaving ? 256 : 64) * engine.DeltaTime);
            bottomRect.Position.Y = Approach(bottomRect.Position.Y, leaving ? 512 : 0,
                (float)(leaving ? 256 : 64) * engine.DeltaTime);
            lerp = Approach(lerp, iceMode ? 1 : 0, engine.DeltaTime * 4f);
            bottomRect.SurfaceColor = SourceColorInterpolation.Lerp(OriginalRisingLavaState.Hot[0],
                OriginalRisingLavaState.Cold[0], lerp, engine.ScalarArithmetic);
            bottomRect.EdgeColor = SourceColorInterpolation.Lerp(OriginalRisingLavaState.Hot[1],
                OriginalRisingLavaState.Cold[1], lerp, engine.ScalarArithmetic);
            bottomRect.CenterColor = SourceColorInterpolation.Lerp(OriginalRisingLavaState.Hot[2],
                OriginalRisingLavaState.Cold[2], lerp, engine.ScalarArithmetic);
            bottomRect.Spikey = lerp * 5f;
            bottomRect.UpdateMultiplier = (1f - lerp) * 2f;
            bottomRect.Fade = (iceMode ? 128 : 32);
            topRect.SurfaceColor = bottomRect.SurfaceColor;
            topRect.EdgeColor = bottomRect.EdgeColor;
            topRect.CenterColor = bottomRect.CenterColor;
            topRect.Spikey = bottomRect.Spikey;
            topRect.UpdateMultiplier = bottomRect.UpdateMultiplier;
            topRect.Fade = bottomRect.Fade;
        }
    }
}

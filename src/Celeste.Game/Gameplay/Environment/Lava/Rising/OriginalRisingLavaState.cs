using Celeste.Core.Display;
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

namespace Celeste.Game.Gameplay.Environment.Lava.Rising
{
    public class OriginalRisingLavaState : SceneEntityState
    {
        private readonly IOriginalLavaProcess engine;

        private RoomPlayerSession FindPlayer()
        {
            return ((OriginalLevelSceneRoot)Scene).Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                typeof(global::Celeste.Simulation.RoomPlayerSession).FullName);
        }

        private float Approach(float value, float target, float amount)
            => ScalarMath.Approach(value, target, amount, engine.ExtremaArithmetic);

        private const float Speed = -30f;

        private bool intro;

        private bool iceMode;

        private bool waiting;

        private float lerp;

        public static PackedColor[] Hot = new PackedColor[3]
        {
            new PackedColor(255, 137, 51, 255),
            new PackedColor(242, 94, 41, 255),
            new PackedColor(208, 28, 1, 255)
        };

        public static PackedColor[] Cold = new PackedColor[3]
        {
            new PackedColor(51, 255, 231, 255),
            new PackedColor(76, 162, 235, 255),
            new PackedColor(1, 81, 208, 255)
        };

        private LavaRectangleComponentState bottomRect;

        private float delay;

        private SoundSourceComponentState loopSfx;

        public OriginalRisingLavaState(bool intro, IOriginalLavaProcess engine)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            this.intro = intro;
            base.Depth = -1000000;
            base.Collider = new HitboxColliderGeometry(340f, 120f);
            Visible = false;
            OwnedComponents.Add(new PlayerColliderComponentState(OnPlayer));
            OwnedComponents.Add(new CoreModeListenerState(OnChangeMode));
            OwnedComponents.Add(loopSfx = engine.SoundSources.Create());
            OwnedComponents.Add(bottomRect =
                new LavaRectangleComponentState(400f, 200f, 4, engine, "danger/lava/bubble_a", "particles/bubble"));
            bottomRect.Position = new Vector2(-40f, 0f);
            bottomRect.OnlyMode = LavaRectangleComponentState.OnlyModes.OnlyTop;
            bottomRect.SmallWaveAmplitude = 2f;
        }


        public override void Added(object scene)
        {
            base.Added(scene);
            base.X = ((OriginalLevelSceneRoot)Scene).Bounds.Left - 10;
            base.Y = ((OriginalLevelSceneRoot)Scene).Bounds.Bottom + 16;
            iceMode = ((OriginalLevelSceneRoot)Scene).Session.CoreMode == RoomCoreMode.Cold;
            loopSfx.Play("event:/game/09_core/rising_threat", "room_state", iceMode ? 1 : 0);
            loopSfx.Position = new Vector2(base.Width / 2f, 0f);
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (intro)
            {
                waiting = true;
            }
            else
            {
                RoomPlayerSession entity = FindPlayer();
                if (entity != null && entity.JustRespawned)
                {
                    waiting = true;
                }
            }

            if (intro)
            {
                Visible = true;
            }
        }

        private void OnChangeMode(RoomCoreMode mode)
        {
            iceMode = mode == RoomCoreMode.Cold;
            loopSfx.Param("room_state", iceMode ? 1 : 0);
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            if (engine.SaveContext.CurrentSave.Assists.Invincible)
            {
                if (delay <= 0f)
                {
                    float from = base.Y;
                    float to = base.Y + 48f;
                    player.Data.Motion.Normal.Speed.Y = -200f;
                    player.RefillDash();
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

        public override void Update()
        {
            delay -= engine.DeltaTime;
            base.X = ((OriginalLevelSceneRoot)Scene).Camera.X;
            RoomPlayerSession entity = FindPlayer();
            base.Update();
            Visible = true;
            float num = 1f;
            if (waiting)
            {
                loopSfx.Param("rising", 0f);
                if (!intro && entity != null && entity.JustRespawned)
                {
                    base.Y = Approach(base.Y, entity.Y + 32f, 32f * engine.DeltaTime);
                }

                if ((!iceMode || !intro) && (entity == null || !entity.JustRespawned))
                {
                    waiting = false;
                }
            }
            else
            {
                float num2 = ((OriginalLevelSceneRoot)Scene).Camera.Bottom - 12f;
                if (base.Top > num2 + 96f)
                {
                    base.Top = num2 + 96f;
                }

                num = ((!(base.Top > num2))
                    ? ScalarMath.ClampedMap(num2 - base.Top, 0f, 32f, 1f, 0.5f)
                    : ScalarMath.ClampedMap(base.Top - num2, 0f, 96f, 1f, 2f));
                if (delay <= 0f)
                {
                    loopSfx.Param("rising", 1f);
                    base.Y += -30f * num * engine.DeltaTime;
                }
            }

            lerp = Approach(lerp, iceMode ? 1 : 0, engine.DeltaTime * 4f);
            bottomRect.SurfaceColor = SourceColorInterpolation.Lerp(Hot[0], Cold[0], lerp, engine.ScalarArithmetic);
            bottomRect.EdgeColor = SourceColorInterpolation.Lerp(Hot[1], Cold[1], lerp, engine.ScalarArithmetic);
            bottomRect.CenterColor = SourceColorInterpolation.Lerp(Hot[2], Cold[2], lerp, engine.ScalarArithmetic);
            bottomRect.Spikey = lerp * 5f;
            bottomRect.UpdateMultiplier = (1f - lerp) * 2f;
            bottomRect.Fade = (iceMode ? 128 : 32);
        }
    }
}

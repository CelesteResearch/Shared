using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Components.Switches;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Gameplay.Enemies.Seekers;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Physics.Collision.Shapes;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Audio.Emitters;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Holdables;
using Celeste.Simulation.Gameplay.Player.Collision.Components;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.Particles.Definitions;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Gameplay.Mechanisms.Switches
{
    public class OriginalTouchSwitchState : SceneEntityState
    {
        protected PackedColor inactiveColor = PackedColor.FromHex("5fcde4");
        protected PackedColor activeColor = PackedColor.White;
        protected PackedColor finishColor = PackedColor.FromHex("f141df");
        private readonly IOriginalTouchSwitchProcess process;

        private OriginalLevelSceneRoot Level =>
            (OriginalLevelSceneRoot)Scene;

        public OriginalSwitchComponent Switch;
        private float ease;
        private float timer;
        protected Sprite icon;
        private readonly AtlasEntry border;
        private readonly WigglerComponent wiggler;
        private readonly BloomPointState bloom;
        private readonly SoundSourceComponentState touchSfx;
        private Vector2 pulse = Vector2.One;

        public OriginalTouchSwitchState(EntityData data,
            Vector2 offset, IOriginalTouchSwitchProcess process) : this(data.Position + offset, process)
        {
        }

        public OriginalTouchSwitchState(Vector2 position, IOriginalTouchSwitchProcess process)
            : base(
                ((ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration, position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            border = process.GameGraphics.GameAtlas["objects/touchswitch/container"];
            icon = new(process, process.GameGraphics.GameAtlas,
                "objects/touchswitch/icon");
            Depth = 2000;
            Switch = new(false);
            OwnedComponents.Add(Switch);
            OwnedComponents.Add(
                new PlayerColliderComponentState(
                    OnPlayer, null,
                    new HitboxColliderGeometry(30f, 30f, -15f, -15f)));
            OwnedComponents.Add(icon);
            bloom = new(0f, 16f);
            OwnedComponents.Add(bloom);
            bloom.Alpha = 0f;
            icon.Add("idle", "", 0f, 0);
            icon.Add("spin", "", .1f, new Chooser<string>("spin", 1f), 0, 1, 2, 3, 4,
                5);
            icon.Play("spin");
            icon.Color = inactiveColor;
            icon.CenterOrigin();
            Collider = new HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(new HoldableColliderState(OnHoldable,
                new HitboxColliderGeometry(20f, 20f, -10f, -10f)));
            OwnedComponents.Add(new SeekerColliderState(OnSeeker,
                new HitboxColliderGeometry(24f, 24f, -12f, -12f)));
            Switch.OnActivate = () =>
            {
                wiggler.Start();
                for (var i = 0; i < 32; i++)
                {
                    var angle =
                        SourceRandomMath.NextFloat(process.Random, (float)Math.PI * 2f);
                    Level.Particles.Emit(process.ParticleTypes.TouchSwitch.P_FireWhite,
                        Position + Vector2Geometry.AngleToVector(angle, 6f), angle);
                }

                icon.Rate = 4;
            };
            Switch.OnFinish = () => ease = 0;
            Switch.OnStartFinished = () =>
            {
                icon.Rate = .1f;
                icon.Play("idle");
                icon.Color = finishColor;
                ease = 1;
            };
            wiggler = process.WigglerPool.Create(.5f, 4f, value => pulse = Vector2.One * (1f + value * .25f));
            OwnedComponents.Add(wiggler);
            var light = new VertexLightState(process, Vector2.Zero,
                PackedColor.White, .8f, 16, 32);
            OwnedComponents.Add(light);
            touchSfx = process.SoundSources.Create();
            OwnedComponents.Add(touchSfx);
        }

        protected virtual ParticleTypePresentation
            FireParticle =>
            process.ParticleTypes.TouchSwitch.P_Fire;

        public void TurnOn()
        {
            if (!Switch.Activated)
            {
                touchSfx.Play("event:/game/general/touchswitch_any");
                if (Switch.Activate())
                {
                    SoundEmitterState.Play(
                        "event:/game/general/touchswitch_last_oneshot", process);
                    var cutoff = process.SoundSources.Create();
                    cutoff.Play("event:/game/general/touchswitch_last_cutoff");
                    OwnedComponents.Add(cutoff);
                }
            }
        }

        private void OnPlayer(RoomPlayerSession player)
        {
            TurnOn();
        }

        private void OnHoldable(HoldableState holdable)
        {
            TurnOn();
        }

        private void OnSeeker(OriginalSeekerState seeker)
        {
            if (Level.InsideCamera(Position, 10f)) TurnOn();
        }

        public override void Update()
        {
            timer += process.DeltaTime * 8;
            ease = ScalarMath.Approach(ease,
                Switch.Finished || Switch.Activated ? 1 : 0, process.DeltaTime * 2, process.ExtremaArithmetic);
            icon.Color = SourceColorInterpolation.Lerp(inactiveColor,
                Switch.Finished ? finishColor : activeColor, ease, process.ScalarArithmetic);
            icon.Color *= .5f + ((float)Math.Sin(timer) + 1) / 2 * (1 - ease) * .5f + .5f * ease;
            bloom.Alpha = ease;
            if (Switch.Finished)
            {
                if (icon.Rate > .1f)
                {
                    icon.Rate -= 2 * process.DeltaTime;
                    if (icon.Rate <= .1f)
                    {
                        icon.Rate = .1f;
                        wiggler.Start();
                        icon.Play("idle");
                        Level.Displacement.AddBurst(Position, .6f, 4f, 28f, .2f);
                    }
                }
                else if (Level.SourceScene.Clock.OnInterval(.03f, process))
                {
                    Level.ParticlesBG.Emit(FireParticle,
                        Position + new Vector2(0f, 1f) + Vector2Geometry.AngleToVector(
                            SourceRandomMath.NextFloat(process.Random,
                                (float)Math.PI * 2f), 5f));
                }
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            var sink =
                (ISourceRenderCommandSink<
                    AtlasTextureDraw>)context;
            var origin = new Vector2(border.FrameWidth / 2f, border.FrameHeight / 2f);
            var shadow = new AtlasTextureDraw(border,
                Position + new Vector2(0f, -1f),
                origin, PackedColor.Black, Vector2.One);
            sink.Draw(in shadow, this);
            var face = new AtlasTextureDraw(border, Position, origin, icon.Color,
                pulse);
            sink.Draw(in face, this);
            base.Render(context);
        }
    }
}

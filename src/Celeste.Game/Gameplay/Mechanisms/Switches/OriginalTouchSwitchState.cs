using Celeste.Core.Display;
using Celeste.Physics.Collision;
using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;
using Celeste.Graphics.Display;

namespace Celeste.Game.Gameplay.Mechanisms.Switches
{
    public class OriginalTouchSwitchState : global::Celeste.Scene.Entities.SceneEntityState
    {
        protected PackedColor inactiveColor = PackedColor.FromHex("5fcde4");
        protected PackedColor activeColor = PackedColor.White;
        protected PackedColor finishColor = PackedColor.FromHex("f141df");
        private readonly IOriginalTouchSwitchProcess process;

        private global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot Level =>
            (global::Celeste.Game.Execution.Levels.OriginalLevelSceneRoot)Scene;

        public global::Celeste.Game.Components.Switches.OriginalSwitchComponent Switch;
        private float ease;
        private float timer;
        protected global::Celeste.Graphics.Animation.Sprite icon;
        private global::Celeste.Graphics.Content.Atlas.AtlasEntry border;
        private global::Celeste.Scene.Components.Oscillation.WigglerComponent wiggler;
        private global::Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState bloom;
        private global::Celeste.Simulation.Audio.Sources.SoundSourceComponentState touchSfx;
        private Vector2 pulse = Vector2.One;

        public OriginalTouchSwitchState(global::Celeste.Formats.Map.Entities.Structure.EntityData data,
            Vector2 offset, IOriginalTouchSwitchProcess process) : this(data.Position + offset, process)
        {
        }

        public OriginalTouchSwitchState(Vector2 position, IOriginalTouchSwitchProcess process)
            : base(
                ((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)process)
                .EntitySourceDataRegistration, position)
        {
            this.process = process ?? throw new ArgumentNullException(nameof(process));
            border = process.GameGraphics.GameAtlas["objects/touchswitch/container"];
            icon = new global::Celeste.Graphics.Animation.Sprite(process, process.GameGraphics.GameAtlas,
                "objects/touchswitch/icon");
            Depth = 2000;
            Switch = new global::Celeste.Game.Components.Switches.OriginalSwitchComponent(false);
            OwnedComponents.Add(Switch);
            OwnedComponents.Add(
                new global::Celeste.Simulation.Gameplay.Player.Collision.Components.PlayerColliderComponentState(
                    OnPlayer, null,
                    new global::Celeste.Physics.Collision.Shapes.HitboxColliderGeometry(30f, 30f, -15f, -15f)));
            OwnedComponents.Add(icon);
            bloom = new global::Celeste.Simulation.Presentation.PostProcessing.Bloom.BloomPointState(0f, 16f);
            OwnedComponents.Add(bloom);
            bloom.Alpha = 0f;
            icon.Add("idle", "", 0f, 0);
            icon.Add("spin", "", .1f, new global::Celeste.Core.Randomness.Chooser<string>("spin", 1f), 0, 1, 2, 3, 4,
                5);
            icon.Play("spin");
            icon.Color = inactiveColor;
            icon.CenterOrigin();
            Collider = new global::Celeste.Physics.Collision.Shapes.HitboxColliderGeometry(16f, 16f, -8f, -8f);
            OwnedComponents.Add(new global::Celeste.Simulation.Gameplay.Holdables.HoldableColliderState(OnHoldable,
                new global::Celeste.Physics.Collision.Shapes.HitboxColliderGeometry(20f, 20f, -10f, -10f)));
            OwnedComponents.Add(new global::Celeste.Game.Gameplay.Enemies.Seekers.SeekerColliderState(OnSeeker,
                new global::Celeste.Physics.Collision.Shapes.HitboxColliderGeometry(24f, 24f, -12f, -12f)));
            Switch.OnActivate = () =>
            {
                wiggler.Start();
                for (int i = 0; i < 32; i++)
                {
                    float angle =
                        global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(process.Random, (float)Math.PI * 2f);
                    Level.Particles.Emit(process.ParticleTypes.TouchSwitch.P_FireWhite,
                        Position + global::Celeste.Core.Mathematics.Vector2Geometry.AngleToVector(angle, 6f), angle);
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
            var light = new global::Celeste.Simulation.Presentation.Lighting.VertexLightState(process, Vector2.Zero,
                PackedColor.White, .8f, 16, 32);
            OwnedComponents.Add(light);
            touchSfx = process.SoundSources.Create();
            OwnedComponents.Add(touchSfx);
        }

        protected virtual global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation
            FireParticle =>
            process.ParticleTypes.TouchSwitch.P_Fire;

        public void TurnOn()
        {
            if (!Switch.Activated)
            {
                touchSfx.Play("event:/game/general/touchswitch_any");
                if (Switch.Activate())
                {
                    global::Celeste.Simulation.Audio.Emitters.SoundEmitterState.Play(
                        "event:/game/general/touchswitch_last_oneshot", process);
                    var cutoff = process.SoundSources.Create();
                    cutoff.Play("event:/game/general/touchswitch_last_cutoff");
                    OwnedComponents.Add(cutoff);
                }
            }
        }

        private void OnPlayer(global::Celeste.Simulation.RoomPlayerSession player) => TurnOn();
        private void OnHoldable(global::Celeste.Simulation.Gameplay.Holdables.HoldableState holdable) => TurnOn();

        private void OnSeeker(global::Celeste.Game.Gameplay.Enemies.Seekers.OriginalSeekerState seeker)
        {
            if (Level.InsideCamera(Position, 10f)) TurnOn();
        }

        public override void Update()
        {
            timer += process.DeltaTime * 8;
            ease = global::Celeste.Core.Mathematics.ScalarMath.Approach(ease,
                Switch.Finished || Switch.Activated ? 1 : 0, process.DeltaTime * 2, process.ExtremaArithmetic);
            icon.Color = global::Celeste.Graphics.Display.Colors.SourceColorInterpolation.Lerp(inactiveColor,
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
                    Level.ParticlesBG.Emit(FireParticle,
                        Position + new Vector2(0f, 1f) + global::Celeste.Core.Mathematics.Vector2Geometry.AngleToVector(
                            global::Celeste.Core.Randomness.SourceRandomMath.NextFloat(process.Random,
                                (float)Math.PI * 2f), 5f));
            }

            base.Update();
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            var sink =
                (global::Celeste.Core.Rendering.ISourceRenderCommandSink<
                    global::Celeste.Graphics.Display.AtlasTextureDraw>)context;
            var origin = new Vector2(border.FrameWidth / 2f, border.FrameHeight / 2f);
            var shadow = new global::Celeste.Graphics.Display.AtlasTextureDraw(border,
                Position + new Vector2(0f, -1f),
                origin, PackedColor.Black, Vector2.One);
            sink.Draw(in shadow, this);
            var face = new global::Celeste.Graphics.Display.AtlasTextureDraw(border, Position, origin, icon.Color,
                pulse);
            sink.Draw(in face, this);
            base.Render(context);
        }
    }
}

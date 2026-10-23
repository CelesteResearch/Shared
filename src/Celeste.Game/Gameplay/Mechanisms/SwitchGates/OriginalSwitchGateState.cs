using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Physics.Collision;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Components.Switches;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Gameplay.Mechanisms.SwitchGates
{
    public class OriginalSwitchGateState : SourceSolidEntityState
    {
        private readonly IOriginalSwitchGateProcess process;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;
        private AtlasEntry[,] nineSlice;

        protected Sprite icon;

        private Vector2 iconOffset;

        private WigglerComponent wiggler;

        private Vector2 node;

        private SoundSourceComponentState openSfx;

        private bool persistent;

        protected PackedColor inactiveColor = new PackedColor(95, 205, 228);

        protected PackedColor activeColor = PackedColor.White;

        protected PackedColor finishColor = new PackedColor(241, 65, 223);

        public OriginalSwitchGateState(Vector2 position, float width, float height, Vector2 node, bool persistent,
            string spriteName, IOriginalSwitchGateProcess process, ISourceSolidWorldFactory worlds)
            : this(position, width, height, node, persistent, spriteName, process, worlds,
                "objects/switchgate/icon")
        {
        }

        public OriginalSwitchGateState(Vector2 position, float width, float height, Vector2 node, bool persistent,
            string spriteName, IOriginalSwitchGateProcess process, ISourceSolidWorldFactory worlds, string iconPath)
            : base(position, width, height, false, worlds.Create(position, false))
        {
            this.process = process;
            this.node = node;
            this.persistent = persistent;
            OwnedComponents.Add(icon = new Sprite(process, process.GameGraphics.GameAtlas, iconPath));
            icon.Add("spin", "", 0.1f, new Chooser<string>("spin"));
            icon.Play("spin");
            icon.Rate = 0f;
            icon.Color = inactiveColor;
            icon.Position = (iconOffset = new Vector2(width / 2f, height / 2f));
            icon.CenterOrigin();
            OwnedComponents.Add(wiggler =
                process.WigglerPool.Create(0.5f, 4f, delegate(float f) { icon.Scale = Vector2.One * (1f + f); }));
            AtlasEntry mTexture = process.GameGraphics.GameAtlas["objects/switchgate/" + spriteName];
            nineSlice = global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.Presentation.SwitchGateRendering
                .CreateNineSlice(mTexture);

            OwnedComponents.Add(openSfx = process.SoundSources.Create());
            OwnedComponents.Add(new LightOccludeState(0.5f));
        }

        public OriginalSwitchGateState(EntityData data, Vector2 offset,
            IOriginalSwitchGateProcess process, ISourceSolidWorldFactory worlds)
            : this(data.Position + offset, data.Width, data.Height, data.Nodes[0] + offset,
                EntityAttributeReader.Bool(data.Values, "persistent"),
                EntityAttributeReader.Attr(data.Values, "sprite", "block"), process, worlds)
        {
        }

        public override void Awake(object scene)
        {
            base.Awake(scene);
            if (OriginalSwitchComponent.CheckLevelFlag(Level))
            {
                MoveTo(node);
                icon.Rate = 0f;
                icon.SetAnimationFrame(0);
                icon.Color = finishColor;
            }
            else
            {
                OwnedComponents.Add(new SimulationCoroutine(process, Sequence(node)));
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.Presentation.SwitchGateRendering.RenderFrame(context,
                this, nineSlice);

            icon.Position = iconOffset + base.Shake;
            icon.DrawOutline(context);
            base.Render(context);
        }

        private IEnumerator Sequence(Vector2 node)
        {
            Vector2 start = Position;
            while (!OriginalSwitchComponent.Check(Scene))
            {
                yield return null;
            }

            if (persistent)
            {
                OriginalSwitchComponent.SetLevelFlag(Level);
            }

            yield return 0.1f;
            openSfx.Play("event:/game/general/touchswitch_gate_open");
            StartShaking(0.5f);
            while (icon.Rate < 1f)
            {
                icon.Color =
                    SourceColorInterpolation.Lerp(inactiveColor, activeColor, icon.Rate, process.ScalarArithmetic);
                icon.Rate += process.DeltaTime * 2f;
                yield return null;
            }

            yield return 0.1f;
            int particleAt = 0;
            SourceTweenState tween = SourceTweenState.Create(process.TweenPool, SourceTweenState.TweenMode.Oneshot,
                process.EasingArithmetic.CubeOut, 2f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                MoveTo(Vector2Math.Lerp(start, node, t.Eased, process.ScalarArithmetic));
                if (Level.SourceScene.Clock.OnInterval(0.1f, process))
                {
                    particleAt++;
                    particleAt %= 2;
                    for (int i = 0; (float)i < base.Width / 8f; i++)
                    {
                        for (int j = 0; (float)j < base.Height / 8f; j++)
                        {
                            if ((i + j) % 2 == particleAt)
                            {
                                Level.ParticlesBG.Emit(process.ParticleTypes.SwitchGate.P_Behind,
                                    Position + new Vector2(i * 8, j * 8) +
                                    SourceRandomMath.Range(process.Random, Vector2.One * 2f, Vector2.One * 6f));
                            }
                        }
                    }
                }
            };
            OwnedComponents.Add(tween);
            yield return 1.8f;
            bool collidable = Collidable;
            Collidable = false;
            global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.Effects.SwitchGateParticleEffects.EmitEdgeDust(this,
                start, node, process);
            Collidable = collidable;
            process.AudioSession.Play("event:/game/general/touchswitch_gate_finish", Position, process.SaveContext);
            StartShaking(0.2f);
            while (icon.Rate > 0f)
            {
                icon.Color =
                    SourceColorInterpolation.Lerp(activeColor, finishColor, 1f - icon.Rate, process.ScalarArithmetic);
                icon.Rate -= process.DeltaTime * 4f;
                yield return null;
            }

            icon.Rate = 0f;
            icon.SetAnimationFrame(0);
            wiggler.Start();
            bool collidable2 = Collidable;
            Collidable = false;
            if (!(SourceSceneCollision.FirstPoint<ISourceEntityCollider>(Level.Scheduler.Entities, "Celeste.Solid",
                    base.Center) != null))
            {
                global::Celeste.Game.Gameplay.Mechanisms.SwitchGates.Effects.SwitchGateParticleEffects.EmitIconFire(
                    this, iconOffset, process);
            }

            Collidable = collidable2;
        }
    }
}

using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalBonfireState : SceneEntityState
    {
        public enum Mode
        {
            Unlit,
            Lit,
            Smoking,
        }

        private Mode mode;
        private readonly Sprite sprite;
        private readonly VertexLightState light;
        private readonly BloomPointState bloom;
        private readonly WigglerComponent wiggle;
        private float brightness;
        private float multiplier;
        public bool Activated;
        private readonly SoundSourceComponentState loopSfx;
        private readonly ISourceEngineContext engine;
        private OriginalLevelSceneRoot Level => (OriginalLevelSceneRoot)Scene;

        public OriginalBonfireState(Vector2 position, Mode mode, ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value;
            Depth = -5;
            OwnedComponents.Add(loopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            OwnedComponents.Add(sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("campfire"));
            OwnedComponents.Add(light = new(engine, new(0f, -6f),
                new(219, 112, 147, 255), 1f, 32, 64));
            OwnedComponents.Add(bloom = new(new(0f, -6f), 1f, 32f));
            OwnedComponents.Add(wiggle = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.2f, 4f,
                f =>
                {
                    light.Alpha = bloom.Alpha =
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f, brightness + f * 0.25f) *
                        multiplier;
                }));
            Position = position;
            this.mode = mode;
            if (((IOriginalStarJumpEnvironment)engine).StarJumpProfile == StarJumpRuntimeProfile.Installed)
            {
                var animations = sprite.Animations;
                if (animations.ContainsKey("startDream"))
                {
                    var chooser = animations["startDream"].Goto;
                    if (chooser != null && chooser[0].Equals("dreamy") && !animations.ContainsKey("dreamy"))
                        animations["startDream"].Goto = new("burnDream");
                }
            }
        }

        public OriginalBonfireState(EntityData data, Vector2 offset, ISourceEngineContext engine)
            : this(data.Position + offset, EntityAttributeReader.Enum(data.Values, "mode", Mode.Unlit), engine)
        {
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            SetMode(mode);
        }

        public void SetMode(Mode mode)
        {
            this.mode = mode;
            switch (mode)
            {
                default:
                    sprite.Play("idle");
                    bloom.Alpha = light.Alpha = brightness = 0f;
                    break;
                case Mode.Lit:
                    if (Activated)
                    {
                        var process = (IOriginalGameplayProcess)engine;
                        process.AudioSession.Play("event:/env/local/campfire_start", Position, process.SaveContext);
                        loopSfx.Play("event:/env/local/campfire_loop");
                        sprite.Play(Level.Session.Dreaming ? "startDream" : "start");
                    }
                    else
                    {
                        loopSfx.Play("event:/env/local/campfire_loop");
                        sprite.Play(Level.Session.Dreaming ? "burnDream" : "burn");
                    }

                    break;
                case Mode.Smoking:
                    sprite.Play("smoking");
                    break;
            }

            Activated = true;
        }

        public override void Update()
        {
            if (mode == Mode.Lit)
            {
                multiplier = ScalarMath.Approach(multiplier, 1f, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (Level.Clock.OnInterval(0.25f, engine))
                {
                    brightness = 0.5f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 0.5f);
                    wiggle.Start();
                }
            }

            base.Update();
        }
    }
}

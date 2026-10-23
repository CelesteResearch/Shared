using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Randomness;
using Celeste.Core.Scheduling;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Entities;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;

namespace Celeste.Game.Entities.Payphones
{
    public class OriginalPayphoneState : SceneEntityState
    {
        private readonly ISourceEngineContext engine;

        public OriginalPayphoneState(ISourceEngineContext engine, EntityData data, Vector2 offset) : this(engine,
            data.Position + offset)
        {
        }


        public bool Broken;

        public Sprite Sprite;

        public SpriteImage Blink;

        private readonly VertexLightState light;

        private readonly BloomPointState bloom;

        private float lightFlickerTimer;

        private float lightFlickerFor = 0.1f;

        private int lastFrame;

        private readonly SoundSourceComponentState buzzSfx;

        public OriginalPayphoneState(ISourceEngineContext engine, Vector2 pos)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, pos)
        {
            this.engine = engine;
            Depth = 1;
            OwnedComponents.Add(Sprite =
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.SpriteFactory.Create("payphone"));
            Sprite.Play("idle");
            OwnedComponents.Add(Blink =
                new(
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas["cutscenes/payphone/blink"]));
            Blink.Origin = Sprite.Origin;
            Blink.Visible = false;
            OwnedComponents.Add(light =
                new(engine, new(-6f, -45f), PackedColor.White, 1f, 8, 96));
            light.Spotlight = true;
            light.SpotlightDirection = Vector2Geometry.Angle(new(0f, 1f));
            OwnedComponents.Add(bloom = new(new(-6f, -45f), 0.8f, 8f));
            OwnedComponents.Add(buzzSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            buzzSfx.Play("event:/env/local/02_old_site/phone_lamp");
            buzzSfx.Param("on", 1f);
        }

        public override void Update()
        {
            base.Update();
            if (!Broken)
            {
                lightFlickerTimer -= engine.DeltaTime;
                if (lightFlickerTimer <= 0f)
                {
                    if (((OriginalLevelSceneRoot)Scene).OnInterval(0.025f))
                    {
                        var flag = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) > 0.5f;
                        light.Visible = flag;
                        bloom.Visible = flag;
                        Blink.Visible = !flag;
                        buzzSfx.Param("on", flag ? 1 : 0);
                    }

                    if (lightFlickerTimer < 0f - lightFlickerFor)
                    {
                        lightFlickerTimer = ((ISourceRandomEnvironment)engine).Random.Choose(0.4f, 0.6f, 0.8f, 1f);
                        lightFlickerFor = ((ISourceRandomEnvironment)engine).Random.Choose(0.1f, 0.2f, 0.05f);
                        light.Visible = true;
                        bloom.Visible = true;
                        Blink.Visible = false;
                        buzzSfx.Param("on", 1f);
                    }
                }
            }
            else
            {
                Blink.Visible = bloom.Visible = light.Visible = false;
                buzzSfx.Param("on", 0f);
            }

            if (Sprite.CurrentAnimationID == "eat" && Sprite.CurrentAnimationFrame == 5 &&
                lastFrame != Sprite.CurrentAnimationFrame)
            {
                var level = (OriginalLevelSceneRoot)Scene;
                level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Payphone.P_Snow, 10,
                    level.Camera.Position + new Vector2(236f, 152f), new(10f, 0f));
                level.ParticlesFG.Emit(((IOriginalGameplayProcess)engine).ParticleTypes.Payphone.P_SnowB, 8,
                    level.Camera.Position + new Vector2(236f, 152f), new(6f, 0f));
                level.DirectionalShake(Vector2.UnitY);
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            }

            if (Sprite.CurrentAnimationID == "eat" &&
                Sprite.CurrentAnimationFrame == Sprite.CurrentAnimationTotalFrames - 5 &&
                lastFrame != Sprite.CurrentAnimationFrame)
                ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(0, 1);

            lastFrame = Sprite.CurrentAnimationFrame;
        }
    }
}

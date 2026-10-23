using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Scheduling;
using Celeste.Core.Randomness;
using Celeste.Core.Audio;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Player.Dash;
using Celeste.Simulation.Audio.Sources;
using Celeste.Simulation.Runtime.Session;
using Celeste.Simulation.Presentation.Particles;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Entities.Collectibles.Hearts;
using Celeste.Game.Entities.Effects.AbsorbOrbs;
using Celeste.Game.Presentation.Particles;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Particles.Sources;
using Celeste.Core.Rendering;

namespace Celeste.Game.Entities.Puzzles.ForsakenSatellite
{
    public class OriginalForsakenCitySatelliteState : SceneEntityState
    {
        private class CodeBird : SceneEntityState
        {
            private Sprite sprite;

            private SimulationCoroutine routine;

            private float timer;
            private readonly ISourceEngineContext engine;
            private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

            private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
                ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

            private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
            private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
            private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
            private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;

            private OriginalSatelliteProcessState SourceState =>
                ((IOriginalSatelliteEnvironment)engine).SatelliteProcess;

            private Dictionary<string, PackedColor> Colors => Process.ParticleTypes.ForsakenCitySatellite.Colors;

            private Dictionary<string,
                global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation> Particles =>
                Process.ParticleTypes.ForsakenCitySatellite.Particles;


            private Vector2 speed;

            private SpriteImage heartImage;

            private readonly string code;

            private readonly Vector2 origin;

            private readonly Vector2 dash;

            public CodeBird(ISourceEngineContext engine, Vector2 origin, string code)
                : this(engine, origin, code, SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random))
            {
            }

            private CodeBird(ISourceEngineContext engine, Vector2 origin, string code, float initialTimer)
                : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, origin)
            {
                this.engine = engine;
                timer = initialTimer;
                this.code = code;
                this.origin = origin;
                OwnedComponents.Add(sprite = new Sprite(engine, GameAtlas, "scenery/flutterbird/"));
                sprite.AddLoop("fly", "flap", 0.08f);
                sprite.Play("fly");
                sprite.CenterOrigin();
                sprite.Color = Colors[code];
                Vector2 zero = Vector2.Zero;
                zero.X = (Enumerable.Contains(code, 'L') ? (-1) : (Enumerable.Contains(code, 'R') ? 1 : 0));
                zero.Y = (Enumerable.Contains(code, 'U') ? (-1) : (Enumerable.Contains(code, 'D') ? 1 : 0));
                dash = VectorArithmetic.SafeNormalize(zero);
                OwnedComponents.Add(routine = new SimulationCoroutine(engine, AimlessFlightRoutine()));
            }

            public override void Update()
            {
                timer += engine.DeltaTime;
                sprite.Position.Y = (float)Math.Sin(timer * 2f);
                base.Update();
            }

            public void Dash()
            {
                routine.Replace(DashRoutine());
            }

            public void Transform(float duration)
            {
                Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
                routine.Replace(TransformRoutine(duration));
            }

            private IEnumerator AimlessFlightRoutine()
            {
                speed = Vector2.Zero;
                while (true)
                {
                    Vector2 target = origin + Vector2Geometry.AngleToVector(
                        SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f),
                        16f + SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, 40f));
                    float reset = 0f;
                    while (reset < 1f && VectorArithmetic.Length(target - Position) > 8f)
                    {
                        Vector2 vector = VectorArithmetic.SafeNormalize(target - Position);
                        speed += vector * 420f * engine.DeltaTime;
                        if (VectorArithmetic.Length(speed) > 90f)
                        {
                            speed = VectorArithmetic.SafeNormalize(speed, 90f);
                        }

                        Position += speed * engine.DeltaTime;
                        reset += engine.DeltaTime;
                        if (Math.Sign(vector.X) != 0)
                        {
                            sprite.Scale.X = Math.Sign(vector.X);
                        }

                        yield return null;
                    }
                }
            }

            private IEnumerator DashRoutine()
            {
                for (float t = 0.25f; t > 0f; t -= engine.DeltaTime)
                {
                    speed = VectorArithmetic.Approach(speed, Vector2.Zero, 200f * engine.DeltaTime);
                    Position += speed * engine.DeltaTime;
                    yield return null;
                }

                Vector2 from = Position;
                Vector2 to = origin + dash * 8f;
                if (Math.Sign(to.X - from.X) != 0)
                {
                    sprite.Scale.X = Math.Sign(to.X - from.X);
                }

                for (float t = 0f; t < 1f; t += engine.DeltaTime * 1.5f)
                {
                    Position = from + (to - from) * Easing.CubeInOut(t);
                    yield return null;
                }

                Position = to;
                yield return 0.2f;
                if (dash.X != 0f)
                {
                    sprite.Scale.X = Math.Sign(dash.X);
                }

                (base.Scene as OriginalLevelSceneRoot).Displacement.AddBurst(Position, 0.25f, 4f, 24f, 0.4f);
                speed = dash * 300f;
                for (float t = 0.4f; t > 0f; t -= engine.DeltaTime)
                {
                    if (t > 0.1f && ((OriginalLevelSceneRoot)Scene).OnInterval(0.02f))
                    {
                        ((OriginalLevelSceneRoot)Scene).ParticlesBG.Emit(Particles[code], 1, Position, Vector2.One * 2f,
                            Vector2Geometry.Angle(dash));
                    }

                    speed = VectorArithmetic.Approach(speed, Vector2.Zero, 800f * engine.DeltaTime);
                    Position += speed * engine.DeltaTime;
                    yield return null;
                }

                yield return 0.4f;
                routine.Replace(AimlessFlightRoutine());
            }

            private IEnumerator TransformRoutine(float duration)
            {
                PackedColor colorFrom = sprite.Color;
                PackedColor colorTo = PackedColor.White;
                Vector2 target = origin;
                OwnedComponents.Add(heartImage = new SpriteImage(GameAtlas["collectables/heartGem/shape"]));
                heartImage.CenterOrigin();
                heartImage.Scale = Vector2.Zero;
                for (float t = 0f; t < 1f; t += engine.DeltaTime / duration)
                {
                    Vector2 vector = VectorArithmetic.SafeNormalize(target - Position);
                    speed += 400f * vector * engine.DeltaTime;
                    float num = Extrema.Max(20f, (1f - t) * 200f);
                    if (VectorArithmetic.Length(speed) > num)
                    {
                        speed = VectorArithmetic.SafeNormalize(speed, num);
                    }

                    Position += speed * engine.DeltaTime;
                    sprite.Color = SourceColorInterpolation.Lerp(colorFrom, colorTo, t,
                        ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                    heartImage.Scale = Vector2.One * Extrema.Max(0f, (t - 0.75f) * 4f);
                    if (vector.X != 0f)
                    {
                        sprite.Scale.X = Math.Abs(sprite.Scale.X) * (float)Math.Sign(vector.X);
                    }

                    sprite.Scale.X = (float)Math.Sign(sprite.Scale.X) * (1f - heartImage.Scale.X);
                    sprite.Scale.Y = 1f - heartImage.Scale.X;
                    yield return null;
                }
            }
        }

        private const string UnlockedFlag = "unlocked_satellite";


        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private global::Celeste.Graphics.Content.Atlas.AtlasData GameAtlas =>
            ((ISourceGameGraphicsEnvironment)engine).GameGraphics.GameAtlas;

        private ISourceVectorArithmetic VectorArithmetic => ((ISourceVectorEnvironment)engine).VectorArithmetic;
        private ISourceExtremaArithmetic Extrema => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic;
        private ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        private ISourceCurveArithmetic CurveArithmetic => ((ISourceCurveEnvironment)engine).CurveArithmetic;
        private OriginalSatelliteProcessState SourceState => ((IOriginalSatelliteEnvironment)engine).SatelliteProcess;
        private Dictionary<string, PackedColor> Colors => Process.ParticleTypes.ForsakenCitySatellite.Colors;

        private Dictionary<string,
                global::Celeste.Simulation.Presentation.Particles.Definitions.ParticleTypePresentation>
            Particles => Process.ParticleTypes.ForsakenCitySatellite.Particles;

        private bool enabled;

        private List<string> currentInputs = new List<string>();

        private List<CodeBird> birds = new List<CodeBird>();

        private Vector2 gemSpawnPosition;

        private Vector2 birdFlyPosition;

        private SpriteImage sprite;

        private SpriteImage pulse;

        private SpriteImage computer;

        private SpriteImage computerScreen;

        private Sprite computerScreenNoise;

        private SpriteImage computerScreenShine;

        private BloomPointState pulseBloom;

        private BloomPointState screenBloom;

        private OriginalLevelSceneRoot level;

        private DashListenerState dashListener;

        private SoundSourceComponentState birdFlyingSfx;

        private SoundSourceComponentState birdThrustSfx;

        private SoundSourceComponentState birdFinishSfx;

        private SoundSourceComponentState staticLoopSfx;

        public OriginalForsakenCitySatelliteState(ISourceEngineContext engine, EntityData data, Vector2 offset)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset)
        {
            this.engine = engine;
            OwnedComponents.Add(sprite = new SpriteImage(GameAtlas["objects/citysatellite/dish"]));
            OwnedComponents.Add(pulse = new SpriteImage(GameAtlas["objects/citysatellite/light"]));
            OwnedComponents.Add(computer = new SpriteImage(GameAtlas["objects/citysatellite/computer"]));
            OwnedComponents.Add(computerScreen = new SpriteImage(GameAtlas["objects/citysatellite/computerscreen"]));
            OwnedComponents.Add(computerScreenNoise =
                new Sprite(engine, GameAtlas, "objects/citysatellite/computerScreenNoise"));
            OwnedComponents.Add(computerScreenShine =
                new SpriteImage(GameAtlas["objects/citysatellite/computerscreenShine"]));
            sprite.JustifyOrigin(0.5f, 1f);
            pulse.JustifyOrigin(0.5f, 1f);
            OwnedComponents.Add(new SimulationCoroutine(engine, PulseRoutine()));
            OwnedComponents.Add(pulseBloom = new BloomPointState(new Vector2(-12f, -44f), 1f, 8f));
            OwnedComponents.Add(screenBloom = new BloomPointState(new Vector2(32f, 20f), 1f, 8f));
            computerScreenNoise.AddLoop("static", "", 0.05f);
            computerScreenNoise.Play("static");
            computer.Position = (computerScreen.Position =
                (computerScreenShine.Position = (computerScreenNoise.Position = new Vector2(8f, 8f))));
            birdFlyPosition = offset + data.Nodes[0];
            gemSpawnPosition = offset + data.Nodes[1];
            OwnedComponents.Add(dashListener = new DashListenerState());
            dashListener.OnDash = delegate(Vector2 dir)
            {
                string text = "";
                if (dir.Y < 0f)
                {
                    text = "U";
                }
                else if (dir.Y > 0f)
                {
                    text = "D";
                }

                if (dir.X < 0f)
                {
                    text += "L";
                }
                else if (dir.X > 0f)
                {
                    text += "R";
                }

                currentInputs.Add(text);
                if (currentInputs.Count > SourceState.Code.Length)
                {
                    currentInputs.RemoveAt(0);
                }

                if (currentInputs.Count == SourceState.Code.Length)
                {
                    bool flag = true;
                    for (int i = 0; i < SourceState.Code.Length; i++)
                    {
                        if (!currentInputs[i].Equals(SourceState.Code[i]))
                        {
                            flag = false;
                        }
                    }

                    if (flag && level.Camera.Left + 32f < gemSpawnPosition.X && enabled)
                    {
                        OwnedComponents.Add(new SimulationCoroutine(engine, UnlockGem()));
                    }
                }
            };
            string[] code = SourceState.Code;
            foreach (string item in code)
            {
                if (!SourceState.UniqueCodes.Contains(item))
                {
                    SourceState.UniqueCodes.Add(item);
                }
            }

            base.Depth = 8999;
            OwnedComponents.Add(staticLoopSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
            staticLoopSfx.Position = computer.Position;
        }

        public override void Added(object scene)
        {
            base.Added(scene);
            level = scene as OriginalLevelSceneRoot;
            enabled = !level.Session.HeartGem && !level.Session.GetFlag("unlocked_satellite");
            if (enabled)
            {
                foreach (string uniqueCode in SourceState.UniqueCodes)
                {
                    CodeBird codeBird = new CodeBird(engine, birdFlyPosition, uniqueCode);
                    birds.Add(codeBird);
                    level.Scheduler.QueueSourceEntity(codeBird);
                }

                OwnedComponents.Add(birdFlyingSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
                OwnedComponents.Add(birdFinishSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
                OwnedComponents.Add(birdThrustSfx = ((ISourceSoundSourceEnvironment)engine).SoundSources.Create());
                birdFlyingSfx.Position = birdFlyPosition - Position;
                birdFlyingSfx.Play("event:/game/01_forsaken_city/birdbros_fly_loop");
            }
            else
            {
                staticLoopSfx.Play("event:/game/01_forsaken_city/console_static_loop");
            }

            if (!level.Session.HeartGem && level.Session.GetFlag("unlocked_satellite"))
            {
                OriginalHeartGemState entity = new OriginalHeartGemState(engine, gemSpawnPosition);
                level.Scheduler.QueueSourceEntity(entity);
            }
        }

        public override void Update()
        {
            base.Update();
            computerScreenNoise.Visible = !pulse.Visible;
            computerScreen.Visible = pulse.Visible;
            screenBloom.Visible = pulseBloom.Visible;
        }

        private IEnumerator PulseRoutine()
        {
            BloomPointState bloomPoint = pulseBloom;
            SpriteImage image = pulse;
            bool visible = false;
            image.Visible = false;
            bloomPoint.Visible = visible;
            while (enabled)
            {
                yield return 2f;
                for (int i = 0; i < SourceState.Code.Length; i++)
                {
                    if (!enabled)
                    {
                        break;
                    }

                    pulse.Color = (computerScreen.Color = Colors[SourceState.Code[i]]);
                    BloomPointState bloomPoint2 = pulseBloom;
                    SpriteImage image2 = pulse;
                    visible = true;
                    image2.Visible = true;
                    bloomPoint2.Visible = visible;
                    Process.AudioSession.Play(SourceState.Sounds[SourceState.Code[i]], Position + computer.Position,
                        Process.SaveContext);
                    yield return 0.5f;
                    BloomPointState bloomPoint3 = pulseBloom;
                    SpriteImage image3 = pulse;
                    visible = false;
                    image3.Visible = false;
                    bloomPoint3.Visible = visible;
                    Process.AudioSession.Play(
                        (i < SourceState.Code.Length - 1)
                            ? "event:/game/01_forsaken_city/console_static_short"
                            : "event:/game/01_forsaken_city/console_static_long", Position + computer.Position,
                        Process.SaveContext);
                    yield return 0.2f;
                }

                SourceAlarmState.Set(engine.AlarmPool, OwnedComponents, 1.1f, delegate
                {
                    if (enabled)
                    {
                        birdThrustSfx.Position = birdFlyPosition - Position;
                        birdThrustSfx.Play("event:/game/01_forsaken_city/birdbros_thrust");
                    }
                });
                birds.Shuffle(((ISourceRandomEnvironment)engine).Random);
                foreach (CodeBird bird in birds)
                {
                    if (enabled)
                    {
                        bird.Dash();
                        yield return 0.02f;
                    }
                }
            }

            BloomPointState bloomPoint4 = pulseBloom;
            SpriteImage image4 = pulse;
            visible = false;
            image4.Visible = false;
            bloomPoint4.Visible = visible;
        }

        private IEnumerator UnlockGem()
        {
            level.Session.SetFlag("unlocked_satellite");
            birdFinishSfx.Position = birdFlyPosition - Position;
            birdFinishSfx.Play("event:/game/01_forsaken_city/birdbros_finish");
            staticLoopSfx.Play("event:/game/01_forsaken_city/console_static_loop");
            enabled = false;
            yield return 0.25f;
            level.Displacement.Clear();
            yield return null;
            birdFlyingSfx.Stop();
            level.Frozen = true;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            BloomPointState bloom = new BloomPointState(birdFlyPosition - Position, 0f, 32f);
            OwnedComponents.Add(bloom);
            foreach (CodeBird bird in birds)
            {
                bird.Transform(3f);
            }

            while (bloom.Alpha < 1f)
            {
                bloom.Alpha += engine.DeltaTime / 3f;
                yield return null;
            }

            yield return 0.25f;
            foreach (CodeBird bird2 in birds)
            {
                bird2.RemoveSelf();
            }

            ParticleSystemPresentation particles =
                new ParticleSystemPresentation(-10000, 100, engine, (ISourceParticleTextureEnvironment)engine);
            particles.Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value;
            particles.Emit(Process.ParticleTypes.BirdNPC.P_Feather, 24, birdFlyPosition, new Vector2(4f, 4f));
            level.Scheduler.QueueSourceEntity(particles);
            OriginalHeartGemState gem = new OriginalHeartGemState(engine, birdFlyPosition)
            {
                Tags = ((IOriginalGameTagsEnvironment)engine).Tags.FrozenUpdate.Value
            };
            level.Scheduler.QueueSourceEntity(gem);
            yield return null;
            gem.ScaleWiggler.Start();
            yield return 0.85f;
            SimpleCurve curve = new SimpleCurve(gem.Position, gemSpawnPosition,
                VectorArithmetic.Divide(gem.Position + gemSpawnPosition, 2f) + new Vector2(0f, -64f));
            for (float t = 0f; t < 1f; t += engine.DeltaTime)
            {
                yield return null;
                gem.Position = curve.GetPoint(Easing.CubeInOut(t), CurveArithmetic);
            }

            yield return 0.5f;
            particles.RemoveSelf();
            OwnedComponents.Remove(bloom);
            level.Frozen = false;
        }
    }
}

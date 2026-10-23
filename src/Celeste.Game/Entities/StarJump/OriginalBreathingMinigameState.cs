using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Core.Timing;
using Celeste.Game.Audio;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Effects.MagicGlow;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Input.Gameplay;
using Celeste.Input.Gameplay.Feedback;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalBreathingMinigameState : SceneEntityState
    {
        private struct Particle
        {
            public Vector2 Position;

            public float Speed;

            public float Scale;

            public float Sin;

            public void Reset(ISourceEngineContext engine)
            {
                var num = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random);
                num *= num * num * num;
                Position = new(SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 1920f,
                    SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random) * 1080f);
                Scale = ScalarMath.Map(num, 0f, 1f, 0.05f, 0.8f);
                Speed = Scale * SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, 2f, 8f);
                Sin = SourceRandomMath.NextFloat(((ISourceRandomEnvironment)engine).Random, (float)Math.PI * 2f);
            }
        }

        private const float StablizeDuration = 30f;

        private const float StablizeLossRate = 0.5f;

        private const float StablizeIncreaseDelay = 0.2f;

        private const float StablizeLossPenalty = 0.5f;

        private const float Acceleration = 280f;

        private const float Gravity = 280f;

        private const float Maxspeed = 200f;

        private const float Bounds = 450f;

        private const float BGFadeStart = 0.65f;

        private const float featherSpriteOffset = -128f;

        private const float FadeBoxInMargin = 300f;

        private const float TargetSineAmplitude = 300f;

        private const float TargetSineFreq = 0.25f;

        private const float TargetBoundsAtStart = 160f;

        private const float TargetBoundsAtEnd = 100f;

        public const float MaxRumble = 0.5f;

        private const float PercentBeforeStartLosing = 0.4f;

        private const float LoseDuration = 5f;

        public bool Completed;

        public bool Pausing;

        private readonly bool winnable;

        private float boxAlpha;

        private float featherAlpha;

        private float bgAlpha;

        private float feather;

        private float speed;

        private float stablizedTimer;

        private float currentTargetBounds = 160f;

        private float currentTargetCenter;

        private float speedMultiplier = 1f;

        private float insideTargetTimer;

        private bool boxEnabled;

        private float trailSpeed;

        private bool losing;

        private float losingTimer;

        private readonly Sprite featherSprite;

        private SpriteImage featherSlice;

        private SpriteImage featherHalfLeft;

        private SpriteImage featherHalfRight;

        private SineWaveState sine;

        private readonly SineWaveState featherWave;

        private OriginalBreathingRumblerState rumbler;

        private string text;

        private float textAlpha;

        private VirtualRenderTarget featherBuffer;

        private VirtualRenderTarget smokeBuffer;

        private VirtualRenderTarget tempBuffer;

        private float timer;

        private readonly Particle[] particles;

        private readonly AtlasEntry particleTexture;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private float particleSpeed;

        private float particleAlpha;

        private Vector2 screenCenter =>
            ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(new Vector2(1920f, 1080f), 2f);

        public OriginalBreathingMinigameState(ISourceEngineContext engine, bool winnable = true,
            OriginalBreathingRumblerState rumbler = null)
            : this(
                ((IOriginalOverworldGraphicsEnvironment)engine).OverworldGraphics.Atlas["snow"]
                .GetSubtexture(1, 1, 254, 254), engine, winnable, rumbler)
        {
        }

        private OriginalBreathingMinigameState(AtlasEntry particleTexture, ISourceEngineContext engine, bool winnable,
            OriginalBreathingRumblerState rumbler)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.particleTexture = particleTexture;
            this.engine = engine;
            this.rumbler = rumbler;
            this.winnable = winnable;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            Depth = 100;
            OwnedComponents.Add(featherSprite =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiSpriteBank
                .Create("feather"));
            featherSprite.Position = screenCenter + Vector2.UnitY * (feather + -128f);
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
            OwnedComponents.Add(featherWave = new(engine, 0.25f));
            OwnedComponents.Add(new BeforeRenderCallbackComponentState(BeforeRender));
            particles = new Particle[50];
            for (var i = 0; i < particles.Length; i++) particles[i].Reset(engine);

            particleSpeed = 120f;
        }

        public IEnumerator Routine()
        {
            insideTargetTimer = 1f;
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                yield return null;
                if (p > 1f) p = 1f;

                bgAlpha = p * 0.65f;
            }

            if (winnable)
            {
                yield return ShowText(1);
                yield return FadeGameIn();
                yield return ShowText(2);
                yield return ShowText(3);
                yield return ShowText(4);
                yield return ShowText(5);
            }
            else
            {
                yield return FadeGameIn();
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, FadeBoxIn()));
            var activeBounds = 450f;
            while (stablizedTimer < 30f)
            {
                var num = stablizedTimer / 30f;
                var flag = ((ISourceGameInputEnvironment)engine).Input.Jump.Check ||
                           ((ISourceGameInputEnvironment)engine).Input.Dash.Check ||
                           ((ISourceGameInputEnvironment)engine).Input.Aim.Value.Y < 0f;
                if (winnable)
                {
                    Process.AudioSession.SetMusicParam("calm", num);
                    Process.AudioSession.SetMusicParam("gondola_idle", num);
                }
                else
                {
                    var level = Scene as OriginalLevelSceneRoot;
                    if (!losing)
                    {
                        var num2 = num / 0.4f;
                        level.Session.Audio.Music.Layer(1, num2);
                        level.Session.Audio.Music.Layer(3, 1f - num2);
                        OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                            Process.AudioApplyPolicy);
                    }
                    else
                    {
                        level.Session.Audio.Music.Layer(1, 1f - losingTimer);
                        level.Session.Audio.Music.Layer(3, losingTimer);
                        OriginalAudioSession.Apply(level.Session.Audio, Process.AudioSession.ChannelOutput,
                            Process.AudioApplyPolicy);
                    }
                }

                if (!winnable && losing)
                {
                    if (IntervalQueries.BetweenInterval(losingTimer * 10f, 0.5f)) flag = !flag;

                    activeBounds = 450f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(losingTimer) *
                        200f;
                }

                if (flag)
                {
                    if (feather > 0f - activeBounds) speed -= 280f * engine.DeltaTime;

                    particleSpeed -= 2800f * engine.DeltaTime;
                }
                else
                {
                    if (feather < activeBounds) speed += 280f * engine.DeltaTime;

                    particleSpeed += 2800f * engine.DeltaTime;
                }

                speed = ScalarMath.Clamp(speed, -200f, 200f);
                if (feather > activeBounds && speedMultiplier == 0f && speed > 0f) speed = 0f;

                if (feather < activeBounds && speedMultiplier == 0f && speed < 0f) speed = 0f;

                particleSpeed = ScalarMath.Clamp(particleSpeed, -1600f, 120f);
                speedMultiplier = ScalarMath.Approach(speedMultiplier,
                    (!(feather < 0f - activeBounds) || !(speed < 0f)) && (!(feather > activeBounds) || !(speed > 0f))
                        ? 1
                        : 0, engine.DeltaTime * 4f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                currentTargetBounds = ScalarMath.Approach(currentTargetBounds, 160f + -60f * num,
                    engine.DeltaTime * 16f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                feather += speed * speedMultiplier * engine.DeltaTime;
                if (boxEnabled)
                {
                    currentTargetCenter = (0f - sine.Value) * 300f *
                                          ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(1f, 0f,
                                              ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(num));
                    var num3 = currentTargetCenter - currentTargetBounds;
                    var num4 = currentTargetCenter + currentTargetBounds;
                    if (feather > num3 && feather < num4)
                    {
                        insideTargetTimer += engine.DeltaTime;
                        if (insideTargetTimer > 0.2f) stablizedTimer += engine.DeltaTime;

                        if (rumbler != null) rumbler.Strength = 0.3f * (1f - num);
                    }
                    else
                    {
                        if (insideTargetTimer > 0.2f)
                            stablizedTimer =
                                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(0f, stablizedTimer - 0.5f);

                        if (stablizedTimer > 0f) stablizedTimer -= 0.5f * engine.DeltaTime;

                        insideTargetTimer = 0f;
                        if (rumbler != null) rumbler.Strength = 0.5f * (1f - num);
                    }
                }
                else if (rumbler != null)
                {
                    rumbler.Strength = 0.2f;
                }

                var target = 0.65f + ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f, num / 0.8f) *
                    0.35000002f;
                bgAlpha = ScalarMath.Approach(bgAlpha, target, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                featherSprite.Position = screenCenter + Vector2.UnitY * (feather + -128f);
                featherSprite.Play(insideTargetTimer > 0f || !boxEnabled ? "hover" : "flutter");
                particleAlpha = ScalarMath.Approach(particleAlpha, 1f, engine.DeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                if (!winnable && stablizedTimer > 12f) losing = true;

                if (losing)
                {
                    losingTimer += engine.DeltaTime / 5f;
                    if (losingTimer > 1f) break;
                }

                yield return null;
            }

            if (!winnable)
            {
                Pausing = true;
                while (Pausing)
                {
                    if (rumbler != null)
                        rumbler.Strength = ScalarMath.Approach(rumbler.Strength, 1f, 2f * engine.DeltaTime,
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);

                    featherSprite.Position += (screenCenter - featherSprite.Position) *
                                              (1f - (float)Math.Pow(0.009999999776482582, engine.DeltaTime));
                    boxAlpha -= engine.DeltaTime * 10f;
                    particleAlpha = boxAlpha;
                    yield return null;
                }

                losing = false;
                losingTimer = 0f;
                yield return PopFeather();
            }
            else
            {
                bgAlpha = 1f;
                if (rumbler != null)
                {
                    rumbler.RemoveSelf();
                    rumbler = null;
                }

                while (boxAlpha > 0f)
                {
                    yield return null;
                    boxAlpha -= engine.DeltaTime;
                    particleAlpha = boxAlpha;
                }

                particleAlpha = 0f;
                yield return 2f;
                while (featherAlpha > 0f)
                {
                    yield return null;
                    featherAlpha -= engine.DeltaTime;
                }

                yield return 1f;
            }

            for (Completed = true; bgAlpha > 0f; bgAlpha -= engine.DeltaTime * (winnable ? 1f : 10f)) yield return null;

            RemoveSelf();
        }

        private IEnumerator ShowText(int num)
        {
            yield return FadeTextTo(0f);
            text = ((IOriginalGameTextEnvironment)engine).Text.CleanDialog("CH4_GONDOLA_FEATHER_" + num);
            yield return 0.1f;
            yield return FadeTextTo(1f);
            while (!((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed) yield return null;

            yield return FadeTextTo(0f);
        }

        private IEnumerator FadeGameIn()
        {
            while (featherAlpha < 1f)
            {
                featherAlpha += engine.DeltaTime;
                yield return null;
            }

            featherAlpha = 1f;
        }

        private IEnumerator FadeBoxIn()
        {
            yield return winnable ? 5f : 2f;
            while (Math.Abs(feather) > 300f) yield return null;

            boxEnabled = true;
            OwnedComponents.Add(sine = new(engine, 0.12f));
            while (boxAlpha < 1f)
            {
                boxAlpha += engine.DeltaTime;
                yield return null;
            }

            boxAlpha = 1f;
        }

        private IEnumerator FadeTextTo(float v)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (textAlpha != v)
            {
                var from = textAlpha;
                for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
                {
                    yield return null;
                    textAlpha = from + (v - from) * p;
                }

                textAlpha = v;
            }
        }

        private IEnumerator PopFeather()
        {
            Process.AudioSession.Play("event:/game/06_reflection/badeline_feather_slice");
            ((ISourceRumbleEnvironment)engine).RumbleSession.Rumble(2, 1);
            if (rumbler != null)
            {
                rumbler.RemoveSelf();
                rumbler = null;
            }

            featherSprite.Rotation = 0f;
            featherSprite.Play("hover");
            featherSprite.CenterOrigin();
            featherSprite.Position.Y += featherSprite.Height / 2f;
            yield return 0.25f;
            featherSlice =
                new(((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .GuiAtlas["feather/slice"]);
            featherSlice.CenterOrigin();
            featherSlice.Position = featherSprite.Position;
            featherSlice.Rotation = Vector2Geometry.Angle(new(96f, 165f), new(140f, 112f));
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 8f)
            {
                featherSlice.Scale.X = (0.25f + ScalarMath.YoYo(p) * 0.75f) * 8f;
                featherSlice.Scale.Y = (0.5f + (1f - ScalarMath.YoYo(p)) * 0.5f) * 8f;
                featherSlice.Position = featherSprite.Position + Vector2Interpolation.Lerp(new(128f, -128f),
                    new(-128f, 128f), p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                yield return null;
            }

            featherSlice.Visible = false;
            (Scene as OriginalLevelSceneRoot).Shake();
            (Scene as OriginalLevelSceneRoot).Flash(PackedColor.White);
            featherSprite.Visible = false;
            featherHalfLeft =
                new(((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .GuiAtlas["feather/feather_half0"]);
            featherHalfLeft.CenterOrigin();
            featherHalfRight =
                new(((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                    .GuiAtlas["feather/feather_half1"]);
            featherHalfRight.CenterOrigin();
            for (var p = 0f; p < 1f; p += engine.DeltaTime)
            {
                featherHalfLeft.Position = featherSprite.Position + Vector2Interpolation.Lerp(Vector2.Zero,
                    new(-128f, -32f), p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                featherHalfRight.Position = featherSprite.Position + Vector2Interpolation.Lerp(Vector2.Zero,
                    new(128f, 32f), p, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                featherAlpha = 1f - p;
                yield return null;
            }
        }

        public override void Update()
        {
            timer += engine.DeltaTime;
            trailSpeed = ScalarMath.Approach(trailSpeed, speed, engine.DeltaTime * 200f * 8f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (featherWave != null) featherSprite.Rotation = featherWave.Value * 0.25f + 0.1f;

            for (var i = 0; i < particles.Length; i++)
            {
                particles[i].Position.Y += particles[i].Speed * particleSpeed * engine.DeltaTime;
                if (particleSpeed > -400f)
                    particles[i].Position.X +=
                        (particleSpeed + 400f) * (float)Math.Sin(particles[i].Sin) * 0.1f * engine.DeltaTime;

                particles[i].Sin += engine.DeltaTime;
                if (particles[i].Position.Y < -128f || particles[i].Position.Y > 1208f)
                {
                    particles[i].Reset(engine);
                    if (particleSpeed < 0f)
                        particles[i].Position.Y = 1208f;
                    else
                        particles[i].Position.Y = -128f;
                }
            }

            base.Update();
        }

        public void BeforeRender()
        {
            var context = ((ISourceRenderEnvironment)engine).CurrentContext;
            if (featherBuffer == null)
            {
                var num = Math.Min(1920, ((ISourceEngineViewEnvironment)engine).ViewWidth);
                var num2 = Math.Min(1080, ((ISourceEngineViewEnvironment)engine).ViewHeight);
                featherBuffer =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("breathing-minigame-a",
                        num, num2);
                smokeBuffer =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("breathing-minigame-b",
                        num / 2, num2 / 2);
                tempBuffer =
                    ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("breathing-minigame-c",
                        num / 2, num2 / 2);
            }

            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(featherBuffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            var transformMatrix = SourceMatrixMath.CreateScale(featherBuffer.Width / 1920f);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred,
                SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, null, null, null, transformMatrix);
            if (losing)
            {
                featherSprite.Position += ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                    new Vector2(SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -1, 1),
                        SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -1, 1))) * losingTimer * 10f;
                featherSprite.Rotation +=
                    SourceRandomMath.Range(((ISourceRandomEnvironment)engine).Random, -1, 1) *
                    losingTimer * 0.1f;
            }

            featherSprite.Color = PackedColor.White * featherAlpha;
            if (featherSprite.Visible) featherSprite.Render(context);

            if (featherSlice != null && featherSlice.Visible) featherSlice.Render(context);

            if (featherHalfLeft != null && featherHalfLeft.Visible)
            {
                featherHalfLeft.Color = PackedColor.White * featherAlpha;
                featherHalfRight.Color = PackedColor.White * featherAlpha;
                featherHalfLeft.Render(context);
                featherHalfRight.Render(context);
            }

            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.SetRenderTarget(smokeBuffer.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice.Clear(PackedColor.Transparent);
            MagicGlowPresentation.Render((ISourceMagicGlowEnvironment)engine, featherBuffer.Target, timer,
                (0f - trailSpeed) / 200f * 2f, SourceMatrixMath.CreateScale(0.5f));
            GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)engine, smokeBuffer.Target, tempBuffer,
                smokeBuffer);
        }

        public override void Render(ISourceRenderContext context)
        {
            var color = insideTargetTimer > 0.2f ? PackedColor.White : PackedColor.White * 0.6f;
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * bgAlpha);
            if (!(Scene is OriginalLevelSceneRoot level) ||
                (!level.FrozenOrPaused && level.RetryPlayerCorpse == null && !level.SkippingCutscene))
            {
                var mTexture =
                    ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                        "feather/border"];
                var mTexture2 =
                    ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                        "feather/box"];
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2,
                    screenCenter + new Vector2(0f, currentTargetCenter), PackedColor.White * boxAlpha * 0.25f,
                    new Vector2((mTexture.FrameWidth * 2f - 32f) / mTexture2.FrameWidth,
                        (currentTargetBounds * 2f - 32f) / mTexture2.FrameHeight));
                SourceAtlasDrawing.Draw(context, this, mTexture,
                    screenCenter + new Vector2(-mTexture.FrameWidth, currentTargetCenter - currentTargetBounds),
                    Vector2.Zero, color * boxAlpha, Vector2.One);
                SourceAtlasDrawing.Draw(context, this, mTexture,
                    screenCenter + new Vector2(mTexture.FrameWidth, currentTargetCenter + currentTargetBounds),
                    Vector2.Zero, color * boxAlpha, new Vector2(-1f, -1f));
                if (featherBuffer != null && !featherBuffer.IsDisposed)
                {
                    var num = 1920f / featherBuffer.Width;
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(smokeBuffer.Target, Vector2.Zero,
                        smokeBuffer.Bounds,
                        (PackedColor.White * 0.3f).PackedValue, 0f, Vector2.Zero, num * 2f, SourceSpriteEffects.None,
                        0f);
                    ((ISourceDrawScope)engine).Draw.SpriteBatch.Draw(featherBuffer.Target, Vector2.Zero,
                        featherBuffer.Bounds, PackedColor.White.PackedValue, 0f, Vector2.Zero, num,
                        SourceSpriteEffects.None, 0f);
                }

                var vector = new Vector2(1f, 1f);
                if (particleSpeed < 0f)
                    vector = new(
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(1f,
                            1f / ((0f - particleSpeed) * 0.004f)),
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(1f,
                            1f * (0f - particleSpeed) * 0.004f));

                for (var i = 0; i < particles.Length; i++)
                {
                    var position = particles[i].Position;
                    var scale = particles[i].Scale * vector;
                    SourceAtlasDrawing.DrawCentered(context, this, particleTexture, position,
                        PackedColor.White * (0.5f * particleAlpha), scale);
                }

                if (!string.IsNullOrEmpty(text) && textAlpha > 0f)
                    ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Draw(context, this, text,
                        new(960f, 920f), new(0.5f, 0.5f), Vector2.One, PackedColor.White * textAlpha);

                if (!string.IsNullOrEmpty(text) && textAlpha >= 1f)
                {
                    var vector2 = ((IOriginalGameTextEnvironment)engine).Text.ActiveFont.Measure(text);
                    var position2 = new Vector2((1920f + vector2.X) / 2f + 40f, 920f + vector2.Y / 2f - 16f) +
                                    new Vector2(0f, timer % 1f < 0.25f ? 6 : 0);
                    SourceAtlasDrawing.DrawCentered(context, this,
                        ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                            "textboxbutton"], position2, PackedColor.White);
                }
            }
        }

        public override void Removed(object scene)
        {
            Dispose();
            base.Removed(scene);
        }

        public override void SceneEnd(object scene)
        {
            Dispose();
            base.SceneEnd(scene);
        }

        private void Dispose()
        {
            if (!(featherBuffer != null && !featherBuffer.IsDisposed))
                return;
            featherBuffer.Dispose();
            featherBuffer = null;
            smokeBuffer.Dispose();
            smokeBuffer = null;
            tempBuffer.Dispose();
            tempBuffer = null;
        }
    }
}

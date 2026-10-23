using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components.Animation;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Mountain.Rendering;
using Celeste.Game.Settings;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;

namespace Celeste.Game.Menus.Title
{
    public class TitleScreenSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;

        protected OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        protected OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        protected OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        protected ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        protected SettingsState Settings => ((ISettingsContext)engine).Settings;
        protected OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        public readonly MountainCameraState MountainTarget;

        private const float TextY = 1000f;

        private const float TextOutY = 1200f;

        private const int ReflectionSliceSize = 4;

        protected float alpha;

        protected float fade;

        protected string version;

        protected bool hideConfirmButton;

        protected SpriteImage logo;

        protected AtlasEntry title;

        protected List<AtlasEntry> reflections;

        protected float textY;

        public TitleScreenSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            MountainTarget = new(new(0f, 12f, 24f),
                MountainRendererState.RotateLookAt, ((ISourceVectorEnvironment)engine).VectorArithmetic);
            version = "v." + GameRuntime.Instance.Version;
            logo = new(Graphics.GuiAtlas["logo"]);
            logo.CenterOrigin();
            logo.Position = new Vector2(1920f, 1080f) / 2f;
            title = Graphics.GuiAtlas["title"];
            reflections = [];
            for (var num = title.FrameHeight - 4; num > 0; num -= 4)
                reflections.Add(title.GetSubtexture(0, num, title.FrameWidth, 4));

            if (((IOriginalGamePlayModeEnvironment)engine).PlayMode != GameRuntime.PlayModes.Normal)
            {
                if ("".Length > 0) version += "\n";

                version = version + "\n" + ((IOriginalGamePlayModeEnvironment)engine).PlayMode + " Build";
            }

            if (Settings.LaunchWithFMODLiveUpdate) version += "\nFMOD Live Update Enabled";
        }

        public override bool IsStart(OverworldSequence overworld, OverworldStartMode start)
        {
            if (start == OverworldStartMode.Titlescreen)
            {
                overworld.ShowInputUI = false;
                overworld.Mountain.SnapCamera(-1, MountainTarget);
                textY = 1000f;
                alpha = 1f;
                fade = 1f;
                return true;
            }

            textY = 1200f;
            return false;
        }

        public override IEnumerator Enter(OuiState from)
        {
            yield return null;
            Overworld.ShowInputUI = false;
            var camera = Overworld.Mountain.Camera;
            var rotateLookAt = MountainRendererState.RotateLookAt;
            var vector = ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(camera.Position -
                new Vector3(rotateLookAt.X, camera.Position.Y - 2f, rotateLookAt.Z));
            var transform = new MountainCameraState(MountainRendererState.RotateLookAt + vector * 20f,
                camera.Target, ((ISourceVectorEnvironment)engine).VectorArithmetic);
            Add(new SimulationCoroutine(engine, FadeBgTo(1f)));
            hideConfirmButton = false;
            Visible = true;
            Overworld.Mountain.EaseCamera(-1, transform, 2f, false);
            var start = textY;
            yield return 0.4f;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Easing.CubeInOut, 0.6f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                alpha = t.Percent;
                textY = ScalarMath.Lerp(start, 1000f, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            };
            Add(tween);
            yield return tween.Wait();
            Overworld.Mountain.SnapCamera(-1, MountainTarget);
        }

        public override IEnumerator Leave(OuiState next)
        {
            Overworld.ShowInputUI = true;
            Overworld.Mountain.GotoRotationMode();
            var start = textY;
            var tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                Easing.CubeInOut, 0.6f, true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                alpha = 1f - t.Percent;
                textY = ScalarMath.Lerp(start, 1200f, t.Eased, ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            };
            Add(tween);
            yield return tween.Wait();
            yield return FadeBgTo(0f);
            Visible = false;
        }

        private IEnumerator FadeBgTo(float to)
        {
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (fade != to)
            {
                yield return null;
                fade = ScalarMath.Approach(fade, to, engine.DeltaTime * 2f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }
        }

        public override void Update()
        {
            var gamepadIndex = -1;
            if (Selected && Input.AnyGamepadConfirmPressed(out gamepadIndex) && !hideConfirmButton)
            {
                Input.Gamepad = gamepadIndex;
                Audio.Play("event:/ui/main/title_firstinput");
                Overworld.Goto<MainMenuSequence>();
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade);
            if (!hideConfirmButton)
                SourceAtlasDrawing.DrawJustified(context, this, Input.GuiButton(Input.MenuConfirm),
                    new(1840f, textY), new(1f, 1f), PackedColor.White * alpha);

            Text.ActiveFont.Draw(context, this, version, new(80f, textY), new(0f, 1f),
                Vector2.One * 0.5f,
                PackedColor.DarkSlateBlue);
            if (alpha > 0f)
            {
                var num = ScalarMath.Lerp(0.5f, 1f, Easing.SineOut(alpha),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                logo.Color = PackedColor.White * alpha;
                logo.Scale = Vector2.One * num;
                logo.Render(context);
                var num2 = ((ISourceScene)Scene).SourceScene.Clock.TimeActive * 3f;
                var num3 = 1f / reflections.Count * ((float)Math.PI * 2f) * 2f;
                var num4 = title.FrameWidth / logo.Width * num;
                for (var i = 0; i < reflections.Count; i++)
                {
                    var num5 = i / (float)reflections.Count;
                    var x = (float)Math.Sin(num2) * 32f * num5;
                    var position = new Vector2(1920f, 1080f) / 2f +
                                   new Vector2(x, logo.Height * 0.5f + i * 4) * num4;
                    var num6 = Easing.CubeIn(1f - num5) * alpha * 0.9f;
                    SourceAtlasDrawing.DrawJustified(context, this, reflections[i], position, new(0.5f, 0.5f),
                        PackedColor.White * num6, new Vector2(1f, -1f) * num4);
                    num2 += num3 * ((float)Math.Sin(((ISourceScene)Scene).SourceScene.Clock.TimeActive +
                                                    i * ((float)Math.PI * 2f) * 0.04f) + 1f);
                }
            }
        }
    }
}

using Celeste.Core.Display;
using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Animation;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Scene.Entities;
using Celeste.Input.Gameplay;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.StarJump
{
    public class OriginalSelfieState : SceneEntityState
    {
        private OriginalLevelSceneRoot level;
        private readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        private SpriteImage image;

        private SpriteImage overImage;

        private bool waitForKeyPress;

        private float timer;

        private SourceTweenState tween;

        public OriginalSelfieState(OriginalLevelSceneRoot level)
            : base(((ISourceEntitySourceDataEnvironment)level.EngineContext).EntitySourceDataRegistration)
        {
            engine = level.EngineContext;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            this.level = level;
        }

        public IEnumerator PictureRoutine(string photo = "selfie")
        {
            level.Flash(PackedColor.White);
            yield return 0.5f;
            yield return OpenRoutine(photo);
            yield return WaitForInput();
            yield return EndRoutine();
        }

        public IEnumerator FilterRoutine()
        {
            yield return OpenRoutine();
            yield return 0.5f;
            AtlasEntry tex =
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).PortraitsAtlas[
                    "selfieFilter"];
            overImage = new SpriteImage(tex);
            overImage.Visible = false;
            overImage.CenterOrigin();
            int atWidth = 0;
            tween = SourceTweenState.Create(engine.TweenPool, SourceTweenState.TweenMode.Oneshot,
                ((ISourceEasingEnvironment)engine).EasingArithmetic.SineInOut, 0.4f, start: true);
            tween.OnUpdate = delegate(SourceTweenState t)
            {
                int num = (int)Math.Round(
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(0f, tex.FrameWidth, t.Eased));
                if (num != atWidth)
                {
                    atWidth = num;
                    overImage.Texture = tex.GetSubtexture(tex.FrameWidth - atWidth, 0, atWidth, tex.FrameHeight);
                    overImage.Visible = true;
                    overImage.Origin.X = atWidth - tex.FrameWidth / 2;
                }
            };
            Process.AudioSession.Play("event:/game/02_old_site/theoselfie_photo_filter");
            yield return tween.Wait();
            yield return WaitForInput();
            yield return EndRoutine();
        }

        public IEnumerator OpenRoutine(string selfie = "selfie")
        {
            Process.AudioSession.Play("event:/game/02_old_site/theoselfie_photo_in");
            image = new SpriteImage(
                ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .PortraitsAtlas[selfie]);
            image.CenterOrigin();
            float percent = 0f;
            while (percent < 1f)
            {
                percent += engine.DeltaTime;
                image.Position = Vector2Interpolation.Lerp(new Vector2(992f, 1080f + image.Height / 2f),
                    new Vector2(960f, 540f), ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(percent),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                image.Rotation = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(0.5f, 0f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.BackOut(percent));
                yield return null;
            }
        }

        public IEnumerator WaitForInput()
        {
            waitForKeyPress = true;
            while (!((ISourceGameInputEnvironment)engine).Input.MenuCancel.Pressed &&
                   !((ISourceGameInputEnvironment)engine).Input.MenuConfirm.Pressed)
            {
                yield return null;
            }

            Process.AudioSession.Play("event:/ui/main/button_lowkey");
            waitForKeyPress = false;
        }

        public IEnumerator EndRoutine()
        {
            Process.AudioSession.Play("event:/game/02_old_site/theoselfie_photo_out");
            float percent = 0f;
            while (percent < 1f)
            {
                percent += engine.DeltaTime * 2f;
                image.Position = Vector2Interpolation.Lerp(new Vector2(960f, 540f),
                    new Vector2(928f, (0f - image.Height) / 2f),
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.BackIn(percent),
                    ((ISourceScalarEnvironment)engine).ScalarArithmetic);
                image.Rotation = ((ISourceScalarEnvironment)engine).ScalarArithmetic.Lerp(0f, -0.15f,
                    ((ISourceEasingEnvironment)engine).EasingArithmetic.BackIn(percent));
                yield return null;
            }

            yield return null;
            level.Scheduler.RemoveEntity(this);
        }

        public override void Update()
        {
            if (tween != null && tween.Active)
            {
                tween.Update();
            }

            if (waitForKeyPress)
            {
                timer += engine.DeltaTime;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            if (base.Scene is OriginalLevelSceneRoot level &&
                (level.FrozenOrPaused || level.RetryPlayerCorpse != null || level.SkippingCutscene))
            {
                return;
            }

            if (image != null && image.Visible)
            {
                image.Render(context);
                if (overImage != null && overImage.Visible)
                {
                    overImage.Position = image.Position;
                    overImage.Rotation = image.Rotation;
                    overImage.Scale = image.Scale;
                    overImage.Render(context);
                }
            }

            if (waitForKeyPress)
            {
                SourceAtlasDrawing.DrawCentered(context, this,
                    ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                        "textboxbutton"],
                    image.Position + new Vector2(image.Width / 2f + 40f,
                        image.Height / 2f + (float)((timer % 1f < 0.25f) ? 6 : 0)), PackedColor.White);
            }
        }
    }
}

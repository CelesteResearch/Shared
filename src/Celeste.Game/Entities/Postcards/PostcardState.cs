using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Scene.Entities;

namespace Celeste.Game.Entities.Postcards
{
    public sealed class PostcardState : SceneEntityState,
        IDisposable
    {
        public AtlasEntry Postcard { get; set; }

        public RichTextLayout Text;
        public string SoundIn, SoundOut;
        private readonly ISourceEngineContext engine;

        private ISourceRenderContext renderContext =>
            ((ISourceRenderEnvironment)engine).CurrentContext;

        private VirtualContent virtualContent =>
            ((ISourceVirtualContentEnvironment)engine).VirtualContent;

        private IOriginalGameplayProcess Process =>
            (IOriginalGameplayProcess)engine;

        private OriginalGameTextProcess SourceText =>
            ((IOriginalGameTextEnvironment)engine).Text;

        private OriginalGameInputProcess SourceInput =>
            ((IOriginalGameInputProcessEnvironment)engine).InputSource;

        public float Alpha { get; private set; } = 1;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public float Scale { get; private set; } = 1;
        public float Rotation { get; private set; }
        public float ButtonEase { get; private set; }
        public VirtualRenderTarget Target { get; private set; }
        public SimulationCoroutine EaseButton { get; private set; }

        private ActiveBitmapFont CurrentFont =>
            ((ISourceActiveFontScope)engine).ActiveFont;

        private ISourceEasingArithmetic Easing =>
            ((ISourceEasingEnvironment)engine).EasingArithmetic;

        public PostcardState(ISourceEngineContext engine, string message, int area)
            : this(engine, message, "event:/ui/main/postcard_ch" + area + "_in",
                "event:/ui/main/postcard_ch" + area + "_out")
        {
        }

        public PostcardState(ISourceEngineContext engine, string message)
            : this(engine, message, "event:/ui/main/postcard_csides_in", "event:/ui/main/postcard_csides_out")
        {
        }

        public PostcardState(ISourceEngineContext engine, string message,
            string soundId)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            if (string.IsNullOrEmpty(soundId)) soundId = "csides";
            string path;
            if (soundId.StartsWith("event:/"))
            {
                path = soundId;
            }
            else if (soundId == "variants")
            {
                path = "event:/new_content/ui/postcard_variants";
            }
            else
            {
                path = "event:/ui/main/postcard_";
                if (int.TryParse(soundId, out _)) path += "ch";
                path += soundId;
            }

            this.engine = engine;
            Initialize(message, path + "_in", path + "_out");
        }

        public PostcardState(ISourceEngineContext engine,
            string message, string sfxIn, string sfxOut)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            Initialize(message, sfxIn, sfxOut);
        }

        private void Initialize(string message, string sfxIn, string sfxOut)
        {
            Visible = false;
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            SoundIn = sfxIn;
            SoundOut = sfxOut;
            Postcard =
                ((OriginalGameGraphicsResources)
                    ((ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .GuiAtlas["postcard"];
            Text = OriginalFancyTextParser.Parse(message,
                (int)((Postcard.Width - 120) / .7f), -1, 1,
                PackedColor.Black * .6f,
                OriginalFancyTextContext.Create(
                    (IOriginalFancyTextProcess)engine));
        }

        public override void Removed(object actualScene)
        {
            Dispose();
            base.Removed(actualScene);
        }

        public override void SceneEnd(object actualScene)
        {
            Dispose();
            base.SceneEnd(actualScene);
        }

        public void Dispose()
        {
            Target?.Dispose();
            Target = null;
        }

        public SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var component = new SimulationCoroutine(engine, routine);
            OwnedComponents.Add(component);
            return component;
        }

        public IEnumerator DisplayRoutine()
        {
            yield return EaseIn();
            yield return .75f;
            while (!SourceInput.MenuConfirm.Pressed) yield return null;
            Process.AudioSession.Play("event:/ui/main/button_lowkey");
            yield return EaseOut();
            yield return 1.2f;
        }

        public IEnumerator EaseIn()
        {
            Process.AudioSession.Play(SoundIn);
            var center = new Vector2(renderContext.Graphics.Width, renderContext.Graphics.Height) / 2;
            var from = center + new Vector2(0, 200);
            var to = center;
            float rotationFrom = -.1f, rotationTo = .05f;
            Visible = true;
            for (float p = 0; p < 1; p += engine.Frame.DeltaTime * .8f)
            {
                Position = from + (to - from) * Easing.CubeOut(p);
                Alpha = Easing.CubeOut(p);
                Rotation = rotationFrom + (rotationTo - rotationFrom) * Easing.CubeOut(p);
                yield return null;
            }

            EaseButton = AddCoroutine(EaseButtinIn());
        }

        private IEnumerator EaseButtinIn()
        {
            yield return .75f;
            while ((ButtonEase += engine.Frame.DeltaTime * 2) < 1) yield return null;
        }

        public IEnumerator EaseOut()
        {
            Process.AudioSession.Play(SoundOut);
            EaseButton?.RemoveSelf();
            var from = Position;
            var to = new Vector2(renderContext.Graphics.Width, renderContext.Graphics.Height) / 2 +
                     new Vector2(0, -200);
            float rotationFrom = Rotation, rotationTo = Rotation + .1f;
            for (float p = 0; p < 1; p += engine.Frame.DeltaTime)
            {
                Position = from + (to - from) * Easing.CubeIn(p);
                Alpha = 1 - Easing.CubeIn(p);
                Rotation = rotationFrom + (rotationTo - rotationFrom) * Easing.CubeIn(p);
                ButtonEase = ScalarMath.Approach(ButtonEase, 0,
                    engine.Frame.DeltaTime * 8,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            Alpha = 0;
            RemoveSelf();
        }

        public void BeforeRender()
        {
            if (Target == null)
                Target = virtualContent.CreateRenderTarget("postcard", Postcard.Width, Postcard.Height);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .SetRenderTarget(Target.Target);
            ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .Clear(PackedColor.Transparent);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            var name = SourceText.CleanDialog("FILE_DEFAULT");
            if (Process.SaveContext.CurrentSave != null && SourceText.Dialog.Language.CanDisplay(
                    Process.SaveContext.CurrentSave.Name,
                    c => CurrentFont.Font.Get(CurrentFont.BaseSize).Characters.ContainsKey(c)))
                name = Process.SaveContext.CurrentSave.Name;
            var postcard = new AtlasTextureDraw(Postcard, Vector2.Zero,
                Vector2.Zero, PackedColor.White, Vector2.One);
            var atlasSink =
                (ISourceRenderCommandSink<
                    AtlasTextureDraw>)renderContext;
            atlasSink.Draw(in postcard, this);
            CurrentFont.Draw(renderContext, this, name, new(115, 30), Vector2.Zero,
                Vector2.One * .9f, PackedColor.Black * .7f);
            Text.DrawJustifyPerLine(renderContext, this,
                (ISourceRichTextDrawProcess)engine,
                new Vector2(Postcard.Width, Postcard.Height) / 2 + new Vector2(0, 40),
                new(.5f), Vector2.One * .7f, 1);
            ((ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (Target != null)
            {
                var target = new RenderTargetTextureDraw(Target.Target,
                    Position, Target.Bounds, new Vector2(Target.Width, Target.Height) / 2,
                    PackedColor.White * Alpha, new(Scale), Rotation);
                ((ISourceRenderCommandSink<
                        RenderTargetTextureDraw>)context)
                    .Draw(in target, this);
            }

            if (ButtonEase > 0)
            {
                var texture = SourceInput.GuiButton(SourceInput.MenuConfirm);
                var button = new AtlasTextureDraw(texture,
                    new(context.Graphics.Width - 120,
                        context.Graphics.Height - 100 - 20 * Easing.CubeOut(ButtonEase)),
                    new Vector2(texture.FrameWidth, texture.FrameHeight) / 2,
                    PackedColor.White * Easing.CubeOut(ButtonEase), Vector2.One);
                ((ISourceRenderCommandSink<
                        AtlasTextureDraw>)context)
                    .Draw(in button, this);
            }
        }
    }
}

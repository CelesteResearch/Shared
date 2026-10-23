using Celeste.Core.Display;
using Celeste.Scene.Scheduling;
using Celeste.Simulation.UI.Presentation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace Celeste.Game.Entities.Postcards
{
    public sealed class PostcardState : global::Celeste.Scene.Entities.SceneEntityState,
        IDisposable
    {
        private global::Celeste.Graphics.Content.Atlas.AtlasEntry postcard;

        public global::Celeste.Graphics.Content.Atlas.AtlasEntry Postcard
        {
            get => postcard;
            set => postcard = value;
        }

        public global::Celeste.Graphics.Text.RichText.Layout.RichTextLayout Text;
        public string SoundIn, SoundOut;
        private readonly global::Celeste.Core.Scheduling.ISourceEngineContext engine;

        private global::Celeste.Core.Rendering.ISourceRenderContext renderContext =>
            ((global::Celeste.Core.Rendering.ISourceRenderEnvironment)engine).CurrentContext;

        private global::Celeste.Graphics.Content.VirtualAssets.VirtualContent virtualContent =>
            ((global::Celeste.Graphics.Content.VirtualAssets.ISourceVirtualContentEnvironment)engine).VirtualContent;

        private global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess Process =>
            (global::Celeste.Game.Execution.Processes.IOriginalGameplayProcess)engine;

        private global::Celeste.Game.Content.Dialogs.OriginalGameTextProcess SourceText =>
            ((global::Celeste.Game.Content.Dialogs.IOriginalGameTextEnvironment)engine).Text;

        private global::Celeste.Game.Controls.Source.OriginalGameInputProcess SourceInput =>
            ((global::Celeste.Game.Controls.Source.IOriginalGameInputProcessEnvironment)engine).InputSource;

        public float Alpha { get; private set; } = 1;
        public float Scale { get; private set; } = 1;
        public float Rotation { get; private set; }
        public float ButtonEase { get; private set; }
        public global::Celeste.Graphics.Content.VirtualAssets.VirtualRenderTarget Target { get; private set; }
        public global::Celeste.Core.Scheduling.SimulationCoroutine EaseButton { get; private set; }

        private global::Celeste.Graphics.Text.ActiveBitmapFont CurrentFont =>
            ((global::Celeste.Graphics.Text.ISourceActiveFontScope)engine).ActiveFont;

        private global::Celeste.Core.Mathematics.Easing.ISourceEasingArithmetic Easing =>
            ((global::Celeste.Core.Mathematics.Easing.ISourceEasingEnvironment)engine).EasingArithmetic;

        public PostcardState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, string message, int area)
            : this(engine, message, "event:/ui/main/postcard_ch" + area + "_in",
                "event:/ui/main/postcard_ch" + area + "_out")
        {
        }

        public PostcardState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, string message)
            : this(engine, message, "event:/ui/main/postcard_csides_in", "event:/ui/main/postcard_csides_out")
        {
        }

        public PostcardState(global::Celeste.Core.Scheduling.ISourceEngineContext engine, string message,
            string soundId)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            if (string.IsNullOrEmpty(soundId)) soundId = "csides";
            string path;
            if (soundId.StartsWith("event:/")) path = soundId;
            else if (soundId == "variants") path = "event:/new_content/ui/postcard_variants";
            else
            {
                path = "event:/ui/main/postcard_";
                if (int.TryParse(soundId, out _)) path += "ch";
                path += soundId;
            }

            this.engine = engine;
            Initialize(message, path + "_in", path + "_out");
        }

        public PostcardState(global::Celeste.Core.Scheduling.ISourceEngineContext engine,
            string message, string sfxIn, string sfxOut)
            : base(((global::Celeste.Core.Components.ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            Initialize(message, sfxIn, sfxOut);
        }

        private void Initialize(string message, string sfxIn, string sfxOut)
        {
            Visible = false;
            Tags = ((global::Celeste.Game.Execution.Startup.IOriginalGameTagsEnvironment)engine).Tags.HUD.Value;
            SoundIn = sfxIn;
            SoundOut = sfxOut;
            Postcard =
                ((global::Celeste.Game.Execution.Graphics.OriginalGameGraphicsResources)
                    ((global::Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine).GameGraphics)
                .GuiAtlas["postcard"];
            Text = global::Celeste.Game.Content.Dialogs.OriginalFancyTextParser.Parse(message,
                (int)((Postcard.Width - 120) / .7f), -1, 1,
                global::Celeste.Core.Display.PackedColor.Black * .6f,
                global::Celeste.Game.Content.Dialogs.OriginalFancyTextContext.Create(
                    (global::Celeste.Game.Content.Dialogs.IOriginalFancyTextProcess)engine));
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

        public global::Celeste.Core.Scheduling.SimulationCoroutine AddCoroutine(IEnumerator routine)
        {
            var component = new global::Celeste.Core.Scheduling.SimulationCoroutine(engine, routine);
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
                ButtonEase = global::Celeste.Core.Mathematics.ScalarMath.Approach(ButtonEase, 0,
                    engine.Frame.DeltaTime * 8,
                    ((global::Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
                yield return null;
            }

            Alpha = 0;
            RemoveSelf();
        }

        public void BeforeRender()
        {
            if (Target == null)
                Target = virtualContent.CreateRenderTarget("postcard", Postcard.Width, Postcard.Height);
            ((global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .SetRenderTarget(Target.Target);
            ((global::Celeste.Graphics.Rendering.Devices.ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice
                .Clear(global::Celeste.Core.Display.PackedColor.Transparent);
            ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)engine).Draw.SpriteBatch.Begin();
            string name = SourceText.CleanDialog("FILE_DEFAULT");
            if (Process.SaveContext.CurrentSave != null && SourceText.Dialog.Language.CanDisplay(
                    Process.SaveContext.CurrentSave.Name,
                    c => CurrentFont.Font.Get(CurrentFont.BaseSize).Characters.ContainsKey(c)))
                name = Process.SaveContext.CurrentSave.Name;
            var postcard = new global::Celeste.Graphics.Display.AtlasTextureDraw(Postcard, Vector2.Zero,
                Vector2.Zero, global::Celeste.Core.Display.PackedColor.White, Vector2.One);
            var atlasSink =
                (global::Celeste.Core.Rendering.ISourceRenderCommandSink<
                    global::Celeste.Graphics.Display.AtlasTextureDraw>)renderContext;
            atlasSink.Draw(in postcard, this);
            CurrentFont.Draw(renderContext, this, name, new Vector2(115, 30), Vector2.Zero,
                Vector2.One * .9f, global::Celeste.Core.Display.PackedColor.Black * .7f);
            Text.DrawJustifyPerLine(renderContext, this,
                (global::Celeste.Graphics.Text.RichText.Drawing.ISourceRichTextDrawProcess)engine,
                new Vector2(Postcard.Width, Postcard.Height) / 2 + new Vector2(0, 40),
                new Vector2(.5f), Vector2.One * .7f, 1);
            ((global::Celeste.Graphics.Rendering.Drawing.ISourceDrawScope)engine).Draw.SpriteBatch.End();
        }

        public override void Render(global::Celeste.Core.Rendering.ISourceRenderContext context)
        {
            if (Target != null)
            {
                var target = new global::Celeste.Graphics.Display.RenderTargetTextureDraw(Target.Target,
                    Position, Target.Bounds, new Vector2(Target.Width, Target.Height) / 2,
                    global::Celeste.Core.Display.PackedColor.White * Alpha, new Vector2(Scale), Rotation);
                ((global::Celeste.Core.Rendering.ISourceRenderCommandSink<
                        global::Celeste.Graphics.Display.RenderTargetTextureDraw>)context)
                    .Draw(in target, this);
            }

            if (ButtonEase > 0)
            {
                var texture = SourceInput.GuiButton(SourceInput.MenuConfirm);
                var button = new global::Celeste.Graphics.Display.AtlasTextureDraw(texture,
                    new Vector2(context.Graphics.Width - 120,
                        context.Graphics.Height - 100 - 20 * Easing.CubeOut(ButtonEase)),
                    new Vector2(texture.FrameWidth, texture.FrameHeight) / 2,
                    global::Celeste.Core.Display.PackedColor.White * Easing.CubeOut(ButtonEase), Vector2.One);
                ((global::Celeste.Core.Rendering.ISourceRenderCommandSink<
                        global::Celeste.Graphics.Display.AtlasTextureDraw>)context)
                    .Draw(in button, this);
            }
        }
    }
}

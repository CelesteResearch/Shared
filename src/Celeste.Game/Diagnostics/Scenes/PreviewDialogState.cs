using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Settings;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Rendering;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Gameplay;
using Celeste.Input.Runtime;
using Celeste.Localization.Languages;
using Celeste.Scene.Scenes;
using Celeste.Scene.Scheduling;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Dialogs.Nodes;
using Celeste.Simulation.Presentation.Rendering;

namespace Celeste.Game.Diagnostics.Scenes
{
    public class PreviewDialogState : SourceSceneState
    {
        private class Renderer : HiresRendererState
        {
            public readonly PreviewDialogState previewer;

            public Renderer(PreviewDialogState previewer) : base(1920, 1080)
            {
                this.previewer = previewer;
            }

            public override void RenderContent(object scene, ISourceRenderContext context)
            {
                BeginRender(context);
                previewer.RenderContent();
                EndRender(context);
            }
        }

        private DialogLanguage language;

        private readonly List<string> list = [];

        private Vector2 listScroll = new(64f, 64f);

        private const float scale = 0.6f;

        private string current;

        private readonly List<object> elements = [];

        private Vector2 textboxScroll = new(0f, 0f);

        private float delay;

        public Vector2 Mouse => SourceVector2Math.Transform(
            new(((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CurrentState.X,
                ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.CurrentState.Y),
            SourceMatrixMath.Invert(((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.ScreenMatrix));

        public PreviewDialogState(ISourceEngineContext engine, DialogLanguage language = null, float listScroll = 64f,
            float textboxScroll = 0f, string dialog = null)
            : base(engine, ((ISourceSceneCatalogEnvironment)engine).SceneCatalog,
                ((ISourceSceneUpdatePolicyEnvironment)engine).PlainScenePolicy)
        {
            this.listScroll.Y = listScroll;
            this.textboxScroll.Y = textboxScroll;
            if (language != null) SetLanguage(language);

            if (dialog != null) SetCurrent(dialog);

            Renderers.Add(new Renderer(this));
        }

        public override void End()
        {
            base.End();
            UnsetLanguage();
        }

        public override void Update()
        {
            if (!EngineRuntime.Instance.IsActive)
            {
                delay = 0.1f;
                return;
            }

            if (delay > 0f)
            {
                delay -= EngineContext.Frame.DeltaTime;
                return;
            }

            if (current != null)
            {
                var num = 1f;
                foreach (var element in elements)
                    if (element is TextboxState textbox)
                    {
                        textbox.RenderOffset = textboxScroll + Vector2.UnitY * num;
                        num += 300f;
                        if (textbox.Scene != null) textbox.Update();
                    }
                    else
                    {
                        num += ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace)
                            .Get(language.FontFaceSize).LineHeight + 50;
                    }

                textboxScroll.Y += ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.WheelDelta *
                                   EngineContext.Frame.DeltaTime * ((IOriginalGameTextEnvironment)EngineContext).Text
                                   .ActiveFont.LineHeight;
                textboxScroll.Y -= ((IGameInputEnvironment)EngineContext).Input.Aim.Value.Y *
                                   EngineContext.Frame.DeltaTime *
                                   ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight * 20f;
                textboxScroll.Y = ScalarMath.Clamp(textboxScroll.Y, 716f - num, 64f,
                    ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
                if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Escape) ||
                    ((IGameInputEnvironment)EngineContext).Input[GameAction.MenuConfirm].Pressed)
                {
                    ClearTextboxes();
                }
                else if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Space))
                {
                    var item = current;
                    ClearTextboxes();
                    var num2 = list.IndexOf(item) + 1;
                    if (num2 < list.Count) SetCurrent(list[num2]);
                }
            }
            else
            {
                listScroll.Y += ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.WheelDelta *
                                EngineContext.Frame.DeltaTime * ((IOriginalGameTextEnvironment)EngineContext).Text
                                .ActiveFont.LineHeight;
                listScroll.Y -= ((IGameInputEnvironment)EngineContext).Input.Aim.Value.Y *
                                EngineContext.Frame.DeltaTime *
                                ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight * 20f;
                listScroll.Y = ScalarMath.Clamp(listScroll.Y,
                    1016f - list.Count *
                    ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight *
                    0.6f, 64f, ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic);
                if (language != null)
                {
                    if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedLeftButton)
                        for (var i = 0; i < list.Count; i++)
                            if (MouseOverOption(i))
                            {
                                SetCurrent(list[i]);
                                break;
                            }

                    if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.Escape) ||
                        ((IGameInputEnvironment)EngineContext).Input[GameAction.MenuConfirm].Pressed)
                    {
                        listScroll = new(64f, 64f);
                        UnsetLanguage();
                    }
                }
                else if (((ISourceMInputEnvironment)EngineContext).MInput.Mouse.PressedLeftButton)
                {
                    var num3 = 0;
                    foreach (var language in
                             ((IOriginalGameTextEnvironment)EngineContext)
                             .Text.Dialog.Languages)
                    {
                        if (MouseOverOption(num3))
                        {
                            SetLanguage(language.Value);
                            listScroll = new(64f, 64f);
                            break;
                        }

                        num3++;
                    }
                }
            }

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F2))
            {
                GameRuntime.ReloadPortraits();
                EngineContext.Frame.Scenes.NextScene = new PreviewDialogState(EngineContext, language,
                    listScroll.Y,
                    textboxScroll.Y, current);
            }

            if (((ISourceMInputEnvironment)EngineContext).MInput.Keyboard.Pressed(SourceKeys.F1) &&
                this.language != null)
            {
                GameRuntime.ReloadDialog();
                EngineContext.Frame.Scenes.NextScene = new PreviewDialogState(EngineContext,
                    ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Languages[language.Id], listScroll.Y,
                    textboxScroll.Y, current);
            }
        }

        private void ClearTextboxes()
        {
            foreach (var element in elements)
                if (element is TextboxState)
                    SourceScene.RemoveEntity(element as TextboxState);

            current = null;
            textboxScroll = Vector2.Zero;
        }

        private void SetCurrent(string id)
        {
            current = id;
            elements.Clear();
            TextboxState textbox = null;
            var num = 0;
            while (true)
            {
                var textbox2 = new TextboxState(id, EngineContext, language);
                if (!textbox2.SkipToPage(num)) break;

                if (textbox != null)
                    for (var i = textbox.Start + 1; i <= textbox2.Start && i < textbox.Nodes.Count; i++)
                        if (textbox.Nodes[i] is DialogTrigger trigger)
                            elements.Add((trigger.Silent ? "Silent " : "") + "Trigger [" + trigger.Index + "] " +
                                         trigger.Label);

                SourceScene.QueueSourceEntity(textbox2);
                elements.Add(textbox2);
                textbox2.RenderOffset = textboxScroll + Vector2.UnitY * (1 + num * 300);
                textbox = textbox2;
                num++;
            }
        }

        private void SetLanguage(DialogLanguage lan)
        {
            ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Load(lan.FontFace);
            language = lan;
            list.Clear();
            var flag = false;
            foreach (var item in language.Dialog)
            {
                if (!flag && item.Key.StartsWith("CH0", StringComparison.OrdinalIgnoreCase)) flag = true;

                if (flag && !item.Key.StartsWith("poem_", StringComparison.OrdinalIgnoreCase) &&
                    !item.Key.StartsWith("journal_", StringComparison.OrdinalIgnoreCase))
                    list.Add(item.Key);
            }
        }

        private void UnsetLanguage()
        {
            if (language != null && language.Id != ((ISettingsContext)EngineContext).Settings.LanguageId &&
                language.FontFace !=
                ((IOriginalGameTextEnvironment)EngineContext).Text.Dialog.Languages["english"].FontFace)
                ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Unload(language.FontFace);

            language = null;
        }

        private void RenderContent()
        {
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, 0f, 0f, 960f, 1080f,
                PackedColor.DarkSlateGray * 0.25f);
            if (current != null)
            {
                var num = 1;
                var num2 = 0;
                foreach (var element in elements)
                    if (element is TextboxState textbox)
                    {
                        if (textbox.Opened && ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts
                            .Get(language.FontFace).Sizes.Count > 0)
                        {
                            textbox.Render(SourceRenderContext);
                            ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace).DrawOutline(
                                SourceRenderContext, this, language.FontFaceSize, "#" + num,
                                textbox.RenderOffset + new Vector2(32f, 64f), Vector2.Zero, Vector2.One * 0.5f,
                                PackedColor.White, 2f, PackedColor.Black);
                            num++;
                            num2 += 300;
                        }
                    }
                    else
                    {
                        ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace).DrawOutline(
                            SourceRenderContext, this, language.FontFaceSize, element.ToString(),
                            textboxScroll + new Vector2(128f,
                                num2 + 50 + ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts
                                .Get(language.FontFace)
                                .Get(language.FontFaceSize).LineHeight), new(0f, 0.5f), Vector2.One * 0.5f,
                            PackedColor.White, 2f, PackedColor.Black);
                        num2 += ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace)
                            .Get(language.FontFaceSize).LineHeight + 50;
                    }

                ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.DrawOutline(SourceRenderContext, this,
                    current, new(1888f, 32f), new(1f, 0f), Vector2.One * 0.5f, PackedColor.Red, 2f,
                    PackedColor.Black);
            }
            else if (language != null)
            {
                var num3 = 0;
                foreach (var item in list)
                {
                    if (((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace).Sizes.Count > 0)
                        ((IOriginalGameTextEnvironment)EngineContext).Text.Fonts.Get(language.FontFace).Draw(
                            SourceRenderContext, this, language.FontFaceSize, item,
                            listScroll + new Vector2(0f,
                                num3 * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight *
                                0.6f), Vector2.Zero, Vector2.One * 0.6f,
                            MouseOverOption(num3) ? PackedColor.White : PackedColor.Gray);

                    num3++;
                }
            }
            else
            {
                var num4 = 0;
                foreach (var language in ((IOriginalGameTextEnvironment)EngineContext)
                         .Text
                         .Dialog.Languages)
                {
                    ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.Draw(SourceRenderContext, this,
                        language.Value.Id,
                        listScroll + new Vector2(0f,
                            num4 * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight *
                            0.6f),
                        Vector2.Zero, Vector2.One * 0.6f, MouseOverOption(num4) ? PackedColor.White : PackedColor.Gray);
                    num4++;
                }
            }

            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, Mouse.X - 12f, Mouse.Y - 4f, 24f, 8f,
                PackedColor.Red);
            SourcePrimitiveDrawing.Rect(SourceRenderContext, this, Mouse.X - 4f, Mouse.Y - 12f, 8f, 24f,
                PackedColor.Red);
        }

        private bool MouseOverOption(int i)
        {
            if (Mouse.X > listScroll.X &&
                Mouse.Y > listScroll.Y +
                i * ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight * 0.6f &&
                ((ISourceMInputEnvironment)EngineContext).MInput.Mouse.X < 960f)
                return Mouse.Y < listScroll.Y + (i + 1) *
                    ((IOriginalGameTextEnvironment)EngineContext).Text.ActiveFont.LineHeight * 0.6f;

            return false;
        }
    }
}

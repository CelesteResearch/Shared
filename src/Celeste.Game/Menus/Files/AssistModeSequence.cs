using Celeste.Core.Display;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Audio.Fmod.Events;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Audio.Fmod;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Settings;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Drawing;

namespace Celeste.Game.Menus.Files
{
    public class AssistModeSequence : OuiState
    {
        protected readonly ISourceEngineContext engine;
        private IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;
        private OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;
        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private ActiveBitmapFont ActiveFont => ((ISourceActiveFontScope)engine).ActiveFont;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((Celeste.Graphics.Content.ISourceGameGraphicsEnvironment)engine)
            .GameGraphics;

        private class Page
        {
            public RichTextLayout Text;

            public float Ease;

            public float Direction;
        }

        public ISourceFileSelectSlot FileSlot;

        protected float fade;

        private List<Page> pages = new List<Page>();

        private int pageIndex;

        private int questionIndex = 1;

        private float questionEase;

        private WigglerComponent wiggler;

        private float dot;

        private RichTextLayout questionText;

        private PackedColor iconColor = SourceHexColor.HexToColor("44adf7");

        private float leftArrowEase;

        private float rightArrowEase;

        private FmodEventReference mainSfx;

        private const float textScale = 0.8f;

        public AssistModeSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            Visible = false;
            OwnedComponents.Add(wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.4f, 4f));
        }

        public override IEnumerator Enter(OuiState from)
        {
            Focused = false;
            Visible = true;
            pageIndex = 0;
            questionIndex = 1;
            questionEase = 0f;
            dot = 0f;
            questionText = OriginalFancyTextParser.Parse(Text.Dialog.Get("ASSIST_ASK"), 1600, -1, 1f, PackedColor.White,
                OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
            if (!FileSlot.AssistModeEnabled)
            {
                for (int i = 0; Text.Dialog.Has("ASSIST_MODE_" + i); i++)
                {
                    Page page = new Page();
                    page.Text = OriginalFancyTextParser.Parse(Text.Dialog.Get("ASSIST_MODE_" + i), 2000, -1, 1f,
                        PackedColor.White * 0.9f, OriginalFancyTextContext.Create((IOriginalFancyTextProcess)engine));
                    page.Ease = 0f;
                    pages.Add(page);
                }

                pages[0].Ease = 1f;
                mainSfx = Process.AudioSession.Play("event:/ui/main/assist_info_whistle");
            }
            else
            {
                questionEase = 1f;
            }

            while (fade < 1f)
            {
                fade += engine.DeltaTime * 4f;
                yield return null;
            }

            Focused = true;
            OwnedComponents.Add(new SimulationCoroutine(engine, InputRoutine()));
        }

        public override IEnumerator Leave(OuiState next)
        {
            Focused = false;
            while (fade > 0f)
            {
                fade -= engine.DeltaTime * 4f;
                yield return null;
            }

            if (mainSfx != null)
            {
                mainSfx.Release();
            }

            pages.Clear();
            Visible = false;
        }

        private IEnumerator InputRoutine()
        {
            while (true)
            {
                if (Input.MenuCancel.Pressed)
                {
                    Focused = false;
                    base.Overworld.Goto<FileSelectSequence>();
                    Process.AudioSession.Play("event:/ui/main/button_back");
                    Process.AudioSession.SetParameter(mainSfx, "assist_progress", 6f);
                    yield break;
                }

                int was = pageIndex;
                if ((Input.MenuConfirm.Pressed || Input.MenuRight.Pressed) && pageIndex < pages.Count)
                {
                    pageIndex++;
                    Process.AudioSession.Play("event:/ui/main/rollover_down");
                    Process.AudioSession.SetParameter(mainSfx, "assist_progress", pageIndex);
                }
                else if (Input.MenuLeft.Pressed && pageIndex > 0)
                {
                    Process.AudioSession.Play("event:/ui/main/rollover_up");
                    pageIndex--;
                }

                if (was != pageIndex)
                {
                    if (was < pages.Count)
                    {
                        pages[was].Direction = Math.Sign(was - pageIndex);
                        while ((pages[was].Ease = ScalarMath.Approach(pages[was].Ease, 0f, engine.DeltaTime * 8f,
                                   ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != 0f)
                        {
                            yield return null;
                        }
                    }
                    else
                    {
                        while ((questionEase = ScalarMath.Approach(questionEase, 0f, engine.DeltaTime * 8f,
                                   ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != 0f)
                        {
                            yield return null;
                        }
                    }

                    if (pageIndex < pages.Count)
                    {
                        pages[pageIndex].Direction = Math.Sign(pageIndex - was);
                        while ((pages[pageIndex].Ease = ScalarMath.Approach(pages[pageIndex].Ease, 1f,
                                   engine.DeltaTime * 8f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != 1f)
                        {
                            yield return null;
                        }
                    }
                    else
                    {
                        while ((questionEase = ScalarMath.Approach(questionEase, 1f, engine.DeltaTime * 8f,
                                   ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) != 1f)
                        {
                            yield return null;
                        }
                    }
                }

                if (pageIndex >= pages.Count)
                {
                    if (Input.MenuConfirm.Pressed)
                    {
                        break;
                    }

                    if (Input.MenuUp.Pressed && questionIndex > 0)
                    {
                        Process.AudioSession.Play("event:/ui/main/rollover_up");
                        questionIndex--;
                        wiggler.Start();
                    }
                    else if (Input.MenuDown.Pressed && questionIndex < 1)
                    {
                        Process.AudioSession.Play("event:/ui/main/rollover_down");
                        questionIndex++;
                        wiggler.Start();
                    }
                }

                yield return null;
            }

            FileSlot.AssistModeEnabled = questionIndex == 0;
            if (FileSlot.AssistModeEnabled)
            {
                FileSlot.VariantModeEnabled = false;
            }

            FileSlot.CreateButtons();
            Focused = false;
            base.Overworld.Goto<FileSelectSequence>();
            Process.AudioSession.Play((questionIndex == 0)
                ? "event:/ui/main/assist_button_yes"
                : "event:/ui/main/assist_button_no");
            Process.AudioSession.SetParameter(mainSfx, "assist_progress", (questionIndex == 0) ? 4 : 5);
        }

        public override void Update()
        {
            dot = ScalarMath.Approach(dot, pageIndex, engine.DeltaTime * 8f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            leftArrowEase = ScalarMath.Approach(leftArrowEase, (pageIndex > 0) ? 1 : 0, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            rightArrowEase = ScalarMath.Approach(rightArrowEase, (pageIndex < pages.Count) ? 1 : 0,
                engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (!Visible)
            {
                return;
            }

            SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade * 0.9f);
            for (int i = 0; i < pages.Count; i++)
            {
                Page page = pages[i];
                float num = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(page.Ease);
                if (num > 0f)
                {
                    Vector2 position = new Vector2(960f, 620f);
                    position.X += page.Direction * (1f - num) * 256f;
                    page.Text.DrawJustifyPerLine(context, this, (ISourceRichTextDrawProcess)engine, position,
                        new Vector2(0.5f, 0f), Vector2.One * 0.8f, num * fade);
                }
            }

            if (questionEase > 0f)
            {
                float num2 = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(questionEase);
                float num3 = wiggler.Value * 8f;
                Vector2 vector = new Vector2(960f + (1f - num2) * 256f, 620f);
                float lineHeight = ActiveFont.LineHeight;
                questionText.DrawJustifyPerLine(context, this, (ISourceRichTextDrawProcess)engine, vector,
                    new Vector2(0.5f, 0f), Vector2.One, num2 * fade);
                ActiveFont.DrawOutline(context, this, Text.Dialog.Clean("ASSIST_YES"),
                    vector + new Vector2(((questionIndex == 0) ? num3 : 0f) * 1.2f * num2, lineHeight * 1.4f + 10f),
                    new Vector2(0.5f, 0f), Vector2.One * 0.8f, SelectionColor(questionIndex == 0), 2f,
                    PackedColor.Black * num2 * fade);
                ActiveFont.DrawOutline(context, this, Text.Dialog.Clean("ASSIST_NO"),
                    vector + new Vector2(((questionIndex == 1) ? num3 : 0f) * 1.2f * num2, lineHeight * 2.2f + 20f),
                    new Vector2(0.5f, 0f), Vector2.One * 0.8f, SelectionColor(questionIndex == 1), 2f,
                    PackedColor.Black * num2 * fade);
            }

            if (pages.Count > 0)
            {
                int num4 = pages.Count + 1;
                AtlasEntry mTexture = Graphics.GuiAtlas["dot"];
                int num5 = mTexture.Width * num4;
                Vector2 vector2 = new Vector2(960f,
                    960f - 40f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(fade));
                for (int j = 0; j < num4; j++)
                {
                    SourceAtlasDrawing.DrawCentered(context, this, mTexture,
                        vector2 + new Vector2((float)(-num5 / 2) + (float)mTexture.Width * ((float)j + 0.5f), 0f),
                        PackedColor.White * 0.25f);
                }

                float x = 1f + ScalarMath.YoYo(dot % 1f) * 4f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture,
                    vector2 + new Vector2((float)(-num5 / 2) + (float)mTexture.Width * (dot + 0.5f), 0f), iconColor,
                    new Vector2(x, 1f));
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["dotarrow"],
                    vector2 + new Vector2(-num5 / 2 - 50,
                        32f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(leftArrowEase))),
                    iconColor * leftArrowEase, new Vector2(-1f, 1f));
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["dotarrow"],
                    vector2 + new Vector2(num5 / 2 + 50,
                        32f * (1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(rightArrowEase))),
                    iconColor * rightArrowEase);
            }

            SourceAtlasDrawing.DrawJustified(context, this, Graphics.GuiAtlas["assistmode"],
                new Vector2(960f, 540f + 64f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(fade)),
                new Vector2(0.5f, 1f), iconColor * fade);
        }

        protected virtual PackedColor SelectionColor(bool selected)
        {
            if (selected)
            {
                return ((((ISettingsContext)engine).Settings.DisableFlashes ||
                         ((ISourceScene)Scene).SourceScene.Clock.BetweenInterval(0.1f))
                    ? TextMenuPresentation.HighlightColorA
                    : TextMenuPresentation.HighlightColorB) * fade;
            }

            return PackedColor.White * fade;
        }
    }
}

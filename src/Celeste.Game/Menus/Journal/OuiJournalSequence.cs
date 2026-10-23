using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Chapters;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Platform.Statistics;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;

namespace Celeste.Game.Menus.Journal
{
    public class OuiJournalSequence : OuiState
    {
        protected internal readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        internal OriginalGameTextProcess Text => ((IOriginalGameTextEnvironment)engine).Text;

        internal OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)engine).MountainResources;

        internal ISourceRenderContext Context => ((ISourceRenderEnvironment)engine).CurrentContext;
        internal ISourceEasingArithmetic Easing => ((ISourceEasingEnvironment)engine).EasingArithmetic;
        internal OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        internal IOriginalGameplayProcess Process => (IOriginalGameplayProcess)engine;

        internal OriginalPlatformStatisticsProcess Statistics =>
            ((IOriginalPlatformStatisticsEnvironment)engine).Statistics;

        public OuiJournalSequence(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            backColor = SourceColorInterpolation.Lerp(PackedColor.White, PackedColor.Black, 0.2f,
                ((ISourceScalarEnvironment)engine).ScalarArithmetic);
            arrow = MountainResources.Journal["pageArrow"];
        }

        private const float onScreenX = 0f;

        private const float offScreenX = -1920f;

        public bool PageTurningLocked;

        public List<OuiJournalPage> Pages = [];

        public int PageIndex;

        public VirtualRenderTarget CurrentPageBuffer;

        public VirtualRenderTarget NextPageBuffer;

        private bool turningPage;

        private float turningScale;

        private readonly PackedColor backColor;

        private bool fromAreaInspect;

        private float rotation;

        private MountainCameraState cameraStart;

        private MountainCameraState cameraEnd;

        private AtlasEntry arrow;

        private float dot;

        private float dotTarget;

        private float dotEase;

        private float leftArrowEase;

        private float rightArrowEase;

        public OuiJournalPage Page => Pages[PageIndex];

        public OuiJournalPage NextPage => Pages[PageIndex + 1];

        public OuiJournalPage PrevPage => Pages[PageIndex - 1];

        public override IEnumerator Enter(OuiState from)
        {
            Statistics.MakeRequest();
            Overworld.ShowConfirmUI = false;
            fromAreaInspect = from is ChapterPanelSequence;
            PageIndex = 0;
            Visible = true;
            X = -1920f;
            turningPage = false;
            turningScale = 1f;
            rotation = 0f;
            dot = 0f;
            dotTarget = 0f;
            dotEase = 0f;
            leftArrowEase = 0f;
            rightArrowEase = 0f;
            NextPageBuffer =
                ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("journal-a", 1610, 1000);
            CurrentPageBuffer =
                ((ISourceVirtualContentEnvironment)engine).VirtualContent.CreateRenderTarget("journal-b", 1610, 1000);
            Pages.Add(new OuiJournalCoverPage(this));
            Pages.Add(new OuiJournalProgressPage(this));
            Pages.Add(new OuiJournalSpeedrunPage(this));
            Pages.Add(new OuiJournalDeathsPage(this));
            Pages.Add(new OuiJournalPoemPage(this));
            if (Statistics.Has()) Pages.Add(new OuiJournalGlobalPage(this));

            var num = 0;
            foreach (var page in Pages) page.PageIndex = num++;

            Pages[0].Redraw(CurrentPageBuffer);
            cameraStart = Overworld.Mountain.UntiltedCamera;
            cameraEnd = cameraStart;
            cameraEnd.Position += -SourceQuaternionMath.Forward(cameraStart.Rotation) * 1f;
            Overworld.Mountain.EaseCamera(Overworld.Mountain.Area, cameraEnd, 2f);
            Overworld.Mountain.AllowUserRotation = false;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / 0.4f)
            {
                rotation = -0.025f * Easing.BackOut(p);
                X = -1920f + 1920f * Easing.CubeInOut(p);
                dotEase = p;
                yield return null;
            }

            dotEase = 1f;
        }

        public override void HandleGraphicsReset()
        {
            base.HandleGraphicsReset();
            if (Pages.Count > 0) Page.Redraw(CurrentPageBuffer);
        }

        public IEnumerator TurnPage(int direction)
        {
            turningPage = true;
            if (direction < 0)
            {
                PageIndex--;
                turningScale = -1f;
                dotTarget -= 1f;
                Page.Redraw(CurrentPageBuffer);
                NextPage.Redraw(NextPageBuffer);
                while ((turningScale = ScalarMath.Approach(turningScale, 1f, engine.DeltaTime * 8f,
                           ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) < 1f)
                    yield return null;
            }
            else
            {
                NextPage.Redraw(NextPageBuffer);
                turningScale = 1f;
                dotTarget += 1f;
                while ((turningScale = ScalarMath.Approach(turningScale, -1f, engine.DeltaTime * 8f,
                           ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)) > -1f)
                    yield return null;

                PageIndex++;
                Page.Redraw(CurrentPageBuffer);
            }

            turningScale = 1f;
            turningPage = false;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Process.AudioSession.Play("event:/ui/world_map/journal/back");
            Overworld.Mountain.EaseCamera(Overworld.Mountain.Area, cameraStart, 0.4f);
            ((IOriginalUserIOEnvironment)engine).UserIO.SaveHandler(false, true);
            yield return EaseOut(0.4f);
            while (((IOriginalUserIOEnvironment)engine).UserIO.Saving) yield return null;

            CurrentPageBuffer.Dispose();
            NextPageBuffer.Dispose();
            Overworld.ShowConfirmUI = true;
            Pages.Clear();
            Visible = false;
            Overworld.Mountain.AllowUserRotation = true;
        }

        private IEnumerator EaseOut(float duration)
        {
            var rotFrom = rotation;
            for (var p = 0f; p < 1f; p += engine.DeltaTime / duration)
            {
                rotation = rotFrom * (1f - Easing.BackOut(p));
                X = 0f + -1920f * Easing.CubeInOut(p);
                dotEase = 1f - p;
                yield return null;
            }

            dotEase = 0f;
        }

        public override void Update()
        {
            base.Update();
            dot = ScalarMath.Approach(dot, dotTarget, engine.DeltaTime * 8f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            leftArrowEase = ScalarMath.Approach(leftArrowEase, dotTarget > 0f ? 1 : 0, engine.DeltaTime * 5f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic) * dotEase;
            rightArrowEase = ScalarMath.Approach(rightArrowEase, dotTarget < Pages.Count - 1 ? 1 : 0,
                engine.DeltaTime * 5f, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic) * dotEase;
            if (!Focused || turningPage) return;

            Page.Update();
            if (!PageTurningLocked)
            {
                if (Input.MenuLeft.Pressed && PageIndex > 0)
                {
                    if (PageIndex == 1)
                        Process.AudioSession.Play("event:/ui/world_map/journal/page_cover_back");
                    else
                        Process.AudioSession.Play("event:/ui/world_map/journal/page_main_back");

                    Add(new SimulationCoroutine(engine, TurnPage(-1)));
                }
                else if (Input.MenuRight.Pressed && PageIndex < Pages.Count - 1)
                {
                    if (PageIndex == 0)
                        Process.AudioSession.Play("event:/ui/world_map/journal/page_cover_forward");
                    else
                        Process.AudioSession.Play("event:/ui/world_map/journal/page_main_forward");

                    Add(new SimulationCoroutine(engine, TurnPage(1)));
                }
            }

            if (!PageTurningLocked && (Input.MenuJournal.Pressed || Input.MenuCancel.Pressed)) Close();
        }

        private void Close()
        {
            if (fromAreaInspect)
                Overworld.Goto<ChapterPanelSequence>();
            else
                Overworld.Goto<ChapterSelectSequence>();
        }

        public override void Render(ISourceRenderContext context)
        {
            var vector = Position + new Vector2(128f, 120f);
            var num = Easing.CubeInOut(Math.Max(0f, turningScale));
            var num2 = Easing.CubeInOut(Math.Abs(Math.Min(0f, turningScale)));
            if (Process.SaveContext.CurrentSave.CheatMode)
                SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["cheatmode"],
                    vector + new Vector2(80f, 360f), PackedColor.White, 1f, (float)Math.PI / 2f);

            if (Process.SaveContext.CurrentSave.AssistMode)
                SourceAtlasDrawing.DrawCentered(context, this, MountainResources.FileSelect["assist"],
                    vector + new Vector2(100f, 370f), PackedColor.White, 1f, (float)Math.PI / 2f);

            var mTexture = MountainResources.Journal["edge"];
            SourceAtlasDrawing.Draw(context, this, mTexture, vector + new Vector2(-mTexture.FrameWidth, 0f),
                Vector2.Zero,
                PackedColor.White, 1f, rotation);
            if (PageIndex > 0)
                SourceAtlasDrawing.Draw(context, this, MountainResources.Journal[PrevPage.PageTexture], vector,
                    Vector2.Zero, backColor, new Vector2(-1f, 1f), rotation);

            if (turningPage)
            {
                SourceAtlasDrawing.Draw(context, this, MountainResources.Journal[NextPage.PageTexture], vector,
                    Vector2.Zero, PackedColor.White, 1f, rotation);
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(NextPageBuffer.Target, vector, NextPageBuffer.Bounds,
                    PackedColor.White.PackedValue, rotation, Vector2.Zero, Vector2.One, SourceSpriteEffects.None, 0f);
            }

            if (turningPage && num2 > 0f)
                SourceAtlasDrawing.Draw(context, this, MountainResources.Journal[Page.PageTexture], vector,
                    Vector2.Zero,
                    backColor, new Vector2(-1f * num2, 1f), rotation);

            if (num > 0f)
            {
                SourceAtlasDrawing.Draw(context, this, MountainResources.Journal[Page.PageTexture], vector,
                    Vector2.Zero,
                    PackedColor.White, new Vector2(num, 1f), rotation);
                ((ISourceDrawScope)context).Draw.SpriteBatch.Draw(CurrentPageBuffer.Target, vector,
                    CurrentPageBuffer.Bounds, PackedColor.White.PackedValue, rotation, Vector2.Zero,
                    new Vector2(num, 1f),
                    SourceSpriteEffects.None, 0f);
            }

            if (Pages.Count > 0)
            {
                var count = Pages.Count;
                var mTexture2 = Graphics.GuiAtlas["dot_outline"];
                var num3 = mTexture2.FrameWidth * count;
                var vector2 = new Vector2(960f, 1040f - 40f * Easing.CubeOut(dotEase));
                for (var i = 0; i < count; i++)
                    SourceAtlasDrawing.DrawCentered(context, this, mTexture2,
                        vector2 + new Vector2(-num3 / 2 + mTexture2.FrameWidth * (i + 0.5f), 0f),
                        PackedColor.White * 0.25f);

                var x = 1f + ScalarMath.YoYo(dot % 1f) * 4f;
                SourceAtlasDrawing.DrawCentered(context, this, mTexture2,
                    vector2 + new Vector2(-num3 / 2 + mTexture2.FrameWidth * (dot + 0.5f), 0f),
                    PackedColor.White, new Vector2(x, 1f));
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["dotarrow_outline"],
                    vector2 + new Vector2(-num3 / 2 - 50, 32f * (1f - Easing.CubeOut(leftArrowEase))),
                    PackedColor.White * leftArrowEase, new Vector2(-1f, 1f));
                SourceAtlasDrawing.DrawCentered(context, this, Graphics.GuiAtlas["dotarrow_outline"],
                    vector2 + new Vector2(num3 / 2 + 50, 32f * (1f - Easing.CubeOut(rightArrowEase))),
                    PackedColor.White * rightArrowEase);
            }
        }

        public virtual bool GetAreaInterlude(IOriginalAreaData area)
        {
            return area.Interlude;
        }

        public virtual bool GetAreaIsFinal(IOriginalAreaData area)
        {
            return area.IsFinal;
        }
    }
}

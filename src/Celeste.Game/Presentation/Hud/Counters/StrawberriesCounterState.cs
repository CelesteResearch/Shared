using Celeste.Core.Display;
using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Graphics.Rendering;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;

namespace Celeste.Game.Presentation.Hud.Counters
{
    public class StrawberriesCounterState : SourceComponentState
    {
        public const int IconWidth = 60;
        public bool Golden;
        public Vector2 Position;
        public bool CenteredX;
        public bool CanWiggle = true;
        public float Scale = 1f;
        public float Stroke = 2f;
        public float Rotation;
        public PackedColor Color = PackedColor.White;
        public PackedColor OutOfColor = PackedColor.LightGray;
        public bool OverworldSfx;
        private int amount;
        private int outOf = -1;
        private WigglerComponent wiggler;
        private float flashTimer;
        private string sAmount;
        private string sOutOf;
        private AtlasEntry x;
        private bool showOutOf;
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private global::Celeste.Graphics.Text.ActiveBitmapFont ActiveFont =>
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        public StrawberriesCounterState(ISourceEngineContext engine, bool centeredX,
            int amount, int outOf = 0, bool showOutOf = false) : base(true, true)
        {
            this.engine = engine;
            CenteredX = centeredX;
            this.amount = amount;
            this.outOf = outOf;
            this.showOutOf = showOutOf;
            UpdateStrings();
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.5f, 3f);
            wiggler.StartZero = true;
            wiggler.UseRawDeltaTime = true;
            x = Graphics.GuiAtlas["x"];
        }

        public int Amount
        {
            get => amount;
            set
            {
                if (amount == value) return;
                amount = value;
                UpdateStrings();
                if (CanWiggle)
                {
                    if (OverworldSfx)
                        ((IOriginalGameplayProcess)engine).AudioSession.Play(Golden
                            ? "event:/ui/postgame/goldberry_count"
                            : "event:/ui/postgame/strawberry_count");
                    else
                        ((IOriginalGameplayProcess)engine).AudioSession.Play("event:/ui/game/increment_strawberry");
                    wiggler.Start();
                    flashTimer = .5f;
                }
            }
        }

        public int OutOf
        {
            get => outOf;
            set
            {
                outOf = value;
                UpdateStrings();
            }
        }

        public bool ShowOutOf
        {
            get => showOutOf;
            set
            {
                if (showOutOf != value)
                {
                    showOutOf = value;
                    UpdateStrings();
                }
            }
        }

        public float FullHeight => ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(ActiveFont.LineHeight,
            Graphics.GuiAtlas["collectables/strawberry"].FrameHeight);

        public Vector2 RenderPosition => Vector2Geometry.Round(
            (Entity != null ? ((ISourceEntityPosition)Entity).Position : Vector2.Zero) + Position);

        private void UpdateStrings()
        {
            sAmount = amount.ToString();
            sOutOf = outOf > -1 ? "/" + outOf : "";
        }

        public void Wiggle()
        {
            wiggler.Start();
            flashTimer = .5f;
        }

        public override void Update()
        {
            base.Update();
            // The original private Wiggler is detached, not a member of ComponentList.
            if (wiggler.Active) wiggler.Update();
            if (flashTimer > 0f) flashTimer -= engine.RawDeltaTime;
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 renderPosition = RenderPosition;
            Vector2 along = Vector2Geometry.AngleToVector(Rotation, 1f);
            Vector2 down = new Vector2(0f - along.Y, along.X);
            string text = showOutOf ? sOutOf : "";
            float numberWidth = ActiveFont.Measure(sAmount).X;
            float suffixWidth = ActiveFont.Measure(text).X;
            float width = 62f + x.FrameWidth + 2f + numberWidth + suffixWidth;
            PackedColor color = Color;
            if (flashTimer > 0f && Scene != null &&
                ((ISourceScene)Scene).SourceScene.Clock.BetweenRawInterval(.05f))
                color = ((IStrawberriesCounterStaticEnvironment)engine).StrawberriesCounterStatics.FlashColor;
            if (CenteredX) renderPosition -= along * (width / 2f) * Scale;
            AtlasEntry icon = Graphics.GuiAtlas[Golden ? "collectables/goldberry" : "collectables/strawberry"];
            DrawCentered(context, icon, renderPosition + along * 60f * .5f * Scale, PackedColor.White);
            DrawCentered(context, x, renderPosition + along * (62f + x.FrameWidth * .5f) * Scale + down * 2f * Scale,
                color);
            ActiveFont.DrawOutline(context, Entity, sAmount,
                renderPosition + along * (width - suffixWidth - numberWidth * .5f) * Scale +
                down * (wiggler.Value * 18f) * Scale,
                new Vector2(.5f), Vector2.One * Scale, color, Stroke, PackedColor.Black);
            if (text != "")
                ActiveFont.DrawOutline(context, Entity, text,
                    renderPosition + along * (width - suffixWidth / 2f) * Scale,
                    new Vector2(.5f), Vector2.One * Scale, OutOfColor, Stroke, PackedColor.Black);
        }

        private void DrawCentered(ISourceRenderContext context, AtlasEntry texture, Vector2 position, PackedColor color)
        {
            SourceAtlasDrawing.DrawCentered(context, Entity, texture, position, color, Scale);
        }
    }
}

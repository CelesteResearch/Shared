using Celeste.Core.Display;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Tracking;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Presentation.Hud.Counters
{
    public class DeathsCounterState : SourceComponentState
    {
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private global::Celeste.Graphics.Text.ActiveBitmapFont ActiveFont =>
            ((IOriginalGameTextEnvironment)engine).Text.ActiveFont;

        private const int IconWidth = 60;

        public Vector2 Position;

        public bool CenteredX;

        public bool CanWiggle = true;

        public float Alpha = 1f;

        public float Scale = 1f;

        public float Stroke = 2f;

        public PackedColor Color = PackedColor.White;

        private int amount;

        private int minDigits;

        private WigglerComponent wiggler;

        private WigglerComponent iconWiggler;

        private float flashTimer;

        private string sAmount;

        private AtlasEntry icon;

        private AtlasEntry x;

        public int Amount
        {
            get { return amount; }
            set
            {
                if (amount != value)
                {
                    amount = value;
                    UpdateString();
                    if (CanWiggle)
                    {
                        wiggler.Start();
                        flashTimer = 0.5f;
                    }
                }
            }
        }

        public int MinDigits
        {
            get { return minDigits; }
            set
            {
                if (minDigits != value)
                {
                    minDigits = value;
                    UpdateString();
                }
            }
        }

        public Vector2 RenderPosition =>
            Vector2Geometry.Round(((Entity != null) ? ((ISourceEntityPosition)Entity).Position : Vector2.Zero) +
                                  Position);

        public DeathsCounterState(ISourceEngineContext engine, OriginalAreaMode mode, bool centeredX, int amount,
            int minDigits = 0)
            : base(true, true)
        {
            this.engine = engine;
            CenteredX = centeredX;
            this.amount = amount;
            this.minDigits = minDigits;
            UpdateString();
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f);
            wiggler.StartZero = true;
            wiggler.UseRawDeltaTime = true;
            iconWiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(0.5f, 3f);
            iconWiggler.UseRawDeltaTime = true;
            SetMode(mode);
            x = Graphics.GuiAtlas["x"];
        }

        private void UpdateString()
        {
            if (minDigits > 0)
            {
                sAmount = amount.ToString("D" + minDigits);
            }
            else
            {
                sAmount = amount.ToString();
            }
        }

        public void SetMode(OriginalAreaMode mode)
        {
            switch (mode)
            {
                case OriginalAreaMode.Normal:
                    icon = Graphics.GuiAtlas["collectables/skullBlue"];
                    break;
                case OriginalAreaMode.BSide:
                    icon = Graphics.GuiAtlas["collectables/skullRed"];
                    break;
                default:
                    icon = Graphics.GuiAtlas["collectables/skullGold"];
                    break;
            }

            iconWiggler.Start();
        }

        public void Wiggle()
        {
            wiggler.Start();
            flashTimer = 0.5f;
        }

        public override void Update()
        {
            base.Update();
            if (wiggler.Active)
            {
                wiggler.Update();
            }

            if (iconWiggler.Active)
            {
                iconWiggler.Update();
            }

            if (flashTimer > 0f)
            {
                flashTimer -= engine.RawDeltaTime;
            }
        }

        public override void Render(ISourceRenderContext context)
        {
            Vector2 renderPosition = RenderPosition;
            float num = ActiveFont.Measure(sAmount).X;
            float num2 = 62f + (float)x.FrameWidth + 2f + num;
            PackedColor color = Color;
            PackedColor black = PackedColor.Black;
            if (flashTimer > 0f && Scene != null && ((ISourceScene)Scene).SourceScene.Clock.BetweenRawInterval(0.05f))
            {
                color = ((IStrawberriesCounterStaticEnvironment)engine).StrawberriesCounterStatics.FlashColor;
            }

            if (Alpha < 1f)
            {
                color *= Alpha;
                black *= Alpha;
            }

            if (CenteredX)
            {
                renderPosition -= Vector2.UnitX * (num2 / 2f) * Scale;
            }

            SourceAtlasDrawing.DrawCentered(context, Entity, icon, renderPosition + new Vector2(30f, 0f) * Scale,
                PackedColor.White * Alpha, Scale * (1f + iconWiggler.Value * 0.2f));
            SourceAtlasDrawing.DrawCentered(context, Entity, x,
                renderPosition + new Vector2(62f + (float)(x.FrameWidth / 2), 2f) * Scale, color, Scale);
            ActiveFont.DrawOutline(context, Entity, sAmount,
                renderPosition + new Vector2(num2 - num / 2f, (0f - wiggler.Value) * 18f) * Scale,
                new Vector2(0.5f, 0.5f),
                Vector2.One * Scale, color, Stroke, black);
        }
    }
}

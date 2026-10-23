using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Presentation.Hud.Counters;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Scene.Entities;

namespace Celeste.Game.Presentation.Hud.Strawberries
{
    public sealed class TotalStrawberriesDisplayState : SceneEntityState
    {
        public static readonly PackedColor FlashColor = SourceHexColor.HexToColor("FF5E76");
        private readonly AtlasEntry bg;
        public float DrawLerp;
        private float strawberriesUpdateTimer;
        private float strawberriesWaitTimer;
        private readonly StrawberriesCounterState strawberries;
        private readonly ISourceEngineContext engine;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private SettingsState Settings => ((ISettingsContext)engine).Settings;

        private int CurrentTotalStrawberries => ((IOriginalSaveCollectibleTotalsEnvironment)engine)
            .SaveCollectibleTotals.GetTotalStrawberriesSafe(((IOriginalGameplayProcess)engine).SaveContext.CurrentSave);

        public TotalStrawberriesDisplayState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration)
        {
            this.engine = engine;
            Position = new(0f, 96f);
            Depth = -101;
            AddTag(((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.TransitionUpdate.Value);
            bg = Graphics.GuiAtlas.Entries["strawberryCountBG"];
            strawberries = new(engine, false, CurrentTotalStrawberries);
            OwnedComponents.Add(strawberries);
        }

        public override void Update()
        {
            base.Update();
            var level = Scene as OriginalLevelSceneRoot;
            if (CurrentTotalStrawberries > strawberries.Amount && strawberriesUpdateTimer <= 0f)
                strawberriesUpdateTimer = .4f;
            if (CurrentTotalStrawberries > strawberries.Amount || strawberriesUpdateTimer > 0f ||
                strawberriesWaitTimer > 0f || (level.Paused && level.PauseMainMenuOpen))
                DrawLerp = ScalarMath.Approach(DrawLerp, 1f, 1.2f * engine.RawDeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            else
                DrawLerp = ScalarMath.Approach(DrawLerp, 0f, 2f * engine.RawDeltaTime,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            if (strawberriesWaitTimer > 0f) strawberriesWaitTimer -= engine.RawDeltaTime;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            if (strawberriesUpdateTimer > 0f && DrawLerp == 1f)
            {
                strawberriesUpdateTimer -= engine.RawDeltaTime;
                if (strawberriesUpdateTimer <= 0f)
                {
                    if (strawberries.Amount < CurrentTotalStrawberries) strawberries.Amount++;
                    strawberriesWaitTimer = 2f;
                    if (strawberries.Amount < CurrentTotalStrawberries) strawberriesUpdateTimer = .3f;
                }
            }

            if (Visible)
            {
                var targetY = 96f;
                if (!level.TimerHidden)
                {
                    if (Settings.SpeedrunClock == 1) targetY += 58f;
                    else if (Settings.SpeedrunClock == 2) targetY += 78f;
                }

                Y = ScalarMath.Approach(Y, targetY, engine.DeltaTime * 800f,
                    ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            }

            Visible = DrawLerp > 0f;
        }

        public override void Render(ISourceRenderContext context)
        {
            var position = Vector2Math.Round(Vector2Math.Lerp(new(-bg.FrameWidth, Position.Y),
                new(32f, Position.Y), ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(DrawLerp),
                ((ISourceScalarEnvironment)engine).ScalarArithmetic));
            var draw = new AtlasTextureDraw(bg, position + new Vector2(-96f, 12f),
                new(0f, bg.FrameHeight * .5f), PackedColor.White, Vector2.One);
            ((ISourceRenderCommandSink<AtlasTextureDraw>)context).Draw(in draw, this);
            strawberries.Position = position + new Vector2(0f, -Position.Y);
            strawberries.Render(context);
        }
    }
}

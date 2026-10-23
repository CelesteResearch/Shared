using System;
using System.Globalization;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Text.BitmapFonts;
using Celeste.Scene.Components.Oscillation;
using Celeste.Scene.Entities;
using Celeste.Simulation.Presentation.Hud.Speedrun;

namespace Celeste.Game.Presentation.Hud.Speedrun
{
    public sealed class SpeedrunTimerState : SceneEntityState
    {
        public float CompleteTimer;
        public const int GuiChapterHeight = 58;
        public const int GuiFileHeight = 78;
        private readonly AtlasEntry bg;
        public float DrawLerp;
        private readonly WigglerComponent wiggler;
        private readonly ISourceEngineContext engine;

        public SpeedrunTimerState(ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine)
                .EntitySourceDataRegistration)
        {
            this.engine = engine;
            bg = ((OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics).GuiAtlas[
                "strawberryCountBG"];
            Tags = ((IOriginalGameTagsEnvironment)engine).Tags.HUD.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.Global.Value |
                   ((IOriginalGameTagsEnvironment)engine).Tags.PauseUpdate
                   .Value | ((IOriginalGameTagsEnvironment)engine).Tags
                   .TransitionUpdate.Value;
            Depth = -100;
            Position = new(0f, 60f);
            CalculateBaseSizes(engine);
            wiggler = ((ISourceWigglerPoolScope)engine).WigglerPool.Create(.5f, 4f);
            wiggler.AddTo(OwnedComponents);
        }

        public override void Update()
        {
            var level = (OriginalLevelSceneRoot)Scene;
            if (level.Completed)
            {
                if (CompleteTimer == 0f) wiggler.Start();
                CompleteTimer += engine.DeltaTime;
            }

            var show = false;
            if (level.Session.AreaID != 8 && !level.TimerHidden)
            {
                if (((ISettingsContext)engine).Settings.SpeedrunClock == (int)SpeedrunClockMode.Chapter)
                {
                    if (CompleteTimer < 3f) show = true;
                }
                else if (((ISettingsContext)engine).Settings.SpeedrunClock ==
                         (int)SpeedrunClockMode.File)
                {
                    show = true;
                }
            }

            DrawLerp = ScalarMath.Approach(DrawLerp, show ? 1f : 0f, engine.DeltaTime * 4f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (DrawLerp <= 0f) return;
            var x = -300f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(1f - DrawLerp);
            var level = (OriginalLevelSceneRoot)Scene;
            var session = level.Session;
            if (((ISettingsContext)engine).Settings.SpeedrunClock == (int)SpeedrunClockMode.Chapter)
            {
                var time = ShortGameplayFormat(session.Time);
                DrawBackground(context, new(x, Position.Y), 1f);
                DrawTimeSource(context, new(x + 32f, Position.Y + 44f), time, 1f + wiggler.Value * .15f,
                    session.StartedFromBeginning, level.Completed, session.BeatBestTime);
            }
            else if (((ISettingsContext)engine).Settings.SpeedrunClock == (int)SpeedrunClockMode.File)
            {
                var time = TimeSpan.FromTicks(session.Time);
                var text = !(time.TotalHours >= 1.0)
                    ? time.ToString(@"mm\:ss")
                    : (int)time.TotalHours + ":" + time.ToString(@"mm\:ss");
                var saveTime =
                    TimeSpan.FromTicks(((IOriginalGameplayProcess)engine)
                        .SaveContext.CurrentSave.Time);
                var hours = (int)saveTime.TotalHours;
                var fileTime = hours + saveTime.ToString(@"\:mm\:ss\.fff");
                var width = hours < 10 ? 64 : hours < 100 ? 96 : 128;
                SourcePrimitiveDrawing.Rect(context, this, x, Position.Y, width + 2, 38f, PackedColor.Black);
                DrawBackground(context, new(x + width, Position.Y), 1f);
                DrawTimeSource(context, new(x + 32f, Position.Y + 44f), fileTime);
                DrawBackground(context, new(x, Position.Y + 38f), .6f);
                DrawTimeSource(context, new(x + 32f, Position.Y + 40f + 26.400002f), text,
                    (1f + wiggler.Value * .15f) * .6f, session.StartedFromBeginning, level.Completed,
                    session.BeatBestTime,
                    .6f);
            }
        }

        private void DrawBackground(ISourceRenderContext context, Vector2 position, float scale)
        {
            SourceAtlasDrawing.Draw(context, this, bg, position, Vector2.Zero, PackedColor.White, Vector2.One * scale);
        }

        public static SpeedrunTimeMetrics GetMetrics(ISourceEngineContext engine)
        {
            return ((ISourceSpeedrunTimeMetricsEnvironment)engine).SpeedrunTimeMetrics;
        }

        public static void CalculateBaseSizes(ISourceEngineContext engine)
        {
            var text = ((IOriginalGameTextEnvironment)engine).Text;
            var font = text.Fonts.Get(text.Dialog.Languages["english"].FontFace);
            var size = text.Dialog.Languages["english"].FontFaceSize;
            GetMetrics(engine).CalculateBaseSizes(font, size);
        }

        public static void DrawTimeSource(ISourceEngineContext engine, ISourceRenderContext context, object owner,
            Vector2 position, string timeString, float scale = 1f, bool valid = true,
            bool finished = false, bool bestTime = false, float alpha = 1f)
        {
            var sink = new SourceGlyphSink(context, owner, engine);
            DrawTime(ref sink, GetMetrics(engine), position, timeString, scale, valid, finished, bestTime, alpha);
        }

        public interface ITimeGlyphSink
        {
            void Draw(string glyph, Vector2 position, Vector2 justify, Vector2 scale, PackedColor color);
        }

        private readonly struct SourceGlyphSink : ITimeGlyphSink
        {
            private readonly ISourceRenderContext context;
            private readonly object owner;
            private readonly SourcePixelFont font;
            private readonly float baseSize;

            public SourceGlyphSink(ISourceRenderContext context, object owner, ISourceEngineContext engine)
            {
                this.context = context;
                this.owner = owner;
                var text = ((IOriginalGameTextEnvironment)engine).Text;
                font = text.Fonts.Get(text.Dialog.Languages["english"].FontFace);
                baseSize = text.Dialog.Languages["english"].FontFaceSize;
            }

            public void Draw(string glyph, Vector2 position, Vector2 justify, Vector2 scale, PackedColor color)
            {
                font.DrawOutline(context, owner, baseSize, glyph,
                    position, justify, scale, color, 2f, PackedColor.Black);
            }
        }

        private void DrawTimeSource(ISourceRenderContext context, Vector2 position, string timeString, float scale = 1f,
            bool valid = true, bool finished = false, bool bestTime = false, float alpha = 1f)
        {
            // Original DrawTime obtains English font and size once at this call point, after the background draw.
            var sink = new SourceGlyphSink(context, this, engine);
            DrawTime(ref sink, GetMetrics(engine), position, timeString, scale, valid, finished, bestTime, alpha);
        }

        public static void DrawTime<TSink>(ref TSink sink, SpeedrunTimeMetrics metrics, Vector2 position,
            string timeString,
            float scale = 1f,
            bool valid = true, bool finished = false, bool bestTime = false, float alpha = 1f)
            where TSink : struct, ITimeGlyphSink
        {
            var num = scale;
            var num2 = position.X;
            var num3 = position.Y;
            var color = PackedColor.White * alpha;
            // Color.LightGray is (211, 211, 211, 255).
            var color2 = PackedColor.LightGray * alpha;
            if (!valid)
            {
                color = SourceHexColor.HexToColor("918988") * alpha;
                color2 = SourceHexColor.HexToColor("7a6f6d") * alpha;
            }
            else if (bestTime)
            {
                color = SourceHexColor.HexToColor("fad768") * alpha;
                color2 = SourceHexColor.HexToColor("cfa727") * alpha;
            }
            else if (finished)
            {
                color = SourceHexColor.HexToColor("6ded87") * alpha;
                color2 = SourceHexColor.HexToColor("43d14c") * alpha;
            }

            for (var i = 0; i < timeString.Length; i++)
            {
                var c = timeString[i];
                if (c == '.')
                {
                    num = scale * 0.7f;
                    num3 -= 5f * scale;
                }

                var color3 = c == ':' || c == '.' || num < scale ? color2 : color;
                var num4 = ((c == ':' || c == '.' ? metrics.SpacerWidth : metrics.NumberWidth) + 4f) * num;
                // :145 `font.DrawOutline(fontFaceSize, c, new Vector2(num2 + num4 / 2f, num3),
                // (0.5f, 1f), Vector2.One * num, color3, 2f, Black)`.
                sink.Draw(c.ToString(), new(num2 + num4 / 2f, num3), new(0.5f, 1f),
                    Vector2.One * num, color3);
                num2 += num4;
            }
        }


        public static float TimeWidth(SpeedrunTimeMetrics metrics, string timeString, float scale = 1f)
        {
            return TimeWidth(metrics.NumberWidth, metrics.SpacerWidth, timeString, scale);
        }

        public static float TimeWidth(float numberWidth, float spacerWidth, string timeString, float scale = 1f)
        {
            var currentScale = scale;
            var width = 0f;
            foreach (var c in timeString)
            {
                if (c == '.') currentScale = scale * .7f;
                width += ((c == ':' || c == '.' ? spacerWidth : numberWidth) + 4f) * currentScale;
            }

            return width;
        }

        public static string ShortGameplayFormat(long ticks)
        {
            var time = TimeSpan.FromTicks(ticks);
            if (time.TotalHours >= 1.0)
                return (int)time.TotalHours + ":" + time.ToString(@"mm\:ss\.fff", CultureInfo.InvariantCulture);
            return time.ToString(@"m\:ss\.fff", CultureInfo.InvariantCulture);
        }
    }
}

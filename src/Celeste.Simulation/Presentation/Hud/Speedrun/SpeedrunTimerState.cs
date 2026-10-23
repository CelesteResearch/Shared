using System;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using Celeste.Simulation.Rendering;
using Celeste.Simulation;

namespace Celeste.Simulation.Presentation.Hud.Speedrun
{
    // Port of Celeste.SpeedrunTimerDisplay (Artifacts/Reference/Original/Celeste/SpeedrunTimerDisplay.cs:7-165).
    // The original is a Level HUD entity that LevelLoader adds once per level load
    // (LevelLoader.cs:94 `this.Level.Add(new SpeedrunTimerDisplay())`) with
    // Tag = Tags.HUD | Tags.Global | Tags.PauseUpdate | Tags.TransitionUpdate (:27) and Depth -100 (:28).
    // It owns the top-left speedrun clock: a strawberry-count plate carrying the session time, and in
    // File mode a second, dimmer plate below it carrying the current session time while the bright plate
    // above carries SaveData.Time.
    public sealed class SpeedrunTimerState
    {
        // SpeedrunTimerDisplay.cs:11/:13.
        public const int GuiChapterHeight = 58;

        public const int GuiFileHeight = 78;

        // SpeedrunTimerDisplay.cs:28-29 `base.Depth = -100; base.Y = 60f;`.
        public const int DisplayDepth = -100;
        public const float DisplayY = 60f;

        // SpeedrunTimerDisplay.cs:31 `Wiggler.Create(0.5f, 4f)` (Monocle/Wiggler.cs:41-55:
        // increment = 1f / duration, sineAdd = 6.2831855f * frequency).
        public const float WigglerDuration = 0.5f;
        public const float WigglerFrequency = 4f;
        public const float WigglerIncrement = 1f / WigglerDuration;

        public const float WigglerSineAdd = 6.2831855f * WigglerFrequency;

        // SpeedrunTimerDisplay.cs:66 `CompleteTimer < 3f`.
        public const float ChapterCompleteHideDelay = 3f;

        // SpeedrunTimerDisplay.cs:76 `Engine.DeltaTime * 4f`.
        public const float DrawLerpRate = 4f;

        // SpeedrunTimerDisplay.cs:84 `-300f * Ease.CubeIn(1f - DrawLerp)`.
        public const float SlideDistance = 300f;

        // SpeedrunTimerDisplay.cs:15/:17 `private static float numberWidth; private static float spacerWidth;`
        // Both live for the whole process and are written by CalculateBaseSizes (:34-48); numberWidth only
        // grows (`if (x > numberWidth)`), spacerWidth is assigned unconditionally.
        static float numberWidth;
        static float spacerWidth;

        public static float NumberWidth
        {
            get { return numberWidth; }
        }

        public static float SpacerWidth
        {
            get { return spacerWidth; }
        }

        readonly global::Celeste.Simulation.Presentation.Hud.Speedrun.ISpeedrunTimerWorld world;

        // SpeedrunTimerDisplay.cs:9 `public float CompleteTimer;`.
        public float CompleteTimer;

        // SpeedrunTimerDisplay.cs:21 `public float DrawLerp;`.
        public float DrawLerp;

        // SpeedrunTimerDisplay.cs:23 `private Wiggler wiggler` -> Wiggler.Value (Monocle/Wiggler.cs:17/:132).
        public float WigglerValue;

        // Wiggler.Counter (Monocle/Wiggler.cs:12/:116/:123-126).
        public float WigglerCounter;

        // Wiggler.sineCounter (Monocle/Wiggler.cs:149/:120).
        public float WigglerSineCounter;

        // Wiggler.Active (Monocle/Wiggler.cs:54/:86/:125). Monocle EntityList.Update skips a component's
        // own Update while Active is false, so a never-started wiggler is not ticked at all.
        public bool WigglerActive;

        // SpeedrunTimerDisplay.cs:61 `bool flag` - the per-frame visibility decision.
        public bool VisibleTarget;

        // The RemoveSelf() half of the port: CS07_Credits.cs:44-48 removes the level's
        // SpeedrunTimerDisplay before the crawl starts, through ICreditsChapterWorld.RemoveSpeedrunTimer.
        public bool Removed;

        // SpeedrunTimerDisplay.cs:25-32.
        public SpeedrunTimerState(global::Celeste.Simulation.Presentation.Hud.Speedrun.ISpeedrunTimerWorld world)
        {
            this.world = world ?? throw new ArgumentNullException(nameof(world));
            // Add(wiggler = Wiggler.Create(0.5f, 4f)): Wiggler.Create defaults to start: false, so
            // Wiggler.Init sets Active = false and leaves Counter, sineCounter and Value at 0.
            WigglerActive = false;
            WigglerCounter = 0f;
            WigglerSineCounter = 0f;
            WigglerValue = 0f;
        }

        public global::Celeste.Simulation.Presentation.Hud.Speedrun.ISpeedrunTimerWorld World
        {
            get { return world; }
        }

        // SpeedrunTimerDisplay.cs:34-48. The original reads Dialog.Languages["english"].Font and its
        // FontFaceSize and writes the two process-wide statics.
        public static void CalculateBaseSizes(global::Celeste.Graphics.Text.BitmapFontPresentation englishFont)
        {
            for (int i = 0; i < 10; i++)
            {
                float x = englishFont.Measure(i.ToString(CultureInfo.InvariantCulture)).X;
                if (x > numberWidth) numberWidth = x;
            }

            spacerWidth = englishFont.Measure(".").X;
        }

        // SpeedrunTimerDisplay.cs:50-78.
        public void Update(float deltaTime)
        {
            // :53-60 Level.Completed starts the one-shot wiggler and advances CompleteTimer.
            if (world.LevelCompleted)
            {
                if (CompleteTimer == 0f) StartWiggler();
                CompleteTimer += deltaTime;
            }

            // :61-75.
            bool flag = false;
            if (world.AreaId != 8 && !world.TimerHidden)
            {
                if (world.Clock == global::Celeste.Simulation.Presentation.Hud.Speedrun.SpeedrunClockMode.Chapter)
                {
                    if (CompleteTimer < ChapterCompleteHideDelay) flag = true;
                }
                else if (world.Clock == global::Celeste.Simulation.Presentation.Hud.Speedrun.SpeedrunClockMode.File)
                {
                    flag = true;
                }
            }

            VisibleTarget = flag;
            // :76 DrawLerp = Calc.Approach(DrawLerp, flag ? 1 : 0, Engine.DeltaTime * 4f)
            // (Monocle/Calc.cs:959-966).
            DrawLerp = Approach(DrawLerp, flag ? 1f : 0f, deltaTime * DrawLerpRate);
            UpdateWiggler(deltaTime);
        }

        // SpeedrunTimerDisplay.cs:80-109.
        public IReadOnlyList<global::Celeste.Graphics.Display.ImagePlacement> Images()
        {
            var images = new List<global::Celeste.Graphics.Display.ImagePlacement>();
            // :82 `if (!(DrawLerp <= 0f))`.
            if (Removed || DrawLerp <= 0f) return images;
            // :84 `float num = -300f * Ease.CubeIn(1f - DrawLerp);` Ease.CubeIn = t*t*t (Monocle/Ease.cs:59).
            float num = -SlideDistance * CubeIn(1f - DrawLerp);
            // :85-86 the original dereferences `base.Scene as Level` and `level.Session` unconditionally
            // here; the port reads the same values through the world.
            if (world.Clock == global::Celeste.Simulation.Presentation.Hud.Speedrun.SpeedrunClockMode.Chapter)
            {
                // :89-91.
                string timeString = ShortGameplayFormat(world.SessionTimeTicks);
                world.DrawBackground(images, new Vector2(num, DisplayY), Vector2.Zero, Vector4.One, 1f);
                DrawTime(images, new Vector2(num + 32f, DisplayY + 44f), timeString, 1f + WigglerValue * 0.15f,
                    world.StartedFromBeginning, world.LevelCompleted, world.BeatBestTime);
            }
            else if (world.Clock == global::Celeste.Simulation.Presentation.Hud.Speedrun.SpeedrunClockMode.File)
            {
                // :95-106.
                var timeSpan = TimeSpan.FromTicks(world.SessionTimeTicks);
                string text = ((!(timeSpan.TotalHours >= 1.0))
                    ? timeSpan.ToString("mm\\:ss", CultureInfo.InvariantCulture)
                    : ((int)timeSpan.TotalHours + ":" + timeSpan.ToString("mm\\:ss", CultureInfo.InvariantCulture)));
                var timeSpan2 = TimeSpan.FromTicks(world.SaveTimeTicks);
                int num2 = (int)timeSpan2.TotalHours;
                string timeString2 = num2 + timeSpan2.ToString("\\:mm\\:ss\\.fff", CultureInfo.InvariantCulture);
                int num3 = ((num2 < 10) ? 64 : ((num2 < 100) ? 96 : 128));
                world.DrawRect(images, num, DisplayY, num3 + 2, 38f, new Vector4(0f, 0f, 0f, 1f));
                world.DrawBackground(images, new Vector2(num + num3, DisplayY), Vector2.Zero, Vector4.One, 1f);
                DrawTime(images, new Vector2(num + 32f, DisplayY + 44f), timeString2);
                world.DrawBackground(images, new Vector2(num, DisplayY + 38f), Vector2.Zero, Vector4.One, 0.6f);
                DrawTime(images, new Vector2(num + 32f, DisplayY + 40f + 26.400002f), text,
                    (1f + WigglerValue * 0.15f) * 0.6f, world.StartedFromBeginning, world.LevelCompleted,
                    world.BeatBestTime, 0.6f);
            }

            return images;
        }

        // The glyph terminal of SpeedrunTimerDisplay.cs:145
        // `font.DrawOutline(fontFaceSize, c.ToString(), new Vector2(num2 + num4 / 2f, num3), (0.5f, 1f),
        // Vector2.One * num, color3, 2f, Black)`. The original reaches PixelFont through
        // Dialog.Languages["english"].Font; the port injects it so that both users of the layout below -
        // the in-play HUD (world.DrawGlyph, depth -100) and the area-complete / ending presentations
        // (their own English font, depth 0) - run ONE implementation instead of two copies of the loop.
        public delegate void GlyphDrawer(ICollection<global::Celeste.Graphics.Display.ImagePlacement> target,
            string glyph, Vector2 position,
            Vector2 justify, Vector2 scale, Vector4 color);

        // SpeedrunTimerDisplay.cs:111-148. The original is `public static void DrawTime(...)` and every
        // caller reaches that one body: SpeedrunTimerDisplay.cs:91/:104/:106 (the in-play HUD),
        // AreaComplete.cs:182/:187/:189 (the area-complete screen, through
        // AreaCompleteInfoPresentation.DrawTime) and CS08_Ending.cs:26 (the epilogue pie screen, through
        // EpilogueEndingSequence -> AreaCompleteInfoPresentation.DrawTime). CS10_Ending.cs routes through
        // AreaComplete.Info as well, so it is that same body a third time. The static overload below is
        // the one body; this instance overload is the HUD's way into it.
        public void DrawTime(ICollection<global::Celeste.Graphics.Display.ImagePlacement> target, Vector2 position,
            string timeString,
            float scale = 1f, bool valid = true, bool finished = false, bool bestTime = false, float alpha = 1f)
        {
            DrawTime(target, world.DrawGlyph, position, timeString, scale, valid, finished, bestTime, alpha);
        }

        // SpeedrunTimerDisplay.cs:111-148, the one implementation.
        public static void DrawTime(ICollection<global::Celeste.Graphics.Display.ImagePlacement> target,
            GlyphDrawer drawGlyph, Vector2 position,
            string timeString, float scale = 1f, bool valid = true, bool finished = false, bool bestTime = false,
            float alpha = 1f)
        {
            float num = scale;
            float num2 = position.X;
            float num3 = position.Y;
            var color = Scale(Vector4.One, alpha);
            // Color.LightGray is (211, 211, 211, 255).
            var color2 = Scale(new Vector4(211f, 211f, 211f, 255f) / 255f, alpha);
            if (!valid)
            {
                color = Scale(Hex("918988"), alpha);
                color2 = Scale(Hex("7a6f6d"), alpha);
            }
            else if (bestTime)
            {
                color = Scale(Hex("fad768"), alpha);
                color2 = Scale(Hex("cfa727"), alpha);
            }
            else if (finished)
            {
                color = Scale(Hex("6ded87"), alpha);
                color2 = Scale(Hex("43d14c"), alpha);
            }

            for (int i = 0; i < timeString.Length; i++)
            {
                char c = timeString[i];
                if (c == '.')
                {
                    num = scale * 0.7f;
                    num3 -= 5f * scale;
                }

                var color3 = ((c == ':' || c == '.' || num < scale) ? color2 : color);
                float num4 = (((c == ':' || c == '.') ? spacerWidth : numberWidth) + 4f) * num;
                // :145 `font.DrawOutline(fontFaceSize, c, new Vector2(num2 + num4 / 2f, num3),
                // (0.5f, 1f), Vector2.One * num, color3, 2f, Black)`.
                drawGlyph(target, c.ToString(), new Vector2(num2 + num4 / 2f, num3), new Vector2(0.5f, 1f),
                    Vector2.One * num, color3);
                num2 += num4;
            }
        }

        // SpeedrunTimerDisplay.cs:150-164. The original is static; this instance overload is the port's
        // existing surface and forwards to the one implementation below, which the area-complete /
        // ending presentations call directly.
        public float GetTimeWidth(string timeString, float scale = 1f)
        {
            return TimeWidth(timeString, scale);
        }

        // SpeedrunTimerDisplay.cs:150-164, the one implementation.
        public static float TimeWidth(string timeString, float scale = 1f)
        {
            float num = scale;
            float num2 = 0f;
            foreach (char c in timeString)
            {
                if (c == '.') num = scale * 0.7f;
                float num3 = (((c == ':' || c == '.') ? spacerWidth : numberWidth) + 4f) * num;
                num2 += num3;
            }

            return num2;
        }

        // Monocle/Calc.cs:647-654 ShortGameplayFormat.
        public static string ShortGameplayFormat(long ticks)
        {
            var time = TimeSpan.FromTicks(ticks);
            if (time.TotalHours >= 1.0)
                return (int)time.TotalHours + ":" + time.ToString("mm\\:ss\\.fff", CultureInfo.InvariantCulture);
            return time.ToString("m\\:ss\\.fff", CultureInfo.InvariantCulture);
        }

        // Wiggler.Update (Monocle/Wiggler.cs:111-137). Monocle's EntityList.Update only calls a
        // component's own Update while Active is true (Monocle/EntityList.cs / Component.Update), so an
        // inactive wiggler keeps Value at 0 and is skipped entirely.
        public void UpdateWiggler(float deltaTime)
        {
            if (!WigglerActive) return;
            WigglerSineCounter += WigglerSineAdd * deltaTime;
            WigglerCounter -= WigglerIncrement * deltaTime;
            if (WigglerCounter <= 0f)
            {
                WigglerCounter = 0f;
                WigglerActive = false;
            }

            WigglerValue = (float)Math.Cos(WigglerSineCounter) * WigglerCounter;
        }

        // Wiggler.Start (Monocle/Wiggler.cs:65-87) with the default StartZero = false.
        public void StartWiggler()
        {
            WigglerCounter = 1f;
            WigglerSineCounter = 0f;
            WigglerValue = 1f;
            WigglerActive = true;
        }

        // CS07_Credits.cs:44-48 `Level.Entities.FindFirst<SpeedrunTimerDisplay>()?.RemoveSelf()`.
        public void RemoveSelf()
        {
            Removed = true;
        }

        static float Approach(float val, float target, float maxMove)
        {
            if (val <= target) return Math.Min(val + maxMove, target);
            return Math.Max(val - maxMove, target);
        }

        static float CubeIn(float t)
        {
            return t * t * t;
        }

        static Vector4 Hex(string value) => new Vector4(
            Convert.ToInt32(value.Substring(0, 2), 16),
            Convert.ToInt32(value.Substring(2, 2), 16),
            Convert.ToInt32(value.Substring(4, 2), 16), 255f) / 255f;

        static Vector4 Scale(Vector4 color, float scale) =>
            global::Celeste.Graphics.Display.Colors.ColorMath.Scale(color, scale);
    }
}

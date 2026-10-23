using Celeste.Core.Display;
using Celeste.Core.Components;
using Celeste.Game.Controls.Source;
using System;
using System.Numerics;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Input.Gameplay;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;
using Celeste.Simulation;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Game.Entities.Lookouts
{
    public static class LookoutHudPresentation
    {
        public static void Render(ILookoutHudState state, ISourceRenderContext context) =>
            Render(state, context, PackedColor.White);

        public static void Update(ILookoutHudState state)
        {
            OriginalLevelSceneRoot level = (OriginalLevelSceneRoot)state.Entity.Scene;
            Vector2 position = level.Camera.Position;
            IntRect bounds = level.Bounds;
            int num = 320;
            int num2 = 180;
            bool flag = Blocked(state, new IntRect((int)(position.X - 8f), (int)position.Y, num, num2));
            bool flag2 = Blocked(state, new IntRect((int)(position.X + 8f), (int)position.Y, num, num2));
            bool flag3 = (state.TrackMode && state.TrackPercent >= 1f) ||
                         Blocked(state, new IntRect((int)position.X, (int)(position.Y - 8f), num, num2));
            bool flag4 = (state.TrackMode && state.TrackPercent <= 0f) ||
                         Blocked(state, new IntRect((int)position.X, (int)(position.Y + 8f), num, num2));
            state.Left = ScalarMath.Approach(state.Left, (!flag && position.X > (float)(bounds.Left + 2)) ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Right = ScalarMath.Approach(state.Right,
                (!flag2 && position.X + (float)num < (float)(bounds.Right - 2)) ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Up = ScalarMath.Approach(state.Up, (!flag3 && position.Y > (float)(bounds.Top + 2)) ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Down = ScalarMath.Approach(state.Down,
                (!flag4 && position.Y + (float)num2 < (float)(bounds.Bottom - 2)) ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Aim = ((IOriginalGameInputProcessEnvironment)state.Process.EngineContext).InputSource.Aim.Value;
            if (state.Aim.X < 0f)
            {
                state.MultLeft = ScalarMath.Approach(state.MultLeft, 0f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerLeft += state.Process.EngineContext.DeltaTime * 12f;
            }
            else
            {
                state.MultLeft = ScalarMath.Approach(state.MultLeft, 1f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerLeft += state.Process.EngineContext.DeltaTime * 6f;
            }

            if (state.Aim.X > 0f)
            {
                state.MultRight = ScalarMath.Approach(state.MultRight, 0f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerRight += state.Process.EngineContext.DeltaTime * 12f;
            }
            else
            {
                state.MultRight = ScalarMath.Approach(state.MultRight, 1f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerRight += state.Process.EngineContext.DeltaTime * 6f;
            }

            if (state.Aim.Y < 0f)
            {
                state.MultUp = ScalarMath.Approach(state.MultUp, 0f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerUp += state.Process.EngineContext.DeltaTime * 12f;
            }
            else
            {
                state.MultUp = ScalarMath.Approach(state.MultUp, 1f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerUp += state.Process.EngineContext.DeltaTime * 6f;
            }

            if (state.Aim.Y > 0f)
            {
                state.MultDown = ScalarMath.Approach(state.MultDown, 0f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerDown += state.Process.EngineContext.DeltaTime * 12f;
            }
            else
            {
                state.MultDown = ScalarMath.Approach(state.MultDown, 1f, state.Process.EngineContext.DeltaTime * 2f,
                    state.Process.ExtremaArithmetic);
                state.TimerDown += state.Process.EngineContext.DeltaTime * 6f;
            }

            state.UpdateComponents();
        }

        public static void Render(ILookoutHudState state, ISourceRenderContext context, PackedColor paddingColor)
        {
            OriginalLevelSceneRoot level = state.Entity.Scene as OriginalLevelSceneRoot;
            float num = state.Process.EasingArithmetic.CubeInOut(state.Easer);
            PackedColor color = paddingColor * num;
            int num2 = (int)(80f * num);
            int num3 = (int)(80f * num * 0.5625f);
            int num4 = 8;
            if (level.FrozenOrPaused || level.RetryPlayerCorpse != null)
            {
                color *= 0.25f;
            }

            SourcePrimitiveDrawing.Rect(context, state.Entity, num2, num3, 1920 - num2 * 2 - num4, num4, color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, num2, num3 + num4, num4 + 2, 1080 - num3 * 2 - num4,
                color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, 1920 - num2 - num4 - 2, num3, num4 + 2,
                1080 - num3 * 2 - num4,
                color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, num2 + num4, 1080 - num3 - num4, 1920 - num2 * 2 - num4,
                num4,
                color);
            if (level.FrozenOrPaused || level.RetryPlayerCorpse != null)
            {
                return;
            }

            AtlasEntry mTexture = state.Process.GuiAtlas.Entries["towerarrow"];
            float y = (float)num3 * state.Up -
                      (float)(Math.Sin(state.TimerUp) * 18.0 *
                              (double)ScalarMath.Lerp(0.5f, 1f, state.MultUp, state.Process.ScalarArithmetic)) -
                      (1f - state.MultUp) * 12f;
            DrawCentered(state, context, mTexture, new Vector2(960f, y), color * state.Up, 1f, (float)Math.PI / 2f);
            float y2 = 1080f - (float)num3 * state.Down +
                       (float)(Math.Sin(state.TimerDown) * 18.0 *
                               (double)ScalarMath.Lerp(0.5f, 1f, state.MultDown, state.Process.ScalarArithmetic)) +
                       (1f - state.MultDown) * 12f;
            DrawCentered(state, context, mTexture, new Vector2(960f, y2), color * state.Down, 1f, 4.712389f);
            if (!state.TrackMode && !state.OnlyY)
            {
                float num5 = state.Left;
                float num6 = state.MultLeft;
                float num7 = state.TimerLeft;
                float num8 = state.Right;
                float num9 = state.MultRight;
                float num10 = state.TimerRight;
                if (state.Process.CurrentSave != null && state.Process.CurrentSave.Assists.MirrorMode)
                {
                    num5 = state.Right;
                    num6 = state.MultRight;
                    num7 = state.TimerRight;
                    num8 = state.Left;
                    num9 = state.MultLeft;
                    num10 = state.TimerLeft;
                }

                float x = (float)num2 * num5 -
                          (float)(Math.Sin(num7) * 18.0 *
                                  (double)ScalarMath.Lerp(0.5f, 1f, num6, state.Process.ScalarArithmetic)) -
                          (1f - num6) * 12f;
                DrawCentered(state, context, mTexture, new Vector2(x, 540f), color * num5);
                float x2 = 1920f - (float)num2 * num8 +
                           (float)(Math.Sin(num10) * 18.0 *
                                   (double)ScalarMath.Lerp(0.5f, 1f, num9, state.Process.ScalarArithmetic)) +
                           (1f - num9) * 12f;
                DrawCentered(state, context, mTexture, new Vector2(x2, 540f), color * num8, 1f, (float)Math.PI);
            }
            else if (state.TrackMode)
            {
                int num11 = 1080 - num3 * 2 - 128 - 64;
                int num12 = 1920 - num2 - 64;
                float num13 = (float)(1080 - num11) / 2f + 32f;
                SourcePrimitiveDrawing.Rect(context, state.Entity, num12 - 7, num13 + 7f, 14f, num11 - 14,
                    PackedColor.Black * num);
                DrawJustified(state, context, state.HalfDot, new Vector2(num12, num13 + 7f), new Vector2(0.5f, 1f),
                    PackedColor.Black * num);
                DrawJustified(state, context, state.HalfDot, new Vector2(num12, num13 + (float)num11 - 7f),
                    new Vector2(0.5f, 1f),
                    PackedColor.Black * num, new Vector2(1f, -1f));
                DrawCentered(state, context, state.Process.GuiAtlas.Entries["lookout/cursor"],
                    new Vector2(num12, num13 + (1f - state.TrackPercent) * (float)num11), PackedColor.White * num, 1f);
                DrawCentered(state, context, state.Process.GuiAtlas.Entries["lookout/summit"],
                    new Vector2(num12, num13 - 64f),
                    PackedColor.White * num, 0.65f);
            }
        }

        private static bool Blocked(ILookoutHudState state, IntRect rectangle)
            => SourceSceneCollisionQueries.First<object>(rectangle,
                   ((ISourceScene)state.Entity.Scene).SourceScene.Entities
                   .GetTrackedEntities("Celeste.LookoutBlocker")) !=
               null;

        private static void DrawCentered(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            PackedColor color, float scale = 1f, float rotation = 0f)
            => SourceAtlasDrawing.DrawCentered(context, state.Entity, texture, position, color, scale, rotation);

        private static void DrawJustified(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            Vector2 justify, PackedColor color)
            => SourceAtlasDrawing.DrawJustified(context, state.Entity, texture, position, justify, color);

        private static void DrawJustified(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            Vector2 justify, PackedColor color, Vector2 scale)
            => SourceAtlasDrawing.DrawJustified(context, state.Entity, texture, position, justify, color, scale);
    }
}

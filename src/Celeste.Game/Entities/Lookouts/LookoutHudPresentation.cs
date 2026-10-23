using System;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Rendering;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Collision;

namespace Celeste.Game.Entities.Lookouts
{
    public static class LookoutHudPresentation
    {
        public static void Render(ILookoutHudState state, ISourceRenderContext context)
        {
            Render(state, context, PackedColor.White);
        }

        public static void Update(ILookoutHudState state)
        {
            var level = (OriginalLevelSceneRoot)state.Entity.Scene;
            var position = level.Camera.Position;
            var bounds = level.Bounds;
            var num = 320;
            var num2 = 180;
            var flag = Blocked(state, new((int)(position.X - 8f), (int)position.Y, num, num2));
            var flag2 = Blocked(state, new((int)(position.X + 8f), (int)position.Y, num, num2));
            var flag3 = (state.TrackMode && state.TrackPercent >= 1f) ||
                        Blocked(state, new((int)position.X, (int)(position.Y - 8f), num, num2));
            var flag4 = (state.TrackMode && state.TrackPercent <= 0f) ||
                        Blocked(state, new((int)position.X, (int)(position.Y + 8f), num, num2));
            state.Left = ScalarMath.Approach(state.Left, !flag && position.X > bounds.Left + 2 ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Right = ScalarMath.Approach(state.Right,
                !flag2 && position.X + num < bounds.Right - 2 ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Up = ScalarMath.Approach(state.Up, !flag3 && position.Y > bounds.Top + 2 ? 1 : 0,
                state.Process.EngineContext.DeltaTime * 8f, state.Process.ExtremaArithmetic);
            state.Down = ScalarMath.Approach(state.Down,
                !flag4 && position.Y + num2 < bounds.Bottom - 2 ? 1 : 0,
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
            var level = state.Entity.Scene as OriginalLevelSceneRoot;
            var num = state.Process.EasingArithmetic.CubeInOut(state.Easer);
            var color = paddingColor * num;
            var num2 = (int)(80f * num);
            var num3 = (int)(80f * num * 0.5625f);
            var num4 = 8;
            if (level.FrozenOrPaused || level.RetryPlayerCorpse != null) color *= 0.25f;

            SourcePrimitiveDrawing.Rect(context, state.Entity, num2, num3, 1920 - num2 * 2 - num4, num4, color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, num2, num3 + num4, num4 + 2, 1080 - num3 * 2 - num4,
                color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, 1920 - num2 - num4 - 2, num3, num4 + 2,
                1080 - num3 * 2 - num4,
                color);
            SourcePrimitiveDrawing.Rect(context, state.Entity, num2 + num4, 1080 - num3 - num4, 1920 - num2 * 2 - num4,
                num4,
                color);
            if (level.FrozenOrPaused || level.RetryPlayerCorpse != null) return;

            var mTexture = state.Process.GuiAtlas.Entries["towerarrow"];
            var y = num3 * state.Up -
                    (float)(Math.Sin(state.TimerUp) * 18.0 *
                            ScalarMath.Lerp(0.5f, 1f, state.MultUp, state.Process.ScalarArithmetic)) -
                    (1f - state.MultUp) * 12f;
            DrawCentered(state, context, mTexture, new(960f, y), color * state.Up, 1f, (float)Math.PI / 2f);
            var y2 = 1080f - num3 * state.Down +
                     (float)(Math.Sin(state.TimerDown) * 18.0 *
                             ScalarMath.Lerp(0.5f, 1f, state.MultDown, state.Process.ScalarArithmetic)) +
                     (1f - state.MultDown) * 12f;
            DrawCentered(state, context, mTexture, new(960f, y2), color * state.Down, 1f, 4.712389f);
            if (!state.TrackMode && !state.OnlyY)
            {
                var num5 = state.Left;
                var num6 = state.MultLeft;
                var num7 = state.TimerLeft;
                var num8 = state.Right;
                var num9 = state.MultRight;
                var num10 = state.TimerRight;
                if (state.Process.CurrentSave != null && state.Process.CurrentSave.Assists.MirrorMode)
                {
                    num5 = state.Right;
                    num6 = state.MultRight;
                    num7 = state.TimerRight;
                    num8 = state.Left;
                    num9 = state.MultLeft;
                    num10 = state.TimerLeft;
                }

                var x = num2 * num5 -
                        (float)(Math.Sin(num7) * 18.0 *
                                ScalarMath.Lerp(0.5f, 1f, num6, state.Process.ScalarArithmetic)) -
                        (1f - num6) * 12f;
                DrawCentered(state, context, mTexture, new(x, 540f), color * num5);
                var x2 = 1920f - num2 * num8 +
                         (float)(Math.Sin(num10) * 18.0 *
                                 ScalarMath.Lerp(0.5f, 1f, num9, state.Process.ScalarArithmetic)) +
                         (1f - num9) * 12f;
                DrawCentered(state, context, mTexture, new(x2, 540f), color * num8, 1f, (float)Math.PI);
            }
            else if (state.TrackMode)
            {
                var num11 = 1080 - num3 * 2 - 128 - 64;
                var num12 = 1920 - num2 - 64;
                var num13 = (1080 - num11) / 2f + 32f;
                SourcePrimitiveDrawing.Rect(context, state.Entity, num12 - 7, num13 + 7f, 14f, num11 - 14,
                    PackedColor.Black * num);
                DrawJustified(state, context, state.HalfDot, new(num12, num13 + 7f), new(0.5f, 1f),
                    PackedColor.Black * num);
                DrawJustified(state, context, state.HalfDot, new(num12, num13 + num11 - 7f),
                    new(0.5f, 1f),
                    PackedColor.Black * num, new(1f, -1f));
                DrawCentered(state, context, state.Process.GuiAtlas.Entries["lookout/cursor"],
                    new(num12, num13 + (1f - state.TrackPercent) * num11), PackedColor.White * num);
                DrawCentered(state, context, state.Process.GuiAtlas.Entries["lookout/summit"],
                    new(num12, num13 - 64f),
                    PackedColor.White * num, 0.65f);
            }
        }

        private static bool Blocked(ILookoutHudState state, IntRect rectangle)
        {
            return SourceSceneCollisionQueries.First<object>(rectangle,
                       ((ISourceScene)state.Entity.Scene).SourceScene.Entities
                       .GetTrackedEntities("Celeste.LookoutBlocker")) !=
                   null;
        }

        private static void DrawCentered(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            PackedColor color, float scale = 1f, float rotation = 0f)
        {
            SourceAtlasDrawing.DrawCentered(context, state.Entity, texture, position, color, scale, rotation);
        }

        private static void DrawJustified(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            Vector2 justify, PackedColor color)
        {
            SourceAtlasDrawing.DrawJustified(context, state.Entity, texture, position, justify, color);
        }

        private static void DrawJustified(ILookoutHudState state, ISourceRenderContext context, AtlasEntry texture,
            Vector2 position,
            Vector2 justify, PackedColor color, Vector2 scale)
        {
            SourceAtlasDrawing.DrawJustified(context, state.Entity, texture, position, justify, color, scale);
        }
    }
}

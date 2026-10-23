using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static class ZipMoverBodyDrawing
    {
        public static void Draw(ISourceRenderContext context, SourceSolidEntityState solid, float percent,
            List<AtlasEntry> innerCogs, AtlasEntry[,] edges, AtlasEntry temp, float inset, PackedColor tint)
        {
            var unusedScale = Vector2.Zero;
            DrawCore<UnscaledProjection>(context, solid, percent, innerCogs, edges, temp, inset, tint, ref unusedScale);
        }

        public static void DrawScaled(ISourceRenderContext context, SourceSolidEntityState solid, float percent,
            List<AtlasEntry> innerCogs, AtlasEntry[,] edges, AtlasEntry temp, float inset, PackedColor tint,
            ref Vector2 scale)
        {
            DrawCore<ScaledProjection>(context, solid, percent, innerCogs, edges, temp, inset, tint, ref scale);
        }

        private static void DrawCore<TProjection>(ISourceRenderContext context, SourceSolidEntityState solid,
            float percent, List<AtlasEntry> innerCogs, AtlasEntry[,] edges, AtlasEntry temp, float inset,
            PackedColor tint, ref Vector2 scale) where TProjection : struct, IBodyProjection
        {
            TProjection projection = default;
            projection.Fill(context, solid, inset, ref scale);
            var halfTint = tint * .5f;
            var num = 1;
            var num2 = 0f;
            var count = innerCogs.Count;
            for (var i = 4; i <= solid.Height - 4f; i += 8)
            {
                var num3 = num;
                for (var j = 4; j <= solid.Width - 4f; j += 8)
                {
                    var index = ZipMoverDrawing.CogFrameIndex(num2, num, percent, count);
                    var mTexture = innerCogs[index];
                    mTexture = ZipMoverDrawing.ClipInnerCog(mTexture, mTexture.FrameWidth, mTexture.FrameHeight,
                        j <= 4, j > 4 && j >= solid.Width - 4f,
                        i <= 4, i > 4 && i >= solid.Height - 4f, temp, out var zero);
                    projection.Inner(context, solid, mTexture, j, i, zero, num < 0 ? halfTint : tint, ref scale);
                    num = -num;
                    num2 += (float)Math.PI / 3f;
                }

                if (num3 == num) num = -num;
            }

            for (var k = 0; k < solid.Width / 8f; k++)
            for (var l = 0; l < solid.Height / 8f; l++)
            {
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var num4 = k != 0 ? k != solid.Width / 8f - 1f ? 1 : 2 : 0;
                // ReSharper disable once CompareOfFloatsByEqualityOperator
                var num5 = l != 0 ? l != solid.Height / 8f - 1f ? 1 : 2 : 0;
                if (num4 != 1 || num5 != 1) projection.Edge(context, solid, edges[num4, num5], k, l, tint, ref scale);
            }
        }

        private interface IBodyProjection
        {
            void Fill(ISourceRenderContext context, SourceSolidEntityState solid, float inset, ref Vector2 scale);

            void Inner(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture, int x, int y,
                Vector2 offset, PackedColor tint, ref Vector2 scale);

            void Edge(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture, int x, int y,
                PackedColor tint, ref Vector2 scale);
        }

        private readonly struct UnscaledProjection : IBodyProjection
        {
            public void Fill(ISourceRenderContext context, SourceSolidEntityState solid, float inset, ref Vector2 scale)
            {
                SourcePrimitiveDrawing.Rect(context, solid, solid.X + inset, solid.Y + inset, solid.Width - inset * 2f,
                    solid.Height - inset * 2f, PackedColor.Black);
            }

            public void Inner(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture,
                int x, int y, Vector2 offset, PackedColor tint, ref Vector2 scale)
            {
                SourceAtlasDrawing.DrawCentered(context, solid, texture,
                    SourceVector2Math.Add(SourceVector2Math.Add(solid.Position, new(x, y)), offset), tint);
            }

            public void Edge(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture,
                int x, int y, PackedColor tint, ref Vector2 scale)
            {
                SourceAtlasDrawing.Draw(context, solid, texture,
                    new(solid.X + x * 8, solid.Y + y * 8),
                    Vector2.Zero, tint, Vector2.One);
            }
        }

        private readonly struct ScaledProjection : IBodyProjection
        {
            public void Fill(ISourceRenderContext context, SourceSolidEntityState solid, float inset, ref Vector2 scale)
            {
                SourcePrimitiveDrawing.Rect(context, solid,
                    (int)(solid.Center.X + (solid.X + inset - solid.Center.X) * scale.X),
                    (int)(solid.Center.Y + (solid.Y + inset - solid.Center.Y) * scale.Y),
                    (int)((solid.Width - inset * 2f) * scale.X),
                    (int)((solid.Height - inset * 2f) * scale.Y), PackedColor.Black);
            }

            public void Inner(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture,
                int x, int y, Vector2 offset, PackedColor tint, ref Vector2 scale)
            {
                var position = SourceVector2Math.Add(solid.Center,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(
                        SourceVector2Math.Add(SourceVector2Math.Add(solid.Position, new(x, y)), offset),
                        solid.Center), scale));
                SourceAtlasDrawing.DrawCentered(context, solid, texture, position, tint, scale);
            }

            public void Edge(ISourceRenderContext context, SourceSolidEntityState solid, AtlasEntry texture,
                int x, int y, PackedColor tint, ref Vector2 scale)
            {
                var position = SourceVector2Math.Add(solid.Center,
                    SourceVector2Math.Multiply(SourceVector2Math.Subtract(
                        new(solid.X + x * 8 + 4, solid.Y + y * 8 + 4), solid.Center), scale));
                SourceAtlasDrawing.DrawCentered(context, solid, texture, position, tint, scale);
            }
        }
    }
}

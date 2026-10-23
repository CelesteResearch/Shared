using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Rendering;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static partial class ZipMoverDrawing
    {
        public static void Body(ISourceRenderContext context, SourceSolidEntityState solid, float percent,
            List<AtlasEntry> innerCogs, AtlasEntry[,] edges, AtlasEntry temp, float inset)
        {
            ZipMoverBodyDrawing.Draw(context, solid, percent, innerCogs, edges, temp, inset, PackedColor.White);
        }

        public static void ScrapeParticles(SourceSolidEntityState solid, ISourceEngineContext engine, Vector2 to)
        {
            if (!((ISourceScene)solid.Scene).SourceScene.Clock.OnInterval(0.03f, engine)) return;

            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var flag = to.Y != solid.ExactPosition.Y;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            var flag2 = to.X != solid.ExactPosition.X;
            if (flag && !flag2)
            {
                var num = Math.Sign(to.Y - solid.ExactPosition.Y);
                var vector = num != 1 ? solid.TopLeft : solid.BottomLeft;
                var num2 = 4;
                if (num == 1) num2 = Math.Min((int)solid.Height - 12, 20);

                var num3 = (int)solid.Height;
                if (num == -1) num3 = Math.Max(16, (int)solid.Height - 16);

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector, new(-2f, num * -2))))
                    for (var i = num2; i < num3; i += 8)
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopLeft, new(0f, i + num * 2f)),
                            num == 1 ? -(float)Math.PI / 4f : (float)Math.PI / 4f);

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector, new(solid.Width + 2f, num * -2))))
                    for (var j = num2; j < num3; j += 8)
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopRight, new(-1f, j + num * 2f)),
                            num == 1 ? (float)Math.PI * -3f / 4f : (float)Math.PI * 3f / 4f);
            }
            else
            {
                if (!flag2 || flag) return;

                var num4 = Math.Sign(to.X - solid.ExactPosition.X);
                var vector2 = num4 != 1 ? solid.TopLeft : solid.TopRight;
                var num5 = 4;
                if (num4 == 1) num5 = Math.Min((int)solid.Width - 12, 20);

                var num6 = (int)solid.Width;
                if (num4 == -1) num6 = Math.Max(16, (int)solid.Width - 16);

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector2, new(num4 * -2, -2f))))
                    for (var k = num5; k < num6; k += 8)
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopLeft, new(k + num4 * 2f, -1f)),
                            num4 == 1 ? (float)Math.PI * 3f / 4f : (float)Math.PI / 4f);

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector2, new(num4 * -2, solid.Height + 2f))))
                    for (var l = num5; l < num6; l += 8)
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.BottomLeft, new(l + num4 * 2f, 0f)),
                            num4 == 1 ? (float)Math.PI * -3f / 4f : -(float)Math.PI / 4f);
            }
        }

        public static void Ropes(ISourceRenderContext context, SceneEntityState owner, ISourceEngineContext engine,
            Vector2 from, Vector2 to, AtlasEntry cog, float percent, PackedColor ropeColor, PackedColor ropeLightColor,
            Vector2 offset, PackedColor? colorOverride = null)
        {
            var vector =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                    SourceVector2Math.Subtract(to, from));
            var vector2 = SourceVector2Math.Multiply(Vector2Geometry.Perpendicular(vector), 3f);
            var vector3 =
                SourceVector2Math.Multiply(SourceVector2Math.Negate(Vector2Geometry.Perpendicular(vector)), 4f);
            var rotation = percent * (float)Math.PI * 2f;
            RopeLines(context, owner, ((ISourceVectorEnvironment)engine).VectorArithmetic,
                SourceVector2Math.Add(from, vector2), SourceVector2Math.Add(from, vector3),
                SourceVector2Math.Add(to, vector2), SourceVector2Math.Add(to, vector3),
                vector, Vector2Geometry.Perpendicular(vector),
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Length(SourceVector2Math.Subtract(to, from)),
                percent * (float)Math.PI * 8f, offset, ropeColor, ropeLightColor, colorOverride);

            SourceAtlasDrawing.DrawCentered(context, owner, cog, SourceVector2Math.Add(from, offset),
                colorOverride.HasValue ? colorOverride.Value : PackedColor.White, 1f, rotation);
            SourceAtlasDrawing.DrawCentered(context, owner, cog, SourceVector2Math.Add(to, offset),
                colorOverride.HasValue ? colorOverride.Value : PackedColor.White, 1f, rotation);
        }

        public static void Sparks(SceneEntityState owner, ISourceEngineContext engine, Vector2 from, Vector2 to,
            Vector2 sparkAdd, float sparkDirFromA, float sparkDirFromB, float sparkDirToA, float sparkDirToB)
        {
            Sparks(owner, engine, from, to, sparkAdd, sparkDirFromA, sparkDirFromB, sparkDirToA, sparkDirToB, null);
        }

        private static float Mod(float x, float m)
        {
            return (x % m + m) % m;
        }
    }
}

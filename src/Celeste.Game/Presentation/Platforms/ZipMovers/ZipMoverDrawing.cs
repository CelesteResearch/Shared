using Celeste.Core.Display;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Components.Timing;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Randomness;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Simulation.Presentation.PostProcessing.Bloom;
using Celeste.Simulation.Audio.Sources;
using Celeste.Graphics.Animation;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Controls.Source;

namespace Celeste.Game.Presentation.Platforms.ZipMovers
{
    public static partial class ZipMoverDrawing
    {
        public static void Body(ISourceRenderContext context, SourceSolidEntityState solid, float percent,
            List<AtlasEntry> innerCogs, AtlasEntry[,] edges, AtlasEntry temp, float inset)
            => ZipMoverBodyDrawing.Draw(context, solid, percent, innerCogs, edges, temp, inset, PackedColor.White);

        public static void ScrapeParticles(SourceSolidEntityState solid, ISourceEngineContext engine, Vector2 to)
        {
            if (!((ISourceScene)solid.Scene).SourceScene.Clock.OnInterval(0.03f, engine))
            {
                return;
            }

            bool flag = to.Y != solid.ExactPosition.Y;
            bool flag2 = to.X != solid.ExactPosition.X;
            if (flag && !flag2)
            {
                int num = Math.Sign(to.Y - solid.ExactPosition.Y);
                Vector2 vector = ((num != 1) ? solid.TopLeft : solid.BottomLeft);
                int num2 = 4;
                if (num == 1)
                {
                    num2 = Math.Min((int)solid.Height - 12, 20);
                }

                int num3 = (int)solid.Height;
                if (num == -1)
                {
                    num3 = Math.Max(16, (int)solid.Height - 16);
                }

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector, new Vector2(-2f, num * -2))))
                {
                    for (int i = num2; i < num3; i += 8)
                    {
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopLeft, new Vector2(0f, (float)i + (float)num * 2f)),
                            (num == 1) ? (-(float)Math.PI / 4f) : ((float)Math.PI / 4f));
                    }
                }

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector, new Vector2(solid.Width + 2f, num * -2))))
                {
                    for (int j = num2; j < num3; j += 8)
                    {
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopRight, new Vector2(-1f, (float)j + (float)num * 2f)),
                            (num == 1) ? ((float)Math.PI * -3f / 4f) : ((float)Math.PI * 3f / 4f));
                    }
                }
            }
            else
            {
                if (!flag2 || flag)
                {
                    return;
                }

                int num4 = Math.Sign(to.X - solid.ExactPosition.X);
                Vector2 vector2 = ((num4 != 1) ? solid.TopLeft : solid.TopRight);
                int num5 = 4;
                if (num4 == 1)
                {
                    num5 = Math.Min((int)solid.Width - 12, 20);
                }

                int num6 = (int)solid.Width;
                if (num4 == -1)
                {
                    num6 = Math.Max(16, (int)solid.Width - 16);
                }

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector2, new Vector2(num4 * -2, -2f))))
                {
                    for (int k = num5; k < num6; k += 8)
                    {
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.TopLeft, new Vector2((float)k + (float)num4 * 2f, -1f)),
                            (num4 == 1) ? ((float)Math.PI * 3f / 4f) : ((float)Math.PI / 4f));
                    }
                }

                if (SourceSceneCollision.CheckPoint(((ISourceScene)solid.Scene).SourceScene.Entities, "Celeste.Solid",
                        SourceVector2Math.Add(vector2, new Vector2(num4 * -2, solid.Height + 2f))))
                {
                    for (int l = num5; l < num6; l += 8)
                    {
                        (solid.Scene as OriginalLevelSceneRoot).ParticlesFG.Emit(
                            ((IOriginalGameplayProcess)engine).ParticleTypes.ZipMover.P_Scrape,
                            SourceVector2Math.Add(solid.BottomLeft, new Vector2((float)l + (float)num4 * 2f, 0f)),
                            (num4 == 1) ? ((float)Math.PI * -3f / 4f) : (-(float)Math.PI / 4f));
                    }
                }
            }
        }

        public static void Ropes(ISourceRenderContext context, SceneEntityState owner, ISourceEngineContext engine,
            Vector2 from, Vector2 to, AtlasEntry cog, float percent, PackedColor ropeColor, PackedColor ropeLightColor,
            Vector2 offset, PackedColor? colorOverride = null)
        {
            Vector2 vector =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.SafeNormalize(
                    SourceVector2Math.Subtract(to, from));
            Vector2 vector2 = SourceVector2Math.Multiply(Vector2Geometry.Perpendicular(vector), 3f);
            Vector2 vector3 =
                SourceVector2Math.Multiply(SourceVector2Math.Negate(Vector2Geometry.Perpendicular(vector)), 4f);
            float rotation = percent * (float)Math.PI * 2f;
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

        private static float Mod(float x, float m) => (x % m + m) % m;
    }
}

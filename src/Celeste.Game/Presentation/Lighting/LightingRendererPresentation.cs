using System;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Graphics.Content;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;

namespace Celeste.Game.Presentation.Lighting
{
    public class LightingRendererPresentation : SceneRenderer
    {
        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 28)]
        private struct VertexPositionColorMaskTexture : ISourceVertexType
        {
            public Vector3 Position;

            public PackedColor Color;

            public PackedColor Mask;

            public Vector2 Texcoord;

            public static readonly SourceVertexDeclaration VertexDeclaration = new(
                new SourceVertexElement(0, SourceVertexElementFormat.Vector3, SourceVertexElementUsage.Position, 0),
                new SourceVertexElement(12, SourceVertexElementFormat.Color, SourceVertexElementUsage.Color, 0),
                new SourceVertexElement(16, SourceVertexElementFormat.Color, SourceVertexElementUsage.Color, 1),
                new SourceVertexElement(20, SourceVertexElementFormat.Vector2,
                    SourceVertexElementUsage.TextureCoordinate,
                    0));

            SourceVertexDeclaration ISourceVertexType.VertexDeclaration => VertexDeclaration;
        }

        private readonly ISourceEngineContext engine;
        private SourceGraphicsDevice Device => ((ISourceGraphicsDeviceEnvironment)engine).GraphicsDevice;

        private OriginalGameGraphicsResources Graphics =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)engine).GameGraphics;

        private SourceDrawState Draw => ((ISourceDrawScope)engine).Draw;

        private LightingRendererProcessState Process =>
            ((IOriginalLightingRendererEnvironment)engine).LightingRendererProcess;

        public const int TextureSize = 1024;

        public const int TextureSplit = 4;

        public const int Channels = 4;

        public const int Padding = 8;

        public const int CircleSegments = 20;

        private const int Cells = 16;

        private const int MaxLights = 64;

        private const int Radius = 128;

        private const int LightRadius = 120;

        public PackedColor BaseColor = PackedColor.Black;

        public float Alpha = 0.1f;

        private readonly SourceVertexPositionColor[] verts = new SourceVertexPositionColor[11520];

        private readonly VertexPositionColorMaskTexture[] resultVerts = new VertexPositionColorMaskTexture[384];

        private readonly int[] indices = new int[11520];

        private int vertexCount;

        private int indexCount;

        private readonly VertexLightState[] lights;

        private VertexLightState spotlight;

        private bool inSpotlight;

        private float nonSpotlightAlphaMultiplier = 1f;

        private readonly Vector3[] angles = new Vector3[20];

        public LightingRendererPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            lights = new VertexLightState[64];
            for (var i = 0; i < 20; i++)
                angles[i] = new(Vector2Geometry.AngleToVector(i / 20f * ((float)Math.PI * 2f), 1f), 0f);
        }

        public VertexLightState SetSpotlight(VertexLightState light)
        {
            spotlight = light;
            inSpotlight = true;
            return light;
        }

        public void UnsetSpotlight()
        {
            inSpotlight = false;
        }

        public override void Update(object scene)
        {
            nonSpotlightAlphaMultiplier = ScalarMath.Approach(nonSpotlightAlphaMultiplier, inSpotlight ? 0f : 1f,
                engine.DeltaTime * 2f,
                ((ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update(scene);
        }

        public override void BeforeRender(object scene)
        {
            var level = scene as OriginalLevelSceneRoot;
            var camera = level.Camera;
            for (var i = 0; i < 64; i++)
                if (lights[i] != null && ((ISourceEntityScene)lights[i].Entity).Scene != scene)
                {
                    lights[i].Index = -1;
                    lights[i] = null;
                }

            foreach (VertexLightState component in ((ISourceTrackedComponents)((ISourceComponentIndexScene)scene)
                         .ComponentIndex).GetTrackedComponents("Celeste.VertexLight"))
                if (component.Entity != null && ((ISourceEntityVisibility)component.Entity).Visible &&
                    component.Visible &&
                    component.Alpha > 0f && component.Color.A > 0 &&
                    component.Center.X + component.EndRadius > camera.X &&
                    component.Center.Y + component.EndRadius > camera.Y &&
                    component.Center.X - component.EndRadius < camera.X + 320f &&
                    component.Center.Y - component.EndRadius < camera.Y + 180f)
                {
                    if (component.Index < 0)
                    {
                        component.Dirty = true;
                        for (var j = 0; j < 64; j++)
                            if (lights[j] == null)
                            {
                                lights[j] = component;
                                component.Index = j;
                                break;
                            }
                    }

                    if (component.LastPosition != component.Position ||
                        component.LastEntityPosition != ((ISourceEntityPosition)component.Entity).Position ||
                        component.Dirty)
                    {
                        component.LastPosition = component.Position;
                        component.InSolid = false;
                        // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
                        foreach (var item in SourceSceneCollision.AllPoint<SourceSolidEntityState>(
                                     level.Scheduler.Entities, "Celeste.Solid", component.Center))
                            if (item.DisableLightsInside)
                            {
                                component.InSolid = true;
                                break;
                            }

                        if (!component.InSolid) component.LastNonSolidPosition = component.Center;

                        if (component.InSolid && !component.Started) component.InSolidAlphaMultiplier = 0f;
                    }

                    if (((ISourceEntityPosition)component.Entity).Position != component.LastEntityPosition)
                    {
                        component.Dirty = true;
                        component.LastEntityPosition = ((ISourceEntityPosition)component.Entity).Position;
                    }

                    component.Started = true;
                }
                else if (component.Index >= 0)
                {
                    lights[component.Index] = null;
                    component.Index = -1;
                    component.Started = false;
                }

            Device.SetRenderTarget(Graphics.Buffers.LightBuffer.Target);
            Device.RasterizerState = SourceRasterizerState.CullNone;
            var matrix = SourceMatrixMath.Multiply(
                SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(0.0009765625f),
                    SourceMatrixMath.CreateScale(2f, -2f, 1f)), SourceMatrixMath.CreateTranslation(-1f, 1f, 0f));
            ClearDirtyLights(matrix);
            DrawLightGradients(matrix);
            DrawLightOccluders(matrix, level);
            Device.SetRenderTarget(Graphics.Buffers.Light.Target);
            Device.Clear(BaseColor);
            Device.Textures[0] = Graphics.Buffers.LightBuffer.Target;
            StartDrawingPrimitives();
            for (var k = 0; k < 64; k++)
            {
                var vertexLight2 = lights[k];
                if (vertexLight2 == null) continue;

                vertexLight2.Dirty = false;
                var num = vertexLight2.Alpha * vertexLight2.InSolidAlphaMultiplier;
                if (nonSpotlightAlphaMultiplier < 1f && vertexLight2 != spotlight) num *= nonSpotlightAlphaMultiplier;

                if (num > 0f && vertexLight2.Color.A > 0 && vertexLight2.EndRadius >= 2f)
                {
                    var num2 = 128;
                    while (vertexLight2.EndRadius <= num2 / 2) num2 /= 2;

                    DrawLight(k, vertexLight2.InSolid ? vertexLight2.LastNonSolidPosition : vertexLight2.Center,
                        vertexLight2.Color * num, num2);
                }
            }

            if (vertexCount > 0)
                SourcePrimitiveGraphics.DrawIndexedVertices(
                    ((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    camera.Matrix, resultVerts, vertexCount, indices, indexCount / 3, Graphics.FxLighting,
                    SourceBlendState.Additive);

            GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)engine, Graphics.Buffers.Light.Target,
                Graphics.Buffers.TempA, Graphics.Buffers.Light);
        }

        private void ClearDirtyLights(Matrix4x4 matrix)
        {
            StartDrawingPrimitives();
            for (var i = 0; i < 64; i++)
            {
                var vertexLight = lights[i];
                if (vertexLight != null && vertexLight.Dirty) SetClear(i);
            }

            if (vertexCount <= 0) return;

            Device.BlendState = Process.OccludeBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (var pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private void DrawLightGradients(Matrix4x4 matrix)
        {
            StartDrawingPrimitives();
            var num = 0;
            for (var i = 0; i < 64; i++)
            {
                var vertexLight = lights[i];
                if (vertexLight != null && vertexLight.Dirty)
                {
                    num++;
                    SetGradient(i,
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(
                                vertexLight.StartRadius, 0f), 120f),
                        ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                            ((ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(
                                vertexLight.EndRadius, 0f), 120f));
                }
            }

            if (vertexCount <= 0) return;

            Device.BlendState = Process.GradientBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (var pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private void DrawLightOccluders(Matrix4x4 matrix, OriginalLevelSceneRoot level)
        {
            StartDrawingPrimitives();
            var tileBounds = level.TileBounds;
            var components =
                ((ISourceTrackedComponents)level.ComponentIndex).GetTrackedComponents("Celeste.LightOcclude");
            var components2 =
                ((ISourceTrackedComponents)level.ComponentIndex).GetTrackedComponents("Celeste.EffectCutout");
            foreach (LightOccludeState item in components)
                if (item.Visible && ((ISourceEntityVisibility)item.Entity).Visible)
                    item.RenderBounds = new(item.Left, item.Top, item.Width, item.Height);

            for (var i = 0; i < 64; i++)
            {
                var vertexLight = lights[i];
                if (vertexLight == null || !vertexLight.Dirty) continue;

                var light = vertexLight.InSolid ? vertexLight.LastNonSolidPosition : vertexLight.Center;
                var rectangle = new IntRect((int)(light.X - vertexLight.EndRadius),
                    (int)(light.Y - vertexLight.EndRadius), (int)vertexLight.EndRadius * 2,
                    (int)vertexLight.EndRadius * 2);
                var center = GetCenter(i);
                var mask = GetMask(i, 0f, 1f);
                foreach (LightOccludeState item2 in components)
                {
                    if (!item2.Visible || !((ISourceEntityVisibility)item2.Entity).Visible ||
                        item2.Alpha <= 0f) continue;

                    var renderBounds = item2.RenderBounds;
                    if (renderBounds.Intersects(rectangle))
                    {
                        renderBounds = SourceRectangleGeometry.ClampTo(renderBounds, rectangle);
                        var mask2 = GetMask(i, 1f - item2.Alpha, 1f);
                        if (renderBounds.Bottom > rectangle.Top &&
                            renderBounds.Bottom < rectangle.Y + rectangle.Height / 2)
                            SetOccluder(center, mask2, light, new(renderBounds.Left, renderBounds.Bottom),
                                new(renderBounds.Right, renderBounds.Bottom));

                        if (renderBounds.Top < rectangle.Bottom &&
                            renderBounds.Top > rectangle.Y + rectangle.Height / 2)
                            SetOccluder(center, mask2, light, new(renderBounds.Left, renderBounds.Top),
                                new(renderBounds.Right, renderBounds.Top));

                        if (renderBounds.Right > rectangle.Left &&
                            renderBounds.Right < rectangle.X + rectangle.Width / 2)
                            SetOccluder(center, mask2, light, new(renderBounds.Right, renderBounds.Top),
                                new(renderBounds.Right, renderBounds.Bottom));

                        if (renderBounds.Left < rectangle.Right &&
                            renderBounds.Left > rectangle.X + rectangle.Width / 2)
                            SetOccluder(center, mask2, light, new(renderBounds.Left, renderBounds.Top),
                                new(renderBounds.Left, renderBounds.Bottom));
                    }
                }

                var num = rectangle.Left / 8 - tileBounds.Left;
                var num2 = rectangle.Top / 8 - tileBounds.Top;
                var num3 = rectangle.Height / 8;
                var num4 = rectangle.Width / 8;
                var num5 = num + num4;
                var num6 = num2 + num3;
                for (var j = num2; j < num2 + num3 / 2; j++)
                for (var k = num; k < num5; k++)
                    if (level.SolidsData.SafeCheck(k, j) != '0' && level.SolidsData.SafeCheck(k, j + 1) == '0')
                    {
                        var num7 = k;
                        do
                        {
                            k++;
                        } while (k < num5 && level.SolidsData.SafeCheck(k, j) != '0' &&
                                 level.SolidsData.SafeCheck(k, j + 1) == '0');

                        SetOccluder(center, mask, light,
                            new Vector2(tileBounds.X + num7, tileBounds.Y + j + 1) * 8f,
                            new Vector2(tileBounds.X + k, tileBounds.Y + j + 1) * 8f);
                    }

                for (var l = num; l < num + num4 / 2; l++)
                for (var m = num2; m < num6; m++)
                    if (level.SolidsData.SafeCheck(l, m) != '0' && level.SolidsData.SafeCheck(l + 1, m) == '0')
                    {
                        var num8 = m;
                        do
                        {
                            m++;
                        } while (m < num6 && level.SolidsData.SafeCheck(l, m) != '0' &&
                                 level.SolidsData.SafeCheck(l + 1, m) == '0');

                        SetOccluder(center, mask, light,
                            new Vector2(tileBounds.X + l + 1, tileBounds.Y + num8) * 8f,
                            new Vector2(tileBounds.X + l + 1, tileBounds.Y + m) * 8f);
                    }

                for (var n = num2 + num3 / 2; n < num6; n++)
                for (var num9 = num; num9 < num5; num9++)
                    if (level.SolidsData.SafeCheck(num9, n) != '0' &&
                        level.SolidsData.SafeCheck(num9, n - 1) == '0')
                    {
                        var num10 = num9;
                        do
                        {
                            num9++;
                        } while (num9 < num5 && level.SolidsData.SafeCheck(num9, n) != '0' &&
                                 level.SolidsData.SafeCheck(num9, n - 1) == '0');

                        SetOccluder(center, mask, light, new Vector2(tileBounds.X + num10, tileBounds.Y + n) * 8f,
                            new Vector2(tileBounds.X + num9, tileBounds.Y + n) * 8f);
                    }

                for (var num11 = num + num4 / 2; num11 < num5; num11++)
                for (var num12 = num2; num12 < num6; num12++)
                    if (level.SolidsData.SafeCheck(num11, num12) != '0' &&
                        level.SolidsData.SafeCheck(num11 - 1, num12) == '0')
                    {
                        var num13 = num12;
                        do
                        {
                            num12++;
                        } while (num12 < num6 && level.SolidsData.SafeCheck(num11, num12) != '0' &&
                                 level.SolidsData.SafeCheck(num11 - 1, num12) == '0');

                        SetOccluder(center, mask, light,
                            new Vector2(tileBounds.X + num11, tileBounds.Y + num13) * 8f,
                            new Vector2(tileBounds.X + num11, tileBounds.Y + num12) * 8f);
                    }

                foreach (EffectCutoutState item3 in components2)
                    if (item3.Visible && ((ISourceEntityVisibility)item3.Entity).Visible && !(item3.Alpha <= 0f))
                    {
                        var bounds = item3.Bounds;
                        if (bounds.Intersects(rectangle))
                        {
                            bounds = SourceRectangleGeometry.ClampTo(bounds, rectangle);
                            var mask3 = GetMask(i, 1f - item3.Alpha, 1f);
                            SetCutout(center, mask3, light, bounds.X, bounds.Y, bounds.Width, bounds.Height);
                        }
                    }

                for (var num14 = num; num14 < num5; num14++)
                for (var num15 = num2; num15 < num6; num15++)
                    if (level.FgTilesLightMask.Tiles.SafeCheck(num14, num15) != null)
                        SetCutout(center, mask, light, (tileBounds.X + num14) * 8, (tileBounds.Y + num15) * 8, 8f,
                            8f);
            }

            if (vertexCount <= 0) return;

            Device.BlendState = Process.OccludeBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (var pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private PackedColor GetMask(int index, float maskOn, float maskOff)
        {
            var num = index / 16;
            return new(num == 0 ? maskOn : maskOff, num == 1 ? maskOn : maskOff,
                num == 2 ? maskOn : maskOff, num == 3 ? maskOn : maskOff);
        }

        private Vector3 GetCenter(int index)
        {
            var num = index % 16;
            return new(128f * (num % 4 + 0.5f) * 2f, 128f * (num / 4 + 0.5f) * 2f, 0f);
        }

        private void StartDrawingPrimitives()
        {
            vertexCount = 0;
            indexCount = 0;
        }

        private void SetClear(int index)
        {
            var center = GetCenter(index);
            var mask = GetMask(index, 0f, 1f);
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 1;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount + 3;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(-128f, -128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(128f, -128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(128f, 128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(-128f, 128f, 0f));
            verts[vertexCount++].Color = mask;
        }

        private void SetGradient(int index, float startFade, float endFade)
        {
            var center = GetCenter(index);
            var mask = GetMask(index, 1f, 0f);
            var num = vertexCount;
            verts[vertexCount].Position = center;
            verts[vertexCount].Color = mask;
            vertexCount++;
            for (var i = 0; i < 20; i++)
            {
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, SourceVector3Math.Multiply(angles[i], startFade));
                verts[vertexCount].Color = mask;
                vertexCount++;
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, SourceVector3Math.Multiply(angles[i], endFade));
                verts[vertexCount].Color = PackedColor.Transparent;
                vertexCount++;
                var num2 = i;
                var num3 = (i + 1) % 20;
                indices[indexCount++] = num;
                indices[indexCount++] = num + 1 + num2 * 2;
                indices[indexCount++] = num + 1 + num3 * 2;
                indices[indexCount++] = num + 1 + num2 * 2;
                indices[indexCount++] = num + 2 + num2 * 2;
                indices[indexCount++] = num + 2 + num3 * 2;
                indices[indexCount++] = num + 1 + num2 * 2;
                indices[indexCount++] = num + 2 + num3 * 2;
                indices[indexCount++] = num + 1 + num3 * 2;
            }
        }

        private void SetOccluder(Vector3 center, PackedColor mask, Vector2 light, Vector2 edgeA, Vector2 edgeB)
        {
            var vector = Vector2Geometry.Floor(edgeA - light);
            var vector2 = Vector2Geometry.Floor(edgeB - light);
            var num = Vector2Geometry.Angle(vector);
            var num2 = Vector2Geometry.Angle(vector2);
            var num3 = vertexCount;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(vector, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(vector2, 0f));
            verts[vertexCount++].Color = mask;
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            while (num != num2)
            {
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, new(Vector2Geometry.AngleToVector(num, 128f), 0f));
                verts[vertexCount].Color = mask;
                indices[indexCount++] = num3;
                indices[indexCount++] = vertexCount;
                indices[indexCount++] = vertexCount + 1;
                vertexCount++;
                num = ScalarMath.AngleApproach(num, num2, (float)Math.PI / 4f);
            }

            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new(Vector2Geometry.AngleToVector(num, 128f), 0f));
            verts[vertexCount].Color = mask;
            indices[indexCount++] = num3;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = num3 + 1;
            vertexCount++;
        }

        private void SetCutout(Vector3 center, PackedColor mask, Vector2 light, float x, float y, float width,
            float height)
        {
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 1;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount + 3;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new(x - light.X, y - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new(x + width - light.X, y - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new(x + width - light.X, y + height - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new(x - light.X, y + height - light.Y, 0f));
            verts[vertexCount++].Color = mask;
        }

        private void DrawLight(int index, Vector2 position, PackedColor color, float radius)
        {
            var center = GetCenter(index);
            var mask = GetMask(index, 1f, 0f);
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 1;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount + 3;
            resultVerts[vertexCount].Position = new(position + new Vector2(0f - radius, 0f - radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X - radius, center.Y - radius), 1024f);
            resultVerts[vertexCount].Position = new(position + new Vector2(radius, 0f - radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X + radius, center.Y - radius), 1024f);
            resultVerts[vertexCount].Position = new(position + new Vector2(radius, radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X + radius, center.Y + radius), 1024f);
            resultVerts[vertexCount].Position = new(position + new Vector2(0f - radius, radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X - radius, center.Y + radius), 1024f);
        }

        public override void Render(object scene)
        {
            var capture = Draw.SpriteBatch.PresentationCapture;
            var difference = capture?.GameplayDifference;
            var observing = false;
            try
            {
                if (capture != null)
                {
                    var camera = capture.CameraTransform;
                    observing = difference.Begin(Graphics.Buffers.Gameplay.Target,
                        capture.Room, in camera, capture.FrameSequence);
                }

                Graphics.FxDither.CurrentTechnique = Graphics.FxDither.Techniques["InvertDither"];
                Graphics.FxDither.Parameters["size"]
                    .SetValue(new Vector2(Graphics.Buffers.Light.Width, Graphics.Buffers.Light.Height));
                Draw.SpriteBatch.Begin(SourceSpriteSortMode.Deferred, Graphics.DestinationTransparencySubtract,
                    SourceSamplerState.PointClamp, SourceDepthStencilState.None, SourceRasterizerState.CullNone,
                    Graphics.FxDither, Matrix4x4.Identity);
                Draw.SpriteBatch.Draw(Graphics.Buffers.Light.Target, Vector2.Zero,
                    (PackedColor.White * ScalarMath.Clamp(Alpha, 0f, 1f)).PackedValue);
                Draw.SpriteBatch.End();
                if (observing) difference.Complete();
            }
            finally
            {
                if (observing) difference.Abort();
            }
        }
    }
}

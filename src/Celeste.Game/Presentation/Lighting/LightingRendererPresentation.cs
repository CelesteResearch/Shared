using Celeste.Core.Display;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.InteropServices;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Rendering;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Simulation.Gameplay.Platforms.Foundation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Display;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Primitives;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;

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

            public static readonly SourceVertexDeclaration VertexDeclaration = new SourceVertexDeclaration(
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

        private SourceVertexPositionColor[] verts = new SourceVertexPositionColor[11520];

        private VertexPositionColorMaskTexture[] resultVerts = new VertexPositionColorMaskTexture[384];

        private int[] indices = new int[11520];

        private int vertexCount;

        private int indexCount;

        private VertexLightState[] lights;

        private VertexLightState spotlight;

        private bool inSpotlight;

        private float nonSpotlightAlphaMultiplier = 1f;

        private Vector3[] angles = new Vector3[20];

        public LightingRendererPresentation(ISourceEngineContext engine)
        {
            this.engine = engine;
            lights = new VertexLightState[64];
            for (int i = 0; i < 20; i++)
            {
                angles[i] = new Vector3(Vector2Geometry.AngleToVector((float)i / 20f * ((float)Math.PI * 2f), 1f), 0f);
            }
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
                ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic);
            base.Update(scene);
        }

        public override void BeforeRender(object scene)
        {
            OriginalLevelSceneRoot level = scene as OriginalLevelSceneRoot;
            CameraState camera = level.Camera;
            for (int i = 0; i < 64; i++)
            {
                if (lights[i] != null && ((ISourceEntityScene)lights[i].Entity).Scene != scene)
                {
                    lights[i].Index = -1;
                    lights[i] = null;
                }
            }

            foreach (VertexLightState component in ((ISourceTrackedComponents)((ISourceComponentIndexScene)scene)
                         .ComponentIndex).GetTrackedComponents("Celeste.VertexLight"))
            {
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
                        for (int j = 0; j < 64; j++)
                        {
                            if (lights[j] == null)
                            {
                                lights[j] = component;
                                component.Index = j;
                                break;
                            }
                        }
                    }

                    if (component.LastPosition != component.Position ||
                        component.LastEntityPosition != ((ISourceEntityPosition)component.Entity).Position ||
                        component.Dirty)
                    {
                        component.LastPosition = component.Position;
                        component.InSolid = false;
                        foreach (SourceSolidEntityState item in SourceSceneCollision.AllPoint<SourceSolidEntityState>(
                                     level.Scheduler.Entities, "Celeste.Solid", component.Center))
                        {
                            if (item.DisableLightsInside)
                            {
                                component.InSolid = true;
                                break;
                            }
                        }

                        if (!component.InSolid)
                        {
                            component.LastNonSolidPosition = component.Center;
                        }

                        if (component.InSolid && !component.Started)
                        {
                            component.InSolidAlphaMultiplier = 0f;
                        }
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
            }

            Device.SetRenderTarget(Graphics.Buffers.LightBuffer.Target);
            Device.RasterizerState = SourceRasterizerState.CullNone;
            Matrix4x4 matrix = SourceMatrixMath.Multiply(
                SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(0.0009765625f),
                    SourceMatrixMath.CreateScale(2f, -2f, 1f)), SourceMatrixMath.CreateTranslation(-1f, 1f, 0f));
            ClearDirtyLights(matrix);
            DrawLightGradients(matrix);
            DrawLightOccluders(matrix, level);
            Device.SetRenderTarget(Graphics.Buffers.Light.Target);
            Device.Clear(BaseColor);
            Device.Textures[0] = Graphics.Buffers.LightBuffer.Target;
            StartDrawingPrimitives();
            for (int k = 0; k < 64; k++)
            {
                VertexLightState vertexLight2 = lights[k];
                if (vertexLight2 == null)
                {
                    continue;
                }

                vertexLight2.Dirty = false;
                float num = vertexLight2.Alpha * vertexLight2.InSolidAlphaMultiplier;
                if (nonSpotlightAlphaMultiplier < 1f && vertexLight2 != spotlight)
                {
                    num *= nonSpotlightAlphaMultiplier;
                }

                if (num > 0f && vertexLight2.Color.A > 0 && vertexLight2.EndRadius >= 2f)
                {
                    int num2 = 128;
                    while (vertexLight2.EndRadius <= (float)(num2 / 2))
                    {
                        num2 /= 2;
                    }

                    DrawLight(k, vertexLight2.InSolid ? vertexLight2.LastNonSolidPosition : vertexLight2.Center,
                        vertexLight2.Color * num, num2);
                }
            }

            if (vertexCount > 0)
            {
                SourcePrimitiveGraphics.DrawIndexedVertices(
                    ((ISourcePrimitiveGraphicsEnvironment)engine).PrimitiveGraphics,
                    camera.Matrix, resultVerts, vertexCount, indices, indexCount / 3, Graphics.FxLighting,
                    SourceBlendState.Additive);
            }

            GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)engine, Graphics.Buffers.Light.Target,
                Graphics.Buffers.TempA, Graphics.Buffers.Light);
        }

        private void ClearDirtyLights(Matrix4x4 matrix)
        {
            StartDrawingPrimitives();
            for (int i = 0; i < 64; i++)
            {
                VertexLightState vertexLight = lights[i];
                if (vertexLight != null && vertexLight.Dirty)
                {
                    SetClear(i);
                }
            }

            if (vertexCount <= 0)
            {
                return;
            }

            Device.BlendState = Process.OccludeBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (SourceEffectPass pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private void DrawLightGradients(Matrix4x4 matrix)
        {
            StartDrawingPrimitives();
            int num = 0;
            for (int i = 0; i < 64; i++)
            {
                VertexLightState vertexLight = lights[i];
                if (vertexLight != null && vertexLight.Dirty)
                {
                    num++;
                    SetGradient(i,
                        ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                            ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(
                                vertexLight.StartRadius, 0f), 120f),
                        ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic.Min(
                            ((Celeste.Core.Mathematics.Extrema.ISourceExtremaEnvironment)engine).ExtremaArithmetic.Max(
                                vertexLight.EndRadius, 0f), 120f));
                }
            }

            if (vertexCount <= 0)
            {
                return;
            }

            Device.BlendState = Process.GradientBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (SourceEffectPass pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private void DrawLightOccluders(Matrix4x4 matrix, OriginalLevelSceneRoot level)
        {
            StartDrawingPrimitives();
            IntRect tileBounds = level.TileBounds;
            List<SourceComponentState> components =
                ((ISourceTrackedComponents)level.ComponentIndex).GetTrackedComponents("Celeste.LightOcclude");
            List<SourceComponentState> components2 =
                ((ISourceTrackedComponents)level.ComponentIndex).GetTrackedComponents("Celeste.EffectCutout");
            foreach (LightOccludeState item in components)
            {
                if (item.Visible && ((ISourceEntityVisibility)item.Entity).Visible)
                {
                    item.RenderBounds = new IntRect(item.Left, item.Top, item.Width, item.Height);
                }
            }

            for (int i = 0; i < 64; i++)
            {
                VertexLightState vertexLight = lights[i];
                if (vertexLight == null || !vertexLight.Dirty)
                {
                    continue;
                }

                Vector2 light = (vertexLight.InSolid ? vertexLight.LastNonSolidPosition : vertexLight.Center);
                IntRect rectangle = new IntRect((int)(light.X - vertexLight.EndRadius),
                    (int)(light.Y - vertexLight.EndRadius), (int)vertexLight.EndRadius * 2,
                    (int)vertexLight.EndRadius * 2);
                Vector3 center = GetCenter(i);
                PackedColor mask = GetMask(i, 0f, 1f);
                foreach (LightOccludeState item2 in components)
                {
                    if (!item2.Visible || !((ISourceEntityVisibility)item2.Entity).Visible || item2.Alpha <= 0f)
                    {
                        continue;
                    }

                    IntRect renderBounds = item2.RenderBounds;
                    if (renderBounds.Intersects(rectangle))
                    {
                        renderBounds = SourceRectangleGeometry.ClampTo(renderBounds, rectangle);
                        PackedColor mask2 = GetMask(i, 1f - item2.Alpha, 1f);
                        if (renderBounds.Bottom > rectangle.Top &&
                            renderBounds.Bottom < (rectangle.Y + rectangle.Height / 2))
                        {
                            SetOccluder(center, mask2, light, new Vector2(renderBounds.Left, renderBounds.Bottom),
                                new Vector2(renderBounds.Right, renderBounds.Bottom));
                        }

                        if (renderBounds.Top < rectangle.Bottom &&
                            renderBounds.Top > (rectangle.Y + rectangle.Height / 2))
                        {
                            SetOccluder(center, mask2, light, new Vector2(renderBounds.Left, renderBounds.Top),
                                new Vector2(renderBounds.Right, renderBounds.Top));
                        }

                        if (renderBounds.Right > rectangle.Left &&
                            renderBounds.Right < (rectangle.X + rectangle.Width / 2))
                        {
                            SetOccluder(center, mask2, light, new Vector2(renderBounds.Right, renderBounds.Top),
                                new Vector2(renderBounds.Right, renderBounds.Bottom));
                        }

                        if (renderBounds.Left < rectangle.Right &&
                            renderBounds.Left > (rectangle.X + rectangle.Width / 2))
                        {
                            SetOccluder(center, mask2, light, new Vector2(renderBounds.Left, renderBounds.Top),
                                new Vector2(renderBounds.Left, renderBounds.Bottom));
                        }
                    }
                }

                int num = rectangle.Left / 8 - tileBounds.Left;
                int num2 = rectangle.Top / 8 - tileBounds.Top;
                int num3 = rectangle.Height / 8;
                int num4 = rectangle.Width / 8;
                int num5 = num + num4;
                int num6 = num2 + num3;
                for (int j = num2; j < num2 + num3 / 2; j++)
                {
                    for (int k = num; k < num5; k++)
                    {
                        if (level.SolidsData.SafeCheck(k, j) != '0' && level.SolidsData.SafeCheck(k, j + 1) == '0')
                        {
                            int num7 = k;
                            do
                            {
                                k++;
                            } while (k < num5 && level.SolidsData.SafeCheck(k, j) != '0' &&
                                     level.SolidsData.SafeCheck(k, j + 1) == '0');

                            SetOccluder(center, mask, light,
                                new Vector2(tileBounds.X + num7, tileBounds.Y + j + 1) * 8f,
                                new Vector2(tileBounds.X + k, tileBounds.Y + j + 1) * 8f);
                        }
                    }
                }

                for (int l = num; l < num + num4 / 2; l++)
                {
                    for (int m = num2; m < num6; m++)
                    {
                        if (level.SolidsData.SafeCheck(l, m) != '0' && level.SolidsData.SafeCheck(l + 1, m) == '0')
                        {
                            int num8 = m;
                            do
                            {
                                m++;
                            } while (m < num6 && level.SolidsData.SafeCheck(l, m) != '0' &&
                                     level.SolidsData.SafeCheck(l + 1, m) == '0');

                            SetOccluder(center, mask, light,
                                new Vector2(tileBounds.X + l + 1, tileBounds.Y + num8) * 8f,
                                new Vector2(tileBounds.X + l + 1, tileBounds.Y + m) * 8f);
                        }
                    }
                }

                for (int n = num2 + num3 / 2; n < num6; n++)
                {
                    for (int num9 = num; num9 < num5; num9++)
                    {
                        if (level.SolidsData.SafeCheck(num9, n) != '0' &&
                            level.SolidsData.SafeCheck(num9, n - 1) == '0')
                        {
                            int num10 = num9;
                            do
                            {
                                num9++;
                            } while (num9 < num5 && level.SolidsData.SafeCheck(num9, n) != '0' &&
                                     level.SolidsData.SafeCheck(num9, n - 1) == '0');

                            SetOccluder(center, mask, light, new Vector2(tileBounds.X + num10, tileBounds.Y + n) * 8f,
                                new Vector2(tileBounds.X + num9, tileBounds.Y + n) * 8f);
                        }
                    }
                }

                for (int num11 = num + num4 / 2; num11 < num5; num11++)
                {
                    for (int num12 = num2; num12 < num6; num12++)
                    {
                        if (level.SolidsData.SafeCheck(num11, num12) != '0' &&
                            level.SolidsData.SafeCheck(num11 - 1, num12) == '0')
                        {
                            int num13 = num12;
                            do
                            {
                                num12++;
                            } while (num12 < num6 && level.SolidsData.SafeCheck(num11, num12) != '0' &&
                                     level.SolidsData.SafeCheck(num11 - 1, num12) == '0');

                            SetOccluder(center, mask, light,
                                new Vector2(tileBounds.X + num11, tileBounds.Y + num13) * 8f,
                                new Vector2(tileBounds.X + num11, tileBounds.Y + num12) * 8f);
                        }
                    }
                }

                foreach (EffectCutoutState item3 in components2)
                {
                    if (item3.Visible && ((ISourceEntityVisibility)item3.Entity).Visible && !(item3.Alpha <= 0f))
                    {
                        IntRect bounds = item3.Bounds;
                        if (bounds.Intersects(rectangle))
                        {
                            bounds = SourceRectangleGeometry.ClampTo(bounds, rectangle);
                            PackedColor mask3 = GetMask(i, 1f - item3.Alpha, 1f);
                            SetCutout(center, mask3, light, bounds.X, bounds.Y, bounds.Width, bounds.Height);
                        }
                    }
                }

                for (int num14 = num; num14 < num5; num14++)
                {
                    for (int num15 = num2; num15 < num6; num15++)
                    {
                        if (level.FgTilesLightMask.Tiles.SafeCheck(num14, num15) != null)
                        {
                            SetCutout(center, mask, light, (tileBounds.X + num14) * 8, (tileBounds.Y + num15) * 8, 8f,
                                8f);
                        }
                    }
                }
            }

            if (vertexCount <= 0)
            {
                return;
            }

            Device.BlendState = Process.OccludeBlendState;
            Graphics.FxPrimitive.Parameters["World"].SetValue(matrix);
            foreach (SourceEffectPass pass in Graphics.FxPrimitive.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawUserIndexedPrimitives(SourcePrimitiveType.TriangleList, verts, 0, vertexCount, indices, 0,
                    indexCount / 3);
            }
        }

        private PackedColor GetMask(int index, float maskOn, float maskOff)
        {
            int num = index / 16;
            return new PackedColor((num == 0) ? maskOn : maskOff, (num == 1) ? maskOn : maskOff,
                (num == 2) ? maskOn : maskOff, (num == 3) ? maskOn : maskOff);
        }

        private Vector3 GetCenter(int index)
        {
            int num = index % 16;
            return new Vector3(128f * ((float)(num % 4) + 0.5f) * 2f, 128f * ((float)(num / 4) + 0.5f) * 2f, 0f);
        }

        private void StartDrawingPrimitives()
        {
            vertexCount = 0;
            indexCount = 0;
        }

        private void SetClear(int index)
        {
            Vector3 center = GetCenter(index);
            PackedColor mask = GetMask(index, 0f, 1f);
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 1;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount + 3;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(-128f, -128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(128f, -128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(128f, 128f, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(-128f, 128f, 0f));
            verts[vertexCount++].Color = mask;
        }

        private void SetGradient(int index, float startFade, float endFade)
        {
            Vector3 center = GetCenter(index);
            PackedColor mask = GetMask(index, 1f, 0f);
            int num = vertexCount;
            verts[vertexCount].Position = center;
            verts[vertexCount].Color = mask;
            vertexCount++;
            for (int i = 0; i < 20; i++)
            {
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, SourceVector3Math.Multiply(angles[i], startFade));
                verts[vertexCount].Color = mask;
                vertexCount++;
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, SourceVector3Math.Multiply(angles[i], endFade));
                verts[vertexCount].Color = PackedColor.Transparent;
                vertexCount++;
                int num2 = i;
                int num3 = (i + 1) % 20;
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
            Vector2 vector = Vector2Geometry.Floor(edgeA - light);
            Vector2 vector2 = Vector2Geometry.Floor(edgeB - light);
            float num = Vector2Geometry.Angle(vector);
            float num2 = Vector2Geometry.Angle(vector2);
            int num3 = vertexCount;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(vector, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(vector2, 0f));
            verts[vertexCount++].Color = mask;
            while (num != num2)
            {
                verts[vertexCount].Position =
                    SourceVector3Math.Add(center, new Vector3(Vector2Geometry.AngleToVector(num, 128f), 0f));
                verts[vertexCount].Color = mask;
                indices[indexCount++] = num3;
                indices[indexCount++] = vertexCount;
                indices[indexCount++] = vertexCount + 1;
                vertexCount++;
                num = ScalarMath.AngleApproach(num, num2, (float)Math.PI / 4f);
            }

            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new Vector3(Vector2Geometry.AngleToVector(num, 128f), 0f));
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
            verts[vertexCount].Position = SourceVector3Math.Add(center, new Vector3(x - light.X, y - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new Vector3(x + width - light.X, y - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new Vector3(x + width - light.X, y + height - light.Y, 0f));
            verts[vertexCount++].Color = mask;
            verts[vertexCount].Position =
                SourceVector3Math.Add(center, new Vector3(x - light.X, y + height - light.Y, 0f));
            verts[vertexCount++].Color = mask;
        }

        private void DrawLight(int index, Vector2 position, PackedColor color, float radius)
        {
            Vector3 center = GetCenter(index);
            PackedColor mask = GetMask(index, 1f, 0f);
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 1;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount;
            indices[indexCount++] = vertexCount + 2;
            indices[indexCount++] = vertexCount + 3;
            resultVerts[vertexCount].Position = new Vector3(position + new Vector2(0f - radius, 0f - radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X - radius, center.Y - radius), 1024f);
            resultVerts[vertexCount].Position = new Vector3(position + new Vector2(radius, 0f - radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X + radius, center.Y - radius), 1024f);
            resultVerts[vertexCount].Position = new Vector3(position + new Vector2(radius, radius), 0f);
            resultVerts[vertexCount].Color = color;
            resultVerts[vertexCount].Mask = mask;
            resultVerts[vertexCount++].Texcoord =
                ((ISourceVectorEnvironment)engine).VectorArithmetic.Divide(
                    new Vector2(center.X + radius, center.Y + radius), 1024f);
            resultVerts[vertexCount].Position = new Vector3(position + new Vector2(0f - radius, radius), 0f);
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
            bool observing = false;
            try
            {
                if (capture != null)
                {
                    var camera = capture.CameraTransform;
                    observing = difference.Begin((SourceRenderTarget2DResource)Graphics.Buffers.Gameplay.Target,
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

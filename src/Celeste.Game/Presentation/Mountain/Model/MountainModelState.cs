using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Graphics;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Geometry.ThreeD.Billboards;
using Celeste.Graphics.Geometry.ThreeD.Camera;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Scenes;

namespace Celeste.Game.Presentation.Mountain.Model
{
    public class MountainModelState : IDisposable
    {
        public readonly ISourceEngineContext EngineContext;
        protected ISourceRenderContext Context => ((ISourceRenderEnvironment)EngineContext).CurrentContext;
        protected SourceGraphicsDevice Device => ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice;

        protected IOriginalEngineGraphicsState Metrics =>
            ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics;

        protected OriginalMountainResources MountainResources =>
            ((IOriginalMountainEnvironment)EngineContext).MountainResources;

        protected OriginalGameGraphicsResources GraphicsResources =>
            (OriginalGameGraphicsResources)((ISourceGameGraphicsEnvironment)EngineContext)
            .GameGraphics;

        protected ISourceVectorArithmetic VectorArithmetic =>
            ((ISourceVectorEnvironment)EngineContext).VectorArithmetic;

        protected ISourceScalarArithmetic ScalarArithmetic =>
            ((ISourceScalarEnvironment)EngineContext).ScalarArithmetic;

        protected ISourceExtremaArithmetic ExtremaArithmetic =>
            ((ISourceExtremaEnvironment)EngineContext).ExtremaArithmetic;

        protected ISourceEasingArithmetic EasingArithmetic =>
            ((ISourceEasingEnvironment)EngineContext).EasingArithmetic;

        public MountainCameraState Camera;

        public Vector3 Forward;

        public float SkyboxOffset;

        public bool LockBufferResizing;

        protected VirtualRenderTarget buffer;

        protected VirtualRenderTarget blurA;

        protected VirtualRenderTarget blurB;

        public static SourceRasterizerState MountainRasterizer = new()
        {
            CullMode = SourceCullMode.CullClockwiseFace,
            MultiSampleAntiAlias = true,
        };

        public static SourceRasterizerState CullNoneRasterizer = new()
        {
            CullMode = SourceCullMode.None,
            MultiSampleAntiAlias = false,
        };

        public static SourceRasterizerState CullCCRasterizer = new()
        {
            CullMode = SourceCullMode.CullCounterClockwiseFace,
            MultiSampleAntiAlias = false,
        };

        public static SourceRasterizerState CullCRasterizer = new()
        {
            CullMode = SourceCullMode.CullClockwiseFace,
            MultiSampleAntiAlias = false,
        };

        protected int currState;

        protected int nextState;

        protected int targetState;

        protected float easeState = 1f;

        protected MountainState[] mountainStates = new MountainState[4];

        public Vector3 CoreWallPosition = Vector3.Zero;

        protected SourceVertexBuffer billboardVertices;

        protected SourceIndexBuffer billboardIndices;

        protected SourceVertexPositionColorTexture[] billboardInfo = new SourceVertexPositionColorTexture[2048];

        protected SourceTexture2DResource[] billboardTextures = new SourceTexture2DResource[512];

        protected MountainRing fog;

        protected MountainRing fog2;

        public float NearFogAlpha;

        public float StarEase;

        public float SnowStretch;

        public float SnowSpeedAddition = 1f;

        public float SnowForceFloat;

        protected MountainRing starsky;

        protected MountainRing starfog;

        protected MountainRing stardots0;

        protected MountainRing starstream0;

        protected MountainRing starstream1;

        protected MountainRing starstream2;

        protected bool ignoreCameraRotation;

        protected Quaternion lastCameraRotation;

        protected Vector3 starCenter = new(0f, 32f, 0f);

        protected float birdTimer;

        public List<SourceVertexPositionColor> DebugPoints = [];

        public bool DrawDebugPoints;

        public MountainModelState(ISourceEngineContext engine)
        {
            EngineContext = engine;
            mountainStates[0] = new(EngineContext, MountainResources.MountainTerrainTextures[0],
                MountainResources.MountainBuildingTextures[0], MountainResources.MountainSkyboxTextures[0],
                new(1, 8, 23));
            mountainStates[1] = new(EngineContext, MountainResources.MountainTerrainTextures[1],
                MountainResources.MountainBuildingTextures[1], MountainResources.MountainSkyboxTextures[1],
                new(19, 32, 62));
            mountainStates[2] = new(EngineContext, MountainResources.MountainTerrainTextures[2],
                MountainResources.MountainBuildingTextures[2], MountainResources.MountainSkyboxTextures[2],
                new(40, 26, 53));
            mountainStates[3] = new(EngineContext, MountainResources.MountainTerrainTextures[0],
                MountainResources.MountainBuildingTextures[0], MountainResources.MountainSkyboxTextures[0],
                new(1, 8, 23));
            fog = new(EngineContext, 6f, -1f, 20f, 0f, 24, PackedColor.White,
                MountainResources.MountainFogTexture);
            fog2 = new(EngineContext, 6f, -4f, 10f, 0f, 24, PackedColor.White,
                MountainResources.MountainFogTexture);
            starsky = new(EngineContext, 18f, -18f, 20f, 0f, 24, PackedColor.White,
                PackedColor.Transparent,
                MountainResources.MountainStarSky);
            starfog = new(EngineContext, 10f, -18f, 19.5f, 0f, 24, new(2, 9, 21),
                PackedColor.Transparent, MountainResources.MountainFogTexture);
            stardots0 = new(EngineContext, 16f, -18f, 19f, 0f, 24, PackedColor.White,
                PackedColor.Transparent,
                MountainResources.MountainStars, 4f);
            starstream0 = new(EngineContext, 5f, -8f, 18.5f, 0.2f, 80, PackedColor.Black,
                MountainResources.MountainStarStream);
            starstream1 = new(EngineContext, 4f, -6f, 18f, 1f, 80, new PackedColor(146, 40, 226) * 0.5f,
                MountainResources.MountainStarStream);
            starstream2 = new(EngineContext, 3f, -4f, 17.9f, 1.4f, 80,
                new PackedColor(48, 255, 255) * 0.5f,
                MountainResources.MountainStarStream);
            ResetRenderTargets();
            ResetBillboardBuffers();
        }

        public void SnapState(int state)
        {
            currState = nextState = targetState = state % mountainStates.Length;
            easeState = 1f;
            if (state == 3) StarEase = 1f;
        }

        public void EaseState(int state)
        {
            targetState = state % mountainStates.Length;
            lastCameraRotation = Camera.Rotation;
        }

        public virtual void Update()
        {
            if (currState != nextState)
            {
                easeState = ScalarMath.Approach(easeState, 1f,
                    (nextState == targetState ? 1 : 4) * EngineContext.DeltaTime, ExtremaArithmetic);
                if (easeState >= 1f) currState = nextState;
            }
            else if (nextState != targetState)
            {
                nextState = targetState;
                easeState = 0f;
            }

            StarEase = ScalarMath.Approach(StarEase, nextState == 3 ? 1f : 0f,
                (nextState == 3 ? 1.5f : 1f) * EngineContext.DeltaTime, ExtremaArithmetic);
            SnowForceFloat = ScalarMath.ClampedMap(StarEase, 0.95f, 1f);
            ignoreCameraRotation = (nextState == 3 && currState != 3 && StarEase < 0.5f) ||
                                   (nextState != 3 && currState == 3 && StarEase > 0.5f);
            if (nextState == 3)
            {
                SnowStretch = ScalarMath.ClampedMap(StarEase, 0f, 0.25f) * 50f;
                SnowSpeedAddition = SnowStretch * 4f;
            }
            else
            {
                SnowStretch = ScalarMath.ClampedMap(StarEase, 0.25f, 1f) * 50f;
                SnowSpeedAddition = (0f - SnowStretch) * 4f;
            }

            starfog.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
            fog.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
            fog.TopColor = fog.BotColor = SourceColorInterpolation.Lerp(mountainStates[currState].FogColor,
                mountainStates[nextState].FogColor, easeState, ScalarArithmetic);
            fog2.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
            fog2.TopColor = fog2.BotColor = PackedColor.White * 0.3f * NearFogAlpha;
            starstream1.Rotate(EngineContext.DeltaTime * 0.01f);
            starstream2.Rotate(EngineContext.DeltaTime * 0.02f);
            birdTimer += EngineContext.DeltaTime;
        }

        public void ResetRenderTargets()
        {
            var num = Math.Min(1920, Metrics.ViewWidth);
            var num2 = Math.Min(1080, Metrics.ViewHeight);
            if (buffer == null || buffer.IsDisposed || (buffer.Width != num && !LockBufferResizing))
            {
                DisposeTargets();
                buffer = ((ISourceVirtualContentEnvironment)EngineContext).VirtualContent.CreateRenderTarget(
                    "mountain-a",
                    num, num2, true, false);
                blurA = ((ISourceVirtualContentEnvironment)EngineContext).VirtualContent.CreateRenderTarget(
                    "mountain-blur-a", num / 2, num2 / 2);
                blurB = ((ISourceVirtualContentEnvironment)EngineContext).VirtualContent.CreateRenderTarget(
                    "mountain-blur-b", num / 2, num2 / 2);
            }
        }

        public virtual void ResetBillboardBuffers()
        {
            if (billboardVertices == null || billboardIndices.IsDisposed ||
                billboardIndices.GraphicsDevice.IsDisposed ||
                billboardVertices.IsDisposed || billboardVertices.GraphicsDevice.IsDisposed ||
                billboardInfo.Length > billboardVertices.VertexCount)
            {
                DisposeBillboardBuffers();
                billboardVertices = new(Device, typeof(SourceVertexPositionColorTexture),
                    billboardInfo.Length, SourceBufferUsage.None);
                billboardIndices = new(Device, typeof(short), billboardInfo.Length / 4 * 6,
                    SourceBufferUsage.None);
                var array = new short[billboardIndices.IndexCount];
                var num = 0;
                var num2 = 0;
                while (num < array.Length)
                {
                    array[num] = (short)num2;
                    array[num + 1] = (short)(num2 + 1);
                    array[num + 2] = (short)(num2 + 2);
                    array[num + 3] = (short)num2;
                    array[num + 4] = (short)(num2 + 2);
                    array[num + 5] = (short)(num2 + 3);
                    num += 6;
                    num2 += 4;
                }

                billboardIndices.SetData(array);
            }
        }

        public void Dispose()
        {
            DisposeTargets();
            DisposeBillboardBuffers();
        }

        public void DisposeTargets()
        {
            if (buffer != null && !buffer.IsDisposed)
            {
                buffer.Dispose();
                blurA.Dispose();
                blurB.Dispose();
            }
        }

        public virtual void DisposeBillboardBuffers()
        {
            if (billboardVertices != null && !billboardVertices.IsDisposed) billboardVertices.Dispose();

            if (billboardIndices != null && !billboardIndices.IsDisposed) billboardIndices.Dispose();
        }

        public virtual void BeforeRender(object scene)
        {
            ResetRenderTargets();
            var rotation = Camera.Rotation;
            if (ignoreCameraRotation) rotation = lastCameraRotation;

            var matrix = SourceMatrixMath.CreatePerspectiveFieldOfView((float)Math.PI / 4f,
                Metrics.Width / (float)Metrics.Height, 0.25f, 50f);
            var matrix2 = SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(-Camera.Position),
                SourceMatrixMath.CreateFromQuaternion(rotation));
            var matrix3 = SourceMatrixMath.Multiply(matrix2, matrix);
            Forward = SourceVector3Math.Transform(new(0f, 0f, -1f),
                SourceQuaternionMath.Conjugate(Camera.Rotation));
            Device.SetRenderTarget(buffer.Target);
            if (StarEase < 1f)
            {
                var matrix4 = SourceMatrixMath.Multiply(
                    SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(0f, 5f - Camera.Position.Y * 1.1f, 0f),
                        SourceMatrixMath.CreateFromQuaternion(rotation)), matrix);
                if (currState == nextState)
                {
                    mountainStates[currState].Skybox.Draw(matrix4, PackedColor.White);
                }
                else
                {
                    mountainStates[currState].Skybox.Draw(matrix4, PackedColor.White);
                    mountainStates[nextState].Skybox.Draw(matrix4, PackedColor.White * easeState);
                }

                if (currState != nextState)
                {
                    GraphicsResources.FxMountain.Parameters["ease"].SetValue(easeState);
                    GraphicsResources.FxMountain.CurrentTechnique = GraphicsResources.FxMountain.Techniques["Easing"];
                }
                else
                {
                    GraphicsResources.FxMountain.CurrentTechnique = GraphicsResources.FxMountain.Techniques["Single"];
                }

                Device.DepthStencilState = SourceDepthStencilState.Default;
                Device.BlendState = SourceBlendState.AlphaBlend;
                Device.RasterizerState = MountainRasterizer;
                GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                GraphicsResources.FxMountain.Parameters["fog"].SetValue(fog.TopColor.ToVector3());
                Device.Textures[0] = mountainStates[currState].TerrainTexture.Texture;
                Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                if (currState != nextState)
                {
                    Device.Textures[1] = mountainStates[nextState].TerrainTexture.Texture;
                    Device.SamplerStates[1] = SourceSamplerState.LinearClamp;
                }

                MountainResources.MountainTerrain.Draw(GraphicsResources.FxMountain);
                GraphicsResources.FxMountain.Parameters["WorldViewProj"]
                    .SetValue(SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(CoreWallPosition), matrix3));
                MountainResources.MountainCoreWall.Draw(GraphicsResources.FxMountain);
                GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                Device.Textures[0] = mountainStates[currState].BuildingsTexture.Texture;
                Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                if (currState != nextState)
                {
                    Device.Textures[1] = mountainStates[nextState].BuildingsTexture.Texture;
                    Device.SamplerStates[1] = SourceSamplerState.LinearClamp;
                }

                MountainResources.MountainBuildings.Draw(GraphicsResources.FxMountain);
                fog.Draw(matrix3);
            }

            if (StarEase > 0f)
            {
                Context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearClamp, null, null, null, Matrix4x4.Identity));
                SourcePrimitiveDrawing.Rect(Context, this, 0f, 0f, buffer.Width,
                    buffer.Height,
                    PackedColor.Black * EasingArithmetic.CubeInOut(ScalarMath.ClampedMap(StarEase, 0f, 0.6f)));
                Context.EndBatch();
                var matrix5 = SourceMatrixMath.Multiply(
                    SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(starCenter - Camera.Position),
                        SourceMatrixMath.CreateFromQuaternion(rotation)), matrix);
                var alpha = ScalarMath.ClampedMap(StarEase, 0.8f, 1f);
                starsky.Draw(matrix5, CullCCRasterizer, alpha);
                starfog.Draw(matrix5, CullCCRasterizer, alpha);
                stardots0.Draw(matrix5, CullCCRasterizer, alpha);
                starstream0.Draw(matrix5, CullCCRasterizer, alpha);
                starstream1.Draw(matrix5, CullCCRasterizer, alpha);
                starstream2.Draw(matrix5, CullCCRasterizer, alpha);
                Device.DepthStencilState = SourceDepthStencilState.Default;
                Device.BlendState = SourceBlendState.AlphaBlend;
                Device.RasterizerState = CullCRasterizer;
                Device.Textures[0] = MountainResources.MountainMoonTexture.Texture;
                Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                GraphicsResources.FxMountain.CurrentTechnique = GraphicsResources.FxMountain.Techniques["Single"];
                GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                GraphicsResources.FxMountain.Parameters["fog"].SetValue(fog.TopColor.ToVector3());
                MountainResources.MountainMoon.Draw(GraphicsResources.FxMountain);
                var num = birdTimer * 0.2f;
                var matrix6 = SourceMatrixMath.Multiply(
                    SourceMatrixMath.Multiply(
                        SourceMatrixMath.Multiply(
                            SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(0.25f),
                                SourceMatrixMath.CreateRotationZ((float)Math.Cos(num * 2f) * 0.5f)),
                            SourceMatrixMath.CreateRotationX(0.4f + (float)Math.Sin(num) * 0.05f)),
                        SourceMatrixMath.CreateRotationY(0f - num - (float)Math.PI / 2f)),
                    SourceMatrixMath.CreateTranslation((float)Math.Cos(num) * 2.2f,
                        31f + (float)Math.Sin(num * 2f) * 0.8f,
                        (float)Math.Sin(num) * 2.2f));
                GraphicsResources.FxMountain.Parameters["WorldViewProj"]
                    .SetValue(SourceMatrixMath.Multiply(matrix6, matrix3));
                GraphicsResources.FxMountain.Parameters["fog"].SetValue(fog.TopColor.ToVector3());
                MountainResources.MountainBird.Draw(GraphicsResources.FxMountain);
            }

            DrawBillboards(matrix3,
                ((SourceSceneState)scene).SourceScene.Components.GetTrackedComponents("Celeste.Billboard"));
            if (StarEase < 1f) fog2.Draw(matrix3, CullCRasterizer);

            if (DrawDebugPoints && DebugPoints.Count > 0)
            {
                GraphicsResources.FxDebug.World = Matrix4x4.Identity;
                GraphicsResources.FxDebug.View = matrix2;
                GraphicsResources.FxDebug.Projection = matrix;
                GraphicsResources.FxDebug.TextureEnabled = false;
                GraphicsResources.FxDebug.VertexColorEnabled = true;
                var array = DebugPoints.ToArray();
                foreach (var pass in GraphicsResources.FxDebug.CurrentTechnique.Passes)
                {
                    pass.Apply();
                    Device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, array, 0, array.Length / 3);
                }
            }

            GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)EngineContext,
                buffer.Target, blurA, blurB, 0.75f, true, GaussianBlurSamples.Five);
        }

        protected void DrawBillboards(Matrix4x4 matrix, List<SourceComponentState> billboards)
        {
            var num = 0;
            var num2 = billboardInfo.Length / 4;
            var vector = SourceVector3Math.Transform(new(-1f, 0f, 0f),
                SourceQuaternionMath.Conjugate(SourceQuaternionMath.LookAt(Vector3.Zero, Forward, Vector3.UnitY,
                    VectorArithmetic)));
            var vector2 = SourceVector3Math.Transform(Vector3.UnitY,
                SourceQuaternionMath.Conjugate(SourceQuaternionMath.LookAt(Vector3.Zero, Forward, Vector3.UnitY,
                    VectorArithmetic)));
            foreach (BillboardState billboard in billboards)
            {
                if (!((ISourceEntityVisibility)billboard.Entity).Visible || !billboard.Visible) continue;

                if (billboard.BeforeRender != null) billboard.BeforeRender();

                if (billboard.Color.A >= 0 && billboard.Size.X != 0f && billboard.Size.Y != 0f &&
                    billboard.Scale.X != 0f &&
                    billboard.Scale.Y != 0f && billboard.Texture != null)
                {
                    if (num < num2)
                    {
                        var position = billboard.Position;
                        var vector3 = vector * billboard.Size.X * billboard.Scale.X;
                        var vector4 = vector2 * billboard.Size.Y * billboard.Scale.Y;
                        var vector5 = -vector3;
                        var vector6 = -vector4;
                        var num3 = num * 4;
                        var num4 = num * 4 + 1;
                        var num5 = num * 4 + 2;
                        var num6 = num * 4 + 3;
                        billboardInfo[num3].Color = billboard.Color;
                        billboardInfo[num3].TextureCoordinate.X = billboard.Texture.LeftUV;
                        billboardInfo[num3].TextureCoordinate.Y = billboard.Texture.BottomUV;
                        billboardInfo[num3].Position = position + vector3 + vector6;
                        billboardInfo[num4].Color = billboard.Color;
                        billboardInfo[num4].TextureCoordinate.X = billboard.Texture.LeftUV;
                        billboardInfo[num4].TextureCoordinate.Y = billboard.Texture.TopUV;
                        billboardInfo[num4].Position = position + vector3 + vector4;
                        billboardInfo[num5].Color = billboard.Color;
                        billboardInfo[num5].TextureCoordinate.X = billboard.Texture.RightUV;
                        billboardInfo[num5].TextureCoordinate.Y = billboard.Texture.TopUV;
                        billboardInfo[num5].Position = position + vector5 + vector4;
                        billboardInfo[num6].Color = billboard.Color;
                        billboardInfo[num6].TextureCoordinate.X = billboard.Texture.RightUV;
                        billboardInfo[num6].TextureCoordinate.Y = billboard.Texture.BottomUV;
                        billboardInfo[num6].Position = position + vector5 + vector6;
                        billboardTextures[num] = billboard.Texture.Texture.TextureSafe;
                    }

                    num++;
                }
            }

            ResetBillboardBuffers();
            if (num <= 0) return;

            billboardVertices.SetData(billboardInfo);
            Device.SetVertexBuffer(billboardVertices);
            Device.Indices = billboardIndices;
            Device.RasterizerState = CullNoneRasterizer;
            Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
            Device.BlendState = SourceBlendState.AlphaBlend;
            Device.DepthStencilState = SourceDepthStencilState.DepthRead;
            GraphicsResources.FxTexture.Parameters["World"].SetValue(matrix);
            var num7 = Math.Min(num, billboardInfo.Length / 4);
            var texture2D = billboardTextures[0];
            var num8 = 0;
            for (var i = 1; i < num7; i++)
                if (billboardTextures[i] != texture2D)
                {
                    DrawBillboardBatch(texture2D, num8, i - num8);
                    texture2D = billboardTextures[i];
                    num8 = i;
                }

            DrawBillboardBatch(texture2D, num8, num7 - num8);
            if (num * 4 > billboardInfo.Length)
            {
                billboardInfo = new SourceVertexPositionColorTexture[billboardInfo.Length * 2];
                billboardTextures = new SourceTexture2DResource[billboardInfo.Length / 4];
            }
        }

        private void DrawBillboardBatch(SourceTexture2DResource texture, int offset, int sprites)
        {
            Device.Textures[0] = texture;
            foreach (var pass in GraphicsResources.FxTexture.CurrentTechnique.Passes)
            {
                pass.Apply();
                Device.DrawIndexedPrimitives(SourcePrimitiveType.TriangleList, offset * 4, 0, sprites * 4, 0,
                    sprites * 2);
            }
        }

        public void Render()
        {
            var num = Metrics.ViewWidth / (float)buffer.Width;
            Context.BeginBatch(new(SourceSpriteSortMode.Deferred, SourceBlendState.AlphaBlend,
                SourceSamplerState.LinearClamp, null, null, null, Matrix4x4.Identity));
            ((ISourceRenderCommandSink<RenderTargetTextureDraw>)Context).Draw(
                new(buffer.Target, Vector2.Zero, buffer.Bounds,
                    Vector2.Zero, PackedColor.White * 1f, Vector2.One * num), this);
            ((ISourceRenderCommandSink<RenderTargetTextureDraw>)Context).Draw(
                new(blurB.Target, Vector2.Zero, blurB.Bounds,
                    Vector2.Zero,
                    PackedColor.White, Vector2.One * (num * 2f)), this);
            Context.EndBatch();
        }
    }
}

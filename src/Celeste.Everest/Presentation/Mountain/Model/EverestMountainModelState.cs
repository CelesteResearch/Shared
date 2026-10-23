using System;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;
using Celeste.Core.Display;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Core.Rendering.States;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Metadata.Mountain;
using Celeste.Everest.Runtime.Threading;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Presentation.Mountain.Model;
using Celeste.Game.Presentation.Mountain.Particles;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Graphics.Display.Colors;
using Celeste.Graphics.Effects.Blur;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Buffers;
using Celeste.Graphics.Rendering.Vertices;
using Celeste.Scene.Scenes;

namespace Celeste.Everest.Presentation.Mountain.Model
{
    public class EverestMountainModelState : MountainModelState
    {
        protected MountainRing customFog, customFog2;
        private MountainRing customStarsky, customStarfog, customStardots0;
        private MountainRing customStarstream0, customStarstream1, customStarstream2;
        private MoonParticle3DState vanillaMoonParticles, customMoonParticles;
        public string PreviousSID;
        protected float fade, fadeHoldCountdown;
        private PackedColor previousFogColor, targetFogColor;
        private float fogFade;
        private bool firstUpdate = true;
        private object _Billboard_QueuedLoadLock;
        private ValueTask<SourceVertexBuffer> _Billboard_QueuedLoad;

        private OriginalSaveDataState CurrentSave => ((IOriginalGameplayProcess)EngineContext).SaveContext.CurrentSave;

        private EverestMainThreadProcess MainThread =>
            ((ISourceEverestMainThreadEnvironment)EngineContext).MainThreadProcess;

        public EverestMountainModelState(ISourceEngineContext engine) : base(engine)
        {
            customFog = fog;
            customFog2 = fog2;
            customStarsky = starsky;
            customStarfog = starfog;
            customStardots0 = stardots0;
            customStarstream0 = starstream0;
            customStarstream1 = starstream1;
            customStarstream2 = starstream2;
        }

        public override void Update()
        {
            base.Update();
            string text;
            try
            {
                text = Path.Combine("Maps",
                    (CurrentSave is { } lastAreaSave1
                        ? ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSID(
                            ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection
                            .GetLastAreaSafe(
                                lastAreaSave1))
                        : null) ?? "").Replace('\\', '/');
            }
            catch (ArgumentException)
            {
                text = "Maps";
            }

            EverestMapMetadata meta;
            if (CurrentSave != null &&
                ((IEverestMountainContentEnvironment)EngineContext).Content.TryGet(text, out var metadata) &&
                metadata != null && (meta = metadata.GetMeta<EverestMapMetadata>()) != null && meta.Mountain != null &&
                hasCustomSettings(meta))
            {
                if (firstUpdate || PreviousSID == ((CurrentSave is { } lastAreaSave2
                        ? ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSID(
                            ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection
                            .GetLastAreaSafe(
                                lastAreaSave2))
                        : null) ?? ""))
                {
                    var array = ((IEverestMountainResourceEnvironment)EngineContext).MountainExtension
                        .MountainMappings[text].MountainStates;
                    var fogColor = ((array != null ? array[nextState] : null) ?? mountainStates[nextState])
                        .FogColor;
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (firstUpdate || fade == 1f)
                    {
                        targetFogColor = fogColor;
                        fogFade = 1f;
                    }
                    else if (fogColor != targetFogColor)
                    {
                        previousFogColor = customFog.TopColor;
                        targetFogColor = fogColor;
                        fogFade = 0f;
                    }

                    customFog.TopColor = customFog.BotColor =
                        SourceColorInterpolation.Lerp(previousFogColor, targetFogColor, fogFade, ScalarArithmetic);
                    fogFade = ScalarMath.Approach(fogFade, 1f, EngineContext.DeltaTime, ExtremaArithmetic);
                }

                customFog.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
                customFog2.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
                customFog2.TopColor = customFog2.BotColor = PackedColor.White * 0.3f * NearFogAlpha;
                customStarstream1.Rotate(EngineContext.DeltaTime * 0.01f);
                customStarstream2.Rotate(EngineContext.DeltaTime * 0.02f);
                customStarfog.Rotate((0f - EngineContext.DeltaTime) * 0.01f);
            }

            firstUpdate = false;
        }

        public override void ResetBillboardBuffers()
        {
            if (billboardVertices != null && !billboardIndices.IsDisposed &&
                !billboardIndices.GraphicsDevice.IsDisposed &&
                billboardVertices != null && !billboardVertices.IsDisposed &&
                !billboardVertices.GraphicsDevice.IsDisposed && billboardInfo.Length <= billboardVertices.VertexCount)
                return;

            var queuedLoadLock = _Billboard_QueuedLoadLock;
            if (queuedLoadLock != null)
            {
                lock (queuedLoadLock)
                {
                    if (_Billboard_QueuedLoadLock == null) return;

                    if (MainThread.IsMainThread) _Billboard_QueuedLoadLock = null;
                }

                if (!MainThread.IsMainThread)
                {
                    _ = _Billboard_QueuedLoad.Result;
                    return;
                }
            }

            if ((!((IEverestMountainThreadSettingsEnvironment)EngineContext).ThreadedGL ?? true) &&
                !MainThread.IsMainThread && queuedLoadLock == null)
                lock (queuedLoadLock = new())
                {
                    _Billboard_QueuedLoadLock = queuedLoadLock;
                    _Billboard_QueuedLoad = MainThread.Schedule(delegate
                    {
                        lock (queuedLoadLock)
                        {
                            if (_Billboard_QueuedLoadLock == null) return billboardVertices;

                            if (billboardVertices != null && !billboardVertices.IsDisposed) billboardVertices.Dispose();

                            if (billboardIndices != null && !billboardIndices.IsDisposed) billboardIndices.Dispose();

                            base.ResetBillboardBuffers();
                            _Billboard_QueuedLoadLock = null;
                            return billboardVertices;
                        }
                    });
                    return;
                }

            base.ResetBillboardBuffers();
        }

        public override void DisposeBillboardBuffers()
        {
            if (!MainThread.IsMainThread && ((billboardVertices != null && !billboardVertices.IsDisposed) ||
                                             (billboardIndices != null && !billboardIndices.IsDisposed)))
            {
                var billboardVerticesOld = billboardVertices;
                var billboardIndicesOld = billboardIndices;
                billboardVertices = null;
                billboardIndices = null;
                MainThread.Schedule(delegate
                {
                    if (billboardVerticesOld is { IsDisposed: false })
                        billboardVerticesOld.Dispose();

                    if (billboardIndicesOld is { IsDisposed: false }) billboardIndicesOld.Dispose();
                });
            }
            else
            {
                if (billboardVertices != null && !billboardVertices.IsDisposed) billboardVertices.Dispose();

                if (billboardIndices != null && !billboardIndices.IsDisposed) billboardIndices.Dispose();
            }
        }

        public override void BeforeRender(object scene)
        {
            if (vanillaMoonParticles == null)
                vanillaMoonParticles = (EngineContext.Frame.Scenes.CurrentScene as OverworldSequence)?.SourceScene
                    .Entities
                    .Entities.OfType<MoonParticle3DState>().First();

            string text;
            try
            {
                text = Path.Combine("Maps",
                    (CurrentSave is { } lastAreaSave3
                        ? ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSID(
                            ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection
                            .GetLastAreaSafe(
                                lastAreaSave3))
                        : null) ?? "").Replace('\\', '/');
            }
            catch (ArgumentException)
            {
                text = "Maps";
            }

            var text2 = (CurrentSave is { } lastAreaSave4
                ? ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSID(
                    ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection.GetLastAreaSafe(
                        lastAreaSave4))
                : null) ?? "";
            var flag = true;
            if (PreviousSID != null && !((CurrentSave is { } lastAreaSave5
                    ? ((IOriginalAreaKeyEnvironment)EngineContext).AreaKeys.GetSID(
                        ((IOriginalSaveSessionSelectionEnvironment)EngineContext).SaveSessionSelection.GetLastAreaSafe(
                            lastAreaSave5))
                    : null) ?? "").Equals(PreviousSID))
            {
                MapMetaMountain mapMetaMountain = null;
                MapMetaMountain mapMetaMountain2 = null;
                EverestMapMetadata meta;
                if (CurrentSave != null &&
                    ((IEverestMountainContentEnvironment)EngineContext).Content.TryGet(text, out var metadata) &&
                    metadata != null && (meta = metadata.GetMeta<EverestMapMetadata>()) != null &&
                    meta.Mountain != null)
                    mapMetaMountain2 = meta.Mountain;

                string text3;
                try
                {
                    text3 = Path.Combine("Maps", PreviousSID ?? "").Replace('\\', '/');
                }
                catch (ArgumentException)
                {
                    text3 = "Maps";
                }

                EverestMapMetadata meta2;
                if (CurrentSave != null &&
                    ((IEverestMountainContentEnvironment)EngineContext).Content.TryGet(text3, out metadata) &&
                    metadata != null && (meta2 = metadata.GetMeta<EverestMapMetadata>()) != null &&
                    meta2.Mountain != null)
                    mapMetaMountain = meta2.Mountain;

                if (mapMetaMountain?.MountainModelDirectory != mapMetaMountain2?.MountainModelDirectory ||
                    mapMetaMountain?.MountainTextureDirectory != mapMetaMountain2?.MountainTextureDirectory ||
                    mapMetaMountain?.FogColors == null != (mapMetaMountain2?.FogColors == null) ||
                    mapMetaMountain?.StarFogColor != mapMetaMountain2?.StarFogColor ||
                    (mapMetaMountain?.ShowSnow ?? true) != (mapMetaMountain2?.ShowSnow ?? true) ||
                    !arrayEqual(mapMetaMountain?.StarStreamColors, mapMetaMountain2?.StarStreamColors) ||
                    !arrayEqual(mapMetaMountain?.StarBeltColors1, mapMetaMountain2?.StarBeltColors1) ||
                    !arrayEqual(mapMetaMountain?.StarBeltColors2, mapMetaMountain2?.StarBeltColors2))
                {
                    // ReSharper disable once CompareOfFloatsByEqualityOperator
                    if (fade != 1f)
                    {
                        text2 = PreviousSID;
                        text = text3;
                        fade = ScalarMath.Approach(fade, 1f, EngineContext.DeltaTime * 4f, ExtremaArithmetic);
                        flag = false;
                    }
                    else
                    {
                        fadeHoldCountdown = 0.3f;
                    }
                }
            }

            if (flag && fade != 0f)
            {
                if (fadeHoldCountdown <= 0f)
                    fade = ScalarMath.Approach(fade, 0f, EngineContext.DeltaTime * 4f, ExtremaArithmetic);
                else
                    fadeHoldCountdown -= EngineContext.DeltaTime;
            }

            EverestMapMetadata meta3;
            if (CurrentSave != null &&
                ((IEverestMountainContentEnvironment)EngineContext).Content.TryGet(text, out var metadata2) &&
                metadata2 != null && (meta3 = metadata2.GetMeta<EverestMapMetadata>()) != null &&
                meta3.Mountain != null &&
                hasCustomSettings(meta3))
            {
                var mountainResources =
                    ((IEverestMountainResourceEnvironment)EngineContext).MountainExtension.MountainMappings[text];
                ResetRenderTargets();
                var rotation = Camera.Rotation;
                if (ignoreCameraRotation) rotation = lastCameraRotation;

                var matrix = SourceMatrixMath.CreatePerspectiveFieldOfView(MathF.PI / 4f,
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
                        SourceMatrixMath.Multiply(
                            SourceMatrixMath.CreateTranslation(0f, 5f - Camera.Position.Y * 1.1f, 0f),
                            SourceMatrixMath.CreateFromQuaternion(rotation)), matrix);
                    if (currState == nextState)
                    {
                        var array = mountainResources.MountainStates;
                        ((array != null ? array[currState] : null) ?? mountainStates[currState]).Skybox.Draw(matrix4,
                            PackedColor.White);
                    }
                    else
                    {
                        var array2 = mountainResources.MountainStates;
                        ((array2 != null ? array2[currState] : null) ?? mountainStates[currState]).Skybox.Draw(
                            matrix4,
                            PackedColor.White);
                        var array3 = mountainResources.MountainStates;
                        ((array3 != null ? array3[nextState] : null) ?? mountainStates[nextState]).Skybox.Draw(
                            matrix4,
                            PackedColor.White * easeState);
                    }

                    if (currState != nextState)
                    {
                        GraphicsResources.FxMountain.Parameters["ease"].SetValue(easeState);
                        GraphicsResources.FxMountain.CurrentTechnique =
                            GraphicsResources.FxMountain.Techniques["Easing"];
                    }
                    else
                    {
                        GraphicsResources.FxMountain.CurrentTechnique =
                            GraphicsResources.FxMountain.Techniques["Single"];
                    }

                    Device.DepthStencilState = SourceDepthStencilState.Default;
                    Device.BlendState = SourceBlendState.AlphaBlend;
                    Device.RasterizerState = MountainRasterizer;
                    GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                    GraphicsResources.FxMountain.Parameters["fog"].SetValue(customFog.TopColor.ToVector3());
                    var textures = Device.Textures;
                    var array4 = mountainResources.MountainStates;
                    textures[0] =
                        ((array4 != null ? array4[currState] : null) ??
                         mountainStates[currState]).TerrainTexture.TextureSafe;
                    Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                    if (currState != nextState)
                    {
                        var textures2 = Device.Textures;
                        var array5 = mountainResources.MountainStates;
                        textures2[1] =
                            ((array5 != null ? array5[nextState] : null) ??
                             mountainStates[nextState]).TerrainTexture.TextureSafe;
                        Device.SamplerStates[1] = SourceSamplerState.LinearClamp;
                    }

                    (mountainResources.MountainTerrain ?? MountainResources.MountainTerrain).Draw(GraphicsResources
                        .FxMountain);
                    GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(
                        SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(CoreWallPosition), matrix3));
                    (mountainResources.MountainCoreWall ?? MountainResources.MountainCoreWall).Draw(GraphicsResources
                        .FxMountain);
                    GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                    for (var i = 0; i < mountainResources.MountainExtraModels.Count; i++)
                    {
                        Device.Textures[0] =
                            (mountainResources.MountainExtraModelTextures[i][currState] ??
                             mountainStates[currState].TerrainTexture).TextureSafe;
                        Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                        if (currState != nextState)
                        {
                            Device.Textures[1] =
                                (mountainResources.MountainExtraModelTextures[i][nextState] ??
                                 mountainStates[nextState].TerrainTexture).TextureSafe;
                            Device.SamplerStates[1] = SourceSamplerState.LinearClamp;
                        }

                        mountainResources.MountainExtraModels[i].Draw(GraphicsResources.FxMountain);
                    }

                    GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                    var textures3 = Device.Textures;
                    var array6 = mountainResources.MountainStates;
                    textures3[0] =
                        ((array6 != null ? array6[currState] : null) ??
                         mountainStates[currState]).BuildingsTexture.TextureSafe;
                    Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                    if (currState != nextState)
                    {
                        var textures4 = Device.Textures;
                        var array7 = mountainResources.MountainStates;
                        textures4[1] =
                            ((array7 != null ? array7[nextState] : null) ??
                             mountainStates[nextState]).BuildingsTexture.TextureSafe;
                        Device.SamplerStates[1] = SourceSamplerState.LinearClamp;
                    }

                    (mountainResources.MountainBuildings ?? MountainResources.MountainBuildings).Draw(GraphicsResources
                        .FxMountain);
                    customFog.Draw(matrix3);
                }

                if (StarEase > 0f)
                {
                    Context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                        SourceBlendState.AlphaBlend, SourceSamplerState.LinearClamp, null, null, null,
                        Matrix4x4.Identity));
                    SourcePrimitiveDrawing.Rect(Context, this, 0f, 0f, buffer.Width, buffer.Height,
                        PackedColor.Black * EasingArithmetic.CubeInOut(ScalarMath.ClampedMap(StarEase, 0f, 0.6f)));
                    Context.EndBatch();
                    var matrix5 = SourceMatrixMath.Multiply(
                        SourceMatrixMath.Multiply(SourceMatrixMath.CreateTranslation(starCenter - Camera.Position),
                            SourceMatrixMath.CreateFromQuaternion(rotation)), matrix);
                    var alpha = ScalarMath.ClampedMap(StarEase, 0.8f, 1f);
                    customStarsky.Draw(matrix5, CullCCRasterizer, alpha);
                    customStarfog.Draw(matrix5, CullCCRasterizer, alpha);
                    customStardots0.Draw(matrix5, CullCCRasterizer, alpha);
                    customStarstream0.Draw(matrix5, CullCCRasterizer, alpha);
                    customStarstream1.Draw(matrix5, CullCCRasterizer, alpha);
                    customStarstream2.Draw(matrix5, CullCCRasterizer, alpha);
                    Device.DepthStencilState = SourceDepthStencilState.Default;
                    Device.BlendState = SourceBlendState.AlphaBlend;
                    Device.RasterizerState = CullCRasterizer;
                    Device.Textures[0] =
                        (mountainResources.MountainMoonTexture ??
                         MountainResources.MountainMoonTexture).TextureSafe;
                    Device.SamplerStates[0] = SourceSamplerState.LinearClamp;
                    GraphicsResources.FxMountain.CurrentTechnique = GraphicsResources.FxMountain.Techniques["Single"];
                    GraphicsResources.FxMountain.Parameters["WorldViewProj"].SetValue(matrix3);
                    GraphicsResources.FxMountain.Parameters["fog"].SetValue(fog.TopColor.ToVector3());
                    (mountainResources.MountainMoon ?? MountainResources.MountainMoon).Draw(
                        GraphicsResources.FxMountain);
                    var num = birdTimer * 0.2f;
                    var matrix6 = SourceMatrixMath.Multiply(
                        SourceMatrixMath.Multiply(
                            SourceMatrixMath.Multiply(
                                SourceMatrixMath.Multiply(SourceMatrixMath.CreateScale(0.25f),
                                    SourceMatrixMath.CreateRotationZ((float)Math.Cos(num * 2f) * 0.5f)),
                                SourceMatrixMath.CreateRotationX(0.4f + (float)Math.Sin(num) * 0.05f)),
                            SourceMatrixMath.CreateRotationY(0f - num - MathF.PI / 2f)),
                        SourceMatrixMath.CreateTranslation((float)Math.Cos(num) * 2.2f,
                            31f + (float)Math.Sin(num * 2f) * 0.8f, (float)Math.Sin(num) * 2.2f));
                    GraphicsResources.FxMountain.Parameters["WorldViewProj"]
                        .SetValue(SourceMatrixMath.Multiply(matrix6, matrix3));
                    GraphicsResources.FxMountain.Parameters["fog"].SetValue(fog.TopColor.ToVector3());
                    (mountainResources.MountainBird ?? MountainResources.MountainBird).Draw(
                        GraphicsResources.FxMountain);
                }

                DrawBillboards(matrix3,
                    ((SourceSceneState)scene).SourceScene.Components.GetTrackedComponents("Celeste.Billboard"));
                if (StarEase < 1f) customFog2.Draw(matrix3, CullCRasterizer);

                if (DrawDebugPoints && DebugPoints.Count > 0)
                {
                    GraphicsResources.FxDebug.World = Matrix4x4.Identity;
                    GraphicsResources.FxDebug.View = matrix2;
                    GraphicsResources.FxDebug.Projection = matrix;
                    GraphicsResources.FxDebug.TextureEnabled = false;
                    GraphicsResources.FxDebug.VertexColorEnabled = true;
                    var array8 = DebugPoints.ToArray();
                    foreach (var pass in GraphicsResources.FxDebug.CurrentTechnique.Passes)
                    {
                        pass.Apply();
                        Device.DrawUserPrimitives(SourcePrimitiveType.TriangleList, array8, 0, array8.Length / 3);
                    }
                }

                GaussianBlurPresentation.Blur((ISourceGaussianBlurEnvironment)EngineContext,
                    buffer.Target, blurA, blurB, 0.75f, true, GaussianBlurSamples.Five);
                Context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearClamp, null, null, null, Matrix4x4.Identity));
                SourcePrimitiveDrawing.Rect(Context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade);
                Context.EndBatch();
                if (!text2.Equals(PreviousSID))
                {
                    var botColor = customFog?.TopColor ?? PackedColor.White;
                    var x = customFog.Verts[1].TextureCoordinate.X;
                    customFog = new(EngineContext, 6f, -1f, 20f, 0f, 24, PackedColor.White,
                        mountainResources.MountainFogTexture ?? MountainResources.MountainFogTexture);
                    customFog2 = new(EngineContext, 6f, -4f, 10f, 0f, 24, PackedColor.White,
                        mountainResources.MountainFogTexture ?? MountainResources.MountainFogTexture);
                    customStarsky = new(EngineContext, 18f, -18f, 20f, 0f, 24, PackedColor.White,
                        PackedColor.Transparent,
                        mountainResources.MountainSpaceTexture ?? MountainResources.MountainStarSky);
                    customStarfog = new(EngineContext, 10f, -18f, 19.5f, 0f, 24,
                        mountainResources.StarFogColor ?? new PackedColor(2, 9, 21), PackedColor.Transparent,
                        mountainResources.MountainFogTexture ?? MountainResources.MountainFogTexture);
                    customStardots0 = new(EngineContext, 16f, -18f, 19f, 0f, 24, PackedColor.White,
                        PackedColor.Transparent,
                        mountainResources.MountainSpaceStarsTexture ?? MountainResources.MountainStars, 4f);
                    var starStreamColors = mountainResources.StarStreamColors;
                    customStarstream0 = new(EngineContext, 5f, -8f, 18.5f, 0.2f, 80,
                        starStreamColors != null ? starStreamColors[0] : PackedColor.Black,
                        mountainResources.MountainStarStreamTexture ?? MountainResources.MountainStarStream);
                    var starStreamColors2 = mountainResources.StarStreamColors;
                    customStarstream1 = new(EngineContext, 4f, -6f, 18f, 1f, 80,
                        starStreamColors2 != null ? starStreamColors2[1] : new PackedColor(146, 40, 226) * 0.5f,
                        mountainResources.MountainStarStreamTexture ?? MountainResources.MountainStarStream);
                    var starStreamColors3 = mountainResources.StarStreamColors;
                    customStarstream2 = new(EngineContext, 3f, -4f, 17.9f, 1.4f, 80,
                        starStreamColors3 != null ? starStreamColors3[2] : new PackedColor(48, 255, 255) * 0.5f,
                        mountainResources.MountainStarStreamTexture ?? MountainResources.MountainStarStream);
                    customFog.TopColor = customFog.BotColor = botColor;
                    customFog.Rotate(x);
                    customFog2.Rotate(x);
                    if (EngineContext.Frame.Scenes.CurrentScene is OverworldSequence overworld)
                    {
                        overworld.RemoveEntity(customMoonParticles);
                        if (mountainResources.StarBeltColors1 != null && mountainResources.StarBeltColors2 != null)
                        {
                            overworld.RemoveEntity(vanillaMoonParticles);
                            overworld.AddEntity(customMoonParticles = new(this,
                                new(0f, 31f, 0f), mountainResources.StarBeltColors1,
                                mountainResources.StarBeltColors2));
                        }
                        else
                        {
                            customMoonParticles = null;
                            overworld.AddEntity(vanillaMoonParticles);
                        }
                    }
                }

                PreviousSID = text2;
            }
            else
            {
                if (customMoonParticles != null &&
                    EngineContext.Frame.Scenes.CurrentScene is OverworldSequence overworld2)
                {
                    overworld2.RemoveEntity(customMoonParticles);
                    customMoonParticles = null;
                    overworld2.AddEntity(vanillaMoonParticles);
                }

                base.BeforeRender(scene);
                Context.BeginBatch(new(SourceSpriteSortMode.Deferred,
                    SourceBlendState.AlphaBlend,
                    SourceSamplerState.LinearClamp, null, null, null, Matrix4x4.Identity));
                SourcePrimitiveDrawing.Rect(Context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * fade);
                Context.EndBatch();
                PreviousSID = text2;
            }
        }

        private static bool hasCustomSettings(EverestMapMetadata meta)
        {
            if (string.IsNullOrEmpty(meta.Mountain.MountainModelDirectory) &&
                string.IsNullOrEmpty(meta.Mountain.MountainTextureDirectory) && meta.Mountain.FogColors == null &&
                string.IsNullOrEmpty(meta.Mountain.StarFogColor) && meta.Mountain.StarStreamColors == null)
            {
                if (meta.Mountain.StarBeltColors1 != null) return meta.Mountain.StarBeltColors2 != null;

                return false;
            }

            return true;
        }

        private bool arrayEqual(string[] array1, string[] array2)
        {
            if (array1 == null || array2 == null) return array1 == array2;

            return array1.SequenceEqual(array2);
        }
    }
}

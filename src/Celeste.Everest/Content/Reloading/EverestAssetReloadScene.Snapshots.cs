using Celeste.Core.Display;
using System;
using Celeste.Core.Rendering;
using Celeste.Core.Geometry;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Core.Scheduling;
using Celeste.Core.Mathematics.Framework;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Engine.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Textures;
using global::Celeste.Game.Execution;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadScene
    {
        private void CaptureSnapshots(ISourceSceneExecution scene)
        {
            var device = ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice;
            var viewport = ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Viewport;
            var previousViewport = device.Viewport;
            int width = viewport.Width;
            int height = viewport.Height;
            PackedColor[] pixels = new PackedColor[width * height];
            try
            {
                ((ISourceSceneRenderExecution)scene).BeforeRender();
                device.Viewport = viewport;
                device.SetRenderTarget((SourceRenderTarget2DResource)null);
                device.Clear(EngineRuntime.ClearColor);
                ((ISourceSceneRenderExecution)scene).Render();
                ((ISourceSceneRenderExecution)scene).AfterRender();
                device.GetBackBufferData(new IntRect(viewport.X, viewport.Y, viewport.Width, viewport.Height), pixels,
                    0,
                    pixels.Length);
            }
            catch (Exception exception)
            {
                process.Logger.Log(EverestLogLevel.Warn, "reload",
                    "Failed to render original scene for reload snapshot:");
                process.Logger.LogDetailed(exception, "reload");
            }
            finally
            {
                device.SetRenderTarget((SourceRenderTarget2DResource)null);
                device.Viewport = previousViewport;
                try
                {
                    ((ISourceDrawScope)((ISourceRenderEnvironment)EngineContext).CurrentContext).Draw.SpriteBatch.End();
                }
                catch
                {
                }
            }

            snapshotTex?.Dispose();
            snapshotTex = new SourceTexture2DResource(device, width, height, false, SourceSurfaceFormat.Color);
            snapshotTex.SetData(pixels);
            for (int i = 0; i < pixels.Length; i++)
            {
                PackedColor color = pixels[i];
                int gray = SourceFrameworkMath.Clamp((int)((float)(int)color.R * .3f +
                                                           (float)(int)color.G * .59f + (float)(int)color.B * .11f), 0,
                    255);
                pixels[i] = new PackedColor(gray, gray, gray, color.A);
            }

            snapshotGrayScaleTex?.Dispose();
            snapshotGrayScaleTex = new SourceTexture2DResource(device, width, height, false, SourceSurfaceFormat.Color);
            snapshotGrayScaleTex.SetData(pixels);
        }
    }
}

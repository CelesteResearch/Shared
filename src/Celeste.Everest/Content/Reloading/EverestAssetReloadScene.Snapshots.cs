using System;
using Celeste.Core.Display;
using Celeste.Core.Geometry;
using Celeste.Core.Mathematics.Framework;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Engine;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Everest.Content.Reloading
{
    public sealed partial class EverestAssetReloadScene
    {
        private void CaptureSnapshots(ISourceSceneExecution scene)
        {
            var device = ((ISourceGraphicsDeviceEnvironment)EngineContext).GraphicsDevice;
            var viewport = ((IOriginalEngineGraphicsEnvironment)EngineContext).EngineGraphics.Viewport;
            var previousViewport = device.Viewport;
            var width = viewport.Width;
            var height = viewport.Height;
            var pixels = new PackedColor[width * height];
            try
            {
                ((ISourceSceneRenderExecution)scene).BeforeRender();
                device.Viewport = viewport;
                device.SetRenderTarget(null);
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
                device.SetRenderTarget(null);
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
            snapshotTex = new(device, width, height, false, SourceSurfaceFormat.Color);
            snapshotTex.SetData(pixels);
            for (var i = 0; i < pixels.Length; i++)
            {
                var color = pixels[i];
                var gray = SourceFrameworkMath.Clamp((int)(color.R * .3f +
                                                           color.G * .59f + color.B * .11f), 0,
                    255);
                pixels[i] = new(gray, gray, gray, color.A);
            }

            snapshotGrayScaleTex?.Dispose();
            snapshotGrayScaleTex = new(device, width, height, false, SourceSurfaceFormat.Color);
            snapshotGrayScaleTex.SetData(pixels);
        }
    }
}

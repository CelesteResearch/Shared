using Celeste.Core.Display;
using System;
using Celeste.Game.Execution.Engine.Rendering;
using Celeste.Core.Rendering;
using Celeste.Graphics.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;
using Celeste.Graphics.Rendering.Textures;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalEngineDrawEnvironment, IOriginalEngineRenderDevice
    {
        private OriginalCelesteDraw sourceEngineDraw;

        public OriginalCelesteDraw EngineDraw => sourceEngineDraw ??
                                                 throw new InvalidOperationException(
                                                     "The actual shared Engine draw is not constructed.");

        public void ConstructSourceEngineDraw()
        {
            if (sourceEngineDraw != null)
                throw new InvalidOperationException("The actual shared Engine draw is already constructed.");
            sourceEngineDraw = new OriginalCelesteDraw(Frame.Scenes, ActualGame.Framework,
                ((Celeste.Framework.Diagnostics.Commands.ISourceCommandsProcessEnvironment)this).Commands,
                this, (ISourceRenderEnvironment)this);
        }

        void IOriginalEngineRenderDevice.SetBackBuffer() =>
            GraphicsDevice.SetRenderTarget((SourceRenderTarget2DResource)null);

        void IOriginalEngineRenderDevice.SetViewport(CameraViewport viewport) => GraphicsDevice.Viewport = viewport;
        void IOriginalEngineRenderDevice.Clear(PackedColor color) => GraphicsDevice.Clear(color);
    }
}

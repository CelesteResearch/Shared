using System;
using Celeste.Core.Display;
using Celeste.Game.Execution.Engine.Rendering;
using Celeste.Graphics.Geometry.TwoD.Camera;

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
            sourceEngineDraw = new(Frame.Scenes, ActualGame.Framework,
                Commands,
                this, this);
        }

        void IOriginalEngineRenderDevice.SetBackBuffer()
        {
            GraphicsDevice.SetRenderTarget(null);
        }

        void IOriginalEngineRenderDevice.SetViewport(CameraViewport viewport)
        {
            GraphicsDevice.Viewport = viewport;
        }

        void IOriginalEngineRenderDevice.Clear(PackedColor color)
        {
            GraphicsDevice.Clear(color);
        }
    }
}

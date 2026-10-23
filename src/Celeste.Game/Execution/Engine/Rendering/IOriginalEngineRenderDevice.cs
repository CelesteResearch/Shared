using Celeste.Core.Display;
using Celeste.Graphics.Geometry.TwoD.Camera;

namespace Celeste.Game.Execution.Engine.Rendering
{
    public interface IOriginalEngineRenderDevice
    {
        void SetBackBuffer();
        void SetViewport(CameraViewport viewport);
        void Clear(PackedColor color);
    }
}

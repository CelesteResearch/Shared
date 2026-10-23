using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Rendering.Offscreen;

public interface IOffscreenGraphicsBackendFactory
{
    IOffscreenGraphicsBackend Create(ISourceSDLHintDevice hints, GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation);
}

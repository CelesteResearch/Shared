using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D11.Offscreen;

public sealed class Direct3D11OffscreenGraphicsBackendFactory : IOffscreenGraphicsBackendFactory
{
    public static Direct3D11OffscreenGraphicsBackendFactory Instance { get; } = new();

    private Direct3D11OffscreenGraphicsBackendFactory()
    {
    }

    public IOffscreenGraphicsBackend Create(ISourceSDLHintDevice hints, GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation) =>
        new Direct3D11OffscreenGraphicsBackend(hints, dispatcher, presentation);
}

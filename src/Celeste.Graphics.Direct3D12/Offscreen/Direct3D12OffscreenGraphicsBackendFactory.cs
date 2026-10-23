using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Direct3D12.Offscreen;

public sealed class Direct3D12OffscreenGraphicsBackendFactory : IOffscreenGraphicsBackendFactory
{
    public static Direct3D12OffscreenGraphicsBackendFactory Instance { get; } = new();

    private Direct3D12OffscreenGraphicsBackendFactory()
    {
    }

    public IOffscreenGraphicsBackend Create(ISourceSDLHintDevice hints, GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation) =>
        new Direct3D12OffscreenGraphicsBackend(dispatcher, presentation);
}

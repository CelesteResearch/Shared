using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Offscreen;
using Celeste.Graphics.Threading;

namespace Celeste.Graphics.Vulkan.Offscreen;

public sealed class VulkanOffscreenGraphicsBackendFactory : IOffscreenGraphicsBackendFactory
{
    public static VulkanOffscreenGraphicsBackendFactory Instance { get; } = new();

    private VulkanOffscreenGraphicsBackendFactory()
    {
    }

    public IOffscreenGraphicsBackend Create(ISourceSDLHintDevice hints, GraphicsOwnerDispatcher dispatcher,
        IOffscreenGraphicsPresentation presentation) => new VulkanOffscreenGraphicsBackend(dispatcher, presentation);
}

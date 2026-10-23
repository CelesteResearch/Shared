using System;
using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Rendering.Offscreen;

namespace Celeste.Hosting.Runtime.Graphics
{
    public sealed class RgbaEmbeddedGraphicsSessionFactory : IEmbeddedGraphicsSessionFactory
    {
        private readonly IOffscreenGraphicsBackendFactory _backendFactory;

        public RgbaEmbeddedGraphicsSessionFactory(IOffscreenGraphicsBackendFactory backendFactory)
        {
            _backendFactory = backendFactory ?? throw new ArgumentNullException(nameof(backendFactory));
        }

        public IEmbeddedGraphicsSession Create(ISourceHostWindowIO window, ISourceSDLHintDevice hints, int ownerThread)
        {
            return new RgbaEmbeddedGraphicsSession(window, hints, ownerThread, _backendFactory);
        }
    }
}

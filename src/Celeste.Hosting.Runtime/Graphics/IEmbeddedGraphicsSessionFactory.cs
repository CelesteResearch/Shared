using Celeste.Core.IO.Platform.SDL;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Hosting.Runtime.Graphics
{
    public interface IEmbeddedGraphicsSessionFactory
    {
        // Called by the game session on its owner thread, including background sessions.
        IEmbeddedGraphicsSession Create(ISourceHostWindowIO window, ISourceSDLHintDevice hints, int ownerThread);
    }
}

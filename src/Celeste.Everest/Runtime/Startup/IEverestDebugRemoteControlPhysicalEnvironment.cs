using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Everest.Runtime.Startup
{
    public interface IEverestDebugRemoteControlPhysicalEnvironment
    {
        SourceGameWindow Window { get; }
        ISourceWindowFocusIO WindowFocus { get; }
    }
}

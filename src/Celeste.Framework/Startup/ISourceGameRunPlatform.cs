using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Startup
{
    public interface ISourceGameRunPlatform
    {
        SourceGraphicsAdapter RegisterGame(SourceGameProcess actualGame);
        void UnregisterGame(SourceGameProcess actualGame);
        bool GetTouchDeviceConnected();
        bool NeedsPlatformMainLoop();
        void RunPlatformMainLoop(SourceGameProcess actualGame);
        void OnIsMouseVisibleChanged(bool visible);
    }
}

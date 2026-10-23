namespace Celeste.Core.Framework.Startup
{
    public interface ISourceGameHostRuntimeIO
    {
        bool GetTouchDeviceConnected();
        void SetMouseVisible(bool visible);
    }
}

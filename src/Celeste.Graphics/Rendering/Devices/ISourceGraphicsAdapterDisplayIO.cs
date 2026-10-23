namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGraphicsAdapterDisplayIO
    {
        int GetNumVideoDisplays();
        int GetNumDisplayModes(int displayIndex);
        void GetDisplayMode(int displayIndex, int modeIndex, out SourceNativeDisplayMode mode);
        void GetCurrentDisplayMode(int displayIndex, out SourceNativeDisplayMode mode);
        string GetDisplayName(int displayIndex);
    }
}

using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Hosting.Runtime.Platform
{
    public sealed class VirtualDisplayDevice : ISourceGraphicsAdapterDisplayIO
    {
        private readonly EmbeddedGameConfiguration _configuration;

        public VirtualDisplayDevice(EmbeddedGameConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetNumVideoDisplays()
        {
            return 1;
        }

        public int GetNumDisplayModes(int displayIndex)
        {
            return 1;
        }

        public void GetDisplayMode(int displayIndex, int modeIndex, out SourceNativeDisplayMode mode)
        {
            GetCurrentDisplayMode(displayIndex, out mode);
        }

        public void GetCurrentDisplayMode(int displayIndex, out SourceNativeDisplayMode mode)
        {
            mode = new()
            {
                w = _configuration.Width,
                h = _configuration.Height,
                refresh_rate = 60,
            };
        }

        public string GetDisplayName(int displayIndex)
        {
            return "Embedded Celeste";
        }
    }
}

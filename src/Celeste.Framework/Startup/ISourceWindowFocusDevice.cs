using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Framework.Startup
{
    public interface ISourceWindowFocusDevice
    {
        string GetEnvironmentVariable(string name);
        void SetHint(string name, string value);
        void RaiseWindow(System.IntPtr window);
    }
}

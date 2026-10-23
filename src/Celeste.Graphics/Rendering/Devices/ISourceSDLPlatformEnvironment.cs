using System.Reflection;

namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceSDLPlatformEnvironment
    {
        string OSVersion { get; }
        string TitleLocation { get; }
        string FriendlyName { get; }
        Assembly EntryAssembly { get; }
    }
}

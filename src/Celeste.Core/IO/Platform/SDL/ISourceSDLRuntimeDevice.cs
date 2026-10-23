namespace Celeste.Core.IO.Platform.SDL
{
    public interface ISourceSDLRuntimeDevice
    {
        string GetPlatform();
        string GetPrefPath(string organization, string application);
    }
}

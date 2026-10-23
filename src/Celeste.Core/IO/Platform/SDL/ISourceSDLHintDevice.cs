namespace Celeste.Core.IO.Platform.SDL
{
    // A physical SDL query; the existing SDL hint store remains its sole owner.
    public interface ISourceSDLHintDevice
    {
        bool GetHintBoolean(string name, bool defaultValue);
    }
}

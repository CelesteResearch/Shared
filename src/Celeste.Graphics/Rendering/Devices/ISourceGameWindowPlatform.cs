namespace Celeste.Graphics.Rendering.Devices
{
    public interface ISourceGameWindowPlatform : ISourceGraphicsManagerPlatform
    {
        SourceGameWindow CreateWindow();
        void DisposeWindow(SourceGameWindow window);
    }
}

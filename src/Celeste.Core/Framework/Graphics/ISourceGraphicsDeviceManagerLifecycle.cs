namespace Celeste.Core.Framework.Graphics
{
    public interface ISourceGraphicsDeviceManagerLifecycle
    {
        void CreateDevice();
        bool BeginDraw();
        void EndDraw();
    }
}

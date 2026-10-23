namespace Celeste.Core.Framework.Graphics
{
    // These properties belong to the actual shared graphics manager/device/adapter.
    // ApplyChanges must execute its shared framework source body, not a native whole
    // callback. Native output is consumed below that framework body.
    public interface ISourceScreenGraphicsManager
    {
        int PreferredBackBufferWidth { get; set; }
        int PreferredBackBufferHeight { get; set; }
        bool IsFullScreen { get; set; }
        ISourceScreenGraphicsDevice GraphicsDevice { get; }
        void ApplyChanges();
    }
}

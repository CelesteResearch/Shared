namespace Celeste.Core.Rendering
{
    // Resource creation and disposal belong to the actual logical Engine device.
    public interface ISourceRenderTargetFactory
    {
        object Create(string name, int width, int height);
        void Dispose(object target);
    }
}

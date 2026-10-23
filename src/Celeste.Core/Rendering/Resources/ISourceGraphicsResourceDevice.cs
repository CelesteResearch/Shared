namespace Celeste.Core.Rendering.Resources
{
    public interface ISourceGraphicsResourceDevice
    {
        bool IsDisposed { get; }
        SourceGraphicsResourceReferences ResourceReferences { get; }
    }
}

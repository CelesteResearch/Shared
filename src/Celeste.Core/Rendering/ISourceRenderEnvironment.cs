namespace Celeste.Core.Rendering
{
    // One logical Engine owns this render IO capability. It is not a Scene or view binding.
    public interface ISourceRenderEnvironment
    {
        ISourceRenderContext CurrentContext { get; }
    }
}

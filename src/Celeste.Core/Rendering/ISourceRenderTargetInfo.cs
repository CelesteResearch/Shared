namespace Celeste.Core.Rendering
{
    // Query the actual Engine resource; no copied dimensions or disposed flags.
    public interface ISourceRenderTargetInfo
    {
        int Width(object target);
        int Height(object target);
        bool IsDisposed(object target);
    }
}

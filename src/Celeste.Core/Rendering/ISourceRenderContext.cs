namespace Celeste.Core.Rendering
{
    public interface ISourceRenderContext
    {
        ISourceGraphicsContext Graphics { get; }
        void BeginBatch(in SourceRenderBatchState state);
        void EndBatch();
    }
}

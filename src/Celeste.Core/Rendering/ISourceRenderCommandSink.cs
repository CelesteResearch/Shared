namespace Celeste.Core.Rendering
{
    public interface ISourceRenderCommandSink<T>
    {
        void Draw(in T payload, object actualEntity);
    }
}

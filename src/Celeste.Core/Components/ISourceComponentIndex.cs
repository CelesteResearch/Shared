namespace Celeste.Core.Components
{
    public interface ISourceComponentIndex
    {
        void Track(SourceComponentState component);
        void Untrack(SourceComponentState component);
    }
}

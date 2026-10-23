namespace Celeste.Core.Framework.GarbageCollection
{
    public interface ISourceGarbageCollectionEnvironment
    {
        ISourceGarbageCollectionPolicy GarbageCollectionPolicy { get; }
    }
}

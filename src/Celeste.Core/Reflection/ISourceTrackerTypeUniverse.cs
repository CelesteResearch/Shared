namespace Celeste.Core.Reflection
{
    public interface ISourceTrackerTypeUniverse
    {
        ISourceTypeMetadata[] GetTypes();
        ISourceTypeMetadata EntityType { get; }
        ISourceTypeMetadata ComponentType { get; }
    }
}

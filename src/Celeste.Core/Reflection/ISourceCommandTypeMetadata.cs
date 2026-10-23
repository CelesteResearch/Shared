namespace Celeste.Core.Reflection
{
    public interface ISourceCommandTypeMetadata
    {
        ISourceCommandMethodMetadata[] GetDeclaredStaticMethods();
    }
}

namespace Celeste.Core.Reflection
{
    // A source metadata scope; explicitly not System.Reflection.Assembly.
    public interface ISourceAssemblyMetadata
    {
        string Identity { get; }
        ISourceTypeMetadata[] GetTypes();
    }
}

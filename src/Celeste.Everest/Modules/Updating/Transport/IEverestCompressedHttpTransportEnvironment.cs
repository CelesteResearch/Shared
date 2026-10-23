namespace Celeste.Everest.Modules.Updating.Transport
{
    public interface IEverestCompressedHttpTransportEnvironment
    {
        IEverestCompressedHttpTransport CompressedHttpTransport { get; }
    }
}

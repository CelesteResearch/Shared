using System.Net.Http;

namespace Celeste.Everest.Modules.Updating.Transport
{
    // Pure HTTP physical transport. The source handler policy requires decompression,
    // IPv4-only connect, cancellation, NoDelay and owned socket cleanup as one capability.
    public interface IEverestCompressedHttpTransport
    {
        HttpMessageHandler CreateCompressedHandler();
    }
}

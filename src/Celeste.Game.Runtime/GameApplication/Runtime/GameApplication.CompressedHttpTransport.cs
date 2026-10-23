using System;
using Celeste.Everest.Modules.Updating.Transport;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestCompressedHttpTransportEnvironment
    {
        IEverestCompressedHttpTransport IEverestCompressedHttpTransportEnvironment.CompressedHttpTransport =>
            PhysicalIO.CompressedHttpTransport ??
            throw new InvalidOperationException(
                "The enabled Everest profile requires its compressed HTTP transport.");
    }
}

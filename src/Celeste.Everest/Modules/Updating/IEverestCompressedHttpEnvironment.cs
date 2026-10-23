using System;
using System.Net;
using System.Net.Http;
using Celeste.Everest.Modules.Updating.Transport;
using Celeste.Core.Scheduling;
using Celeste.Core.Threading;

namespace Celeste.Everest.Modules.Updating
{
    public interface IEverestCompressedHttpEnvironment
    {
        EverestCompressedHttpProcess CompressedHttp { get; }
    }
}

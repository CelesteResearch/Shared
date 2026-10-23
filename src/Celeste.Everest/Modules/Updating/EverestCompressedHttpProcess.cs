using System;
using System.Net;
using System.Net.Http;
using Celeste.Everest.Modules.Updating.Transport;
using Celeste.Core.Scheduling;
using Celeste.Core.Threading;

namespace Celeste.Everest.Modules.Updating
{
    public sealed class EverestCompressedHttpProcess
    {
        private readonly ISourceEngineContext engine;
        private readonly SourceTypeInitialization<CompressedHttpState> typeState;

        public EverestCompressedHttpProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
            typeState = new SourceTypeInitialization<CompressedHttpState>(
                "Celeste.Mod.Helpers.CompressedHttpClient", new CompressedHttpStateFactory(engine));
        }

        public HttpClient CreateClient() => new CompressedHttpClient(typeState.Value, engine);

        private sealed class CompressedHttpState
        {
            internal HttpMessageHandler handler;
        }

        private sealed class CompressedHttpStateFactory : ISourceTypeInitializationFactory<CompressedHttpState>
        {
            public CompressedHttpState Allocate() => new CompressedHttpState();

            private readonly ISourceEngineContext engine;
            public CompressedHttpStateFactory(ISourceEngineContext engine) => this.engine = engine;

            public void Initialize(CompressedHttpState state) => state.handler =
                ((IEverestCompressedHttpTransportEnvironment)engine).CompressedHttpTransport.CreateCompressedHandler();
        }

        private sealed class CompressedHttpClient : HttpClient
        {
            internal CompressedHttpClient(CompressedHttpState state, ISourceEngineContext engine)
                : base(state.handler, disposeHandler: false)
            {
                DefaultRequestHeaders.Add("User-Agent", "Everest/" +
                                                        ((IEverestVersionStringEnvironment)engine)
                                                        .EverestVersionString);
            }
        }
    }
}

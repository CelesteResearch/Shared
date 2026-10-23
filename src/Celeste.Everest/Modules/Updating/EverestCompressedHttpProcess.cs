using System.Net.Http;
using Celeste.Core.Scheduling;
using Celeste.Core.Threading;
using Celeste.Everest.Modules.Updating.Transport;

namespace Celeste.Everest.Modules.Updating
{
    public sealed class EverestCompressedHttpProcess
    {
        private readonly ISourceEngineContext engine;
        private readonly SourceTypeInitialization<CompressedHttpState> typeState;

        public EverestCompressedHttpProcess(ISourceEngineContext engine)
        {
            this.engine = engine;
            typeState = new(
                "Celeste.Mod.Helpers.CompressedHttpClient", new CompressedHttpStateFactory(engine));
        }

        public HttpClient CreateClient()
        {
            return new CompressedHttpClient(typeState.Value, engine);
        }

        private sealed class CompressedHttpState
        {
            internal HttpMessageHandler handler;
        }

        private sealed class CompressedHttpStateFactory : ISourceTypeInitializationFactory<CompressedHttpState>
        {
            public CompressedHttpState Allocate()
            {
                return new();
            }

            private readonly ISourceEngineContext engine;

            public CompressedHttpStateFactory(ISourceEngineContext engine)
            {
                this.engine = engine;
            }

            public void Initialize(CompressedHttpState state)
            {
                state.handler =
                    ((IEverestCompressedHttpTransportEnvironment)engine).CompressedHttpTransport
                    .CreateCompressedHandler();
            }
        }

        private sealed class CompressedHttpClient : HttpClient
        {
            internal CompressedHttpClient(CompressedHttpState state, ISourceEngineContext engine)
                : base(state.handler, false)
            {
                DefaultRequestHeaders.Add("User-Agent", "Everest/" +
                                                        ((IEverestVersionStringEnvironment)engine)
                                                        .EverestVersionString);
            }
        }
    }
}

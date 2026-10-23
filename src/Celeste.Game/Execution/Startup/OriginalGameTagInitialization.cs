using System;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tagging;

namespace Celeste.Game.Execution.Startup
{
    public sealed class OriginalGameTagInitialization : IOriginalGameTagInitialization
    {
        private readonly ISourceEngineContext engine;

        public OriginalGameTagInitialization(ISourceEngineContext engine) =>
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

        public void Initialize() =>
            ((IOriginalGameTagsEnvironment)engine).Tags.Initialize(((ISourceBitTagEnvironment)engine).BitTags);
    }
}

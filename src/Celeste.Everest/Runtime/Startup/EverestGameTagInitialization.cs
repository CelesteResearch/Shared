using System;
using Celeste.Core.Scheduling;
using Celeste.Scene.Tagging;
using Celeste.Game.Execution.Startup;

namespace Celeste.Everest.Runtime.Startup
{
    public sealed class EverestGameTagInitialization : IOriginalGameTagInitialization
    {
        private readonly ISourceEngineContext engine;

        public EverestGameTagInitialization(ISourceEngineContext engine) =>
            this.engine = engine ?? throw new ArgumentNullException(nameof(engine));

        public void Initialize() =>
            ((IEverestGameTagsEnvironment)engine).EverestTags.Initialize(((IOriginalGameTagsEnvironment)engine).Tags,
                ((ISourceBitTagEnvironment)engine).BitTags);
    }
}

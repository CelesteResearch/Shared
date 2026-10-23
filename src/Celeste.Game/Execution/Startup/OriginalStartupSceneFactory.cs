using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Menus.Loading;
using Celeste.Game.Presentation.Environment;
using Celeste.Game.Vignettes;
using Celeste.Input.Gameplay;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Execution.Startup
{
    public sealed class OriginalStartupSceneFactory
    {
        private readonly ISourceEngineContext engine;
        private readonly IGameLoaderSourceResources loaderResources;
        private readonly IOriginalGameLoaderConstruction loaderConstruction;

        public OriginalStartupSceneFactory(ISourceEngineContext actualEngine,
            IGameLoaderSourceResources actualLoaderResources,
            IOriginalGameLoaderConstruction actualLoaderConstruction)
        {
            engine = actualEngine ?? throw new ArgumentNullException(nameof(actualEngine));
            loaderResources = actualLoaderResources ?? throw new ArgumentNullException(nameof(actualLoaderResources));
            loaderConstruction = actualLoaderConstruction ??
                                 throw new ArgumentNullException(nameof(actualLoaderConstruction));
        }

        public GameLoaderScene CreateGameLoader()
        {
            return loaderConstruction.Create(engine,
                ((ISourceGameInputEnvironment)engine).Input, loaderResources);
        }

        public IntroVignetteSequence CreateIntroVignette(ChapterCompletionSession session, HiresSnowState snow)
        {
            return new(session, engine, snow);
        }
    }
}

using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Levels.Update;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Everest.Gameplay.Levels.Errors
{
    public sealed class EverestLevelEntryPendingErrorPolicy : IOriginalLevelErrorPolicy
    {
        private readonly LevelEnterStaticState errors;
        private readonly SourceEngineSceneState scenes;
        private readonly ILevelEntrySceneFactory sourceScenes;

        public EverestLevelEntryPendingErrorPolicy(LevelEnterStaticState actualErrors,
            SourceEngineSceneState actualScenes, ILevelEntrySceneFactory actualSourceSceneFactory)
        {
            errors = actualErrors ?? throw new ArgumentNullException(nameof(actualErrors));
            scenes = actualScenes ?? throw new ArgumentNullException(nameof(actualScenes));
            sourceScenes = actualSourceSceneFactory ??
                           throw new ArgumentNullException(nameof(actualSourceSceneFactory));
        }

        public bool CheckForErrors(ChapterCompletionSession actualSession)
        {
            if (errors.ErrorMessage == null) return false;
            // Installed LevelEnter.Go exits here before custom/original vignettes or Everest Enter events.
            scenes.NextScene = sourceScenes.CreateLevelEnter(actualSession, false);
            return true;
        }
    }
}

using System;
using Celeste.Everest.Chapters.Flow;
using Celeste.Everest.Chapters.Flow.Completions;
using Celeste.Everest.Presentation.Completion.SceneFactories;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalAreaCompleteEnvironment,
        IOriginalLevelExitCompletionEnvironment
    {
        private IOriginalAreaCompleteFactory sourceAreaCompletes;
        private IOriginalLevelExitCompletionPolicy sourceLevelExitCompletionPolicy;

        public IOriginalAreaCompleteFactory AreaCompletes => sourceAreaCompletes ??
                                                             throw new InvalidOperationException(
                                                                 "The actual selected AreaComplete factory is not constructed.");

        public IInstalledAreaCompleteFactory InstalledAreaCompletes => (IInstalledAreaCompleteFactory)AreaCompletes;

        public IOriginalLevelExitCompletionPolicy LevelExitCompletionPolicy => sourceLevelExitCompletionPolicy ??
                                                                               throw new InvalidOperationException(
                                                                                   "The actual selected LevelExit completion policy is not constructed.");

        internal void ConstructSourceAreaCompletionProcesses()
        {
            if (sourceAreaCompletes != null)
                throw new InvalidOperationException("The actual AreaComplete process roles are already constructed.");
            sourceAreaCompletes = SourceProfile == GameProfile.Original
                ? new OriginalAreaCompleteFactory(this)
                : new EverestAreaCompleteFactory(this, this, Text);
            ConstructSourceChapterExitAndInfoProcesses();
            var original = new OriginalLevelExitCompletionPolicy(this, GraphicsResources, this, sourceAreaCompletes);
            sourceLevelExitCompletionPolicy = SourceProfile == GameProfile.Original
                ? original
                : new EverestLevelExitCompletionPolicy(this, original,
                    this, InstalledAreaCompletes);
        }
    }
}

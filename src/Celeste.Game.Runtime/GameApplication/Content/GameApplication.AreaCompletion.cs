using System;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Profiles;
using Celeste.Everest.Presentation.Completion.SceneFactories;

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
                ? (IOriginalAreaCompleteFactory)new OriginalAreaCompleteFactory(this)
                : new global::Celeste.Everest.Chapters.Flow.EverestAreaCompleteFactory(this, this, Text);
            ConstructSourceChapterExitAndInfoProcesses();
            var original = new OriginalLevelExitCompletionPolicy(this, GraphicsResources, this, sourceAreaCompletes);
            sourceLevelExitCompletionPolicy = SourceProfile == GameProfile.Original
                ? (IOriginalLevelExitCompletionPolicy)original
                : new global::Celeste.Everest.Chapters.Flow.Completions.EverestLevelExitCompletionPolicy(this, original,
                    this, InstalledAreaCompletes);
        }
    }
}

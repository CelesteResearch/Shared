using System;
using Celeste.Everest.Chapters.Flow;
using Celeste.Everest.Chapters.Flow.Restarts;
using Celeste.Everest.Modules.Runtime;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Chapters.Flow.Restarts;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Profiles;
using Celeste.Simulation.Runtime.Session;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IOriginalLevelExitEnvironment,
        IOriginalLevelRestartEnvironment, IOriginalAreaCompleteInfoEnvironment, IInstalledAreaCompleteInfoProcess
    {
        private IOriginalLevelExitFactory sourceLevelExits;
        private IOriginalLevelRestartPolicy sourceLevelRestartPolicy;
        private OriginalAreaCompleteInfoState sourceChapterCompletionInfo;

        public IOriginalLevelExitFactory LevelExits => sourceLevelExits ??
                                                       throw new InvalidOperationException(
                                                           "The actual selected LevelExit factory is not constructed.");

        public IOriginalLevelRestartPolicy LevelRestartPolicy => sourceLevelRestartPolicy ??
                                                                 throw new InvalidOperationException(
                                                                     "The actual selected LevelExit restart policy is not constructed.");

        public OriginalAreaCompleteInfoState AreaCompleteInfo => sourceChapterCompletionInfo ??
                                                                 throw new InvalidOperationException(
                                                                     "The actual selected AreaComplete info process is not constructed.");

        private void ConstructSourceChapterExitAndInfoProcesses()
        {
            if (sourceLevelExits != null || sourceLevelRestartPolicy != null || sourceChapterCompletionInfo != null)
                throw new InvalidOperationException(
                    "The actual chapter exit and completion info roles are already constructed.");
            if (SourceProfile == GameProfile.Original)
            {
                sourceLevelExits = new OriginalLevelExitFactory(this);
                sourceLevelRestartPolicy = new OriginalLevelRestartPolicy();
                sourceChapterCompletionInfo = new(this);
            }
            else
            {
                sourceLevelExits = new EverestLevelExitFactory(this, this, GameEvents);
                sourceLevelRestartPolicy = new EverestLevelRestartPolicy();
                sourceChapterCompletionInfo = new EverestAreaCompleteInfoState(this);
            }
        }

        string IInstalledAreaCompleteInfoProcess.Build => $"{EverestRuntime.Build}";
        byte[] IInstalledAreaCompleteInfoProcess.InstallationHash => ModulesProcess.InstallationHash;

        string IInstalledAreaCompleteInfoProcess.GetModePath(ChapterCompletionSession session)
        {
            return ((IOriginalAreaDataResolver)this).Get(session.AreaID).Mode[session.Mode].Path;
        }

        bool IInstalledAreaCompleteInfoProcess.TryGetMapModule(string path, out EverestModuleMetadata module)
        {
            if (SourceContentRegistry.TryGet(path, out var metadata))
            {
                module = metadata.Source.Mod;
                return true;
            }

            module = null;
            return false;
        }
    }
}

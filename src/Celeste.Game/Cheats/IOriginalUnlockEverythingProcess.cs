using Celeste.Core.Scheduling;
using Celeste.Game.Controls.Source;
using Celeste.Game.Chapters.Flow;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Settings;

namespace Celeste.Game.Cheats
{
    public interface IOriginalUnlockEverythingProcess : ISourceEngineContext,
        IOriginalGameInputProcessEnvironment, IOriginalGameplayProcess, IOriginalLevelExitEnvironment
    {
        IMenuSettingsFlags MenuSettings { get; }
        IOriginalSaveProgressionPolicy SaveProgression { get; }
        IOriginalSaveLevelSetQueries SaveLevelSets { get; }
        IOriginalUnlockEverythingPolicy UnlockEverythingPolicy { get; }
    }
}

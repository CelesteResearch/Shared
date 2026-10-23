using Celeste.Core.Scheduling;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.LevelLoader;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Session;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.Runtime;

namespace Celeste.Game.Chapters.Flow
{
    public interface IOriginalLevelEnterProcess : ISourceEngineContext, IOriginalGameplayProcess,
        IOriginalGameTextEnvironment, IOriginalLevelLoaderEnvironment, IOriginalSaveCounterEnvironment,
        IOriginalGameInputProcessEnvironment, IOriginalAreaKeyEnvironment,
        IOriginalSaveSessionSelectionEnvironment, IOriginalLevelEnterStaticEnvironment,
        IOriginalSessionEnvironment,
        IOriginalOverworldLoaderEnvironment
    {
        IOriginalLevelEnterPolicy LevelEnterPolicy { get; }
    }
}

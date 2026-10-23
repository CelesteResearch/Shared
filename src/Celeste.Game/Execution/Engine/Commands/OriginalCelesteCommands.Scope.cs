using Celeste.Core.Scheduling;
using Celeste.Scene.Scenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Areas;
using Celeste.Game.Execution.Session;
using Celeste.Game.Save.Data;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Game.Settings;
using Celeste.Framework.Diagnostics.Commands;
using global::Celeste.Game.Execution;

namespace Celeste.Game.Execution.Engine.Commands
{
    public static partial class OriginalCelesteCommands
    {
        // Original Engine.Instance is the actual SDK source current slot. Every loan is late.
        private static ISourceEngineContext Process => EngineRuntime.Instance.Process;
        private static OriginalSaveDataState CurrentSave => ((IOriginalGameplayProcess)Process).SaveContext.CurrentSave;

        private static SourceSceneState Scene
        {
            get => (SourceSceneState)Process.Frame.Scenes.CurrentScene;
            set => Process.Frame.Scenes.NextScene = value;
        }

        private static SourceCommands Console => EngineRuntime.Instance.Commands;
        private static IOriginalAreaKeyPolicy AreaKeys => ((IOriginalAreaKeyEnvironment)Process).AreaKeys;
        private static OriginalSessionFactory Sessions => ((IOriginalSessionEnvironment)Process).Sessions;
        private static SettingsState Settings => ((ISettingsContext)Process).Settings;

        private static void InitializeDebugMode() =>
            ((IOriginalSaveDebugEnvironment)Process).SaveDebug.InitializeDebugMode(
                ((IOriginalUserIOStorageEnvironment)Process).UserIOStorage,
                (IOriginalSaveInitializationServices)Process);
    }
}

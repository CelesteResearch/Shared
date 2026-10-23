using System;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.SoundTest;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Save.IO;
using Celeste.Game.Save.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Runtime;

namespace Celeste.Everest.Diagnostics.Commands
{
    public static class InstalledEverestHelperCommands
    {
        private static ISourceEngineContext Process => EngineRuntime.Instance.Process;

        [Flags]
        private enum WhatToSave
        {
            File = 1,
            Settings = 2,
            All = 3,
        }

        public static void Hide()
        {
            ((ISourceMInputEnvironment)Process).MInput.Keyboard.CurrentState =
                new(SourceKeys.Enter);
            EngineRuntime.Instance.Commands.Open = false;
        }

        public static void WipeDebug()
        {
            ((IOriginalSaveDeletionEnvironment)Process).SaveDeletion.TryDelete(-1,
                ((IOriginalSaveDeletionEnvironment)Process).SaveDeletionServices);
            if (((IOriginalGameplayProcess)Process).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)Process).SaveContext.CurrentSave.FileSlot == -1)
                ((IOriginalSaveDebugEnvironment)Process).SaveDebug.InitializeDebugMode(
                    ((IOriginalUserIOStorageEnvironment)Process).UserIOStorage,
                    (IOriginalSaveInitializationServices)Process);
        }

        public static void LogDetours()
        {
            ((ISourceEverestModulesProcessEnvironment)Process).ModulesProcess.LogDetours(
                ((IEverestLoggerProcessEnvironment)Process).Logger.GetLogLevel("detours"));
        }

        public static void SetLogLevel(string tagPrefix, string minimumLevel = "Verbose")
        {
            if (Enum.TryParse<EverestLogLevel>(minimumLevel, true, out var result))
            {
                tagPrefix = tagPrefix.Equals("*") ? "" : tagPrefix;
                ((IEverestLoggerProcessEnvironment)Process).Logger.SetLogLevelFromSettings(tagPrefix, result);
            }
            else
            {
                EngineRuntime.Instance.Commands.Log("Invalid log level! Use Verbose, Debug, Info, Warn, or Error");
            }
        }

        public static void ToggleShowModOptions()
        {
            ((IEverestCoreSettingsEnvironment)Process).CurrentCoreSettings.ShowModOptionsInGame =
                !((IEverestCoreSettingsEnvironment)Process).CurrentCoreSettings.ShowModOptionsInGame;
        }

        public static void OpenSoundTest()
        {
            if (Process.Frame.Scenes.CurrentScene.GetType() != typeof(OverworldSequence))
                Process.Frame.Scenes.NextScene = new EverestOverworldLoaderToSoundTest(Process);
            else
                ((IEverestModOptionsEnvironment)Process).EverestUI.ModOptionsInstance.Overworld
                    .Goto<EverestSoundTestState>();
        }

        public static void Save(string whatToSave = "all")
        {
            if (!string.IsNullOrWhiteSpace(whatToSave) &&
                Enum.TryParse<WhatToSave>(whatToSave, true, out var result))
            {
                var flag = (result & WhatToSave.File) != 0;
                var flag2 = (result & WhatToSave.Settings) != 0;
                if (((IOriginalGameplayProcess)Process).SaveContext.CurrentSave == null) flag = false;

                if (flag || flag2) ((IOriginalUserIOEnvironment)Process).UserIO.SaveHandler(flag, flag2);
            }
            else
            {
                EngineRuntime.Instance.Commands.Log("Invalid option! Use File, Settings, or All");
            }
        }
    }
}

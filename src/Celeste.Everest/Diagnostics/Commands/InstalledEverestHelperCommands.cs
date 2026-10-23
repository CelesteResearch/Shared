using Celeste.Input.Runtime;
using Celeste.Input.Devices.Keyboard;
using Celeste.Game.Execution.Engine;
using System;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Save.Runtime;
using Celeste.Game.Save.IO;
using Celeste.Game.Menus.Overworld;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.UI.SoundTest;
using Celeste.Everest.UI.ModOptions;
using global::Celeste.Game.Execution;

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
            All = 3
        }

        public static void Hide()
        {
            ((ISourceMInputEnvironment)Process).MInput.Keyboard.CurrentState =
                new SourceKeyboardState(SourceKeys.Enter);
            EngineRuntime.Instance.Commands.Open = false;
        }

        public static void WipeDebug()
        {
            ((IOriginalSaveDeletionEnvironment)Process).SaveDeletion.TryDelete(-1,
                ((IOriginalSaveDeletionEnvironment)Process).SaveDeletionServices);
            if (((IOriginalGameplayProcess)Process).SaveContext.CurrentSave != null &&
                ((IOriginalGameplayProcess)Process).SaveContext.CurrentSave.FileSlot == -1)
            {
                ((IOriginalSaveDebugEnvironment)Process).SaveDebug.InitializeDebugMode(
                    ((IOriginalUserIOStorageEnvironment)Process).UserIOStorage,
                    (IOriginalSaveInitializationServices)Process);
            }
        }

        public static void LogDetours()
        {
            ((ISourceEverestModulesProcessEnvironment)Process).ModulesProcess.LogDetours(
                ((IEverestLoggerProcessEnvironment)Process).Logger.GetLogLevel("detours"));
        }

        public static void SetLogLevel(string tagPrefix, string minimumLevel = "Verbose")
        {
            if (Enum.TryParse<EverestLogLevel>(minimumLevel, ignoreCase: true, out var result))
            {
                tagPrefix = (tagPrefix.Equals("*") ? "" : tagPrefix);
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
            {
                Process.Frame.Scenes.NextScene = new EverestOverworldLoaderToSoundTest(Process);
            }
            else
            {
                ((IEverestModOptionsEnvironment)Process).EverestUI.ModOptionsInstance.Overworld
                    .Goto<EverestSoundTestState>();
            }
        }

        public static void Save(string whatToSave = "all")
        {
            if (!string.IsNullOrWhiteSpace(whatToSave) &&
                Enum.TryParse<WhatToSave>(whatToSave, ignoreCase: true, out var result))
            {
                bool flag = (result & WhatToSave.File) != 0;
                bool flag2 = (result & WhatToSave.Settings) != 0;
                if (((IOriginalGameplayProcess)Process).SaveContext.CurrentSave == null)
                {
                    flag = false;
                }

                if (flag || flag2)
                {
                    ((IOriginalUserIOEnvironment)Process).UserIO.SaveHandler(flag, flag2);
                }
            }
            else
            {
                EngineRuntime.Instance.Commands.Log("Invalid option! Use File, Settings, or All");
            }
        }
    }
}

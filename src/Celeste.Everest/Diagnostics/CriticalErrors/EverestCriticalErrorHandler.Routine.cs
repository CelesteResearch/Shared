using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using Celeste.Core.Framework.Timing;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.Diagnostics.CriticalErrors
{
    public sealed partial class EverestCriticalErrorHandler
    {
        private IEnumerator Routine()
        {
            UserChoice? choice;
            while (true)
            {
                if (State != DisplayState.BlueScreen)
                    yield return FadeIn();
                else
                    Fade = 1f;

                optMenu = new TextMenuPresentation(EngineContext) { AutoScroll = false };
                optMenu.Add(new TextMenuPresentation.Button("Open log file folder")
                {
                    Disabled = LogFileError != null
                }.Pressed(() =>
                {
                    string command;
                    if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        if (!RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                        {
                            if (!RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                                throw new NotSupportedException();
                            command = "open";
                        }
                        else command = "xdg-open";
                    }
                    else command = "explorer.exe";

                    ((global::Celeste.Everest.Runtime.Processes.IEverestProcessStartEnvironment)EngineContext)
                        .ProcessStart
                        .Start(new ProcessStartInfo
                        {
                            FileName = command,
                            ArgumentList = { Path.GetDirectoryName(LogFile) },
                            UseShellExecute = true
                        });
                }));
                choice = null;
                if (Session != null)
                {
                    optMenu.Add(new TextMenuPresentation.Button("Retry level")
                    {
                        Disabled = !CanExecuteChoice(UserChoice.RetryLevel)
                    }.Pressed(() => choice = UserChoice.RetryLevel));
                    optMenu.Add(new TextMenuPresentation.Button("Save & Quit")
                    {
                        Disabled = !CanExecuteChoice(UserChoice.SaveAndQuit)
                    }.Pressed(() => choice = UserChoice.SaveAndQuit));
                }

                if (process.Saves.CurrentSave != null && !hasFlushedSaveData)
                    optMenu.Add(new TextMenuPresentation.Button("Save current progress")
                    {
                        Disabled = !CanExecuteChoice(UserChoice.FlushSaveData)
                    }.Pressed(() => choice = UserChoice.FlushSaveData));
                optMenu.Add(new TextMenuPresentation.Button("Return to main menu")
                {
                    Disabled = !CanExecuteChoice(UserChoice.ReturnToMainMenu)
                }.Pressed(() => choice = UserChoice.ReturnToMainMenu));
                optMenu.Add(new TextMenuPresentation.Button("Exit Game").Pressed(() =>
                {
                    ((ISourceScene)Scene).SourceScene.OnEndOfFrame += () =>
                        ((ISourceGameLoopEnvironment)EngineContext).GameLoop.Exit();
                }));

                AddRestartButton();

                ConfigureOptionsMenu();
                var previousScene = EngineContext.Frame.Scenes.CurrentScene;
                var previousState = State;
                while (!choice.HasValue && ReferenceEquals(previousScene, EngineContext.Frame.Scenes.CurrentScene)
                                        && State == previousState)
                    yield return null;
                if (ReferenceEquals(previousScene, EngineContext.Frame.Scenes.CurrentScene) && previousState == State)
                {
                    if (State != DisplayState.BlueScreen) yield return FadeOut();
                    if (!ExecuteUserChoice(choice.Value)) failedChoices.Add(choice.Value);
                    else if (!ReferenceEquals(process.CurrentHandler, this)) break;
                }
            }

            RemoveSelf();
        }
    }
}

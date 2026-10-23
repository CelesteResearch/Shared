using System.Linq;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.UI.ModOptions;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public void CreatePauseMenuButtons(OriginalLevelSceneRoot level, TextMenuPresentation menu, bool minimal)
        {
            if (!Settings.ShowModOptionsInGame) return;
            var items = menu.Items;
            var cleanedOptions = ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("menu_pause_options");
            var index =
                items.FindIndex(item => item is TextMenuPresentation.Button button && button.Label == cleanedOptions);
            index = index == -1 ? items.Count : index + 1;
            TextMenuPresentation.Item itemModOptions = null;
            menu.Insert(index, itemModOptions = new TextMenuPresentation.Button(
                ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog("menu_pause_modoptions")).Pressed(() =>
            {
                var returnIndex = menu.IndexOf(itemModOptions);
                menu.RemoveSelf();
                level.PauseMainMenuOpen = false;
                level.Paused = true;
                var options = EverestModOptionsState.CreateMenu(true, level.PauseSnapshot);
                var startSearching = EverestModOptionsState.AddSearchBox(options);
                options.OnUpdate = () =>
                {
                    if (options.Focused && ((IOriginalGameInputProcessEnvironment)SourceEngine).InputSource.QuickRestart
                        .Pressed)
                        startSearching();
                };
                options.OnESC = options.OnCancel = () =>
                {
                    if (options.Focused)
                    {
                        ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play("event:/ui/main/button_back");
                        options.CloseAndRun(
                            ((ISourceEverestModulesProcessEnvironment)SourceEngine).ModulesProcess.SaveSettings(), () =>
                            {
                                level.Pause(returnIndex, minimal);
                                var textMenu =
                                    level.Scheduler.GetToAdd()
                                            .FirstOrDefault(entity => entity is TextMenuPresentation) as
                                        TextMenuPresentation;
                                var button = textMenu?.Items
                                    .OfType<TextMenuPresentation.Button>()
                                    .FirstOrDefault(candidate =>
                                        candidate.Label ==
                                        ((IOriginalGameTextEnvironment)SourceEngine).Text.CleanDialog(
                                            "menu_pause_modoptions"));
                                if (button != null) textMenu.Selection = textMenu.IndexOf(button);
                            });
                    }
                };
                options.OnPause = () =>
                {
                    if (options.Focused)
                    {
                        ((IOriginalGameplayProcess)SourceEngine).AudioSession.Play("event:/ui/main/button_back");
                        options.CloseAndRun(
                            ((ISourceEverestModulesProcessEnvironment)SourceEngine).ModulesProcess.SaveSettings(), () =>
                            {
                                level.Paused = false;
                                SourceEngine.Effects.FreezeTimer = .15f;
                            });
                    }
                };
                level.Scheduler.QueueSourceEntity(options);
            }));
        }
    }
}

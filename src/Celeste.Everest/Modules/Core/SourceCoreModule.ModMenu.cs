using Celeste.Audio.Fmod.Events;
using Celeste.Game.Content.Dialogs;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.Menus.InitialSetup;
using Celeste.Everest.UI.SoundTest;
using Celeste.Everest.UI.Updating.Versions;
using Celeste.Everest.UI.Updating.Mods;
using Celeste.Everest.UI.Mods.Toggling;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.Modules.Updating;
using TextMenu = Celeste.Simulation.UI.Menus.Text.TextMenuPresentation;

namespace Celeste.Everest.Modules.Core
{
    public partial class SourceCoreModule
    {
        public override void CreateModMenuSection(TextMenu menu, bool inGame, FmodEventReference snapshot)
        {
            base.CreateModMenuSection(menu, inGame, snapshot);
            if (!inGame)
            {
                var items = menu.Items;
                menu.Insert(items.Count - 2,
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog
                            .Clean("modoptions_coremodule_oobe"))
                        .Pressed(() =>
                        {
                            ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestCoreOobeSequence>();
                        }));
                menu.Insert(items.Count - 2,
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                                "modoptions_coremodule_soundtest"))
                        .Pressed(() =>
                        {
                            ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestSoundTestState>();
                        }));
                menu.Insert(items.Count - 2,
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                                "modoptions_coremodule_versionlist"))
                        .Pressed(() =>
                        {
                            ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestVersionListState>();
                        }));
                TextMenu.Item item =
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                                "modoptions_coremodule_legacyref"))
                        .Pressed(() =>
                        {
                            ((IEverestUpdaterEnvironment)SourceEngine).Updater.UpdateLegacyRef(
                                ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestLoggedProgressState>());
                        });
                menu.Insert(items.Count - 2, item);
                item.AddDescription(menu,
                    ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                        "modoptions_coremodule_legacyref_descr"));
                menu.Insert(items.Count - 2,
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                                "modoptions_coremodule_modupdates"))
                        .Pressed(() =>
                        {
                            ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestModUpdateListState>();
                        }));
                menu.Insert(items.Count - 2,
                    new TextMenu.Button(
                            ((IOriginalGameTextEnvironment)SourceEngine).Text.Dialog.Clean(
                                "modoptions_coremodule_togglemods"))
                        .Pressed(() =>
                        {
                            ((IEverestModOptionsEnvironment)SourceEngine).EverestUI.ModOptionsInstance.Overworld
                                .Goto<EverestModTogglerState>();
                        }));
            }
        }
    }
}

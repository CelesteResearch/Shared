using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime;
using Celeste.Everest.Runtime.Startup;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Settings;
using Celeste.Everest.UI.Shutdown;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Scenes;
using Celeste.Game.Menus.Overworld;
using Celeste.Graphics.Rendering;
using Celeste.Localization.Lookup;
using Celeste.Scene.Rendering;
using Celeste.Scene.Tracking;
using Celeste.Simulation.Presentation.Scene.Transitions;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.Updating.Mods
{
    public class EverestModUpdateListState : OuiState, IEverestModOptionsSubmenu
    {
        private readonly ISourceEngineContext engine;

        public EverestModUpdateListState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
        }

        private OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)engine).InputSource;
        private OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)engine).AudioSession;
        private DialogCatalog Dialog => ((IOriginalGameTextEnvironment)engine).Text.Dialog;
        private EverestUpdaterProcess Updater => ((IEverestUpdaterEnvironment)engine).Updater;
        private EverestModUpdaterProcess ModUpdater => ((IEverestModUpdaterEnvironment)engine).ModUpdater;
        private EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)engine).Loader;
        private EverestStartupRuntimeProcess Runtime => ((IEverestStartupRuntimeEnvironment)engine).EverestRuntime;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)engine).Logger;

        private TextMenuPresentation menu;

        private EverestMenuSubHeaderExt subHeader;

        private EverestMenuSubHeaderExt subRestartHeader;

        private TextMenuPresentation.Button fetchingButton;

        private TextMenuPresentation.Button updateAllButton;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private float alpha;

        private bool shouldRestart;

        private bool restartMenuAdded;

        private Task updateTask;

        private List<EverestModUpdateHolder> updatableMods;

        private bool isFetchingDone;

        private bool ongoingUpdateCancelled;

        private bool menuOnScreen;

        public override IEnumerator Enter(OuiState from)
        {
            Loader.AutoLoadNewMods = false;
            var ouiModUpdateList = this;
            var obj = new TextMenuPresentation(engine);
            obj.Add(new TextMenuPresentation.Header(Dialog.Clean("MODUPDATECHECKER_MENU_TITLE")));
            obj.Add(subHeader = new(Dialog.Clean("MODUPDATECHECKER_MENU_HEADER")));
            var ouiModUpdateList2 = this;
            var obj2 =
                new TextMenuPresentation.Button(Dialog.Clean("MODUPDATECHECKER_FETCHING"))
                {
                    Disabled = true,
                };
            var item = obj2;
            ouiModUpdateList2.fetchingButton = obj2;
            obj.Add(item);
            ouiModUpdateList.menu = obj;
            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
            var textMenu = menu;
            var ouiModUpdateList3 = this;
            var visible = true;
            ouiModUpdateList3.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
            menuOnScreen = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Loader.AutoLoadNewMods = true;
            Audio.Play("event:/ui/main/whoosh_large_out");
            menu.Focused = false;
            menuOnScreen = false;
            for (var p = 0f; p < 1f; p += engine.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            var textMenu = menu;
            var ouiModUpdateList = this;
            var visible = false;
            ouiModUpdateList.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
            if (updatableMods != null)
                foreach (var updatableMod in updatableMods)
                    updatableMod.RemoveButton();

            updateTask = null;
            updatableMods = null;
            isFetchingDone = false;
        }

        public override void Update()
        {
            if (menu == null || subHeader == null)
            {
                base.Update();
                return;
            }

            if (!isFetchingDone && ModUpdater.IsAsyncUpdateCheckingDone())
            {
                renderUpdateList();
                isFetchingDone = true;
            }

            if (menu.Focused && shouldRestart)
            {
                subHeader.TextColor = PackedColor.OrangeRed;
                subHeader.Title = Dialog.Clean("MODUPDATECHECKER_MENU_HEADER") + " (" +
                                  Dialog.Clean("MODUPDATECHECKER_RESTARTNEEDED") + ")";
                addRestartButtons();
            }
            else if (!menu.Focused && ongoingUpdateCancelled && menuOnScreen)
            {
                subHeader.TextColor = PackedColor.Gray;
                subHeader.Title = Dialog.Clean("MODUPDATECHECKER_MENU_HEADER") + " (" +
                                  Dialog.Clean("MODUPDATECHECKER_CANCELLING") + ")";
            }
            else
            {
                subHeader.TextColor = PackedColor.Gray;
                subHeader.Title = Dialog.Clean("MODUPDATECHECKER_MENU_HEADER");
            }

            if (Input.MenuCancel.Pressed && !menu.Focused && menuOnScreen)
            {
                ongoingUpdateCancelled = true;
                if (!isFetchingDone)
                {
                    Audio.Play("event:/ui/main/button_back");
                    Overworld.Goto<EverestModOptionsState>();
                }
            }
            else if (Input.MenuCancel.Pressed && menu.Focused && Selected)
            {
                if (shouldRestart && subRestartHeader != null)
                {
                    Audio.Play("event:/ui/main/button_invalid");
                }
                else
                {
                    Audio.Play("event:/ui/main/button_back");
                    Overworld.Goto<EverestModOptionsState>();
                }
            }

            base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);

            base.Render(context);
        }

        private void addRestartButtons()
        {
            if (restartMenuAdded) return;

            menu.Add(subRestartHeader =
                new(Dialog.Clean("MODUPDATECHECKER_MENU_HEADER_RESTART")));
            var button =
                new TextMenuPresentation.Button(Dialog.Clean("MODUPDATECHECKER_SHUTDOWN"));
            button.Pressed(delegate
            {
                new FadeWipePresentation((ISourceRendererScene)Scene, false, delegate
                {
                    engine.Frame.Scenes.NextScene = new OriginalPlainScene(engine);
                    ((IEverestApplicationExitEnvironment)engine).ApplicationLoop.Exit();
                });
            });
            var button2 =
                new TextMenuPresentation.Button(Dialog.Clean("MODUPDATECHECKER_RESTART"));
            button2.Pressed(delegate { ((IEverestRestartEnvironment)engine).Restart.QuickFullRestart(); });
            menu.Add(button2);
            menu.Add(button);
            restartMenuAdded = true;
            if (updatableMods.Count == 0) menu.FirstSelection();
        }

        private void renderUpdateList()
        {
            Logger.Log(EverestLogLevel.Verbose, "OuiModUpdateList", "Rendering updates");
            menu.Remove(fetchingButton);
            fetchingButton = null;
            var asyncLoadedModUpdates =
                ModUpdater.GetAsyncLoadedModUpdates();
            if (asyncLoadedModUpdates == null)
            {
                menu.Add(new TextMenuPresentation.Button(Dialog.Clean("MODUPDATECHECKER_ERROR"))
                {
                    Disabled = true,
                });
                return;
            }

            if (asyncLoadedModUpdates.Count == 0)
            {
                menu.Add(new TextMenuPresentation.Button(Dialog.Clean("MODUPDATECHECKER_NOUPDATE"))
                {
                    Disabled = true,
                });
                return;
            }

            var list = new List<TextMenuPresentation.Button>();
            updatableMods = [];
            if (asyncLoadedModUpdates.Count > 1)
            {
                updateAllButton = new(Dialog.Clean("MODUPDATECHECKER_UPDATE_ALL"));
                updateAllButton.Pressed(delegate { downloadAllMods(); });
                list.Add(updateAllButton);
            }

            foreach (var update in asyncLoadedModUpdates.Keys)
            {
                var metadata = asyncLoadedModUpdates[update];
                var versionUpdate = metadata.VersionString;
                if (metadata.VersionString != update.Version)
                    versionUpdate = metadata.VersionString + " > " + update.Version;

                var holder =
                    new EverestModUpdateHolder(update, metadata, () => null);
                Func<TextMenuPresentation.Button> buttonGenerator = delegate
                {
                    var button = new TextMenuPresentation.Button(
                        $"{ModUpdater.FormatModName(metadata.Name)} | v. {versionUpdate} ({new DateTime(1970, 1, 1, 0, 0, 0, 0).AddSeconds(update.LastUpdate):yyyy-MM-dd})");
                    button.Pressed(delegate
                    {
                        menu.Focused = false;
                        button.Disabled = true;
                        downloadModUpdate(holder);
                    });
                    if (update.xxHash.Count > 1) button.Disabled = true;

                    return button;
                };
                holder.buttonGenerator = buttonGenerator;
                if (update.xxHash.Count <= 1) updatableMods.Add(holder);

                list.Add(holder.button);
            }

            foreach (var item in list) menu.Add(item);
        }

        /// <summary>
        ///     Downloads and installs a mod update.
        /// </summary>
        /// <param name="modHolder">The relevant info for the mod</param>
        private void downloadModUpdate(EverestModUpdateHolder modHolder)
        {
            updateTask = new(delegate
            {
                if (doDownloadModUpdate(modHolder.update, modHolder.metadata, modHolder.button))
                {
                    if (menu.Selection + 1 > menu.LastPossibleSelection)
                        menu.Selection = menu.LastPossibleSelection;
                    else
                        menu.MoveSelection(1);

                    updatableMods.Remove(modHolder);
                    if (updatableMods.Count == 0 && updateAllButton != null)
                    {
                        updateAllButton.Disabled = true;
                        updateAllButton.Label = Dialog.Clean("MODUPDATECHECKER_UPDATE_ALL_DONE");
                    }
                }
                else
                {
                    modHolder.button.Disabled = false;
                }

                menu.Focused = true;
            });
            updateTask.Start();
        }

        /// <summary>
        ///     Does the actual downloading of the mod. This is it's own function, to avoid double code
        /// </summary>
        /// <param name="update">The update info coming from the update server</param>
        /// <param name="mod">The mod metadata from Everest for the installed mod</param>
        /// <param name="button">The button for that mod shown on the interface</param>
        /// <returns>Bool wether the update failed or not</returns>
        private bool doDownloadModUpdate(EverestModUpdateInfo update, EverestModuleMetadata mod,
            TextMenuPresentation.Button button)
        {
            ongoingUpdateCancelled = false;
            var text = Path.Combine(Runtime.PathTmp, $"modupdate-{update.GetHashCode()}.zip");
            try
            {
                button.Label = ModUpdater.FormatModName(update.Name) + " (" +
                               Dialog.Clean("MODUPDATECHECKER_DOWNLOADING") +
                               ")";
                downloadMod(update, button, text);
                if (ongoingUpdateCancelled)
                {
                    Logger.Log(EverestLogLevel.Verbose, "OuiModUpdateList", "Update was cancelled");
                    ModUpdater.TryDelete(text);
                    button.Label = ModUpdater.FormatModName(update.Name) + " (" +
                                   Dialog.Clean("MODUPDATECHECKER_CANCELLED") + ")";
                    return false;
                }

                shouldRestart = true;
                button.Label = ModUpdater.FormatModName(update.Name) + " (" +
                               Dialog.Clean("MODUPDATECHECKER_INSTALLING") +
                               ")";
                ModUpdater.InstallModUpdate(update, mod, text);
                button.Label = ModUpdater.FormatModName(update.Name) + " (" + Dialog.Clean("MODUPDATECHECKER_UPDATED") +
                               ")";
                return true;
            }
            catch (Exception e)
            {
                button.Label = ModUpdater.FormatModName(update.Name) + " (" + Dialog.Clean("MODUPDATECHECKER_FAILED") +
                               ")";
                var failedMessage = Logger.BeginEnabledMessage("OuiModUpdateList", EverestLogLevel.Warn);
                if (failedMessage.ShouldLog) failedMessage.Write("Updating " + update.Name + " failed");
                Logger.LogDetailed(e);
                ModUpdater.TryDelete(text);
                return false;
            }
        }

        /// <summary>
        ///     Downloads a mod update.
        /// </summary>
        /// <param name="update">The update info coming from the update server</param>
        /// <param name="button">The button for that mod shown on the interface</param>
        /// <param name="zipPath">The path to the zip the update will be downloaded to</param>
        private void downloadMod(EverestModUpdateInfo update, TextMenuPresentation.Button button, string zipPath)
        {
            var downloadMessage = Logger.BeginEnabledMessage("OuiModUpdateList", EverestLogLevel.Verbose);
            if (downloadMessage.ShouldLog) downloadMessage.Write("Downloading " + update.URL + " to " + zipPath);
            var progressCallback = delegate(int position, long length, int speed)
            {
                if (ongoingUpdateCancelled) return false;

                if (length > 0)
                    button.Label =
                        $"{ModUpdater.FormatModName(update.Name)} ({(int)Math.Floor(100.0 * (position / (double)length))}% @ {speed} KiB/s)";
                else
                    button.Label =
                        $"{ModUpdater.FormatModName(update.Name)} ({(int)Math.Floor(position / 1000.0)}KiB @ {speed} KiB/s)";

                return true;
            };
            Exception ex = null;
            foreach (string allMirrorUrl in ModUpdater.GetAllMirrorUrls(update.URL))
            {
                try
                {
                    ex = null;
                    Updater.DownloadFileWithProgress(allMirrorUrl, zipPath, progressCallback);
                    if (!ongoingUpdateCancelled) ModUpdater.VerifyChecksum(update, zipPath);
                }
                catch (Exception ex2)
                {
                    ex = ex2;
                    var mirrorMessage = Logger.BeginEnabledMessage("OuiModUpdateList", EverestLogLevel.Warn);
                    if (mirrorMessage.ShouldLog)
                        mirrorMessage.Write("Download from " + allMirrorUrl + " failed, trying another mirror.");
                    Logger.LogDetailed(ex2);
                    continue;
                }

                break;
            }

            if (ex != null)
            {
                ModUpdater.TryDelete(zipPath);
                throw ex;
            }
        }

        /// <summary>
        ///     Downloads all automatically updatable mods
        /// </summary>
        private void downloadAllMods()
        {
            updateTask = new(delegate
            {
                menu.Focused = false;
                updateAllButton.Disabled = true;
                updateAllButton.Label = Dialog.Clean("MODUPDATECHECKER_UPDATE_ALL_INPROGRESS");
                foreach (var updatableMod in updatableMods) updatableMod.button.Disabled = true;

                menu.Focused = false;
                int num;
                for (num = 0; num < updatableMods.Count; num++)
                {
                    var modUpdateHolder = updatableMods[num];
                    focusOn(modUpdateHolder.button);
                    if (!doDownloadModUpdate(modUpdateHolder.update, modUpdateHolder.metadata,
                            modUpdateHolder.button)) break;

                    updatableMods.Remove(modUpdateHolder);
                    num--;
                }

                focusOn(updateAllButton);
                foreach (var updatableMod2 in updatableMods) updatableMod2.button.Disabled = false;

                if (updatableMods.Count != 0)
                {
                    updateAllButton.Label = Dialog.Clean("MODUPDATECHECKER_UPDATE_ALL");
                    updateAllButton.Disabled = false;
                }
                else
                {
                    updateAllButton.Label = Dialog.Clean("MODUPDATECHECKER_UPDATE_ALL_DONE");
                }

                menu.Focused = true;
            });
            updateTask.Start();
        }

        private void focusOn(TextMenuPresentation.Button button)
        {
            var num = menu.Items.IndexOf(button);
            if (num != -1) menu.Selection = num;
        }
    }
}

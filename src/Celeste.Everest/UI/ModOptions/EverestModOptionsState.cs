using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using Celeste.Audio.Fmod.Events;
using Celeste.Core.Display;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Persistence.GameSaves;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.UI.Dependencies;
using Celeste.Everest.UI.Progress;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Audio.Runtime;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Controls.Source;
using Celeste.Game.Execution;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Menus.Overworld;
using Celeste.Game.Menus.Title;
using Celeste.Graphics.Rendering;
using Celeste.Input.Devices.Keyboard;
using Celeste.Input.Runtime;
using Celeste.Localization.Lookup;
using Celeste.Scene.Tracking;
using Celeste.Simulation.UI.Menus.Text;

namespace Celeste.Everest.UI.ModOptions
{
    public class EverestModOptionsState : OuiState
    {
        private readonly ISourceEngineContext engine;
        private static ISourceEngineContext Process => EngineRuntime.Instance.Process;

        public static EverestModOptionsState Instance =>
            ((IEverestModOptionsEnvironment)Process).EverestUI.ModOptionsInstance;

        private static OriginalGameInputProcess Input => ((IOriginalGameInputProcessEnvironment)Process).InputSource;
        private static OriginalGameAudioSession Audio => ((IOriginalGameplayProcess)Process).AudioSession;
        private static DialogCatalog Dialog => ((IOriginalGameTextEnvironment)Process).Text.Dialog;

        private static SourceEverestModulesProcess Modules =>
            ((ISourceEverestModulesProcessEnvironment)Process).ModulesProcess;

        private static EverestUpdaterProcess Updater => ((IEverestUpdaterEnvironment)Process).Updater;
        private static EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)Process).Loader;
        private static SourceEverestModule CoreModule => ((IEverestCoreModuleEnvironment)Process).CoreModule;
        private static EverestCoreSettings Settings => ((IEverestCoreSettingsEnvironment)Process).CurrentCoreSettings;

        private TextMenuPresentation menu;

        private const float onScreenX = 960f;

        private const float offScreenX = 2880f;

        private float alpha;

        private int savedMenuIndex = -1;

        private Action startSearching;

        public EverestModOptionsState(ISourceEngineContext engine) : base(engine)
        {
            this.engine = engine;
            ((IEverestModOptionsEnvironment)engine).EverestUI.ModOptionsInstance = this;
        }

        public static TextMenuPresentation CreateMenu(bool inGame, FmodEventReference snapshot)
        {
            var textMenu = new TextMenuPresentation(Process);
            textMenu.CompactWidthMode = true;
            textMenu.BatchMode = true;
            textMenu.Add(new EverestMenuHeaderImage("menu/everest")
            {
                ImageColor = PackedColor.White,
                ImageOutline = true,
                ImageScale = 0.5f,
            });
            if (!inGame)
            {
                var missingDependencies = new List<EverestModuleMetadata>();
                lock (Loader.Delayed)
                {
                    if (Loader.Delayed.Count > 0 || Loader.ModsWithAssemblyLoadFailures.Count > 0)
                    {
                        textMenu.Add(new EverestMenuSubHeaderExt(Dialog.Clean("modoptions_coremodule_notloaded_a"))
                        {
                            HeightExtra = 0f,
                            TextColor = PackedColor.OrangeRed,
                        });
                        textMenu.Add(new EverestMenuSubHeaderExt(Dialog.Clean("modoptions_coremodule_notloaded_b"))
                        {
                            HeightExtra = 0f,
                            TextColor = PackedColor.OrangeRed,
                        });
                        foreach (var modsWithAssemblyLoadFailure in Loader
                                     .ModsWithAssemblyLoadFailures)
                            textMenu.Add(new EverestMenuSubHeaderExt(
                                $"{modsWithAssemblyLoadFailure.Name} | v.{modsWithAssemblyLoadFailure.VersionString} ({Dialog.Get("modoptions_coremodule_notloaded_asmloaderror")})")
                            {
                                HeightExtra = 0f,
                                TextColor = PackedColor.PaleVioletRed,
                            });

                        foreach (var item in Loader.Delayed)
                        {
                            var text = "";
                            if (item.Item1.Dependencies != null)
                            {
                                var list =
                                    item.Item1.Dependencies.FindAll(dep =>
                                        !Loader.DependencyLoaded(dep));
                                if (item.Item1.OptionalDependencies != null)
                                {
                                    var collection =
                                        item.Item1.OptionalDependencies.FindAll(dep =>
                                            !Loader.DependencyLoaded(dep) &&
                                            Modules.Modules.Any(module =>
                                                module.Metadata?.Name == dep.Name));
                                    list.AddRange(collection);
                                }

                                missingDependencies.AddRange(list);
                                if (list.Count != 0)
                                {
                                    text = string.Join(", ",
                                        list.Select(dependency =>
                                            dependency.Name + " | v." + dependency.VersionString));
                                    if (text.Length > 40) text = text.Substring(0, 40) + "...";

                                    text = " (" + string.Format(Dialog.Get("modoptions_coremodule_notloaded_notfound"),
                                        text) + ")";
                                }
                            }

                            textMenu.Add(
                                new EverestMenuSubHeaderExt(item.Item1.Name + " | v." + item.Item1.VersionString + text)
                                {
                                    HeightExtra = 0f,
                                    TextColor = PackedColor.PaleVioletRed,
                                });
                        }
                    }
                    else if (Settings.WarnOnEverestYamlErrors && Loader.FilesWithMetadataLoadFailures.Count > 0)
                    {
                        textMenu.Add(new EverestMenuSubHeaderExt(Dialog.Clean("modoptions_coremodule_yamlerrors"))
                        {
                            HeightExtra = 0f,
                            TextColor = PackedColor.OrangeRed,
                        });
                        textMenu.Add(new EverestMenuSubHeaderExt(Dialog.Clean("modoptions_coremodule_notloaded_b"))
                        {
                            HeightExtra = 0f,
                            TextColor = PackedColor.OrangeRed,
                        });
                        foreach (var filesWithMetadataLoadFailure in Loader.FilesWithMetadataLoadFailures)
                            textMenu.Add(new EverestMenuSubHeaderExt(Path.GetFileName(filesWithMetadataLoadFailure))
                            {
                                HeightExtra = 0f,
                                TextColor = PackedColor.PaleVioletRed,
                            });
                    }
                }

                if (Updater.HasUpdate)
                    textMenu.Add(
                        new TextMenuPresentation.Button(Dialog.Clean("modoptions_coremodule_update")
                            .Replace("((version))", Updater.Newest.Build.ToString())).Pressed(delegate
                        {
                            Updater.Update(Instance.Overworld.Goto<EverestLoggedProgressState>());
                        }));

                if (missingDependencies.Count != 0)
                    textMenu.Add(
                        new TextMenuPresentation.Button(Dialog.Clean("modoptions_coremodule_downloaddeps")).Pressed(
                            delegate
                            {
                                ((IEverestDependencyDownloadEnvironment)Process).DependencyDownloads
                                    .MissingDependencies =
                                    missingDependencies;
                                Instance.Overworld.Goto<EverestDependencyDownloaderState>();
                            }));
            }

            var list2 = new List<SourceEverestModule>(Modules.Modules);
            _ = list2[0];
            list2.Remove(CoreModule);
            list2 = [.. list2.OrderBy(module => module.Metadata.Name)];
            list2.Insert(0, CoreModule);
            if (Loader._ModOptionsOrder != null && Loader._ModOptionsOrder.Count > 0)
                foreach (var item2 in Loader._ModOptionsOrder)
                {
                    if (item2.Equals("Everest", StringComparison.InvariantCultureIgnoreCase))
                    {
                        createModMenuSectionAndDelete(list2,
                            module => module.Metadata.Name == "Everest", textMenu, inGame,
                            snapshot);
                        continue;
                    }

                    var modPath = Path.Combine(Loader.PathMods, item2);
                    if (!createModMenuSectionAndDelete(list2,
                            module => module.Metadata.PathDirectory == modPath, textMenu, inGame,
                            snapshot))
                        createModMenuSectionAndDelete(list2,
                            module => module.Metadata.PathArchive == modPath, textMenu, inGame,
                            snapshot);
                }

            foreach (var item3 in list2) item3.CreateModMenuSection(textMenu, inGame, snapshot);

            if (textMenu.Height > textMenu.ScrollableMinSize)
            {
                var scrollPosition = textMenu.Position;
                scrollPosition.Y = textMenu.ScrollTargetY;
                textMenu.Position = scrollPosition;
            }

            textMenu.BatchMode = false;
            return textMenu;
        }

        /// <summary>
        ///     Adds the mod menu section for the first element of 'modules' that matches 'criteria',
        ///     then removes it from the 'modules' list.
        /// </summary>
        /// <returns>true if an element matching 'criteria' was found, false otherwise.</returns>
        private static bool createModMenuSectionAndDelete(List<SourceEverestModule> modules,
            Predicate<SourceEverestModule> criteria, TextMenuPresentation menu, bool inGame,
            FmodEventReference snapshot)
        {
            var result = false;
            for (var num = modules.FindIndex(criteria); num != -1; num = modules.FindIndex(criteria))
            {
                modules[num].CreateModMenuSection(menu, inGame, snapshot);
                modules.RemoveAt(num);
                result = true;
            }

            return result;
        }

        private void ReloadMenu()
        {
            var position = Vector2.Zero;
            var num = -1;
            if (menu != null)
            {
                position = menu.Position;
                num = menu.Selection;
                ((ISourceScene)Scene).SourceScene.RemoveEntity(menu);
            }

            menu = CreateMenu(false, null);
            startSearching = AddSearchBox(menu, Overworld);
            if (num >= 0)
            {
                menu.Selection = num;
                menu.Position = position;
            }

            ((ISourceScene)Scene).SourceScene.QueueSourceEntity(menu);
        }

        public static Action AddSearchBox(TextMenuPresentation menu, OverworldSequence overworld = null)
        {
            var textBox = new EverestMenuTextBox(Process, overworld)
            {
                PlaceholderText = Dialog.Clean("MODOPTIONS_COREMODULE_SEARCHBOX_PLACEHOLDER"),
            };
            var modal = new EverestMenuModal(textBox, null, 85f);
            menu.Add(modal);
            menu.Add(new EverestMenuSearchToolTip(Process));
            textBox.OnTextInputCharActions['\t'] = SearchNextMod(false);
            textBox.OnTextInputCharActions['\n'] = delegate { };
            textBox.OnTextInputCharActions['\r'] = delegate(EverestMenuTextBox obj)
            {
                if (((ISourceMInputEnvironment)Process).MInput.Keyboard.CurrentState.IsKeyDown(SourceKeys.LeftShift) ||
                    ((ISourceMInputEnvironment)Process).MInput.Keyboard.CurrentState.IsKeyDown(SourceKeys.RightShift))
                    SearchNextMod(true)(obj);
                else
                    SearchNextMod(false)(obj);
            };
            textBox.OnTextInputCharActions['\b'] = delegate(EverestMenuTextBox textBox2)
            {
                if (textBox2.DeleteCharacter())
                {
                    Audio.Play("event:/ui/main/rename_entry_backspace");
                }
                else
                {
                    ExitSearch(textBox2);
                    Input.MenuCancel.ConsumePress();
                }
            };
            textBox.AfterInputConsumed = delegate
            {
                if (textBox.Typing)
                {
                    if (Input.ESC.Pressed)
                    {
                        ExitSearch(textBox);
                        Input.ESC.ConsumePress();
                    }
                    else if (Input.MenuDown.Pressed)
                    {
                        SearchNextMod(false)(textBox);
                    }
                    else if (Input.MenuUp.Pressed)
                    {
                        SearchNextMod(true)(textBox);
                    }
                }
            };
            return delegate
            {
                if (menu.Focused)
                {
                    modal.Visible = true;
                    textBox.StartTyping();
                }
            };

            void ExitSearch(EverestMenuTextBox textBox2)
            {
                textBox2.StopTyping();
                modal.Visible = false;
                textBox2.ClearText();
            }

            Action<EverestMenuTextBox> SearchNextMod(bool inReverse)
            {
                return delegate(EverestMenuTextBox textBox2)
                {
                    var searchTarget = textBox2.Text.ToLower();
                    var items = menu.Items;
                    if (EverestMenuTextBox.WrappingLinearSearch(items, SearchNextPredicate,
                            menu.Selection + (!inReverse ? 1 : -1), inReverse, out var nextModIndex))
                    {
                        if (nextModIndex >= menu.Selection)
                            Audio.Play("event:/ui/main/rollover_down");
                        else
                            Audio.Play("event:/ui/main/rollover_up");

                        items[menu.Selection].OnLeave?.Invoke();
                        menu.Selection = nextModIndex;
                        items[nextModIndex].OnEnter?.Invoke();
                    }
                    else
                    {
                        Audio.Play("event:/ui/main/button_invalid");
                    }

                    bool SearchNextPredicate(TextMenuPresentation.Item item)
                    {
                        if (!item.Visible || !item.Selectable || item.Disabled) return false;

                        var num = menu.IndexOf(item);
                        if (num > 0 && menu.Items[num - 1] is TextMenuPresentation.SubHeader
                            {
                                Title: not null,
                            } subHeader && subHeader.Title.ToLower().Contains(searchTarget))
                            return true;

                        return item.SearchLabel()?.ToLower().Contains(searchTarget) ?? false;
                    }
                };
            }
        }

        public override IEnumerator Enter(OuiState from)
        {
            ReloadMenu();
            if (savedMenuIndex != -1 && typeof(IEverestModOptionsSubmenu).IsAssignableFrom(from.GetType()))
            {
                menu.Selection = Math.Min(savedMenuIndex, menu.LastPossibleSelection);
                var scrollPosition = menu.Position;
                scrollPosition.Y = menu.ScrollTargetY;
                menu.Position = scrollPosition;
            }

            var textMenu = menu;
            var ouiModOptions = this;
            var visible = true;
            ouiModOptions.Visible = true;
            textMenu.Visible = visible;
            menu.Focused = false;
            for (var p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                menu.X = 2880f + -1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                alpha = ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeOut(p);
                yield return null;
            }

            menu.Focused = true;
        }

        public override IEnumerator Leave(OuiState next)
        {
            Audio.Play("event:/ui/main/whoosh_large_out");
            menu.Focused = false;
            savedMenuIndex = menu.Selection;
            yield return ((IEverestSaveSettingsEnvironment)engine).SaveSettingsProcess.SaveSettings();
            for (var p = 0f; p < 1f; p += engine.Frame.DeltaTime * 4f)
            {
                menu.X = 960f + 1920f * ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                alpha = 1f - ((ISourceEasingEnvironment)engine).EasingArithmetic.CubeIn(p);
                yield return null;
            }

            var textMenu = menu;
            var ouiModOptions = this;
            var visible = false;
            ouiModOptions.Visible = false;
            textMenu.Visible = visible;
            menu.RemoveSelf();
            menu = null;
        }

        public override void Update()
        {
            if (menu != null && menu.Focused && Selected && Input.MenuCancel.Pressed)
            {
                Audio.Play("event:/ui/main/button_back");
                Overworld.Goto<MainMenuSequence>();
            }

            if (Selected && Focused && Input.QuickRestart.Pressed)
                startSearching?.Invoke();
            else
                base.Update();
        }

        public override void Render(ISourceRenderContext context)
        {
            if (alpha > 0f)
                SourcePrimitiveDrawing.Rect(context, this, -10f, -10f, 1940f, 1100f, PackedColor.Black * alpha * 0.4f);

            base.Render(context);
        }
    }
}

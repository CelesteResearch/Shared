using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;
using Celeste.Core.Display;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Content.Archives;
using Celeste.Everest.Content.Serialization;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Runtime;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime;
using Celeste.Everest.UI.Menus;
using Celeste.Everest.UI.ModOptions;
using Celeste.Everest.UI.Settings;
using Celeste.Game.Execution;
using Celeste.Game.Menus.Overworld;
using Celeste.Input.Runtime;
using Celeste.Simulation.UI.Menus.Text;
using Keys = Celeste.Input.Devices.Keyboard.SourceKeys;

namespace Celeste.Everest.UI.Mods.Toggling
{
    public class EverestModTogglerState : EverestGenericMenuState, IEverestModOptionsSubmenu
    {
        private static ISourceEngineContext Process => EngineRuntime.Instance.Process;
        private static EverestLoaderProcess Loader => ((IEverestLoaderProcessEnvironment)Process).Loader;

        private static SourceEverestModulesProcess Modules =>
            ((ISourceEverestModulesProcessEnvironment)Process).ModulesProcess;

        private static EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)Process).Logger;
        private SourceMInputProcess MInput => ((ISourceMInputEnvironment)engine).MInput;

        private List<string> allMods;

        private HashSet<string> blacklistedMods;

        private HashSet<string> blacklistedModsOriginal;

        private HashSet<string> favoriteMods;

        private HashSet<string> favoriteModsOriginal;

        private Dictionary<string, HashSet<string>> favoriteModDependencies;

        private bool toggleDependencies = true;

        private bool protectFavorites = true;

        private EverestMenuSubHeaderExt restartMessage1;

        private EverestMenuSubHeaderExt restartMessage2;

        private Dictionary<string, EverestModuleMetadata[]> modYamls;

        private Dictionary<string, string> modFilename;

        private Dictionary<string, TextMenuPresentation.OnOff> modToggles;

        private Task modLoadingTask;

        private Action startSearching;

        public override string MenuName => Dialog.Clean("MODOPTIONS_MODTOGGLE");

        internal static Dictionary<string, EverestModuleMetadata[]> LoadAllModYamls(Action<float> progressCallback)
        {
            var stopwatch = Stopwatch.StartNew();
            var num = 0;
            var num2 = Directory.GetFiles(Loader.PathMods).Length + Directory.GetDirectories(Loader.PathMods).Length;
            var dictionary = new Dictionary<string, EverestModuleMetadata[]>();
            var source =
                Modules.Modules.Select(module => module.Metadata);
            var files = Directory.GetFiles(Loader.PathMods);
            int i;
            for (i = 0; i < files.Length; i++)
            {
                progressCallback(num / (float)num2);
                num++;
                var fileName = Path.GetFileName(files[i]);
                if (fileName.EndsWith(".zip"))
                {
                    var array =
                        source.Where(meta => meta.PathArchive == files[i]).ToArray();
                    if (array.Length == 0) array = loadZip(Path.Combine(Loader.PathMods, fileName));

                    if (array != null) dictionary[fileName] = array;
                }
            }

            files = Directory.GetDirectories(Loader.PathMods);
            int i2;
            for (i2 = 0; i2 < files.Length; i2++)
            {
                progressCallback(num / (float)num2);
                num++;
                var fileName2 = Path.GetFileName(files[i2]);
                if (!(fileName2 == "Cache"))
                {
                    var array2 =
                        source.Where(meta => meta.PathDirectory == files[i2]).ToArray();
                    if (array2.Length == 0) array2 = loadDir(Path.Combine(Loader.PathMods, fileName2));

                    if (array2 != null) dictionary[fileName2] = array2;
                }
            }

            stopwatch.Stop();
            var sourceMessage1 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage1.ShouldLog)
                sourceMessage1.Write("" + "Found " + dictionary.Count + " mod(s) with yaml files, took " +
                                     stopwatch.ElapsedMilliseconds + " ms");
            return dictionary;
        }

        private static EverestModuleMetadata[] loadZip(string archive)
        {
            try
            {
                using var zipArchive = ZipFile.OpenRead(archive);
                foreach (var entry in zipArchive.Entries)
                {
                    if (entry.FullName == "metadata.yaml")
                        using (var stream = entry.ExtractStream())
                        {
                            using var input = new StreamReader(stream);
                            var everestModuleMetadata = ((IEverestYamlEnvironment)Process).Yaml
                                .Deserializer.Deserialize<EverestModuleMetadata>(input);
                            everestModuleMetadata.PathArchive = archive;
                            everestModuleMetadata.PostParse(
                                ((IEverestCoreModuleEnvironment)Process).CoreModule.Metadata);
                            return [everestModuleMetadata];
                        }

                    if (!(entry.FullName == "multimetadata.yaml") && !(entry.FullName == "everest.yaml") &&
                        !(entry.FullName == "everest.yml"))
                        continue;

                    using var stream2 = entry.ExtractStream();
                    using var streamReader = new StreamReader(stream2);
                    if (!streamReader.EndOfStream)
                    {
                        var array =
                            ((IEverestYamlEnvironment)Process).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                                streamReader);
                        var array2 = array;
                        foreach (var obj in array2)
                        {
                            obj.PathArchive = archive;
                            obj.PostParse(((IEverestCoreModuleEnvironment)Process).CoreModule.Metadata);
                        }

                        return array;
                    }
                }
            }
            catch (Exception value)
            {
                var sourceMessage2 = Logger.BeginEnabledMessage("loader", EverestLogLevel.Warn);
                if (sourceMessage2.ShouldLog)
                    sourceMessage2.Write("" + "Failed loading everest.yaml in archive " + archive + ": " + value);
            }

            return null;
        }

        private static EverestModuleMetadata[] loadDir(string dir)
        {
            try
            {
                var path = Path.Combine(dir, "metadata.yaml");
                if (File.Exists(path))
                {
                    using var input = new StreamReader(path);
                    var everestModuleMetadata =
                        ((IEverestYamlEnvironment)Process).Yaml.Deserializer.Deserialize<EverestModuleMetadata>(input);
                    everestModuleMetadata.PathDirectory = dir;
                    everestModuleMetadata.PostParse(((IEverestCoreModuleEnvironment)Process).CoreModule.Metadata);
                    return [everestModuleMetadata];
                }

                path = Path.Combine(dir, "multimetadata.yaml");
                if (!File.Exists(path)) path = Path.Combine(dir, "everest.yaml");

                if (!File.Exists(path)) path = Path.Combine(dir, "everest.yml");

                if (File.Exists(path))
                {
                    using var streamReader = new StreamReader(path);
                    if (!streamReader.EndOfStream)
                    {
                        var array =
                            ((IEverestYamlEnvironment)Process).Yaml.Deserializer.Deserialize<EverestModuleMetadata[]>(
                                streamReader);
                        var array2 = array;
                        foreach (var obj in array2)
                        {
                            obj.PathDirectory = dir;
                            obj.PostParse(((IEverestCoreModuleEnvironment)Process).CoreModule.Metadata);
                        }

                        return array;
                    }
                }
            }
            catch (Exception value)
            {
                var sourceMessage3 = Logger.BeginEnabledMessage("loader", EverestLogLevel.Warn);
                if (sourceMessage3.ShouldLog)
                    sourceMessage3.Write("" + "Failed loading everest.yaml in directory " + dir + ": " + value);
            }

            return null;
        }

        public EverestModTogglerState(ISourceEngineContext engine) : base(engine)
        {
            backToParentMenu = onBackPressed;
        }

        protected override void addOptionsToMenu(TextMenuPresentation menu)
        {
            var loading =
                new TextMenuPresentation.Button(Dialog.Clean("MODOPTIONS_MODTOGGLE_LOADING"))
                {
                    Disabled = true,
                };
            menu.Add(loading);
            modLoadingTask = new(delegate
            {
                var updateTimer = Stopwatch.StartNew();
                modYamls = LoadAllModYamls(delegate(float progress)
                {
                    if (updateTimer.ElapsedMilliseconds > 500)
                    {
                        updateTimer.Restart();
                        loading.Label = $"{Dialog.Clean("MODOPTIONS_MODTOGGLE_LOADING")} ({(int)(progress * 100f)}%)";
                    }
                });
                updateTimer.Stop();
                ((IEverestModuleRuntimeEnvironment)Process).MainThread.Schedule(delegate
                {
                    modToggles = new();
                    modFilename = BuildModFilenameDictionary(modYamls);
                    menu.Remove(loading);
                    if (Loader.Whitelist != null || Loader.TemporaryBlacklist != null)
                    {
                        var textMenu = menu;
                        var ouiModToggler = this;
                        var obj =
                            new EverestMenuSubHeaderExt(Dialog.Clean("MODOPTIONS_MODTOGGLE_WHITELISTWARN"))
                            {
                                TextColor = PackedColor.OrangeRed,
                            };
                        var item = obj;
                        ouiModToggler.restartMessage1 = obj;
                        textMenu.Add(item);
                    }

                    menu.Add(restartMessage1 =
                        new(Dialog.Clean("MODOPTIONS_MODTOGGLE_MESSAGE_1")));
                    menu.Add(restartMessage2 =
                        new(Dialog.Clean("MODOPTIONS_MODTOGGLE_MESSAGE_2"))
                        {
                            HeightExtra = 0f,
                        });
                    menu.Add(new EverestMenuSubHeaderExt(Dialog.Clean("MODOPTIONS_MODTOGGLE_MESSAGE_3"))
                    {
                        HeightExtra = 20f,
                        TextColor = PackedColor.Goldenrod,
                    });
                    if (Loader.Whitelist != null || Loader.TemporaryBlacklist != null)
                        restartMessage1.HeightExtra = 30f;

                    menu.Add(new TextMenuPresentation.Button(Dialog.Clean("MODOPTIONS_MODTOGGLE_ENABLEALL")).Pressed(
                        delegate
                        {
                            foreach (var value in modToggles.Values) value.Index = 1;

                            blacklistedMods.Clear();
                            updateHighlightedMods();
                        }));
                    menu.Add(new TextMenuPresentation.Button(Dialog.Clean("MODOPTIONS_MODTOGGLE_DISABLEALL")).Pressed(
                        delegate
                        {
                            blacklistedMods.Clear();
                            foreach (var modToggle in modToggles)
                            {
                                var flag2 = favoriteMods.Contains(modToggle.Key) ||
                                            favoriteModDependencies.ContainsKey(modToggle.Key);
                                if (!(protectFavorites && flag2))
                                {
                                    modToggle.Value.Index = 0;
                                    blacklistedMods.Add(modToggle.Key);
                                }
                            }

                            updateHighlightedMods();
                        }));
                    TextMenuPresentation.Item option;
                    menu.Add(option =
                        new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_MODTOGGLE_TOGGLEDEPS"), true,
                            engine).Change(delegate(bool value) { toggleDependencies = value; }));
                    option.AddDescription(menu, Dialog.Clean("MODOPTIONS_MODTOGGLE_TOGGLEDEPS_MESSAGE2"));
                    option.AddDescription(menu, Dialog.Clean("MODOPTIONS_MODTOGGLE_TOGGLEDEPS_MESSAGE1"));
                    TextMenuPresentation.Item item2;
                    menu.Add(item2 =
                        new TextMenuPresentation.OnOff(Dialog.Clean("MODOPTIONS_MODTOGGLE_PROTECTFAVORITES"),
                            protectFavorites, engine).Change(delegate(bool value) { protectFavorites = value; }));
                    var favoriteToolTip =
                        new EverestMenuEaseInSubMenuWithInputs(menu.Resources,
                            string.Format(Dialog.Get("MODOPTIONS_MODTOGGLE_PROTECTFAVORITES_MESSAGE"), '|'), '|',
                            [Input.MenuJournal], false)
                        {
                            TextColor = PackedColor.Gray,
                        };
                    menu.Add(favoriteToolTip);
                    item2.OnEnter = (Action)Delegate.Combine(item2.OnEnter,
                        (Action)delegate { favoriteToolTip.FadeVisible = true; });
                    item2.OnLeave = (Action)Delegate.Combine(item2.OnLeave,
                        (Action)delegate { favoriteToolTip.FadeVisible = false; });
                    menu.Add(new TextMenuPresentation.Button(Dialog.Clean("MODOPTIONS_MODTOGGLE_CANCEL")).Pressed(
                        delegate
                        {
                            blacklistedMods = blacklistedModsOriginal;
                            favoriteMods = favoriteModsOriginal;
                            onBackPressed(Overworld);
                        }));
                    AddSearchBox(menu);
                    allMods = [];
                    blacklistedMods = [];
                    favoriteMods = [];
                    favoriteModDependencies = new();
                    var directories = Directory.GetDirectories(Loader.PathMods);
                    Array.Sort(directories,
                        (a, b) => a.ToLowerInvariant().CompareTo(b.ToLowerInvariant()));
                    var flag = false;
                    for (var num = 0; num < directories.Length; num++)
                    {
                        var fileName = Path.GetFileName(directories[num]);
                        if (fileName != "Cache")
                        {
                            if (!flag)
                            {
                                menu.Add(new TextMenuPresentation.SubHeader(
                                    Dialog.Clean("MODOPTIONS_MODTOGGLE_DIRECTORIES")));
                                flag = true;
                            }

                            addFileToMenu(menu, fileName);
                        }
                    }

                    directories = Directory.GetFiles(Loader.PathMods);
                    Array.Sort(directories,
                        (a, b) => a.ToLowerInvariant().CompareTo(b.ToLowerInvariant()));
                    flag = false;
                    for (var num2 = 0; num2 < directories.Length; num2++)
                    {
                        var fileName2 = Path.GetFileName(directories[num2]);
                        if (fileName2.EndsWith(".zip"))
                        {
                            if (!flag)
                            {
                                menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("MODOPTIONS_MODTOGGLE_ZIPS")));
                                flag = true;
                            }

                            addFileToMenu(menu, fileName2);
                        }
                    }

                    directories = Directory.GetFiles(Loader.PathMods);
                    Array.Sort(directories,
                        (a, b) => a.ToLowerInvariant().CompareTo(b.ToLowerInvariant()));
                    flag = false;
                    for (var num3 = 0; num3 < directories.Length; num3++)
                    {
                        var fileName3 = Path.GetFileName(directories[num3]);
                        if (fileName3.EndsWith(".bin"))
                        {
                            if (!flag)
                            {
                                menu.Add(new TextMenuPresentation.SubHeader(Dialog.Clean("MODOPTIONS_MODTOGGLE_BINS")));
                                flag = true;
                            }

                            addFileToMenu(menu, fileName3);
                        }
                    }

                    allMods.Sort((a, b) => a.ToLowerInvariant().CompareTo(b.ToLowerInvariant()));
                    blacklistedModsOriginal = /* ReSharper disable once UseCollectionExpression */ new(blacklistedMods);
                    favoriteModsOriginal = /* ReSharper disable once UseCollectionExpression */ new(favoriteMods);
                    updateHighlightedMods();
                    menu.Y = menu.ScrollTargetY;
                    modLoadingTask = null;
                });
            });
            modLoadingTask.Start();
        }

        private void AddSearchBox(TextMenuPresentation menu)
        {
            var textBox = new EverestMenuTextBox(engine, Overworld)
            {
                PlaceholderText = Dialog.Clean("MODOPTIONS_MODTOGGLE_SEARCHBOX_PLACEHOLDER"),
            };
            var modal = new EverestMenuModal(textBox, null, 85f);
            menu.Add(modal);
            menu.Add(new EverestMenuSearchToolTip(engine));
            startSearching = delegate
            {
                modal.Visible = true;
                textBox.StartTyping();
            };
            textBox.OnTextInputCharActions['\t'] = SearchNextMod(false);
            textBox.OnTextInputCharActions['\n'] = delegate { };
            textBox.OnTextInputCharActions['\r'] = delegate(EverestMenuTextBox obj)
            {
                if (MInput.Keyboard.CurrentState.IsKeyDown(Keys.LeftShift) ||
                    MInput.Keyboard.CurrentState.IsKeyDown(Keys.RightShift))
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
                        ExitSearch(textBox);
                    else if (Input.MenuDown.Pressed)
                        SearchNextMod(false)(textBox);
                    else if (Input.MenuUp.Pressed) SearchNextMod(true)(textBox);
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
                    _ = menu.Selection;
                    if (EverestMenuTextBox.WrappingLinearSearch(items, SearchPredicate,
                            menu.Selection + (!inReverse ? 1 : -1), inReverse, out var nextModIndex))
                    {
                        if (nextModIndex >= menu.Selection)
                            Audio.Play("event:/ui/main/rollover_down");
                        else
                            Audio.Play("event:/ui/main/rollover_up");

                        menu.Selection = nextModIndex;
                    }
                    else
                    {
                        Audio.Play("event:/ui/main/button_invalid");
                    }

                    bool SearchPredicate(TextMenuPresentation.Item item)
                    {
                        if (item is TextMenuPresentation.Option<bool> option && modToggles.ContainsKey(option.Label))
                            return option.Label.ToLower().Contains(searchTarget);

                        return false;
                    }
                };
            }
        }

        private void addFileToMenu(TextMenuPresentation menu, string file)
        {
            var flag = !Loader.Blacklist.Contains(file);
            var num = Loader.Favorites.Contains(file);
            var option =
                new TextMenuPresentation.OnOff(file.Length > 40 ? file.Substring(0, 40) + "..." : file, flag,
                    engine);
            option.Change(delegate(bool b)
            {
                if (b)
                    removeFromBlacklist(file);
                else
                    addToBlacklist(file);

                updateHighlightedMods();
            }).AltPressed(delegate
            {
                if (!favoriteMods.Contains(file))
                {
                    Audio.Play("event:/ui/main/button_toggle_on");
                    addToFavorites(file);
                }
                else
                {
                    Audio.Play("event:/ui/main/button_toggle_off");
                    removeFromFavorites(file);
                }

                option.SelectWiggler.Start();
                updateHighlightedMods();
            });
            menu.Add(option);
            allMods.Add(file);
            if (!flag) blacklistedMods.Add(file);

            if (num) addToFavorites(file);

            modToggles[file] = option;
        }

        private Dictionary<string, string> BuildModFilenameDictionary(
            Dictionary<string, EverestModuleMetadata[]> modYamls)
        {
            var dictionary = new Dictionary<string, EverestModuleMetadata>();
            foreach (var modYaml in modYamls)
            {
                var value = modYaml.Value;
                foreach (var everestModuleMetadata in value)
                    if (dictionary.TryGetValue(everestModuleMetadata.Name, out var value2))
                    {
                        if (value2.Version < everestModuleMetadata.Version)
                            dictionary[everestModuleMetadata.Name] = everestModuleMetadata;
                    }
                    else
                    {
                        dictionary[everestModuleMetadata.Name] = everestModuleMetadata;
                    }
            }

            return dictionary.ToDictionary(dictEntry => dictEntry.Key,
                dictEntry =>
                    Path.GetFileName(dictEntry.Value.PathArchive ?? dictEntry.Value.PathDirectory));
        }

        private void updateHighlightedMods()
        {
            foreach (var modToggle in modToggles)
            {
                var unselectedColor = PackedColor.White;
                if (favoriteMods.Contains(modToggle.Key))
                    unselectedColor = PackedColor.DeepPink;
                else if (favoriteModDependencies.ContainsKey(modToggle.Key))
                    unselectedColor = PackedColor.LightPink;
                else if (modHasDependencies(modToggle.Key)) unselectedColor = PackedColor.Goldenrod;

                modToggle.Value.UnselectedColor = unselectedColor;
            }

            if (blacklistedModsOriginal.SetEquals(blacklistedMods))
            {
                restartMessage1.TextColor = PackedColor.Gray;
                restartMessage2.TextColor = PackedColor.Gray;
            }
            else
            {
                restartMessage1.TextColor = PackedColor.OrangeRed;
                restartMessage2.TextColor = PackedColor.OrangeRed;
            }
        }

        public override void Update()
        {
            canGoBack = modLoadingTask == null || modLoadingTask.IsCompleted || modLoadingTask.IsCanceled ||
                        modLoadingTask.IsFaulted;
            if (Selected && Focused && Input.QuickRestart.Pressed)
                startSearching?.Invoke();
            else
                base.Update();
        }

        private void addToBlacklist(string file)
        {
            if (blacklistedMods.Contains(file)) return;

            blacklistedMods.Add(file);
            var sourceMessage4 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage4.ShouldLog) sourceMessage4.Write("" + file + " was added to the blacklist");
            if (!toggleDependencies || !modYamls.TryGetValue(file, out var value)) return;

            var array = value;
            foreach (var everestModuleMetadata in array)
            {
                var modName = everestModuleMetadata.Name;
                foreach (var modYaml in modYamls)
                    if (!blacklistedMods.Contains(modYaml.Key) && modYaml.Value.Any(otherMeta =>
                            otherMeta.Dependencies.Any(dependency =>
                                dependency.Name == modName)))
                    {
                        addToBlacklist(modYaml.Key);
                        modToggles[modYaml.Key].Index = 0;
                    }
            }
        }

        private void removeFromBlacklist(string file)
        {
            if (!blacklistedMods.Contains(file)) return;

            blacklistedMods.Remove(file);
            var sourceMessage5 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage5.ShouldLog) sourceMessage5.Write("" + file + " was removed from the blacklist");
            if (!toggleDependencies || !TryGetModDependenciesFileNames(file, out var dependenciesFileNames)) return;

            foreach (var item in dependenciesFileNames)
            {
                removeFromBlacklist(item);
                modToggles[item].Index = 1;
            }
        }

        private void addToFavorites(string modFileName)
        {
            favoriteMods.Add(modFileName);
            var sourceMessage6 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage6.ShouldLog) sourceMessage6.Write("" + modFileName + " was added to favorites");
            if (!TryGetModDependenciesFileNames(modFileName, out var dependenciesFileNames)) return;

            foreach (var item in dependenciesFileNames) addToFavoritesDependencies(item, modFileName);
        }

        private void addToFavoritesDependencies(string modFileName, string dependentModFileName)
        {
            HashSet<string> value;
            var flag = favoriteModDependencies.TryGetValue(modFileName, out value);
            if ((flag && value.Contains(dependentModFileName)) || modFileName == dependentModFileName) return;

            if (!flag)
            {
                var hashSet = favoriteModDependencies[modFileName] = [];
                value = hashSet;
            }

            value.Add(dependentModFileName);
            var sourceMessage7 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage7.ShouldLog)
                sourceMessage7.Write(
                    "" + modFileName + " was added as a favorite dependency of " + dependentModFileName);
            if (!TryGetModDependenciesFileNames(modFileName, out var dependenciesFileNames)) return;

            foreach (var item in dependenciesFileNames) addToFavoritesDependencies(item, dependentModFileName);
        }

        private void removeFromFavorites(string modFileName)
        {
            favoriteMods.Remove(modFileName);
            var sourceMessage8 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage8.ShouldLog) sourceMessage8.Write("" + modFileName + " was removed from favorites");
            if (!TryGetModDependenciesFileNames(modFileName, out var dependenciesFileNames)) return;

            foreach (var item in dependenciesFileNames) removeFromFavoritesDependencies(item, modFileName);
        }

        private void removeFromFavoritesDependencies(string modFileName, string dependentModFileName)
        {
            if (!favoriteModDependencies.TryGetValue(modFileName, out var value) ||
                !value.Contains(dependentModFileName))
                return;

            value.Remove(dependentModFileName);
            var sourceMessage9 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
            if (sourceMessage9.ShouldLog)
                sourceMessage9.Write("" + modFileName + " was removed from being a favorite dependency of " +
                                     dependentModFileName);
            if (value.Count == 0)
            {
                favoriteModDependencies.Remove(modFileName);
                var sourceMessage10 = Logger.BeginEnabledMessage("OuiModToggler", EverestLogLevel.Verbose);
                if (sourceMessage10.ShouldLog)
                    sourceMessage10.Write("" + modFileName + " is no longer a favorite dependency");
            }

            if (!TryGetModDependenciesFileNames(modFileName, out var dependenciesFileNames)) return;

            foreach (var item in dependenciesFileNames) removeFromFavoritesDependencies(item, dependentModFileName);
        }

        private void onBackPressed(OverworldSequence overworld)
        {
            if (modLoadingTask != null && !modLoadingTask.IsCompleted && !modLoadingTask.IsCanceled &&
                !modLoadingTask.IsFaulted)
                return;

            if (!favoriteModsOriginal.SetEquals(favoriteMods))
            {
                Loader.Favorites = favoriteMods;
                using var streamWriter = File.CreateText(Loader.PathFavorites);
                streamWriter.WriteLine("# This is the favorite list. Lines starting with # are ignored.");
                streamWriter.WriteLine("");
                foreach (var favoriteMod in favoriteMods) streamWriter.WriteLine(favoriteMod);
            }

            if (blacklistedModsOriginal.SetEquals(blacklistedMods))
            {
                overworld.Goto<EverestModOptionsState>();
                return;
            }

            using (var streamWriter2 = File.CreateText(Loader.PathBlacklist))
            {
                streamWriter2.WriteLine("# This is the blacklist. Lines starting with # are ignored.");
                streamWriter2.WriteLine("# File generated through the \"Toggle Mods\" menu in Mod Options");
                streamWriter2.WriteLine("");
                foreach (var allMod in allMods)
                    streamWriter2.WriteLine(blacklistedMods.Contains(allMod) ? allMod : "# " + allMod);
            }

            ((IEverestRestartEnvironment)Process).Restart.QuickFullRestart();
        }

        private bool TryGetModDependenciesFileNames(string modFilename, out List<string> dependenciesFileNames)
        {
            if (modYamls.TryGetValue(modFilename, out var value))
            {
                dependenciesFileNames = [];
                var array = value;
                for (var i = 0; i < array.Length; i++)
                    foreach (var item in array[i].Dependencies.Select(dep => dep.Name))
                        if (this.modFilename.TryGetValue(item, out var value2))
                            dependenciesFileNames.Add(value2);

                return true;
            }

            dependenciesFileNames = null;
            return false;
        }

        private bool modHasDependencies(string modFilename)
        {
            if (modYamls.TryGetValue(modFilename, out var value))
                return value.Any(delegate(EverestModuleMetadata metadata)
                {
                    var modName = metadata.Name;
                    return modYamls.Any(mod =>
                        !blacklistedMods.Contains(mod.Key) && modFilename != mod.Key &&
                        mod.Value.Any(yaml =>
                            yaml.Dependencies.Any(dependency => dependency.Name == modName)));
                });

            return false;
        }

        public override void Render(ISourceRenderContext context)
        {
            base.Render(context);
        }

        public override IEnumerator Leave(OuiState next)
        {
            var orig = base.Leave(next);
            while (orig.MoveNext()) yield return orig.Current;

            allMods = null;
            blacklistedMods = null;
            blacklistedModsOriginal = null;
            restartMessage1 = null;
            restartMessage2 = null;
            modYamls = null;
            modFilename = null;
            modToggles = null;
            modLoadingTask = null;
            toggleDependencies = true;
            protectFavorites = true;
            favoriteMods = null;
            favoriteModsOriginal = null;
            favoriteModDependencies = null;
        }
    }
}

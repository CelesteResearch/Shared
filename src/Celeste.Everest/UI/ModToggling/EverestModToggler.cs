using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Celeste.Everest.Modules.Runtime;
using YamlDotNet.Serialization;

namespace Celeste.Everest.UI.ModToggling
{
    // OuiModToggler's filename-based state, independent of the presentation engine.
    // No content unload occurs here: blacklist.txt is consumed by the next boot scan.
    public sealed class EverestModToggler
    {
        private readonly string modsDirectory;
        private readonly List<string> allMods = [];
        private readonly List<string> directoryMods = [];
        private readonly List<string> zipMods = [];
        private readonly List<string> binMods = [];

        private readonly Dictionary<string, EverestModuleMetadata[]> modYamls =
            new();

        private readonly Dictionary<string, string> modFilename = new();

        private readonly Dictionary<string, HashSet<string>> favoriteDependencies = new();

        private HashSet<string> blacklisted = [];
        private HashSet<string> favorites = [];
        private HashSet<string> originalBlacklist, originalFavorites;

        public IReadOnlyList<string> AllMods => allMods;
        public IReadOnlyList<string> DirectoryMods => directoryMods;
        public IReadOnlyList<string> ZipMods => zipMods;
        public IReadOnlyList<string> BinMods => binMods;

        public IReadOnlyDictionary<string, EverestModuleMetadata[]> Metadata =>
            modYamls;

        public bool ToggleDependencies { get; set; } = true;
        public bool ProtectFavorites { get; set; } = true;
        public bool BlacklistChanged => !originalBlacklist.SetEquals(blacklisted);
        public bool FavoritesChanged => !originalFavorites.SetEquals(favorites);
        public bool NeedsRestart => BlacklistChanged;
        public bool WhitelistWarning { get; }

        private EverestModToggler(string modsDirectory, bool whitelistWarning)
        {
            this.modsDirectory = Path.GetFullPath(modsDirectory);
            WhitelistWarning = whitelistWarning;
        }

        public static EverestModToggler Load(string modsDirectory,
            EverestModuleMetadata core,
            bool whitelistWarning = false, Action<float> progress = null, Action<string, Exception> error = null)
        {
            if (core == null) throw new ArgumentNullException(nameof(core));
            var state = new EverestModToggler(modsDirectory, whitelistWarning);
            if (!Directory.Exists(state.modsDirectory)) Directory.CreateDirectory(state.modsDirectory);
            var files = Directory.GetFiles(state.modsDirectory);
            var dirs = Directory.GetDirectories(state.modsDirectory);
            int processed = 0, total = files.Length + dirs.Length;
            // LoadAllModYamls scans files before directories, in OS enumeration order.
            foreach (var path in files)
            {
                progress?.Invoke(total == 0 ? 0 : (float)processed / total);
                processed++;
                if (!Path.GetFileName(path).EndsWith(".zip", StringComparison.Ordinal)) continue;
                var metadata = ReadZip(path, core, error);
                if (metadata != null) state.modYamls.Add(Path.GetFileName(path), metadata);
            }

            foreach (var path in dirs)
            {
                progress?.Invoke(total == 0 ? 0 : (float)processed / total);
                processed++;
                var name = Path.GetFileName(path);
                if (name == "Cache") continue;
                var metadata = ReadDirectory(path, core, error);
                if (metadata != null) state.modYamls.Add(name, metadata);
            }

            // Newest metadata version wins. Equal versions retain the first source.
            var newest = new Dictionary<string, EverestModuleMetadata>();
            foreach (var pair in state.modYamls)
            foreach (var module in pair.Value)
                if (!newest.TryGetValue(module.Name, out var previous) || previous.Version < module.Version)
                    newest[module.Name] = module;
            foreach (var pair in newest)
                state.modFilename[pair.Key] = Path.GetFileName(pair.Value.PathArchive ?? pair.Value.PathDirectory);

            state.blacklisted = ReadNames(Path.Combine(state.modsDirectory, "blacklist.txt"));
            state.favorites = ReadNames(Path.Combine(state.modsDirectory, "favorites.txt"));
            foreach (var dir in dirs.OrderBy(path => path.ToLowerInvariant(), StringComparer.CurrentCulture))
                if (Path.GetFileName(dir) != "Cache")
                    state.directoryMods.Add(Path.GetFileName(dir));
            foreach (var file in files.OrderBy(path => path.ToLowerInvariant(), StringComparer.CurrentCulture))
                if (Path.GetFileName(file).EndsWith(".zip", StringComparison.Ordinal))
                    state.zipMods.Add(Path.GetFileName(file));
            foreach (var file in files.OrderBy(path => path.ToLowerInvariant(), StringComparer.CurrentCulture))
                if (Path.GetFileName(file).EndsWith(".bin", StringComparison.Ordinal))
                    state.binMods.Add(Path.GetFileName(file));
            state.allMods.AddRange(state.directoryMods);
            state.allMods.AddRange(state.zipMods);
            state.allMods.AddRange(state.binMods);
            state.allMods.Sort((a, b) => a.ToLowerInvariant().CompareTo(b.ToLowerInvariant()));
            var visible = new HashSet<string>(state.allMods);
            state.blacklisted.RemoveWhere(file => !visible.Contains(file));
            state.favorites.RemoveWhere(file => !visible.Contains(file));
            foreach (var favorite in state.allMods)
                if (state.favorites.Contains(favorite))
                    state.AddFavoriteDependencies(favorite);
            state.originalBlacklist = /* ReSharper disable once UseCollectionExpression */ new(state.blacklisted);
            state.originalFavorites = /* ReSharper disable once UseCollectionExpression */ new(state.favorites);
            return state;
        }

        private static HashSet<string> ReadNames(string path)
        {
            var result = new HashSet<string>();
            if (File.Exists(path))
                foreach (var line in File.ReadAllLines(path))
                {
                    var name = (line.StartsWith("#", StringComparison.Ordinal) ? "" : line).Trim();
                    if (name.Length != 0) result.Add(name);
                }

            return result;
        }

        private static EverestModuleMetadata[] Parse(string yaml, bool single,
            string directory,
            string archive, EverestModuleMetadata core)
        {
            var deserializer = new DeserializerBuilder().IgnoreUnmatchedProperties().Build();
            var values = single
                ?
                [
                    deserializer.Deserialize<EverestModuleMetadata>(yaml),
                ]
                : deserializer.Deserialize<EverestModuleMetadata[]>(yaml);
            if (values == null) return null;
            foreach (var metadata in values)
            {
                metadata.PathDirectory = directory;
                metadata.PathArchive = archive;
                metadata.Multimeta = values;
                metadata.PostParse(core);
            }

            return values;
        }

        private static EverestModuleMetadata[] ReadZip(string path,
            EverestModuleMetadata core,
            Action<string, Exception> error)
        {
            try
            {
                using (var zip = ZipFile.OpenRead(path))
                {
                    foreach (var entry in zip.Entries)
                    {
                        var single = entry.FullName == "metadata.yaml";
                        if (!single && entry.FullName != "multimetadata.yaml" &&
                            entry.FullName != "everest.yaml" && entry.FullName != "everest.yml") continue;
                        using (var reader = new StreamReader(entry.Open()))
                        {
                            var yaml = reader.ReadToEnd();
                            if (!single && yaml.Length == 0) continue;
                            return Parse(yaml, single, null, path, core);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                error?.Invoke(path, e);
            }

            return null;
        }

        private static EverestModuleMetadata[] ReadDirectory(string path,
            EverestModuleMetadata core,
            Action<string, Exception> error)
        {
            try
            {
                var single = Path.Combine(path, "metadata.yaml");
                if (File.Exists(single)) return Parse(File.ReadAllText(single), true, path, null, core);
                foreach (var name in new[] { "multimetadata.yaml", "everest.yaml", "everest.yml" })
                {
                    var file = Path.Combine(path, name);
                    if (File.Exists(file))
                    {
                        var yaml = File.ReadAllText(file);
                        return yaml.Length == 0 ? null : Parse(yaml, false, path, null, core);
                    }
                }
            }
            catch (Exception e)
            {
                error?.Invoke(path, e);
            }

            return null;
        }

        public bool Enabled(string file)
        {
            return !blacklisted.Contains(file);
        }

        public bool Favorite(string file)
        {
            return favorites.Contains(file);
        }

        public bool IsFavoriteDependency(string file)
        {
            return favoriteDependencies.ContainsKey(file);
        }

        private IEnumerable<string> Dependencies(string file)
        {
            if (!modYamls.TryGetValue(file, out var metadatas)) yield break;
            foreach (var metadata in metadatas)
            foreach (var dependency in metadata.Dependencies)
                if (modFilename.TryGetValue(dependency.Name, out var dependencyFile))
                    yield return dependencyFile;
        }

        public void SetEnabled(string file, bool enabled)
        {
            if (enabled) RemoveFromBlacklist(file);
            else AddToBlacklist(file);
        }

        private void AddToBlacklist(string file)
        {
            if (!blacklisted.Add(file)) return;
            if (!ToggleDependencies || !modYamls.TryGetValue(file, out var metadatas)) return;
            foreach (var metadata in metadatas)
            foreach (var other in modYamls)
                if (!blacklisted.Contains(other.Key) && other.Value.Any(candidate =>
                        candidate.Dependencies.Any(dependency => dependency.Name == metadata.Name)))
                    AddToBlacklist(other.Key);
        }

        private void RemoveFromBlacklist(string file)
        {
            if (!blacklisted.Remove(file)) return;
            if (ToggleDependencies && modYamls.ContainsKey(file))
                foreach (var dependency in Dependencies(file))
                    RemoveFromBlacklist(dependency);
        }

        public void EnableAll()
        {
            blacklisted.Clear();
        }

        public void DisableAll()
        {
            blacklisted.Clear();
            foreach (var file in allMods)
                if (!ProtectFavorites || (!favorites.Contains(file) && !favoriteDependencies.ContainsKey(file)))
                    blacklisted.Add(file);
        }

        public void SetFavorite(string file, bool favorite)
        {
            if (favorite)
            {
                favorites.Add(file);
                AddFavoriteDependencies(file);
            }
            else
            {
                favorites.Remove(file);
                RemoveFavoriteDependencies(file);
            }
        }

        private void AddFavoriteDependencies(string favorite)
        {
            foreach (var file in Dependencies(favorite)) AddFavoriteDependency(file, favorite);
        }

        private void AddFavoriteDependency(string file, string favorite)
        {
            if (file == favorite) return;
            if (!favoriteDependencies.TryGetValue(file, out var dependents))
                favoriteDependencies[file] = dependents = [];
            if (!dependents.Add(favorite)) return;
            foreach (var dependency in Dependencies(file)) AddFavoriteDependency(dependency, favorite);
        }

        private void RemoveFavoriteDependencies(string favorite)
        {
            foreach (var file in Dependencies(favorite)) RemoveFavoriteDependency(file, favorite);
        }

        private void RemoveFavoriteDependency(string file, string favorite)
        {
            if (!favoriteDependencies.TryGetValue(file, out var dependents) || !dependents.Remove(favorite)) return;
            if (dependents.Count == 0) favoriteDependencies.Remove(file);
            foreach (var dependency in Dependencies(file)) RemoveFavoriteDependency(dependency, favorite);
        }

        public EverestModHighlight Highlight(string file)
        {
            if (favorites.Contains(file)) return EverestModHighlight.Favorite;
            if (favoriteDependencies.ContainsKey(file))
                return EverestModHighlight.FavoriteDependency;
            if (modYamls.TryGetValue(file, out var metadatas) &&
                metadatas.Any(metadata => modYamls.Any(other => other.Key != file && !blacklisted.Contains(other.Key) &&
                                                                other.Value.Any(candidate =>
                                                                    candidate.Dependencies.Any(dep =>
                                                                        dep.Name == metadata.Name)))))
                return EverestModHighlight.Required;
            return EverestModHighlight.Normal;
        }

        public void Cancel()
        {
            blacklisted = originalBlacklist;
            favorites = originalFavorites;
        }

        public bool Save()
        {
            if (FavoritesChanged)
                using (var writer = File.CreateText(Path.Combine(modsDirectory, "favorites.txt")))
                {
                    writer.WriteLine("# This is the favorite list. Lines starting with # are ignored.");
                    writer.WriteLine();
                    foreach (var file in favorites) writer.WriteLine(file);
                }

            if (!BlacklistChanged) return false;
            using (var writer = File.CreateText(Path.Combine(modsDirectory, "blacklist.txt")))
            {
                writer.WriteLine("# This is the blacklist. Lines starting with # are ignored.");
                writer.WriteLine("# File generated through the \"Toggle Mods\" menu in Mod Options");
                writer.WriteLine();
                foreach (var file in allMods)
                    writer.WriteLine(blacklisted.Contains(file) ? file : "# " + file);
            }

            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading;
using Celeste.Everest.Modules.Dependencies;
using Celeste.Everest.Modules.Runtime;
using MAB.DotIgnore;
using YamlDotNet.Serialization;

namespace Celeste.Everest.Content.Packages
{
    // Catalog of explicitly registered content sources. Discovering a file on disk never
    // claims that its DLL, settings, or game hooks have been loaded.
    public sealed class EverestManifestCatalog
    {
        private static long nextRegistrationId;

        private readonly List<EverestContentPackage> packages = [];

        private readonly Dictionary<string, EverestContentPackage> maps =
            new(StringComparer
                .Ordinal);

        private readonly Dictionary<string, EverestModuleMetadata> modules =
            new(
                StringComparer.Ordinal);

        private readonly Dictionary<string, List<EverestModuleMetadata>>
            moduleLayers =
                new(
                    StringComparer.Ordinal);

        private readonly Dictionary<string, int> gameBananaIds = new(StringComparer.Ordinal);

        public static EverestManifestCatalog Shared { get; } =
            CreateRuntimeCatalog();

        private static EverestManifestCatalog CreateRuntimeCatalog()
        {
            var catalog = new EverestManifestCatalog();
            catalog.RegisterModule(new() { Name = "Celeste", VersionString = "1.4.0.0" });
            catalog.RegisterModule(
                new() { Name = "Everest", VersionString = "1.6580.0", ReferenceVersion = "1.6580.0" });
            return catalog;
        }

        public IReadOnlyCollection<EverestModuleMetadata> Modules =>
            modules.Values;

        // Model the module view after revoking selected content layers, without
        // changing registration identity or invoking any code-module lifecycle.
        public IReadOnlyDictionary<string, EverestModuleMetadata>
            ModulesWithout(
                IEnumerable<EverestContentPackage> departing)
        {
            if (departing == null) throw new ArgumentNullException(nameof(departing));
            var excluded = new HashSet<EverestModuleMetadata>(
                departing.SelectMany(package =>
                    package?.Metadata ??
                    throw new ArgumentException("A departing package is null", nameof(departing))));
            var result =
                new Dictionary<string, EverestModuleMetadata>(StringComparer
                    .Ordinal);
            foreach (var pair in moduleLayers)
            {
                var surviving = pair.Value.LastOrDefault(module => !excluded.Contains(module));
                if (surviving != null) result.Add(pair.Key, surviving);
            }

            return result;
        }

        public IReadOnlyList<EverestContentPackage> Packages => packages;
        public int ContentGeneration { get; private set; }
        public Action<string, Exception> ManifestFailed;

        public void RegisterModule(EverestModuleMetadata metadata)
        {
            if (metadata == null || string.IsNullOrEmpty(metadata.Name))
                throw new ArgumentException("Module metadata needs a name");
            if (!moduleLayers.TryGetValue(metadata.Name, out var layers))
                moduleLayers[metadata.Name] =
                    layers = [];
            if (!layers.Any(value => ReferenceEquals(value, metadata))) layers.Add(metadata);
            modules[metadata.Name] = layers[layers.Count - 1];
        }

        public void UnregisterModule(EverestModuleMetadata metadata)
        {
            if (metadata == null || !moduleLayers.TryGetValue(metadata.Name, out var layers)) return;
            layers.RemoveAll(value => ReferenceEquals(value, metadata));
            if (layers.Count == 0)
            {
                moduleLayers.Remove(metadata.Name);
                modules.Remove(metadata.Name);
            }
            else
            {
                modules[metadata.Name] = layers[layers.Count - 1];
            }
        }

        public EverestModuleMetadata GetModule(string name)
        {
            return name != null && modules.TryGetValue(name, out var value) ? value : null;
        }

        public EverestContentPackage MapSource(string sid)
        {
            return maps.TryGetValue(sid, out var value) ? value : null;
        }

        public void LoadUpdateList(string yaml)
        {
            var entries = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                .Deserialize<Dictionary<string, EverestModUpdateInfo>>(
                    yaml);
            gameBananaIds.Clear();
            if (entries != null)
                foreach (var item in entries)
                    gameBananaIds[item.Key] = item.Value.GameBananaId;
        }

        public void SetUpdateInfo(string module, int gameBananaId)
        {
            gameBananaIds[module] = gameBananaId;
        }

        public int GetGameBananaId(string module)
        {
            return gameBananaIds.TryGetValue(module, out var value) ? value : 0;
        }

        public static EverestModuleMetadata[] Parse(string yaml,
            EverestModuleMetadata core, string directory = null,
            string archive = null)
        {
            var values = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                .Deserialize<EverestModuleMetadata[]>(yaml);
            if (values == null) throw new InvalidDataException("The module manifest contains no modules");
            foreach (var metadata in values)
            {
                if (metadata == null || string.IsNullOrEmpty(metadata.Name))
                    throw new InvalidDataException("The module manifest contains an unnamed module");
                metadata.PathDirectory = directory;
                metadata.PathArchive = archive;
                metadata.Multimeta = values;
                metadata.PostParse(core);
            }

            return values;
        }

        private static bool IsMap(string sourcePath, IgnoreList ignore)
        {
            var path = sourcePath.Replace('\\', '/');
            if (!path.StartsWith("Maps/", StringComparison.Ordinal) ||
                !path.EndsWith(".bin", StringComparison.Ordinal)) return false;
            if (Path.GetFileNameWithoutExtension(path).StartsWith(".", StringComparison.Ordinal))
                return false;
            var directories = path.Split('/');
            for (var i = 0; i < directories.Length - 1; i++)
                if (directories[i].StartsWith(".", StringComparison.Ordinal) ||
                    new[] { "lib-stripped", "__MACOSX", "obj" }.Contains(directories[i],
                        StringComparer.OrdinalIgnoreCase))
                    return false;
            return ignore?.IsIgnored(path, false) != true;
        }

        private static bool IsAsset(string sourcePath, IgnoreList ignore)
        {
            var path = sourcePath.Replace('\\', '/');
            if (path.Length == 0 || path.StartsWith("/", StringComparison.Ordinal) ||
                path.EndsWith("/", StringComparison.Ordinal)) return false;
            var segments = path.Split('/');
            foreach (var segment in segments)
                if (segment.Length == 0 || segment == "." || segment == ".." ||
                    segment.StartsWith(".", StringComparison.Ordinal)
                    || new[] { "lib-stripped", "__MACOSX", "obj" }.Contains(segment, StringComparer.OrdinalIgnoreCase))
                    return false;
            return ignore?.IsIgnored(path, false) != true;
        }

        public EverestContentPackage RegisterContentPackage(string path,
            EverestModuleMetadata core)
        {
            return RegisterInspectedContentPackage(InspectContentPackage(path, core));
        }

        // The cold-start loader activates an already inspected source at the
        // exact contentCrawl slot. Its NullModules are registered one by one by
        // the module scheduler, not all at once with the content layer.
        public EverestContentPackage RegisterInspectedContentPackage(
            EverestContentPackage package,
            bool registerContentModules = true)
        {
            if (package == null) throw new ArgumentNullException(nameof(package));
            if (package.IsRegistered)
                throw new InvalidOperationException("Content source is already registered: " + package.Path);
            package.IsRegistered = true;
            package.RegistrationId = Interlocked.Increment(ref nextRegistrationId);
            packages.Add(package);
            foreach (var map in package.Maps) maps[map] = package;
            ContentGeneration++;
            // Content-only packages are real loaded modules as soon as their content is registered.
            // Code modules are only exposed once the host registers their actual module instance.
            if (registerContentModules)
                foreach (var module in package.Metadata)
                    if (string.IsNullOrEmpty(module.DLL))
                        RegisterModule(module);
            return package;
        }

        // Read and validate a source without activating it or allocating page identity.
        // A replacement preflight must not change the running catalog.
        public EverestContentPackage InspectContentPackage(string path,
            EverestModuleMetadata core,
            Action<string, Exception> onManifestFailed = null)
        {
            path = Path.GetFullPath(path);
            var archive = !Directory.Exists(path);
            string yaml = null;
            string[] content;
            IgnoreList ignore = null;
            if (archive)
            {
                using (var zip = ZipFile.OpenRead(path))
                {
                    var manifest = zip.Entries.FirstOrDefault(entry =>
                        entry.FullName == "everest.yaml" || entry.FullName == "everest.yml");
                    if (manifest != null)
                        using (var reader = new StreamReader(manifest.Open()))
                        {
                            yaml = reader.ReadToEnd();
                        }

                    var ignoreEntry = zip.GetEntry(".everestignore");
                    if (ignoreEntry != null)
                        using (var reader = new StreamReader(ignoreEntry.Open()))
                        {
                            ignore = new(reader.ReadToEnd().Replace("\r\n", "\n").Split('\n'));
                        }

                    content =
                    [
                        .. zip.Entries.Select(entry => entry.FullName).Where(name => IsAsset(name, ignore)),
                    ];
                }
            }
            else
            {
                var manifest = Path.Combine(path, "everest.yaml");
                if (!File.Exists(manifest)) manifest = Path.Combine(path, "everest.yml");
                if (File.Exists(manifest)) yaml = File.ReadAllText(manifest);
                var ignorePath = Path.Combine(path, ".everestignore");
                if (File.Exists(ignorePath)) ignore = new(ignorePath);
                content =
                [
                    .. Directory.GetFiles(path, "*", SearchOption.AllDirectories)
                        .Select(file => file.Substring(path.Length + 1).Replace('\\', '/'))
                        .Where(name => IsAsset(name, ignore)),
                ];
            }

            EverestModuleMetadata[] metadata = null;
            if (!string.IsNullOrEmpty(yaml))
                try
                {
                    metadata = Parse(yaml, core, archive ? null : path, archive ? path : null);
                }
                catch (Exception error)
                {
                    ManifestFailed?.Invoke(path, error);
                    onManifestFailed?.Invoke(path, error);
                }

            if (metadata == null)
            {
                var dummy = new EverestModuleMetadata
                {
                    Name = archive
                        ? "_zip_" + Path.GetFileNameWithoutExtension(path)
                        : "_dir_" + Path.GetFileName(path),
                    VersionString = "0.0.0-dummy", PathArchive = archive ? path : null,
                    PathDirectory = archive ? null : path,
                };
                dummy.PostParse(core);
                metadata = [dummy];
            }

            return new(path, archive, metadata, content);
        }

        public void UnregisterContentPackage(EverestContentPackage package)
        {
            if (package == null || !packages.Remove(package)) return;
            package.IsRegistered = false;
            ContentGeneration++;
            maps.Clear();
            foreach (var remaining in packages)
            foreach (var map in remaining.Maps)
                maps[map] = remaining;
            foreach (var module in package.Metadata) UnregisterModule(module);
        }
    }
}

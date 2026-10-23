using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using YamlDotNet.Serialization;
using Celeste.Everest;

namespace Celeste.Everest.Modules.Dependencies
{
    // Shared network/file backend. The host owns the confirmation UI, target profile,
    // module unload/restart and post-install module activation; no TAS/Unity dependency.
    public sealed class EverestDependencyDownloader
    {
        private sealed class DependencyGraphEntry
        {
            public List<global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo> Dependencies { get; set; }

            public List<global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo> OptionalDependencies
            {
                get;
                set;
            }
        }

        private readonly HttpClient client;
        private readonly global::Celeste.Everest.Modules.Dependencies.EverestDependencySource source;

        public EverestDependencyDownloader(HttpClient client,
            global::Celeste.Everest.Modules.Dependencies.EverestDependencySource source = null)
        {
            this.client = client ?? throw new ArgumentNullException(nameof(client));
            this.source = source;
        }

        public Action<Exception> DownloadFailed;

        public async Task<Dictionary<string, global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo>>
            DownloadUpdateListAsync(bool useApiMirror,
                CancellationToken cancellation = default)
        {
            if (source == null) throw new InvalidOperationException("Dependency download source is not configured");
            string uri = useApiMirror
                ? source.MirrorUpdateListUrl
                : (await client.GetStringAsync(source.UpdateListPointerUrl).ConfigureAwait(false)).Trim();
            using (var response = await client.GetAsync(uri, cancellation).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                var values = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                    .Deserialize<Dictionary<string, global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo>>(
                        await response.Content.ReadAsStringAsync()
                            .ConfigureAwait(false));
                foreach (var pair in values) pair.Value.Name = pair.Key;
                return values;
            }
        }

        public async Task<Dictionary<string, global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>>
            DownloadDependencyGraphAsync(bool useApiMirror,
                CancellationToken cancellation = default)
        {
            if (source == null) throw new InvalidOperationException("Dependency download source is not configured");
            string uri = useApiMirror
                ? source.MirrorDependencyGraphUrl
                : (await client.GetStringAsync(source.DependencyGraphPointerUrl).ConfigureAwait(false)).Trim();
            using (var response = await client.GetAsync(uri, cancellation).ConfigureAwait(false))
            {
                response.EnsureSuccessStatusCode();
                var entries = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                    .Deserialize<Dictionary<string, DependencyGraphEntry>>(
                        await response.Content.ReadAsStringAsync().ConfigureAwait(false));
                var graph =
                    new Dictionary<string, global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>(StringComparer
                        .Ordinal);
                if (entries == null) return graph;
                foreach (var pair in entries)
                {
                    var metadata = new global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata
                        { Name = pair.Key };
                    foreach (var value in pair.Value.Dependencies ??
                                          new List<global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo>())
                        try
                        {
                            metadata.Dependencies.Add(new global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata
                                { Name = value.Name, VersionString = value.Version });
                        }
                        catch (ArgumentException)
                        {
                        }

                    foreach (var value in pair.Value.OptionalDependencies ??
                                          new List<global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo>())
                        try
                        {
                            metadata.OptionalDependencies.Add(
                                new global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata
                                    { Name = value.Name, VersionString = value.Version });
                        }
                        catch (ArgumentException)
                        {
                        }

                    graph[pair.Key] = metadata;
                }

                return graph;
            }
        }

        public static void ExpandTransitiveDependencies(
            List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> missing,
            IReadOnlyDictionary<string, global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata> graph,
            Func<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata, bool> loaded)
        {
            var additions = new List<global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata>();
            do
            {
                additions.Clear();
                foreach (var request in missing)
                {
                    if (!graph.TryGetValue(request.Name, out var metadata)) continue;
                    foreach (var dependency in metadata.Dependencies)
                    {
                        if (loaded(dependency) || missing.Any(value => value.Name == dependency.Name) ||
                            additions.Any(value => value.Name == dependency.Name)) continue;
                        additions.Add(dependency);
                    }
                }

                missing.AddRange(additions);
            } while (additions.Count > 0);
        }

        public static IEnumerable<string> MirrorUrls(string url, string preferences)
        {
            uint id = 0;
            if ((url.StartsWith("http://gamebanana.com/dl/") &&
                 !uint.TryParse(url.Substring("http://gamebanana.com/dl/".Length), out id)) ||
                (url.StartsWith("https://gamebanana.com/dl/") &&
                 !uint.TryParse(url.Substring("https://gamebanana.com/dl/".Length), out id)) ||
                (url.StartsWith("http://gamebanana.com/mmdl/") &&
                 !uint.TryParse(url.Substring("http://gamebanana.com/mmdl/".Length), out id)) ||
                (url.StartsWith("https://gamebanana.com/mmdl/") &&
                 !uint.TryParse(url.Substring("https://gamebanana.com/mmdl/".Length), out id))) id = 0;
            if (id == 0)
            {
                yield return url;
                yield break;
            }

            foreach (string preference in preferences.Split(','))
            {
                switch (preference)
                {
                    case "gb": yield return url; break;
                    case "jade": yield return "https://celestemodupdater.0x0a.de/banana-mirror/" + id + ".zip"; break;
                    case "wegfan": yield return "https://celeste.weg.fan/api/v2/download/gamebanana-files/" + id; break;
                    case "otobot": yield return "https://banana-mirror-mods.celestemods.com/" + id + ".zip"; break;
                }
            }
        }

        public static void VerifyChecksum(global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo update,
            string path)
        {
            string actual;
            using (var stream = File.OpenRead(path))
            using (var hash = XXHash64.Create())
                actual = BitConverter.ToString(hash.ComputeHash(stream)).Replace("-", "").ToLowerInvariant();
            string expected = update.xxHash[0];
            if (actual != expected) throw new IOException("Checksum error: expected " + expected + ", got " + actual);
        }

        // This port can activate content-only archives from the public updater.
        // A manifest DLL needs a separately ported code module and must not be
        // installed on the premise that a cold restart will make it loadable.
        public static void ValidateContentOnlyArchive(string path,
            global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata required,
            global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata core)
        {
            if (required == null || core == null)
                throw new ArgumentNullException("Dependency validation needs required and core metadata");
            var package =
                new global::Celeste.Everest.Content.Packages.EverestManifestCatalog()
                    .RegisterContentPackage(path, core);
            if (!package.Metadata.Any(module => module.Name == required.Name &&
                                                global::Celeste.Everest.Modules.Dependencies.EverestDependencyVersion
                                                    .Satisfies(required.Version, module.Version)))
                throw new InvalidDataException("Downloaded archive does not provide " + required.Name + " " +
                                               required.Version);
            var code = package.Metadata.FirstOrDefault(module => !string.IsNullOrEmpty(module.DLL));
            if (code != null)
                throw new NotSupportedException("Downloaded archive contains an unported Everest DLL: " + code.Name +
                                                ". Port this module before enabling the dependency.");
        }

        public async Task<string> DownloadPackageAsync(
            global::Celeste.Everest.Modules.Dependencies.EverestModUpdateInfo update, string preferences,
            string modsDirectory, string temporaryDirectory,
            global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata installed = null,
            IProgress<global::Celeste.Everest.Modules.Dependencies.EverestDownloadProgress> progress = null,
            CancellationToken cancellation = default,
            Action<string> validateArchive = null)
        {
            string root =
                Path.GetFullPath(modsDirectory).TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) +
                Path.DirectorySeparatorChar;
            string target = Path.GetFullPath(installed?.PathArchive ?? Path.Combine(root, update.Name + ".zip"));
            if (!target.StartsWith(root, StringComparison.OrdinalIgnoreCase))
                throw new IOException("Mod archive is outside the active module profile");
            Directory.CreateDirectory(root);
            Directory.CreateDirectory(temporaryDirectory);
            string temporary = Path.Combine(temporaryDirectory,
                "dependency-download-" + Guid.NewGuid().ToString("N") + ".zip");
            try
            {
                bool downloaded = false;
                Exception lastError = null;
                foreach (string uri in MirrorUrls(update.URL, preferences))
                {
                    try
                    {
                        using (var response = await client
                                   .GetAsync(uri, HttpCompletionOption.ResponseHeadersRead, cancellation)
                                   .ConfigureAwait(false))
                        {
                            response.EnsureSuccessStatusCode();
                            long length = response.Content.Headers.ContentLength ?? 0;
                            using (var input = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                            using (var output = File.Create(temporary))
                            {
                                byte[] buffer = new byte[81920];
                                long position = 0;
                                var watch = System.Diagnostics.Stopwatch.StartNew();
                                int read;
                                while ((read = await input.ReadAsync(buffer, 0, buffer.Length, cancellation)
                                           .ConfigureAwait(false)) != 0)
                                {
                                    await output.WriteAsync(buffer, 0, read, cancellation).ConfigureAwait(false);
                                    position += read;
                                    progress?.Report(
                                        new global::Celeste.Everest.Modules.Dependencies.EverestDownloadProgress(
                                            position, length,
                                            (int)(position / 1024.0 / Math.Max(watch.Elapsed.TotalSeconds, .001))));
                                }
                            }
                        }

                        VerifyChecksum(update, temporary);
                        downloaded = true;
                        break;
                    }
                    catch (OperationCanceledException)
                    {
                        throw;
                    }
                    catch (Exception error)
                    {
                        lastError = error;
                        DownloadFailed?.Invoke(error);
                    }
                }

                if (!downloaded) throw lastError ?? new IOException("No configured download mirror is available");
                validateArchive?.Invoke(temporary);
                if (File.Exists(target)) File.Delete(target);
                File.Move(temporary, target);
                return target;
            }
            finally
            {
                if (File.Exists(temporary)) File.Delete(temporary);
            }
        }
    }
}

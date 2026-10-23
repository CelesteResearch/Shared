using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Content.Packages
{
    public sealed class EverestContentPackage
    {
        public string Path { get; }
        public bool IsArchive { get; }
        public EverestModuleMetadata[] Metadata { get; }
        public IReadOnlyList<string> Maps { get; }

        public IReadOnlyList<string> Assets { get; }

        // A captured atlas view must not keep serving bytes after its source is removed.
        public bool IsRegistered { get; internal set; }
        public long RegistrationId { get; internal set; }
        private readonly Dictionary<string, string> mapPaths = new(StringComparer.Ordinal);
        private readonly Dictionary<string, string> assetPaths = new(StringComparer.Ordinal);
        public string SourceName => Metadata[0].Name;

        internal EverestContentPackage(string path, bool archive,
            EverestModuleMetadata[] metadata, string[] assets)
        {
            Path = path;
            IsArchive = archive;
            Metadata = metadata;
            foreach (var entry in assets)
            {
                var normalized = entry.Replace('\\', '/');
                assetPaths[normalized] = entry;
                if (normalized.StartsWith("Maps/", StringComparison.Ordinal) &&
                    normalized.EndsWith(".bin", StringComparison.Ordinal))
                    mapPaths[normalized.Substring(5, normalized.Length - 9)] = entry;
            }

            Maps = (string[])[.. mapPaths.Keys];
            Assets = (string[])[.. assetPaths.Keys];
        }

        public bool ContainsAsset(string path)
        {
            return path != null && assetPaths.ContainsKey(path.Replace('\\', '/'));
        }

        public byte[] ReadAsset(string path)
        {
            if (path == null || !assetPaths.TryGetValue(path.Replace('\\', '/'), out var entry))
                throw new FileNotFoundException("Asset is not owned by this content source: " + path);
            if (!IsArchive)
                return File.ReadAllBytes(System.IO.Path.Combine(Path,
                    entry.Replace('/', System.IO.Path.DirectorySeparatorChar)));
            using (var zip = ZipFile.OpenRead(Path))
            using (var stream = zip.GetEntry(entry).Open())
            using (var bytes = new MemoryStream())
            {
                stream.CopyTo(bytes);
                return bytes.ToArray();
            }
        }

        public byte[] ReadMap(string sid)
        {
            if (!Maps.Contains(sid)) throw new FileNotFoundException("Map is not owned by this content source: " + sid);
            if (!IsArchive)
                return File.ReadAllBytes(System.IO.Path.Combine(Path,
                    mapPaths[sid].Replace('/', System.IO.Path.DirectorySeparatorChar)));
            using (var zip = ZipFile.OpenRead(Path))
            using (var stream = zip.GetEntry(mapPaths[sid]).Open())
            using (var bytes = new MemoryStream())
            {
                stream.CopyTo(bytes);
                return bytes.ToArray();
            }
        }

        public string ReadMapMetaYaml(string sid)
        {
            if (!mapPaths.TryGetValue(sid, out var mapPath)) return null;
            var stem = mapPath.Substring(0, mapPath.Length - 4);
            if (!IsArchive)
            {
                var path = System.IO.Path.Combine(Path,
                    (stem + ".meta.yaml").Replace('/', System.IO.Path.DirectorySeparatorChar));
                return File.Exists(path) ? File.ReadAllText(path) : null;
            }

            using (var zip = ZipFile.OpenRead(Path))
            {
                var entry = zip.GetEntry(stem + ".meta.yaml");
                if (entry == null) return null;
                using (var reader = new StreamReader(entry.Open()))
                {
                    return reader.ReadToEnd();
                }
            }
        }
    }
}

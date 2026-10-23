using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Celeste.Everest.Content.Packages;
using Celeste.Graphics.Content.Atlas;
using YamlDotNet.Serialization;

namespace Celeste.Everest
{
    // A profile-scoped, engine-independent view of Everest's loose atlas textures.
    // The page names are private to this view; the host supplies their PNG bytes to
    // its own texture uploader. No Unity object enters the content package.
    public sealed class EverestAtlasContent
    {
        private sealed class Source
        {
            public EverestContentPackage Package;
            public string Path;
        }

        private sealed class TextureMeta
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private readonly Dictionary<string, Source> pages = new(StringComparer.Ordinal);
        private readonly IReadOnlyList<EverestContentPackage> packages;
        private readonly EverestManifestCatalog catalog;

        private readonly Dictionary<AtlasData,
            Dictionary<string, AtlasEntry>> originals = new();

        private readonly Dictionary<AtlasData, HashSet<string>> appliedPages =
            new();

        public EverestAtlasContent(IEnumerable<EverestContentPackage> packages)
        {
            this.packages = packages?.ToArray() ?? throw new ArgumentNullException(nameof(packages));
        }

        public EverestAtlasContent(EverestManifestCatalog catalog)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public bool IsModPage(string page)
        {
            return page != null && pages.TryGetValue(page, out var source) && source.Package.IsRegistered;
        }

        public byte[] ReadPng(string page)
        {
            if (!IsModPage(page)) throw new FileNotFoundException("No active Everest atlas page: " + page);
            var source = pages[page];
            return source.Package.ReadAsset(source.Path);
        }

        public void Apply(AtlasData atlas, string atlasName)
        {
            if (atlas == null) throw new ArgumentNullException(nameof(atlas));
            if (string.IsNullOrEmpty(atlasName))
                throw new ArgumentException("An atlas name is required", nameof(atlasName));
            // Reapplying to an existing atlas must first undo the previous mod layer.
            // Keeping the original entry object also preserves vanilla frame metadata.
            if (originals.TryGetValue(atlas, out var previous))
                foreach (var item in previous)
                    if (item.Value == null) atlas.Entries.Remove(item.Key);
                    else atlas.Entries[item.Key] = item.Value;

            if (appliedPages.TryGetValue(atlas, out var previousPages))
                foreach (var page in previousPages)
                    pages.Remove(page);
            var currentPages = new HashSet<string>(StringComparer.Ordinal);
            appliedPages[atlas] = currentPages;
            var original =
                new Dictionary<string, AtlasEntry>(StringComparer
                    .OrdinalIgnoreCase);
            originals[atlas] = original;
            var prefix = "Graphics/Atlases/" + atlasName + "/";
            var activePackages = catalog?.Packages ?? packages;
            for (var sourceIndex = 0; sourceIndex < activePackages.Count; sourceIndex++)
            {
                var package = activePackages[sourceIndex];
                if (!package.IsRegistered) continue;
                foreach (var path in package.Assets)
                {
                    if (!path.StartsWith(prefix, StringComparison.Ordinal) ||
                        !path.EndsWith(".png", StringComparison.Ordinal)) continue;
                    var key = path.Substring(prefix.Length, path.Length - prefix.Length - 4);
                    if (key.Length == 0) continue;
                    var png = package.ReadAsset(path);
                    PngSize(png, out var width, out var height);
                    // A reloaded archive at the same path must never reuse a GPU
                    // page key while an older scene still owns its texture lease.
                    var page = "__everest/" + package.RegistrationId + "/" + path;
                    pages[page] = new() { Package = package, Path = path };
                    currentPages.Add(page);
                    TextureMeta meta = null;
                    var metaPath = path + ".meta.yaml";
                    if (package.ContainsAsset(metaPath))
                        meta = new DeserializerBuilder().IgnoreUnmatchedProperties().Build()
                            .Deserialize<TextureMeta>(Encoding.UTF8.GetString(package.ReadAsset(metaPath)));
                    var hadOld = atlas.Entries.TryGetValue(key,
                        out var old);
                    if (!original.ContainsKey(key)) original[key] = hadOld ? old : null;
                    var entry = new AtlasEntry
                        { Name = key, Page = page, Width = width, Height = height };
                    if (meta != null)
                    {
                        entry.OffsetX = meta.X;
                        entry.OffsetY = meta.Y;
                        entry.FrameWidth = meta.Width == 0 ? width : meta.Width;
                        entry.FrameHeight = meta.Height == 0 ? height : meta.Height;
                    }
                    else if (hadOld && old.Width == width && old.Height == height)
                    {
                        entry.OffsetX = old.OffsetX;
                        entry.OffsetY = old.OffsetY;
                        entry.FrameWidth = old.FrameWidth;
                        entry.FrameHeight = old.FrameHeight;
                    }
                    else
                    {
                        entry.FrameWidth = width;
                        entry.FrameHeight = height;
                    }

                    atlas.Entries[key] = entry;
                }
            }
        }

        private static void PngSize(byte[] data, out int width, out int height)
        {
            if (data.Length < 24 || data[0] != 137 || data[1] != 80 || data[2] != 78 || data[3] != 71
                || data[4] != 13 || data[5] != 10 || data[6] != 26 || data[7] != 10
                || data[12] != 73 || data[13] != 72 || data[14] != 68 || data[15] != 82)
                throw new InvalidDataException("Invalid PNG atlas asset");
            width = (int)(((uint)data[16] << 24) | ((uint)data[17] << 16) | ((uint)data[18] << 8) | data[19]);
            height = (int)(((uint)data[20] << 24) | ((uint)data[21] << 16) | ((uint)data[22] << 8) | data[23]);
            if (width < 1 || height < 1 || (long)width * height > 67108864)
                throw new InvalidDataException("Invalid PNG atlas dimensions");
        }
    }
}

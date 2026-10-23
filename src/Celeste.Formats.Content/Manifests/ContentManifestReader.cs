using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Celeste.Core.IO.Content.Manifests;

namespace Celeste.Formats.Content.Manifests
{
    public static class ContentManifestReader
    {
        // Reads the SchemaVersion 1 output of Tools/Content/Build-ContentManifest.ps1.
        // Atlas entries remain in their original metadata files; this catalog describes physical payloads.
        public static ContentManifest Read(Stream stream)
        {
            using var document = JsonDocument.Parse(stream);
            var root = document.RootElement;
            if (root.GetProperty("SchemaVersion").GetInt32() != 1)
                throw new InvalidDataException("Unsupported content manifest schema.");
            var files = new List<ContentFileInfo>();
            var resourcePaths = new HashSet<string>(StringComparer.Ordinal);
            foreach (var file in root.GetProperty("Files").EnumerateArray())
            {
                ContentTextureInfo texture = null;
                var textureElement = file.GetProperty("Texture");
                if (textureElement.ValueKind != JsonValueKind.Null)
                {
                    texture = new(textureElement.GetProperty("Width").GetInt32(),
                        textureElement.GetProperty("Height").GetInt32(),
                        textureElement.GetProperty("AlphaFlag").GetByte());
                    if (texture.HasAlpha != textureElement.GetProperty("HasAlpha").GetBoolean())
                        throw new InvalidDataException("Inconsistent texture alpha metadata.");
                }

                var descriptor = new ContentFileInfo(file.GetProperty("Path").GetString(),
                    file.GetProperty("Size").GetInt64(),
                    file.GetProperty("Sha256").GetString(), texture,
                    file.TryGetProperty("ResourcePath", out var resourcePath)
                        ? resourcePath.GetString()
                        : null);
                if (!resourcePaths.Add(descriptor.ResourcePath))
                    throw new InvalidDataException($"Duplicate physical resource '{descriptor.ResourcePath}'.");
                files.Add(descriptor);
            }

            var groups = new List<ContentGroupInfo>();
            foreach (var group in root.GetProperty("Groups").EnumerateArray())
                groups.Add(new(group.GetProperty("Id").GetString(),
                    ReadStrings(group.GetProperty("Requires")), ReadStrings(group.GetProperty("Files")),
                    group.GetProperty("Size").GetInt64()));
            var atlases = new List<ContentAtlasInfo>();
            foreach (var atlas in root.GetProperty("Atlases").EnumerateArray())
                atlases.Add(new(atlas.GetProperty("Name").GetString(),
                    atlas.GetProperty("Metadata").GetString(), atlas.GetProperty("Format").GetString(),
                    atlas.GetProperty("Version").GetInt32(), atlas.GetProperty("Label").GetString(),
                    atlas.GetProperty("HeaderValue").GetInt32(), atlas.GetProperty("Entries").GetInt32(),
                    atlas.GetProperty("Links").GetInt32(), ReadStrings(atlas.GetProperty("Pages"))));
            return new(files, groups, root.GetProperty("GroupPurpose").GetString(),
                atlases, ReadStrings(root.GetProperty("Unassigned")));
        }

        private static IEnumerable<string> ReadStrings(JsonElement element)
        {
            foreach (var value in element.EnumerateArray())
                yield return value.GetString();
        }
    }
}

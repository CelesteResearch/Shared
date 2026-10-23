using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Core.IO.Content
{
    // Configuration describes the importing host; the view exposes logical game resources.
    public sealed class ProjectedContentSource : IContentSource
    {
        private readonly IContentSource source;
        private readonly string root;
        private readonly List<KeyValuePair<string, string>> mappings;
        private readonly HashSet<string> excludedExtensions;

        public string TitleLocation => source.TitleLocation;

        public ProjectedContentSource(IContentSource contentSource,
            IReadOnlyDictionary<string, string> extensionMappings, IEnumerable<string> nonResourceExtensions)
        {
            source = contentSource ?? throw new ArgumentNullException(nameof(contentSource));
            mappings = new List<KeyValuePair<string, string>>(extensionMappings ??
                                                              throw new ArgumentNullException(
                                                                  nameof(extensionMappings)));
            excludedExtensions = new HashSet<string>(nonResourceExtensions ??
                                                     throw new ArgumentNullException(nameof(nonResourceExtensions)),
                StringComparer.OrdinalIgnoreCase);
            root = Path.GetFullPath(source.TitleLocation)
                       .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                   + Path.DirectorySeparatorChar;
        }

        public Stream OpenTitleStream(string name) => source.OpenTitleStream(ResolveContentPath(name));
        public bool FileExists(string name) => source.FileExists(ResolveContentPath(name));

        public string[] GetFiles(string directory, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            string[] files = source.GetFiles(directory, searchOption);
            var resources = new List<string>(files.Length);
            foreach (string file in files)
            {
                if (!IsProjectedPath(file))
                {
                    resources.Add(file);
                    continue;
                }

                if (!excludedExtensions.Contains(Path.GetExtension(file)))
                    resources.Add(MapExtension(file, false));
            }

            return resources.ToArray();
        }

        private bool IsProjectedPath(string path)
            => ContentFilePath.Resolve(TitleLocation, path).StartsWith(root,
                Path.DirectorySeparatorChar == '\\' ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);

        private string ResolveContentPath(string name)
        {
            string path = ContentFilePath.Resolve(TitleLocation, name);
            return IsProjectedPath(path) ? MapExtension(path, true) : path;
        }

        private string MapExtension(string path, bool toPhysical)
        {
            string matched = null;
            string replacement = null;
            foreach (KeyValuePair<string, string> mapping in mappings)
            {
                string suffix = toPhysical ? mapping.Key : mapping.Value;
                if ((matched == null || suffix.Length > matched.Length)
                    && path.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    matched = suffix;
                    replacement = toPhysical ? mapping.Value : mapping.Key;
                }
            }

            return matched == null ? path : path.Substring(0, path.Length - matched.Length) + replacement;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Core.IO.Content
{
    // Configuration describes the importing host; the view exposes logical game resources.
    public sealed class ProjectedContentSource : IContentSource
    {
        private readonly IContentSource _source;
        private readonly string _root;
        private readonly List<KeyValuePair<string, string>> _mappings;
        private readonly HashSet<string> _excludedExtensions;

        public string TitleLocation => _source.TitleLocation;

        public ProjectedContentSource(IContentSource contentSource,
            IReadOnlyDictionary<string, string> extensionMappings, IEnumerable<string> nonResourceExtensions)
        {
            _source = contentSource ?? throw new ArgumentNullException(nameof(contentSource));
            _mappings =
            [
                .. extensionMappings ??
                   throw new ArgumentNullException(
                       nameof(extensionMappings)),
            ];
            _excludedExtensions = new(nonResourceExtensions ??
                                      throw new ArgumentNullException(nameof(nonResourceExtensions)),
                StringComparer.OrdinalIgnoreCase);
            _root = Path.GetFullPath(_source.TitleLocation)
                        .TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                    + Path.DirectorySeparatorChar;
        }

        public Stream OpenTitleStream(string name)
        {
            return _source.OpenTitleStream(ResolveContentPath(name));
        }

        public bool FileExists(string name)
        {
            return _source.FileExists(ResolveContentPath(name));
        }

        public string[] GetFiles(string directory, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            var files = _source.GetFiles(directory, searchOption);
            var resources = new List<string>(files.Length);
            foreach (var file in files)
            {
                if (!IsProjectedPath(file))
                {
                    resources.Add(file);
                    continue;
                }

                if (!_excludedExtensions.Contains(Path.GetExtension(file)))
                    resources.Add(MapExtension(file, false));
            }

            return [.. resources];
        }

        private bool IsProjectedPath(string path)
        {
            return ContentFilePath.Resolve(TitleLocation, path).StartsWith(_root,
                Path.DirectorySeparatorChar == '\\' ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }

        private string ResolveContentPath(string name)
        {
            var path = ContentFilePath.Resolve(TitleLocation, name);
            return IsProjectedPath(path) ? MapExtension(path, true) : path;
        }

        private string MapExtension(string path, bool toPhysical)
        {
            string matched = null;
            string replacement = null;
            foreach (var mapping in _mappings)
            {
                var suffix = toPhysical ? mapping.Key : mapping.Value;
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

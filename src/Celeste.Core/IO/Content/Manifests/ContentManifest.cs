using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentManifest
    {
        private readonly Dictionary<string, ContentFileInfo> _fileIndex = new(StringComparer.Ordinal);
        private readonly Dictionary<string, ContentGroupInfo> _groupIndex = new(StringComparer.Ordinal);

        public IReadOnlyList<ContentFileInfo> Files { get; }
        public IReadOnlyList<ContentGroupInfo> Groups { get; }
        public int SchemaVersion => 1;
        public string GroupPurpose { get; }
        public IReadOnlyList<ContentAtlasInfo> Atlases { get; }
        public IReadOnlyList<string> Unassigned { get; }

        public ContentManifest(IEnumerable<ContentFileInfo> files, IEnumerable<ContentGroupInfo> groups,
            string groupPurpose = "", IEnumerable<ContentAtlasInfo> atlases = null,
            IEnumerable<string> unassigned = null)
        {
            var fileList = new List<ContentFileInfo>(files ?? throw new ArgumentNullException(nameof(files)));
            var groupList = new List<ContentGroupInfo>(groups ?? throw new ArgumentNullException(nameof(groups)));
            foreach (var file in fileList)
                _fileIndex.Add(file.Path, file);
            foreach (var group in groupList)
                _groupIndex.Add(group.Id, group);
            foreach (var group in groupList)
            {
                foreach (var path in group.Files)
                    if (!_fileIndex.ContainsKey(path))
                        throw new InvalidDataException($"Group '{group.Id}' references unknown file '{path}'.");
                ResolveGroup(group.Id, new(StringComparer.Ordinal),
                    new(StringComparer.Ordinal), new(StringComparer.Ordinal));
            }

            var atlasList = new List<ContentAtlasInfo>(atlases ?? (ContentAtlasInfo[])[]);
            foreach (var atlas in atlasList)
            {
                ValidateFileReference(atlas.Metadata);
                foreach (var page in atlas.Pages)
                    ValidateFileReference(page);
            }

            var unassignedList = new List<string>(unassigned ?? (string[])[]);
            foreach (var path in unassignedList)
                ValidateFileReference(path);

            fileList.Sort((left, right) => StringComparer.Ordinal.Compare(left.Path, right.Path));
            Files = fileList.AsReadOnly();
            Groups = groupList.AsReadOnly();
            GroupPurpose = groupPurpose ?? throw new ArgumentNullException(nameof(groupPurpose));
            Atlases = atlasList.AsReadOnly();
            Unassigned = unassignedList.AsReadOnly();
        }

        public bool TryGetFile(string logicalPath, out ContentFileInfo file)
        {
            return _fileIndex.TryGetValue(logicalPath, out file);
        }

        public bool TryGetTextureDimensions(string logicalPath, out int width, out int height)
        {
            if (_fileIndex.TryGetValue(logicalPath, out var file) && file.Texture != null)
            {
                width = file.Texture.Width;
                height = file.Texture.Height;
                return true;
            }

            width = height = 0;
            return false;
        }

        public IReadOnlyList<string> GetGroupFiles(string groupId)
        {
            var files = new HashSet<string>(StringComparer.Ordinal);
            ResolveGroup(groupId, new(StringComparer.Ordinal),
                new(StringComparer.Ordinal), files);
            var result = new List<string>(files);
            result.Sort(StringComparer.Ordinal);
            return result.AsReadOnly();
        }

        private void ValidateFileReference(string path)
        {
            if (!_fileIndex.ContainsKey(path))
                throw new InvalidDataException($"Unknown content file '{path}'.");
        }

        private void ResolveGroup(string id, HashSet<string> visited, HashSet<string> visiting, HashSet<string> files)
        {
            if (visited.Contains(id))
                return;
            if (!_groupIndex.TryGetValue(id, out var group))
                throw new InvalidDataException($"Unknown content group '{id}'.");
            if (!visiting.Add(id))
                throw new InvalidDataException($"Cyclic content group dependency at '{id}'.");
            foreach (var dependency in group.Requires)
                ResolveGroup(dependency, visited, visiting, files);
            foreach (var file in group.Files)
                files.Add(file);
            visiting.Remove(id);
            visited.Add(id);
        }
    }
}

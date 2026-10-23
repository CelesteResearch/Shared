using System;
using System.Collections.Generic;
using System.IO;

namespace Celeste.Core.IO.Content.Manifests
{
    public sealed class ContentManifest
    {
        private readonly Dictionary<string, ContentFileInfo> fileIndex = new(StringComparer.Ordinal);
        private readonly Dictionary<string, ContentGroupInfo> groupIndex = new(StringComparer.Ordinal);

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
            foreach (ContentFileInfo file in fileList)
                fileIndex.Add(file.Path, file);
            foreach (ContentGroupInfo group in groupList)
                groupIndex.Add(group.Id, group);
            foreach (ContentGroupInfo group in groupList)
            {
                foreach (string path in group.Files)
                    if (!fileIndex.ContainsKey(path))
                        throw new InvalidDataException($"Group '{group.Id}' references unknown file '{path}'.");
                ResolveGroup(group.Id, new HashSet<string>(StringComparer.Ordinal),
                    new HashSet<string>(StringComparer.Ordinal), new HashSet<string>(StringComparer.Ordinal));
            }

            var atlasList = new List<ContentAtlasInfo>(atlases ?? Array.Empty<ContentAtlasInfo>());
            foreach (ContentAtlasInfo atlas in atlasList)
            {
                ValidateFileReference(atlas.Metadata);
                foreach (string page in atlas.Pages)
                    ValidateFileReference(page);
            }

            var unassignedList = new List<string>(unassigned ?? Array.Empty<string>());
            foreach (string path in unassignedList)
                ValidateFileReference(path);

            fileList.Sort((left, right) => StringComparer.Ordinal.Compare(left.Path, right.Path));
            Files = fileList.AsReadOnly();
            Groups = groupList.AsReadOnly();
            GroupPurpose = groupPurpose ?? throw new ArgumentNullException(nameof(groupPurpose));
            Atlases = atlasList.AsReadOnly();
            Unassigned = unassignedList.AsReadOnly();
        }

        public bool TryGetFile(string logicalPath, out ContentFileInfo file) =>
            fileIndex.TryGetValue(logicalPath, out file);

        public bool TryGetTextureDimensions(string logicalPath, out int width, out int height)
        {
            if (fileIndex.TryGetValue(logicalPath, out ContentFileInfo file) && file.Texture != null)
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
            ResolveGroup(groupId, new HashSet<string>(StringComparer.Ordinal),
                new HashSet<string>(StringComparer.Ordinal), files);
            var result = new List<string>(files);
            result.Sort(StringComparer.Ordinal);
            return result.AsReadOnly();
        }

        private void ValidateFileReference(string path)
        {
            if (!fileIndex.ContainsKey(path))
                throw new InvalidDataException($"Unknown content file '{path}'.");
        }

        private void ResolveGroup(string id, HashSet<string> visited, HashSet<string> visiting, HashSet<string> files)
        {
            if (visited.Contains(id))
                return;
            if (!groupIndex.TryGetValue(id, out ContentGroupInfo group))
                throw new InvalidDataException($"Unknown content group '{id}'.");
            if (!visiting.Add(id))
                throw new InvalidDataException($"Cyclic content group dependency at '{id}'.");
            foreach (string dependency in group.Requires)
                ResolveGroup(dependency, visited, visiting, files);
            foreach (string file in group.Files)
                files.Add(file);
            visiting.Remove(id);
            visited.Add(id);
        }
    }
}

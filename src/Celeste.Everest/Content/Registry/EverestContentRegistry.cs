using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Content.Types;
using System;
using System.Collections.Generic;
using System.IO;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Registry
{
    public sealed partial class EverestContentRegistry
    {
        public string PathContentOrig { get; internal set; }
        public string PathDUMP { get; internal set; }
        public bool DumpOnLoad;
        internal bool DumpAllRequested = false;
        public readonly List<EverestContentSource> Mods = new();
        public readonly Dictionary<string, EverestContentAsset> Map = new();
        private readonly IEverestContentDiagnostics Diagnostics;
        public event EverestContentTypeGuesser OnGuessType;

        internal readonly HashSet<string> BlacklistRootFiles = new(StringComparer.OrdinalIgnoreCase)
            { "changelog", "credits", "documentation", "FAQ", "LICENSE", "README" };

        internal readonly HashSet<string> BlacklistExtensions = new(StringComparer.OrdinalIgnoreCase)
            { ".cs", ".csproj", ".md", ".pdb", ".sln", ".yaml-backup", ".gitignore" };

        internal readonly HashSet<string> BlacklistRootFolders = new(StringComparer.OrdinalIgnoreCase)
            { "Ahorn", "Loenn" };

        internal readonly HashSet<string> BlacklistFolders = new(StringComparer.OrdinalIgnoreCase)
            { "lib-stripped", "__MACOSX", "obj" };


        public bool TryAdd(string path, EverestContentAsset metadata)
        {
            path = path.Replace('\\', '/');
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
            if (fileNameWithoutExtension.StartsWith(".") || BlacklistExtensions.Contains(Path.GetExtension(path)))
            {
                return false;
            }

            string[] array = path.Split(EverestContentPath.DirectorySeparators, StringSplitOptions.RemoveEmptyEntries);
            if (array.Length == 1 && BlacklistRootFiles.Contains(fileNameWithoutExtension))
            {
                return false;
            }

            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i].StartsWith(".") || BlacklistFolders.Contains(array[i]) ||
                    (i == 0 && BlacklistRootFolders.Contains(array[0])))
                {
                    return false;
                }
            }

            if (metadata != null &&
                metadata.Source?.Ignore?.IsIgnored(path, metadata.Type == typeof(AssetTypeDirectory)) ==
                true)
            {
                return false;
            }

            if (metadata != null)
            {
                if (metadata.Type == null)
                {
                    path = GuessType(path, out metadata.Type, out metadata.Format);
                }

                metadata.PathVirtual = path;
            }

            string text = metadata?.Source?.Name;
            if (metadata != null && metadata.Type == typeof(AssetTypeDirectory) && !(metadata is EverestContentBranch))
            {
                return false;
            }

            lock (Map)
            {
                Map.TryGetValue(path, out var value);

                if (metadata == null && value != null && value.Type == typeof(AssetTypeDirectory))
                {
                    return false;
                }

                if (metadata == null)
                {
                    Map.Remove(path);
                }
                else
                {
                    if (Map.TryGetValue(path, out var value2) && value2 != null && value2.Source != metadata.Source &&
                        !value2.Type.IsSubclassOf(typeof(AssetTypeNonConflict)))
                    {
                        Diagnostics.Warning("content", "CONFLICT for asset path " + path + " (" +
                                                       (value2?.Source?.Name ?? "???") + " vs " +
                                                       (metadata?.Source?.Name ?? "???") + ")");
                    }

                    Map[path] = metadata;
                    if (text != null)
                    {
                        Map[text + ":/" + path] = metadata;
                    }
                }

                if (path != "")
                {
                    string text2 = Path.GetDirectoryName(path).Replace('\\', '/');
                    if (!Map.TryGetValue(text2, out var value3))
                    {
                        value3 = new EverestContentBranch(this)
                        {
                            PathVirtual = text2,
                            Type = typeof(AssetTypeDirectory)
                        };
                        Add(text2, value3);
                    }

                    lock (value3.Children)
                    {
                        int num = value3.Children.IndexOf(value);
                        if (num != -1)
                        {
                            if (metadata == null)
                            {
                                value3.Children.RemoveAt(num);
                            }
                            else
                            {
                                value3.Children[num] = metadata;
                            }
                        }
                        else
                        {
                            value3.Children.Add(metadata);
                        }
                    }
                }
            }

            return true;
        }

        public void Add(string path, EverestContentAsset asset) => TryAdd(path, asset);
    }
}

using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Directories;
using Celeste.Everest.Tasks.Queuing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Celeste.Everest.Content.Sources
{
    public class FileSystemContentSource : EverestContentSource
    {
        public readonly string Path;

        private readonly Dictionary<string, FileSystemContentAsset> FileSystemMap =
            new Dictionary<string, FileSystemContentAsset>();

        private FileSystemWatcher watcher;
        private readonly IEverestContentDiagnostics Diagnostics;
        private readonly QueuedTaskScheduler QueuedTasks;

        public override string DefaultName => System.IO.Path.GetFileName(Path);

        public FileSystemContentSource(EverestContentRegistry registry, IEverestContentDiagnostics diagnostics,
            QueuedTaskScheduler queuedTasks, string path) : base(registry)
        {
            Path = path;
            Diagnostics = diagnostics;
            QueuedTasks = queuedTasks;
            try
            {
                watcher = new FileSystemWatcher
                {
                    Path = path,
                    NotifyFilter = (NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastWrite),
                    IncludeSubdirectories = true
                };
                watcher.Changed += FileUpdated;
                watcher.Created += FileUpdated;
                watcher.Deleted += FileUpdated;
                watcher.Renamed += FileRenamed;
                watcher.Error += WatcherError;
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                Diagnostics.Warning("content", $"Failed watching folder: {path}");
                Diagnostics.Detailed(e);
                watcher?.Dispose();
                watcher = null;
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            watcher?.Dispose();
        }

        protected override void Crawl()
        {
            Crawl(null, Path, update: false);
        }

        protected virtual void Crawl(string dir, string root, bool update)
        {
            if (dir == null)
            {
                dir = Path;
            }

            if (root == null)
            {
                root = Path;
            }

            int num = dir.LastIndexOf(System.IO.Path.DirectorySeparatorChar);
            if (num != -1 && num >= root.Length && dir.Length > num + 1 && dir[num + 1] == '.')
            {
                return;
            }

            if (File.Exists(dir))
            {
                string path = dir.Substring(root.Length + 1);
                EverestContentAsset modAsset = new FileSystemContentAsset(this, dir);
                if (update)
                {
                    Update(path, modAsset);
                }
                else
                {
                    Add(path, modAsset);
                }

                return;
            }

            string[] files = Directory.GetFiles(dir);
            foreach (string dir2 in files)
            {
                Crawl(dir2, root, update);
            }

            files = Directory.GetDirectories(dir);
            foreach (string dir3 in files)
            {
                Crawl(dir3, root, update);
            }
        }

        protected override void Add(string path, EverestContentAsset asset)
        {
            FileSystemContentAsset fileSystemEverestContentAsset = (FileSystemContentAsset)asset;
            FileSystemMap[fileSystemEverestContentAsset.Path] = fileSystemEverestContentAsset;
            base.Add(path, asset);
        }

        protected override void Update(string path, EverestContentAsset next)
        {
            if (next is FileSystemContentAsset fileSystemEverestContentAsset)
            {
                FileSystemMap[fileSystemEverestContentAsset.Path] = fileSystemEverestContentAsset;
            }

            base.Update(path, next);
        }

        protected override void Update(EverestContentAsset prev, EverestContentAsset next)
        {
            if (prev is FileSystemContentAsset fileSystemEverestContentAsset)
            {
                FileSystemMap[fileSystemEverestContentAsset.Path] = null;
            }

            if (next is FileSystemContentAsset fileSystemEverestContentAsset2)
            {
                FileSystemMap[fileSystemEverestContentAsset2.Path] = fileSystemEverestContentAsset2;
                Stopwatch stopwatch = Stopwatch.StartNew();
                while (File.Exists(fileSystemEverestContentAsset2.Path))
                {
                    try
                    {
                        new FileStream(fileSystemEverestContentAsset2.Path, FileMode.Open, FileAccess.Read,
                            FileShare.Read | FileShare.Delete).Dispose();
                    }
                    catch (ThreadAbortException)
                    {
                        throw;
                    }
                    catch (ThreadInterruptedException)
                    {
                        throw;
                    }
                    catch
                    {
                        if (stopwatch.Elapsed.TotalSeconds >= 2.0)
                        {
                            throw;
                        }

                        continue;
                    }

                    break;
                }

                stopwatch.Stop();
            }

            base.Update(prev, next);
        }

        private void FileUpdated(object source, FileSystemEventArgs e)
        {
            if (e.ChangeType != WatcherChangeTypes.Changed || !Directory.Exists(e.FullPath))
            {
                Diagnostics.Verbose("content", $"File updated: {e.FullPath} - {e.ChangeType}");
                QueuedTasks.Do(e.FullPath, delegate { Update(e.FullPath, e.FullPath); });
            }
        }

        private void FileRenamed(object source, RenamedEventArgs e)
        {
            Diagnostics.Verbose("content", $"File renamed: {e.OldFullPath} - {e.FullPath}");
            QueuedTasks.Do(Tuple.Create(e.OldFullPath, e.FullPath), delegate { Update(e.OldFullPath, e.FullPath); });
        }

        private void WatcherError(object source, ErrorEventArgs e)
        {
            Diagnostics.Error("content",
                $"Error while watching \"{Path}\" for changes. Updates will no longer be detected.");
            Diagnostics.Detailed(e.GetException());
        }

        private void Update(string pathPrev, string pathNext)
        {
            FileSystemContentAsset value;
            EverestContentAsset modAsset = ((!FileSystemMap.TryGetValue(pathPrev, out value))
                ? Registry.Get<AssetTypeDirectory>(pathPrev.Substring(Path.Length + 1))
                : value);
            if (File.Exists(pathNext))
            {
                if (modAsset != null)
                {
                    Update(modAsset, new FileSystemContentAsset(this, pathNext));
                }
                else
                {
                    Update(pathNext.Substring(Path.Length + 1), new FileSystemContentAsset(this, pathNext));
                }
            }
            else if (Directory.Exists(pathNext))
            {
                Update(modAsset, null);
                Crawl(pathNext, Path, update: true);
            }
            else if (modAsset != null)
            {
                Update(modAsset, null);
            }
            else
            {
                Update(pathPrev, (EverestContentAsset)null);
            }
        }
    }
}

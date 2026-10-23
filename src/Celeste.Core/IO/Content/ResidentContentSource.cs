using System;
using System.Buffers.Binary;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using Celeste.Core.IO.Content.Manifests;

namespace Celeste.Core.IO.Content
{
    // TitleLocation is a virtual filesystem namespace, never a network URI.
    public sealed class ResidentContentSource : IContentSource, IContentMemorySource, IDisposable
    {
        private sealed class Entry(ContentFileInfo file)
        {
            public readonly ContentFileInfo File = file;
            public byte[] Bytes;
            public TaskCompletionSource<bool> Pending;
            public bool Requested;
        }

        private readonly Func<ContentFileInfo, CancellationToken, Task<byte[]>> _loadOwnedBytes;
        private readonly Func<ContentFileInfo, CancellationToken, Task<VerifiedContentBytes>> _loadVerifiedBytes;
        private readonly Dictionary<string, Entry> _entries = new(StringComparer.Ordinal);
        private readonly HashSet<string> _directories = new(StringComparer.Ordinal) { "" };
        private readonly CancellationTokenSource _lifetime = new();
        private readonly object _preparationLock = new();
        private readonly string _rootPrefix;
        private int _disposed;
        private long _requestedBytes, _readyBytes;
        private int _requestedFiles, _readyFiles;

        public string TitleLocation { get; }
        public ContentManifest Manifest { get; }

        public ContentLoadProgress ReadPreparationProgress(long receivedBytes)
        {
            return ReadPreparationProgress(receivedBytes, 0);
        }

        public ContentLoadProgress ReadPreparationProgress(long receivedBytes, long cachedBytes)
        {
            lock (_preparationLock)
            {
                ThrowIfDisposed();
                return new(_requestedBytes,
                    Math.Min(_requestedBytes, Math.Max(_readyBytes, receivedBytes)), _readyBytes,
                    _requestedFiles, _readyFiles, Math.Min(_readyBytes, Math.Max(0, cachedBytes)));
            }
        }

        // The loader transfers exclusive ownership of each returned array to this source.
        public ResidentContentSource(string titleLocation, ContentManifest contentManifest,
            Func<ContentFileInfo, CancellationToken, Task<byte[]>> loadOwnedBytes)
            : this(titleLocation, contentManifest, loadOwnedBytes, null)
        {
        }

        public static ResidentContentSource FromVerifiedLoader(string titleLocation, ContentManifest contentManifest,
            Func<ContentFileInfo, CancellationToken, Task<VerifiedContentBytes>> loadVerifiedBytes)
        {
            return new(titleLocation, contentManifest, null,
                loadVerifiedBytes ?? throw new ArgumentNullException(nameof(loadVerifiedBytes)));
        }

        private ResidentContentSource(string titleLocation, ContentManifest contentManifest,
            Func<ContentFileInfo, CancellationToken, Task<byte[]>> loadOwnedBytes,
            Func<ContentFileInfo, CancellationToken, Task<VerifiedContentBytes>> loadVerifiedBytes)
        {
            if (string.IsNullOrEmpty(titleLocation) || titleLocation.Contains("://") ||
                !Path.IsPathFullyQualified(titleLocation))
                throw new ArgumentException("An absolute virtual filesystem location is required.",
                    nameof(titleLocation));
            TitleLocation = Path.GetFullPath(titleLocation);
            _rootPrefix = TitleLocation.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar) +
                          Path.DirectorySeparatorChar;
            Manifest = contentManifest ?? throw new ArgumentNullException(nameof(contentManifest));
            if (loadOwnedBytes == null && loadVerifiedBytes == null)
                throw new ArgumentNullException(nameof(loadOwnedBytes));
            _loadOwnedBytes = loadOwnedBytes;
            _loadVerifiedBytes = loadVerifiedBytes;
            foreach (var file in Manifest.Files)
            {
                _entries.Add(file.Path, new(file));
                var directory = file.Path;
                int separator;
                while ((separator = directory.LastIndexOf('/')) >= 0)
                {
                    directory = directory.Substring(0, separator);
                    _directories.Add(directory);
                }
            }
        }

        public bool FileExists(string name)
        {
            return TryResolve(name, out var logical) && _entries.ContainsKey(logical);
        }

        public bool IsReady(string name)
        {
            return Volatile.Read(ref _disposed) == 0 && TryResolve(name, out var logical)
                                                     && _entries.TryGetValue(logical, out var entry) &&
                                                     Volatile.Read(ref entry.Bytes) != null;
        }

        public Stream OpenTitleStream(string name)
        {
            var bytes = OpenTitleBytes(name);
            return new MemoryStream(bytes, 0, bytes.Length, false, false);
        }

        public ReadOnlyMemory<byte> OpenTitleMemory(string name)
        {
            return OpenTitleBytes(name);
        }

        private byte[] OpenTitleBytes(string name)
        {
            ThrowIfDisposed();
            if (!TryResolve(name, out var logical) || !_entries.TryGetValue(logical, out var entry))
                throw new FileNotFoundException("Content is absent from the manifest.", name);
            var bytes = Volatile.Read(ref entry.Bytes);
            if (bytes == null)
                throw new IOException($"Content '{logical}' has not been prepared.");
            return bytes;
        }

        public string[] GetFiles(string directory, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            if (searchOption != SearchOption.TopDirectoryOnly && searchOption != SearchOption.AllDirectories)
                throw new ArgumentOutOfRangeException(nameof(searchOption));
            if (!TryResolve(directory, out var logical, true) || !_directories.Contains(logical))
                throw new DirectoryNotFoundException(directory);
            var prefix = logical.Length == 0 ? "" : logical + "/";
            var result = new List<string>();
            foreach (var file in Manifest.Files)
                if (file.Path.StartsWith(prefix, StringComparison.Ordinal)
                    && (searchOption == SearchOption.AllDirectories || file.Path.IndexOf('/', prefix.Length) < 0))
                    result.Add(Path.Combine(TitleLocation, file.Path.Replace('/', Path.DirectorySeparatorChar)));
            return [.. result];
        }

        public Task PrepareGroupAsync(string groupId, CancellationToken cancellationToken = default)
        {
            return PrepareFilesAsync(Manifest.GetGroupFiles(groupId), cancellationToken);
        }

        public Task PrepareFilesAsync(IEnumerable<string> names, CancellationToken cancellationToken = default)
        {
            ThrowIfDisposed();
            cancellationToken.ThrowIfCancellationRequested();
            var selected = new HashSet<Entry>();
            foreach (var name in names ?? throw new ArgumentNullException(nameof(names)))
            {
                if (!TryResolve(name, out var logical) || !_entries.TryGetValue(logical, out var entry))
                    throw new FileNotFoundException("Content is absent from the manifest.", name);
                selected.Add(entry);
            }

            var tasks = new List<Task>(selected.Count);
            foreach (var entry in selected)
                tasks.Add(EnsurePrepared(entry));
            return WaitForPreparationAsync(Task.WhenAll(tasks), cancellationToken);
        }

        private Task EnsurePrepared(Entry entry)
        {
            TaskCompletionSource<bool> pending;
            lock (_preparationLock)
            {
                ThrowIfDisposed();
                if (entry.Bytes != null)
                    return Task.CompletedTask;
                if (entry.Pending != null)
                    return entry.Pending.Task;
                if (!entry.Requested)
                {
                    entry.Requested = true;
                    _requestedBytes += entry.File.Size;
                    _requestedFiles++;
                }

                pending = new();
                entry.Pending = pending;
            }

            _ = LoadAsync(entry, pending);
            return pending.Task;
        }

        private async Task LoadAsync(Entry entry, TaskCompletionSource<bool> pending)
        {
            try
            {
                byte[] bytes;
                if (_loadVerifiedBytes != null)
                {
                    var verified = await _loadVerifiedBytes(entry.File, _lifetime.Token);
                    if (!string.Equals(verified.Sha256, entry.File.Sha256, StringComparison.OrdinalIgnoreCase))
                        throw new InvalidDataException($"Content digest mismatch for '{entry.File.Path}'.");
                    bytes = verified.Bytes;
                }
                else
                {
                    bytes = await _loadOwnedBytes(entry.File, _lifetime.Token);
                }

                if (Volatile.Read(ref _disposed) != 0)
                    return;
                if (bytes == null || bytes.LongLength != entry.File.Size)
                    throw new InvalidDataException($"Content size mismatch for '{entry.File.Path}'.");
                var texture = entry.File.Texture;
                if (texture != null && (bytes.Length < 9
                                        || BinaryPrimitives.ReadInt32LittleEndian(bytes.AsSpan(0, 4)) != texture.Width
                                        || BinaryPrimitives.ReadInt32LittleEndian(bytes.AsSpan(4, 4)) != texture.Height
                                        || bytes[8] != texture.AlphaFlag))
                    throw new InvalidDataException($"Physical texture header mismatch for '{entry.File.Path}'.");
                if (_loadVerifiedBytes == null)
                {
                    using var sha256 = SHA256.Create();
                    var digest = sha256.ComputeHash(bytes);
                    for (var index = 0; index < digest.Length; index++)
                        if (digest[index] != Convert.ToByte(entry.File.Sha256.Substring(index * 2, 2), 16))
                            throw new InvalidDataException($"Content digest mismatch for '{entry.File.Path}'.");
                }

                lock (_preparationLock)
                {
                    if (_disposed != 0)
                        return;
                    Volatile.Write(ref entry.Bytes, bytes);
                    _readyBytes += entry.File.Size;
                    _readyFiles++;
                }

                pending.TrySetResult(true);
                lock (_preparationLock)
                {
                    if (ReferenceEquals(entry.Pending, pending))
                        entry.Pending = null;
                }
            }
            catch (Exception exception)
            {
                lock (_preparationLock)
                {
                    if (ReferenceEquals(entry.Pending, pending))
                        entry.Pending = null;
                }

                pending.TrySetException(exception);
            }
        }

        private static async Task WaitForPreparationAsync(Task preparation, CancellationToken cancellationToken)
        {
            if (!cancellationToken.CanBeCanceled)
            {
                await preparation;
                return;
            }

            var canceled = new TaskCompletionSource<bool>();
            using (cancellationToken.Register(() => canceled.TrySetCanceled(cancellationToken)))
            {
                var completed = await Task.WhenAny(preparation, canceled.Task);
                if (completed != preparation)
                    _ = ObservePreparationFailureAsync(preparation);
                await completed;
            }
        }

        private static async Task ObservePreparationFailureAsync(Task preparation)
        {
            try
            {
                await preparation;
            }
            catch (Exception)
            {
                // Caller cancellation leaves the shared preparation alive; observe its eventual failure.
            }
        }

        private bool TryResolve(string name, out string logical, bool directory = false)
        {
            logical = null;
            if (name == null || name.Contains("://") || (name.Contains(":") && !Path.IsPathFullyQualified(name)))
                return false;
            var fullPath = ContentFilePath.Resolve(TitleLocation, name);
            if (directory)
                fullPath = fullPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);
            var comparison = Path.DirectorySeparatorChar == '\\'
                ? StringComparison.OrdinalIgnoreCase
                : StringComparison.Ordinal;
            if (string.Equals(fullPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar),
                    TitleLocation.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar), comparison))
            {
                logical = "";
                return true;
            }

            if (!fullPath.StartsWith(_rootPrefix, comparison))
                return false;
            logical = fullPath.Substring(_rootPrefix.Length).Replace(Path.DirectorySeparatorChar, '/')
                .Replace(Path.AltDirectorySeparatorChar, '/');
            return true;
        }

        private void ThrowIfDisposed()
        {
            if (Volatile.Read(ref _disposed) != 0)
                throw new ObjectDisposedException(nameof(ResidentContentSource));
        }

        public void Dispose()
        {
            List<TaskCompletionSource<bool>> pendingCompletions;
            lock (_preparationLock)
            {
                if (_disposed != 0)
                    return;
                Volatile.Write(ref _disposed, 1);
                pendingCompletions = [];
                foreach (var entry in _entries.Values)
                {
                    Volatile.Write(ref entry.Bytes, null);
                    if (entry.Pending != null)
                        pendingCompletions.Add(entry.Pending);
                    entry.Pending = null;
                }
            }

            foreach (var pending in pendingCompletions)
                pending.TrySetCanceled();

            try
            {
                _lifetime.Cancel();
            }
            finally
            {
                _lifetime.Dispose();
            }
        }
    }
}

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Mono.Cecil;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    /// <summary>
    ///     A module's assembly context, which handles resolving/loading mod assemblies
    /// </summary>
    public sealed class SourceEverestModuleAssemblyContext : IAssemblyResolver, IDisposable
    {
        /// <summary>
        ///     Represents all the checksum data for an assembly, either from the cache or
        ///     from one that's about to be loaded.
        /// </summary>
        public sealed record AsmChecksums(
            string GameChecksum,
            string FileChecksum,
            string SymFileChecksum = "",
            Dictionary<string, string> DepHashes = null,
            Dictionary<string, string> OptDepHashes = null)
        {
            public static readonly AsmChecksums Empty = new("", "");

            /// <summary>
            ///     Writes the data to a file, see
            ///     <see cref="M:Celeste.Mod.SourceEverestModuleAssemblyContext.AsmChecksums.ReadFromFile(System.String)" /> for a
            ///     description
            ///     of the file format.
            /// </summary>
            /// <param name="path">The path to the file to write to.</param>
            public void WriteToFile(string path)
            {
                var lines = new List<string>();
                lines.Add(GameChecksum);
                lines.Add(FileChecksum);
                lines.Add(SymFileChecksum ?? "");
                WriteAsLines(DepHashes);
                lines.Add("");
                WriteAsLines(OptDepHashes);
                File.WriteAllLines(path, lines);

                void WriteAsLines(Dictionary<string, string> dict)
                {
                    foreach (var (text3, text4) in dict) lines.Add(text3 + ":" + text4);
                }
            }

            /// <summary>
            ///     Creates an instance from a file, format is as following:
            ///     We take all the data and partition it on each new line character into strings, keeping empty strings.
            ///     Then, the first element will be the game checksum, the second one, the file checksum,
            ///     the third one, the symbol file (pdb) checksum, or empty an empty string if it doesn't exist or we are working with
            ///     archives (zips).
            ///     After the third element, each element is of the format `Name:Hash`, where Name is the meta name and
            ///     Hash is the hash for that meta, this represents a dependency. Until an empty element, which marks the
            ///     end of the dependencies list. After this element and until the end of file, the optional dependencies list follow
            ///     in the same format.
            /// </summary>
            /// <param name="path">Path to read from.</param>
            /// <returns>A populated instance.</returns>
            public static AsmChecksums ReadFromFile(string path)
            {
                var array = File.ReadAllLines(path);
                if (array.Length < 2) return Empty;

                var gameChecksum = array[0];
                var fileChecksum = array[1];
                if (array.Length <= 2) return new(gameChecksum, fileChecksum);

                var symFileChecksum = array[2];
                if (array.Length <= 3) return new(gameChecksum, fileChecksum, symFileChecksum);

                var dictionary = new Dictionary<string, string>();
                var dictionary2 = new Dictionary<string, string>();
                var dictionary3 = dictionary;
                var num = 3;
                while (num < array.Length)
                {
                    if (array[num] == "")
                    {
                        if (dictionary3 == dictionary)
                        {
                            dictionary3 = dictionary2;
                            num++;
                            continue;
                        }

                        return new(gameChecksum, fileChecksum, symFileChecksum);
                    }

                    ReadOnlySpan<char> span = array[num];
                    var num2 = span.LastIndexOf(':');
                    if (num2 == -1) return new(gameChecksum, fileChecksum, symFileChecksum);

                    var readOnlySpan = span.Slice(0, num2);
                    var num3 = num2 + 1;
                    var readOnlySpan2 = span.Slice(num3, span.Length - num3);
                    dictionary3[readOnlySpan.ToString()] = readOnlySpan2.ToString();
                    num++;
                }

                return new(gameChecksum, fileChecksum, symFileChecksum, dictionary, dictionary2);
            }

            /// <summary>
            ///     Verifies whether the current instance is a valid in respect to the one passed in:
            ///     Game, file, and symbol checksums must always match for it to be valid, but
            ///     the requirements for dependencies and optional dependencies are different.
            ///     We consider this instance valid with respect to the one passed in, if for every dependency D present
            ///     in this instance, D is also present in <paramref name="other" />, and it is associated with the same checksum.
            ///     The same reasoning goes with optional dependencies.
            /// </summary>
            /// <param name="other">The other cache to check with.</param>
            /// <returns>Whether this is compatible with <paramref name="other" /></returns>
            public bool IsValidWith(AsmChecksums other, bool skipGameChecksum)
            {
                if (other == null) return false;

                if (GameChecksum != other.GameChecksum && !skipGameChecksum) return false;

                if (FileChecksum != other.FileChecksum) return false;

                if (SymFileChecksum != other.SymFileChecksum) return false;

                if (!Check(DepHashes, other.DepHashes)) return false;

                if (!Check(OptDepHashes, other.OptDepHashes)) return false;

                return true;

                static bool Check(Dictionary<string, string> dict, Dictionary<string, string> otherDict)
                {
                    if (dict != null)
                    {
                        if (otherDict != null)
                            foreach (var (key, text3) in dict)
                            {
                                if (!otherDict.TryGetValue(key, out var value)) return false;

                                if (text3 != value) return false;
                            }
                        else if (dict.Count != 0) return false;
                    }

                    return true;
                }
            }
        }

        private readonly ISourceEngineContext SourceEngine;
        private readonly ISourceAssemblyRuntimeContext RuntimeContext;

        private SourceEverestAssemblyContextProcess Process =>
            ((ISourceEverestAssemblyProcessEnvironment)SourceEngine).AssemblyContexts;

        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)SourceEngine).Logger;
        private readonly object LOCK = new();

        public readonly EverestModuleMetadata ModuleMeta;

        internal readonly List<SourceEverestModuleAssemblyContext> DependencyContexts = [];

        internal readonly HashSet<SourceEverestModuleAssemblyContext> ActiveDependencyContexts = [];

        private readonly string _ModAsmDir;

        public IEnumerable<Assembly> Assemblies => RuntimeContext.Assemblies;

        private readonly Dictionary<string, Assembly> _LoadedAssemblies = new();

        private bool loadsSharedApiAssemblies;

        private readonly ConcurrentDictionary<Assembly, string> physicalAssemblyPaths = new();

        internal bool TryGetPhysicalAssemblyPath(Assembly assembly, out string path)
        {
            return physicalAssemblyPaths.TryGetValue(assembly, out path);
        }

        private readonly Dictionary<string, ModuleDefinition> _AssemblyModules = new();

        private readonly Dictionary<string, FileSystemWatcher> _AssemblyReloadWatchers = new();

        private readonly ConcurrentDictionary<string, Assembly> _AssemblyLoadCache = new();

        private readonly ConcurrentDictionary<string, nint> _AssemblyUnmanagedLoadCache = new();

        private readonly ConcurrentDictionary<string, AssemblyDefinition> _AssemblyResolveCache = new();

        private readonly ConcurrentDictionary<string, Assembly> _LocalLoadCache = new();

        private readonly ConcurrentDictionary<string, nint> _LocalUnmanagedLoadCache = new();

        private readonly ConcurrentDictionary<string, AssemblyDefinition> _LocalResolveCache = new();

        private LinkedListNode<SourceEverestModuleAssemblyContext> listNode;

        private bool isDisposed;

        private bool currentlyDisposing;

        /// <summary>
        ///     A list of assembly names which must not be loaded by a mod. The list will be initialized upon first access (which
        ///     is before any mods will have loaded).
        /// </summary>
        internal string[] AssemblyLoadBlackList => Process._AssemblyLoadBlackList ?? (Process._AssemblyLoadBlackList =
        [
            .. Process.Runtime.DefaultAssemblies.Select(asm => asm.GetName().Name)
                .Append("Mono.Cecil.Pdb")
                .Append("Mono.Cecil.Mdb")
                .Concat(CecilRuntimeAssemblies.Names),
        ]);

        public SourceEverestModuleAssemblyContext(ISourceEngineContext engine, EverestModuleMetadata meta)
        {
            SourceEngine = engine;
            RuntimeContext = Process.Runtime.CreateContext(meta.Name, Load, LoadUnmanagedDll);
            ModuleMeta = meta;
            RuntimeContext.BindSourceContext(this);
            if (!string.IsNullOrEmpty(meta.DLL))
            {
                if (!string.IsNullOrEmpty(meta.PathDirectory))
                    _ModAsmDir = Path.GetDirectoryName(meta.DLL);
                else
                    _ModAsmDir = Path.GetDirectoryName(meta.DLL.Replace('\\', Path.DirectorySeparatorChar)
                        .Replace('/', Path.DirectorySeparatorChar));
            }

            lock (((ISourceEverestModulesProcessEnvironment)SourceEngine).ModulesProcess.Modules)
            {
                foreach (var dependency in meta.Dependencies)
                    if (Process._ContextsByName.TryGetValue(dependency.Name, out var value))
                        DependencyContexts.Add(value);

                foreach (var optionalDependency in meta.OptionalDependencies)
                    if (Process._ContextsByName.TryGetValue(optionalDependency.Name, out var value2))
                        DependencyContexts.Add(value2);
            }

            Process._AllContextsLock.EnterWriteLock();
            try
            {
                listNode = Process._AllContexts.AddLast(this);
                Process._ContextsByName.Add(meta.Name, this);
            }
            finally
            {
                Process._AllContextsLock.ExitWriteLock();
            }
        }

        public void Dispose()
        {
            lock (LOCK)
            {
                if (isDisposed || currentlyDisposing) return;

                currentlyDisposing = true;
            }

            var failures = new List<Exception>();
            try
            {
                var unloadedAsms = new HashSet<string>();
                while (true)
                {
                    Assembly assembly;
                    lock (LOCK)
                    {
                        assembly = RuntimeContext.Assemblies.FirstOrDefault(asm =>
                            !unloadedAsms.Contains(GetAssemblyName(asm)));
                    }

                    if (assembly == null) break;
                    unloadedAsms.Add(GetAssemblyName(assembly));
                    TryCleanup(() => Process.Lifecycle.UnloadAssembly(ModuleMeta, assembly));
                }

                lock (LOCK)
                {
                    _LoadedAssemblies.Clear();
                    physicalAssemblyPaths.Clear();
                    isDisposed = true;
                    Process._AllContextsLock.EnterWriteLock();
                    try
                    {
                        Process._AllContexts.Remove(listNode);
                        Process._ContextsByName.Remove(ModuleMeta.Name);
                        listNode = null;
                    }
                    finally
                    {
                        Process._AllContextsLock.ExitWriteLock();
                    }

                    foreach (var watcher in _AssemblyReloadWatchers.Values)
                        TryCleanup(watcher.Dispose);
                    _AssemblyReloadWatchers.Clear();
                    foreach (var module in _AssemblyModules.Values)
                        TryCleanup(module.Dispose);
                    _AssemblyModules.Clear();
                    _AssemblyLoadCache.Clear();
                    _LocalLoadCache.Clear();
                    _AssemblyResolveCache.Clear();
                    _LocalResolveCache.Clear();
                }

                TryCleanup(RuntimeContext.Unload);
            }
            finally
            {
                lock (LOCK)
                {
                    currentlyDisposing = false;
                }
            }

            if (failures.Count != 0) throw new AggregateException("Module assembly context disposal failed.", failures);

            void TryCleanup(Action cleanup)
            {
                try
                {
                    cleanup();
                }
                catch (Exception failure)
                {
                    failures.Add(failure);
                }
            }

            static string GetAssemblyName(Assembly asm)
            {
                return asm.FullName ?? $"{asm}@{asm.GetHashCode()}";
            }
        }

        internal void PostBootCleanup()
        {
            _AssemblyResolveCache.Clear();
            _LocalResolveCache.Clear();
        }

        /// <summary>
        ///     Calculates the checksums used to cache the assembly in any relevant
        ///     caches (like the relinker cache), and adds them to the given list.
        ///     Note that said checksums must not necessarily be unique!
        /// </summary>
        /// <param name="checksums">The list to add the calculated checksums to</param>
        /// <param name="path">The path of the assembly inside of the mod</param>
        /// <param name="symPath">The path of the assembly's symbols inside of mod, or null</param>
        public void CalcAssemblyCacheChecksums(List<string> checksums, string path, string symPath)
        {
            if (!string.IsNullOrEmpty(ModuleMeta.PathArchive))
            {
                checksums.Add(ModuleMeta.Hash.ToHexadecimalString());
                return;
            }

            if (!string.IsNullOrEmpty(ModuleMeta.PathDirectory))
            {
                checksums.Add(EverestChecksums.GetChecksum(path).ToHexadecimalString());
                if (symPath != null) checksums.Add(EverestChecksums.GetChecksum(symPath).ToHexadecimalString());

                return;
            }

            throw new InvalidOperationException("Unreachable module storage state");
        }

        private string CalcChecksumForFile(string path)
        {
            if (!string.IsNullOrEmpty(ModuleMeta.PathArchive)) return ModuleMeta.Hash.ToHexadecimalString();

            if (!string.IsNullOrEmpty(ModuleMeta.PathDirectory))
                return EverestChecksums.GetChecksum(path).ToHexadecimalString();

            throw new InvalidOperationException("Unreachable module storage state");
        }

        /// <summary>
        ///     Calculates the checksums used to cache the assembly in any relevant
        ///     caches (like the relinker cache).
        /// </summary>
        /// <param name="path">The path of the assembly inside of the mod.</param>
        /// <param name="symPath">The path of the assembly's symbols inside of mod, or null.</param>
        /// <returns>The calculated checksums for the file.</returns>
        public AsmChecksums CalcAssemblyCacheChecksums(string path, string symPath)
        {
            var dictionary = new Dictionary<string, string>();
            FillChecksums(dictionary, ModuleMeta.Dependencies);
            var dictionary2 = new Dictionary<string, string>();
            FillChecksums(dictionary2, ModuleMeta.OptionalDependencies);
            return new(Process.Relinker.GameChecksum, CalcChecksumForFile(path),
                symPath != null ? CalcChecksumForFile(symPath) : "", dictionary, dictionary2);

            void FillChecksums(Dictionary<string, string> dict, List<EverestModuleMetadata> deps)
            {
                foreach (var depMeta in deps)
                    if (!(depMeta.Name == "EverestCore") && !(depMeta.Name == "Everest"))
                    {
                        var everestModule =
                            ((ISourceEverestModulesProcessEnvironment)SourceEngine).ModulesProcess.Modules
                            .FirstOrDefault(m => m.Metadata.Name == depMeta.Name);
                        if (everestModule != null)
                            dict[depMeta.Name] = everestModule.Metadata.Hash.ToHexadecimalString();
                    }
            }
        }

        /// <summary>
        ///     Tries to load an assembly from a given path inside the mod.
        ///     This path is an absolute path if the the mod was loaded from a directory, or a path into the mod ZIP otherwise.
        /// </summary>
        /// <param name="path">The path to load the assembly from</param>
        /// <param name="asmName">The assembly name, or null for the default</param>
        /// <returns />
        public Assembly LoadAssemblyFromModPath(string path, string asmName = null)
        {
            string symPath;
            lock (LOCK)
            {
                if (isDisposed) throw new ObjectDisposedException("SourceEverestModuleAssemblyContext");

                var text = path.Replace('\\', Path.DirectorySeparatorChar).Replace('/', Path.DirectorySeparatorChar);
                if (asmName == null) asmName = Path.GetFileNameWithoutExtension(text);

                var key = path.Replace('\\', '/');
                if (_LoadedAssemblies.TryGetValue(key, out var value)) return value;

                _LoadedAssemblies.Add(key, null);
                var activeLocalLoadContexts = Process._ActiveLocalLoadContexts;
                Process._ActiveLocalLoadContexts = null;
                try
                {
                    if (!string.IsNullOrEmpty(ModuleMeta.PathArchive))
                    {
                        using var zipArchive = ZipFile.OpenRead(ModuleMeta.PathArchive);
                        var text2 = text.Replace(Path.DirectorySeparatorChar, '/');
                        var entry = zipArchive.GetEntry(text2);
                        var text3 = Path.ChangeExtension(text, ".pdb").Replace(Path.DirectorySeparatorChar, '/');
                        var symEntry = zipArchive.GetEntry(text3);
                        if (symEntry == null) text3 = null;

                        if (entry != null)
                            value = LoadAssemblyFromModStorage(asmName, text2, text3,
                                StreamOpener);

                        (Stream stream, Stream symStream) StreamOpener()
                        {
                            return (stream: entry.ExtractStream(), symStream: symEntry?.ExtractStream());
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(ModuleMeta.PathDirectory))
                            throw new InvalidOperationException("Unreachable module storage state");

                        symPath = Path.ChangeExtension(path, ".pdb");
                        if (!File.Exists(symPath)) symPath = null;

                        if (File.Exists(text))
                            value = LoadAssemblyFromModStorage(asmName, path, symPath,
                                StreamOpener2);
                    }
                }
                finally
                {
                    Process._ActiveLocalLoadContexts = activeLocalLoadContexts;
                }

                if (value != null)
                {
                    _LoadedAssemblies[key] = value;
                    if (!string.IsNullOrEmpty(ModuleMeta.PathDirectory) && ModuleMeta.SupportsCodeReload &&
                        Process.Lifecycle.CodeReload && Process.Runtime.Capabilities.SupportsAssemblyUnloading)
                        RegisterCodeReloadWatcher(Path.GetFullPath(Path.GetDirectoryName(path)));

                    var tag = "modasmctx";
                    bool shouldLog;
                    shouldLog = Logger.GetLogLevel(tag) <= EverestLogLevel.Info;
                    var str = new SourceDefaultInterpolatedStringHandler(39, 3);
                    if (shouldLog)
                    {
                        str.AppendLiteral("Loaded assembly ");
                        str.AppendFormatted(value.FullName);
                        str.AppendLiteral(" from module '");
                        str.AppendFormatted(ModuleMeta.Name);
                        str.AppendLiteral("' path '");
                        str.AppendFormatted(path);
                        str.AppendLiteral("'");
                    }

                    if (shouldLog)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Info, tag, str.ToStringAndClear());
                }

                return value;
            }

            (Stream stream, Stream symStream) StreamOpener2()
            {
                return (stream: File.OpenRead(path), symStream: symPath != null ? File.OpenRead(symPath) : null);
            }
        }

        private Assembly LoadAssemblyFromModStorage(string asmName, string path, string symbolsPath,
            Func<(Stream stream, Stream symStream)> streamOpener)
        {
            byte[] assemblyBytes;
            byte[] symbolBytes;
            var (stream, symbolStream) = streamOpener();
            using (stream)
            using (symbolStream)
            {
                assemblyBytes = ReadAssemblyStorageBytes(stream);
                symbolBytes = symbolStream == null ? null : ReadAssemblyStorageBytes(symbolStream);
            }

            bool sharedApi;
            bool requiresCecilIsolation;
            using (var inspectionStream = new MemoryStream(assemblyBytes, false))
            using (var module = ModuleDefinition.ReadModule(inspectionStream))
            {
                var sharedEverestName = typeof(SourceEverestModule).Assembly.GetName().Name;
                sharedApi = module.AssemblyReferences.Any(reference => reference.Name == sharedEverestName);
                if (sharedApi) loadsSharedApiAssemblies = true;
                else if (loadsSharedApiAssemblies)
                    sharedApi = !module.AssemblyReferences.Any(reference => reference.Name is
                        "Celeste" or "Celeste.Mod.mm" or "FNA" or "MMHOOK_Celeste"
                        or "Microsoft.Xna.Framework" or "Microsoft.Xna.Framework.Game"
                        or "Microsoft.Xna.Framework.Graphics");
                requiresCecilIsolation =
                    sharedApi && module.AssemblyReferences.Any(CecilRuntimeAssemblies.NeedsRewrite);
            }

            if (!sharedApi)
                return Process.Relinker.GetRelinkedAssembly(ModuleMeta, asmName, path, symbolsPath,
                    () => (new MemoryStream(assemblyBytes, false),
                        symbolBytes == null ? null : new MemoryStream(symbolBytes, false)));

            if (requiresCecilIsolation)
                CecilRuntimeAssemblies.RewriteStorageReferences(ref assemblyBytes, ref symbolBytes,
                    Process.Runtime.DefaultAssemblies);

            // Only Cecil runtime identities are isolated; original Celeste.mm rules are not applied.
            // Validate the actual bytes on every load; a legacy relinker .sum never authorizes it.
            var cachePath = Path.Combine(Process.Lifecycle.PathCache,
                ModuleMeta.Name + "." + asmName + ".shared." + CecilRuntimeAssemblies.CacheIdentity + ".dll");
            Directory.CreateDirectory(Process.Lifecycle.PathCache);
            UpdateSharedAssemblyCache(cachePath, assemblyBytes);
            var cachedSymbols = Path.ChangeExtension(cachePath, ".pdb");
            if (symbolBytes == null)
            {
                if (File.Exists(cachedSymbols)) File.Delete(cachedSymbols);
            }
            else
            {
                UpdateSharedAssemblyCache(cachedSymbols, symbolBytes);
            }

            return LoadRelinkedAssembly(cachePath);
        }

        private static byte[] ReadAssemblyStorageBytes(Stream stream)
        {
            using (var copy = new MemoryStream())
            {
                stream.CopyTo(copy);
                return copy.ToArray();
            }
        }

        private static void UpdateSharedAssemblyCache(string path, byte[] bytes)
        {
            if (File.Exists(path) && File.ReadAllBytes(path).SequenceEqual(bytes)) return;
            File.WriteAllBytes(path, bytes);
        }

        private void RegisterCodeReloadWatcher(string asmDir)
        {
            if (_AssemblyReloadWatchers.ContainsKey(asmDir)) return;

            FileSystemWatcher fileSystemWatcher = null;
            bool shouldLog;
            try
            {
                fileSystemWatcher = new(asmDir)
                {
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite,
                };
                fileSystemWatcher.Changed += delegate(object s, FileSystemEventArgs e2)
                {
                    lock (LOCK)
                    {
                        if (_LoadedAssemblies.GetValueOrDefault(e2.FullPath.Replace('\\', '/')) == null) return;
                    }

                    var tag3 = "modasmctx";
                    bool shouldLog2;
                    shouldLog2 = Logger.GetLogLevel(tag3) <= EverestLogLevel.Info;
                    var str3 = new SourceDefaultInterpolatedStringHandler(60, 1);
                    if (shouldLog2)
                    {
                        str3.AppendLiteral("Reloading mod assembly context because of changed assembly: ");
                        str3.AppendFormatted(e2.FullPath);
                    }

                    if (shouldLog2)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Info, tag3, str3.ToStringAndClear());
                    Process.Lifecycle.ReloadMod(ModuleMeta);
                };
                fileSystemWatcher.Error += delegate(object s, ErrorEventArgs e2)
                {
                    var tag3 = "modasmctx";
                    bool shouldLog2;
                    shouldLog2 = Logger.GetLogLevel(tag3) <= EverestLogLevel.Error;
                    var str3 = new SourceDefaultInterpolatedStringHandler(72, 1);
                    if (shouldLog2)
                    {
                        str3.AppendLiteral("Error while watching \"");
                        str3.AppendFormatted(asmDir);
                        str3.AppendLiteral("\" for changes. Updates will no longer be detected.");
                    }

                    if (shouldLog2)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Error, tag3, str3.ToStringAndClear());
                    Logger.LogDetailed(e2.GetException());
                };
                fileSystemWatcher.EnableRaisingEvents = true;
                _AssemblyReloadWatchers.Add(asmDir, fileSystemWatcher);
                var text = "modasmctx";
                var tag = text;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
                var str = new SourceDefaultInterpolatedStringHandler(34, 1);
                if (shouldLog)
                {
                    str.AppendLiteral("Started watching assembly folder: ");
                    str.AppendFormatted(asmDir);
                }

                if (shouldLog) Logger.LogAssemblyContextUnchecked(EverestLogLevel.Verbose, tag, str.ToStringAndClear());
            }
            catch (Exception e)
            {
                var text = "modasmctx";
                var tag2 = text;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                var str2 = new SourceDefaultInterpolatedStringHandler(33, 1);
                if (shouldLog)
                {
                    str2.AppendLiteral("Failed watching assembly folder: ");
                    str2.AppendFormatted(asmDir);
                }

                if (shouldLog) Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag2, str2.ToStringAndClear());
                Logger.LogDetailed(e);
                fileSystemWatcher?.Dispose();
            }
        }

        /// <summary>
        ///     Loads a relinked assembly into this load context
        /// </summary>
        internal Assembly LoadRelinkedAssembly(string path)
        {
            if (isDisposed) throw new ObjectDisposedException("SourceEverestModuleAssemblyContext");

            ModuleDefinition moduleDefinition = null;
            try
            {
                moduleDefinition = ModuleDefinition.ReadModule(path);
                if (AssemblyLoadBlackList.Contains(moduleDefinition.Assembly.Name.Name,
                        StringComparer.OrdinalIgnoreCase))
                    throw new(
                        $"Attempted load of blacklisted assembly {moduleDefinition.Assembly.Name} from module '{ModuleMeta.Name}'");

                var path2 = Path.ChangeExtension(path, "pdb");
                Assembly assembly2;
                using (Stream assembly = File.OpenRead(path))
                {
                    using Stream assemblySymbols = File.Exists(path2) ? File.OpenRead(path2) : null;
                    assembly2 = RuntimeContext.LoadFromStream(assembly, assemblySymbols);
                }

                if (assembly2.ManifestModule.ModuleVersionId != moduleDefinition.Mvid
                    || assembly2.GetName().FullName != moduleDefinition.Assembly.Name.FullName)
                    throw new BadImageFormatException(
                        "The runtime loaded a different assembly from the selected mod PE.", path);
                physicalAssemblyPaths[assembly2] = Path.GetFullPath(path);

                var name = assembly2.GetName().Name;
                if (_AssemblyModules.TryAdd(name, moduleDefinition))
                {
                    _AssemblyLoadCache.TryAdd(name, assembly2);
                    _LocalLoadCache.TryAdd(name, assembly2);
                    _AssemblyResolveCache.TryAdd(name, moduleDefinition.Assembly);
                }
                else
                {
                    var tag = "modasmctx";
                    bool shouldLog;
                    shouldLog = Logger.GetLogLevel(tag) <= EverestLogLevel.Warn;
                    var str = new SourceDefaultInterpolatedStringHandler(49, 2);
                    if (shouldLog)
                    {
                        str.AppendLiteral("Assembly name conflict for name '");
                        str.AppendFormatted(name);
                        str.AppendLiteral("' for module '");
                        str.AppendFormatted(ModuleMeta.Name);
                        str.AppendLiteral("'!");
                    }

                    if (shouldLog)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag, str.ToStringAndClear());
                }

                return assembly2;
            }
            catch
            {
                moduleDefinition?.Dispose();
                throw;
            }
        }

        internal Assembly Load(AssemblyName asmName)
        {
            asmName = CecilRuntimeAssemblies.RuntimeReference(asmName);
            if (_AssemblyLoadCache.TryGetValue(asmName.Name, out var value)) return value;

            var assembly = LoadLocal(asmName) ?? LoadGlobal(asmName);
            if (assembly == null)
            {
                var activeLocalLoadContexts = Process._ActiveLocalLoadContexts;
                if (activeLocalLoadContexts == null || activeLocalLoadContexts.Count == 0)
                {
                    var tag = "modasmctx";
                    bool shouldLog;
                    shouldLog = Logger.GetLogLevel(tag) <= EverestLogLevel.Warn;
                    var str = new SourceDefaultInterpolatedStringHandler(40, 2);
                    if (shouldLog)
                    {
                        str.AppendLiteral("Failed to load assembly '");
                        str.AppendFormatted(asmName.FullName);
                        str.AppendLiteral("' for module '");
                        str.AppendFormatted(ModuleMeta.Name);
                        str.AppendLiteral("'");
                    }

                    if (shouldLog)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag, str.ToStringAndClear());
                }
            }

            _AssemblyLoadCache.TryAdd(asmName.Name, assembly);
            return assembly;
        }

        internal nint LoadUnmanagedDll(string name)
        {
            if (_AssemblyUnmanagedLoadCache.TryGetValue(name, out var value)) return value;

            var num = LoadUnmanagedLocal(name);
            _AssemblyUnmanagedLoadCache.TryAdd(name, num);
            return num;
        }

        /// <summary>
        ///     Resolves an assembly name reference to an assembly definition
        /// </summary>
        public AssemblyDefinition Resolve(AssemblyNameReference asmName)
        {
            CecilRuntimeAssemblies.RewriteReference(asmName);
            if (_AssemblyResolveCache.TryGetValue(asmName.Name, out var value)) return value;

            var assemblyDefinition = ResolveLocal(asmName) ?? ResolveGlobal(asmName);
            _AssemblyResolveCache.TryAdd(asmName.Name, assemblyDefinition);
            return assemblyDefinition;
        }

        public AssemblyDefinition Resolve(AssemblyNameReference name, ReaderParameters parameters)
        {
            return Resolve(name);
        }

        private Assembly LoadLocal(AssemblyName asmName)
        {
            if (_LocalLoadCache.TryGetValue(asmName.Name, out var value)) return value;

            var assembly = LoadFromThisMod(asmName);
            if ((object)assembly != null)
            {
                _LocalLoadCache.TryAdd(asmName.Name, assembly);
                return assembly;
            }

            (Process._ActiveLocalLoadContexts ??
             (Process._ActiveLocalLoadContexts = new())).Push(this);
            try
            {
                foreach (var dependencyContext in DependencyContexts)
                    try
                    {
                        if (!Process._ActiveLocalLoadContexts.Contains(dependencyContext))
                        {
                            var assembly2 = dependencyContext.LoadFromThisMod(asmName);
                            if ((object)assembly2 != null)
                            {
                                _LocalLoadCache.TryAdd(asmName.Name, assembly2);
                                ActiveDependencyContexts.Add(dependencyContext);
                                return assembly2;
                            }
                        }
                    }
                    catch
                    {
                    }
            }
            finally
            {
                if (Process._ActiveLocalLoadContexts.Pop() != this)
                    Process.Lifecycle.CriticalFailureHandler(
                        new("Unexpected SourceEverestModuleAssemblyContext on stack"));
            }

            return null;
        }

        private nint LoadUnmanagedLocal(string name)
        {
            if (_LocalUnmanagedLoadCache.TryGetValue(name, out var value)) return value;

            var handle = LoadUnmanagedFromThisMod(name);
            if (handle != IntPtr.Zero)
            {
                RuntimeContext.Unloading += delegate { Process.Runtime.FreeNativeLibrary(handle); };
                _LocalUnmanagedLoadCache.TryAdd(name, handle);
                return handle;
            }

            (Process._ActiveLocalLoadContexts ??
             (Process._ActiveLocalLoadContexts = new())).Push(this);
            try
            {
                foreach (var dependencyContext in DependencyContexts)
                    try
                    {
                        if (!Process._ActiveLocalLoadContexts.Contains(dependencyContext))
                        {
                            var num = dependencyContext.LoadUnmanagedDll(name);
                            if (num != IntPtr.Zero)
                            {
                                _LocalUnmanagedLoadCache.TryAdd(name, num);
                                ActiveDependencyContexts.Add(dependencyContext);
                                return num;
                            }
                        }
                    }
                    catch
                    {
                    }
            }
            finally
            {
                if (Process._ActiveLocalLoadContexts.Pop() != this)
                    Process.Lifecycle.CriticalFailureHandler(
                        new("Unexpected SourceEverestModuleAssemblyContext on stack"));
            }

            return IntPtr.Zero;
        }

        private AssemblyDefinition ResolveLocal(AssemblyNameReference asmName)
        {
            if (_LocalResolveCache.TryGetValue(asmName.Name, out var value)) return value;

            var assemblyDefinition = ResolveFromThisMod(asmName);
            if (assemblyDefinition != null)
            {
                _LocalResolveCache.TryAdd(asmName.Name, assemblyDefinition);
                return assemblyDefinition;
            }

            (Process._ActiveLocalLoadContexts ??
             (Process._ActiveLocalLoadContexts = new())).Push(this);
            try
            {
                foreach (var dependencyContext in DependencyContexts)
                    if (!Process._ActiveLocalLoadContexts.Contains(dependencyContext))
                    {
                        var assemblyDefinition2 = dependencyContext.ResolveFromThisMod(asmName);
                        if (assemblyDefinition2 != null)
                        {
                            _LocalResolveCache.TryAdd(asmName.Name, assemblyDefinition2);
                            return assemblyDefinition2;
                        }
                    }
            }
            finally
            {
                if (Process._ActiveLocalLoadContexts.Pop() != this)
                    Process.Lifecycle.CriticalFailureHandler(
                        new("Unexpected SourceEverestModuleAssemblyContext on stack"));
            }

            return null;
        }

        private Assembly LoadGlobal(AssemblyName asmName)
        {
            try
            {
                var assembly = Process.Runtime.LoadDefaultAssembly(asmName);
                if ((object)assembly != null) return assembly;
            }
            catch
            {
            }

            foreach (var module in ((ISourceEverestModulesProcessEnvironment)SourceEngine)
                     .ModulesProcess
                     .Modules)
            {
                var assembly2 = module.Metadata.AssemblyContext?.LoadFromThisMod(asmName);
                if ((object)assembly2 != null)
                {
                    var tag = "modasmctx";
                    bool shouldLog;
                    shouldLog = Logger.GetLogLevel(tag) <= EverestLogLevel.Info;
                    var str = new SourceDefaultInterpolatedStringHandler(56, 3);
                    if (shouldLog)
                    {
                        str.AppendLiteral("Loading assembly '");
                        str.AppendFormatted(asmName.FullName);
                        str.AppendLiteral("' from non-dependency '");
                        str.AppendFormatted(module.Metadata.Name);
                        str.AppendLiteral("' for module '");
                        str.AppendFormatted(ModuleMeta.Name);
                        str.AppendLiteral("'");
                    }

                    if (shouldLog)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Info, tag, str.ToStringAndClear());
                    DependencyContexts.Add(module.Metadata.AssemblyContext);
                    ActiveDependencyContexts.Add(module.Metadata.AssemblyContext);
                    return assembly2;
                }
            }

            return null;
        }

        private AssemblyDefinition ResolveGlobal(AssemblyNameReference asmName)
        {
            bool shouldLog;
            if (!Process._GlobalAssemblyResolveCache.TryGetValue(asmName.Name, out var value))
            {
                Assembly assembly = null;
                try
                {
                    assembly = Process.Runtime.LoadDefaultAssembly(new(asmName.Name));
                }
                catch
                {
                }

                value = null;
                if (!string.IsNullOrEmpty(assembly?.Location))
                    try
                    {
                        value = ModuleDefinition.ReadModule(assembly.Location).Assembly;
                    }
                    catch (Exception e)
                    {
                        var text = "modasmctx";
                        var tag = text;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                        var str = new SourceDefaultInterpolatedStringHandler(47, 1);
                        if (shouldLog)
                        {
                            str.AppendLiteral("Failed to resolve global assembly definition '");
                            str.AppendFormatted(asmName.FullName);
                            str.AppendLiteral("'");
                        }

                        if (shouldLog)
                            Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag, str.ToStringAndClear());
                        Logger.LogDetailed(e);
                    }

                Process._GlobalAssemblyResolveCache.Add(asmName.Name, value);
            }

            Process._AllContextsLock.EnterReadLock();
            try
            {
                foreach (var allContext in Process._AllContexts)
                {
                    var assemblyDefinition = allContext.ResolveFromThisMod(asmName);
                    if (assemblyDefinition != null)
                    {
                        var text = "modasmctx";
                        var tag2 = text;
                        shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Info;
                        var str2 = new SourceDefaultInterpolatedStringHandler(56, 3);
                        if (shouldLog)
                        {
                            str2.AppendLiteral("Resolving assembly '");
                            str2.AppendFormatted(asmName.FullName);
                            str2.AppendLiteral("' in non-dependency '");
                            str2.AppendFormatted(allContext.ModuleMeta.Name);
                            str2.AppendLiteral("' for module '");
                            str2.AppendFormatted(ModuleMeta.Name);
                            str2.AppendLiteral("'");
                        }

                        if (shouldLog)
                            Logger.LogAssemblyContextUnchecked(EverestLogLevel.Info, tag2, str2.ToStringAndClear());
                        DependencyContexts.Add(allContext);
                        ActiveDependencyContexts.Add(allContext);
                        return assemblyDefinition;
                    }
                }

                return value;
            }
            finally
            {
                Process._AllContextsLock.ExitReadLock();
            }
        }

        private Assembly LoadFromThisMod(AssemblyName asmName)
        {
            if (_ModAsmDir == null) return null;

            var assembly = LoadAssemblyFromModPath(Path.Combine(_ModAsmDir, asmName.Name + ".dll"));
            if ((object)assembly != null) return assembly;

            return null;
        }

        private nint LoadUnmanagedFromThisMod(string name)
        {
            if (_ModAsmDir == null) return IntPtr.Zero;

            var text = RuntimeInformation.IsOSPlatform(OSPlatform.Windows)
                ? name + ".dll"
                : RuntimeInformation.IsOSPlatform(OSPlatform.Linux)
                    ? "lib" + name + ".so"
                    : RuntimeInformation.IsOSPlatform(OSPlatform.OSX)
                        ? "lib" + name + ".dylib"
                        : name;
            var array = new[] { name, text };
            foreach (var text2 in array)
                if (!string.IsNullOrEmpty(ModuleMeta.PathArchive))
                {
                    var text3 = Path.Combine(Process.Lifecycle.PathCache, "unmanaged-libs",
                        Process.UnmanagedLibraryFolder, ModuleMeta.Name);
                    var text4 = ModuleMeta.Hash.ToHexadecimalString();
                    if (Directory.Exists(text3) &&
                        (!File.Exists(text3 + ".sum") || File.ReadAllText(text3 + ".sum") != text4))
                        Directory.Delete(text3, true);

                    if (!Directory.Exists(text3))
                    {
                        var text5 = Path.Combine(_ModAsmDir, Process.UnmanagedLibraryFolder).Replace('\\', '/') +
                                    "/";
                        using (var zipArchive = ZipFile.OpenRead(ModuleMeta.PathArchive))
                        {
                            foreach (var entry in zipArchive.Entries)
                            {
                                if (!entry.FullName.StartsWith(text5) || entry.FullName.EndsWith("/")) continue;

                                var text6 = entry.FullName.Substring(text5.Length)
                                    .Replace('/', Path.DirectorySeparatorChar)
                                    .Replace('\\', Path.DirectorySeparatorChar);
                                if (text6.Length <= 0) continue;

                                Directory.CreateDirectory(Path.GetDirectoryName(Path.Combine(text3, text6)));
                                using var stream = entry.Open();
                                using Stream destination = File.Create(Path.Combine(text3, text6));
                                stream.CopyTo(destination);
                            }
                        }

                        Directory.CreateDirectory(Path.GetDirectoryName(text3));
                        File.WriteAllText(text3 + ".sum", text4);
                    }

                    if (Process.Runtime.TryLoadNativeLibrary(Path.Combine(text3, text2), out var handle)) return handle;
                }
                else
                {
                    if (string.IsNullOrEmpty(ModuleMeta.PathDirectory))
                        throw new InvalidOperationException("Unreachable module storage state");

                    if (Process.Runtime.TryLoadNativeLibrary(
                            Path.Combine(_ModAsmDir, Process.UnmanagedLibraryFolder, text2), out var handle2))
                        return handle2;
                }

            return IntPtr.Zero;
        }

        private AssemblyDefinition ResolveFromThisMod(AssemblyNameReference asmName)
        {
            if (_ModAsmDir == null) return null;

            if (LoadAssemblyFromModPath(Path.Combine(_ModAsmDir, asmName.Name + ".dll")) != null)
                return _AssemblyModules[asmName.Name].Assembly;

            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Celeste.Core.Scheduling;
using Celeste.Core.Text;
using Celeste.Everest.Diagnostics.Logging;
using Celeste.Everest.Modules.Updating;
using Mono.Cecil;
using Mono.Cecil.Cil;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public sealed class SourceEverestAssemblyRelinker : ISourceEverestAssemblyRelinker
    {
        private readonly ISourceEngineContext SourceEngine;
        private ISourceEverestRelinkerEnvironment Environment => (ISourceEverestRelinkerEnvironment)SourceEngine;
        private EverestLoggerProcess Logger => ((IEverestLoggerProcessEnvironment)SourceEngine).Logger;

        public SourceEverestAssemblyRelinker(ISourceEngineContext engine)
        {
            SourceEngine = engine;
        }

        private string _GameChecksum;

        /// <summary>
        ///     Skips checking the GameChecksum when checking if mods should be relinked.
        /// </summary>
        public bool SkipGameChecksum { get; set; }

        /// <summary>
        ///     The lock which the relinker holds when relinking assemblies
        /// </summary>
        public readonly object RelinkerLock = new();

        private Dictionary<string, ModuleDefinition> _SharedRelinkModuleMap;

        private Dictionary<string, object> _SharedRelinkMap;

        /// <summary>
        ///     The current Celeste.exe's checksum.
        /// </summary>
        public string GameChecksum
        {
            get
            {
                var obj = _GameChecksum ?? EverestChecksums.GetChecksum(Environment.OriginalGameAssemblyPath)
                    .ToHexadecimalString();
                _GameChecksum = obj;
                return obj;
            }
        }

        /// <summary>
        ///     A map shared between all invocations of the relinker which maps certain referenced modules onto others. Can be used
        ///     with <see cref="F:MonoMod.MonoModder.RelinkModuleMap" />.
        /// </summary>
        public Dictionary<string, ModuleDefinition> SharedRelinkModuleMap
        {
            get
            {
                if (_SharedRelinkModuleMap != null) return _SharedRelinkModuleMap;

                _SharedRelinkModuleMap = new();
                var files = Directory.GetFiles(Environment.PathGame);
                foreach (var path in files)
                {
                    var fileName = Path.GetFileName(path);
                    if (!fileName.EndsWith(".mm.dll")) continue;

                    var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                    string text;
                    if (fileName == "Celeste.Mod.mm.dll")
                    {
                        text = Environment.OriginalGameAssemblyPath;
                    }
                    else
                    {
                        var text2 = "relinker";
                        var tag = text2;
                        bool shouldLog;
                        shouldLog = Logger.GetLogLevel(text2) <= EverestLogLevel.Warn;
                        var str = new SourceDefaultInterpolatedStringHandler(31, 1);
                        if (shouldLog)
                        {
                            str.AppendLiteral("Found unexpected mod assembly ");
                            str.AppendFormatted(fileName);
                            str.AppendLiteral("!");
                        }

                        if (shouldLog)
                            Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag, str.ToStringAndClear());
                        text = fileName.Substring(0, fileNameWithoutExtension.Length - 3);
                        var path2 = Path.Combine(Environment.PathGame, text + ".dll");
                        if (!File.Exists(path2))
                        {
                            Logger.Log(EverestLogLevel.Info, "relinker", "-> couldn't remap, ignoring...");
                            continue;
                        }

                        text2 = "relinker";
                        var tag2 = text2;
                        shouldLog = Logger.GetLogLevel(text2) <= EverestLogLevel.Info;
                        var str2 = new SourceDefaultInterpolatedStringHandler(16, 1);
                        if (shouldLog)
                        {
                            str2.AppendLiteral("-> remapping to ");
                            str2.AppendFormatted(Path.GetFileName(path2));
                        }

                        if (shouldLog)
                            Logger.LogAssemblyContextUnchecked(EverestLogLevel.Info, tag2, str2.ToStringAndClear());
                    }

                    _SharedRelinkModuleMap[fileNameWithoutExtension] =
                        ModuleDefinition.ReadModule(text, new(ReadingMode.Immediate));
                }

                return _SharedRelinkModuleMap;
            }
        }

        /// <summary>
        ///     A map shared between all invocations of the relinker which maps certain referenced types / methods / fields / etc.
        ///     onto others. Can be used with <see cref="F:MonoMod.MonoModder.RelinkMap" />.
        /// </summary>
        public Dictionary<string, object> SharedRelinkMap
        {
            get
            {
                if (_SharedRelinkMap != null) return _SharedRelinkMap;

                var patcherRuntime = Environment.PatcherRuntime;
                _SharedRelinkMap = new();
                _SharedRelinkMap["MonoMod.Utils.MonoModExt"] = "MonoMod.Utils.Extensions";
                _SharedRelinkMap[
                        "System.String MonoMod.Utils.Extensions::GetFindableID(Mono.Cecil.MethodReference,System.String,System.String,System.Boolean,System.Boolean)"] =
                    patcherRuntime.CreateRelinkMapEntry("MonoMod.Utils.Extensions",
                        "System.String GetID(Mono.Cecil.MethodReference,System.String,System.String,System.Boolean,System.Boolean)");
                _SharedRelinkMap[
                        "System.String MonoMod.Utils.Extensions::GetFindableID(System.Reflection.MethodBase,System.String,System.String,System.Boolean,System.Boolean,System.Boolean)"] =
                    patcherRuntime.CreateRelinkMapEntry("MonoMod.Utils.Extensions",
                        "System.String GetID(System.Reflection.MethodBase,System.String,System.String,System.Boolean,System.Boolean,System.Boolean)");
                _SharedRelinkMap
                        ["Mono.Cecil.ModuleDefinition MonoMod.Utils.Extensions::ReadModule(System.String,Mono.Cecil.ReaderParameters)"] =
                    patcherRuntime.CreateRelinkMapEntry("Mono.Cecil.ModuleDefinition",
                        "Mono.Cecil.ModuleDefinition ReadModule(System.String,Mono.Cecil.ReaderParameters)");
                return _SharedRelinkMap;
            }
        }

        public Assembly GetRelinkedAssembly(EverestModuleMetadata meta, string asmname, string path, string symPath,
            Func<(Stream stream, Stream symStream)> streamOpener)
        {
            lock (RelinkerLock)
            {
                var cachedPath = GetCachedPath(meta, asmname);
                var text = Path.ChangeExtension(cachedPath, ".sum");
                Assembly assembly = null;
                SourceEverestModuleAssemblyContext.AsmChecksums curChecksums;
                var assembly2 =
                    TryLoadCachedAssembly(meta, asmname, path, symPath, cachedPath, text, out curChecksums);
                bool shouldLog;
                string text2;
                if ((object)assembly2 == null)
                {
                    File.Delete(cachedPath);
                    File.Delete(text);
                    var (stream, stream2) = streamOpener();
                    using (stream)
                    {
                        using (stream2)
                        {
                            try
                            {
                                string tmpOutPath;
                                var assembly3 = RelinkAssembly(meta, asmname, stream, stream2, cachedPath,
                                    out tmpOutPath);
                                if ((object)assembly3 == null) return null;

                                assembly = assembly3;
                                if (tmpOutPath == null) curChecksums.WriteToFile(text);
                            }
                            catch (Exception e)
                            {
                                text2 = "relinker";
                                var tag = text2;
                                shouldLog = Logger.GetLogLevel(text2) <= EverestLogLevel.Warn;
                                var str = new SourceDefaultInterpolatedStringHandler(20, 2);
                                if (shouldLog)
                                {
                                    str.AppendLiteral("Failed relinking ");
                                    str.AppendFormatted(meta);
                                    str.AppendLiteral(" - ");
                                    str.AppendFormatted(asmname);
                                }

                                if (shouldLog)
                                    Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag,
                                        str.ToStringAndClear());
                                Logger.LogDetailed(e);
                                return null;
                            }
                        }
                    }
                }
                else
                {
                    assembly = assembly2;
                }

                text2 = "relinker";
                var tag2 = text2;
                shouldLog = Logger.GetLogLevel(text2) <= EverestLogLevel.Verbose;
                var str2 = new SourceDefaultInterpolatedStringHandler(27, 3);
                if (shouldLog)
                {
                    str2.AppendLiteral("Loading assembly for ");
                    str2.AppendFormatted(meta);
                    str2.AppendLiteral(" - ");
                    str2.AppendFormatted(asmname);
                    str2.AppendLiteral(" - ");
                    str2.AppendFormatted(assembly.FullName);
                }

                if (shouldLog)
                    Logger.LogAssemblyContextUnchecked(EverestLogLevel.Verbose, tag2, str2.ToStringAndClear());
                return assembly;
            }
        }

        private Assembly TryLoadCachedAssembly(EverestModuleMetadata meta, string asmName, string inPath,
            string inSymPath,
            string cachePath, string cacheChecksumsPath,
            out SourceEverestModuleAssemblyContext.AsmChecksums curChecksums)
        {
            curChecksums =
                meta.AssemblyContext.CalcAssemblyCacheChecksums(inPath,
                    !string.IsNullOrEmpty(meta.PathArchive) ? null : inSymPath);
            if (!File.Exists(cachePath) || !File.Exists(cacheChecksumsPath)) return null;

            if (!curChecksums.IsValidWith(
                    SourceEverestModuleAssemblyContext.AsmChecksums.ReadFromFile(cacheChecksumsPath),
                    SkipGameChecksum))
                return null;

            var text = "relinker";
            var tag = text;
            bool shouldLog;
            shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Verbose;
            var str = new SourceDefaultInterpolatedStringHandler(31, 2);
            if (shouldLog)
            {
                str.AppendLiteral("Loading cached assembly for ");
                str.AppendFormatted(meta);
                str.AppendLiteral(" - ");
                str.AppendFormatted(asmName);
            }

            if (shouldLog) Logger.LogAssemblyContextUnchecked(EverestLogLevel.Verbose, tag, str.ToStringAndClear());
            try
            {
                return meta.AssemblyContext.LoadRelinkedAssembly(cachePath);
            }
            catch (Exception e)
            {
                text = "relinker";
                var tag2 = text;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                var str2 = new SourceDefaultInterpolatedStringHandler(38, 2);
                if (shouldLog)
                {
                    str2.AppendLiteral("Failed loading cached assembly for ");
                    str2.AppendFormatted(meta);
                    str2.AppendLiteral(" - ");
                    str2.AppendFormatted(asmName);
                }

                if (shouldLog) Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag2, str2.ToStringAndClear());
                Logger.LogDetailed(e);
                return null;
            }
        }

        private Assembly RelinkAssembly(EverestModuleMetadata meta, string asmname, Stream stream, Stream symStream,
            string outPath, out string tmpOutPath)
        {
            tmpOutPath = null;
            EnsureStreamIsSeekable(ref stream);
            EnsureStreamIsSeekable(ref symStream);
            var monoModder = Environment.PatcherRuntime.Create(Logger);
            monoModder.CleanupEnabled = false;
            monoModder.Input = stream;
            monoModder.OutputPath = outPath;
            monoModder.RelinkModuleMap = new(SharedRelinkModuleMap);
            monoModder.RelinkMap = new(SharedRelinkMap);
            monoModder.AssemblyResolver = meta.AssemblyContext;
            monoModder.MissingDependencyThrow = false;
            bool shouldLog;
            try
            {
                InitMMFlags(monoModder);
                monoModder.ReaderParameters.ReadSymbols = symStream != null;
                monoModder.ReaderParameters.SymbolStream = symStream;
                monoModder.Read();
                CecilRuntimeAssemblies.RewriteReferences(monoModder.Module);
                if (meta.AssemblyContext.AssemblyLoadBlackList.Contains(monoModder.Module.Assembly.Name.Name,
                        StringComparer.OrdinalIgnoreCase))
                {
                    var text = "relinker";
                    var tag = text;
                    shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                    var str = new SourceDefaultInterpolatedStringHandler(42, 2);
                    if (shouldLog)
                    {
                        str.AppendLiteral("Attempted load of blacklisted assembly ");
                        str.AppendFormatted(meta);
                        str.AppendLiteral(" - ");
                        str.AppendFormatted(monoModder.Module.Assembly.Name);
                    }

                    if (shouldLog)
                        Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag, str.ToStringAndClear());
                    return null;
                }

                var moduleDefinition = LoadRuntimeRulesModule();
                monoModder.MapDependencies();
                monoModder.MapDependencies(moduleDefinition);
                var type = moduleDefinition.GetType("MonoMod.MonoModRules");
                monoModder.ParseRules(moduleDefinition);
                if (type != null) moduleDefinition.Types.Add(type);

                monoModder.ParseRules(monoModder.Module);
                monoModder.AutoPatch();
                if (!meta.IsNetCoreOnlyMod) Environment.PatcherRuntime.ConvertToNetCore(monoModder, true);

                CecilRuntimeAssemblies.RewriteReferences(monoModder.Module);
                var flag = false;
                while (true)
                {
                    try
                    {
                        monoModder.WriterParameters.WriteSymbols = true;
                        monoModder.WriterParameters.SymbolWriterProvider = new PortablePdbWriterProvider();
                        monoModder.Write();
                    }
                    catch
                    {
                        try
                        {
                            monoModder.WriterParameters.SymbolWriterProvider = null;
                            monoModder.WriterParameters.WriteSymbols = false;
                            monoModder.Write();
                            goto end_IL_0192;
                        }
                        catch (Exception e) when (!flag)
                        {
                            Logger.Log(EverestLogLevel.Warn, "relinker",
                                "Couldn't write to intended output path - falling back to temporary file...");
                            Logger.LogDetailed(e);
                            flag = true;
                            var value = DateTime.Now.Ticks / 10000;
                            tmpOutPath = Path.Combine(Path.GetTempPath(),
                                $"Everest.Relinked.{Path.GetFileNameWithoutExtension(outPath)}.{value}.dll");
                            var module = monoModder.Module;
                            module.Name = module.Name + "." + value;
                            var name = monoModder.Module.Assembly.Name;
                            name.Name = name.Name + "." + value;
                            monoModder.OutputPath = tmpOutPath;
                            monoModder.WriterParameters.WriteSymbols = true;
                        }

                        continue;
                        end_IL_0192: ;
                    }

                    break;
                }
            }
            finally
            {
                monoModder.Module?.Dispose();
            }

            try
            {
                return meta.AssemblyContext.LoadRelinkedAssembly(outPath);
            }
            catch (Exception e2)
            {
                var text = "relinker";
                var tag2 = text;
                shouldLog = Logger.GetLogLevel(text) <= EverestLogLevel.Warn;
                var str = new SourceDefaultInterpolatedStringHandler(36, 2);
                if (shouldLog)
                {
                    str.AppendLiteral("Failed loading relinked assembly ");
                    str.AppendFormatted(meta);
                    str.AppendLiteral(" - ");
                    str.AppendFormatted(asmname);
                }

                if (shouldLog) Logger.LogAssemblyContextUnchecked(EverestLogLevel.Warn, tag2, str.ToStringAndClear());
                Logger.LogDetailed(e2);
                return null;
            }
        }

        private ModuleDefinition LoadRuntimeRulesModule()
        {
            var text = Path.Combine(Path.GetDirectoryName(Environment.OriginalGameAssemblyPath),
                Path.GetFileNameWithoutExtension(Environment.OriginalGameAssemblyPath) + ".Mod.mm.dll");
            if (!File.Exists(text))
                text = Path.Combine(Path.GetDirectoryName(Environment.OriginalGameAssemblyPath), "Celeste.Mod.mm.dll");

            if (!File.Exists(text)) throw new InvalidOperationException("Couldn't find runtime rules .Mod.mm.dll!");

            return ModuleDefinition.ReadModule(text, new(ReadingMode.Immediate));
        }

        /// <summary>
        ///     Get the cached path of a given mod's relinked .dll
        /// </summary>
        /// <param name="meta">The mod metadata.</param>
        /// <param name="asmname" />
        /// <returns>The full path to the cached relinked .dll</returns>
        public string GetCachedPath(EverestModuleMetadata meta, string asmname)
        {
            return Path.Combine(Environment.PathCache,
                meta.Name + "." + asmname + "." + CecilRuntimeAssemblies.CacheIdentity + ".dll");
        }

        /// <summary>
        ///     Determine if both checksum collections are equal.
        /// </summary>
        /// <param name="a">The first checksum array.</param>
        /// <param name="b">The second checksum array.</param>
        /// <returns>True if the contents of both arrays match, false otherwise.</returns>
        public bool ChecksumsEqual(string[] a, string[] b)
        {
            if (a.Length != b.Length) return false;

            for (var i = 0; i < a.Length; i++)
                if (a[i].Trim() != b[i].Trim())
                    return false;

            return true;
        }

        private void EnsureStreamIsSeekable(ref Stream stream)
        {
            if (stream != null && !stream.CanSeek)
            {
                var memoryStream = new MemoryStream();
                stream.CopyTo(memoryStream);
                stream = memoryStream;
            }
        }

        private void InitMMFlags(ISourceRelinkPatcher modder)
        {
            SetMMFlag(modder, "Headless", false);
            SetMMFlag(modder, "OS:Windows", true);
            SetMMFlag(modder, "OS:NotWindows", false);
            SetMMFlag(modder, "FNA", true);
            SetMMFlag(modder, "XNA", false);
            SetMMFlag(modder, "Steamworks", true);
            SetMMFlag(modder, "NoLauncher", false);
            SetMMFlag(modder, "Has:BirdTutorialGuiButtonPromptEnum", true);
            SetMMFlag(modder, "RelinkXNA", true);
            SetMMFlag(modder, "DontRelinkXNA", false);
        }

        private void SetMMFlag(ISourceRelinkPatcher modder, string key, bool value)
        {
            modder.SharedData[key] = value;
        }
    }
}

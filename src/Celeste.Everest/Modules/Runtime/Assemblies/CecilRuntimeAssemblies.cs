using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Mono.Cecil;

namespace Celeste.Everest.Modules.Runtime.Assemblies
{
    public static class CecilRuntimeAssemblies
    {
        private static readonly AssemblyName Core = typeof(ModuleDefinition).Assembly.GetName();
        private static readonly byte[] Token = Core.GetPublicKeyToken();

        public static readonly string[] Names =
            [Core.Name, Core.Name + ".Pdb", Core.Name + ".Mdb", Core.Name + ".Rocks"];

        public static string CacheIdentity { get; } = Core.Name + "." + Core.Version;

        public static bool IsRuntimeName(string name)
        {
            return Array.IndexOf(Names, name) >= 0;
        }

        private static bool TryMap(string name, byte[] token, out string mapped)
        {
            mapped = null;
            if (Core.Name == "Mono.Cecil" || token == null || token.Length != Token.Length) return false;
            for (var i = 0; i < token.Length; i++)
                if (token[i] != Token[i])
                    return false;
            var index = name switch
            {
                "Mono.Cecil" => 0,
                "Mono.Cecil.Pdb" => 1,
                "Mono.Cecil.Mdb" => 2,
                "Mono.Cecil.Rocks" => 3,
                _ => -1,
            };
            if (index < 0) return false;
            mapped = Names[index];
            return true;
        }

        public static AssemblyName RuntimeReference(AssemblyName reference)
        {
            if (!TryMap(reference.Name, reference.GetPublicKeyToken(), out var mapped)) return reference;
            var runtime = (AssemblyName)reference.Clone();
            runtime.Name = mapped;
            runtime.Version = Core.Version;
            runtime.SetPublicKeyToken(Token);
            return runtime;
        }

        public static bool NeedsRewrite(AssemblyNameReference reference)
        {
            return TryMap(reference.Name, reference.PublicKeyToken, out _);
        }

        public static bool RewriteReference(AssemblyNameReference reference)
        {
            if (!TryMap(reference.Name, reference.PublicKeyToken, out var mapped)) return false;
            reference.Name = mapped;
            reference.Version = Core.Version;
            reference.PublicKey = [];
            reference.PublicKeyToken = Token;
            return true;
        }

        public static bool RewriteReferences(ModuleDefinition module)
        {
            var changed = false;
            foreach (var reference in module.AssemblyReferences)
                changed |= RewriteReference(reference);
            return changed;
        }

        public static void RewriteStorageReferences(ref byte[] assemblyBytes, ref byte[] symbolBytes,
            IEnumerable<Assembly> runtimeAssemblies)
        {
            using var resolver = new DefaultAssemblyResolver();
            foreach (var directory in resolver.GetSearchDirectories()) resolver.RemoveSearchDirectory(directory);
            var directories = new HashSet<string>(StringComparer.Ordinal);
            foreach (var assembly in runtimeAssemblies)
            {
                if (assembly.IsDynamic) continue;
                var path = assembly.Location;
                if (string.IsNullOrEmpty(path)) path = assembly.ManifestModule.FullyQualifiedName;
                if (string.IsNullOrEmpty(path) || !Path.IsPathRooted(path) || !File.Exists(path)) continue;
                var directory = Path.GetDirectoryName(path);
                if (directories.Add(directory)) resolver.AddSearchDirectory(directory);
                var facades = Path.Combine(directory, "Facades");
                if (Directory.Exists(facades) && directories.Add(facades)) resolver.AddSearchDirectory(facades);
            }

            using var input = new MemoryStream(assemblyBytes, false);
            using var symbols = symbolBytes == null ? null : new MemoryStream(symbolBytes, false);
            using var module = ModuleDefinition.ReadModule(input, new()
            {
                AssemblyResolver = resolver,
                ReadSymbols = symbols != null,
                SymbolStream = symbols,
            });
            if (!RewriteReferences(module)) return;
            if (module.Assembly.Name.HasPublicKey)
                throw new NotSupportedException(
                    "A signed mod needs its signing key before runtime references can be rewritten.");
            using var output = new MemoryStream();
            using var outputSymbols = symbols == null ? null : new MemoryStream();
            module.Write(output, new()
            {
                WriteSymbols = module.HasSymbols,
                SymbolWriterProvider = module.SymbolReader?.GetWriterProvider(),
                SymbolStream = outputSymbols,
            });
            assemblyBytes = output.ToArray();
            if (outputSymbols != null) symbolBytes = outputSymbols.ToArray();
        }
    }
}

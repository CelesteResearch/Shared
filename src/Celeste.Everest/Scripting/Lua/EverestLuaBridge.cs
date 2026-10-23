using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Celeste.Everest.Content.Packages;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Content.Types.Modules;

namespace Celeste.Everest.Scripting.Lua
{
    // The Lua VM never owns a content source. A lookup observes the current ordered
    // registry, just as Everest.Content.TryGet observes its current overlay map.
    public sealed class EverestLuaBridge
    {
        private readonly EverestManifestCatalog catalog;
        private readonly EverestContentRegistry content;
        private readonly HashSet<string> preloaded = new(StringComparer.Ordinal);
        public Action<Assembly> PrecacheAssembly { get; set; }

        public EverestLuaBridge(EverestManifestCatalog catalog)
        {
            this.catalog = catalog ?? throw new ArgumentNullException(nameof(catalog));
        }

        public EverestLuaBridge(EverestContentRegistry content)
        {
            this.content = content ?? throw new ArgumentNullException(nameof(content));
        }

        public string[] VirtualFile(string context, string name)
        {
            if (string.IsNullOrEmpty(name)) return null;
            var assetName = name.Replace('.', '/');
            string prefix = null;
            if (!string.IsNullOrEmpty(context))
            {
                var colon = context.IndexOf(':');
                if (colon >= 0) prefix = context.Substring(0, colon + 1);
            }

            if (assetName.IndexOf(':') < 0 && prefix != null &&
                TryRead(prefix + "/" + assetName, out var scoped)) return scoped;
            return TryRead(assetName, out var global) ? global : [null, null];
        }

        private bool TryRead(string virtualName, out string[] result)
        {
            if (content != null)
            {
                if (!content.TryGet<AssetTypeLua>(virtualName, out var asset))
                {
                    result = null;
                    return false;
                }

                var owner = asset.Source.DefaultName;
                if (string.IsNullOrEmpty(owner)) owner = asset.Source.Name;
                if (string.IsNullOrEmpty(owner)) owner = "???";
                using var reader = new StreamReader(asset.Stream);
                result = [reader.ReadToEnd(), "Mods/" + owner + "/" + asset.PathVirtual + ".lua"];
                return true;
            }

            string sourceName = null;
            var sourceSeparator = virtualName.IndexOf(":/", StringComparison.Ordinal);
            if (sourceSeparator >= 0)
            {
                sourceName = virtualName.Substring(0, sourceSeparator);
                virtualName = virtualName.Substring(sourceSeparator + 2);
            }

            var path = virtualName + ".lua";
            var packages = catalog.Packages;
            for (var i = packages.Count - 1; i >= 0; i--)
            {
                var package = packages[i];
                if (!package.IsRegistered || (sourceName != null && package.SourceName != sourceName) ||
                    !package.ContainsAsset(path)) continue;
                var owner = package.SourceName;
                if (string.IsNullOrEmpty(owner)) owner = "???";
                result =
                [
                    Encoding.UTF8.GetString(package.ReadAsset(path)), "Mods/" + owner + "/" + virtualName + ".lua",
                ];
                return true;
            }

            result = null;
            return false;
        }

        // Everest first precaches assemblies, then its namespace tree. This helper
        // resolves the same public namespace and registered type paths without
        // introducing a Unity dependency into the library.
        public int SymbolKind(string name)
        {
            if (string.IsNullOrEmpty(name)) return 1;
            if (EverestLuaTypes.FindType(name) != null) return 2;
            if (EverestLuaTypes.HasAliasNamespace(name)) return 1;
            var prefix = name + ".";
            foreach (var assembly in EverestLuaTypes.LoadedAssemblies())
            {
                Type[] found;
                try
                {
                    found = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException error)
                {
                    found = error.Types;
                }
                catch
                {
                    continue;
                }

                foreach (var type in found)
                    if (type != null && type.FullName != null &&
                        type.FullName.Replace('+', '.').StartsWith(prefix, StringComparison.Ordinal))
                        return 1;
            }

            return 0;
        }

        public bool Preload(string name)
        {
            if (string.IsNullOrEmpty(name)) return false;
            if (preloaded.Contains(name)) return true;
            var found = Type.GetType(name);
            if (found != null)
            {
                preloaded.Add(name);
                preloaded.Add(found.FullName);
                Precache(found.Assembly);
                return true;
            }

            var assemblies = EverestLuaTypes.LoadedAssemblies().ToArray();
            foreach (var assembly in assemblies)
            {
                if (assembly.GetName().Name == name || assembly.FullName == name)
                {
                    Precache(assembly);
                    return true;
                }

                found = assembly.GetType(name);
                if (found != null)
                {
                    preloaded.Add(found.FullName);
                    Precache(assembly);
                    return true;
                }
            }

            var prefix = name + ".";
            foreach (var assembly in assemblies)
            {
                Type[] types;
                try
                {
                    types = assembly.GetTypes();
                }
                catch (ReflectionTypeLoadException error)
                {
                    types = error.Types;
                }
                catch
                {
                    continue;
                }

                if (types.Any(type =>
                        type != null && type.IsPublic &&
                        type.FullName?.StartsWith(prefix, StringComparison.Ordinal) == true))
                {
                    preloaded.Add(prefix);
                    Precache(assembly);
                    return true;
                }
            }

            return false;
        }

        private void Precache(Assembly assembly)
        {
            preloaded.Add(assembly.GetName().Name);
            preloaded.Add(assembly.FullName);
            PrecacheAssembly?.Invoke(assembly);
        }

        public string TypeName(string name)
        {
            return EverestLuaTypes.FindType(name)?.FullName;
        }

        public string AssemblyName(string name)
        {
            return EverestLuaTypes.FindType(name)?.Assembly.FullName;
        }
    }
}

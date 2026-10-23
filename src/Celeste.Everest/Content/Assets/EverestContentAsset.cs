using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Celeste.Everest.Content.Types.Text;
using Celeste.Everest.Content.Sources;

namespace Celeste.Everest.Content.Assets
{
    public abstract class EverestContentAsset
    {
        public EverestContentSource Source;
        public Type Type;
        public string Format;
        public string PathVirtual;
        public List<EverestContentAsset> Children = new();
        public List<object> Targets = new();

        private readonly global::Celeste.Everest.Content.Registry.EverestContentRegistry contentRegistry;

        protected EverestContentAsset(EverestContentSource source) : this(source.ContentRegistry, source)
        {
        }

        protected EverestContentAsset(global::Celeste.Everest.Content.Registry.EverestContentRegistry contentRegistry,
            EverestContentSource source)
        {
            this.contentRegistry = contentRegistry;
            Source = source;
        }

        public virtual Stream Stream
        {
            get
            {
                Open(out var stream, out _);
                return stream;
            }
        }

        public virtual bool StreamAsync => true;

        public virtual byte[] Data
        {
            get
            {
                using var stream = Stream;
                if (stream is MemoryStream memory) return memory.GetBuffer();
                using var copy = new MemoryStream();
                stream.CopyTo(copy);
                return copy.ToArray();
            }
        }

        protected abstract void Open(out Stream stream, out bool isSection);

        public bool TryDeserialize<T>(out T result)
        {
            if (Type == typeof(AssetTypeYaml))
            {
                try
                {
                    using StreamReader input = new StreamReader(Stream);
                    result = contentRegistry.AssetYaml.Deserializer.Deserialize<T>(input);
                }
                catch
                {
                    result = default(T);
                    return false;
                }

                return true;
            }

            result = default(T);
            return false;
        }

        /// <summary>
        ///       Deserialize the asset using a deserializer based on the AssetType (f.e. AssetTypeYaml -&gt; YamlDotNet).
        ///       </summary>
        /// <typeparam name="T">The target type.</typeparam>
        /// <returns>The asset in its deserialized (object) form or default(T).</returns>
        public T Deserialize<T>()
        {
            TryDeserialize<T>(out var result);
            return result;
        }

        /// <summary>
        ///       Deserialize this asset's matching .meta asset. Uses TryDeserialize internally.
        ///       </summary>
        /// <typeparam name="T">The target meta type.</typeparam>
        /// <param name="meta">The requested meta object.</param>
        /// <returns>True if deserializing the meta asset succeeded, false otherwise.</returns>
        public bool TryGetMeta<T>(out T meta)
        {
            if (contentRegistry.TryGet(PathVirtual + ".meta", out var metadata) && metadata.TryDeserialize<T>(out meta))
            {
                return true;
            }

            meta = default(T);
            return false;
        }

        /// <summary>
        ///       Deserialize this asset's matching .meta asset. Uses TryDeserialize internally.
        ///       </summary>
        /// <typeparam name="T">The target meta type.</typeparam>
        /// <returns>The requested meta object or default(T).</returns>
        public T GetMeta<T>()
        {
            TryGetMeta<T>(out var meta);
            return meta;
        }

        /// <summary>
        ///       Cache the file and return a cached path.
        ///       </summary>
        /// <returns>The cached file path.</returns>
        public virtual string GetCachedPath()
        {
            global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata everestModuleMetadata = Source?.Mod;
            if (everestModuleMetadata == null)
            {
                throw new NullReferenceException("Cannot cache mod-less assets");
            }

            string text = Path.Combine(contentRegistry.AssetLoader.PathCache, everestModuleMetadata.Name,
                PathVirtual.Replace('/', Path.DirectorySeparatorChar));
            string path = text + ".sum";
            byte[] hash = everestModuleMetadata.Hash;
            if (hash == null)
            {
                hash = everestModuleMetadata.Multimeta
                    .First((global::Celeste.Everest.Modules.Runtime.EverestModuleMetadata meta) => meta.Hash != null)
                    .Hash;
            }

            string text2 = global::Celeste.Everest.Modules.Runtime.Assemblies.SourceAssemblyStorageExtensions
                .ToHexadecimalString(hash);
            if (File.Exists(text))
            {
                if (File.Exists(path) && File.ReadAllText(path) == text2)
                {
                    return text;
                }

                File.Delete(path);
                File.Delete(text);
            }

            string directoryName = Path.GetDirectoryName(text);
            if (!Directory.Exists(directoryName))
            {
                Directory.CreateDirectory(directoryName);
            }

            WriteCache(text);
            File.WriteAllText(path, text2);
            return text;
        }

        protected virtual void WriteCache(string path)
        {
            using Stream stream = Stream;
            using Stream destination = File.OpenWrite(path);
            stream.CopyTo(destination);
        }
    }
}

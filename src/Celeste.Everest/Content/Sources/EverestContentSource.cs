using Celeste.Everest.Content.Types.Directories;
using System;
using System.Collections.Generic;
using MAB.DotIgnore;
using Celeste.Everest.Content.Assets;
using Celeste.Everest.Content.Registry;
using Celeste.Everest.Modules.Runtime;

namespace Celeste.Everest.Content.Sources
{
    public abstract class EverestContentSource : IDisposable
    {
        private string name;
        private bool disposed;
        protected readonly EverestContentRegistry Registry;
        internal EverestContentRegistry ContentRegistry => Registry;
        public EverestModuleMetadata Mod;
        public IgnoreList Ignore;
        public readonly List<EverestContentAsset> List = new();
        public readonly Dictionary<string, EverestContentAsset> Map = new();
        public virtual string DefaultName { get; }

        public string Name
        {
            get => string.IsNullOrEmpty(name) ? DefaultName : name;
            set => name = value;
        }

        protected EverestContentSource(EverestContentRegistry registry) => Registry = registry;
        protected abstract void Crawl();
        internal void CrawlCore() => Crawl();

        protected virtual void Add(string path, EverestContentAsset asset)
        {
            if (Registry.TryAdd(path, asset))
            {
                List.Add(asset);
                Map[asset.PathVirtual] = asset;
            }
        }

        protected virtual void Update(string path, EverestContentAsset next)
        {
            if (next == null)
            {
                Update(Registry.Get<AssetTypeDirectory>(path), null);
                return;
            }

            next.PathVirtual = path;
            Update((EverestContentAsset)null, next);
        }

        protected virtual void Update(EverestContentAsset prev, EverestContentAsset next)
        {
            if (prev != null)
            {
                int num = List.IndexOf(prev);
                EverestContentAsset[] array;
                if (next == null)
                {
                    Map.Remove(prev.PathVirtual);
                    if (num != -1)
                    {
                        List.RemoveAt(num);
                    }

                    Registry.Update(prev, null);
                    array = prev.Children.ToArray();
                    foreach (EverestContentAsset modAsset in array)
                    {
                        if (modAsset.Source == this)
                        {
                            Update(modAsset, null);
                        }
                    }

                    return;
                }

                Map[prev.PathVirtual] = next;
                if (num != -1)
                {
                    List[num] = next;
                }
                else
                {
                    List.Add(next);
                }

                next.PathVirtual = prev.PathVirtual;
                next.Type = prev.Type;
                next.Format = prev.Format;
                Registry.Update(prev, next);
                array = prev.Children.ToArray();
                foreach (EverestContentAsset modAsset2 in array)
                {
                    if (modAsset2.Source == this)
                    {
                        Update(modAsset2, null);
                    }
                }

                array = next.Children.ToArray();
                foreach (EverestContentAsset modAsset3 in array)
                {
                    if (modAsset3.Source == this)
                    {
                        Update((EverestContentAsset)null, modAsset3);
                    }
                }
            }
            else
            {
                if (next == null)
                {
                    return;
                }

                Map[next.PathVirtual] = next;
                List.Add(next);
                Registry.Update(null, next);
                EverestContentAsset[] array = next.Children.ToArray();
                foreach (EverestContentAsset modAsset4 in array)
                {
                    if (modAsset4.Source == this)
                    {
                        Update((EverestContentAsset)null, modAsset4);
                    }
                }
            }
        }

        ~EverestContentSource()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(false);
            }
        }

        public void Dispose()
        {
            if (!disposed)
            {
                disposed = true;
                Dispose(true);
                GC.SuppressFinalize(this);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }
    }
}

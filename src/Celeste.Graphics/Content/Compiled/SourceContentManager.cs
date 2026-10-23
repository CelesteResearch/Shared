using System;
using System.Collections.Generic;
using Celeste.Core.Framework.Graphics;
using Celeste.Graphics.Rendering.Effects;
using Celeste.Graphics.Rendering.Devices;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager : IDisposable
    {
        private SourceGraphicsDevice graphicsDevice;

        private Dictionary<string, object> loadedAssets =
            new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        private List<IDisposable> disposableAssets = new List<IDisposable>();
        private bool disposed;
        private readonly SourceContentProcessState process;
        internal SourceContentProcessState Process => process;
        public IServiceProvider ServiceProvider { get; private set; }
        public string RootDirectory { get; set; }

        public SourceContentManager(IServiceProvider serviceProvider, SourceContentProcessState process)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            this.process = process;
            ServiceProvider = serviceProvider;
            RootDirectory = string.Empty;
            process.AddContentManager(this);
        }

        public SourceContentManager(IServiceProvider serviceProvider, string rootDirectory,
            SourceContentProcessState process)
        {
            if (serviceProvider == null)
            {
                throw new ArgumentNullException("serviceProvider");
            }

            if (rootDirectory == null)
            {
                throw new ArgumentNullException("rootDirectory");
            }

            this.process = process;
            ServiceProvider = serviceProvider;
            RootDirectory = rootDirectory;
            process.AddContentManager(this);
        }

        ~SourceContentManager()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
            process.RemoveContentManager(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    Unload();
                }

                disposed = true;
            }
        }

        public virtual T Load<T>(string assetName)
        {
            if (string.IsNullOrEmpty(assetName))
            {
                throw new ArgumentNullException("assetName");
            }

            if (disposed)
            {
                throw new ObjectDisposedException("ContentManager");
            }

            T val = default(T);
            string key = assetName.Replace('\\', '/');
            object value = null;
            if (loadedAssets.TryGetValue(key, out value) && value is T)
            {
                return (T)value;
            }

            val = ReadAsset<T>(assetName, null);
            loadedAssets[key] = val;
            return val;
        }

        public virtual void Unload()
        {
            foreach (IDisposable disposableAsset in disposableAssets)
            {
                disposableAsset?.Dispose();
            }

            disposableAssets.Clear();
            loadedAssets.Clear();
        }


        internal void RecordDisposable(IDisposable disposable)
        {
            if (!disposableAssets.Contains(disposable)) disposableAssets.Add(disposable);
        }

        internal SourceGraphicsDevice GetGraphicsDevice()
        {
            if (graphicsDevice == null)
            {
                if (!(ServiceProvider.GetService(typeof(ISourceGraphicsDeviceService)) is ISourceGraphicsDeviceService
                        service))
                    throw new SourceContentLoadException("No Graphics Device Service");
                graphicsDevice = (SourceGraphicsDevice)service.GraphicsDevice;
            }

            return graphicsDevice;
        }
    }
}

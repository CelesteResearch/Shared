using System;
using System.Collections.Generic;
using Celeste.Core.Framework.Graphics;
using Celeste.Graphics.Rendering.Devices;
using JetBrains.Annotations;

namespace Celeste.Graphics.Content.Compiled
{
    public partial class SourceContentManager : IDisposable
    {
        private SourceGraphicsDevice graphicsDevice;

        private readonly Dictionary<string, object> loadedAssets = new(StringComparer.OrdinalIgnoreCase);

        private readonly List<IDisposable> disposableAssets = [];
        private bool disposed;

        [UsedImplicitly(ImplicitUseKindFlags.Access)]
        private readonly SourceContentProcessState process;

        internal SourceContentProcessState Process => process;

        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IServiceProvider ServiceProvider { get; private set; }
        public string RootDirectory { get; set; }

        public SourceContentManager(IServiceProvider serviceProvider, SourceContentProcessState process)
        {
            if (serviceProvider == null) throw new ArgumentNullException("serviceProvider");

            this.process = process;
            ServiceProvider = serviceProvider;
            RootDirectory = string.Empty;
            process.AddContentManager(this);
        }

        public SourceContentManager(IServiceProvider serviceProvider, string rootDirectory,
            SourceContentProcessState process)
        {
            if (serviceProvider == null) throw new ArgumentNullException("serviceProvider");

            if (rootDirectory == null) throw new ArgumentNullException("rootDirectory");

            this.process = process;
            ServiceProvider = serviceProvider;
            RootDirectory = rootDirectory;
            process.AddContentManager(this);
        }

        ~SourceContentManager()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
            process.RemoveContentManager(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) Unload();

                disposed = true;
            }
        }

        public virtual T Load<T>(string assetName)
        {
            if (string.IsNullOrEmpty(assetName)) throw new ArgumentNullException("assetName");

            if (disposed) throw new ObjectDisposedException("ContentManager");

            var val = default(T);
            var key = assetName.Replace('\\', '/');
            object value = null;
            if (loadedAssets.TryGetValue(key, out value) && value is T) return (T)value;

            val = ReadAsset<T>(assetName, null);
            loadedAssets[key] = val;
            return val;
        }

        public virtual void Unload()
        {
            foreach (var disposableAsset in disposableAssets) disposableAsset?.Dispose();

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
                if (ServiceProvider.GetService(typeof(ISourceGraphicsDeviceService)) is not ISourceGraphicsDeviceService
                    service)
                    throw new SourceContentLoadException("No Graphics Device Service");
                graphicsDevice = (SourceGraphicsDevice)service.GraphicsDevice;
            }

            return graphicsDevice;
        }
    }
}

using Celeste.Everest.Content.Registry;
using Celeste.Graphics.Content.Compiled;

namespace Celeste.Everest.Content.Compiled
{
    internal class SourceEverestContentManager : SourceContentManager
    {
        private readonly SourceContentManager Inner;
        private readonly EverestContentRegistry registry;

        internal SourceEverestContentManager(SourceContentManager inner,
            SourceContentProcessState process, EverestContentRegistry registry) : base(inner.ServiceProvider, process)
        {
            Inner = inner;
            this.registry = registry;
            RootDirectory = inner.RootDirectory;
        }

        public override T Load<T>(string assetName)
        {
            if (registry.Get(assetName) != null)
                return base.Load<T>(assetName);
            var value = Inner.Load<T>(assetName);
            registry.ProcessLoad(value, assetName);
            return value;
        }

        public override void Unload()
        {
            Inner.Unload();
            base.Unload();
        }

        protected override void Dispose(bool disposing)
        {
            Inner.Dispose();
            base.Dispose(disposing);
        }
    }
}

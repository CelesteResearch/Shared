using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking.Initialization
{
    internal sealed class ManagedSceneAssemblyMetadata : ISourceAssemblyMetadata
    {
        private readonly ISourceTypeMetadata[] types;
        public string Identity { get; }

        public ManagedSceneAssemblyMetadata(string identity, ISourceTypeMetadata[] types)
        {
            Identity = identity;
            this.types = types;
        }

        public ISourceTypeMetadata[] GetTypes() => (ISourceTypeMetadata[])types.Clone();
    }
}

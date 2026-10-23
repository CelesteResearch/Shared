using Celeste.Core.Reflection;

namespace Celeste.Scene.Tracking.Initialization
{
    internal sealed class ManagedSceneAssemblyMetadata : ISourceAssemblyMetadata
    {
        private readonly ISourceTypeMetadata[] _types;
        public string Identity { get; }

        // ReSharper disable once ConvertToPrimaryConstructor
        public ManagedSceneAssemblyMetadata(string identity, ISourceTypeMetadata[] types)
        {
            Identity = identity;
            _types = types;
        }

        public ISourceTypeMetadata[] GetTypes()
        {
            return (ISourceTypeMetadata[])_types.Clone();
        }
    }
}

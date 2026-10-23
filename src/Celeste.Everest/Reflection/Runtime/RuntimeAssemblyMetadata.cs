using System.Reflection;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeAssemblyMetadata : ISourceAssemblyMetadata
    {
        private ISourceTypeMetadata[] types = [];
        public string Identity { get; }

        // ReSharper disable once ConvertToPrimaryConstructor
        public RuntimeAssemblyMetadata(Assembly assembly)
        {
            Identity = assembly.FullName;
        }

        internal void PublishTypes(ISourceTypeMetadata[] value)
        {
            types = value;
        }

        public ISourceTypeMetadata[] GetTypes()
        {
            return (ISourceTypeMetadata[])types.Clone();
        }
    }
}

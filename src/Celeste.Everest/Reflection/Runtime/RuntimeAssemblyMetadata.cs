using System;
using System.Reflection;
using Celeste.Core.Reflection;

namespace Celeste.Everest.Reflection.Runtime
{
    internal sealed class RuntimeAssemblyMetadata : ISourceAssemblyMetadata
    {
        private ISourceTypeMetadata[] types = Array.Empty<ISourceTypeMetadata>();
        public string Identity { get; }

        public RuntimeAssemblyMetadata(Assembly assembly)
        {
            Identity = assembly.FullName;
        }

        internal void PublishTypes(ISourceTypeMetadata[] value) => types = value;
        public ISourceTypeMetadata[] GetTypes() => (ISourceTypeMetadata[])types.Clone();
    }
}

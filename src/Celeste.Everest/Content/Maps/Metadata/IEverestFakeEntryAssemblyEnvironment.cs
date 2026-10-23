using Celeste.Core.Reflection.Assemblies;

namespace Celeste.Everest.Content.Maps.Metadata
{
// Required actual installed FakeAssembly owner; no executing-assembly fallback.
    public interface IEverestFakeEntryAssemblyEnvironment
    {
        SourceLogicalAggregateAssembly FakeEntryAssembly { get; }
    }
}

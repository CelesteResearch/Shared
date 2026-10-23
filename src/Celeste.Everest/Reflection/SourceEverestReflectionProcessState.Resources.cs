using Celeste.Core.Reflection.Resources;

namespace Celeste.Everest.Reflection
{
    public sealed partial class SourceEverestReflectionProcessState
    {
        public SourceAssemblyResourceCatalog SourceResources { get; } = new();
    }
}

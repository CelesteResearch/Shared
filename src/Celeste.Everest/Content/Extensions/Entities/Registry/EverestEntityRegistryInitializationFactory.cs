using Celeste.Everest.Reflection;
using Celeste.Core.Threading;

namespace Celeste.Everest.Content.Extensions.Entities.Registry
{
    public sealed class EverestEntityRegistryInitializationFactory
        : ISourceTypeInitializationFactory<EverestEntityRegistryProcess>
    {
        private readonly IEverestEntityRegistryTypeSource sourceTypes;
        private readonly SourceEverestReflectionProcessState reflection;

        public EverestEntityRegistryInitializationFactory(IEverestEntityRegistryTypeSource sourceTypes,
            SourceEverestReflectionProcessState reflection)
        {
            this.sourceTypes = sourceTypes;
            this.reflection = reflection;
        }

        public EverestEntityRegistryProcess Allocate() => new(reflection);

        public void Initialize(EverestEntityRegistryProcess instance)
            => instance.InitializeBuiltInTypes(sourceTypes);
    }
}

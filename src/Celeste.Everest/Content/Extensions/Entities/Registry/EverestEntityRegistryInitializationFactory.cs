using Celeste.Core.Threading;
using Celeste.Everest.Reflection;

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

        public EverestEntityRegistryProcess Allocate()
        {
            return new(reflection);
        }

        public void Initialize(EverestEntityRegistryProcess instance)
        {
            instance.InitializeBuiltInTypes(sourceTypes);
        }
    }
}

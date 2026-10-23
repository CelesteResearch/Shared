using Celeste.Core.Threading;
using Celeste.Everest.Content.Maps.Metadata;

namespace Celeste.Everest.Content.Maps.Registry
{
    public sealed class
        InstalledAreaSourceStaticsInitializationFactory : ISourceTypeInitializationFactory<InstalledAreaSourceStatics>
    {
        private readonly IEverestFakeEntryAssemblyEnvironment process;

        public InstalledAreaSourceStaticsInitializationFactory(IEverestFakeEntryAssemblyEnvironment process)
            => this.process = process;

        public InstalledAreaSourceStatics Allocate() => new InstalledAreaSourceStatics();

        public void Initialize(InstalledAreaSourceStatics instance) =>
            instance.InitializeInstalledSourceStatics(process);
    }
}

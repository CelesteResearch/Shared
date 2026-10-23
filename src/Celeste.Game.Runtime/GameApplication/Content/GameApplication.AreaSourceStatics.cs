using System;
using Celeste.Core.Threading;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Content.Maps.Registry;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestMapWipeEnvironment
    {
        private SourceTypeInitialization<InstalledAreaSourceStatics>? sourceInstalledAreaStatics;

        private SourceTypeInitialization<InstalledAreaSourceStatics> InstalledAreaStaticsDescriptor
            => sourceInstalledAreaStatics ??
               throw new InvalidOperationException(
                   "The actual installed AreaData static descriptor is not constructed.");

        public InstalledAreaSourceStatics InstalledAreaStatics => InstalledAreaStaticsDescriptor.Value;
        public EverestMapWipeProcess MapWipes => InstalledAreaStatics.MapWipes;

        public void ConstructSourceInstalledAreaStaticTypeOwner()
        {
            if (sourceInstalledAreaStatics != null)
                throw new InvalidOperationException(
                    "The actual installed AreaData static descriptor is already constructed.");
            sourceInstalledAreaStatics = new SourceTypeInitialization<InstalledAreaSourceStatics>(
                "Celeste.AreaData", new InstalledAreaSourceStaticsInitializationFactory(this));
        }
    }
}

using System;
using Celeste.Core.Reflection.Assemblies;
using Celeste.Core.Threading;
using Celeste.Everest.Content.Maps.Backdrops;
using Celeste.Everest.Content.Maps.Metadata;
using Celeste.Everest.Entities.Triggers.Events;
using Celeste.Everest.Modules.Updating;
using Celeste.Everest.Runtime.Levels.Loading.Entities;
using Celeste.Game.Content.Maps.Backdrops;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestAssemblyRegistriesEnvironment,
        IEverestFakeEntryAssemblyEnvironment, IOriginalBackdropLoadEnvironment
    {
        private SourceTypeInitialization<EverestBackdropLoaders> sourceBackdropLoaders;
        private EverestBackdropLoadPolicy sourceBackdropLoadPolicy;

        public EverestBackdropLoaders Backdrops => (sourceBackdropLoaders ??
                                                    throw new InvalidOperationException(
                                                        "The installed MapData backdrop loader type owner is not constructed."))
            .Value;

        public IOriginalBackdropLoadPolicy BackdropLoadPolicy => sourceBackdropLoadPolicy ??=
            new EverestBackdropLoadPolicy(this, LevelUpdateEvents, Backdrops);

        SourceLogicalAggregateAssembly IEverestFakeEntryAssemblyEnvironment.FakeEntryAssembly
            => Reflection.GetFakeEntryAssembly();

        EverestLevelEntityLoadProcess IEverestAssemblyRegistriesEnvironment.EntityLoaders => EntityLoadProcess;

        EverestEventTriggerRuntimePolicy IEverestAssemblyRegistriesEnvironment.EventTriggers
            => (EverestEventTriggerRuntimePolicy)EventTriggers;

        EverestMapWipeProcess IEverestAssemblyRegistriesEnvironment.Wipes => MapWipes;

        internal void ConstructSourceInstalledBackdropLoadTypeOwner()
        {
            if (SourceProfile != GameProfile.InstalledEverest || sourceBackdropLoaders != null)
                throw new InvalidOperationException(
                    "The installed MapData backdrop loader type owner requires one installed birth.");
            sourceBackdropLoaders = new SourceTypeInitialization<EverestBackdropLoaders>(
                "Celeste.MapData", new EverestBackdropLoadInitializationFactory());
        }
    }
}

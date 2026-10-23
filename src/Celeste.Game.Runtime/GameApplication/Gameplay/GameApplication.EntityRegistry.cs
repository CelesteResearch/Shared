using System;
using Celeste.Core.Components;
using Celeste.Core.Threading;
using Celeste.Everest.Content.Extensions.Entities.Registry;
using Celeste.Game.Entities.Metadata;
using Celeste.Game.Profiles;

namespace Celeste.Game.Runtime
{
    public sealed partial class GameApplication : IEverestEntityRegistryEnvironment,
        IEverestEntityRegistryTypeSource, ISourceEntitySourceDataEnvironment
    {
        private SourceTypeInitialization<EverestEntityRegistryProcess> sourceEntityRegistry;
        private ISourceEntitySourceDataRegistration sourceEntitySourceDataRegistration;

        public EverestEntityRegistryProcess EntityRegistry => (sourceEntityRegistry ??
                                                               throw new InvalidOperationException(
                                                                   "The actual installed entity registry descriptor is not constructed."))
            .Value;

        public ISourceEntitySourceDataRegistration EntitySourceDataRegistration => sourceEntitySourceDataRegistration ??
            throw new InvalidOperationException(
                "The selected entity source data registration is not constructed.");

        Type IEverestEntityRegistryTypeSource.ResolveSourceType(string sourceFullName)
            => SourceMembers.GetActualSourceType("Celeste, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null",
                sourceFullName);

        public void ConstructSourceInstalledEntityRegistry()
        {
            if (sourceEntityRegistry != null)
                throw new InvalidOperationException(
                    "The actual installed entity registry descriptor is already constructed.");
            sourceEntityRegistry = new SourceTypeInitialization<EverestEntityRegistryProcess>(
                "Celeste.Mod.Registry.EntityRegistry",
                new EverestEntityRegistryInitializationFactory(this, Reflection));
        }

        public void ConstructSourceEntitySourceDataRegistration()
        {
            if (sourceEntitySourceDataRegistration != null)
                throw new InvalidOperationException(
                    "The selected entity source data registration is already constructed.");
            sourceEntitySourceDataRegistration = SourceProfile == GameProfile.Original
                ? (ISourceEntitySourceDataRegistration)new OriginalEntitySourceDataRegistration()
                : new EverestEntitySourceDataRegistration(this);
        }
    }
}

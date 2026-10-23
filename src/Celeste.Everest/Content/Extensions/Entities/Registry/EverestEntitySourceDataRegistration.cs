using Celeste.Core.Components;
using Celeste.Game.Content.Maps.Entities;

namespace Celeste.Everest.Content.Extensions.Entities.Registry
{
    public sealed class EverestEntitySourceDataRegistration : ISourceEntitySourceDataRegistration
    {
        private readonly IEverestEntityRegistryEnvironment environment;

        public EverestEntitySourceDataRegistration(IEverestEntityRegistryEnvironment environment)
        {
            this.environment = environment;
        }

        public void Register(object actualActor, object actualSourceData)
        {
            if (actualSourceData == null ||
                ReferenceEquals(actualSourceData, ((ISourceEntitySourceData)actualActor).SourceData))
                return;
            var sid = ((OriginalLevelEntityData)actualSourceData).Name;
            var type = actualActor.GetType();
            environment.EntityRegistry.RegisterSidToTypeConnection(sid, type);
        }
    }
}

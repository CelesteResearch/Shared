using Celeste.Core.Components;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestEntityAddMetadata : ISourceEntityAddMetadata
    {
        private readonly IEverestLevelEntityLoadProcessEnvironment environment;

        // ReSharper disable once ConvertToPrimaryConstructor
        public EverestEntityAddMetadata(IEverestLevelEntityLoadProcessEnvironment environment)
        {
            this.environment = environment;
        }

        public void Handle(ISourceEntitySourceData actualEntity)
        {
            var current = environment.EntityLoadProcess.Current;
            var currentEntityData = current.CurrentEntityData;
            if (currentEntityData == null || actualEntity.SourceData != null) return;
            actualEntity.SourceData = currentEntityData;
            actualEntity.SourceId = current.CurrentEntityId;
        }
    }
}

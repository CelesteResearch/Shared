using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelEntityLoadThreadState
    {
        public bool IsLoadingTriggers;
        public OriginalLevelEntityData CurrentEntityData;
        public MapEntityId CurrentEntityId;
    }
}

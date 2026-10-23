using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.Levels.Loading.Entities
{
// Original Level.LoadLevel has no Installed custom-entity dispatch or thread fields.
    public sealed class OriginalLevelMapLoadPolicy : IOriginalLevelMapLoadPolicy
    {
        public bool LoadBeforeOriginalDispatch(OriginalLevelSceneRoot level, OriginalLevelEntityData record,
            MapEntityId id) => false;

        public MapEntityId CreateEntityId(OriginalLevelRoomData room, OriginalLevelEntityData record)
            => new MapEntityId(room.Name, record.ID);

        public void AfterEntities()
        {
        }

        public void BeforeTriggers()
        {
        }

        public void AfterTriggers()
        {
        }

        public bool IsInDoNotLoadIncreased(OriginalLevelSceneRoot level, OriginalLevelRoomData room,
            OriginalLevelEntityData record) => false;
    }
}

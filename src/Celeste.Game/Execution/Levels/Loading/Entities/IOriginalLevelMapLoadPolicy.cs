using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;

namespace Celeste.Game.Execution.Levels.Loading.Entities
{
    public interface IOriginalLevelMapLoadPolicy
    {
        bool LoadBeforeOriginalDispatch(OriginalLevelSceneRoot level, OriginalLevelEntityData record, MapEntityId id);
        MapEntityId CreateEntityId(OriginalLevelRoomData room, OriginalLevelEntityData record);
        void AfterEntities();
        void BeforeTriggers();
        void AfterTriggers();

        bool IsInDoNotLoadIncreased(OriginalLevelSceneRoot level, OriginalLevelRoomData room,
            OriginalLevelEntityData record);
    }
}

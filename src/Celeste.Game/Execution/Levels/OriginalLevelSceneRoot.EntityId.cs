using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels.Loading.Entities;

namespace Celeste.Game.Execution.Levels
{
    public partial class OriginalLevelSceneRoot
    {
        public MapEntityId CreateEntityId(OriginalLevelRoomData levelData, OriginalLevelEntityData entityData)
        {
            return ((IOriginalLevelMapLoadEnvironment)EngineContext).LevelMapLoadPolicy.CreateEntityId(levelData,
                entityData);
        }
    }
}

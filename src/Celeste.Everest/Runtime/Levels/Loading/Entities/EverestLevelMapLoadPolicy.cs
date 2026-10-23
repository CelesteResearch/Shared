using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Core.Scheduling;
using Celeste.Game.Execution.Levels.Loading.Entities;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelMapLoadPolicy : IOriginalLevelMapLoadPolicy
    {
        private readonly ISourceEngineContext engine;

        private EverestLevelEntityLoadThreadState State =>
            ((IEverestLevelEntityLoadThreadEnvironment)engine).CurrentEntityLoadState;

        public EverestLevelMapLoadPolicy(ISourceEngineContext engine) => this.engine = engine;

        public bool LoadBeforeOriginalDispatch(OriginalLevelSceneRoot level, OriginalLevelEntityData record,
            MapEntityId id)
        {
            State.CurrentEntityData = record;
            State.CurrentEntityId = id;
            return ((IEverestLevelCustomEntityLoaderEnvironment)engine).CustomEntities.LoadCustomEntity(record, level);
        }

        public MapEntityId CreateEntityId(OriginalLevelRoomData room, OriginalLevelEntityData record)
            => new MapEntityId(room.Name, record.ID + (State.IsLoadingTriggers ? 10000000 : 0));

        public void AfterEntities() => State.CurrentEntityData = null;
        public void BeforeTriggers() => State.IsLoadingTriggers = true;

        public void AfterTriggers()
        {
            State.CurrentEntityData = null;
            State.IsLoadingTriggers = false;
        }

        public bool IsInDoNotLoadIncreased(OriginalLevelSceneRoot level, OriginalLevelRoomData room,
            OriginalLevelEntityData record)
            => level.Session.DoNotLoad.Contains(new MapEntityId(room.Name, record.ID + 20000000));
    }
}

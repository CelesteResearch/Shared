using System;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Everest.Runtime.Levels.Update;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;

namespace Celeste.Everest.Runtime.Levels.Loading.Entities
{
    public sealed class EverestLevelCustomEntityLoader
    {
        private readonly IEverestLevelEntityLoadProcessEnvironment environment;
        private readonly EverestLevelUpdateEvents events;
        private readonly EverestLevelEntityOverrides overrides;
        private readonly EverestLevelEntityLoadWarnings warnings;

        public EverestLevelCustomEntityLoader(IEverestLevelEntityLoadProcessEnvironment environment,
            EverestLevelUpdateEvents events, EverestLevelEntityOverrides overrides,
            EverestLevelEntityLoadWarnings warnings)
        {
            this.environment = environment ?? throw new ArgumentNullException(nameof(environment));
            this.events = events ?? throw new ArgumentNullException(nameof(events));
            this.overrides = overrides ?? throw new ArgumentNullException(nameof(overrides));
            this.warnings = warnings ?? throw new ArgumentNullException(nameof(warnings));
        }

        public bool LoadCustomEntity(OriginalLevelEntityData record, OriginalLevelSceneRoot level)
        {
            var room = (OriginalLevelRoomData)level.Session.LevelData;
            var offset = new Vector2(room.Bounds.Left, room.Bounds.Top);
            var previous = environment.EntityLoadProcess.Current.CurrentEntityData;
            environment.EntityLoadProcess.Current.CurrentEntityData = record;
            if (events.LoadEntity(level, room, offset, record))
                return true;
            environment.EntityLoadProcess.Current.CurrentEntityData = null;

            SceneEntityState entity = null;
            if (environment.EntityLoadProcess.EntityLoaders.TryGetValue(record.Name, out var loader))
                entity = loader(level, room, offset, record);
            if (entity == null)
                entity = overrides.Create(level, record, offset);
            if (entity != null)
            {
                var metadata = (ISourceEntitySourceData)entity;
                if (metadata.SourceData == null)
                    metadata.SourceData = record;
                if (metadata.SourceId.Level == null)
                    metadata.SourceId = level.CreateEntityId(room, record);
                level.Scheduler.QueueSourceEntity(entity);
            }
            else if (!environment.EntityLoadProcess.IsOriginalLoadString(record.Name))
            {
                warnings.WarnUnknownEntity(record);
            }

            environment.EntityLoadProcess.Current.CurrentEntityData = previous;
            return entity != null;
        }
    }
}

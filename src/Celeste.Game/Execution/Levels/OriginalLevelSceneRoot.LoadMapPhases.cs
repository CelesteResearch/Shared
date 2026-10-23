using System;
using System.Collections.Generic;
using System.Numerics;
using Celeste.Core.Maps;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels.Loading.Entities;
using Celeste.Game.Entities.Decoration.Decals;
using Celeste.Game.Gameplay.Clutter.Generation;
using Celeste.Simulation.Gameplay.Player.Intro;
using Celeste.Simulation;

namespace Celeste.Game.Execution.Levels
{
    public sealed partial class OriginalLevelSceneRoot
    {
        private OriginalDecalFactory sourceDecalFactory;

        public void BindSourceDecalFactory(OriginalDecalFactory factory)
        {
            if (sourceDecalFactory != null)
                throw new InvalidOperationException("The source decal factory is already bound.");
            sourceDecalFactory = factory ?? throw new ArgumentNullException(nameof(factory));
        }

        private void LoadSourceRoomMapPhases(OriginalLevelRoomData room, Vector2 offset,
            bool checkpointsEnabled, out Vector2? checkpointStart, out bool hasRoomLightning)
        {
            var diagnostics = global::Celeste.Core.Framework.Timing.SourceFrameDiagnostics.Current;
            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapEntity);
            var loadPolicy = ((IOriginalLevelMapLoadEnvironment)EngineContext).LevelMapLoadPolicy;
            checkpointStart = null;
            hasRoomLightning = false;
            bool firstCassetteSeen = false;
            int darkChaserIndex = 0;
            var retainedFollowerIds = new List<MapEntityId>();
            var player =
                Scheduler.Entities.GetTrackedEntity<RoomPlayerSession>(
                    typeof(global::Celeste.Simulation.RoomPlayerSession)
                        .FullName);
            if (player != null)
                foreach (var follower in player.Leader.Followers)
                    retainedFollowerIds.Add(follower.ParentEntityID);

            foreach (var record in room.Entities)
            {
                var id = new MapEntityId(room.Name, record.ID);
                if (Session.DoNotLoad.Contains(id) || retainedFollowerIds.Contains(id))
                    continue;
                if (loadPolicy.LoadBeforeOriginalDispatch(this, record, id))
                    continue;
                LoadSourceMapEntity(record, offset, id, checkpointsEnabled,
                    ref checkpointStart, ref firstCassetteSeen, ref darkChaserIndex, ref hasRoomLightning);
            }

            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapRemainder);
            loadPolicy.AfterEntities();
            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapClutter);
            ((ISourceClutterGeneratorEnvironment)EngineContext).ClutterGenerator.Generate();
            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapTriggers);
            loadPolicy.BeforeTriggers();

            foreach (var record in room.Triggers)
            {
                var id = new MapEntityId(room.Name, record.ID + 10000000);
                if (Session.DoNotLoad.Contains(id) || loadPolicy.IsInDoNotLoadIncreased(this, room, record))
                    continue;
                if (loadPolicy.LoadBeforeOriginalDispatch(this, record, id))
                    continue;
                LoadSourceMapTrigger(record, offset, id);
            }

            loadPolicy.AfterTriggers();

            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapDecals);
            foreach (var placement in room.FgDecals)
            {
                var decal = sourceDecalFactory.Create(placement, offset, -10500);
                decal.PresentationRoom = room.Name;
                Scheduler.QueueSourceEntity(decal);
            }

            foreach (var placement in room.BgDecals)
            {
                var decal = sourceDecalFactory.Create(placement, offset, 9000);
                decal.PresentationRoom = room.Name;
                Scheduler.QueueSourceEntity(decal);
            }

            diagnostics?.ChangeLevelLoadPhase(global::Celeste.Core.Framework.Timing.SourceLevelLoadPhase.MapRemainder);
        }
    }
}

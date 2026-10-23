using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Everest.Stories.Dialogue;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Execution.Levels;
using Celeste.Scene.Entities;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;

namespace Celeste.Everest.Gameplay.Triggers.Dialogue
{
    [CustomEntity("everest/dialogTrigger", "dialog/dialogtrigger", "cavern/dialogtrigger")]
    public class EverestDialogCutsceneTriggerState : SourceTriggerEntityState
    {
        private readonly string dialogEntry;

        private bool triggered;

        private readonly MapEntityId id;

        private readonly bool onlyOnce;

        private readonly bool endLevel;

        private readonly int deathCount;

        public EverestDialogCutsceneTriggerState(EntityData data, Vector2 offset, MapEntityId entId,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            dialogEntry = data.Attr("dialogId");
            onlyOnce = data.Bool("onlyOnce", true);
            endLevel = data.Bool("endLevel");
            deathCount = data.Int("deathCount", -1);
            triggered = false;
            id = entId;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            if (triggered) return;

            var session = (Scene as OriginalLevelSceneRoot).Session;
            var entityId = id;
            if (!session.GetFlag("DoNotLoad" + entityId) && (deathCount < 0 ||
                                                             ((OriginalLevelSceneRoot)Scene).Session
                                                             .DeathsInCurrentLevel == deathCount))
            {
                triggered = true;
                var level = (OriginalLevelSceneRoot)Scene;
                level.SourceScene.QueueSourceEntity(
                    new EverestDialogCutsceneState(dialogEntry, player,
                        endLevel,
                        level.EngineContext));
                if (onlyOnce)
                {
                    var session2 = (Scene as OriginalLevelSceneRoot).Session;
                    entityId = id;
                    session2.SetFlag("DoNotLoad" + entityId);
                }
            }
        }

        // Physical construction adapter; identity comes from the same source Level policy.
        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData entityData)
        {
            return new EverestDialogCutsceneTriggerState(entityData, offset,
                level.CreateEntityId(levelData, entityData),
                level.EngineContext);
        }
    }
}

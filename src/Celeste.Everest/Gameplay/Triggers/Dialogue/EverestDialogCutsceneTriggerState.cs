using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using System.Text.RegularExpressions;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Maps;
using Celeste.Core.Mathematics.Extrema;
using Celeste.Core.Rendering;
using Celeste.Core.Scheduling;
using Celeste.Everest.Modules.Entities.Metadata;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Maps.Entities;
using Celeste.Game.Content.Maps.Levels;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Gameplay.Triggers.Foundation;
using Celeste.Simulation.Runtime.Session;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;

namespace Celeste.Everest.Gameplay.Triggers.Dialogue
{
    [CustomEntity(new string[] { "everest/dialogTrigger", "dialog/dialogtrigger", "cavern/dialogtrigger" })]
    public class EverestDialogCutsceneTriggerState : SourceTriggerEntityState
    {
        private string dialogEntry;

        private bool triggered;

        private MapEntityId id;

        private bool onlyOnce;

        private bool endLevel;

        private int deathCount;

        public EverestDialogCutsceneTriggerState(EntityData data, Vector2 offset, MapEntityId entId,
            ISourceEngineContext engine)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, data.Position + offset,
                data.Width, data.Height, ((ISourceExtremaEnvironment)engine).ExtremaArithmetic)
        {
            dialogEntry = data.Attr("dialogId");
            onlyOnce = data.Bool("onlyOnce", defaultValue: true);
            endLevel = data.Bool("endLevel");
            deathCount = data.Int("deathCount", -1);
            triggered = false;
            id = entId;
        }

        public override void OnEnter(RoomPlayerSession player)
        {
            if (triggered)
            {
                return;
            }

            ChapterCompletionSession session = (base.Scene as OriginalLevelSceneRoot).Session;
            MapEntityId entityID = id;
            if (!session.GetFlag("DoNotLoad" + entityID.ToString()) && (deathCount < 0 ||
                                                                        ((OriginalLevelSceneRoot)base.Scene).Session
                                                                        .DeathsInCurrentLevel == deathCount))
            {
                triggered = true;
                var level = (OriginalLevelSceneRoot)base.Scene;
                level.SourceScene.QueueSourceEntity(
                    new global::Celeste.Everest.Stories.Dialogue.EverestDialogCutsceneState(dialogEntry, player,
                        endLevel,
                        level.EngineContext));
                if (onlyOnce)
                {
                    ChapterCompletionSession session2 = (base.Scene as OriginalLevelSceneRoot).Session;
                    entityID = id;
                    session2.SetFlag("DoNotLoad" + entityID.ToString());
                }
            }
        }

        // Physical construction adapter; identity comes from the same source Level policy.
        public static SceneEntityState Load(OriginalLevelSceneRoot level, OriginalLevelRoomData levelData,
            Vector2 offset, OriginalLevelEntityData entityData)
            => new EverestDialogCutsceneTriggerState(entityData, offset, level.CreateEntityId(levelData, entityData),
                level.EngineContext);
    }
}

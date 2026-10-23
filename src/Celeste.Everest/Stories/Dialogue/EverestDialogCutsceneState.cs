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

namespace Celeste.Everest.Stories.Dialogue
{
    public class EverestDialogCutsceneState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private RoomPlayerSession player;

        private string dialogID;

        private bool endLevel;

        public EverestDialogCutsceneState(string dialogID, RoomPlayerSession player, bool endLevel,
            ISourceEngineContext engine)
            : base(engine)
        {
            this.engine = engine;
            this.dialogID = dialogID;
            this.player = player;
            this.endLevel = endLevel;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            if (endLevel)
            {
                level.RegisterAreaComplete();
            }

            OwnedComponents.Add(new SimulationCoroutine(engine, Cutscene(level)));
        }

        private IEnumerator Cutscene(OriginalLevelSceneRoot level)
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            player.ForceCameraUpdate = true;
            yield return TextboxState.Say(dialogID, engine);
            EndCutscene(level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
            player.ForceCameraUpdate = false;
            if (WasSkipped)
            {
                level.Camera.Position = player.CameraTarget;
            }

            if (endLevel)
            {
                level.CompleteArea();
                player.Machine.State = 11;
                RemoveSelf();
            }
        }
    }
}

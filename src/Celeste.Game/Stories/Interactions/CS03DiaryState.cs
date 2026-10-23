using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Numerics;
using Celeste.Core.Audio;
using Celeste.Core.Components;
using Celeste.Core.Components.Rendering;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Core.Rendering;
using Celeste.Core.Rendering.States;
using Celeste.Core.Mathematics;
using Celeste.Core.Mathematics.Easing;
using Celeste.Core.Mathematics.LinearAlgebra;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Physics.Collision.Shapes;
using Celeste.Formats.Map.Entities.Structure;
using Celeste.Formats.Map.Entities.Attributes;
using Celeste.Formats.Graphics.Atlas;
using Celeste.Game.Components.Talking;
using Celeste.Game.Content.Dialogs;
using Celeste.Game.Entities.Npcs.Theo;
using Celeste.Game.Stories.Temple.Cutscenes;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Levels.Cutscenes;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Execution.Graphics;
using Celeste.Game.Execution.Engine;
using Celeste.Game.Execution.Startup;
using Celeste.Game.Settings;
using Celeste.Game.UI.Dialogue.Textboxes;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Graphics.Content.VirtualAssets;
using Celeste.Graphics.Display;
using Celeste.Graphics.Rendering;
using Celeste.Graphics.Rendering.Drawing;
using Celeste.Graphics.Rendering.Devices;
using Celeste.Graphics.Text.RichText.Layout;
using Celeste.Graphics.Text.RichText.Drawing;
using Celeste.Input.Gameplay;
using Celeste.Simulation;

namespace Celeste.Game.Stories.Interactions
{
    public class CS03DiaryState : OriginalCutsceneEntityState
    {
        private readonly ISourceEngineContext engine;
        private RoomPlayerSession player;

        public CS03DiaryState(ISourceEngineContext engine, RoomPlayerSession player)
            : base(engine)
        {
            this.engine = engine;
            this.player = player;
        }

        public override void OnBegin(OriginalLevelSceneRoot level)
        {
            OwnedComponents.Add(new SimulationCoroutine(engine, Routine()));
        }

        private IEnumerator Routine()
        {
            player.Machine.State = 11;
            player.Machine.Locked = true;
            yield return TextboxState.Say("CH3_DIARY", engine);
            yield return 0.1f;
            EndCutscene(Level);
        }

        public override void OnEnd(OriginalLevelSceneRoot level)
        {
            player.Machine.Locked = false;
            player.Machine.State = 0;
        }
    }
}

using System;
using System.Collections;
using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Geometry;
using Celeste.Core.Scheduling;
using Celeste.Scene.Entities;
using Celeste.Scene.Tracking;
using Celeste.Simulation;
using Celeste.Simulation.Presentation.Lighting;
using Celeste.Graphics.Content;
using Celeste.Graphics.Content.Atlas;
using Celeste.Game.Entities.Npcs;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Game.Settings;
using Celeste.Game.Audio;
using Celeste.Game.Stories.CelestialResort.Cutscenes;
using Celeste.Formats.Map.Entities.Structure;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroLobbyBellState : SceneEntityState
    {
        private OriginalTalkComponent talker;
        private readonly ISourceEngineContext Engine;

        public OriginalOshiroLobbyBellState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Engine = engine;
            OwnedComponents.Add(talker = new OriginalTalkComponent((IOriginalTalkProcess)engine,
                new IntRect(-8, -8, 16, 16), new Vector2(0f, -24f), OnTalk));
            talker.Enabled = false;
        }

        private void OnTalk(RoomPlayerSession player)
        {
            ((IOriginalGameplayProcess)Engine).AudioSession.Play("event:/game/03_resort/deskbell_again", Position,
                ((IOriginalGameplayProcess)Engine).SaveContext);
        }

        public override void Update()
        {
            if (!talker.Enabled &&
                ((OriginalLevelSceneRoot)Scene).SourceScene.Entities.FindFirst<OriginalOshiroLobbyState>() == null)
            {
                talker.Enabled = true;
            }

            base.Update();
        }
    }
}

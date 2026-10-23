using System.Numerics;
using Celeste.Core.Components;
using Celeste.Core.Scheduling;
using Celeste.Game.Components.Talking;
using Celeste.Game.Execution.Levels;
using Celeste.Game.Execution.Processes;
using Celeste.Scene.Entities;
using Celeste.Simulation;

namespace Celeste.Game.Entities.Npcs.Oshiro
{
    public class OriginalOshiroLobbyBellState : SceneEntityState
    {
        private readonly OriginalTalkComponent talker;
        private readonly ISourceEngineContext Engine;

        public OriginalOshiroLobbyBellState(ISourceEngineContext engine, Vector2 position)
            : base(((ISourceEntitySourceDataEnvironment)engine).EntitySourceDataRegistration, position)
        {
            Engine = engine;
            OwnedComponents.Add(talker = new((IOriginalTalkProcess)engine,
                new(-8, -8, 16, 16), new(0f, -24f), OnTalk));
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
                talker.Enabled = true;

            base.Update();
        }
    }
}
